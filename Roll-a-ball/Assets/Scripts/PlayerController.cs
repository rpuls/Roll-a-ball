using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text scoreText;
    public Text winmsg;

    private Rigidbody rb;
    private int score;

    void Start() {
        rb = GetComponent<Rigidbody>();
        score = 0;
        setScoreText();
        winmsg.text = "";
    }

    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("pickup")) {
            other.gameObject.SetActive(false);
            score += 1;
            setScoreText();
        }
    }

    void setScoreText() {
        scoreText.text = "Score: " + score.ToString();
        if(score >= 12) {
            winmsg.text = "YOU WIN!";
        }
    }
}