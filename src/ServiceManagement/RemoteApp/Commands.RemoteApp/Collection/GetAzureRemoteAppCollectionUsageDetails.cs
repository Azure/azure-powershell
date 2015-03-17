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

using Microsoft.Azure.Commands.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using Microsoft.PowerShell.Commands;
using System;
using System.Collections.ObjectModel;
using System.Management.Automation;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppCollectionUsageDetails"), OutputType(typeof(string))]
    public class GetAzureRemoteAppCollectionUsageDetails : RdsCmdlet
    {
        [Parameter(
                   Position = 0,
                   Mandatory = true,
                   ValueFromPipelineByPropertyName = true,
                   HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        public string CollectionName { get; set; }

        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "Number of the month (MM) to report usage")]
        [ValidatePattern(TwoDigitMonthPattern)]
        public string UsageMonth { get; set; }

        [Parameter(Mandatory = false,
            Position = 2,
            HelpMessage = "Year (YYYY) to report usage")]
        [ValidatePattern(FullYearPattern)]
        public string UsageYear { get; set; }

        [Parameter(Mandatory = false,
            HelpMessage = "Allows to run the cmdlet in the background as a PS job.")]
        public SwitchParameter AsJob { get; set; }

        private LongRunningTask<GetAzureRemoteAppCollectionUsageDetails> task = null;

        private void GetPublishedUsageDetails(CollectionUsageDetailsResult detailsUsage)
        {
            RemoteAppOperationStatusResult operationResult = null;
            int maxRetryCount = 60;
            Collection<WebResponseObject> htmlWebResponse = null;
            string scriptBlock = "Invoke-WebRequest -Uri " + "\"" + detailsUsage.UsageDetails.SasUri + "\"";
            
            // The request is async and we have to wait for the usage details to be produced here
            do
            {

                System.Threading.Thread.Sleep(5000);

                operationResult = CallClient(() => Client.OperationResults.Get(detailsUsage.UsageDetails.OperationTrackingId), Client.OperationResults);
            }
            while (operationResult.RemoteAppOperationResult.Status != RemoteAppOperationStatus.Success &&
                operationResult.RemoteAppOperationResult.Status != RemoteAppOperationStatus.Failed &&
                --maxRetryCount > 0);

            if (operationResult.RemoteAppOperationResult.Status == RemoteAppOperationStatus.Success)
            {
                htmlWebResponse = CallPowershellWithReturnType<WebResponseObject>(scriptBlock);
                string usage = new string(System.Text.Encoding.UTF8.GetChars(htmlWebResponse[0].Content));
                WriteObject(usage);
            }
            else
            {
                if (operationResult.RemoteAppOperationResult.Status == RemoteAppOperationStatus.Failed)
                {
                    ErrorRecord error = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                        Commands_RemoteApp.DetailedUsageFailureMessage,
                        String.Empty,
                        Client.Collections,
                        ErrorCategory.ResourceUnavailable);

                    WriteError(error);
                }
                else if (maxRetryCount <= 0)
                {
                    ErrorRecord error = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                        String.Format(System.Globalization.CultureInfo.InvariantCulture,
                            Commands_RemoteApp.RequestTimedOutFormat,
                            detailsUsage.UsageDetails.OperationTrackingId),
                        String.Empty,
                        Client.Collections,
                        ErrorCategory.OperationTimeout);

                    WriteError(error);
                }
            }
        }

        public override void ExecuteCmdlet()
        {
            DateTime today = DateTime.Now;
            CollectionUsageDetailsResult detailsUsage = null;
            string locale = String.Empty;

            if (String.IsNullOrWhiteSpace(UsageMonth))
            {
                UsageMonth = today.Month.ToString();
            }

            if (String.IsNullOrWhiteSpace(UsageYear))
            {
                UsageYear = today.Year.ToString();
            }

            locale = System.Globalization.CultureInfo.CurrentCulture.ToString();

            detailsUsage = CallClient(() => Client.Collections.GetUsageDetails(CollectionName, UsageYear, UsageMonth, locale), Client.Collections);

            if (detailsUsage == null)
            {
                return;
            }

            if (AsJob.IsPresent)
            {
                task = new LongRunningTask<GetAzureRemoteAppCollectionUsageDetails>(this, "RemoteAppBackgroundTask", Commands_RemoteApp.UsageDetails);

                task.ProcessJob(() =>
                {
                    task.SetStatus(Commands_RemoteApp.DownloadingUsageDetails);
                    GetPublishedUsageDetails(detailsUsage);
                    task.SetStatus(Commands_RemoteApp.JobComplete);
                });

                WriteObject(task);

            }
            else
            {
                GetPublishedUsageDetails(detailsUsage);
            }
        }
    }
}
