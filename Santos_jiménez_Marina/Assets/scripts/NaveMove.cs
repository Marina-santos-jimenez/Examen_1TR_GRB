using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaveMove : MonoBehaviour
{
    // Start is called before the first frame update
    private bool inMarginMoveX = true;
    private bool inMarginMoveY = true;
    public float speed;

   
    void Start()
    {
        speed = 10f;
    }

    // Update is called once per frame
    void Update()
    {
       

        MovimientoSphere();

    }

    void MovimientoSphere()
    {
        float posX = transform.position.x;
        float posZ = transform.position.z;
        float desplZ = Input.GetAxis("Vertical");
        float desplX = Input.GetAxis("Horizontal");
       



        if (posX < 21 && posX > -21f || posX < -21f && desplX > 0 || posX > 20f && desplX < 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX);
           
        }

        if (posZ < 21f && posZ > -21f || posZ < -21f && desplZ > 0 || posZ > 21f && desplZ < 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * desplZ);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "suelo")
        {
            print("Chocado");
            Destroy(gameObject);
            speed = 0;
        }
         
    }
}
