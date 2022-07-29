
function Get-AzureRmStorageAccount
{
  [CmdletBinding()]
  [Alias("Get-AzStorageAccount")]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] [alias("StorageAccountName")] $Name)
  BEGIN { 
    $context = Get-Context
    $client = Get-StorageClient $context
  }
  PROCESS {
    $getTask = $client.StorageAccounts.GetPropertiesWithHttpMessagesAsync($ResourceGroupName, $name)
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
  [Alias("New-AzStorageAccount")]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)][alias("StorageAccountName")] $Name,
    [string] [Parameter(Position=2, ValueFromPipelineByPropertyName=$true)] $Location,
    [string] [Parameter(Position=3, ValueFromPipelineByPropertyName=$true)] $typeString,
    [string] [Parameter(Position=4, ValueFromPipelineByPropertyName=$true)] $Kind,
	[bool]   [Parameter(Position=5, ValueFromPipelineByPropertyName=$true)] $DenyAsNetworkRuleDefaultAction)
  BEGIN { 
    $context = Get-Context
    $client = Get-StorageClient $context
  }
  PROCESS {
    $createParms = New-Object -Type Microsoft.Azure.Management.Storage.Version2017_10_01.Models.StorageAccountCreateParameters
	if ([string]::IsNullOrEmpty($typeString))
	{
		$Type = [Microsoft.Azure.Management.Storage.Version2017_10_01.Models.SkuName]::StandardLRS
	}
	else
	{
		$Type = Parse-Type $typeString
	}
    if ([string]::IsNullOrEmpty($Kind))
    {
        $Kind = 'StorageV2'
    }  
    $createParms.Kind = $Kind
	$createParms.Sku = New-Object -Type Microsoft.Azure.Management.Storage.Version2017_10_01.Models.Sku $Type
    $createParms.Location = $Location
	if ($DenyAsNetworkRuleDefaultAction)
	{
		$createParms.NetworkRuleSet = New-Object -Type Microsoft.Azure.Management.Storage.Version2017_10_01.Models.NetworkRuleSet -Property @{DefaultAction="Deny"}
	}
	
    $getTask = $client.StorageAccounts.CreateWithHttpMessagesAsync($ResourceGroupName, $name, $createParms)
    $sa = $getTask.Result.Body
    Write-Output $sa
  }
  END {}

}


function Set-AzureRmStorageAccount
{
  [CmdletBinding()]
  [Alias("Set-AzStorageAccount")]
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
    $createParms = New-Object -Type Microsoft.Azure.Management.Storage.Version2017_10_01.Models.StorageAccountUpdateParameters
    if ([string]::IsNullOrEmpty($Type)) {
      $Type = [Microsoft.Azure.Management.Storage.Version2017_10_01.Models.SkuName]::StandardLRS
    }
    $sku = New-Object -Type Microsoft.Azure.Management.Storage.Version2017_10_01.Models.Sku -ArgumentList @([Microsoft.Azure.Management.Storage.Version2017_10_01.Models.SkuName]::$type)
    $createParms.Sku = $sku
    $getTask = $client.StorageAccounts.UpdateWithHttpMessagesAsync($ResourceGroupName, $Name, $createParms)
    $sa = $getTask.Result.Body
    Write-Output $sa
  }
  END {}
}

function Get-AzureRmStorageAccountKey
{
  [CmdletBinding()]
  [Alias("Get-AzStorageAccountKey")]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] [alias("StorageAccountName")] $Name)
  BEGIN {  
    $context = Get-Context
    $client = Get-StorageClient $context
  }
  PROCESS {
    $getTask = $client.StorageAccounts.ListKeysWithHttpMessagesAsync($ResourceGroupName, $name)
    Write-Output $getTask.Result.Body.Keys
  }
  END {}
}

function Remove-AzureRmStorageAccount
{
  [CmdletBinding()]
  [Alias("Remove-AzStorageAccount")]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] [alias("StorageAccountName")] $Name)
  BEGIN { 
    $context = Get-Context
    $client = Get-StorageClient $context
    $version = $client.GetType().Assembly.GetName().Version
  }
  PROCESS {
    $getTask = $client.StorageAccounts.DeleteWithHttpMessagesAsync($ResourceGroupName, $name)
    $sa = $getTask.Result.Body
  }
  END {}

}

function Get-Context
{
      return [Microsoft.Azure.Commands.Common.Authentication.Abstractions.AzureRmProfileProvider]::Instance.Profile.DefaultContext
}

function Parse-Type
{
  param([string] $type)
  $type = $type.Replace("_", "")
  $returnSkuName = [System.Enum]::Parse([Microsoft.Azure.Management.Storage.Version2017_10_01.Models.SkuName], $type)
  return $returnSkuName;
}

function Get-StorageClient
{
  param([Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext] $context)
    $factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::Instance.ClientFactory
    [System.Type[]]$types = [Microsoft.Azure.Commands.Common.Authentication.Abstractions.IAzureContext], [string]
    $storageClient = [Microsoft.Azure.Management.Storage.Version2017_10_01.StorageManagementClient]
    $storageVersion = [System.Reflection.Assembly]::GetAssembly($storageClient).GetName().Version
    $method = [Microsoft.Azure.Commands.Common.Authentication.IClientFactory].GetMethods() | Where-Object { $_.Name -eq "CreateArmClient" -and $_.IsGenericMethod -eq $true }
    $closedMethod = $method.MakeGenericMethod([Microsoft.Azure.Management.Storage.Version2017_10_01.StorageManagementClient])
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
