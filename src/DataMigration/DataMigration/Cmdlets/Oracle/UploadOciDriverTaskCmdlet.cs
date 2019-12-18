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

using System.Management.Automation;
using Microsoft.Azure.Management.DataMigration.Models;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    public class UploadOciDriverTaskCmdlet : DynamicCmdlet, ITaskCmdlet
    {
        private readonly string OciDriverPath = "OciDriverPath";
        private readonly string Username = "Username";
        private readonly string Password = "Password";

        public UploadOciDriverTaskCmdlet(InvocationInfo myInvocation) : base(myInvocation)
        {
        }

        public override void CustomInit()
        {
            this.SimpleParam(OciDriverPath, typeof(string), "File share path of the driver install package.", true);
            this.SimpleParam(Username, typeof(string), "User that has permissions on the share.", true);
            this.SimpleParam(Password, typeof(string), "Password for the user of the share.", true);
        }

        public ProjectTaskProperties ProcessTaskCmdlet()
        {
            UploadOCIDriverTaskInput input = null;

            FileShare share = new FileShare(
                (string)MyInvocation.BoundParameters[OciDriverPath],
                (string)MyInvocation.BoundParameters[Username],
                (string)MyInvocation.BoundParameters[Password]);
            input = new UploadOCIDriverTaskInput(share);

            return new UploadOCIDriverTaskProperties { Input = input };
        }
    }
}
