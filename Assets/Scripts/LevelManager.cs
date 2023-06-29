using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private GameObject[] cameraPoints;
    private int currentLoc;
    private void OnEnable()
    {
        NextLevelTrigger.OnNextLevel += NextLoc;
    }
    private void OnDisable()
    {
        NextLevelTrigger.OnNextLevel -= NextLoc;
    }
    private void NextLoc()
    {
        Debug.Log($"SDsdsds");
        currentLoc++;
        playerCamera.DOMove(cameraPoints[currentLoc].transform.position, 1f);
    }
}
