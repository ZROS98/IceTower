using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour
{
    [SerializeField] private Collider2D santaCollider;
    [SerializeField] private GameObject afterDeathMenu;
    [SerializeField] private GameObject scoreMenu;
    [SerializeField] private AudioSource death;
    private void Start()
    {
        afterDeathMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other = santaCollider)
        {
            death.Play();
            StartCoroutine(TimeDelay(2f));

        }
    }
    public IEnumerator TimeDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        scoreMenu.SetActive(false);
        afterDeathMenu.SetActive(true);
        Time.timeScale = 0;
    }
}