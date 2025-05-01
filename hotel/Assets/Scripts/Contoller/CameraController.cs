using UnityEngine;

public class CameraController: MonoBehaviour
{
    GameObject player;
    //float cameraPosX;

    enum GameObjects
    {
        player,
    }


    void Start()
    {
        player = GameObject.Find("Player");

        //����ó��
        if (player == null)
        {
            Debug.Log("Player�� ����!");
        }
    }

    void Update()
    {
        //cameraPosX = player.transform.position.x;
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
    }
}
