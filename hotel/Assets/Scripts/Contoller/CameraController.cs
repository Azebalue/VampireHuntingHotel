using UnityEngine;

public class CameraController: MonoBehaviour
{
    GameObject player;
    float cameraPosX;

    enum GameObjects
    {
        player,
    }


    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        cameraPosX = player.transform.position.x;
        transform.position = new Vector3 (cameraPosX, 0, -10);
    }
}
