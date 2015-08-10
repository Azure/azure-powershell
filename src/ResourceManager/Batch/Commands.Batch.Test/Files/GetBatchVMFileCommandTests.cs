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
    public class GetBatchVMFileCommandTests
    {
        private GetBatchVMFileCommand cmdlet;
        private Mock<BatchClient> batchClientMock;
        private Mock<ICommandRuntime> commandRuntimeMock;

        public GetBatchVMFileCommandTests()
        {
            batchClientMock = new Mock<BatchClient>();
            commandRuntimeMock = new Mock<ICommandRuntime>();
            cmdlet = new GetBatchVMFileCommand()
            {
                CommandRuntime = commandRuntimeMock.Object,
                BatchClient = batchClientMock.Object,
            };
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchVMFileParametersTest()
        {
            // Setup cmdlet without required parameters
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolName = null;
            cmdlet.VMName = null;
            cmdlet.Name = null;
            cmdlet.VM = null;
            cmdlet.Filter = null;

            // Build some vm files instead of querying the service on a ListTVMFiles call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTVMFilesRequest)
                {
                    ListTVMFilesResponse response = BatchTestHelpers.CreateListTVMFilesResponse(new string[] { "startup\\stdout.txt" });
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            Assert.Throws<ArgumentNullException>(() => cmdlet.ExecuteCmdlet());

            cmdlet.PoolName = "pool";
            cmdlet.VMName = "vm1";

            // Verify no exceptions occur
            cmdlet.ExecuteCmdlet();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void GetBatchVMFileTest()
        {
            // Setup cmdlet to get a Task file by name
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolName = "pool";
            cmdlet.VMName = "vm1";
            cmdlet.Name = "startup\\stdout.txt";
            cmdlet.Filter = null;

            // Build a vm file instead of querying the service on a GetVMFileProperties call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is GetTVMFilePropertiesRequest)
                {
                    GetTVMFilePropertiesResponse response = BatchTestHelpers.CreateGetTVMFilePropertiesResponse(cmdlet.Name);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSVMFile> pipeline = new List<PSVMFile>();
            commandRuntimeMock.Setup(r => r.WriteObject(It.IsAny<PSVMFile>())).Callback<object>(f => pipeline.Add((PSVMFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the vm file returned from the OM to the pipeline
            Assert.Equal(1, pipeline.Count);
            Assert.Equal(cmdlet.Name, pipeline[0].Name);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchVMFilesByODataFilterTest()
        {
            // Setup cmdlet to list vm files using an OData filter. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolName = "pool";
            cmdlet.VMName = "vm1";
            cmdlet.Name = null;
            cmdlet.Filter = "startswith(name,'startup')";

            string[] namesOfConstructedVMFiles = new[] { "startup\\stdout.txt", "startup\\stderr.txt" };

            // Build some vm files instead of querying the service on a ListTVMFiles call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTVMFilesRequest)
                {
                    ListTVMFilesResponse response = BatchTestHelpers.CreateListTVMFilesResponse(namesOfConstructedVMFiles);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSVMFile> pipeline = new List<PSVMFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSVMFile>()))
                .Callback<object>(f => pipeline.Add((PSVMFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed vm files to the pipeline
            Assert.Equal(2, pipeline.Count);
            int taskCount = 0;
            foreach (PSVMFile f in pipeline)
            {
                Assert.True(namesOfConstructedVMFiles.Contains(f.Name));
                taskCount++;
            }
            Assert.Equal(namesOfConstructedVMFiles.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListBatchVMFilesWithoutFiltersTest()
        {
            // Setup cmdlet to list vm files without filters. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolName = "pool";
            cmdlet.VMName = "vm1";
            cmdlet.Name = null;
            cmdlet.Filter = null;

            string[] namesOfConstructedVMFiles = new[] { "startup", "workitems", "shared" };

            // Build some vm files instead of querying the service on a ListTVMFiles call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTVMFilesRequest)
                {
                    ListTVMFilesResponse response = BatchTestHelpers.CreateListTVMFilesResponse(namesOfConstructedVMFiles);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSVMFile> pipeline = new List<PSVMFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSVMFile>()))
                .Callback<object>(f => pipeline.Add((PSVMFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the cmdlet wrote the constructed vm files to the pipeline
            Assert.Equal(3, pipeline.Count);
            int taskCount = 0;
            foreach (PSVMFile f in pipeline)
            {
                Assert.True(namesOfConstructedVMFiles.Contains(f.Name));
                taskCount++;
            }
            Assert.Equal(namesOfConstructedVMFiles.Length, taskCount);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ListVMFilesMaxCountTest()
        {
            // Verify default max count
            Assert.Equal(Microsoft.Azure.Commands.Batch.Utils.Constants.DefaultMaxCount, cmdlet.MaxCount);

            // Setup cmdlet to list vm files and a max count. 
            BatchAccountContext context = BatchTestHelpers.CreateBatchContextWithKeys();
            cmdlet.BatchContext = context;
            cmdlet.PoolName = "pool";
            cmdlet.VMName = "vm1";
            cmdlet.Name = null;
            cmdlet.Filter = null;
            int maxCount = 2;
            cmdlet.MaxCount = maxCount;

            string[] namesOfConstructedVMFiles = new[] { "startup", "workitems", "shared" };

            // Build some vm files instead of querying the service on a ListTVMFiles call
            YieldInjectionInterceptor interceptor = new YieldInjectionInterceptor((opContext, request) =>
            {
                if (request is ListTVMFilesRequest)
                {
                    ListTVMFilesResponse response = BatchTestHelpers.CreateListTVMFilesResponse(namesOfConstructedVMFiles);
                    Task<object> task = Task<object>.Factory.StartNew(() => { return response; });
                    return task;
                }
                return null;
            });
            cmdlet.AdditionalBehaviors = new List<BatchClientBehavior>() { interceptor };

            // Setup the cmdlet to write pipeline output to a list that can be examined later
            List<PSVMFile> pipeline = new List<PSVMFile>();
            commandRuntimeMock.Setup(r =>
                r.WriteObject(It.IsAny<PSVMFile>()))
                .Callback<object>(f => pipeline.Add((PSVMFile)f));

            cmdlet.ExecuteCmdlet();

            // Verify that the max count was respected
            Assert.Equal(maxCount, pipeline.Count);

            // Verify setting max count <= 0 doesn't return nothing
            cmdlet.MaxCount = -5;
            pipeline.Clear();
            cmdlet.ExecuteCmdlet();

            Assert.Equal(namesOfConstructedVMFiles.Length, pipeline.Count);
        }
    }
}
