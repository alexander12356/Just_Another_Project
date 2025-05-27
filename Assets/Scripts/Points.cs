using DG.Tweening;
using Just_Another_Project;
using UnityEngine;

namespace DefaultNamespace
{
	public class Points : MonoBehaviour
	{
		private bool _isGetted = false;

		private void Start()
		{
			_isGetted = false;
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
			if (!_isGetted) {
				CoreGameplayUi.Instance.AddScore();

				_isGetted = true;

				transform.DORotate(new Vector3(0, 360, 0), 0.76f, RotateMode.FastBeyond360).
					SetLoops(2).OnComplete(() => Destroy(gameObject));
			}
		}
	}
}