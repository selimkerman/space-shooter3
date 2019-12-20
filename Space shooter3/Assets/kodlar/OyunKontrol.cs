using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour
{
    public GameObject Asteroid;
    public Vector3 randomPossition;
    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;
    public Text text;
    bool oyunBittiKontrol = false;
    bool yenidenBaslaKontrol = false;

    public Text gameOverYazisi;
    public Button yenidenBaslat;


    int score;
     
    // enumerator kullandıgımız için "startCoroutine"  kullanılmıştır
    void Start()
    {
        score = 0;
        text.text = "score = " + score;
        StartCoroutine(olustur()) ;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R ) && yenidenBaslaKontrol)
        {
            SceneManager.LoadScene("lvl1");
        }
    }

    // Gök Taşlarını oluşturur 
    IEnumerator olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);
        while (true)
        {
           for (int i = 0; i < 10; i++)
           {
             Vector3 vec = new Vector3(Random.Range(-randomPossition.x, randomPossition.x), (randomPossition.y), (randomPossition.z));
             Instantiate(Asteroid, vec, Quaternion.identity);
             yield return new WaitForSeconds(olusturmaBekleme);
          }
        yield return new WaitForSeconds(donguBekleme);

            if (oyunBittiKontrol)
            {
                yenidenBaslaKontrol = true;
                break;
            }
                
        }
        
        
    }

    public void ScoreArttir( int gelenScore)
    {
        score += gelenScore;
        text.text = "score = " + score;
        Debug.Log("score" + score);
    }

    public void GameOver()
    {
        gameOverYazisi.text = " game over";
        oyunBittiKontrol = true;
        SceneManager.LoadScene("AnaMenu");

    }
   
}
