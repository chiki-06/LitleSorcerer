using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        InvokeRepeating(nameof(CheckEnemies), 1f, 1f);
    }

    private void CheckEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            uiManager.Victory();
            CancelInvoke(nameof(CheckEnemies));
        }
    }
}
