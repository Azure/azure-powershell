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
using System.Globalization;
using System.Management.Automation;
using System.Management.Automation.Host;

namespace Microsoft.Azure.PoerShell.Tools.AzPredictor.MockPSConsole
{
    /// <summary>
    /// Mocking a PSHost with the a specific name so that we can know it's from the mocking program.
    /// </summary>
    internal class MockPSHost: PSHost
    {
        /// <inheritdoc />
        public override string Name => "MockPSHost";

        /// <inheritdoc />
        public override Version Version => PSVersionInfo.PSVersion;

        /// <inheritdoc />
        public override Guid InstanceId { get; } = Guid.NewGuid();

        /// <inheritdoc />
        public override PSHostUserInterface UI => null;

        /// <inheritdoc />
        public override CultureInfo CurrentCulture => CultureInfo.InvariantCulture;

        /// <inheritdoc />
        public override CultureInfo CurrentUICulture => CultureInfo.InvariantCulture;

        /// <inheritdoc />
        public override void SetShouldExit(int exitCode)
        {
        }

        /// <inheritdoc />
        public override void EnterNestedPrompt() => throw new NotSupportedException();

        /// <inheritdoc />
        public override void ExitNestedPrompt() => throw new NotSupportedException();

        /// <inheritdoc />
        public override void NotifyBeginApplication()
        {
        }

        /// <inheritddoc />
        public override void NotifyEndApplication()
        {
        }
    }
}
