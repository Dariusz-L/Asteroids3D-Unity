using Core.UI;
using Core.Utils;
using Game.Controllers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Game.UI.Gameplay
{
    public class ExitToMenuButton : UiButton
    {
        private StatisticsController _statisticsController;

        public ExitToMenuButton() {
            go = GameObject.Find("ExitToMenuButton");
            _statisticsController = GetUtil.GetObjectController<AGameController>().statisticsController;
        }

        protected override void OnPointerClick(PointerEventData data) {
            _statisticsController.SaveBestScore();
            SceneManager.LoadScene("MenuScene");
        }
    }
}