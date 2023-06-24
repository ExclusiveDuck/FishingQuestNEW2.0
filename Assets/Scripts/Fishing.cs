using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Fishing : MonoBehaviour
{
    private Animator anim;
    public int minCatch;
    public int maxCatch;

    public float timeToCatchFish;
    public float timer;
    public bool hasCastLine;
    public List<GameObject> fishList = new List<GameObject>(); // creating a list of gameobjects, calling that list fishlist.
    public Transform fishSpawn;
    public GameObject player;
    public GameObject tick;
    public TextMeshProUGUI counterText;
    public float fishCounter;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        counterText.text = fishCounter + "/5"; // accessing text of Textmeshpro, text being the float value.
        if (fishCounter > 5)
        {
            fishCounter = 5;
        }

        if (timer > 0) // checking if timer float is greater than 0, if it is, start counting down to 0.
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && timer > 0 && hasCastLine) // checking if correct button has been pressed, andn is greater than 0 and if bool hascastline is true, call method ReelInFish
        {
            ReelInFish();
        }

         else if (timer <= 0 && hasCastLine)
         {
             ReturnToNormal();
         }      

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            anim.SetBool("CastLine", true); //Accessing animator component, setting bool parameter "castline" to true
            Invoke("CaughtFish", Random.Range(minCatch,maxCatch)); // invoking CaughtFish method with a range between number value set in inspector.
        }
    }
   private void CaughtFish()
   {
        anim.SetBool("CaughtFish", true); 
        timer = timeToCatchFish; // Setting timer value to 3 seconds which is timeToCatchFish.
        hasCastLine = true;
   }


    private void ReelInFish()
    {
        int randomFish = Random.Range(0, fishList.Count); // the number randomfish = a random range between 0 and 5
        anim.SetBool("CaughtFish", false);
        anim.SetBool("CastLine", false);
        Instantiate(fishList[randomFish], fishSpawn.position, player.transform.rotation, player.transform); // get random fish from list, instantiate that random fish at spawnfishpoint position
        fishList.RemoveAt(randomFish);
        hasCastLine = false;
        Debug.Log("Caught");

        fishCounter++;
    }


    private void ReturnToNormal()
    {
        anim.SetBool("CastLine", false);
        anim.SetBool("CaughtFish", false);
        hasCastLine = false;
        Debug.Log("Miss");
    }

}
