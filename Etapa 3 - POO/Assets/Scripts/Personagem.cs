using UnityEngine;

public class Personagem : MonoBehaviour
{
    [SerializeField]
    private float velocidade;
    [SerializeField]
    private int vida;
    [SerializeField]
    private int energia;

    public void setVelocidade(float velocidade)
    {
        this.velocidade = velocidade;
    }

    public float getVelocidade()
    {
        return this.velocidade;
    }

    public void setVida(int vida)
    {
        this.vida = vida;
    }

    public int getVida()
    {
        return this.vida;
    }

    public void setEnergia(int energia)
    {
        this.energia = energia;
    }

    public int getEnergia()
    {
        return this.energia;
    }

    public void recebeDano(int dano)
    {
        int novaVida = getVida() - dano;
        setVida(novaVida);
    }
}
