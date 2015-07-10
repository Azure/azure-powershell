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
using System.Globalization;
using System.Net;
using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Commands.DataFactories.Properties;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace Microsoft.Azure.Commands.DataFactories
{
    public partial class DataFactoryClient
    {
        public virtual List<PSDataSliceRun> ListDataSliceRuns(DataSliceRunFilterOptions filterOptions)
        {
            List<PSDataSliceRun> runs = new List<PSDataSliceRun>();

            DataSliceRunListResponse response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = DataPipelineManagementClient.DataSliceRuns.ListNext(filterOptions.NextLink);
            }
            else
            {
                response = DataPipelineManagementClient.DataSliceRuns.List(
                    filterOptions.ResourceGroupName,
                    filterOptions.DataFactoryName,
                    filterOptions.TableName,
                    new DataSliceRunListParameters()
                    {
                        DataSliceStartTime = filterOptions.StartDateTime.ConvertToISO8601DateTimeString()
                    });    
            }
            filterOptions.NextLink = response != null ? response.NextLink : null;

            if (response != null && response.DataSliceRuns != null)
            {
                foreach (var run in response.DataSliceRuns)
                {
                    runs.Add(
                        new PSDataSliceRun(run)
                        {
                            ResourceGroupName = filterOptions.ResourceGroupName,
                            DataFactoryName = filterOptions.DataFactoryName,
                            TableName = filterOptions.TableName
                        });
                }
            }

            return runs;
        }

        public virtual List<PSDataSlice> ListDataSlices(DataSliceFilterOptions filterOptions)
        {
            List<PSDataSlice> dataSlices = new List<PSDataSlice>();

            DataSliceListResponse response;
            if (filterOptions.NextLink.IsNextPageLink())
            {
                response = DataPipelineManagementClient.DataSlices.ListNext(filterOptions.NextLink);
            }
            else
            {
                response = DataPipelineManagementClient.DataSlices.List(
                    filterOptions.ResourceGroupName,
                    filterOptions.DataFactoryName,
                    filterOptions.TableName,
                    new DataSliceListParameters()
                    {
                        DataSliceRangeStartTime = filterOptions.DataSliceRangeStartTime.ConvertToISO8601DateTimeString(),
                        DataSliceRangeEndTime = filterOptions.DataSliceRangeEndTime.ConvertToISO8601DateTimeString()
                    });
            }
            filterOptions.NextLink = response != null ? response.NextLink : null;
            
            if (response != null && response.DataSlices != null)
            {
                foreach (var dataSlice in response.DataSlices)
                {
                    dataSlices.Add(
                        new PSDataSlice(dataSlice)
                        {
                            ResourceGroupName = filterOptions.ResourceGroupName,
                            DataFactoryName = filterOptions.DataFactoryName,
                            TableName = filterOptions.TableName
                        });
                }
            }

            return dataSlices;
        }

        public virtual void SetSliceStatus(
            string resourceGroupName,
            string dataFactoryName,
            string tableName,
            string sliceState,
            string updateType,
            DateTime dataSliceRangeStartTime,
            DateTime dataSliceRangeEndTime)
        {
            DataPipelineManagementClient.DataSlices.SetStatus(
                resourceGroupName,
                dataFactoryName,
                tableName,
                new DataSliceSetStatusParameters()
                {
                    SliceState = sliceState,
                    UpdateType = updateType,
                    DataSliceRangeStartTime = dataSliceRangeStartTime.ConvertToISO8601DateTimeString(),
                    DataSliceRangeEndTime = dataSliceRangeEndTime.ConvertToISO8601DateTimeString(),
                });
        }

        public virtual PSRunLogInfo GetDataSliceRunLogsSharedAccessSignature(string resourceGroupName, string dataFactoryName, string dataSliceRunId)
        {
            var response = DataPipelineManagementClient.DataSliceRuns.GetLogs(
                resourceGroupName, dataFactoryName, dataSliceRunId);

            return new PSRunLogInfo(response.DataSliceRunLogsSASUri);
        }

        public virtual void DownloadFileToBlob(BlobDownloadParameters parameters)
        {
            if (parameters == null || parameters.Credentials == null || string.IsNullOrWhiteSpace(parameters.SasUri.ToString()))
            {
                throw new ArgumentNullException(Resources.DownloadCredentialsNull);
            }

            CloudBlobContainer sascontainer = new CloudBlobContainer(parameters.SasUri);

            var bloblist = sascontainer.ListBlobs(null, true);
            string downloadFolderPath = parameters.Directory.Insert(parameters.Directory.Length, @"\");

            foreach (var blob in bloblist)
            {
                ICloudBlob destBlob = blob as ICloudBlob;
                int length =  destBlob.Name.Split('/').Length;
                string blobFileName = destBlob.Name.Split('/')[length-1];
                // the folder structure of run logs changed from flat listing to nesting under time directory
                string blobFolderPath = String.Empty;
                if (destBlob.Name.Length > blobFileName.Length)
                {
                    blobFolderPath = destBlob.Name.Substring(0, destBlob.Name.Length - blobFileName.Length - 1);
                }
                
                if (!Directory.Exists(downloadFolderPath + blobFolderPath))
                {
                    Directory.CreateDirectory(downloadFolderPath + blobFolderPath);
                }
                // adding _log suffix to differentiate between files and folders of the same name. Azure blob storage only knows about blob files. We could use nested folder structure
                // as part of the blob file name and thus it is possible to have a file and folder of the same name in the same location which is not acceptable for Windows file system
                destBlob.DownloadToFile(downloadFolderPath + destBlob.Name + "_log", FileMode.Create);
            }
        }
    }
}