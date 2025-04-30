using UnityEngine;

public class CameraManager 
{
    GameObject player;
    GameObject camera;

    enum GameObjects
    {
        player,
        camera,
    }

    Vector3 cameraPos;

    public void Init()
    {
        camera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
    }

    public void Execute()
    {
        cameraPos = new Vector3(player.transform.position.x, 0, -10);
        camera.transform.position = cameraPos;
    }
}
