using UnityEngine;

public class CharacterManager : MonoBehaviour
{
	public static CharacterManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
	}
	
	private Player _player;
	public Player Player
	{
		get { return _player; }
		set { _player = value; }
	}
}