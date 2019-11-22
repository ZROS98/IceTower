using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class DieSpace : MonoBehaviour
{
    private Collider2D santaCollider;
    [SerializeField] private GameObject afterDeathMenu;
    [SerializeField] private GameObject scoreMenu;
    [SerializeField] private AudioSource death;
    [SerializeField] private GameObject buttonMenu;
    [SerializeField] private GameObject player;

    private void Start()
    {
        santaCollider = player.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other == santaCollider)
        {
            death.Play();
            scoreMenu.SetActive(false);
            buttonMenu.SetActive(false);
            afterDeathMenu.SetActive(true);
            Time.timeScale = 0;

        }
    }
}