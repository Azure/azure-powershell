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

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.PowershellCore
{
    public class CmdletParam
    {
        private readonly string cmdletParamName;
        private readonly object cmdletParamValue;
        private readonly bool cmdletIsSwitch;

        public string name
        {
            get
            {
                return cmdletParamName;
            }
        }

        public object value
        {
            get
            {
                return cmdletParamValue;
            }
        }

        public bool isSwitch
        {
            get
            {
                return cmdletIsSwitch;
            }
        }

        public CmdletParam(string name, object value)
        {
            cmdletParamName = name;
            cmdletParamValue = value;
            cmdletIsSwitch = false;
        }

        public CmdletParam(string name)
        {
            cmdletParamName = name;
            cmdletIsSwitch = true;
        }
    }
}