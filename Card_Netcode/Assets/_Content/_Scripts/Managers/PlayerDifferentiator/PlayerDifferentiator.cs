using UnityEngine;
using Yaygun.Utilities.Singleton;

namespace Yaygun
{
	public class PlayerDifferentiator : Singleton<PlayerDifferentiator>
	{
		[Header("CamPos")]
		[SerializeField] private Transform[] _camTransforms;

        [Header("Hands")]
        [SerializeField] private Transform _handParent;

        protected override void Initialize()
        {
            SetHandPos();
            SetCamPos();
        }

        private void SetHandPos()
        {
            if (PlayerData.Instance.PlayerIndex == 1)
                _handParent.Rotate(0, 0, 180);
        }

        private void SetCamPos()
        {
            int playerIndex = PlayerData.Instance.PlayerIndex;
            SetTransformEqualToOtherTrasnform(Camera.main.transform, _camTransforms[playerIndex]);
        }

        private void SetTransformEqualToOtherTrasnform(Transform t1, Transform t2)
        {
            t1.position = t2.position;
            t1.rotation = t2.rotation;
        }

    }
}
