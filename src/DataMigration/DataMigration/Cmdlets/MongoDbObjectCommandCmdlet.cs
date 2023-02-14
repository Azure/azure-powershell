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

using Microsoft.Azure.Commands.DataMigration.Models;
using Microsoft.Azure.Management.DataMigration.Models;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataMigration.Cmdlets
{
    /// <summary>
    /// Class representing mongo db migration commands's CmdLet
    /// </summary>
    public class MongoDbObjectCommandCmdlet : CommandCmdlet
    {
        private readonly string ObjectName = "ObjectName";
        private readonly string Immediate = "Immediate";

        private readonly CommandTypeEnum commandType;
        private string objectNameParameterValue;
        private bool immediateParameterValue;

        public MongoDbObjectCommandCmdlet(InvocationInfo myInvocation, CommandTypeEnum commandType) : base(myInvocation)
        {
            this.commandType = commandType;
        }

        public override void CustomInit()
        {
            this.SimpleParam(ObjectName, typeof(string), "Gets or sets name of object within the database", true);
            this.SimpleParam(Immediate, typeof(SwitchParameter), "whether the finish command immediates stops the oplog replay", false);
        }

        private CommandProperties _constructInputCommandObject(string objectName, bool immediate)
        {
            switch(commandType)
            {
                case CommandTypeEnum.RestartMongoDB:
                    return new MongoDbRestartCommand() { Input = new MongoDbCommandInput() { ObjectName = objectName } };
                case CommandTypeEnum.FinishMongoDB:
                    return new MongoDbFinishCommand() { Input = new MongoDbFinishCommandInput() { Immediate = immediate, ObjectName = objectName } };
                case CommandTypeEnum.CancelMongoDB:
                    return new MongoDbCancelCommand() { Input = new MongoDbCommandInput() { ObjectName = objectName } };
            }

            throw new PSInvalidOperationException($"{commandType} is not a valid operation on the task");
        }

        public override CommandProperties ProcessCommandCmdlet()
        {
            if (MyInvocation.BoundParameters.ContainsKey(ObjectName))
            {
                objectNameParameterValue = MyInvocation.BoundParameters[ObjectName] as string;
            }

            this.immediateParameterValue = MyInvocation.BoundParameters.ContainsKey(Immediate);
            return this._constructInputCommandObject(this.objectNameParameterValue, this.immediateParameterValue);
        }
    }
}
