using Hue.Managers.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hue.Managers
{
    public class ApiRequestManager : IApiRequestManager
    {
        public string PerformGetRequest(Uri uri, string endpoint)
        {
            try
            {
                var response = string.Empty;

                using (var client = new WebClient())
                {
                    client.BaseAddress = $"{uri}/{endpoint}";
                    response = client.DownloadString(client.BaseAddress);
                }

                return response;
            }
            catch (Exception)
            {

                throw new InvalidOperationException("You need to provide a endpoint");
            }
        }

        public string PerformGetRequestWithParameter(Uri uri, string endpoint, string parameter)
        {
            try
            {
                var response = string.Empty;

                using (var client = new WebClient())
                {
                    client.BaseAddress = $"{uri}/{endpoint}/{parameter}";
                    response = client.DownloadString(client.BaseAddress);
                }

                return response;
            }
            catch (Exception)
            {

                throw new InvalidOperationException("You need to provide a endpoint");
            }
        }

        public string PerformPutRequest(Uri uri, string endpoint, string parameter, object body)
        {
            var json = JsonConvert.SerializeObject(body);
            try
            {
                
                using (var client = new WebClient())
                {
                    client.BaseAddress = $"{uri}/{endpoint}/{parameter}";
                    var response = client.UploadString(client.BaseAddress, "PUT", json);
                    return response;
                }
                

            }
            catch (Exception)
            {

                throw new InvalidOperationException("You need to provide a endpoint");
            }
        }
    }
}
