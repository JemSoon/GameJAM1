using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NotDestroy : MonoBehaviour
{
    public static NotDestroy Inst { get; private set; }
    private void Awake() 
    {
        if (Inst == null)
        { 
            Inst = this; 
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public int Score;
    public int Life;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textLife;
    public AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        Inst.gameObject.SetActive(true);
        DontDestroyOnLoad(gameObject);
        UpdateScore(0);
        Score = 0;
        Life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        textScore.text = "Score: " + Score;
    }

    public void UpdateLife()
    {
        textLife.text = "x " + Life;
    }


}
