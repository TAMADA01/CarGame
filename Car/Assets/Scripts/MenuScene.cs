using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    public void LoadGame()
    {
        ProjectContext.Instance.SceneData.LoadScene = ProjectContext.Instance.SceneData.GameScene;
        SceneManager.LoadScene(ProjectContext.Instance.SceneData.LoadingScene);
    }
}
