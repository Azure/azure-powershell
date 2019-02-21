
namespace Microsoft.Azure.Commands.Blueprint.Common
{
    public static class BlueprintConstants
    {
        public const string AzureBlueprintAppId = "f71766dc-90d9-4b7d-bd9d-4499c4331c3f";
        public const string OwnerRoleDefinitionId = "/providers/Microsoft.Authorization/roleDefinitions/8e3af657-a8ff-443c-a75c-2fe8c4bcb635";
        public const string SubscriptionScope = "/subscriptions/{0}";
        public const string ManagementGroupScope = "/providers/Microsoft.Management/managementGroups/{0}";
        public const string BlueprintProviderNamespace = "Microsoft.Blueprint";
        public const string MgAncestorsRequestUrlTemplate = "https://management.azure.com/subscriptions/{0}?api-version=2018-11-01&$expand=ancestors";

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
            public const string CreateBlueprintAssignment = "BlueprintAssignment";
            public const string DeleteBlueprintAssignmentByName = "DeleteBlueprintAssignmentByName";
            public const string DeleteBlueprintAssignmentByObject = "DeleteBlueprintAssignmentByObject";
        }

        public static class ParameterHelpMessages
        {
            public const string SubscriptionId = "Subscription Id.";
            public const string BlueprintAssignmentName = "Blueprint assignment name.";
            public const string BlueprintAssignmentObject = "Blueprint assignment object.";
            public const string BlueprintObject = "Blueprint object.";
            public const string ManagementGroupId = "Management Group Id where Blueprint is located.";
            public const string BlueprintDefinitionName = "Blueprint definition name.";
            public const string BlueprintDefinitionVersion = "Blueprint definition version.";
            public const string LatestPublishedFlag = "The latest published Blueprint flag. When set, execution returns the latest published version of Blueprint. Defaults to false.";
            public const string SubscriptionIdToAssign = "SubscriptionId to assign the Blueprint. Can be a comma delimited list of subscriptionId strings.";
            public const string Location = "Region for managed identity to be created in. Learn more at aka.ms/blueprintmsi";
            public const string Parameters = "Collection of key/value pairs for parameters and their corresponding values.";
            public const string LockFlag = "Lock resources. Learn more at aka.ms/blueprintlocks";
            public const string CurrentLevel = "Flag to denote if current management group level or subscription to be used for the query.";
        }
    }
}
