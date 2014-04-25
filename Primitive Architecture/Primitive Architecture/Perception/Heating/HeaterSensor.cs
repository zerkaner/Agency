namespace Primitive_Architecture.Perception.Heating {
  internal class HeaterSensor : Sensor {
    private readonly IHeaterDataSource _source;

    //TODO Prüfen, ob :base() notwendig!
    public HeaterSensor(IHeaterDataSource source) {
      _source = source;
    }

    public override SensorInput Sense() {
      return new HeaterInput(this, _source.GetHeaterValue());
    }
  }


  internal interface IHeaterDataSource {
    double GetHeaterValue();
  }
}