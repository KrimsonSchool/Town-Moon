using TMPro;
using UnityEngine;

public class Fps : MonoBehaviour
{
    public float fps;
    private float fpsA;
    
    private float timer;
    
    public TextMeshProUGUI fpsText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        fpsA++;
        if (timer > 1)
        {
            timer = 0;
            fps = fpsA;
            fpsA = 0;
            
            //print("FPS: " + fps);
            fpsText.text = "FPS: " + fps;
        }
    }
}
