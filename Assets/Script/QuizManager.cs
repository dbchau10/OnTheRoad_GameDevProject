using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] Options;
    public int CurrentQuestion;
    public TextMeshProUGUI QuestionTxt;


    public GameObject QuizUI;


    private void Start(){

        AddQuestion("Người lái xe sử dụng đèn như thế nào khi lái xe trong khu đô thị và đông dân cư vào ban đêm ?", new string[] { "Bất cứ đèn nào miễn là mắt nhìn rõ phía trước", "Chỉ bật đèn chiếu xa (đèn pha) khi không nhìn rõ đường", "Đèn chiếu xa (đèn pha) khi đường vắng, đèn pha chiếu gần (đèn cốt) khi có xe đi ngược chiều", "Đèn chiếu gần (đèn cốt)" }, 4);
        AddQuestion("Theo Luật Giao thông đường bộ, tín hiệu đèn giao thông gồm 3 màu nào dưới đây ?", new string[] { "Đỏ-Vàng-Xanh", "Cam-Vàng-Xanh", "Vàng-Xanh dương-Xanh lá", "Đỏ-Cam-Xanh" }, 1);
         AddQuestion("Người đủ 16 tuổi được điều khiển các loại xe nào dưới đây ?", new string[] { "Xe mô tô 2 bánh có dung tích xi-lanh từ 50cm3 trở lên", "Xe gắn máy có dung tích xi lanh dưới 50cm3", "Xe ô tô tải dưới 3,5 tấn; xe chở người đến 9 chỗ ngồi", "Tất cả các ý nêu trên" }, 2);
        generateQuestion();
    }

    void AddQuestion(string question, string[] answers, int correctAnswer)
    {
        QuestionAndAnswer qa = new QuestionAndAnswer
        {
            Question = question,
            Answers = answers,
            CorrectAnswer = correctAnswer
        };

        QnA.Add(qa);
    }

     public void QuizOpen(){
        QuizUI.SetActive(true);
    }

     public void QuizSkip(){
        QuizUI.SetActive(false);

        //  QnA.RemoveAt(CurrentQuestion);
        generateQuestion();
    }
    public void correct(){
        QuizUI.SetActive(false);
        QnA.RemoveAt(CurrentQuestion);
        generateQuestion();
    }
    void SetAnswers(){
        for (int i= 0; i < Options.Length; i++){
           Options[i].GetComponent<AnswerScript>().isCorrect = false;
           Options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[CurrentQuestion].Answers[i];
        
            if (QnA[CurrentQuestion].CorrectAnswer == i + 1){
                Options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }
    void generateQuestion(){
        if (QnA.Count > 0) {
        CurrentQuestion = Random.Range(0,QnA.Count);
        QuestionTxt.text =  QnA[CurrentQuestion].Question;

        SetAnswers();

        }

    }
}
