using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QueueUnit : MonoBehaviour
{
    public Text unitCountText;
    
    private int unitCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Queue()
    {
        unitCount = Int32.Parse(unitCountText.text);
        unitCount++;
        unitCountText.text = unitCount.ToString();
    }
}
