using System;
using System.Device.Gpio;
using System.Diagnostics;

namespace SkyhoshiRobotics.Drivers.Motor_Controllers.crap
{
    /// <summary>
    /// The L298N dual motor driver.
    /// </summary>
    public class L298NOld
    {
        public enum MotorOutput { OneTwo, ThreeFour }

        GpioController _gpioController;
        public Motor.Motor Motor1 { get; private set; }
        public Motor.Motor Motor2 { get; private set; }
        bool _initiated;

        public L298NOld()
        {
            _gpioController = new GpioController(PinNumberingScheme.Board);
        }

        /// <summary>
        /// The L298N dual motor driver.
        /// </summary>
        /// <param name="gpioController">GpioController reference</param>
        public L298NOld(GpioController gpioController)
        {
            this._gpioController = gpioController;
            _initiated = false;
        }

        /// <summary>
        /// Initiates the L298N.
        /// </summary>
        /// <param name="in1">Directional input 1 gpio pin</param>
        /// <param name="in2">Directional input 2 gpio pin</param>
        /// <param name="in3">Directional input 3 gpio pin</param>
        /// <param name="in4">Directional input 4 gpio pin</param>
        /// <param name="ena">Speed output A gpio pin</param>
        /// <param name="enb">Speed output B gpio pin</param>
        /// <param name="en5">Enable 5V</param>
        public void Initiate(int in1, int in2, int in3 = -1, int in4 = -1, int ena = -1, int enb = -1, int en5 = -1)
        {
            try
            {
                Debug.Write($"Initiating L298N motor 1: ");
                //if (gpioController.TryOpenPin(in1, GpioSharingMode.Exclusive, out GpioPin pin, out GpioOpenStatus openStatus))
                //{
                //    if (gpioController.TryOpenPin(in2, GpioSharingMode.Exclusive, out GpioPin pin2, out GpioOpenStatus openStatus2))
                //    {
                //        Motor1 = new Motor(pin, pin2);
                //        Debug.WriteLine($"Success");
                //    }
                //    else
                //    {
                //        Debug.WriteLine($"Fail");
                //    }
                //}
                //else
                //    Debug.WriteLine($"Fail");
                //
                //if (in3 != -1 && in4 != -1)
                //{
                //    Debug.Write($"Initiating L298N motor 2: ");
                //    if (gpioController.TryOpenPin(in3, GpioSharingMode.Exclusive, out GpioPin pin3, out GpioOpenStatus openStatus3))
                //    {
                //        if (gpioController.TryOpenPin(in4, GpioSharingMode.Exclusive, out GpioPin pin4, out GpioOpenStatus openStatus4))
                //        {
                //            Motor2 = new Motor(pin3, pin4);
                //            Debug.WriteLine($"Success");
                //        }
                //        else
                //            Debug.WriteLine($"Fail");
                //    }
                //    else
                //    {
                //        Debug.WriteLine($"Fail");
                //    }
                //}

                _initiated = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Could not initiate the L298N. {ex}");
            }
        }
    }
}