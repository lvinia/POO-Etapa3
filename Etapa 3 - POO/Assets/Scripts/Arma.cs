using UnityEngine;

public class Arma : MonoBehaviour
{
    public Transform saidaDoTiro;
    
    public GameObject bala;
    public float intervaloDeDisparo = 0.2f;
    
    private float tempoDeDisparo = 0;
    
    
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (tempoDeDisparo <= 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("Bala disparada");
            GameObject b = Instantiate(bala, saidaDoTiro.position, saidaDoTiro.rotation) as GameObject;
            
            tempoDeDisparo = intervaloDeDisparo;
        }

        if (tempoDeDisparo > 0)
        {
            tempoDeDisparo -= Time.deltaTime;
        }
    }
}
