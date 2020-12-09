using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemigoCreator : MonoBehaviour
 
{
   
    public int contador;
    public int nObstaculo;
    [SerializeField] Text Tiempo;
    [SerializeField] Text ContadorColumnas;
    private float tiempo = 0;
    private float segundos = 0;
    [SerializeField] Collider other;
    [SerializeField] GameObject Enemigo;
    // Start is called before the first frame update
    void Start()
    {
        
            for (int n = 1; n <= 20; n++)
            {
                StartCoroutine("ObstaculoCoroutine");

            }
    }

    // Update is called once per frame
    void Update()
    {
        TextoUI();
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
    void TextoUI()
    {
        nObstaculo = contador;

        tiempo += Time.deltaTime;
        segundos = tiempo % 60;
        ContadorColumnas.text = "Nº de columnas: " + nObstaculo;
        Tiempo.text = "Tiempo : " + segundos.ToString("f1") + " segs";
    }

}
