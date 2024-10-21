using UnityEngine;

namespace Yaygun
{
	public class PlayerCardHand : MonoBehaviour
	{
        private int state = 2;

        [SerializeField] private GameObject[] _cards;

        [SerializeField] private Transform[] _poses;

        private void Start()
        {
            EventHub.Ev_CharacterCardChangeState += OnCharacterPlayedCard;
            EventHub.Ev_StartPlayTime += StartPlayTime;
        }

        private void Update()
        {
            if(state == 0)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                    PlaceCardOnMap(1);
                if (Input.GetKeyDown(KeyCode.Alpha2))
                    PlaceCardOnMap(2);
            }
            if(state == 1)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    PlayerData.Instance.PlayerNetworkController.WantToTakeBackCardServerRpc();
                }
            }
        }

        private void StartPlayTime()
        {
            state = 0;
            PlaceCardsOnHand();
        }

        private void OnCharacterPlayedCard(int player, int playedEnum)
        {
            if (player != PlayerData.Instance.PlayerIndex)
                return;

            state = playedEnum;

            switch (playedEnum)
            {
                case 0:
                    PlaceCardsOnHand();
                    break;
                case 2:
                    HideCards();
                    break;
            }

        }

        private void PlaceCardOnMap(int card)
        {
            card--;
            state = 1;
            ResetPos();
            _cards[card].transform.position = _poses[2].position;
            PlayerData.Instance.PlayerNetworkController.PlayedCardServerRpc(card);
        }

        private void PlaceCardsOnHand()
        {
            _cards[0].SetActive(true);
            _cards[1].SetActive(true);
            ResetPos();
        }

        private void HideCards()
        {
            _cards[0].SetActive(false);
            _cards[1].SetActive(false);
            _cards[2].SetActive(false);
        }

        private void ResetPos()
        {
            _cards[0].transform.position = _poses[0].position;
            _cards[1].transform.position = _poses[1].position;
        }
    }
}
