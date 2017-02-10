using Core.Objects;
using Game.Objects.Asteroids;
using Game.Scenes;
using UnityEngine;

namespace Game.Controllers.Asteroids
{
    public class AsteroidSpawner
    {
        public const float VELOCITY_RANGE = 6.0f;
        public const float ROT_RANGE = 1.0f;
        public const int ON_CRASHED_ASTEROID_AMOUNT = 4;

        public void OnLevelStartSpawn(Pool<Asteroid> asteroidsPool) {
            for (int i = 0; i < GameScene.ASTEROIDS_COUNT; i++) {
                Vector3 vel = GetRandomVelocity();
                Vector3 rot = GetRandomRotation();
                Vector3 pos = GetRandomPosition();

                Asteroid asteroid = asteroidsPool.GetNext();
                asteroid.Init(AsteroidSize.LARGE, pos, vel, rot);
            }
        }

        public void OnAsteroidCrashedSpawn(Asteroid crashedAsteroid, Pool<Asteroid> asteroidsPool) {
            switch (crashedAsteroid.size) {
                case AsteroidSize.LARGE:
                    for (int i = 0; i < ON_CRASHED_ASTEROID_AMOUNT; i++) {
                        Asteroid a = asteroidsPool.GetNext();

                        a.Init(
                            AsteroidSize.MEDIUM, 
                            crashedAsteroid.transform.position,
                            GetRandomVelocity(),
                            GetRandomRotation()
                            );
                    }
                    break;

                case AsteroidSize.MEDIUM:
                    for (int i = 0; i < ON_CRASHED_ASTEROID_AMOUNT; i++) {
                        Asteroid a = asteroidsPool.GetNext();

                        a.Init(
                            AsteroidSize.SMALL,
                            crashedAsteroid.transform.position,
                            GetRandomVelocity(),
                            GetRandomRotation()
                            );
                    }
                    break;

                case AsteroidSize.SMALL:
                    break;
            }
        }

        public Vector3 GetRandomPosition() {
            Vector3 pos = new Vector3();

            pos.x = Random.Range(0, 2) == 0 ? Random.Range(-12.0f, -4f) : Random.Range(4f, 12f);
            pos.z = Random.Range(0, 2) == 0 ? Random.Range(-12.0f, -4f) : Random.Range(4f, 12f);

            return pos;
        }

        public Vector3 GetRandomVelocity() {
            Vector3 vel = new Vector3();

            vel.x = Random.Range(-VELOCITY_RANGE, VELOCITY_RANGE);
            vel.z = Random.Range(-VELOCITY_RANGE, VELOCITY_RANGE);

            return vel;
        }

        public Vector3 GetRandomRotation() {
            return new Vector3(
                Random.Range(-ROT_RANGE, ROT_RANGE),
                Random.Range(-ROT_RANGE, ROT_RANGE),
                Random.Range(-ROT_RANGE, ROT_RANGE));
        }
    }
}