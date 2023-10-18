using UnityEngine;
using System.Collections;

public class AutoSceneSwitcher : MonoBehaviour
{
    public SceneLoadManager _SceneLoadManager;

    public string sceneToLoad;
    public float delay = 4.0f;

    private void Start()
    {
        StartCoroutine(SwitchSceneAfterDelay());
    }

    private IEnumerator SwitchSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(SceneLoad());
    }

    public IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(1f);

        if (_SceneLoadManager && _SceneLoadManager.transitionAnimator)
        {
            _SceneLoadManager.transitionAnimator.Play("CircleExpand", 0, 0f);
            yield return new WaitForSeconds(1f); 
        }

        Loader.LoadScene(sceneToLoad);
    }
}
