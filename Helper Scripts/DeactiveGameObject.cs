using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactiveGameObject : MonoBehaviour
{
    // Start is called before the first frame update

    public float timer = 2f;
    void Start()
    {
        Invoke("DeactiveAfterTime", timer);
    }
    
    void Update()
    {
        
    }

    void DeactiveAfterTime()
    {
        gameObject.SetActive(false);
    }
}
