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
using System.IO;
using System.Linq;
using System.Management.Automation;
using AzDev.Models;
using AzDev.Models.Inventory;
using AzDev.Services;

namespace AzDev.Cmdlets
{
    public abstract class DevCmdletBase : PSCmdlet, IModuleAssemblyInitializer
    {
        internal DevContext Context
        {
            get
            {
                try
                {
                    return ContextProvider.LoadContext();
                }
                catch (FileNotFoundException)
                {
                    WriteWarning("Run Set-DevContext to set context.");
                    throw;
                }
            }
        }

        internal Codebase Codebase
        {
            get
            {
                try
                {
                    return CodebaseProvider.GetCodebase();
                }
                catch (FileNotFoundException)
                {
                    WriteWarning("Run Set-DevContext to set context.");
                    throw;
                }
            }
        }

        /// <summary>
        /// Gets the context provider. Use <see cref="Context"/> property to get the context.
        /// </summary>
        internal IContextProvider ContextProvider => AzDevModule.GetService<IContextProvider>();

        /// <summary>
        /// Gets the codebase provider. Use <see cref="Codebase"/> property to get the codebase.
        /// </summary>
        internal ICodebaseProvider CodebaseProvider => AzDevModule.GetService<ICodebaseProvider>();

        public DevCmdletBase()
        {
        }

        public void OnImport()
        {
            AzDevModule.Initialize();
        }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
            SetUpCmdletLogger();
        }

        private void SetUpCmdletLogger()
        {
            if (AzDevModule.GetService<ILogger>() is PSCmdletLogger logger)
            {
                logger.SetCmdlet(this);
            }
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
            ClearCmdletLogger();
        }

        private static void ClearCmdletLogger()
        {
            if (AzDevModule.GetService<ILogger>() is PSCmdletLogger logger)
            {
                logger.UnsetCmdlet();
            }
        }

        protected T SelectFrom<T>(string message, IEnumerable<T> options, bool retryIfInvalid = true)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.Count() == 1)
            {
                return options.First();
            }

            while (true)
            {
                Host.UI.WriteLine(message);
                var index = 1;
                foreach (var option in options)
                {
                    Host.UI.WriteLine($"  {index++}: {option}");
                }
                Host.UI.WriteLine("Enter the number corresponding to your selection");

                if (int.TryParse(Host.UI.ReadLine(), out int choice)
                    && choice >= 1 && choice <= options.Count())
                {
                    return options.ElementAt(choice - 1);
                }
                else if (!retryIfInvalid)
                {
                    WriteWarning("Invalid selection.");
                    return default;
                }
                else
                {
                    WriteWarning("Invalid selection. Please try again.");
                }
            }
        }
    }
}
