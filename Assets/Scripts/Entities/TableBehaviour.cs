using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TableBehaviour : MonoBehaviour
{
    //Slider Behaviour
    public int FullServed = 100;
    public int CurrentServed;
    //public UnityEngine.UIElements.ProgressBar progressBar;

    [SerializeField]
    TextMeshProUGUI _insertScoreText;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite emptyTable, halfTable, completeTable;

    private bool isServed;
    private bool serving;
    public int addedScore;

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
            if (FullServed < 100)
            {
                UpdateProgress(25);
            }
            else
                isServed = true;
        }
    }

    void UpdateProgress(int progress)
    {
        CurrentServed += progress;
    }

    public void Interact()
    {
        spriteRenderer.sprite = halfTable;
    }
}
