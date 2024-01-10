using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
            GameManager.Instance.ScorePlus();
        }
    }
}
