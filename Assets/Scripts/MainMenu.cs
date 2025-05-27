using UnityEngine;
using UnityEngine.SceneManagement;

namespace Just_Another_Project.MainMenu
{
	public class MainMenu : MonoBehaviour
	{
		public void StartCoreGame()
		{
			SceneManager.LoadSceneAsync("Scene_2");
		}

		public void QuitGame()
		{
			Application.Quit();
		}
	}
}