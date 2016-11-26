using UnityEngine;
using System.Collections;

public class NavLevel1 : MonoBehaviour
{

	public void BackToLevel0 ()
	{
		Application.LoadLevel ("0_Home");
	}

    public void BackToLevel2()
    {
        Application.LoadLevel("2_Video");
    }
}
