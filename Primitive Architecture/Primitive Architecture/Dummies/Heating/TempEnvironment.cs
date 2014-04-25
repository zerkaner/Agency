﻿using System;
using Primitive_Architecture.Perception.Heating;

namespace Primitive_Architecture.Dummies.Heating {
  internal class TempEnvironment : Environment, 
    IHeaterDataSource, IWindowDataSource, ITempDataSource {
    
    private const double Temp1 = 15;
    private const double Temp2 = 28;
    private const double Thermal1 = 0;
    private const double Thermal2 = 2000;
    private const double WindowInfl = 2;

    public double TempGain { set; private get; }
    public bool WindowOpen { get; set; }
    public double Temperature { get; private set; }


    public TempEnvironment() {
      Temperature = 15;
      WindowOpen = false;
      TempGain = 0;
    }


    public override void Tick() {
      // Thermal value corresponding to one degree Celsius.
      const double tempUnit = (Thermal2 - Thermal1)/(Temp2 - Temp1);

      // Environmental cool off - increased, if window is opened.
      var tempLoss = (Temperature - Temp1)*tempUnit;
      if (WindowOpen) tempLoss *= 1 + ((Temperature - Temp1)/(Temp2 - Temp1))*WindowInfl;

      // Summarize thermal gain and loss to get the new temperature.
      Temperature = Temperature + 0.5*(TempGain - tempLoss)/tempUnit;

      // Parameter, Spaces total (- = left-aligned, digits before . digits after)
      Console.WriteLine("Agent: Room   - Temperatur: " + String.Format("{0,4:00.0}", Temperature)
                        + " °C (" + (int) TempGain + " / " + (int) tempLoss +
                        ") - Fenster: " + (WindowOpen ? "offen" : "geschlossen") + ".");
    }



    public HeaterInput GetHeaterState() {
      throw new NotImplementedException();
    }

    public WindowInput GetWindowState() {
      throw new NotImplementedException();
    }

    public TempInput GetTempState() {
      throw new NotImplementedException();
    }
  }
}