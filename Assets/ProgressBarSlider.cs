using UnityEngine;
using UnityEngine.UI;

public class ProgressBarSlider : MonoBehaviour
{
    public Slider slider;

    public void SetMaxProgress(int progress)
    {
        slider.maxValue = progress;
        slider.value = progress;
    }

    public void SetProgress(int h)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
