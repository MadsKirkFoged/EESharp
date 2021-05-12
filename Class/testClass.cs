using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;

namespace EESharp.Class
{
    public class TestClass
    {


        //Constants can be set this way
        private Length LengthOftest = Length.FromCentimeters(10);


        //Simple calculations can be easily be return like this 
        public Area PlateConnectionCross => Area.FromCircleDiameter(LengthOftest);
        public MassFlow MassFlowFromTest => MassFlow.FromKilogramsPerSecond(10) + MassFlow.FromKilogramsPerSecond(10);



        private MassFlow massFlowFromTest1;
        public MassFlow MassFlowFromTest1
        {
            get
            {
                return massFlowFromTest1;
            }

            set
            {
                massFlowFromTest1 = value;
            }
        }





    }
}
