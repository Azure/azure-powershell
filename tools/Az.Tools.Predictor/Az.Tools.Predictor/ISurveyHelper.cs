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

namespace Microsoft.Azure.PowerShell.Tools.AzPredictor
{
    /// <summary>
    /// An intrface to decide whether we should prompt an suvey and do so.
    /// </summary>
    internal interface ISurveyHelper
    {
        /// <summary>
        /// Indicates wheter a survey is supposed to be shown.
        /// </summary>
        public bool ShouldPromptSurvey();

        /// <summary>
        /// Shows the survey or message to take the survey.
        /// </summary>
        public void PromptSurvey();
    }
}
