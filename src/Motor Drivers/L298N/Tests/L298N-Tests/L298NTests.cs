using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Net;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SkyhoshiRobotics;
using SkyhoshiRobotics.Device.Component;
using SkyhoshiRobotics.Device.Controllers;
using SkyhoshiRobotics.Device.Enums;
using SkyhoshiRobotics.Device.Motor;
using SkyhoshiRobotics.Drivers.Motor;
using SkyhoshiRobotics.IRobot;

namespace L298NTests
{
    [TestClass]
    public class L298NTests
    {
        public L298N MotorController { get; set; }

        [TestInitialize]
        public void Setup()
        {
            //Enable 5V Control
            GpioController gpioController = A.Dummy<GpioController>();
            FakeItEasy.Fake.GetFakeManager(gpioController);
            var generalPurposeInputOutputController = A.Fake<GeneralPurposeInputOutputController>(options=> new GeneralPurposeInputOutputController(gpioController));
            List<IController> motorControllerInitObjects = new List<IController>() {generalPurposeInputOutputController};
            MotorController = A.Fake<L298N>(options => options.WithArgumentsForConstructor(()=> new L298N(generalPurposeInputOutputController)));
            MotorController.ChannelAlphaId = new ComponentChannel("LeftChannel");
            MotorController.ChannelBetaId = new ComponentChannel("RightChannel");
            var channelAMotor1 = GenerateMotor(MotorController.ChannelAlphaId, "FrontLeft", PositionLocation.FrontLeft);
            var channelBMotor1 = GenerateMotor(MotorController.ChannelBetaId, "FrontRight", PositionLocation.FrontRight);

            A.CallTo(() => gpioController.GetPinMode(channelAMotor1.DrivePin.Value.PinNumber)).Returns(PinMode.Output);
            
            MotorController.Motors.Add(channelAMotor1);
            MotorController.Motors.Add(channelBMotor1);
            
        }
        


        [TestMethod]
        public void Enable5VControlTest()
        {
            MotorController.ValidateController();
            
        }

        [TestMethod]
        public void TurnLeftTests()
        {

        }

        [TestMethod]
        public void TurnRightTests()
        {

        }

        [TestMethod]
        public void BackupInReverseTests()
        {

        }

        [TestMethod]
        public void ForwardTests()
        {

        }

        public Motor GenerateMotor(ComponentChannel channel, string positionName, PositionLocation positionLocation)
        {
            return GenerateMotor(channel.ChannelId, channel.ChannelName, positionName, positionLocation);
        }
        public Motor GenerateMotor(Guid channelId, string channelName,string positionName, PositionLocation positionLocation)
        {
            int drivePin = (new Random()).Next(0, 40);
            int groundPin = (new Random()).Next(0, 40);
            MotorPosition motorPosition = new MotorPosition(positionName, positionLocation);
            Motor motor = new Motor(channelId, channelName, drivePin, groundPin, motorPosition);
            return motor;
        }
    }
}
