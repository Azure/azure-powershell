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
    Write-Output $getTask.Result.Provider
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
      return [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
}

function Get-ResourcesClient
{
  param([Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext] $context)
  $factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.ClientFactory
  [System.Type[]]$types = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext], 
	[string]
  $method = [Microsoft.Azure.Commands.Common.Authentication.IHyakClientFactory].GetMethod("CreateClient", $types)
  $closedMethod = $method.MakeGenericMethod([Microsoft.Azure.Management.Resources.ResourceManagementClient])
  $arguments = $context, [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment+Endpoint]::ResourceManager
  $client = $closedMethod.Invoke($factory, $arguments)
  return $client
}

function Get-ResourceGroup {
  param([string] $name, [string] $location, [string] $id)
  $rg = New-Object PSObject -Property @{"ResourceGroupName" = $name; "Location" = $location; "ResourceId" = $id}
  return $rg
}

function List-ResourceGroup {
  $rg = New-Object PSObject -Property @{"ResourceGroupName" = $name; "Location" = $location; }
  return $rg
}