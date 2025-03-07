using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _TMP;
    void Start()
    {
        EventBank.OnScoreCalculated.AddListener(ShowScore);
    }

    private void ShowScore(int pScore)
    {
        _TMP.gameObject.SetActive(true);
        _TMP.text = $"Score : {pScore}";
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
