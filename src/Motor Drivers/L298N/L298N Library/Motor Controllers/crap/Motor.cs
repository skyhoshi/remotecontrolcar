using SkyhoshiRobotics.Device.Enums;
using SkyhoshiRobotics.Drivers.Motor;

namespace SkyhoshiRobotics.Drivers.Motor_Controllers.crap
{
    /// <summary>
    /// A motor in relation to the L298N motor driver.
    /// </summary>
    public class Motor_old
    {
        private System.Device.Gpio.GpioController d;
        private System.Device.Gpio.PinValuePair enx;
        private MotorDirection direction;
        private System.Device.Gpio.PinValuePair pin1, pin2;
        private MotorState state;

        public MotorDirection Direction
        {
            get => direction;
            set
            {
                if (direction == value) return;
                direction = value;
                UpdateState();
            }
        }
        public MotorState State
        {
            get => state;
            set
            {
                if (state == value) return;
                state = value;
                UpdateState();
            }
        }

        /// <summary>
        /// A motor in relation to the L298N motor driver
        /// </summary>
        /// <param name="pin1">Reference to direction pin 1.</param>
        /// <param name="pin2">Reference to direction pin 2.</param>
        /// <param name="direction">The starting direction</param>
        /// <param name="state">The starting state</param>
        /// <param name="enx">Reference to the engage pin.</param>
        public Motor_old()
            //public Motor(GpioPin pin1, GpioPin pin2, MotorDirection direction = MotorDirection.Clockwise, MotorState state = MotorState.Off, GpioPin enx = null)
        {
            //    this.direction = direction;
            //
            //    this.enx = enx;
            //    this.enx?.Write(GpioPinValue.High);
            //    this.enx?.SetDriveMode(GpioPinDriveMode.Output);
            //
            //    this.pin1 = pin1;
            //    this.pin1?.Write(GpioPinValue.Low);
            //    this.pin1?.SetDriveMode(GpioPinDriveMode.Output);
            //
            //    this.pin2 = pin2;
            //    this.pin2?.Write(GpioPinValue.Low);
            //    this.pin2?.SetDriveMode(GpioPinDriveMode.Output);
            //
            //    State = state;
        }

        /// <summary>
        /// Flips the correct bits based on the direction and on/off state.
        /// </summary>
        void UpdateState()
        {
            //    if (state == MotorState.On)
            //    {
            //        pin1?.Write(direction == MotorDirection.Clockwise ? GpioPinValue.High : GpioPinValue.Low);
            //        pin2?.Write(direction == MotorDirection.Clockwise ? GpioPinValue.Low : GpioPinValue.High);
            //    }
            //    else
            //    {
            //        pin1?.Write(GpioPinValue.Low);
            //        pin2?.Write(GpioPinValue.Low);
            //    }
        }
    }
}