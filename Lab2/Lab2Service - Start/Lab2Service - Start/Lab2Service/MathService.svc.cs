﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Lab2Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MathService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MathService.svc or MathService.svc.cs at the Solution Explorer and start debugging.
    public class MathService : IMathService
    {
        public double Add(double value1, double value2)
        {
            //throw new NotImplementedException();
            return value1 + value2;
        }

        public double CircleArea(double radius)
        {
            //throw new NotImplementedException();
            return Math.Pow(radius, 2) * Math.PI;
        }

        public double Divide(double value1, double value2)
        {
            //throw new NotImplementedException();
            return value1 / value2;
        }

        public double Multiply(double value1, double value2)
        {
            //throw new NotImplementedException();
            return value1 * value2;
        }

        public double Subtract(double value1, double value2)
        {
            //throw new NotImplementedException();
            return value1 - value2;
        }
    }
}
