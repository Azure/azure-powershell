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

using System.Net;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.Simulators.Types
{
    /// <summary>
    ///     Class to represent an error that has been returned in response to a passthrough request.
    /// </summary>
    [DataContract(Namespace = "http://schemas.microsoft.com/hdinsight/2013/05/management")]
    public class ErrorDetails
    {
        [DataMember(EmitDefaultValue = false, IsRequired = true, Order = 2)]
        public string ErrorId { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = true, Order = 3)]
        public string ErrorMessage { get; set; }

        [DataMember(EmitDefaultValue = false, IsRequired = true, Order = 1)]
        public HttpStatusCode StatusCode { get; set; }
    }
}
