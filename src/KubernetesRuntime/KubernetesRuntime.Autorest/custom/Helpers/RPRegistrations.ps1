$KubernetesRuntimeRPNamespace = "Microsoft.KubernetesRuntime"
$SubscriptionContributorRoleId = "b24988ac-6180-42a0-ab88-20f7382dd24c"
$SubscriptionOwnerRoleId = "8e3af657-a8ff-443c-a75c-2fe8c4bcb635"
$AuthorizationRpNamespace = "Microsoft.Authorization"

function CheckRPRegistration {
    [Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${ResourceId}
    )

    process {
        $resources = Get-Module Az.Resources -ListAvailable
        if ($null -eq $resources) {
            Write-Error "Missing required module(s): Az.Resources. Please run 'Install-Module Az.Resources -Repository PSGallery' to install Az.Resources."
            return
        }

        Import-Module Az.Resources

        # Check if the RP is registered
        $rp_registration = $(Get-AzResourceProvider -ProviderNamespace $KubernetesRuntimeRPNamespace)

        $subscription_id = $ResourceId.Split('/')[2]

        if ($rp_registration[0].RegistrationState -eq "Registered") {
            Write-Output "Kubernetes Runtime RP has been registered in subscription $subscription_id"
            return
        }

        Write-Output "Registering Kubernetes Runtime RP in subscription $subscription_id..."

        # Get object id for the user in the tenant
        $user_object_id = (Get-AzADUser -SignedIn).Id

        # Check for role assignments
        
        $role_assignments = Get-AzRoleAssignment -Scope "/subscriptions/$subscription_id" -ObjectId $user_object_id | Where-Object { ($_.RoleDefinitionId -eq $SubscriptionContributorRoleId) -or ($_.RoleDefinitionId -eq $SubscriptionOwnerRoleId) } 

        if ($role_assignments.Count -gt 0) {
            # TODO Wait for RP registration.
            Register-AzResourceProvider -ProviderNamespace $KubernetesRuntimeRPNamespace
            Write-Output "Kubernetes Runtime RP has been registered successfully in subscription $subscription_id."
        }
        else {
            throw "You do not have the required permissions to register the Kubernetes Runtime RP in subscription $subscription_id. Please contact your subscription owner or administrator."
        }


    }

}