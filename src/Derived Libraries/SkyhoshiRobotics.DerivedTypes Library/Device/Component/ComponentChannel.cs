using System;
using System.Collections.Generic;
using System.Text;
using SkyhoshiRobotics.Device.Motor;

namespace SkyhoshiRobotics.Device.Component
{
    public class ComponentChannel : IMotorControllerChannel
    {
        public Guid ChannelId { get; set; }
        public string ChannelName { get; set; }
        public string ChannelDescription { get; set; }

        public ComponentChannel()
        {
            ChannelId = Guid.NewGuid();
        }

        public ComponentChannel(string channelName)
        {
            this.ChannelName = channelName;
        }

    }
}
