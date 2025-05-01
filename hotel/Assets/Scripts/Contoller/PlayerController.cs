using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb; //�̵�
    BoxCollider2D bc; //�浹(�̵��Ұ�����)
    LayerMask layerMask; //�浹 ���̾� �ľǿ�



    bool isAttacking = false; //���� ������

    #region Ű���� �Է�&�̵� ���� ����
    Vector3 moveVec = Vector3.zero;
    Vector3 W = new Vector3 (1, 0.5f, 0);
    Vector3 D = new Vector3 (1, -0.5f, 0);

    KeyCode speedUpKey = KeyCode.LeftShift;
    KeyCode speedDownKey = KeyCode.LeftControl;
    KeyCode attackKey = KeyCode.Space;

    float speed;
    public float defaultSpeed = 1f; //��ũ���� �ȴ� �ӵ�
    public float walkingSpeed = 1.5f; //�ȴ� �ӵ� (�⺻)
    public float runSpeed = 2.0f; //�ٴ� �ӵ�
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
        //�ӵ� ����
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

        // �� �࿡ ���� �ߺ� �Է��ϴ� ��� ��ȿȭ
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
