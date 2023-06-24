using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC_Dialogue : MonoBehaviour
{
    Mouse mouse;
    public Fishing fishingScript;
    [SerializeField] GameObject uiDialogue;
    [SerializeField] GameObject objective;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject triggerText;
    [SerializeField] GameObject fishingRod;
    [SerializeField] GameObject dialogueButton;
    [SerializeField] GameObject finishButton;
    public TextMeshProUGUI objectiveText;


    public float dialogueCounter;

    private void Start()
    {
        // telling script to find GameObject player, and within player find script component Mouse.
        mouse = GameObject.Find("Player").GetComponentInChildren<Mouse>();

       
    }

    private void Update()
    {
        // every frame unity is checking to see if we have clicked button which is where we change this float value, to display desired text.
        if (dialogueCounter == 0)
        {
            text.text = "Hello Traveller...";
        }
        if (dialogueCounter == 1)
        {
            text.text = "Glad to see you as I am in need of some help...";
        }
        if (dialogueCounter == 2)
        {
            text.text = "I need some fish to feed my family, however I have a terrible fear of water...";
        }
        if (dialogueCounter == 3)
        {
            text.text = "If you can catch me one of each fish, I will reward you!";
        }
        if (dialogueCounter == 4)
        {
            text.text = "Will you help me?";
        }
        if (dialogueCounter == 5)
        {
            //disabling the next dialogue button, and enabling the finish button.
            text.text = "Great!, My fishing rod is over by the pier... goodluck!";
            dialogueButton.SetActive(false);
            finishButton.SetActive(true);
        }

        if (fishingScript.fishCounter == 5)
        {
            objectiveText.text = "Congragulations! go back and speak to the towns person";
        }

    }
    
    // onTriggerEnter check the first frame of entering.
    private void OnTriggerEnter(Collider other)
    {
        triggerText.SetActive(true);
    }
    

    // OnTriggerStay checks every frame while colliding.
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                triggerText.SetActive(false);
                uiDialogue.SetActive(true);
                mouse.canMoveMouse = false; // Setting the boolean (mouse script) to false

            }
        }
    }
    //OntriggerExit checks the last frame of exiting.
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            triggerText.SetActive(false);
            uiDialogue.SetActive(false);
            mouse.canMoveMouse = true;
   
        }
    }

    public void NextDialogue()
    {
        dialogueCounter++; // adding +1 to the dialogueCounter float.
    }

    public void PreviousDialogue()
    {
        dialogueCounter--; // subtracting 1 to the dialogueCounter float.
    }
    public void ActivateObjective()
    {
        objective.SetActive(true);
        triggerText.SetActive(false);
        uiDialogue.SetActive(false);

        fishingRod.SetActive(true);
    }
}
