
function Get-AzureRmResourceGroup
{
  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] [alias("ResourceGroupName")] $Name),
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] $Location,
	[string] [Parameter(ValueFromPipelineByPropertyName=$true)] [alias("ResourceGroupId")] $Id)
  BEGIN { 
    $context = Get-Context
	$client = Get-ResourcesClient $context
  }
  PROCESS {
    $getTask = $client.ResourceGroups.Get($Name, [System.Threading.CancellationToken]::None)
	$rg = $getTask.Result
	$resourceGroup = Get-ResourceGroup $Name $Location
	Write-Output $resourceGroup
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
	$endpoints = New-Object PSObject -Property @{"Blob" = "https://$name.blob.core.windows.net/"}
  $rg = New-Object PSObject -Property @{"ResourceGroupName" = $name; "Location" = $location; }
  return $rg
}