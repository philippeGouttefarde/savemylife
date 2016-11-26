using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavLevel0 : MonoBehaviour
{

    public float waitingTimeInSecond = 5;

    private void Start()
    {
        StartCoroutine("SimulateCall");
    }

    // every 2 seconds perform the print()
    private IEnumerator SimulateCall()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitingTimeInSecond);
            GoToLevel1();
        }
    }

    public void GoToLevel1 ()
	{
        SceneManager.LoadScene("1_Call");
	}
}
