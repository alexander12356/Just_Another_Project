using System;
using TMPro;
using UnityEngine;

namespace Just_Another_Project
{
	public class CoreGameplayUi : MonoBehaviour
	{
		public static CoreGameplayUi Instance = null;

		private int _score;

		[SerializeField] private TMP_Text _scoreText;

		public event Action OnScoreAdded;

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			_scoreText.text = $"Points: {_score}";
		}

		public void AddScore()
		{
			_score++;
			_scoreText.text = $"Points: {_score}";
			OnScoreAdded?.Invoke();
		}

		public int GetScore() => _score;
	}
}