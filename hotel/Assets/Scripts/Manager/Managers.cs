using UnityEngine;

public class Managers : MonoBehaviour
{
    //�̱��� 
    public static Managers _instance;
    public static Managers Instance { get { return _instance; } }

    //���ҽ� �ν��Ͻ�
    private static ResourceManager ResourceManager = new ResourceManager();

    public static ResourceManager Resource { get { return ResourceManager; } }




    void Start()
    {

    }

    void Update()
    {

    }
}
