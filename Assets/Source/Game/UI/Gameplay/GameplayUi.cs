using Core.UI;
using Game.UI.Gameplay.LeftDownJoystick;
using UnityEngine;

namespace Game.UI.Gameplay
{
    public class GameplayUi : Ui
    {
        public MoveForwardButton moveForwardButton { get; private set; }
        public RotateLeftButton rotateLeftButton { get; private set; }
        public RotateRightButton rotateRightButton { get; private set; }
        public ShootButton shootButton { get; private set; }
        public ExitToMenuButton exitToMenuButton { get; private set; }

        public ScoreText scoreText { get; private set; }
        public LifesText lifesText { get; private set; }

        public GameplayUi() {
            moveForwardButton = new MoveForwardButton();
            rotateLeftButton = new RotateLeftButton();
            rotateRightButton = new RotateRightButton();
            shootButton = new ShootButton();
            exitToMenuButton = new ExitToMenuButton();

            scoreText = new ScoreText();
            lifesText = new LifesText();
        }

        public override void Update() {
            base.Update();

            moveForwardButton.Update();

            scoreText.Update();
            lifesText.Update();
        }

        public override GameObject go {
            get {
                return base.go;
            }

            set {
                base.go = value;

            }
        }
    }
}