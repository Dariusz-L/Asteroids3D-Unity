using Core.Objects;
using Core.Scripts.Collisions;
using Core.Utils;
using Game.Controllers;
using Game.Scripts;
using UnityEngine;

namespace Game.Objects
{
    public class ControlledPlayer : PhysicalObject
    {
        public const float MOVE_SPEED = 8.0f;
        public const float ROT_SPEED = 150f;

        public Pool<Particles> collisionParticlesPool { get; private set; }

        private OnCollisionEnterScript _onCollisionEnterScript;
        private OnTriggerEnterScript _onTriggerEnterScript;

        public ControlledPlayer() {
            APrefabs prefabs = GameObject.FindObjectOfType<APrefabs>();
            collisionParticlesPool = new Pool<Particles>(prefabs.PARTICLE_PLAYER_COLLISION, 5, transform);
        }

        public override GameObject go {
            get {
                return base.go;
            }

            set {
                base.go = value;

                _onCollisionEnterScript = go.AddComponent<OnCollisionEnterScript>();
                _onCollisionEnterScript.method = OnCollisionEnter;

                _onTriggerEnterScript = go.AddComponent<OnTriggerEnterScript>();
                _onTriggerEnterScript.method = OnTriggerEnter;
            }
        }

        private void OnTriggerEnter(Collider other) {
            if (other.tag == "Asteroid") {
                GetUtil.GetObjectController<AGameController>().statisticsController.OnPlayerCrash();
                collisionParticlesPool.GetNext().Play(transform.position);
            }
        }

        private void OnCollisionEnter(Collision other) {
            if (other.collider.tag == "Asteroid") {
                GetUtil.GetObjectController<AGameController>().statisticsController.OnPlayerCrash();
                collisionParticlesPool.GetNext().Play(transform.position);
            }
        }

        public void Update() {
            if (Input.GetKeyDown(KeyCode.A))
                EnableRotationLeft();
            else if (Input.GetKeyUp(KeyCode.A))
                DisableRotation();

            if (Input.GetKeyDown(KeyCode.D))
                EnableRotationRight();
            else if (Input.GetKeyUp(KeyCode.D))
                DisableRotation();

            if (Input.GetKey(KeyCode.W))
                MoveForward();
            else if (Input.GetKeyUp(KeyCode.W))
                DisableMovingForward();
        }

        public void MoveForward() {
            rb.velocity = transform.forward * MOVE_SPEED;
        }

        public void DisableMovingForward() {
            rb.velocity = Vector3.zero;
        }

        public void RotateRight() {
            transform.Rotate(new Vector3(0f, Time.deltaTime * ROT_SPEED, 0f));
        }

        public void RotateLeft() {
            transform.Rotate(new Vector3(0f, -Time.deltaTime * ROT_SPEED, 0f));
        }

        public void EnableRotationRight() {
            rb.angularVelocity = new Vector3(0f, Time.deltaTime * ROT_SPEED, 0f);
        }

        public void DisableRotation() {
            rb.angularVelocity = Vector3.zero;
        }

        public void EnableRotationLeft() {
            rb.angularVelocity = new Vector3(0f, -Time.deltaTime * ROT_SPEED, 0f);
        }
    }
}