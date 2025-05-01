using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    float speed;
    public float defaultSpeed = 1f; //��ũ���� �ȴ� �ӵ�
    public float walkingSpeed = 1.5f; //�ȴ� �ӵ� (�⺻)
    public float runSpeed = 2.0f; //�ٴ� �ӵ�

    bool isAttacking = false; //���� ������

    #region �̵� ���� ����
    Vector3 D = new Vector3 (1, 1, 0);
    Vector3 W = new Vector3 (-1, 1, 0);

    KeyCode speedUpKey = KeyCode.LeftShift;
    KeyCode speedDownKey = KeyCode.LeftControl;
    KeyCode attackKey = KeyCode.Space;
    #endregion

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
        //�ӵ� ����
        speedControll();

        //D
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = D * speed;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = Vector2.zero;
        }

        //A
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -D * speed;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = Vector2.zero;
        }

        //AD �ߺ� �Է��ϴ� ��� ��ȿȭ
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
            rb.velocity = Vector2.zero;


        //W
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = W * speed;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            rb.velocity = Vector2.zero;
        }

        //S
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = -W * speed;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            rb.velocity = Vector2.zero;
        }

        //WS �ߺ� �Է��ϴ� ��� ��ȿȭ
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
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
            //rb.velocity = Vector2.zero; //���߱�
            Debug.Log("����!");
            isAttacking = true;
            StartCoroutine(StopMovementForSeconds(2.0f));
        }
        else if (Input.GetKeyUp(attackKey))
        {
            Debug.Log("���� ��!");
        }

    }

    IEnumerator StopMovementForSeconds(float seconds)
    {
        Debug.Log("��ٷ�!");
        yield return new WaitForSeconds(seconds);
        isAttacking = false;
    }
}
