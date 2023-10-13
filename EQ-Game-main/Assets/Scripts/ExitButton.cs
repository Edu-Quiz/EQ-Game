using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void OnExitButtonClicked()
    {
        Loader.LoadScene("MainPrueba");

    }
}
