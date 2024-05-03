using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VICTORYScript : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            Restartscene();
        }
    }
    private void Restartscene()
    {
        SceneManager.LoadScene("New_Asset_Scene");
    }
}
