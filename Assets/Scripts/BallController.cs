using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float impulseForce = 5f;

    private Vector3 startPos;
    public int perfectPass = 0;
    private bool ignoreNextCollision;
    public bool isSuperSpeedActive;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (perfectPass >= 3 && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            rb.AddForce(Vector3.down * 10, ForceMode.Impulse);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (ignoreNextCollision)
            return;
        if (isSuperSpeedActive)
        {
            if (!other.transform.GetComponent<Goal>())
            {
                Destroy(other.gameObject);
                Debug.Log("Destroying stages");
            //    foreach (Transform t in other.transform.parent)
            //     {
            //         gameObject.AddComponent<TriangleExplosion>();

            //         StartCoroutine(gameObject.GetComponent<TriangleExplosion>().SplitMesh(true));
                  
            //         Debug.Log("exploding - exploding - exploding - exploding");
            //     }
            //     Destroy(other.transform.parent.gameObject);

            }

        }
        // If super speed is not active and a death part git hit -> restart game
          else
        {
            DeathPart deathPart = other.transform.GetComponent<DeathPart>();
            if (deathPart)
                deathPart.HitDeathPart();
        }

        rb.velocity = Vector3.zero; // Remove velocity to not make the ball jump higher after falling done a greater distance
        rb.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);



        // Safety check
        ignoreNextCollision = true;
        Invoke("AllowCollision", .2f);


        // Handlig super speed
        perfectPass = 0;
        isSuperSpeedActive = false;
    }

    public void ResetBall()
    {
        transform.position = startPos;
    }

    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }

}
