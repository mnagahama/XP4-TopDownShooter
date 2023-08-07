using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    Rigidbody rb;
    Vector3 moveInput;
    Animator animator;
    public GunControl gun;
    public GameObject bullet;
    public float shootSpeed = 25;

    public TextMeshPro healthText;
    public int health = 3;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        healthText.text = "Vida: " + health;

        moveInput = new Vector3(x, 0, z);

        if (moveInput != Vector3.zero)
        {
            animator.SetBool("isWalking", true);
            //transform.forward = Vector3.Slerp(transform.forward, moveInput, Time.deltaTime * 10);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(0))
            Shoot(bullet, shootSpeed);


    }
    private void FixedUpdate()
    {
        rb.AddForce(moveInput * speed);
    }

    void Shoot(GameObject bulletPrefab, float speed)
    {
        GameObject bulletCopy = Instantiate(bulletPrefab, gun.spawnPoint.position, gun.spawnPoint.rotation);
        bulletCopy.GetComponent<Rigidbody>().AddForce(gun.spawnPoint.forward * speed, ForceMode.Impulse);

    }

    /*IEnumerator waiter()
    {
        yield return new WaitForSeconds(1);

        LoadNextScene();
    }*/

    public void LoadNextScene()
    {
        SceneManager.LoadScene("GAMEOVER");
        Cursor.visible = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barril")
        {
            health--;
            if (health <= 0)
            {
                //StartCoroutine(waiter());
                LoadNextScene();
            }       
           

        }

    }
}

    
