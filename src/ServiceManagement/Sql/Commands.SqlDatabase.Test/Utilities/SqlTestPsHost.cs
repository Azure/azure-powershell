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
using System.Linq;
using System.Management.Automation.Host;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Test.Utilities
{
    /// <summary>
    /// Custom PSHost implementation to help testing.
    /// </summary>
    public class SqlTestPsHost : PSHost
    {
        /// <summary>
        /// Custom PSHostUserInterface to help control how input is received
        /// </summary>
        private SqlCustomPsHostUserInterface ui;

        /// <summary>
        /// ID for this PSHost
        /// </summary>
        private Guid id = Guid.NewGuid();

        /// <summary>
        /// Name of the PSHost
        /// </summary>
        private const string name = "SqlTestPsHost";

        /// <summary>
        /// PSHost version
        /// </summary>
        private Version version = new Version(1, 0, 0, 0);

        /// <summary>
        /// Default constructor, assigns the UI.
        /// </summary>
        public SqlTestPsHost()
        {
            ui = new SqlCustomPsHostUserInterface();
        }

        /// <summary>
        /// Get the current culture 
        /// </summary>
        public override System.Globalization.CultureInfo CurrentCulture
        {
            get { return Thread.CurrentThread.CurrentCulture; }
        }

        /// <summary>
        /// Get the current culture the UI is using
        /// </summary>
        public override System.Globalization.CultureInfo CurrentUICulture
        {
            get { return Thread.CurrentThread.CurrentUICulture; }
        }

        /// <summary>
        /// Not needed.  Used for calling legacy programs like ping.exe
        /// </summary>
        public override void EnterNestedPrompt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Not needed.  Used for calling legacy programs like ping.exe
        /// </summary>
        public override void ExitNestedPrompt()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the ID of this instance
        /// </summary>
        public override Guid InstanceId
        {
            get { return id; }
        }

        /// <summary>
        /// Gets the name of the host
        /// </summary>
        public override string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Not needed.
        /// </summary>
        public override void NotifyBeginApplication()
        {
            return;
        }

        /// <summary>
        /// Not needed.
        /// </summary>
        public override void NotifyEndApplication()
        {
            return;
        }

        /// <summary>
        /// Not needed.
        /// </summary>
        public override void SetShouldExit(int exitCode)
        {
            return;
        }

        /// <summary>
        /// Gets our custom user interface implementation
        /// </summary>
        public override PSHostUserInterface UI
        {
            get { return ui; }
        }

        /// <summary>
        /// Gets the version
        /// </summary>
        public override Version Version
        {
            get { return version; }
        }
    }
}
