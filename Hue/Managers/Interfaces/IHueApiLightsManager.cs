using Hue.Entities.HueApiEntities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hue.Managers.Interfaces
{
    public interface IHueApiLightsManager
    {
        IDictionary<string, Light> GetLights();

        Light GetLight(string id);

        void TurnOnLight(string id);

        void TurnOffLight(string id);
    }
}
