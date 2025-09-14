using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    public SpriteRenderer toFlicker;
    public TextMeshProUGUI toFlickerTxt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!isVisible)
        {
            return;
        }*/
        if (toFlicker)
        {
            toFlicker.enabled = !toFlicker.enabled;
            return;
        }
        toFlickerTxt.enabled = !toFlickerTxt.enabled;
    }
}
