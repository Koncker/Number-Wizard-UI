using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberWizard : MonoBehaviour {

    private int min;
    private int max;
    private int guess;
    public int maxGuessesAllowed = 7;

    public Text text;


    void StartGame()
    {
        min = 1;
        max = 1000;
        NextGuess();

        max = max + 1;
    }

    void Start ()
    {
        StartGame();
	}

    public void guessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void guessLower()
    {
        max = guess;
        NextGuess();
    }

    public void guessCorrect()
    {
        Debug.Log("Player loses!");
        SceneManager.LoadScene("Lose");
    }

    void NextGuess()
    {
        guess = Random.Range(min, max +1); /* The 1 is added because in Random.Range min is inclusive but the max is exclusive */
        text.text = guess.ToString();
        maxGuessesAllowed = maxGuessesAllowed -  1;
        if (maxGuessesAllowed < 0)
        {
            Debug.Log("Player wins!");
            SceneManager.LoadScene("Win");
        }
    }
}