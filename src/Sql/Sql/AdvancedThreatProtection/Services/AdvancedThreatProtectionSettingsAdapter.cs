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

using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Model;
using Microsoft.Azure.Commands.Sql.Common;
using Microsoft.Azure.Management.Sql.Models;
using System;

namespace Microsoft.Azure.Commands.Sql.AdvancedThreatProtection.Services
{
    /// <summary>
    /// The SqlThreatDetectionAdapter class is responsible for transforming the data that was received form the endpoints to the cmdlets model of auditing policy and vice versa
    /// </summary>
    public class AdvancedThreatProtectionSettingsAdapter
    {
        /// <summary>
        /// The endpoint communicator used by this adapter.
        /// </summary>
        private AdvancedThreatProtectionSettingsCommunicator Communicator { get; set; }

        /// <summary>
        /// The Azure endpoints communicator used by this adapter.
        /// </summary>
        private AzureEndpointsCommunicator AzureCommunicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public AdvancedThreatProtectionSettingsAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AdvancedThreatProtectionSettingsCommunicator(Context);
            AzureCommunicator = new AzureEndpointsCommunicator(Context);
        }

        /// <summary>
        /// Gets a server Advanced Threat Protection Model for the given server.
        /// </summary>
        /// <param name="resourceGroup">The resource group of the server.</param>
        /// <param name="serverName">The name of the server.</param>
        /// <returns>A ServerAdvancedThreatProtectionSettingsModel.</returns>
        public ServerAdvancedThreatProtectionSettingsModel GetServerAdvancedThreatProtectionSettings(string resourceGroup, string serverName)
        {
            ServerAdvancedThreatProtection threatProtectionSettings = Communicator.GetServerAdvancedThreatProtection(resourceGroup, serverName);
            return new ServerAdvancedThreatProtectionSettingsModel()
            {
                ResourceGroupName = resourceGroup,
                ServerName = serverName,
                AdvancedThreatProtectionState = ModelizeAdvancedThreatProtectionState(threatProtectionSettings.State.ToString())
            };
        }

        /// <summary>
        /// Gets a database Advanced Threat Protection Model for the given database.
        /// </summary>
        /// <param name="resourceGroup">The resource group of the database.</param>
        /// <param name="serverName">The name of the server of the database.</param>
        /// <param name="databaseName">The name of the database.</param>
        /// <returns>A DatabaseAdvancedThreatProtectionSettingsModel.</returns>
        public DatabaseAdvancedThreatProtectionSettingsModel GetDatabaseAdvancedThreatProtectionSettings(string resourceGroup, string serverName, string databaseName)
        {
            DatabaseAdvancedThreatProtection threatProtectionSettings = Communicator.GetDatabaseAdvancedThreatProtection(resourceGroup, serverName, databaseName);
            return new DatabaseAdvancedThreatProtectionSettingsModel()
            {
                ResourceGroupName = resourceGroup,
                ServerName = serverName,
                DatabaseName = databaseName,
                AdvancedThreatProtectionState = ModelizeAdvancedThreatProtectionState(threatProtectionSettings.State.ToString())
            };
        }

        /// <summary>
        /// Gets a managed instance Advanced Threat Protection Model for the given managed instance.
        /// </summary>
        /// <param name="resourceGroup">The resource group of the managed instance.</param>
        /// <param name="instanceName">The name of the managed instance.</param>
        /// <returns>A ManagedInstanceAdvancedThreatProtectionSettingsModel.</returns>
        public ManagedInstanceAdvancedThreatProtectionSettingsModel GetManagedInstanceAdvancedThreatProtectionSettings(string resourceGroup, string instanceName)
        {
            ManagedInstanceAdvancedThreatProtection threatProtectionSettings = Communicator.GetManagedInstanceAdvancedThreatProtection(resourceGroup, instanceName);
            return new ManagedInstanceAdvancedThreatProtectionSettingsModel()
            {
                ResourceGroupName = resourceGroup,
                ManagedInstanceName = instanceName,
                AdvancedThreatProtectionState = ModelizeAdvancedThreatProtectionState(threatProtectionSettings.State.ToString())
            };
        }

