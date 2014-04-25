using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primitive_Architecture.Perception {
  class GenericSensor : Sensor {

    public int DataType { get; private set; }
    private IDataSource _source;

    public GenericSensor(IDataSource source, int dataType) {
      _source = source;
      DataType = dataType;
    }


    public override SensorInput Sense() {
      return null; //TODO _source.GetData(DataType);
    }
  }


  internal interface IDataSource {
    Object GetData(int dataType);
  }
}
