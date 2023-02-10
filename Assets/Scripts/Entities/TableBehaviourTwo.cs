using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableBehaviourTwo : MonoBehaviour
{
    //Slider Behaviour
    public int FullServed = 100;
    public int CurrentServed;
    //public UnityEngine.UIElements.ProgressBar progressBar;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite emptyTable, halfTable, completeTable;

    private bool isServed;
    private bool serving;
    public int addedScore;
    public int timesServed;

    //UI Setup
    [SerializeField]
    TextMeshProUGUI _insertScoreText;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isServed = false;
    }

    void UpdateProgress(int progress)
    {
        CurrentServed += progress;
    }

    public void Interact()
    {
        if (timesServed > 2 && timesServed < 3)
            spriteRenderer.sprite = halfTable;
        else if (timesServed > 4)
        {
            spriteRenderer.sprite = completeTable;
            AddToScore();
            isServed = true;
        }
    }

    public void AddToScore()
    {
        if (!isServed)
        { 
            addedScore += 750;
            _insertScoreText.GetComponent<TextMeshProUGUI>().text = addedScore + "";
        }
    }
}
