using System;
using System.Collections.Generic;

namespace Primitive_Architecture {
  internal class Executor {
    private readonly List<Agent> _agents;
    private readonly Environment _environment;

    public Executor() {
      _environment = new TempEnvironment();
      _agents = new List<Agent> {
        new HeaterAgent((TempEnvironment) _environment),
        new AgentSmith((TempEnvironment) _environment)
      };

      Run();
    }

    private void Run() {
      var input = "";
      while (input != "q") {

        // Generate new environment data.
        _environment.Tick();

        // Execute all agents.
        foreach (var agent in _agents) {
          agent.Tick();
        }

        input = Console.ReadLine();
        //Thread.Sleep(3000);
      }
    }


    public static void Main(String[] args) {
      Console.WriteLine("Starting executor.");
      new Executor();
      Console.WriteLine("Program ended. Press <Enter> to quit.");
      Console.ReadLine();
    }
  }
}