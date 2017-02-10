using Core.UI;
using Core.Utils;
using Game.Controllers;
using UnityEngine;

namespace Game.UI.Gameplay
{
    public class LifesText : UiText
    {
        private StatisticsController _statisticsController;

        public LifesText() {
            go = GameObject.Find("LifesText");
            _statisticsController = GetUtil.GetObjectController<AGameController>().statisticsController;
        }

        public void Update() {
            text.text = "Lifes: " + _statisticsController.lifes;
        }
    }
}