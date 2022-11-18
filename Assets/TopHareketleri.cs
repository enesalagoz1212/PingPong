using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TopHareketleri : MonoBehaviour
{
    public Rigidbody2D top;
    public float xHizi, yHizi;
    public TextMeshProUGUI player1Yazi, player2Yazi,kazanan,bitisYazisi;
    int player1Skor,player2Skor;
    public int maxSkor;
    public AudioSource skorSesi, kazanmaSesi;

    void Update()
    {
        player1Yazi.text = player1Skor.ToString();
        player2Yazi.text = player2Skor.ToString();
        if (Time.timeScale == 0)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Time.timeScale = 1;
            }
        }
    }

    
    void OnCollisionEnter2D(Collision2D  temas)
    {
        if (temas.gameObject.tag == "Player1")
        {
            top.velocity = new Vector2(-xHizi, Random.Range(-3f,3f));
        }
        else if(temas.gameObject.tag == "Player2")
        {
            top.velocity = new Vector2(xHizi, Random.Range(-3f, 3f));
        }
        

        if (temas.gameObject.tag == "UstDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, -yHizi);
        }
        else if (temas.gameObject.tag == "AltDuvar")
        {
            top.velocity = new Vector2(top.velocity.x, yHizi);
        }
        if (temas.gameObject.tag == "SolDuvar")
        {
            player1Skor++;
            transform.position = new Vector2(-6.77f, 0f);
            Time.timeScale=Time.timeScale+0.1f;
            skorSesi.Play();
        }
        else if (temas.gameObject.tag=="SagDuvar")
        {
            player2Skor++;
            transform.position = new Vector2(6.77f, 0f);
            Time.timeScale= Time.timeScale + 0.1f;
            skorSesi.Play();
        }
        if (player1Skor==maxSkor)
        {
            kazanan.text = "Player 1 Win";
            bitisYazisi.text = "Tekrar Oynamak Için Enter'a Basiniz";
            kazanmaSesi.Play();
            Time.timeScale = 0;
        }
        else if (player2Skor==maxSkor)
        {
            kazanan.text = "Player 2 Win";
            bitisYazisi.text = "Tekrar Oynamak Için Enter'a Basiniz";
            kazanmaSesi.Play();
            Time.timeScale = 0;
        }
        
    }
}
