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
using System.Globalization;

namespace Microsoft.Azure.Commands.Sql.Services
{
    public class Util
    {
        /// <summary>
        /// Generates a client side tracing Id of the format:
        /// [Guid]-[Time in UTC]
        /// </summary>
        /// <returns>A string representation of the client side tracing Id.</returns>
        public static string GenerateTracingId()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}-{1}",
                Guid.NewGuid().ToString(),
                DateTime.UtcNow.ToString("u"));
        }
    }
}
