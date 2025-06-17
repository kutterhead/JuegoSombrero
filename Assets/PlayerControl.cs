using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity = 10;

    public Transform gorroPointer;
    [SerializeField] int numGorros = 0;

    [SerializeField] int vidas = 3;

    public float offSetY = 0.5f;

    public gameController gc;
    void Start()
    {
        numGorros =0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right*Input.GetAxis("Horizontal")*Time.deltaTime*velocity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión con: " + collision.gameObject.tag);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisión con: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("Gorro"))
        {

            collision.gameObject.transform.position = gorroPointer.position;
            collision.gameObject.transform.SetParent(transform);
            Rigidbody2D rigidbody2D = collision.gameObject.GetComponent<Rigidbody2D>();
            rigidbody2D.simulated = false;
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            collision.gameObject.tag = "Untagged";


            sumaGorro();


       // Destroy(collision.gameObject);

        }
    }

    public void sumaGorro(){

        gorroPointer.position += new Vector3(0, offSetY, 0);

        numGorros++;

        if (numGorros>=10)
        {

            juegoTerminado();

        }

    }



    public void restaVida(){

        vidas--;
        if (vidas<1)
        {
            gameOver();

        }

    }

    public void juegoTerminado()//juego conseguido
    {

        if (gc != null)
        {
            gc.enabled = false;

            Destroy(gc);
            this.enabled = false;//deshabilita script player
        }
        Debug.Log("Juego terminado");
    }
    public void gameOver()//no quedan vidas
    {

        if (gc!=null)
        {
            gc.enabled = false;

           Destroy(gc);
            this.enabled = false;

        }

        Debug.Log("Juego terminado");
    }

}
