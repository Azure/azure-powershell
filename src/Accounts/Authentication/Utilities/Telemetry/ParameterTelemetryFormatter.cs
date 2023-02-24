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

namespace Microsoft.Azure.Commands.Common.Authentication.Utilities
{
    /// <inheritdoc/>
    internal class ParameterTelemetryFormatter : IParameterTelemetryFormatter
    {
        /// <inheritdoc/>
        public string FormatParameters(IDictionary<string, object> boundParameters)
        {
            return string.Join(" ",
                boundParameters.Select(pair => FormatSingleParameter(pair.Key, pair.Value)));
        }

        private string FormatSingleParameter(string name, object value)
        {
            string safeValue = string.Equals("location", name, StringComparison.InvariantCultureIgnoreCase)
                ? value.ToString()
                : "***";
            return $"-{name} {safeValue}";
        }
    }
}
