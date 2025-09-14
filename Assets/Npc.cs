using UnityEngine;

public class Npc : MonoBehaviour
{
    public GameObject eKeyIcon;
    GameObject player;
    private float playerDist;

    public float interactDist;
    
    public Dialogue[] dialogue;

    private bool closeEnough;
    
    DialogueManager dialogueManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player=FindFirstObjectByType<Player>().gameObject;
        dialogueManager =  FindFirstObjectByType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDist = Vector2.Distance(player.transform.position, transform.position);

        closeEnough = playerDist <= interactDist;
        
        if (closeEnough)
        {
            eKeyIcon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                print("Dialogued");
                Dialogue nextDiag=null;
                foreach (Dialogue dg in dialogue)
                {
                    if (dg.available)
                    {
                        nextDiag = dg;
                        break;
                    }
                    
                    if (dg.loop)
                    {
                        dg.available = true;
                    }
                }
                

                if (nextDiag != null)
                {
                    StartCoroutine(dialogueManager.PlayDialogue(nextDiag.text));
                    nextDiag.available = false;
                }
                else
                {
                    dialogueManager.EndDialogue();
                }
                
            }
        }
        else
        {
            eKeyIcon.SetActive(false);
        }
    }
}
