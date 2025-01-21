using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Purchasing;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform startPoint;
    public Transform[] a_Path;

    private void Awake()
    {
        if(instance != null )
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
