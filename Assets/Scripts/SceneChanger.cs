using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Funcția pentru Sign In (deja o ai)
    public void GoToSignIn()
    {
        SceneManager.LoadScene("SignInScene");
    }

    // Funcția NOUĂ pentru Sign Up
    public void GoToSignUp()
    {
        SceneManager.LoadScene("SignUpScene");
    }
}