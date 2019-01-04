using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IMixcloudBooster : IDisposable
    {
        void Boost(String trackPath);
    }
}
