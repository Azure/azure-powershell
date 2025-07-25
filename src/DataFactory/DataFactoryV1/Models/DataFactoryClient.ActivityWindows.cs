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

using Microsoft.Azure.Commands.DataFactories.Models;
using Microsoft.Azure.Management.DataFactories;
using Microsoft.Azure.Management.DataFactories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Reflection;

namespace Microsoft.Azure.Commands.DataFactories
{
    public partial class DataFactoryClient
    {
        public List<PSActivityWindow> ProcessListFilterActivityWindows(ActivityWindowFilterOptions filterOptions)
        {
            List<PSActivityWindow> runs = new List<PSActivityWindow>();

            ActivityWindowListResponse response;

            if (string.IsNullOrWhiteSpace(filterOptions.PipelineName) &&
                !string.IsNullOrWhiteSpace(filterOptions.DatasetName) &&
                string.IsNullOrWhiteSpace(filterOptions.ActivityName))
            {
                ActivityWindowsByDatasetListParameters byDatasetListParameters =
                    this.GenerateListParameters<ActivityWindowsByDatasetListParameters>(filterOptions);
                response = this.ListByDatasetActivityWindows(filterOptions.NextLink, byDatasetListParameters);
            }
            else if (string.IsNullOrWhiteSpace(filterOptions.DatasetName) &&
                !string.IsNullOrWhiteSpace(filterOptions.PipelineName) &&
                string.IsNullOrWhiteSpace(filterOptions.ActivityName))
            {
                ActivityWindowsByPipelineListParameters byPipelineListParameters =
                    this.GenerateListParameters<ActivityWindowsByPipelineListParameters>(filterOptions);
                response = this.ListByPipelineActivityWindows(filterOptions.NextLink, byPipelineListParameters);
            }
            else if (string.IsNullOrWhiteSpace(filterOptions.DatasetName) &&
                !string.IsNullOrWhiteSpace(filterOptions.PipelineName) &&
                !string.IsNullOrWhiteSpace(filterOptions.ActivityName))
            {
                ActivityWindowsByActivityListParameters byActivityListParameters =
                    this.GenerateListParameters<ActivityWindowsByActivityListParameters>(filterOptions);
                response = this.ListByActivityActivityWindows(filterOptions.NextLink, byActivityListParameters);
            }
            else if (string.IsNullOrWhiteSpace(filterOptions.DatasetName) &&
                string.IsNullOrWhiteSpace(filterOptions.PipelineName) &&
                string.IsNullOrWhiteSpace(filterOptions.ActivityName))
            {
                ActivityWindowsByDataFactoryListParameters byDataFactoryListParameters =
                    this.GenerateListParameters<ActivityWindowsByDataFactoryListParameters>(filterOptions);
                response = this.ListByDataFactoryActivityWindows(filterOptions.NextLink, byDataFactoryListParameters);
            }
            else
            {
                throw new PSArgumentException(
                    "An incorrect combination of arguments was passed. One of the following combinations of arguments must be provided:\n" +
                    "1) List activity windows by data factory: '-ResourceGroupName' and '-DataFactoryName'.\n" +
                    "2) List activity windows by pipeline: '-ResourceGroupName' and '-DataFactoryName' and '-PipelineName'.\n" +
                    "3) List activity windows by pipeline activity: '-ResourceGroupName' and '-DataFactoryName' and '-PipelineName' and '-ActivityName'.\n" +
                    "4) List activity windows by dataset: '-ResourceGroupName' and '-DataFactoryName' and '-DatasetName'.\n");
            }

            filterOptions.NextLink = response != null ? response.NextLink : null;

            if (response != null && response.ActivityWindowListResponseValue.ActivityWindows != null)
            {
                runs.AddRange(response.ActivityWindowListResponseValue.ActivityWindows.Select(activityWindow => new PSActivityWindow(activityWindow)));
            }

            return runs;
        }

        public virtual ActivityWindowListResponse ListByPipelineActivityWindows(string nextLink, ActivityWindowsByPipelineListParameters listParameters)
        {
            return nextLink.IsNextPageLink() ?
                DataPipelineManagementClient.ActivityWindows.ListNext(nextLink, listParameters) :
                DataPipelineManagementClient.ActivityWindows.List(listParameters);
        }

        public virtual ActivityWindowListResponse ListByDatasetActivityWindows(
            string nextLink, ActivityWindowsByDatasetListParameters listParameters)
        {
            return nextLink.IsNextPageLink() ?
                DataPipelineManagementClient.ActivityWindows.ListNext(nextLink, listParameters) :
                DataPipelineManagementClient.ActivityWindows.List(listParameters);
        }

        public virtual ActivityWindowListResponse ListByDataFactoryActivityWindows(
            string nextLink, ActivityWindowsByDataFactoryListParameters listParameters)
        {
            return nextLink.IsNextPageLink() ?
                DataPipelineManagementClient.ActivityWindows.ListNext(nextLink, listParameters) :
                DataPipelineManagementClient.ActivityWindows.List(listParameters);
        }

        public virtual ActivityWindowListResponse ListByActivityActivityWindows(
            string nextLink, ActivityWindowsByActivityListParameters listParameters)
        {
            return nextLink.IsNextPageLink() ?
                DataPipelineManagementClient.ActivityWindows.ListNext(nextLink, listParameters) :
                DataPipelineManagementClient.ActivityWindows.ListByPipelineActivity(listParameters);
        }

        private T GenerateListParameters<T>(ActivityWindowFilterOptions filterOptions)
            where T : ActivityWindowsListParameters, new()
        {
            T listParameters = new T();

            Type typeOfT = typeof(T);
            Type filterType = typeof(ActivityWindowFilterOptions);

            foreach (PropertyInfo pi in filterType.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                object filterValue = filterType.GetProperty(pi.Name).GetValue(filterOptions, null);

                PropertyInfo propertyInfo = typeOfT.GetProperty(pi.Name);
                if (propertyInfo != null)
                {
                    typeOfT.GetProperty(pi.Name).SetValue(listParameters, filterValue);
                }
            }

            return listParameters;
        }
    }
}