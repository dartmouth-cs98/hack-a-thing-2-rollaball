using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

// The script needs to check every frame for player input
// And then apply that to the player GameObject every frame as movement

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0; // initial count value

        SetCountText();
        winTextObject.SetActive(false);
    }

    private void OnMove(InputValue movementValue)
    {
        // movementValue var will capture and store data from X&Y direction of input devices
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 12) // must reference number of collectibles
        {
            winTextObject.SetActive(true);
        }
    }

    private void FixedUpdate() // apply physics to Rigidbody
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); // f after value signifies float

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false); // disables game object
            count += 1;
            SetCountText();
        }
    }

}
