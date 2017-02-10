using Core.UI;
using Core.Utils;
using Game.Controllers;
using Game.Objects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Gameplay.LeftDownJoystick
{
    public class RotateRightButton : UiButton
    {
        private ControlledPlayer _controlledPlayer;

        public RotateRightButton() {
            go = GameObject.Find("RightRotateButton");
            _controlledPlayer = GetUtil.GetObjectController<AGameController>().playerController.controlledPlayer;
        }

        protected override void OnPointerDown(PointerEventData data) {
            _controlledPlayer.EnableRotationRight();
        }

        protected override void OnPointerUp(PointerEventData data) {
            _controlledPlayer.DisableRotation();
        }
    }
}
