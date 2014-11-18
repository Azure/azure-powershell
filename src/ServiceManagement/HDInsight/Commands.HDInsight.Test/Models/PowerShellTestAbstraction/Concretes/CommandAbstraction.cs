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

using System.Management.Automation.Runspaces;
using Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Interfaces;

namespace Microsoft.WindowsAzure.Commands.Test.Utilities.HDInsight.PowerShellTestAbstraction.Concretes
{
    public class CommandAbstraction : PipelineAbstraction, ICommand
    {
        internal CommandAbstraction(Command command, Pipeline pipeline, Runspace runsapce) : base(pipeline, runsapce)
        {
            this.Command = command;
        }

        protected Command Command { get; private set; }

        public ICommand WithParameter(string name, object value)
        {
            this.Command.Parameters.Add(name, value);
            return this;
        }
    }
}
