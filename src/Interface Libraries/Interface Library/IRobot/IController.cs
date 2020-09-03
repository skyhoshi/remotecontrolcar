using System.Device.Gpio;
using SkyhoshiRobotics.Controller.Enums;

namespace SkyhoshiRobotics.IRobot
{
    public interface IController
    {
        ControllerPurpose Purpose { get; set; }
        GpioController Controller { get; set; }
        string ControllerName { get; set; }
    }
}