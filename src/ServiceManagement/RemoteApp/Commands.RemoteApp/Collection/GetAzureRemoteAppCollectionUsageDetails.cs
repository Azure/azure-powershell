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
using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;

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
        public string CollectionName { get; set; }

        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "Number of the month (MM) to report usage")]
        [ValidatePattern("^(0[1-9]|1[0-2])$")]
        public string UsageMonth { get; set; }

        [Parameter(Mandatory = false,
            Position = 2,
            HelpMessage = "Year (YYYY) to report usage")]
        [ValidatePattern(@"^(19|20)\d\d$")]
        public string UsageYear { get; set; }

        public override void ExecuteCmdlet()
        {
            DateTime today = DateTime.Now;
            CollectionUsageDetailsResult detailsUsage = null;
            string locale = String.Empty;
            RemoteAppOperationStatusResult operationResult = null;
            int maxRetryCount = 600;

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

            // The request is async and we have to wait for the usage details to be produced here
            do
            {
                System.Threading.Thread.Sleep(5000);

                operationResult = CallClient(() => Client.OperationResults.Get(detailsUsage.UsageDetails.OperationTrackingId), Client.OperationResults);
            }
            while(operationResult.RemoteAppOperationResult.Status != RemoteAppOperationStatus.Success ||
                operationResult.RemoteAppOperationResult.Status != RemoteAppOperationStatus.Failed ||
                --maxRetryCount > 0);

            if (operationResult.RemoteAppOperationResult.Status == RemoteAppOperationStatus.Success)
            {
                WriteUsageDetails(detailsUsage);
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
                        Commands_RemoteApp.RequestTimedOut,
                        String.Empty,
                        Client.Collections,
                        ErrorCategory.OperationTimeout);

                    WriteError(error);
                }
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
            }
            catch (Exception e)
            {
                ErrorRecord error = RemoteAppCollectionErrorState.CreateErrorRecordFromException(e, String.Empty, Client.Collections, ErrorCategory.InvalidResult);
                WriteError(error);
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
    }
}
