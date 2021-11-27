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

        public Animator animator;
        private int animId_speed;


        public float forwardSpeed = 10.0f;
        public float sideSpeed = 5.0f;
        public float torque = 10.0f;


        public float jumpPower = 10.0f;
        public Vector2 yVelocityMinMax = new Vector2(-4.5f, 2.5f);
        public float xzVelocityMax = 20.0f;
        public float torqueMax = 30.0f;

        public bool isGround = false;
        public Transform tmpCamera;






        private void Awake () {
            S = this;
            trans = transform;
            rigid = GetComponent<Rigidbody>();

            animId_speed = Animator.StringToHash("MoveSpeed");

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
                    rigid.AddExplosionForce(jumpPower, trans.position,  10.0f, 0.0f, ForceMode.VelocityChange);
                }
            }

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


            rigid.AddForce(addForce, ForceMode.Acceleration);
            rigid.AddTorque(addTorque, ForceMode.Acceleration);


            Vector2 xzVelocity = new Vector2(rigid.velocity.x, rigid.velocity.z);
            float xzSpeed = xzVelocity.magnitude;
            if(xzSpeed > xzVelocityMax)
                xzVelocity = xzVelocity.normalized * xzVelocityMax;

            rigid.velocity = new Vector3 (xzVelocity.x, Mathf.Clamp(rigid.velocity.y, yVelocityMinMax.x, yVelocityMinMax.y), xzVelocity.y);


            animator.SetFloat(animId_speed, Mathf.Clamp01(xzSpeed/xzVelocityMax));
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
            isGround = true;
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