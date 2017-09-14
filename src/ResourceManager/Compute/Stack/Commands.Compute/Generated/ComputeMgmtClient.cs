namespace Microsoft.Azure.Management.Compute
{
    using System;
    using System.Net.Http;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Newtonsoft.Json;

    public partial class ComputeManagementClient : IAzureClient
    {
        public bool? GenerateClientRequestId
        {
            get { return true; }

            set { throw new NotImplementedException(); }
        }
    }
}