using System;
using System.Collections.Generic;
using System.Device.Gpio;
using System.Text;
using SkyhoshiRobotics.Controller.Enums;
using SkyhoshiRobotics.IRobot;

namespace SkyhoshiRobotics.Device.Controllers
{
    public class GeneralPurposeInputOutputController : IController
    {
        public ControllerPurpose Purpose { get; set; }
        public GpioController Controller { get; set; }
        public string ControllerName { get; set; }

        public GeneralPurposeInputOutputController()
        {
            //Controller = new GpioController();
        }

        public GeneralPurposeInputOutputController(GpioController controller)
        {
            this.Controller = controller;
        }
    }
}
