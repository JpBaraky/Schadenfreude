using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCap : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
          Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
