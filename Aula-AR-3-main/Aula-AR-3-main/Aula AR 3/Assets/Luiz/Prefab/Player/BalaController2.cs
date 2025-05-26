using UnityEngine;

public class BalaController : MonoBehaviour
{
    private Rigidbody fis;
    public float velocidade;
    public GameObject explosionEffect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fis = GetComponent<Rigidbody>();
        fis.AddForce(transform.forward * velocidade, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
        
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Debug.Log("Atingiu o aviao inimigo");
            CarBehaviour car = GameObject.Find("Aviao2(Clone)").GetComponent<CarBehaviour>();
            car.pontos += 50;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
