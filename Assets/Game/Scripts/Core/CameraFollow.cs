using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    private Vector3 distance;
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        distance = Camera.main.transform.position - player.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = distance + player.position;
        transform.position = pos;
    }
}
