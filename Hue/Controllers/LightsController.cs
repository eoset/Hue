using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hue.Entities.HueApiEntities;
using Hue.Managers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Hue.Controllers
{
    [Produces("application/json")]
    public class LightsController : Controller
    {
        private IHueApiLightsManager hueApiLightsManager;

        public LightsController(IHueApiLightsManager hueApiLightsManager)
        {
            this.hueApiLightsManager = hueApiLightsManager;
        }

        [Route("/api/lights")]
        public IActionResult Get()
        {
            var lights = this.hueApiLightsManager.GetLights();

            return Ok(lights);
        }

        [Route("/api/lights/{id}")]
        public IActionResult Get(string id)
        {
            var light = this.hueApiLightsManager.GetLight(id);

            return Ok(light);
        }

        [Route("/api/lights/{id}/on")]
        [HttpPut("{id}")]
        public IActionResult TurnOn(string id)
        {
            this.hueApiLightsManager.TurnOnLight(id);

            return Ok($"state: on");
        }

        [Route("/api/lights/{id}/off")]
        [HttpPut("{id}")]
        public IActionResult TurnOff(string id)
        {
            this.hueApiLightsManager.TurnOffLight(id);

            return Ok($"state: off");
        }
    }
}