# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Gets valid resource group name
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-ResourceName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid password string for a VM
#>
function Get-PasswordForVM
{
	return (getAssetName) + '_196Ab!@'
}

<#
.SYNOPSIS
Gets valid application display name
#>
function Get-ApplicatonDisplayName
{
    return getAssetName
}

<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname)
{
	$assemblies = [AppDomain]::Currentdomain.GetAssemblies() | Select-Object FullName | ForEach-Object { $_.FullName.Substring(0, $_.FullName.IndexOf(',')) }
    if ($assemblies -notcontains 'Microsoft.Azure.Test.HttpRecorder.HttpMockServer' `
		-or $assemblies -notcontains 'Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode' `
		-or [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

function New-AzureRmRoleAssignmentWithId
{
    [CmdletBinding()]
    param(
        [Guid]   [Parameter()] [alias("Id", "PrincipalId")] $ObjectId,
        [string] [Parameter()] [alias("Email", "UserPrincipalName")] $SignInName,
        [string] [Parameter()] [alias("SPN", "ServicePrincipalName")] $ApplicationId,
        [string] [Parameter()] $ResourceGroupName,
        [string] [Parameter()] $ResourceName,
        [string] [Parameter()] $ResourceType,
        [string] [Parameter()] $ParentResource,
        [string] [Parameter()] $Scope,
        [string] [Parameter()] $RoleDefinitionName,
        [Guid]   [Parameter()] $RoleDefinitionId,
        [switch] [Parameter()] $AllowDelegation,
        [Guid]   [Parameter()] $RoleAssignmentId
    )

    $profile = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile
    $cmdlet = New-Object -TypeName Microsoft.Azure.Commands.Resources.NewAzureRoleAssignmentCommand
    $cmdlet.DefaultProfile = $profile
	$cmdlet.CommandRuntime = $PSCmdlet.CommandRuntime

    if ($ObjectId -ne $null -and $ObjectId -ne [System.Guid]::Empty)
    {
        $cmdlet.ObjectId = $ObjectId
    }

    if (-not ([string]::IsNullOrEmpty($SignInName)))
    {
        $cmdlet.SignInName = $SignInName
    }

    if (-not ([string]::IsNullOrEmpty($ApplicationId)))
    {
        $cmdlet.ApplicationId = $ApplicationId
    }

    if (-not ([string]::IsNullOrEmpty($ResourceGroupName)))
    {
        $cmdlet.ResourceGroupName = $ResourceGroupName
    }

    if (-not ([string]::IsNullOrEmpty($ResourceName)))
    {
        $cmdlet.ResourceName = $ResourceName
    }

    if (-not ([string]::IsNullOrEmpty($ResourceType)))
    {
        $cmdlet.ResourceType = $ResourceType
    }

    if (-not ([string]::IsNullOrEmpty($ParentResource)))
    {
        $cmdlet.ParentResource = $ParentResource
    }

    if (-not ([string]::IsNullOrEmpty($Scope)))
    {
        $cmdlet.Scope = $Scope
    }

    if (-not ([string]::IsNullOrEmpty($RoleDefinitionName)))
    {
        $cmdlet.RoleDefinitionName = $RoleDefinitionName
    }

    if ($RoleDefinitionId -ne $null -and $RoleDefinitionId -ne [System.Guid]::Empty)
    {
        $cmdlet.RoleDefinitionId = $RoleDefinitionId
    }

    if ($AllowDelegation.IsPresent)
    {
        $cmdlet.AllowDelegation = $true
    }

    if ($RoleAssignmentId -ne $null -and $RoleAssignmentId -ne [System.Guid]::Empty)
    {
        $cmdlet.RoleAssignmentId = $RoleAssignmentId
    }

    $cmdlet.ExecuteCmdlet()
}

function New-AzureRmRoleDefinitionWithId
{
    [CmdletBinding()]
    param(
        [Microsoft.Azure.Commands.Resources.Models.Authorization.PSRoleDefinition] [Parameter()] $Role,
        [string] [Parameter()] $InputFile,
        [Guid]   [Parameter()] $RoleDefinitionId
    )

    $profile = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile
    $cmdlet = New-Object -TypeName Microsoft.Azure.Commands.Resources.NewAzureRoleDefinitionCommand
    $cmdlet.DefaultProfile = $profile
	$cmdlet.CommandRuntime = $PSCmdlet.CommandRuntime

    if (-not ([string]::IsNullOrEmpty($InputFile)))
    {
        $cmdlet.InputFile = $InputFile
    }

    if ($Role -ne $null)
    {
        $cmdlet.Role = $Role
    }

    if ($RoleDefinitionId -ne $null -and $RoleDefinitionId -ne [System.Guid]::Empty)
    {
        $cmdlet.RoleDefinitionId = $RoleDefinitionId
    }

    $cmdlet.ExecuteCmdlet()
}