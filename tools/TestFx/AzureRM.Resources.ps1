function Get-AzureRmResourceGroup
{
  [CmdletBinding()]
  [Alias("Get-AzResourceGroup")]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] [alias("ResourceGroupName")] $Name,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] $Location,
    [string] [Parameter(ValueFromPipelineByPropertyName=$true)] $Id,
    [switch] $Force)
  BEGIN {
    $context = Get-Context
    $client = Get-ResourcesClient $context
  }
  PROCESS {
    if([string]::IsNullOrEmpty($Name)) {
      $getTask = $client.ResourceGroups.ListWithHttpMessagesAsync($null, $null, [System.Threading.CancellationToken]::None)
      $rg = $getTask.Result.Body
      Write-Output $rg
    } else {
      $getTask = $client.ResourceGroups.GetWithHttpMessagesAsync($Name, $null, [System.Threading.CancellationToken]::None)
      $rg = $getTask.Result
      if($rg -eq $null) {
        $resourceGroup = $null
      } else {
        $resourceGroup = Get-ResourceGroup $Name $Location $rg.ResourceGroup.Id
      }
      Write-Output $resourceGroup
    }
  }
  END {}
}

function Get-AzureRmResource
{
  [CmdletBinding()]
  [Alias("Get-AzResource")]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceType)
  BEGIN {
    $context = Get-Context
    $client = Get-ResourcesClient $context
  }
  PROCESS {
    $result = $client.Resources.ListWithHttpMessagesAsync().Result.Body
    if (![string]::IsNullOrEmpty($ResourceType)) {
      $result = $result | Where-Object { $_.Type -eq $ResourceType }
      Write-Output $result
    }
    else {
      Write-Output $result
    }
  }
  END {}
}

function Get-AzureRmResourceProvider
{
  [CmdletBinding()]
  [Alias("Get-AzResourceProvider")]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ProviderNamespace)
  BEGIN {
    $context = Get-Context
    $client = Get-ResourcesClient $context
  }
  PROCESS {
    $getTask = $client.Providers.GetWithHttpMessagesAsync($ProviderNamespace)
    Write-Output $getTask.Result.Body
  }
  END {}
}

function New-AzureRmResourceGroup
{
  [CmdletBinding()]
  [Alias("New-AzResourceGroup")]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] [alias("ResourceGroupName")] $Name,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] $Location,
    [hashtable] [Parameter(ValueFromPipelineByPropertyName=$true)] $Tags,
    [switch] $Force)
  BEGIN {
    $context = Get-Context
    $client = Get-ResourcesClient $context
  }
  PROCESS {
    $createParams = New-Object -Type Microsoft.Azure.Management.Internal.Resources.Models.ResourceGroup
    $createParams.Location = $Location
    if($Tags)
    {
        $tagsDictionary  = New-Object 'System.Collections.Generic.Dictionary[string,string]'
        $Tags.Keys | ForEach-Object { $tagsDictionary.Add($_,$Tags[$_]) }
        $createParams.Tags = $tagsDictionary
    }
    $createTask = $client.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync($Name, $createParams, $null, [System.Threading.CancellationToken]::None)
    $rg = $createTask.Result
    $resourceGroup = Get-ResourceGroup $Name $Location
    Write-Output $resourceGroup
  }
  END {}
}

function New-AzureRmResourceGroupDeployment
{
  [CmdletBinding()]
  [Alias("New-AzResourceGroupDeployment")]
  param(
    [string] [alias("DeploymentName")] $Name,
    [string] $ResourceGroupName,
    [string] $TemplateFile,
    [string] $serverName,
    [string] $databaseName,
    [string] $storageName,
    [string] $version,
    [string] $EnvLocation,
    [string] $administratorLogin,
    [string] $TemplateParameterFile,
    [switch] $Force)
  BEGIN {
    $context = Get-Context
    $client = Get-ResourcesClient $context
  }
  PROCESS {
    if($TemplateFile)
    {
      $mode = [Microsoft.Azure.Management.Internal.Resources.Models.DeploymentMode]::Incremental
      $template = [Newtonsoft.Json.Linq.JObject]::Parse((Get-Content $TemplateFile) -join "`r`n")
      if($TemplateParameterFile)
      {
        $templateParams = [Newtonsoft.Json.Linq.JObject]::Parse((Get-Content $TemplateParameterFile) -join "`r`n")
        $createParamsProps = New-Object -Type Microsoft.Azure.Management.Internal.Resources.Models.DeploymentProperties -ArgumentList $mode,$template,$null,$templateParams
      }
      else
      {
        $createParamsProps = New-Object -Type Microsoft.Azure.Management.Internal.Resources.Models.DeploymentProperties -ArgumentList $mode,$template
      }
      $createParams = New-Object -Type Microsoft.Azure.Management.Internal.Resources.Models.Deployment -ArgumentList $createParamsProps
    }
    else
    {
      $createParams = New-Object -Type Microsoft.Azure.Management.Internal.Resources.Models.Deployment
    }

    $createTask = $client.Deployments.CreateOrUpdateWithHttpMessagesAsync($Name, $Name, $createParams, $null, [System.Threading.CancellationToken]::None)
    $rg = $createTask.Result
  }
  END {}
}

function Remove-AzureRmResourceGroup
{
  [CmdletBinding()]
  [Alias("Remove-AzResourceGroup")]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] [alias("ResourceGroupName")] $Name,
    [switch] $Force)
  BEGIN {
    $context = Get-Context
    $client = Get-ResourcesClient $context
  }
  PROCESS {
    $deleteTask = $client.ResourceGroups.DeleteWithHttpMessagesAsync($Name, $null, [System.Threading.CancellationToken]::None)
    $rg = $deleteTask.Result
  }
  END {}
}

function New-AzureRmRoleAssignmentWithId
{
    [CmdletBinding()]
    [Alias("New-AzRoleAssignmentWithId")]
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
    [Alias("New-AzRoleDefinitionWithId")]
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

function Get-Context
{
      return [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
}

function Get-ResourcesClient
{
  param([Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext] $context)
  $factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.ClientFactory
  [System.Type[]]$types = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext],[string]
  $method = [Microsoft.Azure.Commands.Common.Authentication.IClientFactory].GetMethods() | Where-Object { $_.Name -eq "CreateArmClient" -and $_.IsGenericMethod -eq $true }
  $closedMethod = $method.MakeGenericMethod([Microsoft.Azure.Management.Internal.Resources.ResourceManagementClient])
  $arguments = $context, [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment+Endpoint]::ResourceManager
  $client = $closedMethod.Invoke($factory, $arguments)
  return $client
}

function Get-ResourceGroup {
  param([string] $name, [string] $location, [string] $id)
  $rg = New-Object PSObject -Property @{"ResourceGroupName" = $name; "Location" = $location; "ResourceId" = $id}
  return $rg
}
