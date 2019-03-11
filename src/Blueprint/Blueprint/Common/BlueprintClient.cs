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

using Microsoft.Azure.Management.Blueprint.Models;
using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Blueprint;
using BlueprintManagement = Microsoft.Azure.Management.Blueprint;
using Microsoft.Azure.PowerShell.Cmdlets.Blueprint.Properties;
using Microsoft.Rest;

namespace Microsoft.Azure.Commands.Blueprint.Common
{
    public partial class BlueprintClient : IBlueprintClient
    {
        private readonly BlueprintManagement.IBlueprintManagementClient blueprintManagementClient;

        /// <summary>
        /// Construct a BlueprintClient BlueprintManagementClient.
        /// </summary>
        /// <param name="subscription"></param>
        /// <param name="blueprintManagementClient"></param>
        public BlueprintClient(IAzureContext context)
        {
            //Remove our custom api handler if it's in the current session's custom handlers list
            var customHandlers = AzureSession.Instance.ClientFactory.GetCustomHandlers();
            var apiExpandHandler = customHandlers?.Where(handler => handler.GetType().Equals(typeof(ApiExpandHandler))).FirstOrDefault();

            if (apiExpandHandler != null )
            {
                AzureSession.Instance.ClientFactory.RemoveHandler(apiExpandHandler.GetType());
            }

            this.blueprintManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<BlueprintManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);
        }

        public BlueprintClient(IAzureContext context, ApiExpandHandler handler)
        {
            AzureSession.Instance.ClientFactory.AddHandler(handler);

            this.blueprintManagementClient = AzureSession.Instance.ClientFactory.CreateArmClient<BlueprintManagementClient>(context,
                AzureEnvironment.Endpoint.ResourceManager);
        }

        public PSBlueprint GetBlueprint(string scope, string blueprintName)
        {
            var result = blueprintManagementClient.Blueprints.GetWithHttpMessagesAsync(scope, blueprintName)
                .GetAwaiter().GetResult();

            return PSBlueprint.FromBlueprintModel(result.Body, scope);
        }

        public PSBlueprintAssignment GetBlueprintAssignment(string subscriptionId, string blueprintAssignmentName)
        {
            var result = blueprintManagementClient.Assignments.GetWithHttpMessagesAsync(subscriptionId, blueprintAssignmentName).GetAwaiter().GetResult();

            return PSBlueprintAssignment.FromAssignment(result.Body, subscriptionId);
        }

        public PSPublishedBlueprint GetPublishedBlueprint(string scope, string blueprintName, string version)
        {
            var result = blueprintManagementClient.PublishedBlueprints.GetWithHttpMessagesAsync(scope, blueprintName, version).GetAwaiter().GetResult();

            return PSPublishedBlueprint.FromPublishedBlueprintModel(result.Body, scope);
        }

        public PSPublishedBlueprint GetLatestPublishedBlueprint(string scope, string blueprintName)
        {
            PSPublishedBlueprint latest = null;
            var publishedBlueprints = ListPublishedBlueprints(scope, blueprintName);

            foreach (var blueprint in publishedBlueprints)
            {
                if (latest == null)
                    latest = blueprint;
                else if (CompareDates(blueprint.Status.TimeCreated, latest.Status.TimeCreated) > 0)
                    latest = blueprint;
            }

            return latest;
        }

        public IEnumerable<PSBlueprintAssignment> ListBlueprintAssignments(string subscriptionId)
        {
            var assignments = blueprintManagementClient.Assignments.List(subscriptionId);

            foreach (var assignment in assignments.Select(assignment => PSBlueprintAssignment.FromAssignment(assignment, subscriptionId)))
            {
                yield return assignment;
            }

            while (!string.IsNullOrEmpty(assignments.NextPageLink))
            {
                assignments = blueprintManagementClient.Assignments.ListNext(assignments.NextPageLink);
                foreach (var assignment in assignments.Select(assignment => PSBlueprintAssignment.FromAssignment(assignment, subscriptionId)))
                {
                    yield return assignment;
                }
            }
        }

