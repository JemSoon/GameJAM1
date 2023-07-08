using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MyButton : MonoBehaviour
{
    public Button restartButton;
    public Button titleButton;
    // Start is called before the first frame update
    void Start()
    {
        //if (NotDestroy.Inst != null)
        //{ NotDestroy.Inst.bgm.Stop(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RestartButton()
    {
        SceneManager.LoadScene("Play1");
        //NotDestroy.Inst.bgm.Play();
        NotDestroy.Inst.Life = 3;
        NotDestroy.Inst.Score = 0;
        NotDestroy.Inst.UpdateLife();
        NotDestroy.Inst.UpdateScore(0);
    }

    public void TitleButton()
    {
        SceneManager.LoadScene("Title");
        NotDestroy.Inst.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Play1");
        if (NotDestroy.Inst != null)
        { NotDestroy.Inst.gameObject.SetActive(true); }
    }
}
