using System;

namespace Primitive_Architecture {
  internal class TempEnvironment : Environment {
    private const double Temp1 = 15;
    private const double Temp2 = 28;
    private const double Thermal1 = 0;
    private const double Thermal2 = 2000;
    private const double WindowInfl = 1.52;

    public double TempGain { set; private get; }
    public bool WindowOpen { get; set; }
    public double Temperature { get; private set; }


    public TempEnvironment() {
      Temperature = 22;
      WindowOpen = false;
      TempGain = 0;
    }


    public override void Tick() {

      // Thermal value corresponding to one degree Celsius.
      const double tempUnit = (Thermal2 - Thermal1) / (Temp2 - Temp1);

      // Environmental cool off - increased, if window is opened.
      var tempLoss = (Temperature - Temp1)*tempUnit;
      if (WindowOpen) tempLoss *= 1 + ((Temperature - Temp1)/(Temp2 - Temp1))*WindowInfl;

      // Summarize thermal gain and loss to get the new temperature.
      Temperature = Temperature + (TempGain - tempLoss)/tempUnit;

      // Parameter, Spaces total (- = left-aligned, digits before . digits after)
      Console.WriteLine("Agent: Room   - Gain: "+(int)TempGain+" - Loss: "+(int)tempLoss);
    }

  }
}