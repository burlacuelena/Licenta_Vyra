using UnityEngine;

public class BackendSettings : MonoBehaviour
{
    [Header("Environment Settings")]
    //public string serverBaseUrl = "http://192.168.1.130:3000";
    public string serverBaseUrl = "http://172.30.43.60:3000";// Am actualizat IP-ul conform ipconfig
  
    public string RegisterRoute => serverBaseUrl + "/auth/register";
    public string LoginRoute => serverBaseUrl + "/auth/login";

    // --- ADAUGĂ ACEASTĂ PARTE DE JOS ---

    public static BackendSettings Instance { get; private set; }

    private void Awake()
    {
        // Dacă există deja o instanță și nu este aceasta, o distrugem pe cea nouă
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Altfel, aceasta devine instanța principală și nu va fi distrusă la schimbarea scenei
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}