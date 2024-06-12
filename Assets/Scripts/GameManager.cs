using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    public GameObject player;
    public Camera mainCamera;
    public Camera cutsceneCamera;
    public GameObject playerUI;
    public GameObject cutsceneUI;
    public CharacterController characterController;
    private PlayerMotor motor;
    private PlayerLook look;
    private PlayerInteract interact;
    private PlayerHealth health;

    public PlayerMotor Motor => motor;
    public PlayerLook Look => look;
    public PlayerInteract Interact => interact;
    public PlayerHealth Health => health;

    public PauseMenu pauseMenu;
    public GameObject minigameUI;
    private CatchGameManager cgManager;
    public CatchGameManager catchGameManager => cgManager;

    void Awake()
    {
        Cursor.visible = false;
        
        // Implement the Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (player == null || mainCamera == null || cutsceneCamera == null || playerUI == null || cutsceneUI == null || characterController == null || pauseMenu == null || minigameUI == null)
        {
            Debug.LogError("GameManager: Essential elements are not set in the Inspector.");

            // Quit if critical components are missing
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }

        motor = player.GetComponent<PlayerMotor>();
        look = player.GetComponent<PlayerLook>();
        interact = player.GetComponent<PlayerInteract>();
        health = player.GetComponent<PlayerHealth>();
        cgManager = minigameUI.GetComponent<CatchGameManager>();
    }
}
