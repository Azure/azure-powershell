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

using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Common.Authentication.Utilities
{
    /// <summary>
    /// Default implementation of <see cref="IEndProcessingRecommendationService"/>
    /// which provides suggestions based on cmdlet execution.
    /// </summary>
    internal class DefaultRecommendationService : IEndProcessingRecommendationService
    {
        private readonly IEnumerable<IRecommender> _recommenders;

        public DefaultRecommendationService()
        {
            _recommenders = new List<IRecommender>()
            {
                new RegionalRecommender()
            };
        }

        /// <inheritdoc/>
        public override void Process(AzurePSCmdlet cmdlet, InvocationInfo invocation, AzurePSQoSEvent qosEvent)
        {
            foreach (var recommender in _recommenders)
            {
                try
                {
                    if (recommender.Process(invocation, qosEvent, out var recommendation))
                    {
                        WriteRecommendation(cmdlet, recommendation);
                    }
                }
                catch (Exception ex)
                {
                    // swallow exceptions as recommendations are not vital
                    cmdlet.WriteDebug($"[{nameof(DefaultRecommendationService)}] Error encountered: {ex.Message}.{Environment.NewLine}{ex.StackTrace}");
                }
            }
        }

        private void WriteRecommendation(AzurePSCmdlet cmdlet, string recommendation)
        {
            cmdlet.WriteInformation(new HostInformationMessage() { Message = recommendation }, new string[] { "PSHOST" });
        }
    }
}
