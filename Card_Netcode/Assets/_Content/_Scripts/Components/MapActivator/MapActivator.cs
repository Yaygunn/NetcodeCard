using UnityEngine;

namespace Yaygun
{
	public class MapActivator : MonoBehaviour
	{
		[SerializeField] private GameObject _map;

        private void Start()
        {
            EventHub.Ev_PlayerDataSet += OnPlayerDataSet;
        }

        private void OnPlayerDataSet()
        {
            if (_map == null)
                return;

            _map.transform.SetParent(null, false);
            _map.SetActive(true);
            _map = null;
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            EventHub.Ev_PlayerDataSet -= OnPlayerDataSet;
        }
    }
}
