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
    public class PSOutput
    {
        private Output output;

        public PSOutput()
        {
            output = new Output();
        }

        public PSOutput(Output output)
        {
            if (output == null)
            {
                throw new ArgumentNullException("output");
            }

            this.output = output;
        }

        public string Name
        {
            get
            {
                return output.Name;
            }
            internal set
            {
                output.Name = value;
            }
        }

        public string JobName { get; set; }

        public string ResourceGroupName { get; set; }

        public OutputProperties Properties
        {
            get
            {
                return output.Properties;
            }
            internal set
            {
                output.Properties = value;
            }
        }

        public string PropertiesInJson
        {
            get { return output.ToFormattedString(); }
        }
    }
}