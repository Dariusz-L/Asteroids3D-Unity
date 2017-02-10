using Core.Objects;
using Game.Scripts;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Objects.Asteroids
{
    public class AsteroidPools
    {
        private int _currentPoolIndex = -1;

        public Pool<Asteroid> currentPool { get; private set; }
        public List<Pool<Asteroid>> asteroidPools { get; private set; }

        public AsteroidPools() {
            var parent = (new GameObject("AsteroidsParent")).transform;

            APrefabs prefabs = GameObject.FindObjectOfType<APrefabs>();

            asteroidPools = new List<Pool<Asteroid>>();
            asteroidPools.Add(new Pool<Asteroid>(prefabs.ASTEROID_1, 30, parent));
            asteroidPools.Add(new Pool<Asteroid>(prefabs.ASTEROID_2, 30, parent));
            asteroidPools.Add(new Pool<Asteroid>(prefabs.ASTEROID_3, 30, parent));
        }

        public Pool<Asteroid> GetAsteroidPool() {
            if (_currentPoolIndex == -1) {
                _currentPoolIndex = Random.Range(0, asteroidPools.Count);
            } else {
                _currentPoolIndex++;
                _currentPoolIndex %= asteroidPools.Count;
            }

            currentPool = asteroidPools[_currentPoolIndex];

            return currentPool;
        }
    }
}