using UnityEngine;

public class Inimigo : Personagem
{
    [SerializeField]
    private int dano = 1;
    [SerializeField]
    private Transform PosicaoDoPlayer;
    
    private SpriteRenderer spriteRenderer;

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
        
        if (PosicaoDoPlayer == null)
        {
            PosicaoDoPlayer = GameObject.Find("Player").transform;
        }
    }
    private void Update()
    {
        if (PosicaoDoPlayer.position.x - transform.position.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if (PosicaoDoPlayer.position.x - transform.position.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        
        if (PosicaoDoPlayer != null)
        {
            Debug.Log("Posição do Player" + PosicaoDoPlayer.position);
            
            transform.position = Vector3.MoveTowards(transform.position, PosicaoDoPlayer.transform.position, getVelocidade() * Time.deltaTime);
        }
        
        
        if (getVida() <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int novaVida = collision.gameObject.GetComponent<Personagem>().getVida() - getDano();
           collision.gameObject.GetComponent<Personagem>().setVida(novaVida);
           
        }
    }
}
