using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class Player : MonoBehaviour
{ 
    public Text attemps;
    public Text textS;
    [SerializeField] private float Jump = 15f;
    [SerializeField] private float Speed = 13f;
    [SerializeField] SpriteRenderer MySprite; //to Make The player flip while Moving
    public int PlayerHealth = 3;
    private float horizontalinput;
    private Rigidbody2D RigidibodyComponent;
    bool isJump;
    public GameObject level2;
    public int score = 0;



    // Start is called before the first frame update
    void Start()
    {
        isJump = false;
        RigidibodyComponent = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // Make the plyer jump one time only

        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //{
        //    MySprite.flipX = true;
        //}
        if (Input.GetButtonDown("Jump") && isJump == false)
        {

            RigidibodyComponent.velocity = new Vector2(0, Jump);
            isJump = true;
        }

        if (Mathf.Abs(RigidibodyComponent.velocity.y) < 0.01f)
        {
            isJump = false;
        }
        horizontalinput = Input.GetAxis("Horizontal");
        if (horizontalinput > 0)
        {
            MySprite.flipX = false;
        }
        else if (horizontalinput < 0)
        {
            MySprite.flipX = true;
        }



    }
    private void FixedUpdate()
    {
        //Make the Player Jump


        RigidibodyComponent.velocity = new Vector2(Speed * horizontalinput, RigidibodyComponent.velocity.y);

        //RigidibodyComponent.velocity = new Vector2(horizontalinput * Speed, RigidibodyComponent.velocity.y);

        //if (Physics.OverlapSphere(CheckingGrounded.position, 0.1f).Length == 1)
        //{
        //    return;
        //}

        //if (jumpkey)
        //{
        //    RigidibodyComponent.AddForce(Vector3.up * 7, ForceMode2D.);
        //    jumpkey = false;
    }
    void loadover()
    {
        SceneManager.LoadScene("GameOver");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (score < 9)
        {
            if (collision.CompareTag("GameOver"))
            {
                loadover();
            }
        }
            if (collision.CompareTag("bat"))
            if (PlayerHealth <= 0)
            {
                loadover();
            }
            else
            {
                PlayerHealth--;
                attemps.text = "Attemps:" + PlayerHealth;
                Debug.Log(PlayerHealth);
                //SceneManager.LoadScene("SampleScene");
            }
        else if (collision.gameObject.CompareTag("char"))
        {
            GetComponent<AudioSource>().Play();
            Destroy(collision.gameObject);
            score++;
            textS.text = "Score  : " + score;
        }
        if (score == 9)
        {
            level2.gameObject.SetActive(true);
        }
        if (score == 20)
        {
            textS.text = "YOU Win ";
            SceneManager.LoadScene("YouWin");

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bat"))
            if (PlayerHealth <= 0)
            {
                loadover();
                Debug.Log("Game Over");
            }
            else
            {
                PlayerHealth--;

                attemps.text = "Attemps:" + PlayerHealth;

            }

    }

}


