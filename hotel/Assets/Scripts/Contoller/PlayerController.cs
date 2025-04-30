using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;

    float speed;
    public float defaultSpeed = 1.5f; //웅크리며 걷는 속도
    public float walkingSpeed = 2.0f; //걷는 속도 (기본)
    public float runSpeed = 3.0f; //뛰는 속도

    bool isAttacking = false; //공격 중인지

    KeyCode forward = KeyCode.D;
    KeyCode backward = KeyCode.A;
    KeyCode speedUpKey = KeyCode.LeftShift;
    KeyCode speedDownKey = KeyCode.LeftControl;
    KeyCode attackKey = KeyCode.Space;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = walkingSpeed;

    }

    void Update()
    {
        attack();
        if (isAttacking == false)
            move();
    }

    void move()
    {
        //속도 조정
        speedControll();

        //앞으로
        if (Input.GetKey(forward))
        {
            rb.velocity = transform.right * speed;
        }
        else if (Input.GetKeyUp(forward))
        {
            rb.velocity = Vector2.zero;
        }

        //뒤로
        if (Input.GetKey(backward))
        {
            rb.velocity = -transform.right * speed;
        }
        else if (Input.GetKeyUp(backward))
        {
            rb.velocity = Vector2.zero;
        }

        //앞뒤 중복키 입력하는 경우 무효화
        if (Input.GetKey(forward) && Input.GetKey(backward))
            rb.velocity = Vector2.zero;
    }

    void speedControll()
    {
        if (Input.GetKey(speedUpKey))
            speed = runSpeed;
        else if(Input.GetKey(speedDownKey))
            speed = defaultSpeed;
        else 
            speed = walkingSpeed;
        
    }

    void attack()
    {
        if (Input.GetKeyDown(attackKey))
        {
            //rb.velocity = Vector2.zero; //멈추기
            Debug.Log("공격!");
            isAttacking = true;
            StartCoroutine(StopMovementForSeconds(2.0f));
        }
        else if (Input.GetKeyUp(attackKey))
        {
            Debug.Log("공격 후!");
        }

    }

    IEnumerator StopMovementForSeconds(float seconds)
    {
        Debug.Log("기다려!");
        yield return new WaitForSeconds(seconds);
        isAttacking = false;
    }
}
