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

using Microsoft.WindowsAzure.Management.RemoteApp;
using Microsoft.WindowsAzure.Management.RemoteApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.WindowsAzure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppStartMenuProgram"), OutputType(typeof(StartMenuApplication))]
    public class GetStartMenuProgram : RdsCmdlet
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
            HelpMessage = "Unique alias of the program, Wildcards are permitted.")]
        [ValidateNotNullOrEmpty()]
        public string ProgramName { get; set; }

        public class ApplicationComparer : IComparer<StartMenuApplication>
        {
            public int Compare(StartMenuApplication first, StartMenuApplication second)
            {
                if (first == null)
                {
                    if (second == null)
                    {
                        return 0; // both null are equal
                    }
                    else
                    {
                        return -1; // second is greateer
                    }
                }
                else
                {
                    if (second == null)
                    {
                        return 1; // first is greater as it is not null
                    }
                }

                return string.Compare(first.Name, second.Name, StringComparison.OrdinalIgnoreCase);
            }
        }

        public override void ExecuteCmdlet()
        {
            GetStartMenuApplicationListResult result = null;
            bool getAllPrograms = false;
            bool found = false;

            if (String.IsNullOrWhiteSpace(ProgramName))
            {
                getAllPrograms = true;
            }
            else
            {
                CreateWildcardPattern(ProgramName);
            }

            result = CallClient(() => Client.Publishing.StartMenuApplicationList(CollectionName), Client.Publishing);
            if (result != null && result.ResultList != null)
            {
                if (ExactMatch)
                {
                    StartMenuApplication application = null;
                    application = result.ResultList.FirstOrDefault(app => String.Equals(app.Name, ProgramName, StringComparison.InvariantCultureIgnoreCase));

                    if (application == null)
                    {
                        WriteErrorWithTimestamp("Program: " + ProgramName + " does not exist in collection " + CollectionName);
                        found = false;
                    }
                    else
                    {
                        WriteObject(application);
                        found = true;
                    }
                }
                else
                {
                    IEnumerable<StartMenuApplication> matchingApps = null;
                    if (getAllPrograms)
                    {
                        matchingApps = result.ResultList;
                    }
                    else if (UseWildcard)
                    {
                        matchingApps = result.ResultList.Where(app => Wildcard.IsMatch(app.Name));
                    }

                    if (matchingApps != null && matchingApps.Count() > 0)
                    {
                        List<StartMenuApplication> applications = new List<StartMenuApplication>(matchingApps);
                        IComparer<StartMenuApplication> comparer = new ApplicationComparer();
                        applications.Sort(comparer);
                        WriteObject(applications, true);
                        found = true;
                    }
                }
            }

            if (!found && !getAllPrograms)
            {
                WriteVerboseWithTimestamp(String.Format("Program '{0}' was not found in Collection '{1}'.", ProgramName, CollectionName));
            }
        }
    }
}