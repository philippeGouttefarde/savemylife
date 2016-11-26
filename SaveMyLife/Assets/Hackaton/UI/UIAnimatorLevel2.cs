using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIAnimatorLevel2 : MonoBehaviour
{
    [Header("Animated text")]
    public Text timer;
    public Text currentTime;

    private void Start()
    {
        StartCoroutine("AnimateText");
    }

    private string ConvertTimeToStr(int timeInSecond)
    {
        string str = "";
        int nbSeconds = timeInSecond % 60;
        int nbMinutes = timeInSecond / 60;

        if (nbMinutes < 10)
        {
            str += "0";            
        }

        str += nbMinutes;
        str += ":";

        if (nbSeconds < 10)
        {
            str += "0";
        }

        str += nbSeconds;
        str += "'";

        return str;
    }

    // every 2 seconds perform the print()
    private IEnumerator AnimateText()
    {
        float timerInSeconds = Time.time;
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            int nbSecondsInCall = (int)Time.time - (int)timerInSeconds;
            timer.text = ConvertTimeToStr(nbSecondsInCall);

            currentTime.text = System.DateTime.UtcNow.ToString();
        }
    }

    public void GoToLevel1 ()
	{
        SceneManager.LoadScene("1_Call");
	}
}
