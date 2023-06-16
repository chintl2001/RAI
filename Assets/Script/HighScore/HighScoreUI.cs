using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class HighScoreUI : MonoBehaviour
{
    public TMP_Text highScoreText;

    void Start()
    {
        // Lấy dữ liệu số điểm cao nhất từ PlayerPrefs JSON
        string json = PlayerPrefs.GetString("scores", "{}");
        ScoreData scoreData = JsonUtility.FromJson<ScoreData>(json);
        List<Score> scores = scoreData.scores;

        // Sắp xếp theo số điểm giảm dần
        scores.Sort((a, b) => b.score.CompareTo(a.score));

        // Hiển thị số điểm cao nhất lên TextMeshPro
        if (scores.Count > 0)
        {
            highScoreText.text = "High Score: " + scores[0].name + " - " + scores[0].score.ToString();
        }
        else
        {
            highScoreText.text = "No high score yet";
        }
    }
}
