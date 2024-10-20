using Unity.Netcode;
using UnityEngine;

namespace Yaygun.Test
{
	public class Test1 : NetworkBehaviour
	{
        [SerializeField] private GameObject _model;
        private NetworkVariable<Vector2> _networkPosition = new NetworkVariable<Vector2>(Vector2.zero, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

        public override void OnNetworkSpawn()
        {
            _networkPosition.OnValueChanged += SetPos;
            _model = Instantiate(_model);
        }

        private void Update()
        {
            if (!IsOwner)
                return;

            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            Vector2 movement = new Vector2 (horizontalInput, verticalInput) * 3 * Time.deltaTime;

            _networkPosition.Value = (Vector2)_model.transform.position + movement;

            if (Input.GetKeyDown(KeyCode.C))
            {
                PerformActionServerRpc();
            }
        }

        [ServerRpc]
        public void PerformActionServerRpc()
        {
            //Debug.Log($"{NetworkObject.OwnerClientId} performed an action on the server.");
            Debug.Log($"{(int)OwnerClientId} performed an action on the server.");
        }
        private void SetPos(Vector2 previousValue, Vector2 newValue)
        {
            _model.transform.position = newValue;

            print("owner id : " + GetOwnerID() );
        }

        private int GetOwnerID()
        {
            return (int)OwnerClientId;
        }
    }
}
