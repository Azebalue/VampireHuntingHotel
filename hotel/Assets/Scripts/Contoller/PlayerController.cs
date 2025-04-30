using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;

    float speed;
    public float defaultSpeed = 1.5f; //��ũ���� �ȴ� �ӵ�
    public float walkingSpeed = 2.0f; //�ȴ� �ӵ� (�⺻)
    public float runSpeed = 3.0f; //�ٴ� �ӵ�

    bool isAttacking = false; //���� ������

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
        //�ӵ� ����
        speedControll();

        //������
        if (Input.GetKey(forward))
        {
            rb.velocity = transform.right * speed;
        }
        else if (Input.GetKeyUp(forward))
        {
            rb.velocity = Vector2.zero;
        }

        //�ڷ�
        if (Input.GetKey(backward))
        {
            rb.velocity = -transform.right * speed;
        }
        else if (Input.GetKeyUp(backward))
        {
            rb.velocity = Vector2.zero;
        }

        //�յ� �ߺ�Ű �Է��ϴ� ��� ��ȿȭ
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
