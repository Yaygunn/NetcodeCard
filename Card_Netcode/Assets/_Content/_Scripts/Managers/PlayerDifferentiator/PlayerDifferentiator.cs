using UnityEngine;
using Yaygun.Utilities.Singleton;

namespace Yaygun
{
	public class PlayerDifferentiator : Singleton<PlayerDifferentiator>
	{
		[Header("CamPos")]
		[SerializeField] private Transform[] _camTransforms;

        protected override void Initialize()
        {
            SetCamPos();
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
