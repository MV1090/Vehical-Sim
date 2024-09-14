using UnityEngine;
using TMPro;
using System.Collections;

public class StartTimer : MonoBehaviour
{
    [SerializeField] TMP_Text countDownText;
    int countDownTime = 3;

    public IEnumerator CountDownToStart()
    {
        while (countDownTime > 0)
        {
            countDownText.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime --;
        }

        countDownText.text = "GO!";

        GameManager.Instance.beginRace = true;

        yield return new WaitForSeconds(1f);

        countDownText.gameObject.SetActive(false);
    }        

    public void StartCountDownTimer()
    {
        countDownTime = 3;

        countDownText.gameObject.SetActive(true);
        StartCoroutine(CountDownToStart());
    }

 }
