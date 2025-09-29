using UnityEngine;

public class Inimigo : Personagem
{
    [SerializeField]
    private int dano = 1;
    //public float
    [SerializeField]
    private Transform PosicaoDoPlayer;
    
    private SpriteRenderer spriteRenderer;
    
    private Animator animator;
    
    private bool andando = false;

    public float raioDeVisao;

    public void setDano(int dano)
    {
        this.dano = dano;
    }

    public int getDano()
    {
        return this.dano;
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
        if (PosicaoDoPlayer == null)
        {
            PosicaoDoPlayer = GameObject.Find("Player").transform;
        }
    }
    private void Update()
    {
        andando = false;
        
        if (PosicaoDoPlayer.position.x - transform.position.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (PosicaoDoPlayer.position.x - transform.position.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        
        if (PosicaoDoPlayer != null && Vector3.Distance(PosicaoDoPlayer.position, transform.position) <= raioDeVisao )
        {
            Debug.Log("Posição do Player" + PosicaoDoPlayer.position);
            
            transform.position = Vector3.MoveTowards(transform.position, PosicaoDoPlayer.transform.position, getVelocidade() * Time.deltaTime);
            andando = true;
        }
        
        
        if (getVida() <= 0)
        {
            gameObject.SetActive(false);
        }
        animator.SetBool("Andando",andando);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int novaVida = collision.gameObject.GetComponent<Personagem>().getVida() - getDano();
           collision.gameObject.GetComponent<Personagem>().setVida(novaVida);
           
           Destroy(gameObject);
           
        }
    }
}
