using System.Collections.Generic;
using SkyhoshiRobotics.Device.Motor;

namespace SkyhoshiRobotics.IRobot.IFunctions
{
    public interface IVehicle
    {
        IList<IMotor> Motors { get; set; }
        IList<IController> FunctionControllers { get; set; }
    }
}