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
    $getTask = $client.ResourceGroups.GetAsync($Name, [System.Threading.CancellationToken]::None)
	$rg = $getTask.Result
	$resourceGroup = Get-ResourceGroup $Name $Location
	Write-Output $resourceGroup
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
    $createParms = New-Object -Type Microsoft.Azure.Management.Resources.Models.ResourceGroup
	$createParms.Location = $Location
	#$createParms.Tags = $Tags
    $createTask = $client.ResourceGroups.CreateOrUpdateAsync($Name, $createParms, [System.Threading.CancellationToken]::None)
	$rg = $createTask.Result
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
  param([string] $name, [string] $location)
  $rg = New-Object PSObject -Property @{"ResourceGroupName" = $name; "Location" = $location; }
  return $rg
}