using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviour
{
    // Reference to the input fields and button in the UI
    public InputField usernameInput;
    public InputField passwordInput;
    public Button loginButton;

    // Start is called before the first frame update
    void Start()
    {
        loginButton.onClick.AddListener(OnLoginSubmit);
    }

    private void OnLoginSubmit()
    {
        string username = usernameInput.text;
        string password = passwordInput.text;

        switch (password)
        {
            case "TEST1":
                PlayerPrefs.SetString("Username", username);
                SceneManager.LoadScene("context1");
                break;
            default:
                Debug.LogWarning("Incorrect password. Please try again.");
                // You can also show this message in the UI.
                break;
        }
    }
}
