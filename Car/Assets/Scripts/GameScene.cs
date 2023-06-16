using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScene : MonoBehaviour
{
    private bool _isLeftButtonPressed;
    private bool _isRightButtonPressed;
    private bool _isUpButtonPressed;
    private bool _isDownButtonPressed;

    private InputData _inputData => ProjectContext.Instance.InputData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenu();
        }
    }

    public void LoadMenu()
    {
        ProjectContext.Instance.SceneData.LoadScene = ProjectContext.Instance.SceneData.MenuScene;
        SceneManager.LoadScene(ProjectContext.Instance.SceneData.LoadingScene);
    }

    public void OnLeftButtonDown()
    {
        _isLeftButtonPressed = true;
        if (!_isRightButtonPressed)
        {
            _inputData.Horizontal = -1f;
        }
    }

    public void OnLeftButtonUp()
    {
        _isLeftButtonPressed = false;
        if (!_isRightButtonPressed)
        {
            _inputData.Horizontal = 0f;
        }
    }

    public void OnRightButtonDown()
    {
        _isRightButtonPressed = true;
        if (!_isLeftButtonPressed)
        {
            _inputData.Horizontal = 1f;
        }
    }

    public void OnRightButtonUp()
    {
        _isRightButtonPressed = false;
        if (!_isLeftButtonPressed)
        {
            _inputData.Horizontal = 0f;
        }
    }

    public void OnUpButtonDown()
    {
        _isUpButtonPressed = true;
        if (!_isDownButtonPressed)
        {
            _inputData.Vertical = 1f;
        }
    }

    public void OnUpButtonUp()
    {
        _isUpButtonPressed = false;
        if (!_isDownButtonPressed)
        {
            _inputData.Vertical = 0f;
        }
    }

    public void OnDownButtonDown()
    {
        _isDownButtonPressed = true;
        if (!_isUpButtonPressed)
        {
            _inputData.Vertical = -1f;
        }
    }

    public void OnDownButtonUp()
    {
        _isDownButtonPressed = false;
        if (!_isUpButtonPressed)
        {
            _inputData.Vertical = 0f;
        }
    }

    public void OnBreakButtonDown()
    {
        _inputData.IsBreaking = true;
    }

    public void OnBreakButtonUp()
    {
        _inputData.IsBreaking = false;
    }
}
