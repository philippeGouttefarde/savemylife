using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIAnimatorLevel1 : MonoBehaviour
{
    [Header("Animated text")]
    public Text inCallText;
    public string T1 = "Appel en cours.";
    public string T2 = "Appel en cours..";
    public string T3 = "Appel en cours...";
    public string T4 = "Appel en cours....";

    public Text currentTimeTxt;

    private void Start()
    {
        StartCoroutine("AnimateText");
    }

    // every 2 seconds perform the print()
    private IEnumerator AnimateText()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            float currentTime = Time.time;
            currentTime -= (int)currentTime;

            if (currentTime <= 0.25f)
            {
                inCallText.text = T1;
            } else if (currentTime <= 0.50f)
            {
                inCallText.text = T2;
            } else if (currentTime <= 0.75f)
            {
                inCallText.text = T3;
            }
            else
            {
                inCallText.text = T4;
            }

            currentTimeTxt.text = System.DateTime.UtcNow.ToString();
        }
    }

    public void GoToLevel1 ()
	{
		SceneManager.LoadScene ("1_Call");
	}
}
