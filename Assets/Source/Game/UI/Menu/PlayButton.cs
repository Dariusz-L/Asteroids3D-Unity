using Core.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Game.UI.Menu
{
    public class PlayButton : UiButton
    {
        public PlayButton() {
            go = GameObject.Find("PlayButton");
        }

        protected override void OnPointerClick(PointerEventData data) {
            SceneManager.LoadScene("GameScene");
        }
    }
}
