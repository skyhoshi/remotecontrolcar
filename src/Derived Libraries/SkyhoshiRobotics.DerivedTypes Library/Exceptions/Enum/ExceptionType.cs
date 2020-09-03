namespace SkyhoshiRobotics.Exceptions.Enum
{
    public enum ExceptionType
    {
        MotorPositionChannelsAreNull,
        MotorControllerCannotControlMoreThanFourMotors,
        MotorControllerCannotControlMoreThanTwoMotors,
        MotorControllerMustHaveAtLeastOneMotorAssigned,
        MotorControllerMustHaveOneMotorAssignedToAComponentChannel,
        MotorControllerMustHaveAtLeastOneFunctionControllerWithPurposeAsMotorControlAssigned,
        MotorMustHaveGroundPinAssigned,
        MotorMustHaveDrivePinAssigned,
        MotorPositionIsNotAssigned,
        MotorPositionMustHaveAName
    }
}