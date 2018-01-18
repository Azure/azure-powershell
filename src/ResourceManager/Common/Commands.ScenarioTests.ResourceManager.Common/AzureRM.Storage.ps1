
function Get-AzureRmStorageAccount
{

  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] [alias("StorageAccountName")] $Name)
  BEGIN { 
    $context = Get-Context
    $client = Get-StorageClient $context
    $version = $client.GetType().Assembly.GetName().Version
  }
  PROCESS {
    if ($version.Major -gt 3)
    {
        $getTask = $client.StorageAccounts.GetPropertiesWithHttpMessagesAsync($ResourceGroupName, $name, $null, [System.Threading.CancellationToken]::None)
    }
    else
    {
        $getTask = $client.StorageAccounts.GetPropertiesAsync($ResourceGroupName, $name, [System.Threading.CancellationToken]::None)
    }
    $sa = $getTask.Result

    if($sa -ne $null)
    {
        $id = "/subscriptions/" + $context.Subscription.Id + "/resourceGroups/"+ $ResourceGroupName + "/providers/Microsoft.Storage/storageAccounts/" + $Name	  
        $account = Get-StorageAccount $ResourceGroupName $Name $id
        Write-Output $account
    }
  }
  END {}

}

function New-AzureRmStorageAccount
{
  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)][alias("StorageAccountName")] $Name,
    [string] [Parameter(Position=2, ValueFromPipelineByPropertyName=$true)] $Location,
    [string] [Parameter(Position=3, ValueFromPipelineByPropertyName=$true)] $typeString)
  BEGIN { 
    $context = Get-Context
    $client = Get-StorageClient $context
    $version = $client.GetType().Assembly.GetName().Version
  }
  PROCESS {
    $createParms = New-Object -Type Microsoft.Azure.Management.Storage.Models.StorageAccountCreateParameters
	if ($version.Major -lt 5)
	{
		if ($typeString -eq $null)
		{
		  $Type = [Microsoft.Azure.Management.Storage.Models.AccountType]::StandardLRS
		}
		else
		{
		  $Type = Parse-Type $typeString $version.Major
		}

		$createParms.AccountType = $Type
	}
	else
	{
		if ($typeString -eq $null)
		{
		  $Type = [Microsoft.Azure.Management.Storage.Models.SkuName]::StandardLRS
		}
		else
		{
		  $Type = Parse-Type $typeString $version.Major
		}

		$createParms.Sku = New-Object -Type Microsoft.Azure.Management.Storage.Models.Sku $Type
	}
    $createParms.Location = $Location
    if ($version.Major -gt 3)
    {
        $getTask = $client.StorageAccounts.CreateWithHttpMessagesAsync($ResourceGroupName, $name, $createParms, $null, [System.Threading.CancellationToken]::None)
    }
    else
    {
        $getTask = $client.StorageAccounts.CreateAsync($ResourceGroupName, $name, $createParms,[System.Threading.CancellationToken]::None)
    }
    $sa = $getTask.Result
  }
  END {}

}

function Set-AzureRmStorageAccount
{
  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)][alias("StorageAccountName")] $Name,
    [string] [Parameter(Position=2, ValueFromPipelineByPropertyName=$true)] $Type,
    [Hashtable[]] [Parameter(Position=3, ValueFromPipelineByPropertyName=$true)] $Tags)
  BEGIN { 
    $context = Get-Context
    $client = Get-StorageClient $context
    $version = $client.GetType().Assembly.GetName().Version
  }
  PROCESS {
    $createParms = New-Object -Type Microsoft.Azure.Management.Storage.Models.StorageAccountUpdateParameters
    $createParms.AccountType = [Microsoft.Azure.Management.Storage.Models.AccountType]::StandardLRS

    if ($version.Major -gt 3)
    {
        $getTask = $client.StorageAccounts.UpdateWithHttpMessagesAsync($ResourceGroupName, $Name, $createParms, $null, [System.Threading.CancellationToken]::None)
    }
    else
    {
        $getTask = $client.StorageAccounts.UpdateAsync($ResourceGroupName, $Name, $createParms, [System.Threading.CancellationToken]::None)
    }
    $sa = $getTask.Result
  }
  END {}
}


