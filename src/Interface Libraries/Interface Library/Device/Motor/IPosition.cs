using SkyhoshiRobotics.Device.Enums;

namespace SkyhoshiRobotics.Device.Motor
{
    public interface IPosition
    {
        string PositionName { get; set; }
        IMotorControllerChannel PositionChannel { get; set; }
        PositionLocation Position { get; set; }

        bool ValidatePosition();
    }
}