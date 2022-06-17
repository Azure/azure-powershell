
    # ----------------------------------------------------------------------------------
    #
    # Copyright Microsoft Corporation
    # Licensed under the Apache License, Version 2.0 (the \"License\");
    # you may not use this file except in compliance with the License.
    # You may obtain a copy of the License at
    # http://www.apache.org/licenses/LICENSE-2.0
    # Unless required by applicable law or agreed to in writing, software
    # distributed under the License is distributed on an \"AS IS\" BASIS,
    # WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    # See the License for the specific language governing permissions and
    # limitations under the License.
    # ----------------------------------------------------------------------------------

    <#
    .Synopsis
    Create a in-memory object for EligibleAuthorization
    .Description
    Create a in-memory object for EligibleAuthorization

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.EligibleAuthorization
    .Link
    https://docs.microsoft.com/powershell/module/az.ManagedServices/new-AzManagedServicesEligibleAuthorizationObject
    #>
    function New-AzManagedServicesEligibleAuthorizationObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.EligibleAuthorization')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(HelpMessage="The list of managedByTenant approvers for the eligible authorization.")]
            [Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.IEligibleApprover[]]
            $JustInTimeAccessPolicyManagedByTenantApprover,
            [Parameter(HelpMessage="The maximum access duration in ISO 8601 format for just-in-time access requests.")]
            [System.TimeSpan]
            $JustInTimeAccessPolicyMaximumActivationDuration,
            [Parameter(HelpMessage="The multi-factor authorization provider to be used for just-in-time access requests.")]
            [Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Support.MultiFactorAuthProvider]
            [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Support.MultiFactorAuthProvider])]
            $JustInTimeAccessPolicyMultiFactorAuthProvider,
            [Parameter(Mandatory, HelpMessage="The identifier of the Azure Active Directory principal.")]
            [string]
            $PrincipalId,
            [Parameter(HelpMessage="The display name of the Azure Active Directory principal.")]
            [string]
            $PrincipalIdDisplayName,
            [Parameter(Mandatory, HelpMessage="The identifier of the Azure built-in role that defines the permissions that the Azure Active Directory principal will have on the projected scope.")]
            [string]
            $RoleDefinitionId
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.ManagedServices.Models.Api20200201Preview.EligibleAuthorization]::New()
    
            $Object.JustInTimeAccessPolicyManagedByTenantApprover = $JustInTimeAccessPolicyManagedByTenantApprover

            if ($PSBoundParameters.ContainsKey("JustInTimeAccessPolicyMaximumActivationDuration")) {
                $Object.JustInTimeAccessPolicyMaximumActivationDuration = $JustInTimeAccessPolicyMaximumActivationDuration
            } else {
                $Object.JustInTimeAccessPolicyMaximumActivationDuration = New-TimeSpan -Hours 8
            }

            if ($PSBoundParameters.ContainsKey("JustInTimeAccessPolicyMultiFactorAuthProvider")) {
                $Object.JustInTimeAccessPolicyMultiFactorAuthProvider = $JustInTimeAccessPolicyMultiFactorAuthProvider
            } else {
                $Object.JustInTimeAccessPolicyMultiFactorAuthProvider = 'None'
            }
            $Object.PrincipalId = $PrincipalId
            $Object.PrincipalIdDisplayName = $PrincipalIdDisplayName
            $Object.RoleDefinitionId = $RoleDefinitionId
            return $Object
        }
    }
    
