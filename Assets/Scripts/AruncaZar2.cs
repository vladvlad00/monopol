using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AruncaZar2 : MonoBehaviour
{

    static Rigidbody rb;
    public static Vector3 vitezaZar;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        vitezaZar = rb.velocity;

        if (Input.GetKeyDown(KeyCode.Space) && vitezaZar == Vector3.zero && AruncaZar1.vitezaZar == Vector3.zero && Base.seJoaca == false)
        {
            arunca();
        }
    }

    private Vector3 spawnRandom()
    {
        Vector3 rez = new Vector3();
        rez.x = Random.Range(-100, 100);
        rez.y = 2;
        rez.z = Random.Range(-100, 100);
        return rez;
    }

    private Quaternion rotRandom()
    {
        Vector3 rez = new Vector3();
        rez.x = Random.Range(0, 3) * 90;
        rez.y = Random.Range(0, 3) * 90;
        rez.z = Random.Range(0, 3) * 90;
        return Quaternion.Euler(rez);
    }

    public void arunca()
    {
        AfisareZar.nrZar2 = 0;
        float dirX = Random.Range(0, 500);
        float dirY = Random.Range(0, 500);
        float dirZ = Random.Range(0, 500);
        transform.position = spawnRandom();
        //transform.position = new Vector3(0,2,0);
        transform.rotation = rotRandom();
        //rb.AddForce(new Vector3(200f, 0f, 100f));
        //rb.AddTorque(dirX, dirY, dirZ);
        rb.AddForce(Random.onUnitSphere * 10f, ForceMode.Impulse);
        rb.AddTorque(Random.onUnitSphere * 10f, ForceMode.Impulse);
    }
}
