using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primitive_Architecture.Perception.Heating {
  class TempInput : SensorInput{
    public TempInput(Sensor originSensor) : base(originSensor) {}
  }
}
