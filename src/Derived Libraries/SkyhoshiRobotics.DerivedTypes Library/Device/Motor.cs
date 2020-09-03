using System;
using System.Device.Gpio;
using SkyhoshiRobotics.Device.Component;
using SkyhoshiRobotics.Device.Enums;
using SkyhoshiRobotics.Device.Motor;
using SkyhoshiRobotics.Exceptions.Enum;
using SkyhoshiRobotics.IRobot;

namespace SkyhoshiRobotics.Drivers.Motor
{
    public class Motor : IMotor
    {

        public IPosition MotorPositions { get; set; }
        public PinValuePair? DrivePin { get; set; }
        public PinValuePair? GroundPin { get; set; }
        public ConstantVoltage OperatingVoltage { get; set; }
        public ConstantVoltage MaxVoltage { get; set; }

        public bool ValidateMotor(IController gpioController)
        {
            if (this.GroundPin == null)
            {
                throw new MotorException(ExceptionType.MotorMustHaveGroundPinAssigned);
            }
            
            if (gpioController.Controller.GetPinMode(GroundPin.Value.PinNumber) != PinMode.Output)
            {

            }

            if (this.DrivePin == null)
            {
                throw new MotorException(ExceptionType.MotorMustHaveDrivePinAssigned);
            }
            
            if (gpioController.Controller.GetPinMode(DrivePin.Value.PinNumber) != PinMode.Output)
            {

            }

            if (MotorPositions == null)
            {
                throw new MotorException(ExceptionType.MotorPositionIsNotAssigned);
            }
            
            return this.MotorPositions.ValidatePosition();
        }

        public Motor()
        {

        }

        //public Motor(int drivePin, int groundPin)
        //{
        //    this.GroundPin = new PinValuePair(groundPin, PinValue.Low);
        //    this.DrivePin = new PinValuePair(drivePin, PinValue.Low);
        //}

        public Motor(int drivePin, int groundPin, IPosition motorPosition)
        {
            this.GroundPin = new PinValuePair(groundPin, PinValue.Low);
            this.DrivePin = new PinValuePair(drivePin, PinValue.Low);
            this.MotorPositions = motorPosition;
        }

        //public Motor(IPosition motorPosition)
        //{
        //    this.MotorPositions = motorPosition;
        //}

        public Motor(Guid channelId, string channelName, int drivePin, int groundPin, IPosition motorPosition)
        {
            motorPosition.PositionChannel = new ComponentChannel(channelName);
            motorPosition.PositionChannel.ChannelId = channelId;
            this.GroundPin = new PinValuePair(groundPin, PinValue.Low);
            this.DrivePin = new PinValuePair(drivePin, PinValue.Low);
            this.MotorPositions = motorPosition;
        }
    }

    public class MotorException : Exception
    {
        public MotorException(ExceptionType exType)
        {
            switch (exType)
            {
                case ExceptionType.MotorMustHaveGroundPinAssigned:
                    message = "Motor must have it's ground and drive pin assigned. Ground pin is missing";
                    break;
                case ExceptionType.MotorMustHaveDrivePinAssigned:
                    message = "Motor must have it's ground and drive pin assigned. Drive pin is missing";
                    break;
                case ExceptionType.MotorPositionIsNotAssigned:
                    message = "Motor must have it's position assigned.";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(exType), exType, null);
            }
        }

        private string message = "";
        public override string Message => message;
    }
}