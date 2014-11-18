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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.Storage.Common;
using Microsoft.WindowsAzure.Storage.DataMovement.TransferJobs;

namespace Microsoft.WindowsAzure.Management.Storage.Test.Common
{
    internal sealed class MockTransferJobRunner : ITransferJobRunner
    {
        private Func<TransferJobBase, Task> runnerValidation;

        private AssertFailedException assertException;

        public MockTransferJobRunner(Func<TransferJobBase, Task> runnerValidation)
        {
            this.runnerValidation = runnerValidation;
        }

        public Task RunTransferJob(TransferJobBase job, Action<double, double> progressReport, CancellationToken cancellationToken)
        {
            try
            {
                return runnerValidation(job);
            }
            catch (AssertFailedException e)
            {
                this.assertException = e;
                throw new MockupException("AssertFailed");
            }
        }

        public void ThrowAssertExceptionIfAvailable()
        {
            if (this.assertException != null)
            {
                throw this.assertException;
            }
        }

        public void Dispose()
        {
        }
    }
}
