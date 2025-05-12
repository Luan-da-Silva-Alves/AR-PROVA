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
    

    private void Awake()
    {
        pontosTxt = GameObject.Find("Pontostxt").GetComponent<TextMeshProUGUI>();
        pontosTxt.text = "Pontos: " + pontos.ToString();
    }

    private void Update()
    {
        var trackingPosition = Reticle.transform.position;
        if (Vector3.Distance(trackingPosition, transform.position) < 0.1)
        {
            return;
        }

        var lookRotation = Quaternion.LookRotation(trackingPosition - transform.position);
        transform.rotation =
            Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        transform.position =
            Vector3.MoveTowards(transform.position, trackingPosition, Speed * Time.deltaTime);
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
            Debug.Log(Package.gameObject.name + " TxtPontos: " + pontos);
            pontosTxt.text = "Pontos: " + pontos.ToString();
            Destroy(other.gameObject);
            if (pontos >= 100)
            {
                pontos = 100;
                
                SceneManager.LoadScene("Vitoria");
            }
            else if (Package.gameObject.CompareTag("obstaculo"))
            {

                SceneManager.LoadScene("Derrota");


                //Destroy(Package.gameObject);
                Destroy(gameObject);

            }
        }
    }
}
