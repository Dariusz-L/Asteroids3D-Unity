using Core.Controllers;
using Core.Objects;
using Game.Objects.Bullets;
using Game.Scripts;
using UnityEngine;

namespace Game.Controllers.Players.Bullets
{
    public class BulletsController : UnityObject, IController
    {
        private const float LIFE_TIME_LIMIT = 1.0f;
        private const float BULLET_SPEED = 50f;

        private Pool<Bullet> _bulletsPool;
        private Transform _owner;

        public BulletsController(Transform owner) {
            _owner = owner;

            go = new GameObject("BulletsPool");

            APrefabs prefabs = GameObject.FindObjectOfType<APrefabs>();
            _bulletsPool = new Pool<Bullet>(prefabs.PLAYER_BOLT, 10, transform);

        }

        public void Shoot() {
            Bullet bullet = _bulletsPool.GetNext();
            GameObject go = bullet.go;

            bullet.collider.enabled = true;
            bullet.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = true;

            bullet.transform.position = _owner.position;

            Vector3 angles = bullet.transform.eulerAngles;
            angles.y = _owner.eulerAngles.y;
            bullet.transform.Rotate(angles);

            bullet.rb.velocity = bullet.transform.forward * BULLET_SPEED;
        }

        public void Update() {
            foreach (Bullet b in _bulletsPool.activeObjects) {
                b.Update();
            }

            for (int i = _bulletsPool.activeObjects.Count - 1; i >= 0; i--) {
                Bullet b = _bulletsPool.activeObjects[i];
                if (b.lifeTime >= LIFE_TIME_LIMIT) {
                    b.Reset();
                    _bulletsPool.DisableObject(b);
                }
            }
        }

        public void Reset() {
            _bulletsPool.Reset();
        }
    }
}