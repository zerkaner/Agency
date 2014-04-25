namespace Primitive_Architecture.Perception.Heating {
  internal class TempSensor : Sensor {
    private readonly ITempDataSource _source;

    //TODO Prüfen, ob :base() notwendig!
    public TempSensor(ITempDataSource source) {
      _source = source;
    }

    public override SensorInput Sense() {
      return _source.GetTempState();
    }
  }


  internal interface ITempDataSource {
    TempInput GetTempState();
  }
}