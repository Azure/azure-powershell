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
    using System.Management.Automation;
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

        StringBuilder verboseBuilder = new StringBuilder();

        StringBuilder errorBuilder = new StringBuilder();

        protected void PrintError()
        {
            if (this.errorBuilder.Length > 0)
            {
                var exception = new Exception(this.errorBuilder.ToString());
                var errorRecord = new ErrorRecord(exception, "RolloutFailed", ErrorCategory.NotSpecified, null);
                this.WriteError(errorRecord);
            }
        }

        protected void PrintRollout(PSRollout rollout)
        {
            if (rollout != null)
            {
                verboseBuilder.InvariantAppend(this.FormatRolloutInfoHeader(rollout));
                this.PrintDetails(rollout);

                this.WriteVerbose(verboseBuilder.ToString());
                this.PrintError();
            }
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

                if (operationInfo?.StartTime != null && operationInfo.StartTime.HasValue)
                {
                    sb.AppendFormatWithLeftIndentAndNewLine(indentFactorForDetails, $"Start Time: {operationInfo.StartTime.Value.ToLocalTimeForUserDisplay()}");
                }

                if (operationInfo?.EndTime != null && operationInfo.EndTime.HasValue)
                {
                    sb.AppendFormatWithLeftIndentAndNewLine(indentFactorForDetails, $"End Time: {operationInfo.EndTime.Value.ToLocalTimeForUserDisplay()}");

                    if (operationInfo?.StartTime != null && operationInfo.StartTime.HasValue)
                    {
                        sb.AppendFormatWithLeftIndentAndNewLine(
                            indentFactorForDetails, 
                            "Total Duration: {0}", 
                            (operationInfo.EndTime.Value - operationInfo.StartTime.Value).ToDisplayFormat());
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

        protected void PrintResourceOperations(IList<PSResourceOperation> resourceOperations, StringBuilder eb)
        {
            StringBuilder sb = new StringBuilder();

            if (resourceOperations != null && resourceOperations.Any())
            {
                sb.AppendFormatWithLeftIndentAndNewLine(RolloutCmdletBase.StepPropertiesIndentFactor, "Resource Operations:");
                int i = 0;
                foreach (var resourceOperation in resourceOperations)
                {
                    if (resourceOperation.ProvisioningState != null && 
                        resourceOperation.ProvisioningState.Equals(RolloutCmdletBase.FailedStatus, StringComparison.OrdinalIgnoreCase))
                    {
                        verboseBuilder.InvariantAppend(sb.ToString());
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

                    if (resourceOperation.ProvisioningState != null && 
                        resourceOperation.ProvisioningState.Equals(RolloutCmdletBase.FailedStatus, StringComparison.OrdinalIgnoreCase))
                    {
                        eb.InvariantAppend(sb.ToString());
                        verboseBuilder.InvariantAppend(sb.ToString());
                        sb.Clear();
                    }
                }
            }

            verboseBuilder.InvariantAppend(sb.ToString());
        }

        private void PrintDetails(PSRollout rollout)
        {
            var sb = new StringBuilder();
            if (rollout != null && rollout.Services != null)
            {
                this.PrintServices(rollout.Services);
            }
        }

        private void PrintServices(IList<PSService> services)
        {
            var sb = new StringBuilder();
            var serviceErrors = new StringBuilder();

            foreach (var service in services)
            {
                sb.AppendLine();
                sb.AppendLine();
                sb.InvariantAppend($"Service: {service.Name}");
                sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(RolloutCmdletBase.ServiceUnitIndentFactor, "TargetLocation", service.TargetLocation);
                sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(RolloutCmdletBase.ServiceUnitIndentFactor, "TargetSubscriptionId", service.TargetSubscriptionId);

                verboseBuilder.InvariantAppend(sb.ToString());
                sb.Clear();

                serviceErrors.Clear();
                if (service.ServiceUnits != null)
                {
                    var suErrors = new StringBuilder();
                    foreach (var serviceUnit in service.ServiceUnits)
                    {
                        suErrors.Clear();
                        this.PrintServiceUnits(serviceUnit, suErrors);

                        if (suErrors.Length > 0)
                        {
                            serviceErrors.AppendLine();
                            serviceErrors.AppendFormatWithLeftIndentAndNewLine(
                                RolloutCmdletBase.ServiceUnitIndentFactor,
                                $"ServiceUnit: {serviceUnit.Name}");
                            serviceErrors.InvariantAppend(suErrors.ToString());
                        }
                    }
                }

                if (serviceErrors.Length > 0)
                {
                    this.errorBuilder.AppendLine();
                    this.errorBuilder.InvariantAppend($"Service: {service.Name}");
                    this.errorBuilder.InvariantAppend(serviceErrors.ToString());
                }
            }
        }

        private void PrintServiceUnits(PSServiceUnit serviceUnit, StringBuilder eb)
        {
            StringBuilder sb = new StringBuilder();
            if (serviceUnit != null)
            {
                sb.AppendLine();
                sb.AppendFormatWithLeftIndentAndNewLine(
                    RolloutCmdletBase.ServiceUnitIndentFactor,
                    $"ServiceUnit: {serviceUnit.Name}");

                sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(
                    RolloutCmdletBase.StepIndentFactor, 
                    "TargetResourceGroup", 
                    serviceUnit.TargetResourceGroup);

                foreach (var step in serviceUnit.Steps)
                {
                    if (step.Status != null && step.Status.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        verboseBuilder.InvariantAppend(sb.ToString());
                        sb.Clear();
                    }

                    sb.AppendLine();
                    sb.AppendFormatWithLeftIndentAndNewLine(RolloutCmdletBase.StepIndentFactor, $"Step: {step.Name}");
                    sb.AppendFormatWithLeftIndentAndNewLine(RolloutCmdletBase.StepPropertiesIndentFactor, $"Status: {step.Status}");
                    sb.AppendFormatWithLeftIndentAndNewLine(RolloutCmdletBase.StepPropertiesIndentFactor, $"StepGroup: {step.StepGroup}");

                    sb.AppendFormatWithLeftIndentAndNewLineIfNotNull(
                        RolloutCmdletBase.StepPropertiesIndentFactor,
                        "Message",
                        RolloutCmdletBase.ActionMessagesToDisplayString(step.Messages));

                    if (step.OperationInfo != null)
                    {
                        string formatOperationInfo = RolloutCmdletBase.FormatOperationInfo(step.OperationInfo, RolloutCmdletBase.StepPropertiesIndentFactor);
                        sb.Append(formatOperationInfo);
                    }

                    if (step.Status != null && step.Status.Equals("Failed", StringComparison.OrdinalIgnoreCase))
                    {
                        verboseBuilder.InvariantAppend(sb.ToString());
                        eb.InvariantAppend(sb.ToString());
                    }
                    else
                    {
                        verboseBuilder.InvariantAppend(sb.ToString());
                    }

                    sb.Clear();

                    this.PrintResourceOperations(step.ResourceOperations, eb);
                }
            }
        }

        private string FormatRolloutInfoHeader(PSRollout rollout)
        {
            StringBuilder sb = new StringBuilder();
            sb.InvariantAppend($"\n\nStatus: {rollout.Status}");

            if (rollout.Status == RolloutCmdletBase.FailedStatus)
            {
                verboseBuilder.InvariantAppend(sb.ToString());
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
                        "{0}{1}",
                        m.TimeStamp.HasValue ? $"{m.TimeStamp.Value.ToLocalTimeForUserDisplay()}: "  : string.Empty,
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
