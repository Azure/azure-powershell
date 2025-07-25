// ----------------------------------------------------------------------------------
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

using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSOperationsApiVersions
    {
        public const string October2020 = "2020-10-01";
    }

    public class PSOperation
    {
        public string Name { get; set; }
        public string Provider { get; set; }
        public string Resource { get; set; }
        public string Operation { get; set; }
        public string Description { get; set; }


        public PSOperation(Operation op)
        {
            Name = op.Name;
            Provider = op.Display.Provider;
            Resource = op.Display.Resource;
            Operation = op.Display.Operation;
            Description = op.Display.Description;
        }

    }
}
