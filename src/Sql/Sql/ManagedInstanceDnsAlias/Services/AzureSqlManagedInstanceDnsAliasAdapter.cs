using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Model;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ManagedInstanceDnsAlias.Services
{
    public class AzureSqlManagedInstanceDnsAliasAdapter
    {
        /// <summary>
        /// Gets or sets the AzureEndpointsCommunicator which has all the needed management clients
        /// </summary>
        private AzureSqlManagedInstanceDnsAliasCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        public AzureSqlManagedInstanceDnsAliasAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlManagedInstanceDnsAliasCommunicator(Context);
        }

        /// <summary>
        /// Gets a managed instance dns alias
        /// </summary>
        public AzureSqlManagedInstanceDnsAliasModel GetManagedInstanceDnsAlias(string resourceGroup, string managedInstanceName, string managedInstanceDnsAliasName)
        {
            var resp = Communicator.Get(resourceGroup, managedInstanceName, managedInstanceDnsAliasName);
            return CreateManagedInstanceDnsAliasModelFromResponse(resourceGroup, managedInstanceName, resp);
        }

        /// <summary>
        /// Lists managed instance dns aliases on managed instance
        /// </summary>
        public List<AzureSqlManagedInstanceDnsAliasModel> ListManagedInstanceDnsAliases(string resourceGroup, string managedInstanceName)
        {
            var resp = Communicator.List(resourceGroup, managedInstanceName);
            return resp.Select(s =>
            {
                return CreateManagedInstanceDnsAliasModelFromResponse(resourceGroup, managedInstanceName, s);
            }).ToList();
        }

        /// <summary>
        /// Upsert managed instance dns alias
        /// </summary>
        public AzureSqlManagedInstanceDnsAliasModel UpsertManagedInstanceDnsAlias(AzureSqlManagedInstanceDnsAliasModel model, bool? createDnsRecord)
        {
            ManagedServerDnsAliasCreation parameters = new ManagedServerDnsAliasCreation(createDnsRecord.GetValueOrDefault());
            var resp = Communicator.CreateOrUpdate(model.ResourceGroupName, model.ManagedInstanceName, model.DnsAliasName, parameters);

            return CreateManagedInstanceDnsAliasModelFromResponse(model.ResourceGroupName, model.ManagedInstanceName, resp);
        }

        /// <summary>
        /// Removes a managed instance dns alias
        /// </summary>
        public void RemoveManagedInstanceDnsAlias(string resourceGroup, string managedInstanceName, string managedInstanceDNSAliasName)
        {
            Communicator.Remove(resourceGroup, managedInstanceName, managedInstanceDNSAliasName);
        }

        /// <summary>
        /// Acquire managed instance dns alias from one managed instance and points it to another
        /// </summary>
        public AzureSqlManagedInstanceDnsAliasModel AcquireManagedInstanceDnsAlias(string resourceGroup, string managedInstanceName, string managedInstanceDNSAliasName, ManagedServerDnsAliasAcquisition parameters)
        {
            var resp = Communicator.Acquire(resourceGroup, managedInstanceName, managedInstanceDNSAliasName, parameters);
            return CreateManagedInstanceDnsAliasModelFromResponse(resourceGroup, managedInstanceName, resp);
        }

        /// <summary>
        /// Create managed instance dns alias model from response
        /// </summary>
        /// <param name="resourceGroup">Resource group</param>
        /// <param name="managedInstanceName">Managed instance name</param>
        /// <param name="resp">Response</param>
        /// <returns></returns>
        private static AzureSqlManagedInstanceDnsAliasModel CreateManagedInstanceDnsAliasModelFromResponse(string resourceGroup, string managedInstanceName, ManagedServerDnsAlias resp)
        {
            AzureSqlManagedInstanceDnsAliasModel managedInstanceDnsAliasModel = new AzureSqlManagedInstanceDnsAliasModel();

            managedInstanceDnsAliasModel.Id = resp.Id;
            managedInstanceDnsAliasModel.ResourceGroupName = resourceGroup;
            managedInstanceDnsAliasModel.ManagedInstanceName = managedInstanceName;
            managedInstanceDnsAliasModel.DnsAliasName = resp.Name;
            managedInstanceDnsAliasModel.AzureDnsRecord = resp.AzureDnsRecord;
            managedInstanceDnsAliasModel.PublicAzureDnsRecord = resp.PublicAzureDnsRecord;

            return managedInstanceDnsAliasModel;
        }
    }
}
