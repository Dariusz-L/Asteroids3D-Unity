using Core.Objects;
using Game.Controllers.Asteroids;
using UnityEngine;

namespace Game.Objects.Asteroids
{
    public class Asteroid : PhysicalObject
    {
        public AsteroidSize size { get; private set; }
        public AsteroidCollisionController collisionController { get; private set; }

        public Asteroid() {
            collisionController = new AsteroidCollisionController();
        }

        public void Update() {
            if (collider.isTrigger && !collisionController.collidingWithAnotherAsteroid) {
                collider.isTrigger = false;
            }
        }

        public void Init(AsteroidSize size, Vector3 pos, Vector3 velocity, Vector3 angularVelocity) {
            this.size = size;
            transform.position = pos;

            rb.velocity = velocity;
            collider.isTrigger = true;
            rb.angularVelocity = angularVelocity;

            if (size == AsteroidSize.LARGE) {
                transform.localScale = new Vector3(3, 3, 3);
            } else if (size == AsteroidSize.MEDIUM) {
                transform.localScale = new Vector3(1, 1, 1);
            } else if (size == AsteroidSize.SMALL) {
                transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            }
        }

        public override GameObject go {
            get {
                return base.go;
            }

            set {
                base.go = value;
                collisionController.Init(base.go);
            }
        }
    }
}