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

using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Azure.Management.MachineLearning.WebServices.Util;

namespace Microsoft.Azure.Commands.MachineLearning.Utilities
{
    public static class ConversionHelper
    {
        public static WebService GetAzureMLWebServiceFromJsonDefinition(string jsonDefinition)
        {
            return ModelsSerializationUtil.GetAzureMLWebServiceFromJsonDefinition(jsonDefinition);
        }

        public static string GetAzureMLWebServiceJsonDefinitionFromObject(WebService webService)
        {
            return ModelsSerializationUtil.GetAzureMLWebServiceDefinitionJsonFromObject(webService);
        }
    }
}
