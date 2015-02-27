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

using Microsoft.Azure.Management.RemoteApp;
using Microsoft.Azure.Management.RemoteApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Management.RemoteApp.Cmdlets
{
    [Cmdlet(VerbsCommon.Get, "AzureRemoteAppStartMenuApplication"), OutputType(typeof(StartMenuApplication))]
    public class GetStartMenuApplication : CmdletWithCollection
    {
        [Parameter(Mandatory = false,
            Position = 1,
            HelpMessage = "Unique alias of application")]
        [ValidateNotNullOrEmpty()]
        public string ApplicationName { get; set; }

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
            Collection collection = null;
            GetStartMenuApplicationListResult result = null;
            bool getAllApplications = false;
            bool found = false;

            collection = FindCollection(CollectionName);

            if (String.IsNullOrWhiteSpace(ApplicationName))
            {
                getAllApplications = true;
            }
            else
            {
                CreateWildcardPattern(ApplicationName);
            }

            if (collection != null)
            {
                result = CallClient(() => Client.Publishing.StartMenuApplicationList(CollectionName), Client.Publishing);
                if (result != null && result.ResultList != null)
                {
                    if (ExactMatch)
                    {
                        StartMenuApplication application = null;
                        application = result.ResultList.FirstOrDefault(app => String.Equals(app.Name, ApplicationName, StringComparison.InvariantCultureIgnoreCase));

                        if (application == null)
                        {
                            WriteErrorWithTimestamp("Application: " + ApplicationName + " does not exist in collection " + CollectionName);
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
                        if (getAllApplications)
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

                if (!found && !getAllApplications)
                {
                    WriteVerboseWithTimestamp(String.Format("Application '{0}' was not found in Collection '{1}'.", ApplicationName, CollectionName));
                }

            }
        }
    }
}