using Core.Scripts;
using Core.UI;
using Core.Utils;
using Game.Controllers;
using Game.Scenes;
using UnityEngine;

namespace Game.UI.Gameplay
{
    public class ScoreText : UiText
    {
        private StatisticsController _statisticsController;

        public ScoreText() {
            go = GameObject.Find("ScoreText");
            _statisticsController = GetUtil.GetObjectController<AGameController>().statisticsController;
        }

        public void Update() {
            text.text = "Score: " + _statisticsController.currentScore;
        }
    }
}