using Core.Scripts.Collisions;
using UnityEngine;

namespace Game.Controllers.Asteroids
{
    public class AsteroidCollisionController
    {
        public bool crash { get; set; }
        public bool collidingWithAnotherAsteroid { get; private set; }

        private OnTriggerStayScript _onTriggerStayScript;
        private OnTriggerExitScript _onTriggerExitScript;

        public void Init(GameObject go) {
            _onTriggerStayScript = go.AddComponent<OnTriggerStayScript>();
            _onTriggerStayScript.method = OnTriggerStay;

            _onTriggerExitScript = go.AddComponent<OnTriggerExitScript>();
            _onTriggerExitScript.method = OnTriggerExit;
        }

        public void OnTriggerStay(Collider other) {
            if (other.tag == "PlayerBullet") {
                crash = true;
                other.enabled = false;
                other.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            }

            if (other.tag == "Asteroid") {
                collidingWithAnotherAsteroid = true;
            }
        }

        public void OnTriggerExit(Collider other) {
            if (other.tag == "Asteroid") {
                collidingWithAnotherAsteroid = false;
            }
        }
    }
}