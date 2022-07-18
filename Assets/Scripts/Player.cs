using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private int health = 100;
    private float recoveryCounter;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        Debug.Log(calculator());
    }

    // Update is called once per frame
    void Update()
    {
        // Moving the Box
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed * Time.deltaTime;

        //Timing
        recoveryCounter += 1 * Time.deltaTime;

        //Sizing
        transform.localScale += new Vector3(.5f, .5f, .5f) * Time.deltaTime;

        // Limiting Box Movement
        CheckBounds();
    }
    public void Hurt()
    {
        if(recoveryCounter > 2)
        {
            health -= 1;
            recoveryCounter = 0;
            transform.localScale = new Vector3(1, 1, 1);
            Debug.Log("Hurt: " + health);
        }
    }
    void CheckBounds()
    {
        // Limiting Box Movement
        if (transform.position.x > 8.38)
        {
            transform.position = new Vector3(8.38f, transform.position.y, transform.position.z);
            Hurt();
        }
        if (transform.position.x < -8.39)
        {
            transform.position = new Vector3(-8.39f, transform.position.y, transform.position.z);
            Hurt();
        }
        if (transform.position.y > 4.4)
        {
            transform.position = new Vector3(transform.position.x, 4.4f, transform.position.z);
            Hurt();
        }
        if (transform.position.y < -4.4)
        {
            transform.position = new Vector3(transform.position.x, -4.4f, transform.position.z);
            Hurt();
        }
    }
    string calculator()
    {
        return "ababa";
    }
}
