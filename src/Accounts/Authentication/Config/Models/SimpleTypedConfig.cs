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

using Microsoft.Azure.PowerShell.Common.Config;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Config
{
    /// <summary>
    /// Represents a simple typed config. For complex configs please define your own type inheriting <see cref="TypedConfig{TValue}"/> or <see cref="ConfigDefinition"/>.
    /// </summary>
    /// <typeparam name="TValue">Type of the config value.</typeparam>
    internal class SimpleTypedConfig<TValue> : TypedConfig<TValue>
    {
        private readonly string _key;
        private readonly string _helpMessage;
        private readonly TValue _defaultValue;
        private readonly string _environmentVariable;
        private readonly IReadOnlyCollection<AppliesTo> _canApplyTo = null;

        public SimpleTypedConfig(string key, string helpMessage, TValue defaultValue, string environmentVariable = null, IReadOnlyCollection<AppliesTo> canApplyTo = null)
        {
            _key = key;
            _helpMessage = helpMessage;
            _defaultValue = defaultValue;
            _environmentVariable = environmentVariable;
            _canApplyTo = canApplyTo;
        }

        public override string Key => _key;
        public override string HelpMessage => _helpMessage;
        public override object DefaultValue => _defaultValue;
        protected override string EnvironmentVariableName => _environmentVariable;
        public override IReadOnlyCollection<AppliesTo> CanApplyTo
        {
            get { return _canApplyTo ?? base.CanApplyTo; }
        }
    }
}
