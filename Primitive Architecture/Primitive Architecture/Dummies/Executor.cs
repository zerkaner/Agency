using System;
using System.Collections.Generic;
using Primitive_Architecture.Agents;
using Primitive_Architecture.Interfaces;

namespace Primitive_Architecture.Dummies {
  internal class Executor {
    private readonly List<ITickClient> _clients;

    private Executor() {
      var environment = new TempEnvironment();
      var heater = new Heater(environment);
      var contrl = new TempAgent(environment, heater);
      var smith = new AgentSmith(environment);
      _clients = new List<ITickClient> {environment, contrl, heater, smith};
    }


    private void Run() {
      var input = "";
      while (input != "q") {
        foreach (var client in _clients) {
          client.Tick();
        }
        input = Console.ReadLine();
      }
    }


    public static void Main() {
      new Executor().Run();
      Console.ReadLine();
    }
  }
}