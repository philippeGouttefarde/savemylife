using UnityEngine;
using System.Collections;

public class NavLevel0 : MonoBehaviour
{

    public float waitingTimeInSecond = 3;

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
		Application.LoadLevel ("1_Call");
	}
}
