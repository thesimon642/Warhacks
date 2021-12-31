using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForcefieldController : MonoBehaviour
{
    //on can take 3 hits and then is destroyed
    public static int currentHP;
    [SerializeField]
    private SpriteRenderer shieldSprite;
    public static bool lose;
    private bool loseSequence;

    private void Start()
    {
        currentHP = 3;
        lose = false;
        loseSequence = false;
    }
    private void Update()
    {
        float alpha = currentHP;
        alpha /= 3;
        shieldSprite.color = new Color(shieldSprite.color.r, shieldSprite.color.g, shieldSprite.color.b, alpha);
        if (currentHP < 0 && !loseSequence)
        {
            loseSequence = true;
            //StartCoroutine(WaitThenLose());
            SceneManager.LoadScene("Lose Screen");
        }
    }

    //IEnumerator WaitThenLose()
    //{
    //    //Time.timeScale = 0;
    //    //yield return new WaitForSeconds(1);
    //    SceneManager.LoadScene("Lose Screen");
    //}
}
