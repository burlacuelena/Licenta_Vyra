using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;
using TMPro;

public class AuthManager : MonoBehaviour
{
    [Header("Configuration")]
    public BackendSettings settings;

    [Header("UI Scripts")]
    public SceneChanger sceneChanger;

    [Header("Input Fields")]
    public TMP_InputField fullNameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;

    public void Register()
    {
        // Verificăm dacă ai tras toate câmpurile în Inspector ca să nu dea eroare
        if (fullNameInput == null || emailInput == null || passwordInput == null)
        {
            Debug.LogError("Lipsesc referintele la Input Fields in Inspector!");
            return;
        }

        StartCoroutine(RegisterRoutine());
    }

    private IEnumerator RegisterRoutine()
    {
        // Construim JSON-ul cu datele din UI
        string json = $"{{\"fullName\":\"{fullNameInput.text}\", \"email\":\"{emailInput.text}\", \"password\":\"{passwordInput.text}\"}}";

        UnityWebRequest request = new UnityWebRequest(settings.RegisterRoute, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        Debug.Log("Se trimite cererea catre: " + settings.RegisterRoute);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("BE SUCCESS: User Registered!");
            // Dacă înregistrarea a reușit, schimbăm scena
            if (sceneChanger != null)
            {
                sceneChanger.GoToSignIn();
            }
        }
        else
        {
            // Dacă dă eroare, ne va spune exact de ce (ex: server oprit, IP greșit)
            Debug.LogError("BE ERROR: " + request.error + " | " + request.downloadHandler.text);
        }
    }
}