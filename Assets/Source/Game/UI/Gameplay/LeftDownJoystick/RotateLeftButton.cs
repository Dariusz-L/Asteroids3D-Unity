using Core.UI;
using Core.Utils;
using Game.Controllers;
using Game.Objects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Gameplay.LeftDownJoystick
{
    public class RotateLeftButton : UiButton
    {
        private ControlledPlayer _controlledPlayer;

        public RotateLeftButton() {
            go = GameObject.Find("LeftRotateButton");
            _controlledPlayer = GetUtil.GetObjectController<AGameController>().playerController.controlledPlayer;
        }

        protected override void OnPointerDown(PointerEventData data) {
            _controlledPlayer.EnableRotationLeft();
        }

        protected override void OnPointerUp(PointerEventData data) {
            _controlledPlayer.DisableRotation();
        }
    }
}
