using System;

namespace Primitive_Architecture {
 abstract class Agent {
    private int _cycle;
    protected readonly string _id;

    public Agent(string id) {
      _id = id;
    }


    public virtual void Tick() {
      _cycle++;

      Console.Write(ToString());
    }
   
    protected virtual new string ToString() {
      return "Agent: " + _id + "\t Cycle: " + _cycle;
    }
  }
}