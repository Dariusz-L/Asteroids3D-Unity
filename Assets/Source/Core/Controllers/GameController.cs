using System.Collections.Generic;

namespace Core.Controllers
{
    public class GameController : IController
    {
        public List<IController> controllers { get; private set; }

        public GameController() {
            controllers = new List<IController>();
        }

        public void Update() {
            foreach (IController c in controllers)
                c.Update();
        }
    }
}
