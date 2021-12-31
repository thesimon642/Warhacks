using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
public class ConsoleController : MonoBehaviour
{
    
    [SerializeField]
    private TMP_InputField consoleInputSerial;
    private static TMP_InputField consoleInput;
    [SerializeField]
    private TextMeshPro consoleOutputSerial;
    private static TextMeshPro consoleOutput;
    private static readonly int maxLines = 8;
    private static string[] storedMessages;
    //value to be sent between workbooks
    public static string sentMessage;
    private static int currentLines;
    public static readonly string playerText = ColorName(Color.white);
    public static readonly string CommanderText = ColorName(Color.blue);
    public static readonly string HackerText = ColorName(Color.green);
    private static WaitForSeconds veryshortWait = new WaitForSeconds(0.01f);
    private static ConsoleController instance;
    private void Start()
    {
        storedMessages = new string[maxLines];
        for (int i = 0; i < maxLines; i++)
        { storedMessages[i] = ""; }
        currentLines = 0;
        consoleInput = consoleInputSerial;
        consoleOutput = consoleOutputSerial;
        instance = this;
        InputController.SemiResetWords();
        InputController.plusInCurrentWord = 0;
    }


    private void Update()
    {
        //when enter is pressed write the inputs to the console and remove them from the input field
        if (Input.GetKeyDown(KeyCode.Return) && consoleInput.text != "" && !PauseController.paused)
        {
            AddLine(consoleInput.text);
            InputController.FindKeyWords(consoleInput.text);
            sentMessage = consoleInput.text;
            consoleInput.text = "";
        }
    }


    public static void AddLetter(string newLetter, string colour)
    {
        //adds a letter to the current line
        storedMessages[currentLines] += "<color=#" + colour + ">" + newLetter;
    }
    public static void AddLine(string newLine, string colour)
    {
        //adds line to the console of the colour added
        string newText;
        //add a colour and new line
        newText = "\n";
        newText += "<color=#" + colour + ">" + newLine;
        if (currentLines < maxLines)
        {
            //if less than max lines just add a new line and store it
            consoleOutput.text += newText;
            storedMessages[currentLines] = newText;
            currentLines += 1;
        }
        else
        {
            //if at max lines, move all lines down one in storage (for memory rather than visuals as will already be off screen)
            consoleOutput.text = "";
            for (int i = 0; i < maxLines - 1; i++)
            {
                storedMessages[i] = storedMessages[i + 1];
                consoleOutput.text += storedMessages[i];
            }
            storedMessages[maxLines - 1] = newText;
            consoleOutput.text += storedMessages[maxLines - 1];
        }
        //foreach (string message in storedMessages)
        //{
        //.Log(message); }
    }
    public static IEnumerator AddLineOneLetterAtATime(string newLine, string colour)
    {
        AddLine("",colour);
        foreach (char letter in newLine)
        {
            storedMessages[currentLines] += letter;
            consoleOutput.text += letter;
            yield return veryshortWait;
        }
    }
    public static void TypeLetters(string newLine, string colour)
    { instance.StartCoroutine(AddLineOneLetterAtATime(newLine,colour)); }
    public static void AddLine(string newLine)
    {
        //default colour is player text
        AddLine(newLine,playerText);
    }

    public static string ColorName(Color colour)
    {//converts colour to hexidecimal string for TMP code
        return ColorUtility.ToHtmlStringRGB(colour);
    }
}
