using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Atirar : MonoBehaviour
{
    public GameObject armaFrente;
    public GameObject balaPrefab;

    public GameObject bombaSpawn;
    public GameObject bombaPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button btnAtirar = GameObject.Find("BtnAtirar").GetComponent<Button>();
        btnAtirar.onClick.AddListener(Disparar);

        Button btnBomba = GameObject.Find("BtnBomba").GetComponent<Button>();
        btnBomba.onClick.AddListener(Bomba);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Disparar()
    {
        var bala = Instantiate(balaPrefab, armaFrente.transform.position, armaFrente.transform.rotation);
        Destroy(bala, 3f);
    }

    public void Bomba()
    {
        var bomba = Instantiate(bombaPrefab, bombaSpawn.transform.position, bombaSpawn.transform.rotation);
        Destroy(bomba, 3f);
    }
}
