using Core.Controllers;
using Core.Objects;
using Game.Objects.Asteroids;
using UnityEngine;

namespace Game.Controllers
{
    public class ScreenWrappingController : IController
    {
        private readonly Vector3 _minCamWorldBounds;
        private readonly Vector3 _maxCamWorldBounds;

        private AsteroidPools _asteroidPools;
        private PhysicalObject _playerToWrap;

        public ScreenWrappingController(AsteroidPools asteroidPools, PhysicalObject playerToWrap) {
            _asteroidPools = asteroidPools;
            _playerToWrap = playerToWrap;

            Camera cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

            float camY = cam.transform.position.y;
            _minCamWorldBounds = cam.ScreenToWorldPoint(new Vector3(0, 0, camY));
            _maxCamWorldBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, camY));
        }

        public void Update() {
            int count = _asteroidPools.currentPool.activeObjects.Count;
            for (int i = 0; i < count; i++) {
                GameObject go = _asteroidPools.currentPool.activeObjects[i].go;
                Check(go);
            }

            Check(_playerToWrap.go);
        }

        private void Check(GameObject go) {
            Bounds b = go.GetComponent<Collider>().bounds;
            Vector3 camMin = _minCamWorldBounds;
            Vector3 camMax = _maxCamWorldBounds;

            Vector3 oMax = b.max;
            Vector3 oMin = b.min;

            Vector3 newPos = go.transform.position;
            if (oMin.z >= camMax.z)
                newPos.z = camMin.z;
            if (oMax.z <= camMin.z)
                newPos.z = camMax.z;
            if (oMin.x >= camMax.x)
                newPos.x = camMin.x;
            if (oMax.x <= camMin.x)
                newPos.x = camMax.x;

            go.transform.position = newPos;
        }
    }
}