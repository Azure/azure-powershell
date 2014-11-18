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

using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters
{
    internal class AzureHDInsightCommandFactory : IAzureHDInsightCommandFactory
    {
        public IAddAzureHDInsightConfigValuesCommand CreateAddConfig()
        {
            return Help.SafeCreate<AddAzureHDInsightConfigValuesCommand>();
        }

        public IAddAzureHDInsightMetastoreCommand CreateAddMetastore()
        {
            return Help.SafeCreate<AddAzureHDInsightMetastoreCommand>();
        }

        public IAddAzureHDInsightScriptActionCommand CreateAddScriptAction()  
        {  
            return Help.SafeCreate<AddAzureHDInsightScriptActionCommand>();  
        }  

        public IAddAzureHDInsightStorageCommand CreateAddStorage()
        {
            return new AddAzureHDInsightStorageCommand();
        }

        public INewAzureHDInsightClusterCommand CreateCreate()
        {
            return Help.SafeCreate<NewAzureHDInsightClusterCommand>();
        }

        public IRemoveAzureHDInsightClusterCommand CreateDelete()
        {
            return Help.SafeCreate<RemoveAzureHDInsightClusterCommand>();
        }

        public IGetAzureHDInsightClusterCommand CreateGet()
        {
            return Help.SafeCreate<GetAzureHDInsightClusterCommand>();
        }

        public IGetAzureHDInsightJobOutputCommand CreateGetJobOutput()
        {
            return Help.SafeCreate<GetAzureHDInsightJobOutputCommand>();
        }

        public IGetAzureHDInsightJobCommand CreateGetJobs()
        {
            return Help.SafeCreate<GetAzureHDInsightJobCommand>();
        }

        public IGetAzureHDInsightPropertiesCommand CreateGetProperties()
        {
            return Help.SafeCreate<GetAzureHDInsightPropertiesCommand>();
        }

        public IInvokeHiveCommand CreateInvokeHive()
        {
            return new InvokeHiveCommand();
        }

        public IManageAzureHDInsightHttpAccessCommand CreateManageHttpAccess()
        {
            return Help.SafeCreate<ManageAzureHDInsightHttpAccessCommand>();
        }

        public INewAzureHDInsightClusterConfigCommand CreateNewConfig()
        {
            return Help.SafeCreate<NewAzureHDInsightClusterConfigCommand>();
        }

        public INewAzureHDInsightHiveJobDefinitionCommand CreateNewHiveDefinition()
        {
            return Help.SafeCreate<NewAzureHDInsightHiveJobDefinitionCommand>();
        }

        public INewAzureHDInsightMapReduceJobDefinitionCommand CreateNewMapReduceDefinition()
        {
            return Help.SafeCreate<NewAzureHDInsightMapReduceJobJobDefinitionCommand>();
        }

        public INewAzureHDInsightPigJobDefinitionCommand CreateNewPigJobDefinition()
        {
            return Help.SafeCreate<NewAzureHDInsightPigJobDefinitionCommand>();
        }

        public INewAzureHDInsightSqoopJobDefinitionCommand CreateNewSqoopDefinition()
        {
            return Help.SafeCreate<NewAzureHDInsightSqoopJobDefinitionCommand>();
        }

        public INewAzureHDInsightStreamingJobDefinitionCommand CreateNewStreamingMapReduceDefinition()
        {
            return Help.SafeCreate<NewAzureHDInsightStreamingJobDefinitionCommand>();
        }

        public ISetAzureHDInsightClusterSizeCommand CreateSetClusterSize()
        {
            return Help.SafeCreate<SetAzureHdInsightClusterSizeCommand>();
        }
        
        public ISetAzureHDInsightDefaultStorageCommand CreateSetDefaultStorage()
        {
            return Help.SafeCreate<SetAzureHDInsightDefaultStorageCommand>();
        }

        public IStartAzureHDInsightJobCommand CreateStartJob()
        {
            return Help.SafeCreate<StartAzureHDInsightJobCommand>();
        }

        public IStopAzureHDInsightJobCommand CreateStopJob()
        {
            return Help.SafeCreate<StopAzureHDInsightJobCommand>();
        }

        public IUseAzureHDInsightClusterCommand CreateUseCluster()
        {
            return Help.SafeCreate<UseAzureHDInsightClusterCommand>();
        }

        public IWaitAzureHDInsightJobCommand CreateWaitJobs()
        {
            return Help.SafeCreate<WaitAzureHDInsightJobCommand>();
        }
    }
}
