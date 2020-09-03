using System.Collections.Generic;
using System.Device.Gpio;

namespace SkyhoshiRobotics.IRobot.IControllers
{
    public interface IMotorController
    {
        IController PrimaryGpioController { get; set; }
        IList<PinValuePair> ReferablePinPairs { get; set; }
        IList<PinValuePair> EnablePinPairs { get; set; }
        IList<PinValuePair> DrivePinPairs { get; set; }
    }
}