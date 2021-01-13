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

using Microsoft.Azure.Commands.Profile.Utilities;
using System;
using System.Linq;
using System.Text.Json;

namespace Microsoft.Azure.Commands.ContainerRegistry.Models
{
    public class PSAcrToken
    {
        public readonly string token;
        public readonly DateTime exp;

        public PSAcrToken(string token)
        {
            this.token = token;

            //header, payload, signature are splitted by '.' in token
            string decodedToken = Base64UrlHelper.DecodeToString(token.Split('.')[1]);
            int unixTimeSeconds = JsonDocument.Parse(decodedToken)
                                      .RootElement
                                      .EnumerateObject()
                                      .Where(p => p.Name == "exp")
                                      .Select(p => p.Value.GetInt32())
                                      .First();

            this.exp = DateTimeOffset.FromUnixTimeSeconds(unixTimeSeconds).UtcDateTime;
        }
    }
}
