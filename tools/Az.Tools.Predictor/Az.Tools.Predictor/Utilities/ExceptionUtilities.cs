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
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Telemetry;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities
{
    /// <summary>
    /// A utilities class to provide functions around exceptions.
    /// </summary>
    internal static class ExceptionUtilities
    {
        /// <summary>
        /// Handles all exceptions and record it in the telemetry.
        /// </summary>
        public static void RecordExceptionWrapper(ITelemetryClient telemetryClient, Action action)
        {
            try
            {
                action();
            }
            catch (Exception e)
            {
                telemetryClient.OnGeneralException(new GeneralExceptionTelemetryData(e));
            }
        }
    }
}
