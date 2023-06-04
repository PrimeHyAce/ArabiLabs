using System.Collections;
using System.Collections.Generic;
using TMPro;
using RTLTMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] TMP_Text questionText;
    [SerializeField] Image questionImage;
    [SerializeField] List<RTLTextMeshPro> answerTexts;

    [SerializeField] Slider quizProgressSlider;
    [SerializeField] GameObject quizResultPanel;
    [SerializeField] TMP_Text quizResultText;

    [SerializeField] List<QuizData> quizDatas;

    int currentQuestionIndex = 0;
    int score = 0;

    private void Start()
    {
        SetQuestion();
    }

    private void Update()
    {
        quizProgressSlider.value = (float)currentQuestionIndex / quizDatas.Count;
    }

    void SetQuestion()
    {
        questionText.text = quizDatas[currentQuestionIndex].question;
        questionImage.sprite = quizDatas[currentQuestionIndex].questionImage;

        for (int i = 0; i < answerTexts.Count; i++)
        {
            answerTexts[i].text = quizDatas[currentQuestionIndex].answers[i];
        }
    }

    public void CheckAnswer(int answerIndex)
    {
        if (answerIndex == quizDatas[currentQuestionIndex].correctAnswerIndex)
        {
            Debug.Log("Correct");
            score++;
        }
        else
        {
            Debug.Log("Wrong");
        }

        if (currentQuestionIndex >= quizDatas.Count - 1)
        {
            Debug.Log("Quiz Finished");
            quizResultPanel.SetActive(true);
            quizResultText.text = "Nilai: " + score * 20;
        }
        else
        {
            currentQuestionIndex++;
            SetQuestion();
        }

        // currentQuestionIndex++;

        // if (currentQuestionIndex >= quizDatas.Count)
        // {
        //     // currentQuestionIndex = 0;
        //     Debug.Log("Quiz Finished");
        //     quizResultPanel.SetActive(true);
        //     quizResultText.text = "Quiz Finished";
        // }

        // SetQuestion();
    }
}

[System.Serializable]
public class QuizData
{
    public string question;
    public Sprite questionImage;
    public List<string> answers;
    public int correctAnswerIndex;
}
