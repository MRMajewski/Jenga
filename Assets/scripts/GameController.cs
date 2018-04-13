using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text TextComponent;

    public bool IsPlaying = true;

    public string NextLevelName;

    int NumberOfSpecialBlocksAtBeginning;

	// Use this for initialization
	void Start () {

       FixLighting();

        TextComponent.enabled = false;
        NumberOfSpecialBlocksAtBeginning = CountBlocks(special: true);
    }
	
  public void OnValidate() // funkcja wykonuje się gdy zmienia się obiekt
 {
     FixLighting();
}

 void FixLighting()
  {
       RenderSettings.ambientLight = Color.white; // ustawienia oświetlenia
        RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
   }


	// Update is called once per frame
	void Update () {
		
	}

    public int CountBlocks(bool special)
    {
        return FindObjectsOfType<Block>()
            .Count(block => block.Enabled && block.IsSpecial == special);


        //inaczej
        //return FindObjectsOfType<Block>()
        //    .Where(block => block.IsSpecial == special)
        //    .Count();
    }

    public void OnTriggerExit(Collider other)
    {
        var block = other.GetComponent<Block>();

        if (block != null)

            block.Enabled = false;


        if (block.IsSpecial)
            StartCoroutine(EndGameCoroutine(won: false));


        else if (CountBlocks(special: false)==0)
            StartCoroutine(EndGameCoroutine(won: true));

        Destroy(block.gameObject);
    }

    IEnumerator EndGameCoroutine(bool won)
    {
        if (IsPlaying == false) yield break; //odliczanie nie rozpocznie się na nowo gdy ruszymy klocek

        TextComponent.enabled = true;
        IsPlaying = false;

        if (won)
        {
            for(int i=5;i>0;i--)
            {
                TextComponent.text = i.ToString();
                yield return new WaitForSeconds(1f);
            }

            if (NumberOfSpecialBlocksAtBeginning != CountBlocks(special: true))
                won = false;
        }

        TextComponent.text = won ? "Wygrałeś!" : "Przegrałeś...";

        yield return new WaitForSeconds(3f);

        if(string.IsNullOrEmpty(NextLevelName))
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(NextLevelName);
        }

    }
}
