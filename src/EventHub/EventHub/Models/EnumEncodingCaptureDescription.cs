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

using Microsoft.Azure.Management.EventHub.Models;
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.EventHub.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.EventHub;
    using System.Runtime;
    using System.Runtime.Serialization;

    /// <summary>
    /// Defines values for EncodingCaptureDescription.
    /// </summary>
    public enum EnumEncodingCaptureDescription
    {
        [EnumMember(Value = "Avro")]
        Avro,
        [EnumMember(Value = "AvroDeflate")]
        AvroDeflate
    }
}
