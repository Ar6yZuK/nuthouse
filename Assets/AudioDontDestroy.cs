using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioDontDestroy : MonoBehaviour
{
	public static AudioSource DoorAudio { get; private set; }

	private void Awake()
	{
		if (DoorAudio is null)
		{
			DoorAudio = GetComponent<AudioSource>();
			DontDestroyOnLoad(gameObject);
		}
		else Destroy(gameObject);
	}
}