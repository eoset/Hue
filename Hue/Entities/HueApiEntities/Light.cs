using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hue.Entities.HueApiEntities
{
    public class Light
    {
        public LightState State { get; set; } = new LightState();
        public string Type { get; set; }
        public string Name { get; set; }
        public string ModelId { get; set; }
        public string SwVersion { get; set; }
    }
}
