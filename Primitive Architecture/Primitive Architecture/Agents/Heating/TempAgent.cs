using System;
using System.Collections.Generic;
using Primitive_Architecture.Dummies.Heating;
using Primitive_Architecture.Interaction;
using Primitive_Architecture.Perception;

namespace Primitive_Architecture.Agents.Heating {
  internal class TempAgent : Agent {
    private readonly TempEnvironment _room; // The room to heat.
    private readonly Heater _heater; // Heater used to set temperature.

    private double _lastTemp;       // The last measured temperature. Not used!
    private double _adjustment;     // Only used for status output.
    private const double TransientValue = 0.5; // Coefficient for adjustment strength.

    public double NominalTemp { get; set; }


    public TempAgent(TempEnvironment room, Heater heater, List<Sensor> sensors)
      : base("Contrl", sensors) {
      _room = room;
      _heater = heater;
      NominalTemp = 25;
    }


    //TODO Muß weg!
    public new void Tick() {
      // Get current temperature and calculate the deltas.
      var temp = _room.Temperature;
      var diffTemp = temp - _lastTemp;
      var diffNominal = NominalTemp - temp;

      // Here comes the black magic ...
      var newCtrl = _heater.CtrValue/Heater.CtrMax;   // Current setting.
      newCtrl += (TransientValue*diffNominal/NominalTemp); // Adjustment value.  
      if (newCtrl > 1) newCtrl = 1;                        //| Correction to fit
      if (newCtrl < 0) newCtrl = 0;                        //| percentage scale.
      if (_room.WindowOpen) newCtrl = 0;                   // Save the planet!
      _adjustment = newCtrl - (_heater.CtrValue/Heater.CtrMax);

      // Set heater control value and save temperature as reference for next run.
      _heater.CtrValue = newCtrl*Heater.CtrMax;
      _lastTemp = temp;
      Console.WriteLine(ToString());
    }

    protected override Plan CreatePlan() {
      throw new NotImplementedException();
    }


    protected override string ToString() {
      return "Agent: " + Id + " - Sollwert: " + String.Format("{0,4:00.0}", NominalTemp) + 
             " °C - Änderung:" + String.Format("{0,5:0.0}", _adjustment*100) + " %.";
    }
  }
}
