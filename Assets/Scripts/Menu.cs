using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI nameInput;
    public Button startBtn;
    // Start is called before the first frame update
    void Awake()
    {
        startBtn.onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        string pName = (nameInput.text == "") ? "Player" : nameInput.text;
        DataManager.Instance.playerName = pName;
        SceneManager.LoadScene("main");
    }
}
