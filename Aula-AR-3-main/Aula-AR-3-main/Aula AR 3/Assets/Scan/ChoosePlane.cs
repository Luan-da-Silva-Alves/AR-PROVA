using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePlane : MonoBehaviour
{
    public GameObject plane;

    public GameObject[] planePrefab;

    public GameObject uiGame;
    public GameObject uiPregame;

    public bool canStart = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(DesabilitarUI());

    }
    IEnumerator DesabilitarUI()
    {
        yield return new WaitForSeconds(.1f);
        uiGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    public void Aviao1()
    {
        plane = planePrefab[0];

        uiGame.SetActive(true);
        uiPregame.SetActive(false);

        canStart = true;

        
    }
    public void Aviao2()
    {
        plane = planePrefab[1];

        uiGame.SetActive(true);
        uiPregame.SetActive(false);

        canStart = true;

        
    }
    public void Aviao3()
    {
        plane = planePrefab[2];

        uiGame.SetActive(true);
        uiPregame.SetActive(false);

        canStart = true;

        
    }
}
