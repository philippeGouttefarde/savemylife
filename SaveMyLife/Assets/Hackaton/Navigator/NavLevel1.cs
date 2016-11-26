using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavLevel1 : MonoBehaviour
{

	public void BackToLevel0 ()
	{
        SceneManager.LoadScene("0_Home");
	}

    public void BackToLevel2()
    {
        SceneManager.LoadScene("2_Video");
    }
}
