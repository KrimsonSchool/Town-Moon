using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TextMeshProUGUI dialogueText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PlayDialogue(string dialogue)
    {
        print("Playing: " +dialogue);
        //dialogueBox.setActive(true);
        if (!dialogueBox.activeSelf)
        {
            dialogueBox.SetActive(true);
            yield return new WaitForSeconds(1);
        }

        dialogueText.text = dialogue;
    }

    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        dialogueText.text = null;
    }
}
