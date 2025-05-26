using UnityEngine;

public class BombaController3 : MonoBehaviour
{
    public GameObject explosionEffect;
    public AudioSource BombaCaindo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Caixa"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Debug.Log("Bomba colidiu com a caixa");
            CarBehaviour car = GameObject.Find("Aviao2(Clone)").GetComponent<CarBehaviour>();
            car.pontos += 25;

            car.qtdCaixas++;
            car.caixasTxt.text = "Caixas destruídas: " + car.qtdCaixas;

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
