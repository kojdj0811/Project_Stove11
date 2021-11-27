using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;


namespace jdj {
    public class WanderfullCharacterController : MonoBehaviour
    {
        public static WanderfullCharacterController S;

		ControlBinding controlBinding;
		string saveData;


        private Transform trans;
        private Rigidbody rigid;
        public CapsuleCollider capsuleColl;
        public CapsuleCollider slipperyWallPhysic;
        
        public PhysicMaterial physicMaterial;

        public Animator animator;
        private int animId_MoveSpeed;
        private int animId_SlideSpeed;
        private int animId_IsSlideable;


        public float forwardSpeed = 40.0f;
        public float slideScale  = 2.0f;
        public float sideSpeed = 0.0f;
        public float torque = 15.0f;


        public float jumpPower = 20.0f;
        public Vector2 yVelocityMinMax = new Vector2(-5.0f, 2.0f);
        public float xzVelocityMax = 10.0f;
        public float torqueMax = 30.0f;

        public bool isGround = false;

        public float colliderCenterY_sliding = 0.5f;
        public float colliderHeight_sliding = 1.0f;

        private float colliderCenterY_stand;
        private float colliderHeight_stand;



        public Transform tmpCamera;


        private float xzSpeed;

        private bool isSlideable = false;





        private void Awake () {
            S = this;
            trans = transform;
            rigid = GetComponent<Rigidbody>();

            animId_MoveSpeed = Animator.StringToHash("MoveSpeed");
            animId_SlideSpeed = Animator.StringToHash("SlideSpeed");
            animId_IsSlideable = Animator.StringToHash("IsSlideable");

            colliderCenterY_stand = capsuleColl.center.y;
            colliderHeight_stand = capsuleColl.height;

            if(tmpCamera != null)
                tmpCamera.gameObject.SetActive(false);
        }


        private void OnEnable() {
			controlBinding = ControlBinding.CreateWithDefaultBindings();
			LoadBindings();
        }



        void Update () {
            if(isGround) {
                if(controlBinding.Jump.WasPressed) {
                    // rigid.AddExplosionForce(jumpPower, trans.position,  10.0f, 0.0f, ForceMode.VelocityChange);
                    rigid.velocity += Vector3.up * jumpPower;;
                }




                if(!isSlideable) {
                    isSlideable = rigid.velocity.magnitude < 9.0f;
                    animator.SetBool(animId_IsSlideable, true);

                    capsuleColl.center = Vector3.up * colliderCenterY_sliding;
                    capsuleColl.height = colliderHeight_sliding;
                    slipperyWallPhysic.enabled = false;

                    physicMaterial.dynamicFriction = 0.0f;
                    physicMaterial.staticFriction = 0.0f;
                }

                if(controlBinding.Fire.WasPressed && isSlideable
                && rigid.velocity.magnitude > 9.0f && rigid.velocity.magnitude < 13.0f
                && animator.GetFloat(animId_MoveSpeed) > 0.5f) {
                    Vector3 addForce = new Vector2(rigid.velocity.x, rigid.velocity.z).magnitude * trans.forward * slideScale;
                    rigid.velocity += addForce;

                    Vector2 xzVelocity = new Vector2(rigid.velocity.x, rigid.velocity.z);
                    xzSpeed = xzVelocity.magnitude;
                    xzSpeed = 0.0f;

                    isSlideable = false;
                }
            }






            // physicMaterial.dynamicFriction = controlBinding.Fire.IsPressed ? 0.0f : 1.0f;
            // physicMaterial.staticFriction = controlBinding.Fire.IsPressed ? 0.0f : 1.0f;
        }


        void FixedUpdate () {

            Vector3 addForce = Vector3.zero;
            Vector3 addTorque = Vector3.zero;


            addForce += controlBinding.Up.Value * trans.forward * forwardSpeed;
            addForce += controlBinding.Down.Value * trans.forward * -forwardSpeed;
            addForce += controlBinding.Left.Value * trans.right * -sideSpeed;
            addForce += controlBinding.Right.Value * trans.right * sideSpeed;

            addTorque += controlBinding.Left.Value * trans.up * -torque;
            addTorque += controlBinding.Right.Value * trans.up * torque;



            if(controlBinding.Fire.Value == 0.0f) {
                if(!animator.GetBool(animId_IsSlideable)) {
                    rigid.AddForce(addForce, ForceMode.Acceleration);
                    rigid.AddTorque(addTorque, ForceMode.Acceleration);
                }

                Vector2 xzVelocity = new Vector2(rigid.velocity.x, rigid.velocity.z);
                xzSpeed = xzVelocity.magnitude;
                if(xzSpeed > xzVelocityMax)
                    xzVelocity = xzVelocity.normalized * xzVelocityMax;

                rigid.velocity = new Vector3 (xzVelocity.x, Mathf.Clamp(rigid.velocity.y, yVelocityMinMax.x, yVelocityMinMax.y), xzVelocity.y);

            }






            animator.SetFloat(animId_MoveSpeed, Mathf.Clamp01(xzSpeed/xzVelocityMax));

            if((controlBinding.Fire.IsPressed && isGround)
            || (!controlBinding.Up.IsPressed && !controlBinding.Down.IsPressed && !controlBinding.Left.IsPressed && !controlBinding.Right.IsPressed)
            && rigid.velocity.magnitude < 9.0f) {
                capsuleColl.center = Vector3.up * colliderCenterY_stand;
                capsuleColl.height = colliderHeight_stand;
                slipperyWallPhysic.enabled = true;

                animator.SetFloat(animId_SlideSpeed, rigid.velocity.magnitude);
                animator.SetBool(animId_IsSlideable, false);

                if(!controlBinding.Fire.IsPressed) {
                    physicMaterial.dynamicFriction = 1.0f;
                    physicMaterial.staticFriction = 1.0f;
                }

            } else {
                animator.SetFloat(animId_SlideSpeed, 0.0f);
            }

            if(rigid.velocity.magnitude < 9.0f)
                animator.SetBool(animId_IsSlideable, false);

        }


		void SaveBindings()
		{
			saveData = controlBinding.Save();
			PlayerPrefs.SetString( "Bindings", saveData );
		}


		void LoadBindings()
		{
			if (PlayerPrefs.HasKey( "Bindings" ))
			{
				saveData = PlayerPrefs.GetString( "Bindings" );
				controlBinding.Load( saveData );
			}
		}


        void OnCollisionStay (Collision collisionInfo) {
            foreach (ContactPoint contact in collisionInfo.contacts)
            {
                if((1.0f - Vector3.Dot(Vector3.up, contact.normal)) * Mathf.Rad2Deg <  20.0f) {
                    Debug.Log($"{contact.thisCollider.transform.name}");
                    isGround = true;
                    break;
                }
            }

        }

        void OnCollisionExit (Collision collisionInfo) {
            isGround = false;
        }


		void OnDisable()
		{
			controlBinding.Destroy();
		}
    }
}