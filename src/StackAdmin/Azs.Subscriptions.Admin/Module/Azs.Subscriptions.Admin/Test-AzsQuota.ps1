<#
Copyright (c) Microsoft Corporation. All rights reserved.
Licensed under the MIT License. See License.txt in the project root for license information.
#>

Microsoft.PowerShell.Core\Set-StrictMode -Version Latest
<#
.SYNOPSIS
    Validates a Quota Id

.DESCRIPTION
    Validates a Quota Id

.PARAMETER Id
    The quota identifier we want to validate as being valid.

#>
Function Test-AzsQuota {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [string]$Id
    )
    Process {

        Write-Verbose "Validating quota id '$Id' with Compute"
        if ($null -ne (Get-AzsComputeQuota -Id $Id -ErrorAction SilentlyContinue))
        {
            Write-Verbose "Validated as Compute quota"
            Write-Output $true
        }

        Write-Verbose "Validating quota id '$Id' with Storage"
        if ($null -ne (Get-AzsStorageQuota -Id $Id -ErrorAction SilentlyContinue))
        {
            Write-Verbose "Validated as Storage quota"
            Write-Output $true
        }

        Write-Verbose "Validating quota id '$Id' with Network"
        if ($null -ne (Get-AzsNetworkQuota -Id $Id -ErrorAction SilentlyContinue))
        {
            Write-Verbose "Validated as Network quota"
            Write-Output $true
        }
        Write-Output $false
    }
}
