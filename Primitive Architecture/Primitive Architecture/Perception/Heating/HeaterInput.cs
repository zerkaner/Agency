namespace Primitive_Architecture.Perception.Heating {
  internal class HeaterInput : SensorInput {
    public double HeatingValue { private set; get; }

    public HeaterInput(Sensor originSensor, double value) : base(originSensor) {
      HeatingValue = value;
    }
  }
}