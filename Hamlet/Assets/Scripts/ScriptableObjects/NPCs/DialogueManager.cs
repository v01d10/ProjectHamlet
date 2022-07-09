using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public NPC npc;

    bool isTalking = false;
    float distance;
    private float curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI playerResponse;

    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void Update()
    {
        if(isTalking == true && distance >= 4.5f)
        {
            EndConversation();
        }

        if(isTalking == true)
        {
            Debug.Log("isTalking");
        } 
        else
        {
            Debug.Log("Is not talking");
        }
    }

    void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if(distance <= 4.5f)
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                curResponseTracker++;
                if(curResponseTracker >= npc.playerDialogue.Length-1)
                {
                    curResponseTracker = npc.playerDialogue.Length-1;
                }
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow))
            {
                curResponseTracker--;
                if(curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }
            }

            if(Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if(Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndConversation();
            }

            if(curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    npcDialogueBox.text = npc.dialogue[1];
                }
                else if(curResponseTracker == 1 && npc.playerDialogue.Length >= 0)
                {
                    playerResponse.text = npc.playerDialogue[1];
                    if(Input.GetKeyDown(KeyCode.Return))
                    {
                        npcDialogueBox.text = npc.dialogue[2];
                    }
                }
            }
        }
    }

    void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndConversation()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }
}
