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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Authentication.Properties;
using Microsoft.Azure.Commands.Shared.Config;
using Microsoft.Azure.PowerShell.Common.Config;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Common.Authentication.Config.Definitions
{
    /// <summary>
    /// Definition of the config to control data collection.
    /// </summary>
    internal class EnableDataCollectionConfig : TypedConfig<bool>
    {
        /// <summary>
        /// Key of the data collection setting in the lagacy config file.
        /// See <see cref="AzurePSDataCollectionProfile.DefaultFileName"/>.
        /// </summary>
        public const string LegacyConfigKey = "enableAzureDataCollection";

        public override object DefaultValue => true;

        public override string Key => ConfigKeys.EnableDataCollection;

        public override string HelpMessage => Resources.HelpMessageOfEnableDataCollection;

        public override IReadOnlyCollection<AppliesTo> CanApplyTo => _canApplyTo;
        private IReadOnlyCollection<AppliesTo> _canApplyTo = new[] { AppliesTo.Az };
    }
}
