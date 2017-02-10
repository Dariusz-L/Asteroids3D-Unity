using Core.Controllers;
using Game.Controllers.Players.Bullets;
using Game.Objects;
using UnityEngine;

namespace Game.Controllers.Players
{
    public class PlayerController : IController
    {
        public ControlledPlayer controlledPlayer { get; private set; }
        public PlayerSpawner playerSpawner { get; private set; }
        public BulletsController bulletsController { get; private set; }

        public PlayerController() {
            playerSpawner = new PlayerSpawner();
            controlledPlayer = playerSpawner.SpawnControlledPlayer(Vector3.zero);

            bulletsController = new BulletsController(controlledPlayer.transform);
        }

        public void Update() {
            controlledPlayer.Update();
            bulletsController.Update();

            if (Input.GetKeyDown(KeyCode.Space)) {
                bulletsController.Shoot();
            }
        }
    }
}