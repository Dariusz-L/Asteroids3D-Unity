using Core.Scripts;
using Core.UI;
using UnityEngine;

namespace Game.UI.Menu
{
    public class BestScoreText : UiText
    {
        public BestScoreText() {
            go = GameObject.Find("BestScoreText");

            UnityScene scene = GameObject.FindObjectOfType<UnityScene>();
            text.text = "Best Score: " + scene.storage.BEST_SCORE;
        }
    }
}
