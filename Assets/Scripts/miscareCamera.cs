using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miscareCamera : MonoBehaviour
{
    static float x = 0, y = 0, z = 0;

    float shift = 1f;

    Vector3 Origine = new Vector3(x, y, z);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift)) shift = 10f;
        if (Input.GetKeyUp(KeyCode.LeftShift)) shift = 1f;
        if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * 100 * shift);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * 100 * shift);
        }

        if(Input.GetKey(KeyCode.W))
        {
            if (Vector3.Distance(transform.position, Origine) > 150f)
            {
                transform.position = Vector3.MoveTowards(transform.position, Origine, 100f * Time.deltaTime * shift);
            }
        }
        else if(Input.GetKey(KeyCode.S))
        {
            if (Vector3.Distance(transform.position, Origine) < 700f)
            {
                transform.position = Vector3.MoveTowards(transform.position, Origine, -100f * Time.deltaTime * shift);
            }
        }

        if(Input.GetKey(KeyCode.KeypadPlus))
        {
            if (transform.position.y < 450f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 1f * shift, transform.position.z);
            }
        }
        else if (Input.GetKey(KeyCode.KeypadMinus))
        {
            if (transform.position.y > 25f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 1f * shift, transform.position.z);
            }
        }

        float marg = 245f;

        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (Origine.x < marg) Origine = new Vector3(Origine.x + 1f * shift, Origine.y, Origine.z);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Origine.x > -marg) Origine = new Vector3(Origine.x - 1f * shift, Origine.y, Origine.z);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (Origine.z < marg) Origine = new Vector3(Origine.x, Origine.y, Origine.z + 1f * shift);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (Origine.z > -marg) Origine = new Vector3(Origine.x, Origine.y, Origine.z - 1f * shift);
        }

        transform.LookAt(Origine);
    }

    public void resetOrigineO()
    {
        Origine = new Vector3(x, y, z);
    }
    public void resetOrigineP()
    {
        Origine = Base.players[Base.laRand].pion.transform.position;
    }
}
