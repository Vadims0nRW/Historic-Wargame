using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using Interaction;
using TMPro;

public class InGameMenu : MonoBehaviour
{

    [Header("Menu")]
 
    public GameObject inGame;
    public GameObject buildMenu;
    public GameObject researchMenu;
    public GameObject pauseMenu;
    public GameObject gameMenu;
    public GameObject interactionPanel;
    public GameObject interactionType;
    public TMP_Text interactionTypeText;

    private StarterAssetsInputs _input;
    private PlayerInput PlIn;

    // Start is called before the first frame update
    void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        PlIn = GetComponent<PlayerInput>();
        Cursor.visible = false;
        gameObject.GetComponent<StarterAssets.FirstPersonController>().enabled = true;
        inGame.SetActive(true);
        buildMenu.SetActive(false);
        researchMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameMenu.SetActive(false);

        //  AgeMenu[].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (_input.build)
        {
            CallBuildMenu();
        }

        if (_input.pause)
        {
            CallPauseMenu();
        }

        if (_input.menu)
        {
            CallMenu();
        }

        
    }

    void CallBuildMenu()
    {
        _input.build = false;

        inGame.SetActive(false);
        buildMenu.SetActive(true);
        researchMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameMenu.SetActive(false);

        gameObject.GetComponent<StarterAssets.FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void CallResearchMenu()
    {
   

        inGame.SetActive(false);
        buildMenu.SetActive(false);
        researchMenu.SetActive(true);
        pauseMenu.SetActive(false);
        gameMenu.SetActive(false);

        gameObject.GetComponent<StarterAssets.FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void CallPauseMenu()
    {
        _input.pause = false;

        inGame.SetActive(false);
        buildMenu.SetActive(false);
        researchMenu.SetActive(false);
        pauseMenu.SetActive(true);
        gameMenu.SetActive(false);

        gameObject.GetComponent<StarterAssets.FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }

    void CallMenu()
    {
        _input.menu = false;
        inGame.SetActive(false);
        buildMenu.SetActive(false);
        researchMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameMenu.SetActive(true);

        gameObject.GetComponent<StarterAssets.FirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ShowInteract(InteractionType type)
    {
        interactionPanel.SetActive(true);

        switch (type)
        {
            case InteractionType.Workshop:
                interactionTypeText.text = "Рабочее место";
                break;

            case InteractionType.Artillery:
                interactionTypeText.text = "Артиллерия";
                break;

            case InteractionType.NPC:
                interactionTypeText.text = "Говорить";
                break;

            case InteractionType.Resource:
                interactionTypeText.text = "Поднять";
                break;
        }

     //   interactionType.GetComponent<TextMesh>().text = interactionTypeText;
    }

    public void HideInteract()
    {
        interactionPanel.SetActive(false);
    }

    public void BackToGame()
    {
        inGame.SetActive(true);
        buildMenu.SetActive(false);
        researchMenu.SetActive(false);
        pauseMenu.SetActive(false);
        gameMenu.SetActive(false);

    
        gameObject.GetComponent<StarterAssets.FirstPersonController>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Back to Game");
    }

    public void SaveExit()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}