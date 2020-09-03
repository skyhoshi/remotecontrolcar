using System;
using System.Net.Http;
using SkyhoshiRobotics.Device.Enums;
using SkyhoshiRobotics.Device.Motor;
using SkyhoshiRobotics.Exceptions.Enum;

namespace SkyhoshiRobotics.Drivers.Motor
{
    public class MotorPosition : IPosition
    {
        public string PositionName { get; set; }
        public IMotorControllerChannel PositionChannel { get; set; }
        public PositionLocation Position { get; set; }
        public bool ValidatePosition()
        {
            if (string.IsNullOrWhiteSpace(PositionName))
            {
                throw new MotorPositionException(ExceptionType.MotorPositionMustHaveAName);
            }

            if (PositionChannel == null)
            {
                throw new MotorPositionException(ExceptionType.MotorPositionChannelsAreNull);
            }

            return true;
        }

        public MotorPosition()
        {
                    
        }

        public MotorPosition(string positionName, PositionLocation positionLocation)
        {
            this.Position = positionLocation;
            this.PositionName = positionName;
        }
    }

    public class MotorPositionException : Exception
    {
        public MotorPositionException(ExceptionType exType)
        {
            switch (exType)
            {
                case ExceptionType.MotorPositionChannelsAreNull:
                    break;
                case ExceptionType.MotorPositionIsNotAssigned:
                    break;
                case ExceptionType.MotorPositionMustHaveAName:
                    break;
            }
        }

        private string message = "";
        public override string Message => message;
    }
}