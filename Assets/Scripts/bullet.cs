using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class bullet : MonoBehaviour
{
   // private Rigidbody2D MyRB;
    public float speed;
    public float hit = 1;

 
    void Start()
    {
        
    }

   
    void Update()
    {
        
        transform.position += transform.right * speed * Time.deltaTime; //transforma y varia la posicion el objeto
    }

    private void OnCollisionEnter2D (Collision2D collision) {
        var enemy = collision.collider.GetComponent<enemigo>(); // el script enemigo se enlaza con este
        var enemigo1 = collision.collider.GetComponent<Enemigo1>();
        var enemigo3 = collision.collider.GetComponent<MovEnemigoPlataforma>();
        var boss = collision.collider.GetComponent<Boss>();
        var enemigoVolador = collision.collider.GetComponent<AIEnemigoVolador>();
        if (enemy) {
            enemy.TakeHit(hit); //nivel de daño que le pongamos
            Destroy(gameObject);
        }

        if (enemigo1) {
            enemigo1.TakeHit(hit); //Hacer x puntos de daño
            Destroy(gameObject);
        }
        if (enemigo3) {
            enemigo3.TakeHit(hit); //Hacer x puntos de daño
            Destroy(gameObject);
        }
        if (boss) {
            boss.TakeHit(hit); //Hacer x puntos de daño
            Destroy(gameObject);
        }
        if (enemigoVolador) {
            enemigoVolador.TakeHit(hit); //Hacer x puntos de daño
            Destroy(gameObject);
        }
        if (collision.transform.tag =="ground" ) {
            Destroy(gameObject);
        }
        
    }
    
}
