using System;

namespace Primitive_Architecture {
  internal class TempAgent : Agent {
    private readonly TempEnvironment _room; // The room to heat.
    private readonly HeaterAgent _heater; // Heater used to set temperature.

    private double _lastTemp;       // The last measured temperature. Not used!
    private double _adjustment;     // Only used for status output.
    private const double TransientValue = 0.5; // Coefficient for adjustment strength.

    public double NominalTemp { get; set; }


    public TempAgent(TempEnvironment room, HeaterAgent heater) : base("Contrl") {
      _room = room;
      _heater = heater;
      NominalTemp = 25;
    }


    public override void Tick() {
      // Get current temperature and calculate the deltas.
      var temp = _room.Temperature;
      var diffTemp = temp - _lastTemp;
      var diffNominal = NominalTemp - temp;

      // Here comes the black magic ...
      var newCtrl = _heater.CtrValue/HeaterAgent.CtrMax;   // Current setting.
      newCtrl += (TransientValue*diffNominal/NominalTemp); // Adjustment value.  
      if (newCtrl > 1) newCtrl = 1;                        //| Correction to fit
      if (newCtrl < 0) newCtrl = 0;                        //| percentage scale.
      if (_room.WindowOpen) newCtrl = 0;                   // Save the planet!
      _adjustment = newCtrl - (_heater.CtrValue/HeaterAgent.CtrMax);

      // Set heater control value and save temperature as reference for next run.
      _heater.CtrValue = newCtrl*HeaterAgent.CtrMax;
      _lastTemp = temp;
      Console.WriteLine(ToString());
    }


    protected override string ToString() {
      return "Agent: " + _id + " - Änderung: " + (int)(_adjustment*100) + " %.";
    }
  }
}
