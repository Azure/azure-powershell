function Get-AzureRmResourceGroup
{
  [CmdletBinding()]
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
    if($Name -eq $null) {
      $getTask = $client.ResourceGroups.ListAsync($null, [System.Threading.CancellationToken]::None)
      $rg = $getTask.Result
      $resourceGroup = List-ResourceGroup
      Write-Output $resourceGroup
    } else {
      $getTask = $client.ResourceGroups.GetAsync($Name, [System.Threading.CancellationToken]::None)
      $rg = $getTask.Result
      $resourceGroup = Get-ResourceGroup $Name $Location $rg.ResourceGroup.Id
      Write-Output $resourceGroup
    }
  }
  END {}
}

function Get-AzureRmResourceProvider
{
  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ProviderNamespace)
  BEGIN {
    $context = Get-Context
    $client = Get-ResourcesClient $context
  }
  PROCESS {
    $getTask = $client.Providers.GetAsync($ProviderNamespace, [System.Threading.CancellationToken]::None)
    $pr = $getTask.Result
    $provider = Get-Provider $pr.Provider.Namespace
    Write-Output $provider
  }
  END {}
}

function New-AzureRmResourceGroup
{
  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] [alias("ResourceGroupName")] $Name,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] $Location,
    [string] [Parameter(ValueFromPipelineByPropertyName=$true)] $Tags,
    [switch] $Force)
  BEGIN {
    $context = Get-Context
    $client = Get-ResourcesClient $context
  }
  PROCESS {
    $createParams = New-Object -Type Microsoft.Azure.Management.Resources.Models.ResourceGroup
    $createParams.Location = $Location
    $createTask = $client.ResourceGroups.CreateOrUpdateAsync($Name, $createParams, [System.Threading.CancellationToken]::None)
    $rg = $createTask.Result
    $resourceGroup = Get-ResourceGroup $Name $Location
    Write-Output $resourceGroup
  }
  END {}
}

function New-AzureRmResourceGroupDeployment
{
  [CmdletBinding()]
  param(
    [string] [alias("ResourceGroupName")] $Name,
    [string] $TemplateFile,
    [string] $serverName,
    [string] $databaseName,
    [string] $storageName,
    [string] $version,
    [string] $EnvLocation,
    [string] $administratorLogin,
    [switch] $Force)
  BEGIN {
    $context = Get-Context
    $client = Get-ResourcesClient $context
  }
  PROCESS {
    $createParams = New-Object -Type Microsoft.Azure.Management.Resources.Models.Deployment
    $createTask = $client.Deployments.CreateOrUpdateAsync($Name, $Name, $createParams, [System.Threading.CancellationToken]::None)
    $rg = $createTask.Result
  }
  END {}
}

function Remove-AzureRmResourceGroup 
{
  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] [alias("ResourceGroupName")] $Name,
    [switch] $Force)
  BEGIN {
    $context = Get-Context
    $client = Get-ResourcesClient $context
  }
  PROCESS {
    $deleteTask = $client.ResourceGroups.DeleteAsync($Name, [System.Threading.CancellationToken]::None)
    $rg = $deleteTask.Result
  }
  END {}
}

function Get-Context
{
    [Microsoft.Azure.Commands.Common.Authentication.Models.AzureContext]$context = $null
    $profile = [Microsoft.WindowsAzure.Commands.Common.AzureRmProfileProvider]::Instance.Profile
    if ($profile -ne $null)
    {
      $context = $profile.Context
    }
    return $context
}

function Get-ResourcesClient
{
  param([Microsoft.Azure.Commands.Common.Authentication.Models.AzureContext] $context)
  $factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::ClientFactory
  [System.Type[]]$types = [Microsoft.Azure.Commands.Common.Authentication.Models.AzureContext], [Microsoft.Azure.Commands.Common.Authentication.Models.AzureEnvironment+Endpoint]
  $method = [Microsoft.Azure.Commands.Common.Authentication.IClientFactory].GetMethod("CreateClient", $types)
  $closedMethod = $method.MakeGenericMethod([Microsoft.Azure.Management.Resources.ResourceManagementClient])
  $arguments = $context, [Microsoft.Azure.Commands.Common.Authentication.Models.AzureEnvironment+Endpoint]::ResourceManager
  $client = $closedMethod.Invoke($factory, $arguments)
  return $client
}

function Get-ResourceGroup {
  param([string] $name, [string] $location, [string] $id)
  $rg = New-Object PSObject -Property @{"ResourceGroupName" = $name; "Location" = $location; "ResourceId" = $id}
  return $rg
}

function Get-Provider {
  param([string] $name)
  $rtype = New-Object PSObject -Property @{"ResourceTypeName" = "virtualMachines"; "Locations" = @("East US"); "ApiVersions" = @("2015-01-01"); }
  $pr = New-Object PSObject -Property @{"ProviderNamespace" = $name; "RegistrationState" = "Registered"; "Locations" = @("East US"); "ResourceTypes" = $rtype;}
  return $pr
}

function List-ResourceGroup {
  $rg = New-Object PSObject -Property @{"ResourceGroupName" = $name; "Location" = $location; }
  return $rg
}