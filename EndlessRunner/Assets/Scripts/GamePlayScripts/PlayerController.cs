using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 5;
    float horizontalInput;
    [SerializeField]
    RoadSpawnManager roadSpawnManager;
    [SerializeField]
    GameObject UIController;
    [SerializeField]
    float verticalVelocity;
    float gravity = 14f;
    [SerializeField]
    float jumpForce = 250f;
    [SerializeField]
    Animator anim;
    Rigidbody rb;
    [SerializeField]
    BoolSO canMove;
    bool isDead = false;
    AudioManager audioManager;
    int updateSpeedFactor = 1;
    void Start()
    {
        canMove.state = true;
        rb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>(); 
    }

    void Update()
    {
        if (canMove.state)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            ControlPlayerMovment();
            Jump();
        }
        else if (!isDead)
        {
            audioManager.PlayeSound("GameOver");
            isDead = true;
            anim.SetBool("Dead", true);
            StartCoroutine(stopDeathAnimation());
        }
    }
    void Jump()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.position.y < 0.5f)
            {
                audioManager.PlayeSound("Jump");
                // rb.AddForce(Vector3.up *jumpForce);
                transform.position = new Vector3(transform.position.x, transform.position.y + jumpForce, transform.position.z);
                anim.SetTrigger("Jump");
            }
        }
    }
    void ControlPlayerMovment()
    {
        transform.Translate(Vector3.back * Time.deltaTime * movementSpeed);
        transform.Translate(Vector3.right * -horizontalInput * Time.deltaTime * movementSpeed / 2);
    }
    void OnTriggerEnter(Collider other)
    {
        if (canMove.state)
        {
            if (other.gameObject.tag == "SpawnPoint")
                StartCoroutine(callSpawnRoad());
            else if (other.gameObject.tag == "Coin")
            {
                audioManager.PlayeSound("Collect");
                UIController.GetComponent<UIController>().AddCoins();
                other.gameObject.SetActive(false);
            }
            else if (other.gameObject.tag=="Health")
            {
                audioManager.PlayeSound("Collect");
                UIController.GetComponent<UIController>().Healing(1);
                other.gameObject.SetActive(false);
            }
            else if (other.gameObject.tag == "Health2")
            {
                audioManager.PlayeSound("Collect");
                UIController.GetComponent<UIController>().Healing(2);
                other.gameObject.SetActive(false);
            }
            else if (other.gameObject.tag == "Speed")
            {
                audioManager.PlayeSound("Collect");
                updateSpeedFactor = 3;
                StartCoroutine(UpdateSpeed());
                other.gameObject.SetActive(false);
            }
            else if (other.gameObject.tag == "Speed2")
            {
                audioManager.PlayeSound("Collect");
                updateSpeedFactor = 6;
                StartCoroutine(UpdateSpeed());
                other.gameObject.SetActive(false);
            }
            else if (other.gameObject.tag == "Jetpack")
            {
                audioManager.PlayeSound("Collect");
                StartCoroutine(UseJetPack());
                other.gameObject.SetActive(false);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            UIController.GetComponent<UIController>().ApplyDamage();
            if (UIController.GetComponent<UIController>().lifes > 1)
            {
                anim.SetTrigger("Hit");
                audioManager.PlayeSound("Hit");
            }
        }
    }
    IEnumerator stopDeathAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("Dead", false);
    }
    IEnumerator callSpawnRoad()
    {
        yield return new WaitForSeconds(0.2f);
        roadSpawnManager.MoveRoad();
    }
    IEnumerator UpdateSpeed()
    {
        movementSpeed += updateSpeedFactor;
        yield return new WaitForSeconds(4f);
        movementSpeed-=updateSpeedFactor;
    }
   
    IEnumerator UseJetPack()
    {
        movementSpeed += 10;
        this.transform.position = new Vector3(this.transform.position.x, 3, this.transform.position.z);
        anim.SetBool("Fly", true);
        rb.useGravity = false;
        yield return new WaitForSeconds(5f);
        movementSpeed -= 10;
        rb.useGravity = true;
        anim.SetBool("Fly", false);
        this.transform.position = new Vector3(this.transform.position.x, 0, this.transform.position.z);
    }

}
