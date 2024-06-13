using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFly : MonoBehaviour
{

    public Rigidbody thisRigidbody;
    public float JumpPower = 10;
    public float JumpInterval = 0.5f;

    private float jumpCooldown = 01;


    // Start is called before the first frame update
    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        // Update cooldown

        jumpCooldown -= Time.deltaTime;
        bool canJump = jumpCooldown <= 0 && GameManager.Instance.isGameActive();


        // Jump

        if (canJump)
        {
            bool jump = Input.GetKey (KeyCode.Space);
            if (jump) 
            {
                thisRigidbody.AddForce(new Vector3(0, JumpPower, 0),ForceMode.Impulse);
            }
        }

        // thisRigidbody.useGravity = isGameActive();


    }

    void OnCollisionEnter(Collision other)
    {
        OnCustomCollisonEnter(other.gameObject);
    }
    
    void OnTriggerEnter(Collider other)
    {
        OnCustomCollisonEnter(other.gameObject);
    }


    private void OnCustomCollisonEnter(GameObject other)
    {
        bool isSensor = other.CompareTag("Sensor");
        if (isSensor)
        {
            GameManager.Instance.score++;
            Debug.Log($"Score {GameManager.Instance.score}");
        }
        else
        {
            Debug.Log("Game Over");
            GameManager.Instance.EndGame();
        }

    }

    private void Jump()
    {
        // reset cooldown 
        bool jump = Input.GetKey (KeyCode.Space);
        if (jump) 
        {
            // A[[ly forcee

            thisRigidbody.velocity = Vector3.zero;
            thisRigidbody.AddForce(new Vector3(0, JumpPower, 0),ForceMode.Impulse);
        }
    }
}
