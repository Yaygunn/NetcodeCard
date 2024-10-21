using UnityEngine;

namespace Yaygun
{
	public class EnemyCardHand : MonoBehaviour
	{
        [SerializeField] private GameObject[] _cards;

        private void Start()
        {
            EventHub.Ev_CharacterCardChangeState += OnCharacterPlayedCard;
            EventHub.Ev_StartPlayTime += PlaceCardsOnHand;
        }

        private void OnCharacterPlayedCard(int player, int playedEnum)
        {
            if (player != PlayerData.Instance.EnemyIndex)
                return;

            switch(playedEnum)
            {
                case 0:
                    PlaceCardsOnHand();
                    break;
                case 1:
                    PlaceCardOnMap();
                    break;
                case 2:
                    HideCards();
                    break;
            }

        }

        private void PlaceCardOnMap()
        {
            _cards[0].SetActive(false);
            _cards[1].SetActive(true);
            _cards[2].SetActive(true);
        }

        private void PlaceCardsOnHand()
        {
            _cards[0].SetActive(true);
            _cards[1].SetActive(true);
            _cards[2].SetActive(false);
        }

        private void HideCards()
        {
            _cards[0].SetActive(false);
            _cards[1].SetActive(false);
            _cards[2].SetActive(false);
        }
       
    }
}
