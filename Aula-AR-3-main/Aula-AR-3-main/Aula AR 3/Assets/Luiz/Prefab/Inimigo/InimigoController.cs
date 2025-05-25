using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;


public class InimigoController : MonoBehaviour
{
    //public Transform target; // jogador
    //public float radius = 2f;
    //public float speed = 30f;

    //private float angle = 0f;
    
    public GameObject[] points;
    [SerializeField] private float speed = 3f;          // Velocidade do patrulhamento
    [SerializeField] private int targetPoint = 0;       //Ponto alvo atual


    private void Start()
    {
        points = GameObject.FindGameObjectsWithTag("waypoint");
        //target = GameObject.Find("aircraft-a(Clone)").GetComponent<Transform>();
        targetPoint = Random.Range(0, points.Length); // Define o ponto alvo inicial aleatorio
    }

    void Update()
    {
        //CercarPlayer();
        if (transform.position == points[targetPoint].transform.position)
        {
            //Atualiza o targetPoint para o proximo waypoint
            targetPoint = Random.Range(0, points.Length); //Aleatoriza o proximo ponto
        }

        //Atualiza a posicao do NPC
        transform.position = Vector3.MoveTowards(transform.position, points[targetPoint].transform.position, speed * Time.deltaTime);
        transform.LookAt(points[targetPoint].transform);
    }

    //public void CercarPlayer()
    //{
    //    angle += speed * Time.deltaTime;

    //    float rad = angle * Mathf.Deg2Rad;
    //    Vector3 offset = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad)) * radius;

    //    transform.position = target.position + offset;
    //    transform.LookAt(target); // Faz o avião olhar para o jogador
    //}
}
