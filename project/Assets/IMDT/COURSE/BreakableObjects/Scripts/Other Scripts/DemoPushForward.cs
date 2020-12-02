using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoPushForward : MonoBehaviour
{
    public float force = 10f;
    private Rigidbody rd;
    //public float speed_x;
    public float speed_y;
    //public float speed_z;
    public float a;
    public float f;
    public float max_speed;

    // Use this for initialization
    void Start()
    {
        //GetComponent<Rigidbody>().AddForce(transform.forward * force);
        rd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rd = GetComponent<Rigidbody>();
        float horizontal_move = Input.GetAxisRaw("Horizontal");
        float vertical_move = Input.GetAxisRaw("Vertical");
        Vector3 v = new Vector3(rd.velocity.x, rd.velocity.y, rd.velocity.z);
        if (rd.velocity.x >0)
        {
            v[0] = (rd.velocity.x-f)>0?(rd.velocity.x-f):0;
        }
        else if (rd.velocity.x < 0)
        {
            v[0] = (rd.velocity.x + f) < 0 ? (rd.velocity.x + f) : 0;
        }
        if (rd.velocity.z > 0)
        {
            v[2] = (rd.velocity.z - f) > 0 ? (rd.velocity.z - f) : 0;
        }
        else if (rd.velocity.z < 0)
        {
            v[2] = (rd.velocity.z + f) < 0 ? (rd.velocity.z + f) : 0;
        }
        if (horizontal_move != 0)
        {
            v[0] = v[0] + horizontal_move * a;
        }
        if (vertical_move != 0)
        {
            v[2] = v[2] + vertical_move * a;
        }
        if (Input.GetKeyDown(KeyCode.Space) && rd.velocity.y == 0)
        {

            v[1] = speed_y;

        }
        if (v[0] > max_speed) v[0] = max_speed;
        else if (v[0] < -max_speed) v[0] = -max_speed;
        if (v[2] > max_speed) v[2] = max_speed;
        else if (v[2] < -max_speed) v[2] = -max_speed;
        rd.velocity = v;
    }

}
