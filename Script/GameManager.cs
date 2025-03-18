using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Text scoreText; // Referencia al texto en la UI
    private int score = 0; // Puntuación inicial

    void Awake()
    {
        Instance = this; // Configura este script como "Singleton" para que sea accesible desde otros scripts
    }

    void Start()
    {
        UpdateScoreUI(); // Actualiza la UI al iniciar
    }

    public void AddScore(int points)
    {
        score += points; // Suma puntos
        UpdateScoreUI(); // Actualiza la UI con la nueva puntuación
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Puntuación: " + score;
        }
    }
}
