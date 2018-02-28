using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    Rigidbody PlayerCollision;
    bool swim;
    public float swimSpeed;
    public Animator anim;

    private void Start()
    {
        PlayerCollision = GetComponent<Rigidbody>();
    }



    void Update()
    {
        PlayerMove();
    }
    void PlayerMove()
    {

        if (swim)
        { 
     
           PlayerCollision.MovePosition(transform.position + Camera.main.transform.forward * swimSpeed * Time.deltaTime);
           PlayerCollision.velocity = new Vector3(0, 0, 0);
           PlayerCollision.MovePosition(transform.position + Camera.main.transform.forward * swimSpeed * Time.deltaTime);
        }
    }

    public void SetSwim(bool value)
    {
        swim = value;
        if (value)
            anim.SetFloat("speed", 1);
        else
            anim.SetFloat("speed", 0);
    }
}
