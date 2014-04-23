using Primitive_Architecture.Interaction.Generic;

namespace Primitive_Architecture.Interaction.Manipulate {
  class ManipulateInteraction : Generic.Interaction {
    
    public ManipulateInteraction(string id, IManipulateSPI source, IManipulateTPI target)
      : base (id, source, new[] {target}) {
      
    }


    public override bool IsExecutable() {
      return true;
    }

    public override void Execute() {
      var source = (IManipulateSPI) Source;
      var target = (IManipulateTPI) Targets[0];      
      source.SetResult (target.Manipulate ("heat", 3));
    }
  }
}
