using System;
using Primitive_Architecture.Interaction.Generic;

namespace Primitive_Architecture.Interaction.Manipulate {
  interface IManipulateTPI : IGenericAPI {

    Object Manipulate (Object key, Object value);
  }
}
