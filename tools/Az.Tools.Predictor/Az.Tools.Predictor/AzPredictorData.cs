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

using Microsoft.Azure.PowerShell.Common.Share.Survey;
using Microsoft.Azure.PowerShell.Tools.AzPredictor.Utilities;
using System;

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// The data that can be accessed from a PowerShell script.
    /// </summary>
    public static class AzPredictorData
    {
        /// <summary>
        /// Gets or sets the flag to show the survey message.
        /// </summary>
        public static volatile bool ShowSurveyOnIdle;
    }
}
