using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public void goToScene1()
    {
        SceneManage.Instance.ChangeScene("Scene1");
    }

    public void goToScene2()
    {
        SceneManage.Instance.ChangeScene("Scene2");
    }
    
}
