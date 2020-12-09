using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCreator : MonoBehaviour
 
{
   
    public int contador;
    public int nObstaculo;
    private float tiempo = 0;
    private float segundos = 0;
    [SerializeField] Collider other;
    [SerializeField] GameObject Enemigo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ObstaculoCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenerarObstaculo()
    {
        float randomX = Random.Range(-20f, 20f);
        float randomZ = Random.Range(-21f, 20f);
        float randomY = Random.Range(0f, 20f);

        Vector3 RndmPos = new Vector3(randomX, randomY, randomZ);
        Instantiate(Enemigo, RndmPos, Quaternion.identity);

        IEnumerator ObstaculoCoroutine()
        {
            for (contador = 1; contador <= 5; contador++)
            {
                GenerarObstaculo();
                yield return new WaitForSeconds(4);
            }
            for (contador = 6; contador <= 10 && contador > 5; contador++)
            {
                GenerarObstaculo();
                yield return new WaitForSeconds(1);
            }
            for (contador = 11; contador > 10; contador++)
            {
                GenerarObstaculo();
                yield return new WaitForSeconds(1f);
            }
        }

    }
}
