using System.Device.Gpio;
using SkyhoshiRobotics.Device.Enums;
using SkyhoshiRobotics.IRobot;

namespace SkyhoshiRobotics.Device.Motor
{
    public interface IMotor
    {
        IPosition MotorPositions { get; set; }
        PinValuePair? DrivePin { get; set; }
        PinValuePair? GroundPin { get; set; }
        ConstantVoltage OperatingVoltage { get; set; }
        ConstantVoltage MaxVoltage { get; set; }
        bool ValidateMotor(IController gpioController);
    }
}