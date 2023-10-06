using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Permissions;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public Timer timer;
    List<GameObject> checkpoints;
    public Transform lastCheckpointPosition;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(gameObject); }
    }

    

    // Update is called once per frame
    void Update()
    {
       
    }
}
