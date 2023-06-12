using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private GameInputs gameInputs;

    [Header("Settings")]
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float rotateSpeed = 1f;

    private void Start()
    {
        newEvents.Sub("Start Game", RestartPosition);
    }

    private void Update()
    {
        if (GameMeneger.Instance.isPlay && GameMeneger.Instance.canGo)
        {
            MoveUpdate();
            RotateUpdate();
        }
    }

    // Update player movement
    private void MoveUpdate()
    {
        Vector2 move = gameInputs.GetMovement();
        if (move != Vector2.zero)
        {
            move *= Time.deltaTime * movementSpeed * 5f;
            Vector3 newMove = new Vector3(move.x, 0f, move.y);
            transform.Translate(newMove);
        }

        // Restrict player within the game area
        float range = WorldMeneger.Range;
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -range, range);
        currentPosition.z = Mathf.Clamp(currentPosition.z, -range, range);
        transform.position = currentPosition;
    }

    // Update camera rotation
    private void RotateUpdate()
    {
        float rotate = gameInputs.GetRotate();
        if (rotate != 0f)
        {
            transform.rotation *= Quaternion.Euler(0f, rotate * Time.deltaTime * rotateSpeed * 50f, 0f);
        }
    }

    // Reset player position when the game starts
    private bool RestartPosition()
    {
        transform.position = Vector3.zero;
        return true;
    }
}
