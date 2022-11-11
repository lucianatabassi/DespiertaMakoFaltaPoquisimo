using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CheckpointCinematicaEncuentroBoss : MonoBehaviour
{
     public Image CinematicaImage;
    /* public RawImage CinematicaEncuentroBoss; */
 void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.CompareTag("Player"))
    {
        
        //CinematicaEncuentroBoss.GetComponent.SetActive(true);
         //CambiarEscena();
         
        // collision.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
    }
}
/* void OnTriggerExit2D(Collider2D colisiono)
{
    Destroy(gameObject);
}
      void CambiarEscena()
    {
      SceneManager.LoadScene(9);

      
    }
    // Update is called once per frame
    void Update()
    {
        
    } */
}
