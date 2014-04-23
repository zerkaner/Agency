using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Primitive_Architecture.Agents {
  abstract class Sensor {

    private bool enabled;
    private SensorInput lastInput;

    public abstract SensorInput Sense();
  }
}
