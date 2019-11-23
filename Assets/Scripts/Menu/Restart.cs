using System;
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
    [SerializeField] private GameObject buttonMenu;
    [SerializeField] private ScoreController scoreController;
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject background;

    private void Start()
    {
        platformCreator = platformCreatorSpace.GetComponent<PlatformCreator>();
        cameraController = mainCamera.GetComponent<CameraController>();
    }

    public void RestartGame()
    {
        PoolManager.ReturnPool();
        mainCamera.transform.position = new Vector3(0, 0, 0);
        currentlyPlayerTransform.position = new Vector3(0, -11.94633f, 8);
        platformCreator.StartingSceneFilling();
        gameObject.SetActive(false);
        scoreMenu.SetActive(true);
        scoreController.RestartScore();
        buttonMenu.SetActive(true);
        cameraController.jumpIsDone = false;
        cameraController.startCameraMovement = false;
        playerMovement.startCamera = false;
        joystick.SnapX = true;
        joystick.input = Vector2.zero;
        background.SetActive(false);
        Time.timeScale = 1;
    }
}