        /// <summary>
        /// Gets a managed database Advanced Threat Protection Model for the given managed database.
        /// </summary>
        /// <param name="resourceGroup">The resource group of the managed database.</param>
        /// <param name="instanceName">The name of the managed instance.</param>
        /// <param name="databaseName">The name of the managed database.</param>
        /// <returns>A ManagedDatabaseAdvancedThreatProtectionSettingsModel.</returns>
        public ManagedDatabaseAdvancedThreatProtectionSettingsModel GetManagedDatabaseAdvancedThreatProtectionSettings(string resourceGroup, string instanceName, string databaseName)
        {
            ManagedDatabaseAdvancedThreatProtection threatProtectionSettings = Communicator.GetManagedDatabaseAdvancedThreatProtection(resourceGroup, instanceName, databaseName);
            return new ManagedDatabaseAdvancedThreatProtectionSettingsModel()
            {
                ResourceGroupName = resourceGroup,
                ManagedInstanceName = instanceName,
                ManagedDatabaseName = databaseName,
                AdvancedThreatProtectionState = ModelizeAdvancedThreatProtectionState(threatProtectionSettings.State.ToString())
            };
        }

        /// <summary>
        /// Transforms the given settings state in a string form to its cmdlet model representation.
        /// </summary>
        private static AdvancedThreatProtectionStateType ModelizeAdvancedThreatProtectionState(string advancedThreatProtectionState)
        {
            AdvancedThreatProtectionStateType value;
            Enum.TryParse(advancedThreatProtectionState, true, out value);
            return value;
        }

        /// <summary>
        /// Sets a server Advanced Threat Protection Model.
        /// </summary>
        /// <param name="model">The server Advanced Threat Protection Model.</param>
        public void SetServerAdvancedThreatProtectionSettings(ServerAdvancedThreatProtectionSettingsModel model)
        {
            ServerAdvancedThreatProtection threatProtectionSettings = new ServerAdvancedThreatProtection()
            {
                State = model.AdvancedThreatProtectionState == AdvancedThreatProtectionStateType.Enabled ? AdvancedThreatProtectionState.Enabled : AdvancedThreatProtectionState.Disabled,
            };
            Communicator.SetServerAdvancedThreatProtection(model.ResourceGroupName, model.ServerName, threatProtectionSettings);
        }

        /// <summary>
        /// Sets a database Advanced Threat Protection Model.
        /// </summary>
        /// <param name="model">The database Advanced Threat Protection Model.</param>
        public void SetDatabaseAdvancedThreatProtectionSettings(DatabaseAdvancedThreatProtectionSettingsModel model)
        {
            DatabaseAdvancedThreatProtection threatProtectionSettings = new DatabaseAdvancedThreatProtection()
            {
                State = model.AdvancedThreatProtectionState == AdvancedThreatProtectionStateType.Enabled ? AdvancedThreatProtectionState.Enabled : AdvancedThreatProtectionState.Disabled,
            };
            Communicator.SetDatabaseAdvancedThreatProtection(model.ResourceGroupName, model.ServerName, model.DatabaseName, threatProtectionSettings);
        }

        /// <summary>
        /// Sets a managed instance Advanced Threat Protection Model.
        /// </summary>
        /// <param name="model">The managed instance Advanced Threat Protection Model.</param>
        public void SetManagedInstanceAdvancedThreatProtectionSettings(ManagedInstanceAdvancedThreatProtectionSettingsModel model)
        {
            ManagedInstanceAdvancedThreatProtection threatProtectionSettings = new ManagedInstanceAdvancedThreatProtection()
            {
                State = model.AdvancedThreatProtectionState == AdvancedThreatProtectionStateType.Enabled ? AdvancedThreatProtectionState.Enabled : AdvancedThreatProtectionState.Disabled,
            };
            Communicator.SetManagedInstanceAdvancedThreatProtection(model.ResourceGroupName, model.ManagedInstanceName, threatProtectionSettings);
        }

        /// <summary>
        /// Sets a managed database Advanced Threat Protection Model.
        /// </summary>
        /// <param name="model">The managed database Advanced Threat Protection Model.</param>
        public void SetManagedDatabaseAdvancedThreatProtectionSettings(ManagedDatabaseAdvancedThreatProtectionSettingsModel model)
        {
            ManagedDatabaseAdvancedThreatProtection threatProtectionSettings = new ManagedDatabaseAdvancedThreatProtection()
            {
                State = model.AdvancedThreatProtectionState == AdvancedThreatProtectionStateType.Enabled ? AdvancedThreatProtectionState.Enabled : AdvancedThreatProtectionState.Disabled,
            };
            Communicator.SetManagedDatabaseAdvancedThreatProtection(model.ResourceGroupName, model.ManagedInstanceName, model.ManagedDatabaseName, threatProtectionSettings);
        }
    }
}
