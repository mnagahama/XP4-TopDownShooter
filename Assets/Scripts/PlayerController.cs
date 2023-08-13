using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed = 15f;
    Rigidbody rb;
    Vector3 moveInput;
    Animator animator;
    public GunControl gun;
    public GameObject bullet, gameOver;
    public float shootSpeed = 25;

   public Text healthText;
    public static int health = 3;

    public Text ammoText;
    public static int currentAmmo;
    public static int maxAmmo;
   
    public AudioSource audioSource;
    public AudioClip audioClip;

    public RestartGame restartGame;
    public SeedSpawner seedSpawner;
    public MainMenu returnMenu;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        gameOver.SetActive(false);
        audioSource.playOnAwake = false;
        currentAmmo = 5;
        maxAmmo = 5;

        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        healthText.text = "Life: " + health;
        ammoText.text = "Seed: " + currentAmmo + "/" + maxAmmo;

        moveInput = new Vector3(x, 0, z);

        if (moveInput != Vector3.zero)
        {
            animator.SetBool("isWalking", true);

        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
        {
            Shoot(bullet, shootSpeed);
            audioSource.clip = audioClip;
            audioSource.Play();
            currentAmmo--;
            //UpdateAmmoCount();

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            restartGame.Restart();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            returnMenu.Return();
        }

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Barril")
        {
            health--;
            if (health <= 0)
            {
                gameOver.SetActive(true);
                Time.timeScale = 0;
            }

        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Semente")
        {
            ReloadAmmo();
            Destroy(other.gameObject);
            seedSpawner.SeedDestroyed();
        }
    }

    public void ReloadAmmo()
    {
        currentAmmo = maxAmmo;

    }
    /*
    public void UpdateAmmoCount()
    {
        ammoText.text = "Seed: " + currentAmmo + "/" + maxAmmo;
    }*/
    /*
    public void AddAmmo()
    {
        currentAmmo+= 1;
        if (currentAmmo > maxAmmo)
        {
            currentAmmo = maxAmmo;
        }
        UpdateAmmoCount() ;
    }*/

    
}