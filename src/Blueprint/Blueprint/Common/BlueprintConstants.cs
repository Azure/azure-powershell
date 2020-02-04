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

namespace Microsoft.Azure.Commands.Blueprint.Common
{
    public static class BlueprintConstants
    {
        public const string AzureBlueprintAppId = "f71766dc-90d9-4b7d-bd9d-4499c4331c3f";
        public const string OwnerRoleDefinitionId = "/providers/Microsoft.Authorization/roleDefinitions/8e3af657-a8ff-443c-a75c-2fe8c4bcb635";
        public const string SubscriptionScope = "/subscriptions/{0}";
        public const string ManagementGroupScope = "/providers/Microsoft.Management/managementGroups/{0}";
        public const string BlueprintProviderNamespace = "Microsoft.Blueprint";
        public const string MgAncestorsRequestUrlTemplate = "{0}subscriptions/{1}?api-version=2018-11-01&$expand=ancestors";

        public static class ParameterSetNames
        {
            // Parameter Set names
            public const string SubscriptionScope = "SubscriptionScope";
            public const string BySubscriptionAndName = "BySubscriptionAndName";
            public const string BySubscriptionNameAndVersion = "BySubscriptionNameAndVersion";
            public const string BySubscriptionNameAndLatestPublished = "BySubscriptionNameAndLatestPublished";

            public const string ManagementGroupScope = "ManagementGroupScope";
            public const string ByManagementGroupAndName = "ByManagementGroupAndName";
            public const string ByManagementGroupNameAndVersion = "ByManagementGroupNameAndVersion";
            public const string ByManagementGroupNameAndLatestPublished = "ByManagementGroupNameAndLatestPublished";

            public const string BlueprintAssignmentsBySubscription = "BlueprintAssignmentsBySubscription";
            public const string BlueprintAssignmentByName = "BlueprintAssignmentByName";
            public const string CreateBlueprintAssignment = "CreateBlueprintAssignment";
            public const string CreateBlueprintAssignmentByFile = "CreateBlueprintAssignmentByFile";
            public const string DeleteBlueprintAssignmentByName = "DeleteBlueprintAssignmentByName";
            public const string DeleteBlueprintAssignmentByObject = "DeleteBlueprintAssignmentByObject";

            public const string UpdateBlueprintAssignment = "UpdateBlueprintAssignment";
            public const string UpdateBlueprintAssignmentByFile = "UpdateBlueprintAssignmentByFile";

            public const string PublishBlueprint = "PublishBlueprint";

            public const string ArtifactsByBlueprint = "ArtifactsByBlueprint";

            public const string CreatePolicyAssignmentArtifact = "CreatePolicyArtifact";
            public const string CreateRoleAssignmentArtifact = "CreateRoleAssignmentArtifact";
            public const string CreateTemplateArtifact = "CreateTemplateArtifact";
            public const string CreateArtifactByInputFile = "CreateArtifactByInputFile";

            public const string CreateBlueprintBySubscription = "CreateBlueprintBySubscription";
            public const string CreateBlueprintByManagementGroup = "CreateBlueprintByManagementGroup";

            public const string UpdatePolicyAssignmentArtifact = "UpdatePolicyAssignmentArtifact";
            public const string UpdateRoleAssignmentArtifact = "UpdateRoleAssignmentArtifact";
            public const string UpdateTemplateArtifact = "UpdateTemplateArtifact";
            public const string UpdateArtifactByInputFile = "UpdateArtifactByInputFile";

            public const string UpdateBlueprintBySubscription = "UpdateBlueprintBySubscription";
            public const string UpdateBlueprintByManagementGroup = "UpdateBlueprintByManagementGroup";

            public const string ExportBlueprintParameterSet = "ExportToFile";
            public const string ImportBlueprintParameterSet = "ImportBlueprint";



        }

        public static class ParameterHelpMessages
        {
            public const string DefinitionSubscriptionId = "Subscription Id where the blueprint definition is or will be saved.";
            public const string AssignmentSubscriptionId = "Subscription Id the blueprint assignment is deployed to.";
            public const string BlueprintAssignmentName = "Blueprint assignment name.";
            public const string BlueprintAssignmentObject = "Blueprint assignment object.";
            public const string BlueprintObject = "Blueprint object.";
            public const string DefinitionManagementGroupId = "Management Group Id where the blueprint definition is or will be saved.";
            public const string BlueprintDefinitionName = "Blueprint definition name.";
            public const string BlueprintDefinitionVersion = "Published blueprint definition version.";
            public const string BlueprintDefinitionVersionToPublish = "Version for the blueprint definition.";
            public const string LatestPublishedFlag = "The latest published blueprint definition flag. When set, execution returns the latest published version of the blueprint definition.";
            public const string SubscriptionIdToAssign = "SubscriptionId to assign the Blueprint. Can be a comma delimited list of subscriptionId strings.";
            public const string Location = "Region for managed identity to be created in. Learn more at aka.ms/blueprintmsi";
            public const string Parameters = "Collection of key/value pairs for parameters and their corresponding values.";
            public const string LockFlag = "Lock resources. Learn more at aka.ms/blueprintlocks";
            public const string CurrentLevel = "Flag to denote if current management group level or subscription to be used for the query.";
            public const string SystemAssignedIdentity = "System assigned identity(MSI) to deploy the artifacts.";
            public const string UserAssignedIdentity = "User assigned identity(MSI) to deploy the artifacts.";
            public const string SecureString = "Secure string parameter for KeyVault resource id, name and version.";
            public const string ArtifactName = "Name of the artifact";
            public const string ArtifactType = "Type of the artifact. There are 3 types supported: RoleAssignmentArtifact, PolicyAssignmentArtifact, TemplateArtifact.";
            public const string ArtifactDescription = "Description of the artifact.";
            public const string ArtifactDependsOn = "List of the names of artifacts that needs to be created before current artifact is created.";
            public const string ArtifactPolicyDefinitionId = "Definition Id of the policy definition.";
            public const string ArtifactPolicyDefinitionParameter = "Hashtable of parameters to pass to the policy definition artifact.";
            public const string ArtifactRoleDefinitionId = "List of role definition";
            public const string ArtifactRoleDefinitionPrincipalId = "List of role definition principal ids.";
            public const string ArtifactTemplateFile = "Location of the ARM template file on disk.";
            public const string ArtifactTemplateParameterFile = "Location of the ARM template parameter file on disk.";
            public const string ArtifactFile = "Location of the artifact file in JSON format on disk.";
            public const string ArtifactResourceGroup = "Name of the resource group the artifact is going to be under.";
            public const string ExportBlueprintObject = "The Blueprint definition object to export.";
            public const string ExportOutputFile = "Path to a file on disk where to export the Blueprint definition in JSON format.";
            public const string ForceHelpMessage = "When set to true, execution will not ask for a confirmation.";
            public const string ImportInputPath = "Path to a Blueprint JSON file on disk.";
            public const string ImportIncludeSubFolders = "If sub folders should be included.";
            public const string ChangeNotes = "Notes to describe the contents of this blueprint version.";
        }
    }
}
