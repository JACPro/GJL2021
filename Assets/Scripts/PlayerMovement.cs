using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] Rigidbody rb;

    [SerializeField] Camera cam;
    [SerializeField] Texture2D crosshair;

    [SerializeField] float timeBetweenSteps = 0.5f;
    bool canPlaySound = true;

    Vector3 movement;
    Vector3 mousePos;

    void Start() {
        Vector2 cursorOffset = new Vector2(crosshair.width/2, crosshair.height/2);
        Cursor.SetCursor(crosshair, cursorOffset, CursorMode.Auto);    
    }

    void Update()
    {
        //handle player movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");

        //stop footsteps audio when not moving
        if (movement != Vector3.zero && canPlaySound)
        {
            GetComponent<AudioSource>().Play();
            canPlaySound = false;
            StartCoroutine(WaitToStep());
        }


        //handle player rotation to face mouse
        mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));        
    }

    void FixedUpdate() {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        Vector3 playerRotation = mousePos - rb.position;

        float angle = Mathf.Atan2(playerRotation.z, playerRotation.x) * Mathf.Rad2Deg - 90f;

        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }

    IEnumerator WaitToStep()
    {
        yield return new WaitForSeconds(timeBetweenSteps);
        canPlaySound = true;

    }
}
