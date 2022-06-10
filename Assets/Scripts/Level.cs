using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    public static Level instance;
    public List<Transform> endCubes;
    public Transform player;
    
    void Start()
    {
        instance = this;

        LevelManager.instance.cmVirtual.Follow = player;
        LevelManager.instance.cmVirtual.LookAt = player;
        
    }


    void Update()
    {
        
    }
}
