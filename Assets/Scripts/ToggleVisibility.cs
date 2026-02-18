using TMPro;
using UnityEngine;
using UnityEngine.UI; // Adăugat pentru a manipula iconița dacă e nevoie

public class PasswordVisibility : MonoBehaviour
{
    public TMP_InputField passwordField;
    public GameObject eyeIconObject; // Obiectul cu iconița ochiului

    void Start()
    {
        // Ne asigurăm că la început parola este mereu ascunsă
        passwordField.contentType = TMP_InputField.ContentType.Password;
        passwordField.ForceLabelUpdate();
    }

    public void TogglePassword()
    {
        if (passwordField.contentType == TMP_InputField.ContentType.Password)
        {
            // O facem vizibilă
            passwordField.contentType = TMP_InputField.ContentType.Standard;

            // Opțional: Schimbăm aspectul ochiului (ex: îl facem mai transparent)
            if (eyeIconObject != null) eyeIconObject.SetActive(true);
        }
        else
        {
            // O ascundem cu steluțe
            passwordField.contentType = TMP_InputField.ContentType.Password;

            // Opțional: Schimbăm aspectul ochiului
            // if(eyeIconObject != null) eyeIconObject.SetActive(false);
        }

        passwordField.ForceLabelUpdate();
    }
}