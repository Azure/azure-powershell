# Shim module that allows scenario tests for hyak-based cmdlets to call cmdlets that are autorest based.
# This is needed because hyak-based cmdlets and autorest-based cmdlets use different versions of
# Microsoft.Azure.Management.Sql, so hyak-based cmdlets and autorest-based cmdlets cannot be used in
# the same scenario tests as one another.
# Based on D:\git\azure-powershell\src\ResourceManager\Common\Commands.ScenarioTests.ResourceManager.Common\AzureRM.Storage.ps1
# SqlManagementClient reference: https://github.com/Azure/azure-sdk-for-net/tree/master/src/ResourceManagement/Sql/SqlManagement

<#

function Extract-Password([PSCredential] $c)
{
  $nc = New-Object -TypeName System.Net.NetworkCredential -ArgumentList $nul, $c.Password
  $nc.Password
}

function New-AzureRmSqlServer
{
  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] $ServerName,
    [string] [Parameter(Position=2, ValueFromPipelineByPropertyName=$true)] $ServerVersion,
    [string] [Parameter(Position=2, ValueFromPipelineByPropertyName=$true)] $Location,
    [PSCredential] [Parameter(Position=2, ValueFromPipelineByPropertyName=$true)] $SqlAdministratorCredentials)
  BEGIN { 
    Write-Debug "New-AzureRmSqlServer shim: BEGIN"
    Write-Debug "$ResourceGroupName // $ServerName // $ServerVersion // $Location // $SqlAdministratorCredentials"
    $context = Get-Context
    $client = Get-SqlClient $context
  }
  PROCESS {
    Write-Debug "New-AzureRmSqlServer shim: PROCESS"

    $properties = New-Object -TypeName "Microsoft.Azure.Management.Sql.Models.ServerCreateOrUpdateProperties"
    $properties.AdministratorLogin = $SqlAdministratorCredentials.UserName
    $properties.AdministratorLoginPassword = Extract-Password $SqlAdministratorCredentials
    $properties.Version = $ServerVersion

    $parameters = New-Object -TypeName "Microsoft.Azure.Management.Sql.Models.ServerCreateOrUpdateParameters"
    $parameters.Properties = $properties
    $parameters.Location = $Location

    $server = $client.Servers.CreateOrUpdateAsync($ResourceGroupName, $ServerName, $parameters, [System.Threading.CancellationToken]::None).Result

    # Return cmdlet model type (as opposed to sdk model type)
    $o = New-Object PSObject -Property @{
      'ResourceGroupName'=$ResourceGroupName;
      'ServerName'=$ServerName;
    }
    $o | Out-String | Write-Debug
    $o
  }
  END {
    Write-Debug "New-AzureRmSqlServer shim: END"
  }
}

function Get-AzureRmSqlServer
{
  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] $ServerName)
  BEGIN { 
    Write-Debug "Get-AzureRmSqlServer shim: BEGIN"
    Write-Debug "$ResourceGroupName // $ServerName"
    $context = Get-Context
    $client = Get-SqlClient $context
  }
  PROCESS {
    Write-Debug "Get-AzureRmSqlServer shim: PROCESS"

    $server = $client.Servers.GetAsync($ResourceGroupName, $ServerName, [System.Threading.CancellationToken]::None).Result

    # Return cmdlet model type (as opposed to sdk model type)
    $o = New-Object PSObject -Property @{
      'ResourceGroupName'=$ResourceGroupName;
      'ServerName'=$ServerName;
    }
    $o | Out-String | Write-Debug
    $o
  }
  END {
    Write-Debug "Get-AzureRmSqlServer shim: END"
  }
}

function New-AzureRmSqlDatabase
{
  [CmdletBinding()]
  param(
    [string] [Parameter(Position=0, ValueFromPipelineByPropertyName=$true)] $ResourceGroupName,
    [string] [Parameter(Position=1, ValueFromPipelineByPropertyName=$true)] $ServerName,
    [string] [Parameter(Position=2, ValueFromPipelineByPropertyName=$true)] $DatabaseName,
    [string] [Parameter(Position=3, ValueFromPipelineByPropertyName=$true)] $Edition = $null,
    [string] [Parameter(Position=4, ValueFromPipelineByPropertyName=$true)] $CollationName = $null,
	[string] [Parameter(Position=5, ValueFromPipelineByPropertyName=$true)] $RequestedServiceObjectiveName = $null)
  BEGIN {
    Write-Debug "New-AzureRmSqlDatabase shim: BEGIN"
    Write-Debug "$ResourceGroupName // $ServerName // $DatabaseName // $Edition // $CollationName // $RequestedServiceObjectiveName"
    $context = Get-Context
    $client = Get-SqlClient $context
  }
  PROCESS {
    Write-Debug "New-AzureRmSqlDatabase shim: PROCESS"

    $Location = $client.Servers.GetAsync($ResourceGroupName, $ServerName, [System.Threading.CancellationToken]::None).Result.Location

    $properties = New-Object -TypeName "Microsoft.Azure.Management.Sql.Models.DatabaseCreateOrUpdateProperties"
    $properties.Edition = $Edition
	$properties.CollationName = $CollationName
	$properties.RequestedServiceObjectiveName = $RequestedServiceObjectiveName

    $parameters = New-Object -TypeName "Microsoft.Azure.Management.Sql.Models.DatabaseCreateOrUpdateParameters"
    $parameters.Properties = $properties
    $parameters.Location = $Location

    $task = $client.Databases.CreateOrUpdateAsync($ResourceGroupName, $ServerName, $DatabaseName, $parameters, [System.Threading.CancellationToken]::None)
    $db = $task.Result
    
    # Return cmdlet model type (as opposed to sdk model type)
    $o = New-Object PSObject -Property @{
      'ResourceGroupName'=$ResourceGroupName;
      'ServerName'=$ServerName;
      'DatabaseName'=$DatabaseName
    }
    $o | Out-String | Write-Debug
    $o
  }
  END {
    Write-Debug "New-AzureRmSqlDatabase shim: END"
  }
}

function Get-SqlClient
{
  param([Microsoft.Azure.Commands.Common.Authentication.Models.AzureContext] $context)
    $factory = [Microsoft.Azure.Commands.Common.Authentication.AzureSession]::ClientFactory
    [System.Type[]]$types = [Microsoft.Azure.Commands.Common.Authentication.Models.AzureContext], [Microsoft.Azure.Commands.Common.Authentication.Models.AzureEnvironment+Endpoint]
    $method = [Microsoft.Azure.Commands.Common.Authentication.IClientFactory].GetMethod("CreateClient", $types)
    $closedMethod = $method.MakeGenericMethod([Microsoft.Azure.Management.Sql.SqlManagementClient])
    $arguments = $context, [Microsoft.Azure.Commands.Common.Authentication.Models.AzureEnvironment+Endpoint]::ResourceManager
    $client = $closedMethod.Invoke($factory, $arguments)
    return $client
}

#>