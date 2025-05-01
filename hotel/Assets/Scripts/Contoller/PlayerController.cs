using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb; //이동
    BoxCollider2D bc; //충돌(이동불가지역)
    LayerMask layerMask; //충돌 레이어 파악용



    bool isAttacking = false; //공격 중인지

    #region 키보드 입력&이동 관련 변수
    Vector3 moveVec = Vector3.zero;
    Vector3 W = new Vector3 (1, 0.5f, 0);
    Vector3 D = new Vector3 (1, -0.5f, 0);

    KeyCode speedUpKey = KeyCode.LeftShift;
    KeyCode speedDownKey = KeyCode.LeftControl;
    KeyCode attackKey = KeyCode.Space;

    float speed;
    public float defaultSpeed = 1f; //웅크리며 걷는 속도
    public float walkingSpeed = 1.5f; //걷는 속도 (기본)
    public float runSpeed = 2.0f; //뛰는 속도
    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();

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

        //D
        if (Input.GetKey(KeyCode.D))
        {
            moveVec = D;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            moveVec = Vector2.zero;
        }

        //A
        if (Input.GetKey(KeyCode.A))
        {
            moveVec = -D;

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            moveVec = Vector2.zero;

        }

        //W
        if (Input.GetKey(KeyCode.W))
        {
            moveVec = W;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            moveVec = Vector2.zero;
        }

        //S
        if (Input.GetKey(KeyCode.S))
        {
            moveVec = -W ;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            moveVec = Vector2.zero;

        }

        // 한 축에 대해 중복 입력하는 경우 무효화
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)
            || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)))
            moveVec = Vector2.zero;

        rb.velocity = moveVec * speed;
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
