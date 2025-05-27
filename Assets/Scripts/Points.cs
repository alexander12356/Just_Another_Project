using Just_Another_Project;
using UnityEngine;

namespace DefaultNamespace
{
	public class Points : MonoBehaviour
	{
		private void OnTriggerEnter2D(Collider2D other)
		{
			CoreGameplayUi.Instance.AddScore();
			Destroy(gameObject);
		}
	}
}