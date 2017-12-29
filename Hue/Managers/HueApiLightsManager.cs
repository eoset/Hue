using Hue.Entities.HueApiEntities;
using Hue.Managers.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hue.Managers
{
    public class HueApiLightsManager : IHueApiLightsManager
    {
        private readonly IApiRequestManager apiRequestManager;

        private readonly Uri apiBaseUri = new Uri("http://192.168.1.32/api/FqPWHdQpylho6msesU1fUbhLwn6UqkgZW98jsD-b/lights");
        public HueApiLightsManager(IApiRequestManager apiRequestManager)
        {
            this.apiRequestManager = apiRequestManager;
        }

        IDictionary<string, Light> IHueApiLightsManager.GetLights()
        {
            var response = apiRequestManager.PerformGetRequest(apiBaseUri);
            var lights = JsonConvert.DeserializeObject<IDictionary<string, Light>>(response);

            return lights;
        }

        public Light GetLight(string id)
        {
            var response = apiRequestManager.PerformGetRequestWithParameter(apiBaseUri, id);
            var lights = JsonConvert.DeserializeObject<Light>(response);

            return lights;
        }

        public void TurnOnLight(string id)
        {
            var cp = new LightStatus { on = true };
            var response = apiRequestManager.PerformPutRequest(apiBaseUri, id, "state", cp);
        }

        public void TurnOffLight(string id)
        {
            var cp = new LightStatus { on = false };
            var response = apiRequestManager.PerformPutRequest(apiBaseUri, id, "state", cp);
        }

    }

    public class LightStatus
    {
        public bool on { get; set; }
    }
}
