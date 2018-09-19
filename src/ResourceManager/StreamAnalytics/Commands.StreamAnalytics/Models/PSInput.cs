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

using Microsoft.Azure.Management.StreamAnalytics.Models;
using System;

namespace Microsoft.Azure.Commands.StreamAnalytics.Models
{
    public class PSInput
    {
        private Input input;

        public PSInput()
        {
            input = new Input();
        }

        public PSInput(Input input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            this.input = input;
        }

        public string Name
        {
            get
            {
                return input.Name;
            }
            internal set
            {
                input.Name = value;
            }
        }

        public string JobName { get; set; }

        public string ResourceGroupName { get; set; }

        public InputProperties Properties
        {
            get
            {
                return input.Properties;
            }
            internal set
            {
                input.Properties = value;
            }
        }

        public string PropertiesInJson
        {
            get { return input.ToFormattedString(); }
        }
    }
}
