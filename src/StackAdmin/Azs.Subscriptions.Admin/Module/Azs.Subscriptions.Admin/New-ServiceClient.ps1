<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

Microsoft.PowerShell.Core\Set-StrictMode -Version Latest

<#
.DESCRIPTION
   Creates Service Client object.

.PARAMETER  FullClientTypeName
    Client type full name.

.PARAMETER  GlobalParameterHashtable
    Global parameters to be set on client object.
#>
function New-ServiceClient {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory = $true)]
        [string]
        $FullClientTypeName,

        [Parameter(Mandatory = $false)]
        [PSCustomObject]
        $GlobalParameterHashtable
    )

    # Azure Powershell way    
    [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext]$Context = Get-AzureRmContext
    if (-not $Context -or -not $Context.Account) {
        Write-Error -Message 'Run Login-AzureRmAccount to login.' -ErrorId 'AzureRmContextError'
        return
    }

    $Factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.ClientFactory
    [System.Type[]]$Types = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext], [string]
    $CreateArmClientMethod = [Microsoft.Azure.Commands.Common.Authentication.IClientFactory].GetMethod('CreateArmClient', $Types)
    $ClientType = $FullClientTypeName -as [Type]
    $ClosedMethod = $CreateArmClientMethod.MakeGenericMethod($ClientType)
    $Arguments = $Context, [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment+Endpoint]::ResourceManager
    $Client = $closedMethod.Invoke($Factory, $Arguments)

    if ($GlobalParameterHashtable) {
        $GlobalParameterHashtable.GetEnumerator() | ForEach-Object {
            if ($_.Value -and (Get-Member -InputObject $Client -Name $_.Key -MemberType Property)) {
                $Client."$($_.Key)" = $_.Value
            }
        }    
    }

    return $Client
}
