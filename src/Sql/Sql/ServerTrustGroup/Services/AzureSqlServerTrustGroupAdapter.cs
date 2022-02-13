using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Internal;
using System.Text;

namespace Microsoft.Azure.Commands.Sql.ServerTrustGroup.Services
{
    /// <summary>
    /// Adapter for Server Trust Group operations
    /// </summary>
    public class AzureSqlServerTrustGroupAdapter
    {
        private AzureSqlServerTrustGroupCommunicator Communicator { get; set; }

        /// <summary>
        /// Gets or sets the Azure profile
        /// </summary>
        public IAzureContext Context { get; set; }

        /// <summary>
        /// Constructs a database adapter
        /// </summary>
        public AzureSqlServerTrustGroupAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerTrustGroupCommunicator(Context);
        }

        /// <summary>
        /// A wrapper method for getting the specified Server Trust Group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name of Server Trust Group.</param>
        /// <param name="locationName">The location of Server Trust Group that is to be received.</param>
        /// <param name="serverTrustGroupName">The name of the server Trust Group that is to be received.</param>
        public AzureSqlServerTrustGroupModel GetServerTrustGroup(string resourceGroupName, string locationName, string serverTrustGroupName)
        {
            var res = Communicator.Get(resourceGroupName, locationName, serverTrustGroupName);
            return CreateServerTrustGroupModelFromResponse(res);
        }

        /// <summary>
        /// A wrapper method for getting all Server Trust Groups that have specified Managed Instance as a member.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name of Server Trust Groups.</param>
        /// <param name="managedInstanceName">Managed Instance name of all Server Trust Groups that contain it.</param>
        public List<AzureSqlServerTrustGroupModel> ListServerTrustGroupsByInstance(string resourceGroupName, string managedInstanceName)
        {
            IPage<Management.Sql.Models.ServerTrustGroup> entities = Communicator.ListGroupsByInstance(resourceGroupName, managedInstanceName);
            List<AzureSqlServerTrustGroupModel> models = new List<AzureSqlServerTrustGroupModel>();
            foreach(Management.Sql.Models.ServerTrustGroup entity in entities)
            {
                models.Add(CreateServerTrustGroupModelFromResponse(entity));
            }

            return models;
        }

        /// <summary>
        /// A wrapper method for getting all Server Trust Groups from a specified location.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name of Server Trust Groups.</param>
        /// <param name="location">The location of Server Trust Groups that are to be received.</param>
        public List<AzureSqlServerTrustGroupModel> ListServerTrustGroupsByLocation(string resourceGroupName, string location)
        {
            IPage<Management.Sql.Models.ServerTrustGroup> entities = Communicator.ListGroupsByLocation(resourceGroupName, location);
            List<AzureSqlServerTrustGroupModel> models = new List<AzureSqlServerTrustGroupModel>();
            foreach (Management.Sql.Models.ServerTrustGroup entity in entities)
            {
                models.Add(CreateServerTrustGroupModelFromResponse(entity));
            }

            return models;
        }

        /// <summary>
        /// A wrapper method for creating a Server Trust Group.
        /// </summary>
        /// <param name="model">Model that is passed from cmdlets.</param>
        /// <returns></returns>
        public AzureSqlServerTrustGroupModel CreateServerTrustGroup(AzureSqlServerTrustGroupModel model)
        {
            Management.Sql.Models.ServerTrustGroup parameters = new Management.Sql.Models.ServerTrustGroup();
            parameters.GroupMembers = new List<ServerInfo>();
            parameters.TrustScopes = model.TrustScope;
            foreach(string member in model.GroupMember)
            {
                parameters.GroupMembers.Add(new ServerInfo(member));
            }

            var res = Communicator.Create(model.ResourceGroupName, model.Location, model.Name, parameters);
            return CreateServerTrustGroupModelFromResponse(res);
        }

        /// <summary>
        /// A wrapper method for deleting a Server Trust Group.
        /// </summary>
        /// <param name="resourceGroupName">Resource group name of the Server Trust Group.</param>
        /// <param name="locationName">The location of the Server Trust Group.</param>
        /// <param name="serverTrustGroupName">The name of the Server Trust Group</param>
        public void DeleteServerTrustGroup(string resourceGroupName, string locationName, string serverTrustGroupName)
        {
            Communicator.Delete(resourceGroupName, locationName, serverTrustGroupName);
        }

        /// <summary>
        /// Creates a model that will be used in Cmdlets from .NET client model.
        /// </summary>
        /// <param name="serverTrustGroup">Object of the .NET client.</param>
        private AzureSqlServerTrustGroupModel CreateServerTrustGroupModelFromResponse(Management.Sql.Models.ServerTrustGroup serverTrustGroup)
        {
            AzureSqlServerTrustGroupModel model = new AzureSqlServerTrustGroupModel();

            model.Name = serverTrustGroup.Name;
            model.Id = serverTrustGroup.Id;
            model.ResourceGroupName = GetUriSegment(serverTrustGroup.Id, 4);
            model.Location = GetUriSegment(serverTrustGroup.Id, 8);
            model.GroupMember = serverTrustGroup.GroupMembers.Select(member => member.ServerId).ToList();
            model.TrustScope = serverTrustGroup.TrustScopes;

            return model;
        }

        /// <summary>
        /// Helper method to get part of the uri.
        /// </summary>
        /// <param name="uri">Uri that should be processed.</param>
        /// <param name="segmentNum">Segment number that should be retrieved from uri.</param>
        private string GetUriSegment(string uri, int segmentNum)
        {
            if (uri != null)
            {
                var segments = uri.Split('/');

                if (segments.Length > segmentNum)
                {
                    return segments[segmentNum];
                }
            }

            return null;
        }
    }
}
