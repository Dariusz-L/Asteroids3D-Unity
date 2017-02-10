using Core.Controllers;
using Game.Objects.Asteroids;
using Game.Scenes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Controllers
{
    public class StatisticsController : IController
    {
        public const int LARGE_CRASH_POINTS = 1;
        public const int MEDIUM_CRASH_POINTS = 2;
        public const int SMALL_CRASH_POINTS = 3;

        public int lifes { get; private set; }
        public int currentScore { get; private set; }

        public StatisticsController() {
            lifes = 5;
            currentScore = 0;
        }

        public void OnPlayerCrash() {
            lifes--;

            if (lifes <= 0) {
                SaveBestScore();
                SceneManager.LoadScene("MenuScene");
            }
        }

        public void OnFinishLevel() {
            lifes += 3;
            currentScore += 30;
        }

        public void OnAsteroidCrash(Asteroid asteroid) {
            switch (asteroid.size) { 
                case AsteroidSize.LARGE:
                    currentScore += LARGE_CRASH_POINTS;
                    break;

                case AsteroidSize.MEDIUM:
                    currentScore += MEDIUM_CRASH_POINTS;
                    break;

                case AsteroidSize.SMALL:
                    currentScore += SMALL_CRASH_POINTS;
                    break;
            }
        }

        public void Update() {
            
        }

        public void SaveBestScore() {
            GameScene scene = GameObject.FindObjectOfType<GameScene>();

            if (scene.storage.BEST_SCORE < currentScore)
                scene.storage.BEST_SCORE = currentScore;
        }
    }
}