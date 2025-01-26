using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Player Sprite")]
    [SerializeField] private GameObject playerSprite;

    [Header("Movement Speed")]
    [SerializeField] private float speed = 5f;

    [Header("Animator")]
    [SerializeField] private Animator animPlayer;

    [SerializeField] AudioSource a;
    [SerializeField] AudioClip walkClips;

    private Vector3 movement; // For tracking input
    private bool isMoving;    // To determine animation state

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {

        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement += Vector3.forward;

        }
        if (Input.GetKey(KeyCode.S))
        {
            movement += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement += Vector3.left;
            playerSprite.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement += Vector3.right;
            playerSprite.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        isMoving = movement != Vector3.zero;

        bool isTrigger = false;
        if (isMoving)
        {
            transform.Translate(movement.normalized * speed * Time.deltaTime, Space.World);
            if (!isTrigger)
            {
                isTrigger = true;
                a.Play();
            }
        }
        else
        {
            a.Stop();
            isTrigger = false;
        }

        animPlayer.SetBool("isWalk", isMoving);
    }
}
