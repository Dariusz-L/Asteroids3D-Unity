using Core.Scripts;
using Game.UI.Menu;

namespace Game.Scripts
{
    public class MenuScene : UnityScene
    {
        protected override void Awake() {
            base.Awake();

            ui = new MenuUi();
        }
    }
}
