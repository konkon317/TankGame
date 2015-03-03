using UnityEngine;
using System.Collections;

public class BgmManager : MonoBehaviour 
{

	enum VolumeState
	{ 
		Max,
		Mute,
		TurnMax,
		TurnMute
	}

	AudioSource audioSource;

	GameController gameController;

	VolumeState state;

	[SerializeField]
	float turnTimeToMax=2;
	[SerializeField]
	float turnTimeToMute = 1f;

	[SerializeField]
	float MaxVolume = 0.8f;

	void Awake()
	{
		audioSource = GetComponent<AudioSource>();
		gameController = GameObject.FindWithTag(Tags.GameController).GetComponent<GameController>();

		audioSource.volume = 0f;
		state = VolumeState.Mute;

		gameController.SetDelegateSetUpFunc_Rady(TurnVolumeMax);
		gameController.SetDelegateSetUpFunc_GameOver(TurnVolumeMute);
	}

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (state)
		{ 
			case VolumeState.TurnMax:
				if (!audioSource.isPlaying)
				{
					audioSource.Play();
				}

				if (turnTimeToMax != 0f)
				{
					audioSource.volume += (MaxVolume / turnTimeToMax) * Time.deltaTime;
				}
				else 
				{
					audioSource.volume = 1f;
				}

				if (audioSource.volume > MaxVolume-0.01)
				{
					state = VolumeState.Max;
					audioSource.volume = MaxVolume;
				}
				
				break;

			case VolumeState.TurnMute:
				if (turnTimeToMute != 0)
				{
					audioSource.volume -= (MaxVolume / turnTimeToMute) * Time.deltaTime;
				}
				else
				{
					audioSource.volume = 0f;
				}
				if (audioSource.volume < 0f)
				{
					audioSource.volume = 0f;
					state = VolumeState.Mute;
				}
				break;

			case VolumeState.Max:
				if (!audioSource.isPlaying)
				{
					audioSource.Play();
				}
				break;

			case VolumeState.Mute:
				if (audioSource.isPlaying)
				{
					audioSource.Stop();
				}
				
				break;
		}

	
	}

	void TurnVolumeMax()
	{
		state = VolumeState.TurnMax;
	}

	void TurnVolumeMute()
	{
		state = VolumeState.TurnMute;
	}
}
