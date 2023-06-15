using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(ProjectContext.Instance.SceneData.MenuScene);
    }
}
