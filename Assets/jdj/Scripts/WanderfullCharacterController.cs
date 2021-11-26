using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jdj {
    public class WanderfullCharacterController : MonoBehaviour
    {
        public static WanderfullCharacterController S;

        private Transform trans;
        private Rigidbody rigid;


        public float forwardSpeed = 10.0f;
        public float sideSpeed = 5.0f;
        public float torque = 10.0f;


        public float jumpPower = 10.0f;



        public bool isGround = false;




        private void Awake () {
            S = this;
            trans = transform;
            rigid = GetComponent<Rigidbody>();
        }


        void Update () {
            if(isGround) {
                if(Input.GetKeyDown(KeyCode.Space)) {
                    rigid.AddExplosionForce(jumpPower, trans.position,  10.0f, 0.0f, ForceMode.VelocityChange);
                    Debug.Log("Jump!");
                }
            }
        }


        void FixedUpdate () {
            if (Input.GetKey(KeyCode.W)) {
                rigid.AddForce(trans.forward * forwardSpeed, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.S)) {
                rigid.AddForce(trans.forward * -forwardSpeed, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.D)) {
                rigid.AddForce(trans.right * sideSpeed, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.A)) {
                rigid.AddForce(trans.right * -sideSpeed, ForceMode.Acceleration);
            }



            if (Input.GetKey(KeyCode.D)) {
                rigid.AddTorque(trans.up * torque, ForceMode.Acceleration);
            }

            if (Input.GetKey(KeyCode.A)) {
                rigid.AddTorque(trans.up * -torque, ForceMode.Acceleration);
            }
        }

        void OnCollisionStay (Collision collisionInfo) {
            isGround = true;
        }

        void OnCollisionExit (Collision collisionInfo) {
            isGround = false;
        }
    }
}