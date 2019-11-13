﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityNightPool;
using UnityNightPool.Example;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Transform currentlyPlayerTransform;
    [SerializeField] private GameObject platformCreatorSpace;
    [SerializeField] private GameObject scoreMenu;
    private PlatformCreator platformCreator;
    [SerializeField] private Text scoreText;
    [SerializeField] private PlayerMovement playerMovement;
    private CameraController cameraController;

    private void Start()
    {
        platformCreator = platformCreatorSpace.GetComponent<PlatformCreator>();
        cameraController = mainCamera.GetComponent<CameraController>();
    }

    public void RestartGame()
    {
        PoolManager.ReturnPool();
        mainCamera.transform.position = new Vector3(0, 0, 0);
        currentlyPlayerTransform.position = new Vector3(0, -11.985f, 8);
        platformCreator.StartingSceneFilling();
        gameObject.SetActive(false);
        scoreMenu.SetActive(true);
        scoreText.text = "0";
        cameraController.jumpIsDone = false;
        cameraController.startCameraMovement = false;
        playerMovement.startCamera = false;
        Time.timeScale = 1;
    }
}