using System;

namespace Primitive_Architecture {
  internal class AgentSmith : Agent {
    private readonly TempEnvironment _room; // The room where Smith lives in.


    /// <summary>
    ///   An agent walks into a bar ...
    /// </summary>
    /// <param name="room"></param>
    public AgentSmith(TempEnvironment room) : base("Smith ") {
      _room = room;
    }


    public override void Tick() {

      // Smith really likes a breeze of fresh air every now and then ...
      var random = new Random();
      var rnd = random.Next(10);
      if (rnd > 6) {
        rnd = random.Next(10);
        _room.WindowOpen = rnd > 7;
      }

      Console.WriteLine(ToString());
    }

    protected override string ToString() {
      return "Agent: " + _id + " - Temperatur: " + String.Format("{0,4:00.0}", _room.Temperature) 
             + " °C - Fenster: " + (_room.WindowOpen ? "offen" : "geschlossen") + ".";
    }
  }
}