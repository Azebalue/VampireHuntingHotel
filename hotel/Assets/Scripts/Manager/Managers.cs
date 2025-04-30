using UnityEngine;

public class Managers : MonoBehaviour
{
    //ΩÃ±€≈Ê 
    public static Managers _instance;
    public static Managers Instance { get { return _instance; } }

    //∏Æº“Ω∫ ¿ŒΩ∫≈œΩ∫
    private static ResourceManager ResourceManager = new ResourceManager();

    public static ResourceManager Resource { get { return ResourceManager; } }




    void Start()
    {

    }

    void Update()
    {

    }
}
