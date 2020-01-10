
using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime
{
    public interface IHeaderSerializable
    {
        void ReadHeaders(global::System.Net.Http.Headers.HttpResponseHeaders headers);
    }
}