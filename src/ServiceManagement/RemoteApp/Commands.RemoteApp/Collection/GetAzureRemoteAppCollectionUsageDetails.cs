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

using Microsoft.WindowsAzure.Commands.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.IO;
using System.Management.Automation;
using System.Net;


namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{

    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppCollectionUsageDetails"), OutputType(typeof(string))]
    public class GetAzureRemoteAppCollectionUsageDetails : RdsCmdlet
    {
        [Parameter(Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "RemoteApp collection name")]
        [ValidatePattern(NameValidatorString)]
        [Alias("Name")]
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
            HelpMessage = "Allows running the cmdlet in the background as a PS job.")]
        public SwitchParameter AsJob { get; set; }

        private LongRunningTask<GetAzureRemoteAppCollectionUsageDetails> task = null;

        private void GetUsageDetails(CollectionUsageDetailsResult detailsUsage)
        {
            RemoteAppOperationStatusResult operationResult = null;

            // The request is async and we have to wait for the usage details to be produced here
            do
            {
                System.Threading.Thread.Sleep(5000);

                operationResult = CallClient(() => Client.OperationResults.Get(detailsUsage.UsageDetails.OperationTrackingId), Client.OperationResults);
            }
            while (operationResult.RemoteAppOperationResult.Status != RemoteAppOperationStatus.Success &&
                operationResult.RemoteAppOperationResult.Status != RemoteAppOperationStatus.Failed);

            if (operationResult.RemoteAppOperationResult.Status == RemoteAppOperationStatus.Success)
            {
                WriteUsageDetails(detailsUsage);
            }
            else
            {
                ErrorRecord error = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                    Commands_RemoteApp.DetailedUsageFailureMessage,
                    String.Empty,
                    Client.Collections,
                    ErrorCategory.ResourceUnavailable);

                WriteError(error);
            }
        }

        private void WriteUsageDetails(CollectionUsageDetailsResult detailsUsage)
        {
            // 
            // Display the content pointed to by the returned URI
            //
            WebResponse response = null;

            WebRequest request = WebRequest.Create(detailsUsage.UsageDetails.SasUri);

            try
            {
                response = (HttpWebResponse)request.GetResponse();
                if (response == null)
                {
                    ErrorRecord error = RemoteAppCollectionErrorState.CreateErrorRecordFromString(
                                "Unable to retrieve Usage data", String.Empty, null, ErrorCategory.InvalidResult);
                    WriteError(error);
                    return;
                }
            }
            catch (Exception e)
            {
                ErrorRecord error = RemoteAppCollectionErrorState.CreateErrorRecordFromException(e, String.Empty, Client.Collections, ErrorCategory.InvalidResult);
                WriteError(error);
                return;
            }

            using (Stream dataStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    String csvContent = reader.ReadToEnd();
                    WriteObject(csvContent);
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
                    GetUsageDetails(detailsUsage);
                    task.SetStatus(Commands_RemoteApp.JobComplete);
                });

                WriteObject(task);

            }
            else
            {
                GetUsageDetails(detailsUsage);
            }
        }
    }
}
