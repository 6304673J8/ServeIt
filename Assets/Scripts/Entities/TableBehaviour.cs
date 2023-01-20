using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBehaviour : MonoBehaviour
{
    //Slider Behaviour
    public int FullServed = 100;
    public int CurrentServed;
    public UnityEngine.UIElements.ProgressBar progressBar;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite emptyTable, halfTable, completeTable;

    private bool isServed;
    private bool serving;

    // Start is called before the first frame update
    void Start()
    {
        isServed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (serving)
        {
            UpdateProgress(25);
        }
    }

    void UpdateProgress(int progress)
    {
        CurrentServed += progress;
    }

    public void Interact()
    {
        if (isServed)
        {
            //AddToScore(750);
        }
        else
        {
            spriteRenderer.sprite = halfTable;
        }
    }

    public void AddToScore(int score)
    { 
    
    }
}
