using Core.UI;
using Core.Utils;
using Game.Controllers;
using Game.Objects;
using Game.Scenes;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game.UI.Gameplay.LeftDownJoystick
{
    public class MoveForwardButton : UiButton
    {
        private ControlledPlayer _controlledPlayer;
        private Vector2 _currentTapPos;
        private bool _isPointerDown;

        public MoveForwardButton() {
            go = GameObject.Find("MoveForwardButton");

            _controlledPlayer = GetUtil.GetObjectController<AGameController>().playerController.controlledPlayer;
            _currentTapPos = rectTransform.position;
        }

        public void Update() {
            if (_isPointerDown) {
                _controlledPlayer.MoveForward();
                if (_currentTapPos.x > rectTransform.offsetMax.x)
                    _controlledPlayer.RotateRight();
                else if (_currentTapPos.x < rectTransform.offsetMin.x)
                    _controlledPlayer.RotateLeft();
            }
        }

        protected override void OnPointerDrag(PointerEventData data) {
            _currentTapPos = data.position;
        }

        protected override void OnPointerDown(PointerEventData data) {
            _isPointerDown = true;
        }

        protected override void OnPointerUp(PointerEventData data) {
            _isPointerDown = false;
            _currentTapPos = rectTransform.position;
            _controlledPlayer.DisableMovingForward();
        }
    }
}