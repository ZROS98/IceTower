using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSound : MonoBehaviour
{
    [SerializeField] private AudioSource jump;
    [SerializeField] private CharacterController2D characterController2D;
    [SerializeField] private PlayerMovement playerMovement;

    private void Update()
    {
        bool grounded = characterController2D.m_Grounded;
        if (playerMovement.jumping && grounded && !jump.isPlaying) 
        {
            jump.Play();
        }
    }
}