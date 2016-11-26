using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NavLevel2 : MonoBehaviour
{

	public void BackToLevel0 ()
	{
        SceneManager.LoadScene("0_Home");
	}
}
