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

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Internal.Interfaces
{
    /// <summary>
    /// An abstraction of the ability to get and set environment variable on various targets.
    /// </summary>
    internal interface IEnvironmentVariableProvider
    {
        string Get(string variableName, EnvironmentVariableTarget target = EnvironmentVariableTarget.Process);

        void Set(string variableName, string value, EnvironmentVariableTarget target = EnvironmentVariableTarget.Process);

        IReadOnlyDictionary<string, string> List(EnvironmentVariableTarget target = EnvironmentVariableTarget.Process);
    }
}
