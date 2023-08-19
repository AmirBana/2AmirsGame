using System;
using UnityEngine;

namespace Game.Movement
{
    public class Mover : MonoBehaviour
    {
        Animator anim;
        private void Start()
        {
            anim = GetComponent<Animator>();
        }
        public void Move(float speed,Vector3 dir)
        {
            if (dir != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(dir, Vector3.up);
                Quaternion diff = toRotation * Quaternion.Inverse(transform.rotation);
                Vector3 moveDir = CalculateMoveDir(diff.eulerAngles);
                print(moveDir);
                anim.SetFloat("VelocityY", moveDir.z * speed);
                anim.SetFloat("VelocityX", moveDir.x * speed);
            }
            else
            {
                anim.SetFloat("VelocityY", 0);
                anim.SetFloat("VelocityX", 0);
            }

        }

        private Vector3 CalculateMoveDir(Vector3 diff)
        {
            float x=0, z=0;
            if(diff == Vector3.zero)
            {
                return new Vector3(0, 0, 1);
            }
            else if(diff.y <= 90)
            {
                x = 90 - diff.y;
                z = diff.y;

            }
            else if( diff.y <= 180)
            {
                x = diff.y - 90;
                z = diff.y - 180; 
            }
            else if(diff.y <= 270)
            {
                x = diff.y - 270;
                z = 180 - diff.y;

            }
            else if(diff.y <= 360)
            {
                z = 360 - diff.y;
                x = diff.y - 270;
            }
            Vector3 moveRot = new Vector3(x, 0, z).normalized;
            return moveRot;
        }

        public void RotateSelf(Vector3 direction,float rotSpeed)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotSpeed * Time.deltaTime);
        }
        public void RotateToward(Vector3 pos,float rotSpeed)
        {
            Quaternion toRotation = Quaternion.LookRotation(pos, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, Time.deltaTime*rotSpeed);
        }
    }
}
