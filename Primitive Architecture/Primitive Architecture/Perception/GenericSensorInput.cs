using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Primitive_Architecture.Perception {
  class GenericSensorInput : SensorInput {

    

    public GenericSensorInput(Sensor originSensor) : base(originSensor) {}
  }
}
