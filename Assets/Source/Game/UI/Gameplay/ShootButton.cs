using Core.UI;
using Core.Utils;
using Game.Controllers;
using Game.Controllers.Players;
using Game.Scenes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Gameplay
{
    public class ShootButton : UiButton
    {
        private PlayerController _playerController;

        public ShootButton() {
            go = GameObject.Find("ShootButton");
            _playerController = GetUtil.GetObjectController<AGameController>().playerController;
        }

        protected override void OnPointerClick(PointerEventData data) {
            _playerController.bulletsController.Shoot();
        }
    }
}
