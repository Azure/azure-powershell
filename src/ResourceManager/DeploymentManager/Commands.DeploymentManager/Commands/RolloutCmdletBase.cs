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

namespace Microsoft.Azure.Commands.DeploymentManager.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Microsoft.Azure.Commands.DeploymentManager.Models;
    using Microsoft.Azure.Commands.DeploymentManager.Utilities;
    using Microsoft.Azure.Management.DeploymentManager.Models;

    public abstract class RolloutCmdletBase : DeploymentManagerBaseCmdlet
    {
        private const string FailedStatus = "Failed";

        private const int NoIndent = 0;

        private const int ServiceUnitIndentFactor = 1;

        private const int StepIndentFactor = 2;

        private const int StepPropertiesIndentFactor = 3;

        private const int ResourceOperationsIndentFactor = 4;

        protected static void PrintVerbose(string message)
        {
            Console.WriteLine(message);
        }

        protected static void PrintError(string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        protected static void PrintRollout(PSRollout rollout)
        {
            RolloutCmdletBase.PrintVerbose(RolloutCmdletBase.FormatRolloutInfoHeader(rollout));
            RolloutCmdletBase.PrintDetails(rollout);
        }

        protected static string FormatOperationInfo(PSBaseOperationInfo operationInfo, int indentFactor)
        {
            string formattedString = string.Empty;
            int indentFactorForDetails = indentFactor < int.MaxValue ? indentFactor + 1 : indentFactor; 
            if (operationInfo != null)
            {
                StringBuilder sb = new StringBuilder();

                var rolloutOperationInfo = operationInfo as PSRolloutOperationInfo;
                if (rolloutOperationInfo != null)
                {
                    sb.AppendFormatWithLeftIndentAndNewLine(indentFactorForDetails, $"Retry Attempt: {rolloutOperationInfo.RetryAttempt}");
                    sb.AppendFormatWithLeftIndentAndNewLine(indentFactorForDetails, $"Skip Succeeded: {rolloutOperationInfo.SkipSucceededOnRetry}");
                }

                var stepOperationInfo = operationInfo as PSStepOperationInfo;
                if (stepOperationInfo != null)
                {
                    sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(indentFactorForDetails, "DeploymentName", stepOperationInfo.DeploymentName);
                    sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(indentFactorForDetails, "CorrelationId", stepOperationInfo.CorrelationId);
                }

                if (operationInfo.StartTime != null)
                {
                    sb.AppendFormatWithLeftIndentAndNewLine(indentFactorForDetails, $"Start Time: {operationInfo.StartTime.Value.ToLocalTimeForUserDisplay()}");
                }

                if (operationInfo.EndTime != null)
                {
                    sb.AppendFormatWithLeftIndentAndNewLine(indentFactorForDetails, $"End Time: {operationInfo.EndTime.Value.ToLocalTimeForUserDisplay()}");

                    if (operationInfo.StartTime != null)
                    {
                        sb.AppendFormatWithLeftIndentAndNewLine(indentFactorForDetails, "Total Duration: {0}", (operationInfo.EndTime.Value - operationInfo.StartTime.Value).ToDisplayFormat());
                    }
                }

                sb.InvariantAppend(RolloutCmdletBase.FormatErrorInfo(operationInfo, indentFactorForDetails));

                formattedString = sb.ToString();
                if (!StringUtilities.IsNullOrWhiteSpace(formattedString))
                {
                    sb.Clear();
                    sb.AppendFormatWithLeftIndentAndNewLine(indentFactor, "Operation Info:");
                    formattedString = string.Concat(sb.ToString(), formattedString);
                }
            }

            return formattedString;
        }

        protected static void PrintResourceOperations(IList<PSResourceOperation> resourceOperations)
        {
            StringBuilder sb = new StringBuilder();

            if (resourceOperations != null && resourceOperations.Any())
            {
                sb.AppendFormatWithLeftIndentAndNewLine(RolloutCmdletBase.StepPropertiesIndentFactor, "Resource Operations:");
                int i = 0;
                foreach (var resourceOperation in resourceOperations)
                {
                    if (resourceOperation.ProvisioningState.Equals(RolloutCmdletBase.FailedStatus, StringComparison.OrdinalIgnoreCase))
                    {
                        RolloutCmdletBase.PrintVerbose(sb.ToString());
                        sb.Clear();
                    }

                    sb.AppendLine();
                    sb.AppendFormatWithLeftIndentAndNewLine(RolloutCmdletBase.ResourceOperationsIndentFactor, "Resource Operation {0}:", ++i);
                    sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(RolloutCmdletBase.ResourceOperationsIndentFactor, "Name", resourceOperation.ResourceName);
                    sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(RolloutCmdletBase.ResourceOperationsIndentFactor, "Type", resourceOperation.ResourceType);
                    sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(RolloutCmdletBase.ResourceOperationsIndentFactor, "ProvisioningState", resourceOperation.ProvisioningState);
                    sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(RolloutCmdletBase.ResourceOperationsIndentFactor, "StatusMessage", resourceOperation.StatusMessage);
                    sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(RolloutCmdletBase.ResourceOperationsIndentFactor, "StatusCode", resourceOperation.StatusCode);
                    sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(RolloutCmdletBase.ResourceOperationsIndentFactor, "OperationId", resourceOperation.OperationId);

                    if (resourceOperation.ProvisioningState.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        RolloutCmdletBase.PrintError(sb.ToString());
                        sb.Clear();
                    }
                }
            }

            RolloutCmdletBase.PrintVerbose(sb.ToString());
        }

        private static void PrintDetails(PSRollout rollout)
        {
            StringBuilder sb = new StringBuilder();
            if (rollout != null && rollout.Services != null)
            {
                RolloutCmdletBase.PrintServices(rollout.Services);
            }
        }

        private static void PrintServices(IList<PSService> services)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var service in services)
            {
                string location = !StringUtilities.IsNullOrWhiteSpace(service.TargetLocation)
                    ? StringUtilities.SafeInvariantFormat("TargetLocation: {0}", service.TargetLocation)
                    : string.Empty;

                string subscriptionId = service.TargetSubscriptionId != null
                    ? StringUtilities.SafeInvariantFormat("TargetSubscriptionId: {0}", service.TargetSubscriptionId)
                    : string.Empty;

                sb.AppendLine();
                sb.InvariantAppend("Service: {0} ", service.Name);
                sb.AppendFormatWithLeftIndentAndNewLine(RolloutCmdletBase.ServiceUnitIndentFactor, location);
                sb.AppendFormatWithLeftIndentAndNewLine(RolloutCmdletBase.ServiceUnitIndentFactor, subscriptionId);

                RolloutCmdletBase.PrintVerbose(sb.ToString());
                sb.Clear();

                foreach (var serviceUnit in service.ServiceUnits)
                {
                    RolloutCmdletBase.PrintServiceUnits(serviceUnit);
                }
            }
        }

        private static void PrintServiceUnits(PSServiceUnit serviceUnit)
        {
            StringBuilder sb = new StringBuilder();
            if (serviceUnit != null)
            {
                sb.AppendFormatWithLeftIndentAndNewLine(
                    RolloutCmdletBase.ServiceUnitIndentFactor,
                    $"ServiceUnit: {serviceUnit.Name}");

                sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(
                    RolloutCmdletBase.StepIndentFactor, 
                    "TargetResourceGroup", 
                    serviceUnit.TargetResourceGroup);

                foreach (var step in serviceUnit.Steps)
                {
                    if (step.Status.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        RolloutCmdletBase.PrintVerbose(sb.ToString());
                        sb.Clear();
                    }

                    sb.AppendLine();
                    sb.AppendFormatWithLeftIndentAndNewLine(RolloutCmdletBase.StepIndentFactor, $"Step: {step.Name}");
                    sb.AppendFormatWithLeftIndentAndNewLine(RolloutCmdletBase.StepPropertiesIndentFactor, $"Status: {step.Status}");

                    sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(
                        RolloutCmdletBase.StepPropertiesIndentFactor,
                        "Message",
                        RolloutCmdletBase.ActionMessagesToDisplayString(step.Messages));

                    if (step.OperationInfo != null)
                    {
                        string formatOperationInfo = RolloutCmdletBase.FormatOperationInfo(step.OperationInfo, RolloutCmdletBase.StepPropertiesIndentFactor);
                        sb.Append(formatOperationInfo);
                    }

                    if (step.Status.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        RolloutCmdletBase.PrintError(sb.ToString());
                    }
                    else
                    {
                        RolloutCmdletBase.PrintVerbose(sb.ToString());
                    }

                    sb.Clear();

                    RolloutCmdletBase.PrintResourceOperations(step.ResourceOperations);
                }
            }
        }

        private static string FormatRolloutInfoHeader(PSRollout rollout)
        {
            StringBuilder sb = new StringBuilder();
            sb.InvariantAppend($"\n\nStatus: {rollout.Status}");

            if (rollout.Status == RolloutCmdletBase.FailedStatus)
            {
                RolloutCmdletBase.PrintError(sb.ToString());
                sb.Clear();
            }

            sb.Append(RolloutCmdletBase.FormatRolloutDetails(rollout));
            sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(
                RolloutCmdletBase.NoIndent,
                "Total Retry Attempts",
                rollout.TotalRetryAttempts.HasValue && rollout.TotalRetryAttempts > 0 ? rollout.TotalRetryAttempts.Value.ToString(CultureInfo.InvariantCulture) : null);

            if (rollout.OperationInfo != null)
            {
                sb.AppendFormatWithLeftIndentAndNewLine(NoIndent, RolloutCmdletBase.FormatOperationInfo(rollout.OperationInfo, RolloutCmdletBase.NoIndent));
            }

            return sb.ToString();
        }

        private static string FormatRolloutDetails(PSRollout rollout)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(RolloutCmdletBase.NoIndent, "ArtifactSourceId", rollout.ArtifactSourceId);
            sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(RolloutCmdletBase.NoIndent, "BuildVersion", rollout.BuildVersion);
            return sb.ToString();
        }

        private static string ActionMessagesToDisplayString(IList<PSMessage> messages)
        {
            if (messages == null || messages.Count == 0)
            {
                return null;
            }

            return string.Join(
                Environment.NewLine,
                messages.Select(
                    m => StringUtilities.SafeInvariantFormat(
                        "{0}: {1}",
                        m.TimeStamp.Value.ToLocalTimeForUserDisplay(),
                        m.MessageProperty)));
        }

        private static string FormatErrorInfo(PSBaseOperationInfo operationInfo, int indentFactor)
        {
            StringBuilder sb = new StringBuilder();
            if (operationInfo != null && operationInfo.Error != null)
            {
                sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(
                    indentFactor,
                    "Error",
                    RolloutCmdletBase.AppendError(operationInfo.Error, indentFactor + 1));
                sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(
                    indentFactor + 1,
                    "Details",
                    operationInfo.Error?.Details?.ToList().Select(e =>
                        RolloutCmdletBase.AppendError(e, indentFactor + 2)).ToCommaDelimitedString());
            }

            return sb.ToString();
        }

        private static string AppendError(CloudErrorBody error, int indentFactor)
        {
            StringBuilder sb = new StringBuilder();
            if (error != null)
            {
                sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(indentFactor, "Code", error.Code);
                sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(indentFactor, "Message", error.Message);
                sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(indentFactor, "Target", error.Target);
            }

            return sb.ToString();
        }
    }
}
