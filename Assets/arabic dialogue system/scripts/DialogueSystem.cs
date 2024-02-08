
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

enum Speaker
{
    youngPharaoh,deer,rock, mina
}

[System.Serializable]
struct Character
{
    public string name;
    public Sprite characterImage; 
}

[System.Serializable]
struct dialogueEntery
{
    public string text;
    public Speaker speaker;
}

public class DialogueSystem : MonoBehaviour
{
    [Header("dialogue")]
    [SerializeField] private Character[] characters;
    [SerializeField] private dialogueEntery[] entries;
    [SerializeField] private float timeBetweenCharacters;
    [SerializeField] private float timeBetweenEntries;
    [Header("dialogue canvas")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] Image speakerImage;
    [SerializeField] TextMeshProUGUI speakerName;
    [SerializeField] TextMeshProUGUI dialogueText;
    string dummySTR;
    public static bool inDialogue=false;
    private void OnEnable()
    {
       showDialogue();
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

    int index = 0;
    IEnumerator TextDisplay()
    {
       
        dialogueText.text = string.Empty;
        dummySTR = string.Empty;
        if (index < entries.Length)
        {
            int speakerIndex = (int)entries[index].speaker;
              speakerName.text = characters[speakerIndex].name;
            if (characters[speakerIndex].characterImage != null)
            {
                speakerImage.sprite = characters[speakerIndex].characterImage;
            }
            else
            {
                Debug.Log("no sprite");
            }
            for (int textIDX = 0; textIDX < entries[index].text.Length; textIDX++)
            {
               dummySTR += entries[index].text[textIDX];
                dialogueText.text = dummySTR;

                yield return new WaitForSeconds(timeBetweenCharacters);
            }

            index++;
            Invoke("showDialogue", timeBetweenEntries);
        }
        else
        {
            StopAllCoroutines();
            inDialogue =  false;
            gameObject.SetActive(false);
        }
       
    }

    //public void hideDialogue()
    //{
    //    dialoguePanel.SetActive(false);        
    //}
    public void showDialogue()
    {
       inDialogue=true;
        dialoguePanel.SetActive(true);
        StartCoroutine(TextDisplay());
        
        
    }

}
