using System.Collections.Generic;
using System.Device.Gpio;
using System.Linq;
using System.Threading;
using SkyhoshiRobotics.Controller.Enums;
using SkyhoshiRobotics.Device.Component;
using SkyhoshiRobotics.Device.Motor;
using SkyhoshiRobotics.Exceptions.Enum;
using SkyhoshiRobotics.IRobot;
using SkyhoshiRobotics.IRobot.IControllers;
using SkyhoshiRobotics.IRobot.IFunctions;

namespace SkyhoshiRobotics.Drivers.Motor
{
    public class L298N : IVehicle, IMotorController
    {
        public IList<IController> FunctionControllers { get; set; }

        public IController PrimaryGpioController
        {
            get { return FunctionControllers.Single(fc => fc.Purpose == ControllerPurpose.MotorControl); }
            set
            {
                if (FunctionControllers.Any(fc => fc.Purpose == ControllerPurpose.MotorControl))
                {
                    FunctionControllers.Remove(FunctionControllers.Single(fc => fc.Purpose == ControllerPurpose.MotorControl));
                }
                FunctionControllers.Add(value);
            }
        }

        public IList<IMotor> Motors { get; set; }
        public IList<PinValuePair> ReferablePinPairs { get; set; }
        public IList<PinValuePair> EnablePinPairs { get; set; }
        public IList<PinValuePair> DrivePinPairs { get; set; }

        public ComponentChannel ChannelAlphaId { get; set; }
        public ComponentChannel ChannelBetaId { get; set; }

        public IList<IMotor> ChannelA => Motors.Where(m => m.MotorPositions.PositionChannel.ChannelId == this.ChannelAlphaId.ChannelId).ToList();

        public IList<IMotor> ChannelB => Motors.Where(m => m.MotorPositions.PositionChannel.ChannelId == this.ChannelBetaId.ChannelId).ToList();

        public L298N()
        {
            InitL298N();
        }

        public L298N(IController controller)
        {
            InitL298N(controller);
        }
        public L298N(IList<IMotor> motors)
        {
            InitL298N(Motors: motors);
        }

        private void InitL298N(IController Controller = null, IList<IMotorControllerChannel> ComponentChannels = null, IList<IMotor> Motors = null)
        {
            this.Motors = new List<IMotor>();
            this.FunctionControllers = new List<IController>();
            this.FunctionControllers.Add(Controller);
            if (Motors != null)
            {
                //if Motors have > 2 channels, throw an error
                if (Motors.All(m => m.MotorPositions.PositionChannel != null))
                {
                    throw new L298NException(ExceptionType.MotorPositionChannelsAreNull);
                }

                if (Motors.Count > 4)
                {
                    throw new L298NException(ExceptionType.MotorControllerCannotControlMoreThanFourMotors);
                }

                foreach (IMotor motor in Motors)
                {
                    motor.ValidateMotor(this.PrimaryGpioController);
                    this.Motors.Add(motor);
                }
            }
        }

        public void ValidateController()
        {
            //Check to ensure a General Purpose IO Controller has been Initalized.
            if (!FunctionControllers.Any())
            {
                throw new L298NException(ExceptionType.MotorControllerMustHaveAtLeastOneFunctionControllerWithPurposeAsMotorControlAssigned);
            }

            //Check if one Motor exists
            if (!this.Motors.Any())
            {
                throw new L298NException(ExceptionType.MotorControllerMustHaveAtLeastOneMotorAssigned);
            }

            //Check if Motor(s) are valid
            foreach (IMotor motor in this.Motors)
            {
                motor.ValidateMotor(this.PrimaryGpioController);
            }

            //ChannelA must have an Assignment
            if (!this.ChannelA.Any() && !this.ChannelB.Any())
            {
                throw new L298NException(ExceptionType.MotorControllerMustHaveOneMotorAssignedToAComponentChannel);
            }

        }
    }
}
