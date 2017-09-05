﻿// ----------------------------------------------------------------------------------
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
using Microsoft.WindowsAzure.Commands.Common.Test.Mocks;
using Microsoft.WindowsAzure.Commands.Storage.File;
using Microsoft.WindowsAzure.Commands.Storage.Test;
using Microsoft.WindowsAzure.Management.Storage.Test.Service;

namespace Microsoft.WindowsAzure.Management.Storage.Test.File
{
    public abstract class StorageFileTestBase<T> : StorageTestBase, IDisposable where T : AzureStorageFileCmdletBase
    {
        private MockStorageFileManagement channel = new MockStorageFileManagement();

        private T cmdlet;

        private IDisposable sessionStateDisposable;

        public StorageFileTestBase()
        {
            this.MockCmdRunTime = new MockCommandRuntime();
            cmdlet = (T)Activator.CreateInstance(typeof(T));
            cmdlet.CommandRuntime = this.MockCmdRunTime;
            cmdlet.Channel = this.channel;
            cmdlet.ShareChannel = true;
            this.sessionStateDisposable = cmdlet.InitializeSessionState();
        }

        protected MockStorageFileManagement MockChannel
        {
            get { return this.channel; }
        }

        protected T CmdletInstance
        {
            get { return this.cmdlet; }
        }

        public void Dispose()
        {
            if (this.sessionStateDisposable != null)
            {
                this.sessionStateDisposable.Dispose();
            }
        }
    }
}
