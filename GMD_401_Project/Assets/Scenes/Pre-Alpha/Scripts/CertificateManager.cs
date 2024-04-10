using UnityEngine;
using UnityEngine.UI;

public class CertificateManager : MonoBehaviour
{
    public Text certificateText;

    // Start is called before the first frame update
    void Start()
    {
        string username = PlayerPrefs.GetString("Username", "Player");
        certificateText.text = username;
    }
}
