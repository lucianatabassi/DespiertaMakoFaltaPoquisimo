using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;
public class AIEnemigoVolador : MonoBehaviour
{
    public Transform target; //Mako
    public float speed = 200f;
    public float nextWaypointDistance = 3f; //cuan cerca tiene que estar de un waypoint para moverse a otro
    //Vida enemigo
    public float PuntosVidaE;  //Conteo de vida
    public float VidaMaximaE = 2;  //Vida maxim
    //public Transform enemyGFX;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    
    //LOGICA DISPARO
    public float shootingRange;
    public GameObject bullet;
    public GameObject bulletParent;
    private float fireRate = 2f;
    private float nextFireTime;

    private Animator anim;
    public GameObject explosion;

    void Start()
    {
        target = GameObject.Find("MakoN3").transform;
        seeker = GetComponent<Seeker>(); //encuentra al componente seeker
        rb = GetComponent<Rigidbody2D>(); //same con el rb
        anim = GetComponent<Animator>();
        InvokeRepeating("UpdatePath", 0f, .5f);
         PuntosVidaE = VidaMaximaE;

    }
void UpdatePath()
{
    if(seeker.IsDone()){
     seeker.StartPath(rb.position, target.position, OnPathComplete); //accede al seeker para crear el path a partir de la posicion del objetivo y le damos la posicion target final, ademas llamamos a la funcion cuando esta calculando el path
}
}
void OnPathComplete(Path p)
{
    if(!p.error)
    {
       path = p; //si no hay error, le asigna el path
    currentWaypoint = 0; //se resetea
    }
}
    // Update is called once per frame
    void Update()
    {
        if (target== null) { // cuando muere el personaje que deja de ejecutarse el codigo de seguimiento
         return;
        }
        if(path == null)
        {
            return;
        }
        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }else{
            reachedEndOfPath = false;
        }

        //mover el personaje
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        
        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
        
        if(force.x >= 0.01f)
        {
            transform.localScale = new Vector3 (-1f,1f,1f);

        }else if (force.x <= -0.01f)

{
    transform.localScale = new Vector3 (1f,1f,1f);

} 
float distanceFromPlayer = Vector2.Distance(target.position,transform.position);
   
   if(distanceFromPlayer < distance && distanceFromPlayer > shootingRange)
   {
    transform.localScale = new Vector3 (1f,1f,1f);
   } else if(distanceFromPlayer <= shootingRange && nextFireTime <Time.time){
    GameObject prefab = Instantiate(bullet,bulletParent.transform.position, Quaternion.identity);
    nextFireTime = Time.time + fireRate;
     Destroy(prefab, 2f);
   }
   
   }
    //VIDA ENEMIGO
#region 
   public void TakeHit(float golpe)
    {
        PuntosVidaE -= golpe;
        // gameObject.GetComponent <Animator>().SetTrigger("enemyHurt");
        // NuevoSonido(SonidoEnemigoHerido[0], 1f);
        if(PuntosVidaE <= 0 )
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            //anim.SetBool("ojoExplota", true);
            Destroy(gameObject);
        }
    }
#endregion
void CambiarEscenaGameOver()
     {
        SceneManager.LoadScene(13);
     }
  
}
