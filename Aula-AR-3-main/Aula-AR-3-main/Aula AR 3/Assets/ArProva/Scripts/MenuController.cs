using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // Referências aos botões
    public Button Jogar;
    public Button Sair;
    


    void Start()
    {
        // Atribui as funções aos botões
        Jogar.onClick.AddListener(PlayGame);
        Sair.onClick.AddListener(ExitGame);
        

    }

    // Função para trocar para a cena do jogo
    void PlayGame()
    {
        SceneManager.LoadScene("ArProva");
    }

   

    // Função para sair do jogo
    void ExitGame()
    {
        Debug.Log("Sair do jogo...");
        Application.Quit();
    }
}