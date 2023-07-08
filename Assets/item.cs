using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public int itemScore;

    private void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (NotDestroy.Inst != null)
        { NotDestroy.Inst.UpdateScore(itemScore); }
        Destroy(gameObject);
    }
}
