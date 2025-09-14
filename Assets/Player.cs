using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public GameObject flash;
    private int fIndex;

    public GameObject transitionEffect;

    private Rigidbody2D rb;

    public float jumpHeight;

    private float camRight;
    private float camLeft;
    private float camDown;

    private bool grounded;
    
    SpriteRenderer spriteRen;

    private Camera mainCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 24;
        rb = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+=transform.right * (speed * Time.deltaTime * Input.GetAxis("Horizontal"));
        
        if(Input.GetAxis("Horizontal")!=0) spriteRen.flipX = !(Input.GetAxis("Horizontal")>0);
        
        if (fIndex > 0)
        {
            fIndex--;
        }
        else
        {
            flash.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Flash();
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            //transform.position += transform.up * 1.5f;
            rb.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse);
        }

        camRight = mainCam.transform.position.x +5;
        camLeft = mainCam.transform.position.x -5;
        camDown = mainCam.transform.position.y -5;
        
        if (transform.position.x > camRight)
        {
            MoveCam(0.4f, 10);
        }
        if (transform.position.x < camLeft)
        {
            MoveCam(-0.4f, -10);
        }
        
        if (transform.position.y < camDown)
        {
            //DIE
            Flash();
            transform.position = new Vector2(-7.5f, -2.5f);
            mainCam.transform.position=new Vector3(-5, 0.25f, -10);
        }
        
        grounded = rb.linearVelocity.y == 0;
    }
    
    //0.05, 0.07, 0.11

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        /*
        if (other.CompareTag("SideTriggerR"))
        {
            mainCam.transform.position+=mainCam.transform.right*10;
            transform.position += transform.right * 0.4f;
            Flash();
        }
        if (other.CompareTag("SideTriggerL"))
        {
            mainCam.transform.position+=mainCam.transform.right*-10;
            transform.position += -transform.right * 0.4f;
            Flash();
        }*/

        if (other.CompareTag("Warp"))
        {
            Warp wrp = other.GetComponent<Warp>();
            Warp(wrp);
        }
    }

    public void MoveCam(float amount, float cam)
    {
        mainCam.transform.position+=mainCam.transform.right*cam;
        transform.position += transform.right * amount;
        Flash();
    }

    public void Flash()
    {
        flash.SetActive(true);
        fIndex+=1;
    }
    

    public async Task Transition(float transitionTime)
    {
        transitionEffect.SetActive(true);
        await Task.Delay(TimeSpan.FromSeconds(transitionTime));
        transitionEffect.SetActive(false);
    }
    
    async void Warp(Warp wrp)
    {
        await Transition(1);
        transform.position = wrp.destination;
        mainCam.transform.position=wrp.destination;
        mainCam.transform.position -= transform.forward * 10;
    }
}
