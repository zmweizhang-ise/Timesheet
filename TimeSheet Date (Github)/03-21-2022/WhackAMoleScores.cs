using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhackAMoleScores : MonoBehaviour
{


    private int scores = 0;
    [SerializeField] private TextMesh scoreTx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreTx.text = scores + "";

    }

    public void addScore()
    {
        scores += 100;
    }
}
