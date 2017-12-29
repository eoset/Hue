using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hue.Managers.Interfaces
{
    public interface IApiRequestManager
    {
        string PerformGetRequest(Uri uri);
        string PerformGetRequestWithParameter(Uri uri, string parameter);
        string PerformPutRequest(Uri uri, string endpoint, string parameter, object body);
    }
}
