using System;
using UnityEngine;

namespace Yaygun
{
	public static class EventHub 
	{
        #region GameRelated

        public static Action Ev_PlayerDataSet;
        public static void PlayerDataSet()
        {
            Ev_PlayerDataSet?.Invoke();
        }

        public static Action Ev_StartPlayTime;
        public static void StartPlayTime()
        {
            Ev_StartPlayTime?.Invoke();
        }

        #endregion

        #region CharacterRelated

        public static Action<int, float> Ev_HealthChanged;
        public static void HealthChanged(int player, float newRatio)
        {
            Ev_HealthChanged?.Invoke(player, newRatio);
        }

        public static Action<int, int> Ev_CharacterCardChangeState;
        public static void CharacterCardChangeState(int player, int playerEnum)
        {
            Ev_CharacterCardChangeState?.Invoke(player, playerEnum);
        }

        #endregion
    }
}
