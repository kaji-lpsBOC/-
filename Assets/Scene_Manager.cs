using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public void PushThisButton_StageSelect()
    {
        SceneManager.LoadScene("Stage_Select");
    }

    public void PushThisButton_GoTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void PushThisButton_GoBattle()
    {
        SceneManager.LoadScene("Battle");
    }
    public void PushThisButton_GoStatus()
    {
        SceneManager.LoadScene("Status");
    }
}
