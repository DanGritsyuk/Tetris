using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public static class GameController
    {
        public static GameControlKeys? GameControllerAction(object key, IGameControllerSettings gameControllerSettings)
        {
            try { return gameControllerSettings.KeyboardSettings[key]; }
            catch { return null; }
        }
    }
}
