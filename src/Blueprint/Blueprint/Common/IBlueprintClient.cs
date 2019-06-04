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

using Microsoft.Azure.Commands.Blueprint.Models;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Blueprint.Models;

namespace Microsoft.Azure.Commands.Blueprint.Common
{
    public interface IBlueprintClient
    {
        PSBlueprint GetBlueprint(string scope, string blueprintName);

        IEnumerable<PSBlueprint> ListBlueprints(string scope);

        IEnumerable<PSBlueprint> ListBlueprints(List<string> scopes);

        PSPublishedBlueprint GetPublishedBlueprint(string scope, string blueprintName, string version);

        PSPublishedBlueprint GetLatestPublishedBlueprint(string scope, string blueprintName);

        IEnumerable<PSBlueprintAssignment> ListBlueprintAssignments(string subscriptionId);

        PSBlueprintAssignment GetBlueprintAssignment(string subscriptionId, string blueprintAssignmentName);

        PSBlueprintAssignment DeleteBlueprintAssignment(string subscriptionId, string blueprintAssignmentName);

        PSBlueprintAssignment CreateOrUpdateBlueprintAssignment(string subscriptionId, string assignmentName, Assignment assignment);

        PSWhoIsBlueprintContract GetBlueprintSpnObjectId(string scope, string assignmentName);
    }
}
