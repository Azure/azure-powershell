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
using System.IO;
using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Batch.Protocol;
using Microsoft.Azure.Batch.Protocol.Entities;
using Microsoft.Azure.Commands.Batch.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;
using Xunit;
using BatchClient = Microsoft.Azure.Commands.Batch.Models.BatchClient;

namespace Microsoft.Azure.Commands.Batch.Test.Files
{
    public class GetBatchTaskFileContentCommandTests
    {
        private GetBatchTaskFileContentCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchTaskFileContentCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchTaskFileContentCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchTaskFileParametersTest()
        {
            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.WorkItemName = null;
            cmdlet.JobName = null;
            cmdlet.TaskName = null;
            cmdlet.Name = null;
            cmdlet.InputObject = null;
            cmdlet.DestinationPath = null;

            string fileName = "stdout.txt";

            // Don't hit the file system during unit tests
            cmdlet.Stream = new MemoryStream();

            // Don't go to the service on a GetTaskFile call or GetTaskFileProperties call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is GetTaskFilePropertiesRequest)
                {
                    GetTaskFilePropertiesResponse response = BatchTestHelpers.CreateGetTaskFilePropertiesResponse(fileName);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                if (request is GetTaskFileRequest)
                {
                    GetTaskFileResponse response = new GetTaskFileResponse();
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            // Fill required Task file details
            cmdlet.WorkItemName = "workItem";
            cmdlet.JobName = "job-0000000001";
            cmdlet.TaskName = "task";
            cmdlet.Name = fileName;

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            // File in required local path
            cmdlet.DestinationPath = "localFile.txt";

            try
            {
                // Verify no exceptions occur
                cmdlet.ExecuteCmdlet();
            }
            finally
            {
                cmdlet.Stream.Dispose();
            }
        }
    }
}
