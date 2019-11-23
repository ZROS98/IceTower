using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Text currentScore;

    void Update()
    {
        scoreText.text = currentScore.text;
    }
}