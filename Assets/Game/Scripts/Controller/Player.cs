using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Movement;

namespace Game.Controller
{
    public class Player : MonoBehaviour
    {
        Rigidbody rb;
        [SerializeField] float rotSpeed;
        [SerializeField] float moveSpeed;
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void Update()
        {
            Strike();
        }
        // Update is called once per frame
        void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            Vector3 direction=new Vector3(-vertical, 0, horizontal);
            direction.Normalize();
            if(direction != Vector3.zero)
            {
                GetComponent<Mover>().RotateSelf(direction, rotSpeed);
            }
            GetComponent<Mover>().Move(rb, moveSpeed*direction.magnitude);
        }
        private Vector3 MousePosition()
        {
            Vector3 mousePos = Input.mousePosition;
            Vector3 worldPos;
            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray,out hitInfo, 1000))
            {
                worldPos = hitInfo.point;
                return new Vector3(worldPos.x,transform.position.y,worldPos.z);
            }
            else
            {
                return Vector3.zero;
            }
        }
        private void Strike()
        {
            Vector3 pos;
            if(Input.GetButtonDown("Fire1"))
            {
                pos = MousePosition();
                pos = new Vector3(pos.x-transform.position.x,transform.position.y, pos.z-transform.position.z);
                if (pos != Vector3.zero)
                {
                    GetComponent<Mover>().RotateToward(pos,rotSpeed);
                }
            }
        }
    }
}
