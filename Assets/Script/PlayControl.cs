using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayControl : MonoBehaviour
{
    private Rigidbody rb;
    private int score;
    public float speed;
    public Text scoreText;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float move_Hor = Input.GetAxis("Horizontal");
        float move_ver = Input.GetAxis("Vertical");
        Vector3 moveMent = new Vector3(move_Hor,0.0f,move_ver);
        rb.AddForce(moveMent*speed);

    }

    // on tigger 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("item"))
        {
            other.gameObject.SetActive(false);
            score+=1;
            SetScoreText();
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }

    }

    void SetScoreText()
    {
        scoreText.text = "score : " + score.ToString();
        if (score==4)
        {
            winText.text = "Congrat ! ! !";
        }
    }
}
