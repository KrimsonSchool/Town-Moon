using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [Tooltip("Max length of 72 chars")]
    [TextArea(8,16)]
    public string text;

    public bool available;
    public bool loop;
    
    //148 char limit at 10pt
    //72 at 12pt
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
