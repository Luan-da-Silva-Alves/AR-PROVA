/*
 * Copyright 2021 Google LLC
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Our car will track a reticle and collide with a <see cref="PackageBehaviour"/>.
 */
public class CarBehaviour : MonoBehaviour
{
    public ReticleBehaviour Reticle;
    public float Speed = 1.2f;

    public int pontos = 0;
    public TextMeshProUGUI pontosTxt;

    public TextMeshProUGUI arosTxt;
    public int qtdAros = 0;

    public TextMeshProUGUI caixasTxt;
    public int qtdCaixas = 0;

    private void Awake()
    {
        AssinarUI();
    }

    public void AssinarUI()
    {
        pontosTxt = GameObject.Find("Pontostxt").GetComponent<TextMeshProUGUI>();
        pontosTxt.text = "Pontos: " + pontos.ToString();
        arosTxt = GameObject.Find("ArosTxt").GetComponent<TextMeshProUGUI>();
        caixasTxt = GameObject.Find("CaixasTxt").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        

        var trackingPosition = new Vector3(Reticle.transform.position.x, transform.position.y, Reticle.transform.position.z);
        if (Vector3.Distance(trackingPosition, transform.position) < 0.1)
        {
            return;
        }

        var lookRotation = Quaternion.LookRotation(trackingPosition - transform.position);
        transform.rotation =
            Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        transform.position =
            Vector3.MoveTowards(transform.position, trackingPosition, Speed * Time.deltaTime);

        pontosTxt.text = "Pontos: " + pontos.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        var Package = other.GetComponent<PackageBehaviour>();
        if (Package != null)
        {
            if (Package.gameObject.CompareTag("+10"))
            {
                pontos += 10;
            }
            else if (Package.gameObject.CompareTag("+20"))
            {
                pontos += 20;
            }
            else if (Package.gameObject.CompareTag("+30"))
            {
                pontos += 30;
            }
            else if (Package.gameObject.CompareTag("+40"))
            {
                pontos += 40;
            }
            //Debug.Log(Package.gameObject.name + " TxtPontos: " + pontos);
            //pontosTxt.text = "Pontos: " + pontos.ToString();
            Destroy(other.gameObject);
            if (pontos >= 250)
            {
                pontos = 250;
                
                SceneManager.LoadScene("Vitoria");
            }
            else if (Package.gameObject.CompareTag("Inimigo"))
            {
                Debug.Log("Bateu no outro aviao");

                SceneManager.LoadScene("Derrota");

                //Destroy(Package.gameObject);
                Destroy(gameObject);

            }
            else if (other.gameObject.CompareTag("Aro"))
            {
                pontos += 25;
                qtdAros++;
                arosTxt.text = "Aros atravessados: " + qtdAros.ToString();
                Debug.Log("passou pelo aro");
            }
        }
    }

    
}
