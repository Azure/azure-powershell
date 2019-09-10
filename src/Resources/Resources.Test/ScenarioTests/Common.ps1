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

$TestOutputRoot = [System.AppDomain]::CurrentDomain.BaseDirectory;
$ResourcesPath = Join-Path $TestOutputRoot "ScenarioTests"

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
        Remove-AzResourceGroup -Name $rgname -Force
    }
}

function New-AzRoleAssignmentWithId
{
    [CmdletBinding()]
    param(
        [string] [Parameter()] [alias("Id", "PrincipalId")] $ObjectId,
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

    if (-not ([string]::IsNullOrEmpty($ObjectId)))
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

function New-AzRoleDefinitionWithId
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

function New-AzADAppCredentialWithId
{
    [CmdletBinding()]
    param(
        [string] [Parameter()] $ObjectId,
        [Guid] [Parameter()] $ApplicationId,
        [string] [Parameter()] $DisplayName,
        [SecureString] [Parameter()] $Password,
        [string] [Parameter()] $CertValue,
        [DateTime] [Parameter()] $StartDate,
        [DateTime] [Parameter()] $EndDate,
        [Guid] [Parameter()] $KeyId
    )
    $profile = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile
    $cmdlet = New-Object -TypeName Microsoft.Azure.Commands.ActiveDirectory.NewAzureADAppCredentialCommand
    $cmdlet.DefaultProfile = $profile
	$cmdlet.CommandRuntime = $PSCmdlet.CommandRuntime

    if (-not ([string]::IsNullOrEmpty($ObjectId)))
    {
        $cmdlet.ObjectId = $ObjectId
    }

    if ($ApplicationId -ne $null -and $ApplicationId -ne [System.Guid]::Empty)
    {
        $cmdlet.ApplicationId = $ApplicationId
    }

    if (-not ([string]::IsNullOrEmpty($DisplayName)))
    {
        $cmdlet.DisplayName = $DisplayName
    }

    if ($Password -ne $null)
    {
        $cmdlet.Password = $Password
    }

    if (-not ([string]::IsNullOrEmpty($CertValue)))
    {
        $cmdlet.CertValue = $CertValue
    }

    if ($StartDate -ne $null)
    {
        $cmdlet.StartDate = $StartDate
    }

    if ($EndDate -ne $null)
    {
        $cmdlet.EndDate = $EndDate
    }

    if ($KeyId -ne $null -and $KeyId -ne [System.Guid]::Empty)
    {
        $cmdlet.KeyId = $KeyId
    }

    $cmdlet.ExecuteCmdlet()
}

function New-AzADSpCredentialWithId
{
    [CmdletBinding()]
    param(
        [string] [Parameter()] $ObjectId,
        [string] [Parameter()] $ServicePrincipalName,
        [string] [Parameter()] $CertValue,
        [SecureString] [Parameter()] $Password,
        [DateTime] [Parameter()] $StartDate,
        [DateTime] [Parameter()] $EndDate,
        [Guid] [Parameter()] $KeyId
    )

    $profile = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile
    $cmdlet = New-Object -TypeName Microsoft.Azure.Commands.ActiveDirectory.NewAzureADSpCredentialCommand
    $cmdlet.DefaultProfile = $profile
	$cmdlet.CommandRuntime = $PSCmdlet.CommandRuntime

    if (-not ([string]::IsNullOrEmpty($ObjectId)))
    {
        $cmdlet.ObjectId = $ObjectId
    }

    if (-not ([string]::IsNullOrEmpty($ServicePrincipalName)))
    {
        $cmdlet.ServicePrincipalName = $ServicePrincipalName
    }

    if (-not ([string]::IsNullOrEmpty($CertValue)))
    {
        $cmdlet.CertValue = $CertValue
    }

	if ($Password -ne $null)
    {
        $cmdlet.Password = $Password
    }

    if ($StartDate -ne $null)
    {
        $cmdlet.StartDate = $StartDate
    }

    if ($EndDate -ne $null)
    {
        $cmdlet.EndDate = $EndDate
    }

    if ($KeyId -ne $null -and $KeyId -ne [System.Guid]::Empty)
    {
        $cmdlet.KeyId = $KeyId
    }

    $cmdlet.ExecuteCmdlet()
}

function Test-AzResourceGroupDeploymentWithName
{
    [CmdletBinding()]
    param(
        [string] [Parameter()] $DeploymentName,
        [string] [Parameter()] $ResourceGroupName,
        [string] [Parameter()] $RollBackDeploymentName,
        [string] [Parameter()] $TemplateFile,
        [string] [Parameter()] $TemplateUri,
        [string] [Parameter()] $TemplateParameterFile,
        [string] [Parameter()] $TemplateParameterUri,
        [string] [Parameter()] $ApiVersion,
        [switch] [Parameter()] $RollbackToLastDeployment,
        [switch] [Parameter()] $SkipTemplateParameterPrompt,
        [switch] [Parameter()] $Pre,
        [hashtable] [Parameter()] $TemplateObject,
        [hashtable] [Parameter()] $TemplateParameterObject,
        [Microsoft.Azure.Management.ResourceManager.Models.DeploymentMode] [Parameter()] $Mode
    )

    $profile = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile
    $cmdlet = New-Object -TypeName Microsoft.Azure.Commands.ResourceManager.Cmdlets.Implementation.TestAzureResourceGroupDeploymentCmdlet
    $cmdlet.DefaultProfile = $profile
    $cmdlet.CommandRuntime = $PSCmdlet.CommandRuntime

    if (-not ([string]::IsNullOrEmpty($DeploymentName)))
    {
        $cmdlet.DeploymentName = $DeploymentName
    }

    if (-not ([string]::IsNullOrEmpty($ResourceGroupName)))
    {
        $cmdlet.ResourceGroupName = $ResourceGroupName
    }

    if (-not ([string]::IsNullOrEmpty($RollBackDeploymentName)))
    {
        $cmdlet.RollBackDeploymentName = $RollBackDeploymentName
    }

    if (-not ([string]::IsNullOrEmpty($TemplateFile)))
    {
        $cmdlet.TemplateFile = $TemplateFile
    }

    if (-not ([string]::IsNullOrEmpty($TemplateUri)))
    {
        $cmdlet.TemplateUri = $TemplateUri
    }

    if (-not ([string]::IsNullOrEmpty($TemplateParameterFile)))
    {
        $cmdlet.TemplateParameterFile = $TemplateParameterFile
    }

    if (-not ([string]::IsNullOrEmpty($TemplateParameterUri)))
    {
        $cmdlet.TemplateParameterUri = $TemplateParameterUri
    }

    if (-not ([string]::IsNullOrEmpty($ApiVersion)))
    {
        $cmdlet.ApiVersion = $ApiVersion
    }

    if ($RollbackToLastDeployment.IsPresent)
    {
        $cmdlet.RollbackToLastDeployment = $true
    }

    if ($SkipTemplateParameterPrompt.IsPresent)
    {
        $cmdlet.SkipTemplateParameterPrompt = $true
    }

    if ($Pre.IsPresent)
    {
        $cmdlet.Pre = $true
    }

    if ($TemplateObject -ne $null)
    {
        $cmdlet.TemplateObject = $TemplateObject
    }

    if ($TemplateParameterObject -ne $null)
    {
        $cmdlet.TemplateParameterObject = $TemplateParameterObject
    }

    if ($Mode -ne $null)
    {
        $cmdlet.Mode = $Mode
    }

    $cmdlet.ExecuteCmdlet()
}