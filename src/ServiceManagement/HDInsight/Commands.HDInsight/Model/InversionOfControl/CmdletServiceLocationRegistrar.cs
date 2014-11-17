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
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.BaseCommandInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Commands.CommandImplementations;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.BaseInterfaces;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.GetAzureHDInsightClusters.Extensions;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.Logging;
using Microsoft.WindowsAzure.Management.HDInsight.Cmdlet.ServiceLocation;
using Microsoft.WindowsAzure.Management.HDInsight.Logging;

namespace Microsoft.WindowsAzure.Management.HDInsight.Cmdlet
{
    /// <summary>
    ///     Registers Cmdlet services with the IoC system.
    /// </summary>
    internal class CmdletServiceLocationRegistrar : IServiceLocationRegistrar
    {
        /// <inheritdoc />
        public void Register(IServiceLocationRuntimeManager manager, IServiceLocator locator)
        {
            if (manager.IsNull())
            {
                throw new ArgumentNullException("manager");
            }

            manager.RegisterType<IAzureHDInsightCommandFactory, AzureHDInsightCommandFactory>();
            manager.RegisterType<IAzureHDInsightConnectionSessionManagerFactory, AzureHDInsightConnectionSessionManagerFactory>();
            manager.RegisterType<IBufferingLogWriterFactory, PowershellLogWriterFactory>();
            manager.RegisterType<IAzureHDInsightSubscriptionResolverFactory, AzureHDInsightSubscriptionResolverFactory>();
            manager.RegisterType<IAzureHDInsightStorageHandlerFactory, AzureHDInsightStorageHandlerFactory>();
            manager.RegisterType<IAzureHDInsightClusterManagementClientFactory, AzureHDInsightClusterManagementClientFactory>();
            manager.RegisterType<IAzureHDInsightJobSubmissionClientFactory, AzureHDInsightJobSubmissionClientFactory>();
        }
    }
}
