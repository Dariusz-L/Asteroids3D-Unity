using Core.Controllers;
using Core.Objects;
using Game.Objects.Asteroids;
using Game.Scripts;
using UnityEngine;

namespace Game.Controllers.Asteroids
{
    public class AsteroidController : UnityObject, IController
    {
        private StatisticsController _statisticsController;

        public AsteroidPools asteroidsPools { get; private set; }

        public Pool<Particles> explosionParticlesPool { get; private set; }
        public AsteroidSpawner asteroidSpawner { get; private set; }

        public AsteroidController(StatisticsController statisticsController) {
            _statisticsController = statisticsController;

            go = new GameObject("AsteroidsPool");

            APrefabs prefabs = GameObject.FindObjectOfType<APrefabs>();
            explosionParticlesPool = new Pool<Particles>(prefabs.PARTICLE_ASTEROID_EXPLOSION, 5);

            asteroidsPools = new AsteroidPools();
            asteroidSpawner = new AsteroidSpawner();
            asteroidSpawner.OnLevelStartSpawn(asteroidsPools.GetAsteroidPool());
        }

        public void Update() {
            for (int i = asteroidsPools.currentPool.activeObjects.Count - 1; i >= 0; i--) {
                Asteroid a = asteroidsPools.currentPool.activeObjects[i];
                a.Update();

                if (a.collisionController.crash) {
                    explosionParticlesPool.GetNext().Play(a.transform.position);

                    _statisticsController.OnAsteroidCrash(a);

                    asteroidSpawner.OnAsteroidCrashedSpawn(a, asteroidsPools.currentPool);
                    asteroidsPools.currentPool.DisableObject(a);
                    a.collisionController.crash = false;
                }
            }

            if (asteroidsPools.currentPool.activeObjects.Count == 0) {
                _statisticsController.OnFinishLevel();
                asteroidSpawner.OnLevelStartSpawn(asteroidsPools.GetAsteroidPool());
            }
        }
    }
}