using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaEnemigoVolador : MonoBehaviour
{/*
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;
public float hit = 1;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized*speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        //Destroy(this.gameObject,2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D (Collision2D collision) {
        var player = collision.collider.GetComponent<MakoNivel3>();
                //Invoke("Destruir_",2);
       if (player) {
            player.TakeHit (hit);
            Destroy(gameObject);
        }
    }
    */
    public float speed = 5;
    Transform player;
    public float hit = 1;
    void Start(){

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update(){
     transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);

    }
     private void OnCollisionEnter2D (Collision2D collision) {
        var player = collision.collider.GetComponent<MakoNivel3>();
                //Invoke("Destruir_",2);
       if (player) {
            player.TakeHit (hit);
            Destroy(gameObject);
        }
    }
}
