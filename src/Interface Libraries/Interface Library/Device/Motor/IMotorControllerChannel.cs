using System;

namespace SkyhoshiRobotics.Device.Motor
{
    public interface IMotorControllerChannel
    {
        Guid ChannelId { get; set; }
        string ChannelName { get; set; }
        string ChannelDescription { get; set; }

    }
}