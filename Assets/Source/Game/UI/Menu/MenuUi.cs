using Core.UI;

namespace Game.UI.Menu
{
    public class MenuUi : Ui
    {
        public PlayButton playButton { get; private set; }
        public BestScoreText bestScoreText { get; private set; }

        public MenuUi() {
            playButton = new PlayButton();
            bestScoreText = new BestScoreText();
        }
    }
}
