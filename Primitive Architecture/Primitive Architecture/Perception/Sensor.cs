namespace Primitive_Architecture.Perception {
  abstract class Sensor {

    private bool enabled;
    private SensorInput lastInput;

    public abstract SensorInput Sense();
  }
}
