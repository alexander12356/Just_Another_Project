using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Just_Another_Project.CoreGameplay
{
	public class GameController : MonoBehaviour
	{
		[SerializeField] private int _scoreInLevel;
		[SerializeField] private CoreGameplayUi _coreGameplayUi;

		private void OnEnable()
		{
			_coreGameplayUi.OnScoreAdded += HandleScoreAdded;
		}

		private void OnDisable()
		{
			_coreGameplayUi.OnScoreAdded -= HandleScoreAdded;
		}

		private void HandleScoreAdded()
		{
			if (CoreGameplayUi.Instance.GetScore() >= _scoreInLevel)
			{
				StartCoroutine(CompleteCoroutine());
			}
		}

		private IEnumerator CompleteCoroutine()
		{
			yield return new WaitForSeconds(2f);
			SceneManager.LoadSceneAsync("Scene_1");
		}
	}
}