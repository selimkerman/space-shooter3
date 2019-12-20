using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOl : MonoBehaviour
{
    public GameObject patlama;
    public GameObject playerPatlama;
    GameObject OyunKontrol;
    OyunKontrol kontrol;

    private void Start()
    {
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrol");
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "sinir")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, transform.position, transform.rotation);
            kontrol.ScoreArttir(10);
        }
        if(other.tag == "Player")
        {
            Instantiate(playerPatlama, other.transform.position, other.transform.rotation);
            kontrol.GameOver();
        }
       
    }

}
