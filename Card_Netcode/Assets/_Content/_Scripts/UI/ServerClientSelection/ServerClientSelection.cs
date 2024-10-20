using Unity.Netcode;
using UnityEngine;

namespace Yaygun
{
	public class ServerClientSelection : MonoBehaviour
	{
        [SerializeField] private GameObject _selectionPanel;
        private void Start()
        {
            ShowPanel(true);
        }

        public void Host()
        {
            ShowPanel(false);
            NetworkManager.Singleton.StartHost();
        }

        public void Client()
        {
            ShowPanel(false);
            NetworkManager.Singleton.StartClient();
        }

        private void ShowPanel(bool show)
        {
            _selectionPanel.SetActive(show);
        }
    }
}
