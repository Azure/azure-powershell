using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Sql.ServerTrustGroup.Model;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="profile">The current azure profile</param>
        /// <param name="subscription">The current azure subscription</param>
        public AzureSqlServerTrustGroupAdapter(IAzureContext context)
        {
            Context = context;
            Communicator = new AzureSqlServerTrustGroupCommunicator(Context);
        }

        public AzureSqlServerTrustGroupModel GetServerTrustGroup(string resourceGroupName, string locationName, string serverTrustGroupName)
		{
            var res = Communicator.Get(resourceGroupName, locationName, serverTrustGroupName);
            return CreateServerTrustGroupModelFromResponse(res);
		}

        public List<AzureSqlServerTrustGroupModel> ListServerTrustGrousByInstance(string resourceGroupName, string serverTrustGroupName)
		{
            IPage<Management.Sql.Models.ServerTrustGroup> entities = Communicator.ListGroupsByInstance(resourceGroupName, serverTrustGroupName);
            List<AzureSqlServerTrustGroupModel> models = new List<AzureSqlServerTrustGroupModel>();
            foreach(Management.Sql.Models.ServerTrustGroup entity in entities)
			{
                models.Add(CreateServerTrustGroupModelFromResponse(entity));
			}

            return models;
		}

        public List<AzureSqlServerTrustGroupModel> ListServerTrustGrousByLocation(string resourceGroupName, string location)
		{
            IPage<Management.Sql.Models.ServerTrustGroup> entities = Communicator.ListGroupsByLocation(resourceGroupName, location);
            List<AzureSqlServerTrustGroupModel> models = new List<AzureSqlServerTrustGroupModel>();
            foreach (Management.Sql.Models.ServerTrustGroup entity in entities)
            {
                models.Add(CreateServerTrustGroupModelFromResponse(entity));
            }

            return models;
        }

        public AzureSqlServerTrustGroupModel CreateServerTrustGroup(AzureSqlServerTrustGroupModel model)
		{
            Management.Sql.Models.ServerTrustGroup parameters = new Management.Sql.Models.ServerTrustGroup();
            parameters.GroupMembers = new List<ServerInfo>();
            parameters.TrustScopes = model.TrustScope;
            foreach(String member in model.GroupMembers)
            {
                parameters.GroupMembers.Add(new ServerInfo($"/subscriptions/{Context.Subscription.Id}/resourceGroups/{model.ResourceGroupName}/providers/Microsoft.Sql/managedInstances/{member}"));
            }

            var res = Communicator.Create(model.ResourceGroupName, model.Location, model.Name, parameters);
            return CreateServerTrustGroupModelFromResponse(res);
        }

        public void DeleteServerTrustGroup(string resourceGroupName, string locationName, string serverTrustGroupName)
		{
            Communicator.Delete(resourceGroupName, locationName, serverTrustGroupName);
		}

        private AzureSqlServerTrustGroupModel CreateServerTrustGroupModelFromResponse(Management.Sql.Models.ServerTrustGroup serverTrustGroup)
		{
            AzureSqlServerTrustGroupModel model = new AzureSqlServerTrustGroupModel();

            model.Name = serverTrustGroup.Name;
            model.ResourceGroupName = GetUriSegment(serverTrustGroup.Id, 4);
            model.Location = GetUriSegment(serverTrustGroup.Id, 8);
            model.GroupMembers = serverTrustGroup.GroupMembers.Select(member => member.ServerId).ToList();
            model.TrustScope = serverTrustGroup.TrustScopes;

            return model;
        }

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
