using UnityEngine;

namespace Game.Movement
{
    public class Mover : MonoBehaviour
    {
        public void Move(Rigidbody characterRb, float speed)
        {
            characterRb.velocity = transform.forward * speed * Time.deltaTime;
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
