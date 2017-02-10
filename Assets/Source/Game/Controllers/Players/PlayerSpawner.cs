using Game.Objects;
using Game.Scripts;
using UnityEngine;

namespace Game.Controllers.Players
{
    public class PlayerSpawner
    {
        public ControlledPlayer SpawnControlledPlayer(Vector3 pos) {
            ControlledPlayer controlledPlayer = new ControlledPlayer();

            GameObject playerPrefab = GameObject.FindObjectOfType<APrefabs>().PLAYER;
            controlledPlayer.go = MonoBehaviour.Instantiate(playerPrefab, pos, Quaternion.identity) as GameObject;

            return controlledPlayer;
        }
    }
}