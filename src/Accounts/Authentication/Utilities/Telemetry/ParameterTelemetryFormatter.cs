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

using Microsoft.WindowsAzure.Commands.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Utilities
{
    /// <inheritdoc/>
    internal class ParameterTelemetryFormatter : IParameterTelemetryFormatter
    {
        /// <inheritdoc/>
        public string FormatParameters(InvocationInfo invocation)
        {
            if (invocation?.BoundParameters == null) return string.Empty;

            return string.Join(" ",
                invocation.BoundParameters.Select(pair =>
                    ShouldKeepValue(invocation, pair.Key)
                    ? FormatParameterWithValue(pair.Key, pair.Value)
                    : FormatParameterWithMaskedValue(pair.Key, pair.Value)));
        }

        private bool ShouldKeepValue(InvocationInfo invocation, string name)
        {
            return string.Equals("New-AzVM", invocation.MyCommand?.Name, StringComparison.InvariantCultureIgnoreCase)
                && string.Equals("location", name, StringComparison.InvariantCultureIgnoreCase);
        }

        private string FormatParameterWithValue(string name, object value)
        {
            return $"-{name} {value}";
        }

        private string FormatParameterWithMaskedValue(string name, object value)
        {
            return $"-{name} ***";
        }
    }
}
