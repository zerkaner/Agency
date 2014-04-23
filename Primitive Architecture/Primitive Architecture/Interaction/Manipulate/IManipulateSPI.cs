using System;
using Primitive_Architecture.Interaction.Generic;

namespace Primitive_Architecture.Interaction.Manipulate {
  interface IManipulateSPI : IGenericAPI {
    void SetResult (Object result);
  }
}
