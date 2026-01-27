using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class move : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    public static move instance;
    float currentSpeed;

    [SerializeField] Rigidbody rb;
    Vector3 direction;

    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float stamina = 5f;
    [SerializeField] TMP_Text HpText;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject rifleStart;

    bool isGrounded = true;

    [SerializeField] Animator anim;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        currentSpeed = movementSpeed;
        ChangeHealth(100);
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        if (direction.x != 0 || direction.z != 0)
        {
            anim.SetBool("Run", true);
        }
        if (direction.x == 0 && direction.z == 0)
        {
            anim.SetBool("Run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
            anim.SetBool("Jump", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= Time.deltaTime;
                currentSpeed = shiftSpeed;
                anim.SetBool("Sprint", true);
            }
            else
            {
                currentSpeed = movementSpeed;
                anim.SetBool("Sprint", false);
            }
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime;
            currentSpeed = movementSpeed;
        }
        if (stamina > 5)
        {
            stamina = 5;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }

        print(stamina);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject buffer = Instantiate(bullet);
            buffer.GetComponent<Bullet>().SetDirection(transform.forward);
            buffer.transform.position = rifleStart.transform.position;
            buffer.transform.rotation = transform.rotation;
        }
    }


    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        anim.SetBool("Jump", false);
    }
    private int health;
    public void ChangeHealth(int count)
    {
        health = health + count;
        HpText.text = health.ToString();
    }
}