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

namespace Microsoft.Azure.Commands.SqlVirtualMachine.Common
{
    /// <summary>
    /// Different sets of parameters allowed as input of a cmdlet.
    /// </summary>
    public static class ParameterSet
    {
        public const string ResourceId = "ResourceId";
        public const string InputObject = "InputObject";
        public const string SqlVMGroupObject = "SqlVmGroupObject";
        public const string Name = "Name";
        public const string ParameterList = "ParamaterList";

        public const string ResourceGroupOnly = "ResourceGroupOnly";

        public const string NameParameterList = Name + ParameterList;
        public const string ResourceIdParameterList = ResourceId + ParameterList;

        public const string NameInputObject = Name + InputObject;
        public const string ResourceIdInputObject = ResourceId + InputObject;
    }
}