        public IEnumerable<PSBlueprint> ListBlueprints(string scope)
        {
            foreach (var bp in ListBlueprintsInternal(scope))
                yield return bp;

        }

        public IEnumerable<PSBlueprint> ListBlueprints(List<string> scopes)
        {
            foreach (var scope in scopes)
            {
                foreach (var bp in ListBlueprintsInternal(scope))
                    yield return bp;
            }
        }

        private IEnumerable<PSBlueprint> ListBlueprintsInternal(string scope)
        {
            var blueprints = blueprintManagementClient.Blueprints.List(scope);

            foreach (var bp in blueprints.Select(bp => PSBlueprint.FromBlueprintModel(bp, scope)))
            {
                yield return bp;
            }

            while (!string.IsNullOrEmpty(blueprints.NextPageLink))
            {
                blueprints = blueprintManagementClient.Blueprints.ListNext(blueprints.NextPageLink);
                foreach (var bp in blueprints.Select(bp => PSBlueprint.FromBlueprintModel(bp, scope)))
                {
                    yield return bp;
                }
            }
        }    

        private async Task<IEnumerable<PSPublishedBlueprint>> ListPublishedBlueprintsAsync(string scope, string blueprintName)
        {
            var list = new List<PSPublishedBlueprint>();
            var response = await blueprintManagementClient.PublishedBlueprints.ListWithHttpMessagesAsync(scope, blueprintName);

            list.AddRange(response.Body.Select(bp => PSPublishedBlueprint.FromPublishedBlueprintModel(bp, scope)));

            while (response.Body.NextPageLink != null)
            {
                response = await blueprintManagementClient.PublishedBlueprints.ListNextWithHttpMessagesAsync(response.Body.NextPageLink);
                list.AddRange(response.Body.Select(bp => PSPublishedBlueprint.FromPublishedBlueprintModel(bp, scope)));
            }

            return list;
        }

        private IEnumerable<PSPublishedBlueprint> ListPublishedBlueprints(string scope, string blueprintName)
        {
            var list = new List<PSPublishedBlueprint>();

            var publishedBlueprints = blueprintManagementClient.PublishedBlueprints.List(scope, blueprintName);

            list.AddRange(publishedBlueprints.Select(bp => PSPublishedBlueprint.FromPublishedBlueprintModel(bp, scope)));

            while (publishedBlueprints.NextPageLink != null)
            {
                publishedBlueprints = blueprintManagementClient.PublishedBlueprints.ListNext(publishedBlueprints.NextPageLink);
                list.AddRange(publishedBlueprints.Select(bp => PSPublishedBlueprint.FromPublishedBlueprintModel(bp, scope)));
            }

            return list;
        }

        public PSBlueprintAssignment DeleteBlueprintAssignment(string subscriptionId, string blueprintAssignmentName)
        {
            var result = blueprintManagementClient.Assignments.DeleteWithHttpMessagesAsync(subscriptionId, blueprintAssignmentName).GetAwaiter().GetResult();

            if (result.Body == null)
                return null;

            return PSBlueprintAssignment.FromAssignment(result.Body, subscriptionId);
        }

        public PSBlueprintAssignment CreateOrUpdateBlueprintAssignment(string subscriptionId, string assignmentName, Assignment assignment)
        {
            var result = blueprintManagementClient.Assignments.CreateOrUpdateWithHttpMessagesAsync(subscriptionId, assignmentName, assignment).GetAwaiter().GetResult();

            if (result.Body != null)
            {
                return PSBlueprintAssignment.FromAssignment(result.Body, subscriptionId);
            }

            return null;
        }

        /// <summary>
        /// Compare to nullable DateTime objects
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>
        /// An integer value that is less than zero if first is earlier than second, greater than zero if first is later than second,
        /// or equal to zero if first is the same as second.
        /// </returns>
        private static int CompareDates(DateTime? first, DateTime? second)
        {
            if (first == null && second == null)
                return 0;
            else if (first == null)
                return -1;
            else if (second == null)
                return 1;

            return DateTime.Compare(first.Value, second.Value);
        }
    }
}
