using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;
public class InputController
{
    public static int plusInCurrentWord;
    public static bool pierceInCurrentWord;
    public static bool stunInCurrentWord;
    public static bool fireInCurrentWord;
    public static bool rapidInCurrentWord;

    //[MenuItem("testing/1")]
    //static void test1()
    //{
    //
    //    .Log(plusInCurrentWord);
    //    Debug.Log(pierceInCurrentWord);
    //    Debug.Log(stunInCurrentWord);
    //    Debug.Log(fireInCurrentWord);
    //    Debug.Log(rapidInCurrentWord);
    //}

    public static void ResetWords()
    {
        plusInCurrentWord   = 0;
        stunInCurrentWord   = false;
        fireInCurrentWord   = false;
        pierceInCurrentWord = rapidInCurrentWord;
    }
    //public static void TotalResetWords()
    //{
    //    plusInCurrentWord = 0;
    //    SemiResetWords();
    //}
    public static void SemiResetWords()
    {
        pierceInCurrentWord = false;
        stunInCurrentWord = false;
        fireInCurrentWord = false;
        rapidInCurrentWord = false;
    }
    public static void FindKeyWords(string userInput)
    {
        plusInCurrentWord += userInput.Split('+').Length - 1;
        if (OverridingSettings.newMode)
        {
            switch (userInput.ToLower())
            {
                case "pierce":
                    SemiResetWords();
                    pierceInCurrentWord = true;
                    break;
                case "stun":
                    SemiResetWords();
                    stunInCurrentWord = true;
                    break;
                case "fire":
                    SemiResetWords();
                    fireInCurrentWord = true;
                    break;
                case "rapid":
                    SemiResetWords();
                    rapidInCurrentWord = true;
                    break;
            }
        }
        else
        {
            pierceInCurrentWord = pierceInCurrentWord || userInput.ToLower().Contains("pierce");
            stunInCurrentWord = stunInCurrentWord || userInput.ToLower().Contains("stun");
            fireInCurrentWord = fireInCurrentWord || userInput.ToLower().Contains("fire");
            rapidInCurrentWord = rapidInCurrentWord || userInput.ToLower().Contains("rapid");
        }
        DisableUnavailble();
        //rapid fire require pierce to work
        pierceInCurrentWord = pierceInCurrentWord || rapidInCurrentWord;
    }
    public static void DisableUnavailble()
    {
        if (!PrefabHolder.plusAvailable)
        { plusInCurrentWord = 0; }
        if (!PrefabHolder.pierceAvailable)
        { pierceInCurrentWord = false; }
        if (!PrefabHolder.stunAvailable)
        { stunInCurrentWord = false; }
        if (!PrefabHolder.fireAvailable)
        { fireInCurrentWord = false; }
        if (!PrefabHolder.rapidAvailable)
        { rapidInCurrentWord = false; }
    }
}
