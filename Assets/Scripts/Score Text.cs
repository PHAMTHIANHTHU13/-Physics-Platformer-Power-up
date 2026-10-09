using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText; // khởi tạo biến lấy giá trị text hiển thị điểm số

    int score = 0;

    void Start()
    {
        AddSCore(0); // additionalScore = 10, 
    }

    public void AddSCore (int additionalScore)
    {
        score += additionalScore; // ý nghĩa là score = score + additionalScore
        scoreText.text = "Score: " + score; // hiển thị điểm số lên màn hình, score chỗ này là điểm hiển thị của additionalScore
    }
    
}
