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

namespace Microsoft.Azure.PowerShell.Share
{
    /// <summary>
    /// Static class containing variables shared across assemblies
    /// </summary>
    public static class SharedVariable
    {
        private static volatile string _predictorCorrelationId;

        /// <summary>
        /// Id should be populated by Az.Tools.Predictor and recorded by AzPS cmdlet telemetry. Once it is recorded, value of id will be cleaned.
        /// </summary>
        public static string PredictorCorrelationId 
        { 
            get 
            {
                return _predictorCorrelationId;
            } 
            set
            {
                _predictorCorrelationId = value;
            }
        }
    }
}
