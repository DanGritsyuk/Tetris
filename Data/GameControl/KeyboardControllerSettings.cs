using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris
{
    class KeyboardControllerSettings : IGameControllerSettings
    {
        private Dictionary<Keys, GameControlKeys> _keyboardSettings;
        public Dictionary<object, GameControlKeys> KeyboardSettings
        {
            get
            {
                var outValue = new Dictionary<object, GameControlKeys>();
                foreach (var item in this._keyboardSettings) { outValue.Add(item.Key, item.Value); }
                return outValue;
            }
        }
        public KeyboardControllerSettings()
        {
            var settings = new Dictionary<Keys, GameControlKeys>();
            var loadFromFile = new SaveLoadFile();

            try
            {
                var fileInfo = loadFromFile.DeSerializeObject<List<KeyValuePair<Keys, GameControlKeys>>>("KeyboardSettings.ini");

                settings = fileInfo.ToDictionary(item => item.Key, item => item.Value);
            }
            catch
            {
                settings.Add(Keys.None, GameControlKeys.None);
                settings.Add(Keys.W, GameControlKeys.Rotate);
                settings.Add(Keys.A, GameControlKeys.Left);
                settings.Add(Keys.S, GameControlKeys.Down);
                settings.Add(Keys.D, GameControlKeys.Rigth);
                settings.Add(Keys.Space, GameControlKeys.Pause);

                SaveKeyboardSettings(settings);
            }
            finally
            {
                this._keyboardSettings = settings;
            }

        }

        public static void SaveKeyboardSettings(Dictionary<Keys, GameControlKeys> settings)
        {
            var saveToFile = new SaveLoadFile();
            var fileInfo = new List<string[]>();

            int i = 0;
            foreach (var kvPair in settings)
            {
                fileInfo.Add(new string[] { kvPair.Key.ToString(), kvPair.Value.ToString() });
                i++;
            }

            saveToFile.SerializeObject(fileInfo, "KeyboardSettings.ini");
        }

        public static Dictionary<Keys, GameControlKeys> LoadKeyboardSettings()
        {
            throw new Exception();
        }
    }
}
