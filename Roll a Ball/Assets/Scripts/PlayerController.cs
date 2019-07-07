using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;

    public Text lifeText;
    private Rigidbody rb;
    private int count;
    private int score;
    private int life;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        life = 3;
        winText.text = "";
        scoreText.text = "";

        SetAllText();

    }
      void FixedUpdate ()
   {
       float moveHorizontal = Input.GetAxis ("Horizontal");
       float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

       rb.AddForce (movement * speed);

       if (Input.GetKey("escape"))
     Application.Quit();
   }
   void OnTriggerEnter(Collider other)
{
        
    if (count == 11) // note that this number should be equal to the number of yellow pickups on the first playfield
        {
    transform.position = new Vector3(35.0f, transform.position.y,0.0f); 
        }


        if (other.gameObject.CompareTag("Pick Up")){
            other.gameObject.SetActive (false);
            count = count + 1;
            score = score + 1; // I added this code to track the score and count separately.
            SetAllText();
        }
    else if (other.gameObject.CompareTag("Enemy"))
     {
          other.gameObject.SetActive(false);
          count = count + 1;  
          score = score - 1; // this removes 1 from the score
          life = life - 1; // this removes 1 from the life
          SetAllText();
     }  

    if (life == 0)
        { 
            Destroy(this.gameObject);
                }
                
}
    void SetAllText ()
    { 
        lifeText.text = "Lives: " + life.ToString();
        scoreText.text = "Score: " + score.ToString(); 
        countText.text = "Count: " + count.ToString ();
        if (count >= 20){
            winText.text = "You Win!";
            }
             if (life == 0){
            winText.text = "You Lose!";
                 }
    }
}
