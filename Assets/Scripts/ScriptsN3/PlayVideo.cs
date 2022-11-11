using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayVideo : MonoBehaviour
{
public GameObject videoPlayer;
public int timeToStop;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.SetActive(false);
    }

void OnTriggerEnter2D(Collider2D player){

    if(player.gameObject.tag=="Player")
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach(AudioSource a in audios)
        {
            a.Pause();
        }
        
        videoPlayer.SetActive(true);
        Destroy(videoPlayer,timeToStop);
        
        player.GetComponent<PlayerRespawn>().ReachedCheckPoint(transform.position.x, transform.position.y);
}
}
}
