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

using Microsoft.AzureStack.Management.Compute.Admin;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using System.Management.Automation;



namespace Test
{

    [Cmdlet(VerbsCommon.Get, "MockClient"), OutputType(typeof(ComputeAdminClient))]
    public class Helper : PSCmdlet {

        [Parameter(Mandatory = true, Position = 0, HelpMessage = "The name of your test class.")]
        public System.String ClassName { get; set; }

        [Parameter(Mandatory = true, Position = 1, HelpMessage = "The name of your test.")]
        public System.String TestName { get; set; }

        protected override void ProcessRecord() {
            System.IO.Directory.SetCurrentDirectory(this.SessionState.Path.CurrentFileSystemLocation.ToString());

            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = System.Net.HttpStatusCode.OK };
            handler.IsPassThrough = true;

            var context = MockContext.Start(ClassName, TestName);
            WriteObject(context.GetServiceClient<ComputeAdminClient>(handlers: handler));
        }
    }
}