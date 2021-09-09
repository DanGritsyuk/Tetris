using System;
using System.Drawing;
using System.Windows.Forms;

//using SharpDX.XInput;

namespace Tetris
{
    public partial class GameForm : Form
    {
        Gameplay game = null;

        //Keyboard
        KeyboardControllerSettings keyboardSettings = new KeyboardControllerSettings();
        Keys key = Keys.None;


        private GameTimer controllerTimer;

        //Gamepad
        //private System.Threading.Timer tmrCheckStatusBattery;
        //private System.Threading.Timer tmrCheckGamepadButtons;
        //private static Controller controller;
        //private State stateNew;
        //private State stateOld;
        //private bool onController = false;

        /// <summary>
        /// Инициализируем форму
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
            Setup();
        }

        private void Setup()
        {
            //LoadController();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (game != null) { StopGame(); }
            else { btnPause.Enabled = true; }
            StartGame();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) => key = e.KeyCode;

        private void Form1_KeyUp(object sender, KeyEventArgs e) => key = Keys.None;

        private void StartGame()
        {
            if (!ptbNextShape.Visible) ptbNextShape.Visible = true;
            ptbField.Focus();

            game = new Gameplay();
            TickTimer.Start();
            controllerTimer = new GameTimer(CheckKeyboardtStatus);
        }

        private void StopGame()
        {
            TickTimer.Stop();
            game.Dispose();
        }

        private void TickTimer_Tick(object sender, EventArgs e)
        {
            game.Tick();
            ptbNextShape.Image = game.FillNextShape();
            ptbField.Image = game.FillField();
            lblLevelValue.Text = game.GetLevel().ToString();
            lblScoreValue.Text = game.GetScore().ToString();
            TickTimer.Interval = game.GetGameSpeed();
        }

        private void CheckKeyboardtStatus()
        {
            var gameKey = GameController.GameControllerAction(key, keyboardSettings);
            if (gameKey != null) 
            { 
                game.KeyDown(gameKey.Value);
                ptbField.Image = game.FillField();
            }
        }

        #region XBox gamepad
        /*
        private void LoadController()
        {
            controller = new Controller(UserIndex.One);
            if (controller.IsConnected)
            {
                onController = true;
                GamepudPanel.Visible = true;
                tmrCheckStatusBattery = new System.Threading.Timer(_ => CheckBatteryStatus(), null, 0, 1000);
                //tmrCheckGamepadButtons = new System.Threading.Timer(_ => CheckGamepadButtons(), null, 0, 50);
            }
        }

        private void CheckBatteryStatus()
        {
            var gpdBattery = controller.GetBatteryInformation(BatteryDeviceType.Gamepad);

            switch (gpdBattery.BatteryLevel)
            {
                case BatteryLevel.Empty:
                    {
                        if (gpdBattery.BatteryType == BatteryType.Wired)
                        {
                            DisplayBatteryData("");
                        }
                        else if (gpdBattery.BatteryType == BatteryType.Nimh)
                        {
                            DisplayBatteryData("");
                            lblBtrType.Visible = !lblBtrType.Visible;
                        }
                        else if (gpdBattery.BatteryType == BatteryType.Alkaline)
                        {
                            DisplayBatteryData("");
                            lblBtrType.Visible = !lblBtrType.Visible;
                        }


                        break;
                    }
                case BatteryLevel.Low:
                    {
                        if (gpdBattery.BatteryType == BatteryType.Wired)
                        { DisplayBatteryData(""); }
                        else if (gpdBattery.BatteryType == BatteryType.Nimh)
                        { DisplayBatteryData(""); }
                        else
                        { lblBtrType.ForeColor = Color.Black; }

                        if (gpdBattery.BatteryType == BatteryType.Alkaline)
                        { DisplayBatteryData(""); }
                        break;
                    }
                case BatteryLevel.Medium:
                    {
                        if (gpdBattery.BatteryType == BatteryType.Wired)
                        { DisplayBatteryData(""); }
                        else if (gpdBattery.BatteryType == BatteryType.Nimh)
                        { DisplayBatteryData(""); }
                        else if (gpdBattery.BatteryType == BatteryType.Alkaline)
                        { DisplayBatteryData(""); }
                        break;
                    }
                case BatteryLevel.Full:
                    {
                        if (gpdBattery.BatteryType == BatteryType.Wired)
                        { DisplayBatteryData(""); }
                        else if (gpdBattery.BatteryType == BatteryType.Nimh)
                        { DisplayBatteryData(""); }
                        else if (gpdBattery.BatteryType == BatteryType.Alkaline)
                        { DisplayBatteryData(""); }
                        break;
                    }
            }
        }

        private void DisplayBatteryData(string btrCheck)
        {
            lblBtrType.Text = btrCheck;
        }

        private void CheckGamepadButtons()
        {
            stateOld = stateNew;
            stateNew = controller.GetState();

            //switch (stateNew.Gamepad.Buttons)
            //{
            //    case GamepadButtonFlags.DPadLeft: if (!pause) Move(-1, 0); break;
            //    case GamepadButtonFlags.DPadRight: if (!pause) Move(1, 0); break;
            //    case GamepadButtonFlags.X:
            //        {
            //            if (stateNew.Gamepad.Buttons != stateOld.Gamepad.Buttons) { RotateShape(); }
            //            break;
            //        }
            //    case GamepadButtonFlags.DPadDown:
            //        {
            //            if (stateNew.Gamepad.Buttons == stateOld.Gamepad.Buttons) { FastMoveDown(); }
            //            break;
            //        }
            //    case GamepadButtonFlags.Start:
            //        {
            //            if (stateNew.Gamepad.Buttons != stateOld.Gamepad.Buttons) { PauseGame(); }
            //            break;
            //        }
            //    default:
            //        {
            //            TickTimer.Interval = gameSpeed;
            //            break;
            //        }
            //}
        }
        */
        #endregion

        private void btnPause_Click(object sender, EventArgs e)
        {
            game.PauseGame = !game.PauseGame;
        }
    }
}

