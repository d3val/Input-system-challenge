using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Permissions;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    public Timer timer;
    public List<GameObject> checkpoints;
    public Transform lastCheckpointPosition;

    public TextMeshProUGUI checkpointText;
    public int checkpointCount;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            UpdateTextCount();
        }
        else { Destroy(gameObject); }
    }

    public void CountCheckpoint()
    {
        checkpointCount++;
        UpdateTextCount();
        if (checkpointCount >= checkpoints.Count)
            timer.enabled = false;
    }

    void UpdateTextCount()
    {
        checkpointText.text = string.Format("{0:00}/{1:00}", checkpointCount, checkpoints.Count);
    }

    public void ResetLevel()
    {
        timer.enabled = false;
        foreach (GameObject checkpoint in checkpoints)
        {
            checkpoint.SetActive(true);
        }
        checkpointCount = 0;
        UpdateTextCount();
        timer.enabled = true;
        lastCheckpointPosition= null;
    }
}
