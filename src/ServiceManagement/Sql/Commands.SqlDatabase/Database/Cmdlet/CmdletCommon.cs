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
using System.Diagnostics;
using System.Management.Automation;
using System.Threading;
using Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Database.Cmdlet
{
    internal static class CmdletCommon
    {
        public static DateTime NormalizeToUtc(DateTime dateTime)
        {
            switch (dateTime.Kind)
            {
                case DateTimeKind.Utc:
                    return dateTime;

                case DateTimeKind.Local:
                    return dateTime.ToUniversalTime();

                case DateTimeKind.Unspecified:
                default:
                    return DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);
            }
        }

        /// <summary>
        /// Queries the server until the database assignment succeeds or there is an error.
        /// </summary>
        /// <param name="context">The context upon which to perform the action</param>
        /// <param name="response">The database object.</param>
        /// <returns>Returns the response from the server</returns>
        internal static Services.Server.Database WaitForDatabaseOperation(PSCmdlet cmdlet, IServerDataServiceContext context, Services.Server.Database response, string databaseName, bool isCreate)
        {
            // Duration to sleep: 2 second
            TimeSpan sleepDuration = TimeSpan.FromSeconds(2.0);

            // Poll for a maximum of 10 minutes;
            TimeSpan maximumPollDuration = TimeSpan.FromMinutes(10.0);

            // Text to display to the user while they wait.
            string pendingText = "Pending";
            string textToDisplay = "";

            // Start the timer
            Stopwatch watch = Stopwatch.StartNew();

            while (watch.Elapsed < maximumPollDuration)
            {
                if (response == null)
                {
                    throw new Exception("An unexpected error occured. The response from the server was invalid, please try your request again.");
                }

                // Check to see if the database is ready for use.
                if ((isCreate && (response.Status != (int)DatabaseStatus.Creating)) || // The database is done being created
                    (!isCreate && (response.ServiceObjectiveAssignmentState != 0)))     // The database is done with SLO upgrade
                {
                    break;
                }

                // Wait before next poll.
                Thread.Sleep(sleepDuration);

                // Display that the status is pending and how long the operation has been waiting
                textToDisplay = string.Format("{0}: {1}", pendingText, watch.Elapsed.ToString("%s' sec.'"));
                cmdlet.WriteProgress(new ProgressRecord(0, "Waiting for database creation completion.", textToDisplay));

                // Poll the server for the database status.
                response = context.GetDatabase(databaseName);
            }

            return response;
        }
    }
}
