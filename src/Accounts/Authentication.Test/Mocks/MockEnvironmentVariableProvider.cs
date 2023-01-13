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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces;

namespace Microsoft.Azure.PowerShell.Authentication.Test.Mocks
{
    public class MockEnvironmentVariableProvider : IEnvironmentVariableProvider
    {
        private readonly IDictionary<string, string> _processVariables = new Dictionary<string, string>();
        private readonly IDictionary<string, string> _userVariables = new Dictionary<string, string>();
        private readonly IDictionary<string, string> _systemVariables = new Dictionary<string, string>();

        public string Get(string variableName, EnvironmentVariableTarget target = EnvironmentVariableTarget.Process)
        {
            GetVariablesByTarget(target).TryGetValue(variableName, out var result);
            return result;
        }

        private IDictionary<string, string> GetVariablesByTarget(EnvironmentVariableTarget target)
        {
            switch (target)
            {
                case EnvironmentVariableTarget.Process:
                    return _processVariables;
                case EnvironmentVariableTarget.User:
                    return _userVariables;
                case EnvironmentVariableTarget.Machine:
                    return _systemVariables;
                default:
                    throw new ArgumentException(nameof(target));
            }
        }

        public void Set(string variableName, string value, EnvironmentVariableTarget target = EnvironmentVariableTarget.Process)
        {
            GetVariablesByTarget(target)[variableName] = value;
        }

        public IReadOnlyDictionary<string, string> List(EnvironmentVariableTarget target = EnvironmentVariableTarget.Process)
        {
            IDictionary<string, string> variables;
            switch (target)
            {
                case EnvironmentVariableTarget.Process:
                    variables = _processVariables;
                    break;
                case EnvironmentVariableTarget.User:
                    variables = _userVariables;
                    break;
                case EnvironmentVariableTarget.Machine:
                    variables = _systemVariables;
                    break;
                default:
                    throw new ArgumentException(nameof(target));
            }
            return new ReadOnlyDictionary<string, string>(variables);
        }
    }
}
