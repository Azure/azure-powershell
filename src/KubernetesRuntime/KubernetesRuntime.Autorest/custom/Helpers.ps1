$KubernetesRuntimeRPNamespace = "Microsoft.KubernetesRuntime"
$SubscriptionContributorRoleId = "b24988ac-6180-42a0-ab88-20f7382dd24c"
$SubscriptionOwnerRoleId = "8e3af657-a8ff-443c-a75c-2fe8c4bcb635"
$KubernetesRuntimeFpaAppId = "087fca6e-4606-4d41-b3f6-5ebdf75b8b4c"

# https://learn.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#kubernetes-extension-contributor
$KUBERNETES_EXTENSION_CONTRIBUTOR_ROLE_ID = "85cb6faf-e071-4c9b-8136-154b5a04f717"
$STORAGE_CLASS_CONTRIBUTOR_ROLE_ID = "0cd9749a-3aaf-4ae5-8803-bd217705bf3b"



function ImportModule {
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${ModuleName}
    )

    process {
        $module = Get-Module -ListAvailable -Name $ModuleName

        if ($null -eq $module) {
            throw "Missing required module(s): $ModuleName. Please run 'Install-Module $ModuleName -Repository PSGallery' to install $ModuleName."
        }

        Import-Module $ModuleName
    }



}

# Requires Az.Resources to be loaded
function CheckRPRegistration {
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${SubscriptionId}
    )

    process {

        # Check if the RP is registered
        $rp_registration = $(Get-AzResourceProvider -ProviderNamespace $KubernetesRuntimeRPNamespace)

        if ($rp_registration[0].RegistrationState -eq "Registered") {
            Write-Output "Kubernetes Runtime RP has been registered in subscription $SubscriptionId"
            return
        }

        Write-Output "Registering Kubernetes Runtime RP in subscription $SubscriptionId..."

        # Get object id for the user in the tenant
        $user_object_id = (Get-AzADUser -SignedIn).Id

        # Check for role assignments
        
        $role_assignments = Get-AzRoleAssignment -Scope "/subscriptions/$SubscriptionId" -ObjectId $user_object_id | Where-Object { ($_.RoleDefinitionId -eq $SubscriptionContributorRoleId) -or ($_.RoleDefinitionId -eq $SubscriptionOwnerRoleId) } 

        if ($role_assignments.Count -gt 0) {
            # TODO Wait for RP registration.
            Register-AzResourceProvider -ProviderNamespace $KubernetesRuntimeRPNamespace
            Write-Output "Kubernetes Runtime RP has been registered successfully in subscription $SubscriptionId."
        }
        else {
            throw "You do not have the required permissions to register the Kubernetes Runtime RP in subscription $SubscriptionId. Please contact your subscription owner or administrator."
        }


    }

}

class ConnectedClusterResourceId {
    [string] $SubscriptionId
    [string] $ResourceGroup
    [string] $ClusterName

    ConnectedClusterResourceId([string] $subscriptionId, [string] $resourceGroup, [string] $clusterName) {
        $this.SubscriptionId = $subscriptionId
        $this.ResourceGroup = $resourceGroup
        $this.ClusterName = $clusterName
    }

    [string] ToString() {
        return "/subscriptions/$($this.SubscriptionId)/resourceGroups/$($this.ResourceGroup)/providers/Microsoft.Kubernetes/connectedClusters/$($this.ClusterName)"
    }

    static [ConnectedClusterResourceId] Parse([string] $resourceId) {

        if (-not $ResourceId.StartsWith('/subscriptions/')) {
            throw "Invalid resource id. The resource id must start with '/subscriptions/'."
        }

        $resource_id_parts = $resourceId.Split('/')
        $subscription_id = $resource_id_parts[2]
        $resource_group = $resource_id_parts[4]
        $cluster_name = $resource_id_parts[8]

        return [ConnectedClusterResourceId]::new($subscription_id, $resource_group, $cluster_name)
    }
}

function QueryRpObjectId {

    process {
        $sp = Get-AzADServicePrincipal -ApplicationId $KubernetesRuntimeFpaAppId

        if ($null -eq $sp) {
            throw "Failed to find the service principal with application id $KubernetesRuntimeFpaAppId. Please check if Kubernetes Runtime RP is registered in the tenant."
        }

        return $sp.Id
    }

}
