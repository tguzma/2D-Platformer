using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    public TextMeshProUGUI score;

    // Start is called before the first frame update
    void Start()
    {
        if (score != null)
        {
            score.text =
                $"Coins: {ScoreHandler.GetCollected()}";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score != null)
        {
            score.text =
                $"Coins: {ScoreHandler.GetCollected()}";
        }
    }
}
