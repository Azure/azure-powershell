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

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDataLakeAnalyticsCatalogSecret"), OutputType(typeof(USqlSecret))]
    [Alias("Set-AdlCatalogSecret")]
    public class SetAzureDataLakeAnalyticsCatalogSecret : DataLakeAnalyticsCmdletBase
    {
        internal const string BaseParameterSetName = "Specify full URI";
        internal const string HostAndPortParameterSetName = "Specify host name and port";

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = BaseParameterSetName, Position = 0,
            Mandatory = true, HelpMessage = "The account name that contains the catalog to update the secret in.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = HostAndPortParameterSetName, Position = 0,
            Mandatory = true, HelpMessage = "The account name that contains the catalog to update the secret in.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = BaseParameterSetName, Position = 1,
            Mandatory = true, HelpMessage = "The name of the database to update the secret in.")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = HostAndPortParameterSetName, Position = 1,
            Mandatory = true, HelpMessage = "The name of the database to update the secret in.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = BaseParameterSetName, Position = 2,
            Mandatory = true, HelpMessage = "The secret to update")]
        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = HostAndPortParameterSetName, Position = 2,
            Mandatory = true, HelpMessage = "The secret to update")]
        [ValidateNotNullOrEmpty]
        public PSCredential Secret { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = HostAndPortParameterSetName, Position = 3,
            Mandatory = true, HelpMessage = "The URI of the database to connect to.")]
        public Uri Uri { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = BaseParameterSetName, Position = 3,
            Mandatory = true, HelpMessage = "The host of the database to connect to in the format 'myhost.dns.com'.")]
        [Alias("Host")]
        public string DatabaseHost { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, ParameterSetName = BaseParameterSetName, Position = 4,
            Mandatory = true, HelpMessage = "The Port associated with the host for the database to connect to.")]
        public int Port { get; set; }

        public override void ExecuteCmdlet()
        {
            if (Uri != null && Uri.Port <= 0)
            {
                WriteWarning(string.Format(Resources.NoPortSpecified, Uri));
            }

            var toUse = Uri ?? new Uri(string.Format("https://{0}:{1}", DatabaseHost, Port));

            WriteObject(DataLakeAnalyticsClient.UpdateSecret(Account, DatabaseName, Secret.UserName,
                Secret.GetNetworkCredential().Password, toUse.AbsoluteUri));
        }
    }
}