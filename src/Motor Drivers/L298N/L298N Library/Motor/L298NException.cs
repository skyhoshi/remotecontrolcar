using System;
using SkyhoshiRobotics.Exceptions.Enum;

namespace SkyhoshiRobotics.Drivers.Motor
{
    public class L298NException : Exception
    {
        private string message = "";
        public override string Message => message;

        public L298NException(ExceptionType exType)
        {
            SetExceptionMessage(exType);
        }

        private void SetExceptionMessage(ExceptionType exType)
        {
            switch (exType)
            {
                case ExceptionType.MotorPositionChannelsAreNull:
                    message = "On this Type of controller a Motor Must be assigned a channel";
                    break;
                case ExceptionType.MotorControllerCannotControlMoreThanTwoMotors:
                    message = "This Type of Motor Controller cannot control more than 2 motors";
                    break;
                case ExceptionType.MotorControllerCannotControlMoreThanFourMotors:
                    message = "This Type of Motor Controller cannot control more than 4 motors";
                    break;
                case ExceptionType.MotorControllerMustHaveAtLeastOneMotorAssigned:
                    message = "No Motors were found. Please assign at least one motor.";
                    break;
                case ExceptionType.MotorControllerMustHaveOneMotorAssignedToAComponentChannel:
                    message = "Any Motor assigned to this controller must be assigned to either ChannelA or ChannelB. No Motor was found to be assigned to either.";
                    break;
                case ExceptionType.MotorControllerMustHaveAtLeastOneFunctionControllerWithPurposeAsMotorControlAssigned:
                    message = "A Function controller with the purpose of Motor Control Must be assigned";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(exType), exType, null);
            }
        }

    }
}