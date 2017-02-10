using Core.Controllers;
using Core.UI;
using Game.Scripts;
using UnityEngine;

namespace Core.Scripts
{
    public abstract class UnityScene : MonoBehaviour
    {
        public Ui ui { get; protected set; }
        public GameController gameController { get; protected set; }
        public Camera mainCamera { get; protected set; }
        public Prefabs prefabs { get; protected set; }
        public Storage storage;

        protected virtual void Awake() {
            SetOptions();
        }

        protected virtual void SetOptions() {
            Application.runInBackground = true;
        }

        protected virtual void Update() {
            if (gameController != null)
                gameController.Update();

            if (ui != null)
                ui.Update();

            Debug.Log(Time.deltaTime * 1000f);
        }
    }
}