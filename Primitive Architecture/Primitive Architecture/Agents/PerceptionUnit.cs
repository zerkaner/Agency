using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primitive_Architecture.Agents {
  class PerceptionUnit {

    private readonly List<Sensor> _sensors;
    private readonly Dictionary<Sensor, Input> _inputMemory;

    public PerceptionUnit(List<Sensor> sensors) {
      _sensors = sensors;
      _inputMemory = new Dictionary<Sensor, Input>();
    }


    public void SenseAll() {
      foreach (var sensor in _sensors) {
        _inputMemory [sensor] = sensor.Sense();
      }  
    }

    public Input GetData(Sensor inputType) {
      return _inputMemory[inputType];
    }


  }
}
