# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a Microsoft Entra ID user on a mongo cluster.
.Description
Create (grant) a Microsoft Entra ID principal access to a mongo cluster by assigning it
database roles. The '-Type' parameter surfaces the Entra principal type; the service models
the identity provider as a discriminated union (identityProvider -> microsoftEntraID ->
principalType) that the generated cmdlet does not flatten, so this wrapper exposes a simple
'-Type' flag and builds the nested request body.
.Example
New-AzDocumentDBUser -Name 11111111-1111-1111-1111-111111111111 -MongoClusterName MyCluster -ResourceGroupName MyResourceGroup -Type User -Role @(@{ Db = 'admin'; Role = 'root' })
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IUser
.Link
https://learn.microsoft.com/powershell/module/az.documentdb/new-azdocumentdbuser
#>
function New-AzDocumentDBUser {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Models.IUser])]
[CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('UserName')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Path')]
    [System.String]
    # The Microsoft Entra object (client) ID of the user or service principal.
    ${Name},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Path')]
    [System.String]
    # The name of the mongo cluster.
    ${MongoClusterName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Path')]
    [System.String]
    # The name of the resource group.
    # The name is case insensitive.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # The ID of the target subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.PSArgumentCompleterAttribute("User", "ServicePrincipal")]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.String]
    # The Microsoft Entra principal type of the user.
    ${Type},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Body')]
    [System.Collections.Hashtable[]]
    # The database roles to assign, each as a hashtable with 'Db' and 'Role' keys.
    # Example: -Role @(@{ Db = 'admin'; Role = 'root' })
    ${Role},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The DefaultProfile parameter is not functional.
    # Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job.
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach.
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline.
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline.
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously.
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use.
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call.
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.DocumentDB.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy.
    ${ProxyUseDefaultCredentials}
)

    process {
        try {
            # The service models the user's identity provider as a discriminated union
            # (identityProvider.type -> microsoftEntraID.principalType). Map the flat -Type
            # value to the principal type the service expects.
            $principalType = switch ($Type) {
                'User'             { 'user' }
                'ServicePrincipal' { 'servicePrincipal' }
                default            { $Type }
            }

            $properties = @{
                identityProvider = @{
                    type       = 'MicrosoftEntraID'
                    properties = @{ principalType = $principalType }
                }
            }
            if ($PSBoundParameters.ContainsKey('Role') -and $Role) {
                $properties['roles'] = @($Role | ForEach-Object { @{ db = $_.Db; role = $_.Role } })
            }
            $jsonString = @{ properties = $properties } | ConvertTo-Json -Depth 10 -Compress

            $null = $PSBoundParameters.Remove('Type')
            $null = $PSBoundParameters.Remove('Role')
            foreach ($commonParam in 'WhatIf', 'Confirm') { $null = $PSBoundParameters.Remove($commonParam) }
            $PSBoundParameters['JsonString'] = $jsonString

            if ($PSCmdlet.ShouldProcess($Name, "Create a Microsoft Entra ID user")) {
                Az.DocumentDB.internal\New-AzDocumentDBUser @PSBoundParameters
            }
        } catch {
            throw
        }
    }
}
