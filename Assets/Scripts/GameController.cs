using UnityEngine;
using UnityEngine.SceneManagement;


public static class GameInput
{
    public static bool Jump
    {
        get { return Input.GetAxis("Jump") > 0 || Input.touchCount > 0; }
    }
}

public class GameController : MonoBehaviour
{

	private PlayerController playerController;
	private SceneController sceneController;
	private CactusCreator cactusCreator;
	private GameObject gameoverUI;
	private ScoreManager scoreManager;
    private bool Die = false;

	void Start ()
	{
		playerController = FindObjectOfType<PlayerController>();
		sceneController = FindObjectOfType<SceneController>();
		cactusCreator = FindObjectOfType<CactusCreator>();

		scoreManager = FindObjectOfType<ScoreManager>();
		scoreManager.StartScoring();

		gameoverUI = GameObject.Find("GameoverUI");
		gameoverUI.SetActive(false);

		Physics2D.gravity = Vector2.down * 50;
	}

    private void Update()
    {
        if(Die && GameInput.Jump)
            Restart();
    }

    public void PlayerDie()
    {
        this.Die = true;
		playerController.Die();
		sceneController.StopRolling();
		cactusCreator.Stop();
		scoreManager.StopScoring();
		gameoverUI.SetActive(true);
	}

	public void Restart()
	{
		SceneManager.LoadScene(0);
	}
}
