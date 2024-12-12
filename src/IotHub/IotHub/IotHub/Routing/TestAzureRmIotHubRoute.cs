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

namespace Microsoft.Azure.Commands.Management.IotHub
{
    using System;
    using System.Collections;
    using System.Linq;
    using System.Management.Automation;
    using Microsoft.Azure.Commands.Management.IotHub.Common;
    using Microsoft.Azure.Commands.Management.IotHub.Models;
    using Microsoft.Azure.Management.IotHub;
    using Microsoft.Azure.Management.IotHub.Models;
    using ResourceManager.Common.ArgumentCompleters;

    [Cmdlet("Test", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "IotHubRoute", DefaultParameterSetName = ResourceParameterSet), OutputType(
        typeof(PSTestRouteResult), typeof(PSRouteCompilationError), typeof(PSRouteProperties[]))]
    public class TestAzureRmIotHubRoute : IotHubBaseCmdlet
    {
        private const string ResourceIdParameterSet = "ResourceIdSet";
        private const string ResourceIdTestRouteParameterSet = "ResourceIdTestRouteSet";
        private const string ResourceIdTestAllRouteParameterSet = "ResourceIdTestAllRouteSet";
        private const string ResourceParameterSet = "ResourceSet";
        private const string TestRouteParameterSet = "TestRouteSet";
        private const string TestAllRouteParameterSet = "TestAllRouteSet";
        private const string InputObjectParameterSet = "InputObjectSet";
        private const string InputObjectTestRouteParameterSet = "InputObjectTestRouteSet";
        private const string InputObjectTestAllRouteParameterSet = "InputObjectTestAllRouteSet";

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectTestRouteParameterSet, ValueFromPipeline = true, HelpMessage = "IotHub Object")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = InputObjectTestAllRouteParameterSet, ValueFromPipeline = true, HelpMessage = "IotHub Object")]
        [ValidateNotNullOrEmpty]
        public PSIotHub InputObject { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = TestRouteParameterSet, HelpMessage = "Name of the Resource Group")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = TestAllRouteParameterSet, HelpMessage = "Name of the Resource Group")]
        [ValidateNotNullOrEmpty]
        [ResourceGroupCompleter]
        public string ResourceGroupName { get; set; }

        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdTestRouteParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [Parameter(Position = 0, Mandatory = true, ParameterSetName = ResourceIdTestAllRouteParameterSet, ValueFromPipelineByPropertyName = true, HelpMessage = "IotHub Resource Id")]
        [ValidateNotNullOrEmpty]
        public string ResourceId { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = TestRouteParameterSet, HelpMessage = "Name of the Iot Hub")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = TestAllRouteParameterSet, HelpMessage = "Name of the Iot Hub")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectTestRouteParameterSet, HelpMessage = "Name of the Route")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdTestRouteParameterSet, HelpMessage = "Name of the Route")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = TestRouteParameterSet, HelpMessage = "Name of the Route")]
        [ValidateNotNullOrEmpty]
        public string RouteName { get; set; }

        [Parameter(Position = 1, Mandatory = true, ParameterSetName = InputObjectTestAllRouteParameterSet, HelpMessage = "Source of the route")]
        [Parameter(Position = 1, Mandatory = true, ParameterSetName = ResourceIdTestAllRouteParameterSet, HelpMessage = "Source of the route")]
        [Parameter(Position = 2, Mandatory = true, ParameterSetName = TestAllRouteParameterSet, HelpMessage = "Source of the route")]
        [ValidateNotNullOrEmpty]
        public PSRoutingSource Source { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Body of the route message")]
        public string Body { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "App properties of the route message")]
        public Hashtable AppProperty { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "System properties of the route message")]
        public Hashtable SystemProperty { get; set; }

        [Parameter(Mandatory = false, ParameterSetName = InputObjectTestRouteParameterSet, HelpMessage = "Show detailed error, if exist")]
        [Parameter(Mandatory = false, ParameterSetName = ResourceIdTestRouteParameterSet, HelpMessage = "Show detailed error, if exist")]
        [Parameter(Mandatory = false, ParameterSetName = TestRouteParameterSet, HelpMessage = "Show detailed error, if exist")]
        public SwitchParameter ShowError { get; set; }

        public override void ExecuteCmdlet()
        {
            IotHubDescription iotHubDescription;
            if (ParameterSetName.Equals(InputObjectTestRouteParameterSet) || ParameterSetName.Equals(InputObjectTestAllRouteParameterSet))
            {
                this.ResourceGroupName = this.InputObject.Resourcegroup;
                this.Name = this.InputObject.Name;
                iotHubDescription = IotHubUtils.ConvertObject<PSIotHub, IotHubDescription>(this.InputObject);
            }
            else
            {
                if (ParameterSetName.Equals(ResourceIdTestRouteParameterSet) || ParameterSetName.Equals(ResourceIdTestAllRouteParameterSet))
                {
                    this.ResourceGroupName = IotHubUtils.GetResourceGroupName(this.ResourceId);
                    this.Name = IotHubUtils.GetIotHubName(this.ResourceId);
                }

                iotHubDescription = this.IotHubClient.IotHubResource.Get(this.ResourceGroupName, this.Name);
            }

            RoutingMessage routingMessage = new RoutingMessage(this.Body, this.AppProperty != null ? this.AppProperty.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value) : null, this.SystemProperty != null ? this.SystemProperty.Cast<DictionaryEntry>().ToDictionary(kvp => (string)kvp.Key, kvp => (string)kvp.Value) : null);

            switch (ParameterSetName)
            {
                case InputObjectTestRouteParameterSet:
                case ResourceIdTestRouteParameterSet:
                case TestRouteParameterSet:
                    TestRouteInput testRouteInput = new TestRouteInput();
                    testRouteInput.Message = routingMessage;
                    testRouteInput.Route = iotHubDescription.Properties.Routing.Routes.FirstOrDefault(x => x.Name.Equals(this.RouteName, StringComparison.OrdinalIgnoreCase));
                    PSTestRouteResult psTestRouteResult = IotHubUtils.ToPSTestRouteResult(this.IotHubClient.IotHubResource.TestRoute(this.Name, this.ResourceGroupName, testRouteInput));
                    if (this.ShowError.IsPresent && psTestRouteResult.Details != null)
                    {
                        this.WriteObject(psTestRouteResult.Details.CompilationErrors, true);
                    }
                    else
                    {
                        this.WriteObject(psTestRouteResult, false);
                    }
                    break;
                case InputObjectTestAllRouteParameterSet:
                case ResourceIdTestAllRouteParameterSet:
                case TestAllRouteParameterSet:
                    TestAllRoutesInput testAllRoutesInput = new TestAllRoutesInput();
                    testAllRoutesInput.RoutingSource = this.Source.ToString();
                    testAllRoutesInput.Message = routingMessage;
                    this.WriteObject(IotHubUtils.ToPSRouteProperties(this.IotHubClient.IotHubResource.TestAllRoutes(this.Name, this.ResourceGroupName, testAllRoutesInput).Routes), true);
                    break;
            }
        }
    }
}