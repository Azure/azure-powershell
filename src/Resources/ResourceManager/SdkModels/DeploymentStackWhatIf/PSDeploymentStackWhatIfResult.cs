// ----------------------------------------------------------------------------------
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.SdkModels.DeploymentStackWhatIf
{
    using Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters;
    using Microsoft.Azure.Management.Resources.Models;
    using Newtonsoft.Json;

    public class PSDeploymentStackWhatIfResult
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("systemData")]
        public SystemData SystemData { get; set; }

        [JsonProperty("properties")]
        public PSDeploymentStackWhatIfProperties Properties { get; set; }

        public override string ToString()
        {
            return DeploymentStackWhatIfFormatter.Format(this);
        }
    }
}
