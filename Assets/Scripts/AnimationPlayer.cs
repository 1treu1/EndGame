using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private float speedX = 0.0f;
    private float speedZ = 0.0f;
    public float acceleration = 2.5f;
    public float desacceleration = 2.5f;
    void Start()
    {
        animator = GetComponent<Animator>();
        speedZ = 0.01f;
    }

    void OnEnable()
    {
        Shoot.OnShoot += AnimationFire;
        Shoot.OnNoShoot += AnimationNoFire;
    }


    void OnDisable()
    {
        Shoot.OnShoot -= AnimationFire;
        Shoot.OnNoShoot -= AnimationNoFire;
    }

    // Update is called once per frame
    void Update()
    {
        //Input para hacer la animacion suave
        bool forwardPressed = Input.GetKey("w");
        bool backPressed = Input.GetKey("s");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");

        if (forwardPressed  && speedX <= 1.0f)
        {
            speedX += Time.deltaTime * acceleration;
        }
        if (backPressed && speedX <= 1.0f)
        {
            speedX += Time.deltaTime * acceleration;
        }
        if (leftPressed && speedX <= 1.0f)
        {
            speedX += Time.deltaTime * acceleration;
        }
        if (rightPressed && speedX <= 1.0f)
        {
            speedX += Time.deltaTime * acceleration;
        }




        if (!forwardPressed &&!backPressed && !leftPressed && !rightPressed && speedX > 0.0f)
        {
            speedX -= Time.deltaTime * acceleration;
            if (speedX < 0.0f)
                speedX = 0.0f;
        }
        


        //Donde ocurre la magia(la animacion)
        animator.SetFloat("XSpeed", speedX);
        animator.SetFloat("YSpeed", speedZ);
    }
    void AnimationFire()
    {
        if (speedZ <= 1.0f)
            speedZ += Time.deltaTime * acceleration;
    }
    void AnimationNoFire()
    {
        if (speedZ > 0.0f)
            speedZ -= Time.deltaTime * acceleration;
        if (speedZ < 0.0f)
            speedZ = 0.01f;
    }
}
