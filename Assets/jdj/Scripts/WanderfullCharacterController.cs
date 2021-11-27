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


        public float forwardSpeed = 10.0f;
        public float sideSpeed = 5.0f;
        public float torque = 10.0f;


        public float jumpPower = 10.0f;
        public Vector2 yVelocityMinMax = new Vector2(-4.5f, 2.5f);
        public float xzVelocityMax = 20.0f;
        public float torqueMax = 30.0f;





        public bool isGround = false;




        private void Awake () {
            S = this;
            trans = transform;
            rigid = GetComponent<Rigidbody>();
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
            if (controlBinding.Up.IsPressed) {
                rigid.AddForce(trans.forward * forwardSpeed, ForceMode.Acceleration);
            }

            if (controlBinding.Down.IsPressed) {
                rigid.AddForce(trans.forward * -forwardSpeed, ForceMode.Acceleration);
            }

            if (controlBinding.Left.IsPressed) {
                rigid.AddForce(trans.right * -sideSpeed, ForceMode.Acceleration);
            }

            if (controlBinding.Right.IsPressed) {
                rigid.AddForce(trans.right * sideSpeed, ForceMode.Acceleration);
            }



            if (controlBinding.Left.IsPressed) {
                rigid.AddTorque(trans.up * -torque, ForceMode.Acceleration);
            }

            if (controlBinding.Right.IsPressed) {
                rigid.AddTorque(trans.up * torque, ForceMode.Acceleration);
            }


            Vector2 xzVelocity = new Vector2(rigid.velocity.x, rigid.velocity.z);
            if(xzVelocity.magnitude > xzVelocityMax)
                xzVelocity = xzVelocity.normalized * xzVelocityMax;

            rigid.velocity = new Vector3 (xzVelocity.x, Mathf.Clamp(rigid.velocity.y, yVelocityMinMax.x, yVelocityMinMax.y), xzVelocity.y);
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