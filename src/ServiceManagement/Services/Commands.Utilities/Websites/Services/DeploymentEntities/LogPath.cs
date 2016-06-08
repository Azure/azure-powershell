// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using Newtonsoft.Json;

namespace Microsoft.WindowsAzure.Commands.Utilities.Websites.Services.DeploymentEntities
{
    /// <summary>
    /// LogPath.
    /// </summary>
    public class LogPath
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public int Size { get; set; }

        [JsonProperty]
        public string MTime { get; set; }

        [JsonProperty]
        public string Mime { get; set; }

        [JsonProperty]
        public Uri Href { get; set; }
    }
}
