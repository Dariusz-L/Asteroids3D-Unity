using Core.Scripts;
using Game.Controllers;
using Game.Scripts;
using Game.UI.Gameplay;
using UnityEngine;

namespace Game.Scenes
{
    public class GameScene : UnityScene
    {
        public const int ASTEROIDS_COUNT = 6;

        protected override void Awake() {
            prefabs = GameObject.Find("Prefabs").GetComponent<APrefabs>();
            mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

            MonoBehaviour.Instantiate((prefabs as APrefabs).BACKGROUND);

            gameController = new AGameController();
            ui = new GameplayUi();
        }
    }
}