function Get-AzureRmStorageAccountKey
{
  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] [alias("StorageAccountName")] $Name)
  BEGIN {  
    $context = Get-Context
    $client = Get-StorageClient $context
    $version = $client.GetType().Assembly.GetName().Version
  }
  PROCESS {
    if ($version.Major -gt 5)
    {
        $getTask = $client.StorageAccounts.ListKeysWithHttpMessagesAsync($ResourceGroupName, $name, $null, [System.Threading.CancellationToken]::None)
        $result = $getTask.GetAwaiter().GetResult()
        Write-Output $result.Body.Keys
    }
    elseif ($version.Major -gt 3)
    {
        $getTask = $client.StorageAccounts.ListKeysWithHttpMessagesAsync($ResourceGroupName, $name, $null, [System.Threading.CancellationToken]::None)
        $result = $getTask.GetAwaiter().GetResult()
        Write-Output $result.Body
    }
    else
    {
        $getTask = $client.StorageAccounts.ListKeysAsync($ResourceGroupName, $name, [System.Threading.CancellationToken]::None)
        Write-Output $getTask.Result.StorageAccountKeys
    }
  }
  END {}
}

function Remove-AzureRmStorageAccount
{

  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] [alias("StorageAccountName")] $Name)
  BEGIN { 
    $context = Get-Context
    $client = Get-StorageClient $context
    $version = $client.GetType().Assembly.GetName().Version
  }
  PROCESS {
    if ($version.Major -gt 3)
    {
        $getTask = $client.StorageAccounts.DeleteWithHttpMessagesAsync($ResourceGroupName, $name, $null, [System.Threading.CancellationToken]::None)
    }
    else
    {
        $getTask = $client.StorageAccounts.DeleteAsync($ResourceGroupName, $name, [System.Threading.CancellationToken]::None)
    }
    $sa = $getTask.Result
  }
  END {}

}

function Get-Context
{
      return [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
}

 function Parse-Type
 {
    param([string] $type, [int] $majorVersion)
    $type = $type.Replace("_", "")
	if ($majorVersion -lt 5)
	{
		$returnSkuName = [System.Enum]::Parse([Microsoft.Azure.Management.Storage.Models.AccountType], $type)
	}
	else
	{
		$returnSkuName = [System.Enum]::Parse([Microsoft.Azure.Management.Storage.Models.SkuName], $type)
	}
    return $returnSkuName;
 }

function Get-StorageClient
{
  param([Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext] $context)
    $factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.ClientFactory
    [System.Type[]]$types = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext], [string]
    $storageClient = [Microsoft.Azure.Management.Storage.StorageManagementClient]
    $storageVersion = [System.Reflection.Assembly]::GetAssembly($storageClient).GetName().Version
    if ($storageVersion.Major -gt 3)
    {
      $method = [Microsoft.Azure.Commands.Common.Authentication.IClientFactory].GetMethod("CreateArmClient", $types)
    }
    else
    {
      $method = [Microsoft.Azure.Commands.Common.Authentication.IHyakClientFactory].GetMethod("CreateClient", $types)
    }
    $closedMethod = $method.MakeGenericMethod([Microsoft.Azure.Management.Storage.StorageManagementClient])
    $arguments = $context, [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureEnvironment+Endpoint]::ResourceManager
    $client = $closedMethod.Invoke($factory, $arguments)
    return $client
}

function Get-StorageAccount {
  param([string] $resourceGroupName, [string] $name, [string] $id)
    $endpoints = New-Object PSObject -Property @{"Blob" = "https://$name.blob.core.windows.net/"}
    $sa = New-Object PSObject -Property @{"Name" = $name; "ResourceGroupName" = $resourceGroupName;
      "PrimaryEndpoints" = $endpoints; "Id" = $id
    }
  return $sa
}
