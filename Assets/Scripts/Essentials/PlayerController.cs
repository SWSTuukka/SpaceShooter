using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Game Mode")]
    public bool dualanalog = false;
    public bool mouseaim = false;

    private GameManager gm;

    [Header("Player Stats")]
    public int maxHealth = 100;
    private int currentHealth;



    [Header("Player Movement")]
    [Range(0.1f, 30f)]
    public float playerSpeed = 10f;
    public float hor;
    public float ver;
   

    [Header("Shooting")]
    public GameObject gun;
    public GameObject bullet;
    public float fireRate = 0.5f;
    public bool canFire = true;

    public PlayerHealthUI healthUI;
    public GameObject explosion;
    public GameObject gameOver;
    public AudioSource damage;


    // Start is called before the first frame update
    void Start()
    {

        //gameOver.SetActive(false);
        gm = GameObject.Find("GM").GetComponent<GameManager>();
        healthUI = GameObject.Find("playerhealthtext").GetComponent<PlayerHealthUI>();

        if(gm.dualanalog)
        {
            dualanalog = true;
            mouseaim = false;
        }

        else if(gm.mouseaim)
        {
            dualanalog = false;
            mouseaim = true;
        }

        if(dualanalog)
        {
            gun.GetComponent<DualAnalogAim>().enabled = true;
            gun.GetComponent<GunScript>().enabled = false;
        }
        else if(mouseaim)
        {
            gun.GetComponent<DualAnalogAim>().enabled = false;
            gun.GetComponent<GunScript>().enabled = true;
        }

        currentHealth = maxHealth;
    }

    public int CurrentHealth
    {
        get { return currentHealth; }
    }

    // Update is called once per frame
    void Update()
    {
        // This is for calling controller Axis
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        // This is for moving the player
        transform.Translate(new Vector3(hor * playerSpeed * Time.deltaTime, 0, ver * playerSpeed * Time.deltaTime));

        // This is for shooting
        if (!dualanalog && Input.GetButton("Fire1") && canFire)
        {
            StartCoroutine("Shoot");
        }

    }

    public IEnumerator Shoot()
    {
        //print("Shoot");
        Instantiate(bullet, gun.transform.position, gun.transform.rotation);
        canFire = false;
        yield return new WaitForSeconds(fireRate);
        canFire = true;

    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        healthUI.OnPlayerTakeDamage();
        damage.Play();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {

        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        gameOver.SetActive(true);
    }

        
}



