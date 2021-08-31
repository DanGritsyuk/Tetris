using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    public interface IGameControllerSettings
    {
        Dictionary<object, GameControlKeys> KeyboardSettings { get; }
    }
}
