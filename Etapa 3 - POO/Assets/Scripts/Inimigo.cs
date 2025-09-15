using UnityEngine;

public class Inimigo : Personagem
{
    [SerializeField]
    private int dano = 1;

    public void setDano(int dano)
    {
        this.dano = dano;
    }

    public int getDano()
    {
        return this.dano;
    }
    private void Update()
    {
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
