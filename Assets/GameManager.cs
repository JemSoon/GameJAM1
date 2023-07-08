using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst { get; private set; }
    private void Awake() => Inst = this;

    public GameObject youDie;
    public GameObject clear;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.Inst.isDead)
        {
            youDie.SetActive(true);
            if (NotDestroy.Inst.Life > 0)
            {
                StartCoroutine(RestartGame()); 
            }
            else
            {
                StartCoroutine(GameOver());
            }
        }

        if (Player.Inst.isClear)
        {
            StartCoroutine(NextGame());
        }
    }

    public IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        --NotDestroy.Inst.Life;
        NotDestroy.Inst.UpdateLife();
        NotDestroy.Inst.Score = 0;
        NotDestroy.Inst.UpdateScore(0);
    }

    public IEnumerator NextGame()
    {
        yield return new WaitForSeconds(3);
        switch(SceneManager.GetActiveScene().name)
        {
            case "Play1":
                SceneManager.LoadScene("Play2");
                break;
            case "Play2":
                SceneManager.LoadScene("GameClear");
                break;
        }
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOver");
    }

}
