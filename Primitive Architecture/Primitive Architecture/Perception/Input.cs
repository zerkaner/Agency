using System;

namespace Primitive_Architecture.Perception {
  internal class Input {
    public long Timestamp { get; private set; }

    public Input() {
      Timestamp = DateTime.Now.Ticks;
    }
  }
}