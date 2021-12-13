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
        private int animId_JumpSpeed;
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
        public ParticleSystem feetEffect;
        private ParticleSystem.EmissionModule feetEffectEmission;

        //public GameObject jumpEffect;


        public GameObject[] woods;



        private float xzSpeed;

        private bool isSlideable = false;



        //private int woodCount = 0;
        //public int WoodCount {
        //    set {
        //        woodCount = Mathf.Clamp(value, 0, 4);
        //        for (int i = 0; i < 4; i++)
        //            woods[i].SetActive(i < woodCount);
        //    }
        //    get => woodCount;
        //}



        private void Awake () {
            S = this;
            trans = transform;
            rigid = GetComponent<Rigidbody>();

            animId_MoveSpeed = Animator.StringToHash("MoveSpeed");
            animId_JumpSpeed = Animator.StringToHash("JumpSpeed");
            animId_SlideSpeed = Animator.StringToHash("SlideSpeed");
            animId_IsSlideable = Animator.StringToHash("IsSlideable");

            colliderCenterY_stand = capsuleColl.center.y;
            colliderHeight_stand = capsuleColl.height;

            if(tmpCamera != null)
                tmpCamera.gameObject.SetActive(false);

            feetEffectEmission = feetEffect.emission;
        }


        private void OnEnable() {
			controlBinding = ControlBinding.CreateWithDefaultBindings();
			LoadBindings();
        }



        void Update () {
            if(isGround) {
                if(controlBinding.Jump.WasPressed) {
                    // rigid.AddExplosionForce(jumpPower, trans.position,  10.0f, 0.0f, ForceMode.VelocityChange);
                    //GameObject fx = Instantiate(jumpEffect);
                    //fx.transform.position = jumpEffect.transform.position;
                    //fx.transform.eulerAngles = Vector3.right * 90.0f;
                    //fx.SetActive(true);
                    //Destroy(fx, 5.0f);

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


            feetEffectEmission.enabled = rigid.velocity.magnitude > 5.0f;


            if(!isGround) {
                float jumpSpeed = rigid.velocity.y;
                
                if(jumpSpeed > 0) {
                    jumpSpeed = Mathf.Min((jumpPower - jumpSpeed)*2.2f, yVelocityMinMax.y) / yVelocityMinMax.y;

                    jumpSpeed = 1.0f - jumpSpeed;
                    jumpSpeed = Mathf.Clamp01(jumpSpeed * jumpSpeed * 0.8f);
                    jumpSpeed = 1.0f - jumpSpeed;
                    jumpSpeed = jumpSpeed * 0.5f;
                    animator.SetFloat(animId_JumpSpeed, jumpSpeed);
                }
                else {
                    jumpSpeed = Mathf.Max(-jumpSpeed*jumpSpeed, yVelocityMinMax.x) / yVelocityMinMax.x;
                    jumpSpeed = 0.5f + jumpSpeed * 0.5f;
                }


            } else {
                animator.SetFloat(animId_JumpSpeed, 0.0f);
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
                animator.SetFloat(animId_SlideSpeed, rigid.velocity.magnitude);
                animator.SetBool(animId_IsSlideable, false);

                if(!controlBinding.Fire.IsPressed) {
                    physicMaterial.dynamicFriction = 1.0f;
                    physicMaterial.staticFriction = 1.0f;
                }

            } else {
                animator.SetFloat(animId_SlideSpeed, 0.0f);
            }

            if(rigid.velocity.magnitude < 9.0f) {
                capsuleColl.center = Vector3.up * colliderCenterY_stand;
                capsuleColl.height = colliderHeight_stand;
                slipperyWallPhysic.enabled = true;

                animator.SetBool(animId_IsSlideable, false);
            }
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
                    isGround = true;
                    animator.SetFloat(animId_JumpSpeed, 0.0f);
                    break;
                }
                else
                {
                    isGround = false;
                    animator.SetFloat(animId_JumpSpeed, 0.5f);
                }
            }

        }

        void OnCollisionExit (Collision collisionInfo) {
            isGround = false;
            animator.SetFloat(animId_JumpSpeed, 0.5f);
        }

        void OnDisable()
		{
			controlBinding.Destroy();
		}
    }
}