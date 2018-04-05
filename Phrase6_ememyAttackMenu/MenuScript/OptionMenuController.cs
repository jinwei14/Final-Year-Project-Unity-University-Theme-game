using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenuController : MonoBehaviour
{


	//reference to the audio mixer
	public AudioMixer audioMixer;

	//reference to the drop down menu
	public Dropdown resolutionDropdown;

	//array that hold all the resolutions

	Resolution[] resolutionsArr;
	//get some infomation such as the resolution the device have
	void Start()
	{
	//fitst adject the resolution dropdown list 
		AdjectResolutionOnStart();
	}

	private void AdjectResolutionOnStart()
	{
		resolutionsArr = Screen.resolutions;

		//clear all the options before adding in
		resolutionDropdown.ClearOptions();

		List<string> optionsList = new List<string>();

		int currentResolutionindex = 0;
		for (int i = 0; i < resolutionsArr.Length; i++)
		{
			//take the width * the height of the screen
			string opt = resolutionsArr[i].width + "X" + resolutionsArr[i].height;
			//add the string into the optionList
			optionsList.Add(opt);

			if (resolutionsArr[i].width == Screen.currentResolution.width && resolutionsArr[i].height == Screen.currentResolution.height)
			{
				currentResolutionindex = i;
			}
		}
		//take list of strings into the resolution drop down list
		resolutionDropdown.AddOptions(optionsList);
		resolutionDropdown.value = currentResolutionindex;
		resolutionDropdown.RefreshShownValue();


	}

	public void SetResolution(int index)
	{
		Resolution resolution = resolutionsArr[index];
		Screen.SetResolution(resolution.width, resolution.height,Screen.fullScreen);
	}

	//set the volume
	public void SetVolume(float volume)
	{
		//display the volume value
		audioMixer.SetFloat("volume", volume);
	}

	//set the quality of the screen
	public void SetQuality(int QualityIndex)
	{
		QualitySettings.SetQualityLevel(QualityIndex);
	}

	//set the resolution of the screen
	public void SetFullscreen(bool isFull)
	{
		Screen.fullScreen = isFull;

	}
}
