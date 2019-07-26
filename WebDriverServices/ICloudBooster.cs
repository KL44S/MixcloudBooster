using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebDriverServices
{
    public interface ICloudBooster : IDisposable
    {
        Task Boost(string trackPath, IList<WebAction> actions);
    }
}
