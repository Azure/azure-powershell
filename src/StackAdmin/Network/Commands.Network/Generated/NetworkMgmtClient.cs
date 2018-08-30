namespace Microsoft.Azure.Management.Network
{
    using System;
    using System.Net.Http;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;

    public partial class NetworkManagementClient : IAzureClient
    {
        public bool? GenerateClientRequestId
        {
            get { throw new NotImplementedException(); }

            set { throw new NotImplementedException(); }
        }
    }
}