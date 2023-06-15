using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(SwipeDetection), typeof(GameData))]
public class ProjectContext : MonoBehaviour
{
    public static ProjectContext Instance { get; private set; }

    public SceneData SceneData { get; private set; }
    public GameData GameData { get; private set; }
    public InputData InputData { get; private set; }
    public SwipeDetection SwipeDetection { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Instance.Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Initialize()
    {
        SceneData = new SceneData();
        InputData = new InputData();
        GameData = GetComponent<GameData>();
        SwipeDetection = GetComponent<SwipeDetection>();
    }
}
