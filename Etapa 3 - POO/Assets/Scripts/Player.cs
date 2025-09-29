using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Personagem
{
    private SpriteRenderer spriteRenderer;
    public Transform arma;
    
    private Animator animator;

    private bool andando = false;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        andando = false;
        
        if (arma.rotation.eulerAngles.z > -90 && arma.rotation.eulerAngles.z < 90)
        {
           spriteRenderer.flipX = false;
        }
        if (arma.rotation.eulerAngles.z > 90 && arma.rotation.eulerAngles.z < 270)
        {
            spriteRenderer.flipX = true;
        }
        
        
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0, getVelocidade()* Time.deltaTime, 0);
            andando = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position -= new Vector3(0, getVelocidade()* Time.deltaTime, 0);
            andando = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(getVelocidade()* Time.deltaTime, 0, 0);
            andando = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position -= new Vector3(getVelocidade()* Time.deltaTime, 0, 0);
            andando = true;
        }

        if (getVida() <= 0)
        {
            Debug.Log("Jogador Morreu");
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
           // gameObject.SetActive(false);
        }
        
        animator.SetBool("Andando",andando);
    }
}
