using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class nameEntryHandler : MonoBehaviour
{
    Dictionary<char, char> arabicToEnglish = new Dictionary<char, char>();
    [SerializeField] TextMeshProUGUI hieroglyphsTXT;
    [SerializeField] TMP_InputField arabicInputField;
    string englishString; 
    string arabicString=string.Empty; 

    void Start()
    {
        arabicToEnglish.Add('ا', 'a');
        arabicToEnglish.Add('ب', 'b');
        arabicToEnglish.Add('ت', 't');
       // arabicToEnglish.Add('ث', 'a');
        arabicToEnglish.Add('ج', 'g');
       // arabicToEnglish.Add('ح', 'a');
       //arabicToEnglish.Add('خ', 'a');
        arabicToEnglish.Add('د', 'd');
       //arabicToEnglish.Add('ذ', 'a');
        arabicToEnglish.Add('ر', 'r');
        arabicToEnglish.Add('ز', 'f');
        arabicToEnglish.Add('س', 's');
       //arabicToEnglish.Add('ش', 'a');
       //arabicToEnglish.Add('ص', 'a');
       //arabicToEnglish.Add('ض', 'a');
        arabicToEnglish.Add('ط', 't');
       //arabicToEnglish.Add('ظ', 'a');
        arabicToEnglish.Add('ع', 'e');
        arabicToEnglish.Add('غ', 'a');
        arabicToEnglish.Add('ف', 'a');
        arabicToEnglish.Add('ق', 'a');
        arabicToEnglish.Add('ك', 'a');
        arabicToEnglish.Add('ل', 'l');
        arabicToEnglish.Add('م', 'm');
        arabicToEnglish.Add('ن', 'n');
        arabicToEnglish.Add('ه', 'a');
        arabicToEnglish.Add('و', 'u');
        arabicToEnglish.Add('ي', 'i');
        arabicToEnglish.Add('ى', 'y');

        
    }

    // Update is called once per frame
    void Update()
    {
       arabicString= arabicInputField.text;
        for(int i=0;i<arabicString.Length;i++)
        {
            englishString += arabicToEnglish[arabicString[i]];
        }
        hieroglyphsTXT.text= englishString;
        englishString=string.Empty;
    }
}
