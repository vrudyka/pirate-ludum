using UnityEngine;
using UnityEngine.SceneManagement;

public class BatyaSceneController : MonoBehaviour
{
    private void Start()
    {
        BatyaCharacterCatching.OnPlayerCaught += ReloadCurrentScene;
    }

    private void ReloadCurrentScene()
    {
        var currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    private void OnDisable()
    {
        BatyaCharacterCatching.OnPlayerCaught -= ReloadCurrentScene;
    }
}
