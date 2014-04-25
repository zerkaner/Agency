namespace Primitive_Architecture.Perception.Heating {
  internal class WindowSensor : Sensor {
    private readonly IWindowDataSource _source;

    //TODO Prüfen, ob :base() notwendig!
    public WindowSensor(IWindowDataSource source) {
      _source = source;
    }

    public override SensorInput Sense() {
      return _source.GetWindowState();
    }
  }


  internal interface IWindowDataSource {
    WindowInput GetWindowState();
  }
}