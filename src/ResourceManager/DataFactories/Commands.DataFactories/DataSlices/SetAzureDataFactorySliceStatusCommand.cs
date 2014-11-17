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

using Microsoft.Azure.Commands.DataFactories.Properties;
using Microsoft.Azure.Management.DataFactories.Models;
using System.Collections;
using System.Globalization;
using System.Management.Automation;
using System.Security.Permissions;

namespace Microsoft.Azure.Commands.DataFactories
{
    [Cmdlet(VerbsCommon.Set, Constants.SliceStatus), OutputType(typeof(bool))]
    public class SetAzureDataFactorySliceStatusCommand : DataSliceContextBaseCmdlet
    {
        private string _updateType = "Individual";

        [Parameter(Position = 5, Mandatory = true, HelpMessage = "The data slice status.")]
        [ValidateSet(
            DataSliceStatus.NotSpecified,
            DataSliceStatus.PendingExecution,
            DataSliceStatus.InProgress,
            DataSliceStatus.Failed,
            DataSliceStatus.Ready,
            DataSliceStatus.Skip,
            DataSliceStatus.Retry,
            DataSliceStatus.TimedOut,
            DataSliceStatus.PendingValidation,
            DataSliceStatus.RetryValidation,
            DataSliceStatus.FailedValidation,
            DataSliceStatus.LongRetry,
            DataSliceStatus.ValidationInProgress,
            IgnoreCase = false)]
        public string Status { get; set; }

        [Parameter(Position = 6, Mandatory = false, HelpMessage = "The update type.")]
        [ValidateSet(
            SetSliceStatusType.Individual,
            SetSliceStatusType.UpstreamInPipeline,
            SetSliceStatusType.UpstreamInFactory,
            IgnoreCase = false)]
        public string UpdateType
        {
            get { return _updateType; }
            set { _updateType = value; }
        }

        [EnvironmentPermission(SecurityAction.Demand, Unrestricted = true)]
        public override void ExecuteCmdlet()
        {
            if (ParameterSetName == ByFactoryObject)
            {
                if (DataFactory == null)
                {
                    throw new PSArgumentNullException(string.Format(CultureInfo.InvariantCulture, Resources.DataFactoryArgumentInvalid));
                }

                DataFactoryName = DataFactory.DataFactoryName;
                ResourceGroupName = DataFactory.ResourceGroupName;
            }

            DataFactoryClient.SetSliceStatus(
                ResourceGroupName,
                DataFactoryName,
                TableName,
                Status,
                UpdateType,
                StartDateTime,
                EndDateTime);

            WriteObject(true);
        }
    }
}