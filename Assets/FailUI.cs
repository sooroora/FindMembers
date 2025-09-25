using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailUI : MonoBehaviour
{
    [SerializeField] BalloonSpawner balloonSpawner;

    private void OnEnable()
    {
        balloonSpawner.StartSpawning();
    }

}
