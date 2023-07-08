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
        NotDestroy.Inst.UpdateScore(itemScore);
        Destroy(gameObject);
    }
}
