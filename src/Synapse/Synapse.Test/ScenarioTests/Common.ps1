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
Gets a Synapse Analytics workspace name to use for testing
#>
function Get-SynapseWorkspaceName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets a Synapse Analytics Spark pool name to use for testing
#>
function Get-SynapseSparkPoolName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets a Synapse Analytics SQL pool name to use for testing
#>
function Get-SynapseSqlPoolName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets a Synapse Analytics SQL database name to use for testing
#>
function Get-SynapseSqlDatabaseName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets a DataLake Analytics storage name to use for testing
#>
function Get-DataLakeStorageAccountName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets a resource group name for testing.
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets test mode - 'Record' or 'Playback'
#>
function Get-SynapseTestMode {
    try {
        $testMode = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode;
        $testMode = $testMode.ToString();
    } catch {
        if ($PSItem.Exception.Message -like '*Unable to find type*') {
            $testMode = 'Record';
        } else {
            throw;
        }
    }

    return $testMode
}

<#
.SYNOPSIS
Executes a cmdlet and enables ignoring of errors if desired
NOTE: this only catches errors that are thrown. If the command calls to Write-Error
the user must specify the errorAction to be silent or store the record in an error variable.
#>
function Invoke-HandledCmdlet
{
    param
    (
        [ScriptBlock] $Command,
        [switch] $IgnoreFailures
    )
    
    try
    {
        &$Command
    }
    catch
    {
        if(!$IgnoreFailures)
        {
            throw;
        }
    }
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Synapse SQL related tests
#>
function Create-SqlTestEnvironmentWithParams ($params, $location)
{
	Create-BasicTestEnvironmentWithParams $params $location
    if(!($params.tags -eq $null) -and !($params.storageAccountType -eq $null))
    {
	    New-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -PerformanceLevel $params.perfLevel -Tag $params.tags -StorageAccountType $params.storageAccountType
	}else{
        New-AzSynapseSqlPool -ResourceGroupName $params.rgname -WorkspaceName $params.workspaceName -SqlPoolName $params.sqlPoolName -PerformanceLevel $params.perfLevel
    }
     Wait-Seconds 10
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Synapse tests
#>
function Create-TestEnvironmentWithParams ($params, $location)
{
	Create-BasicTestEnvironmentWithParams $params $location
	Wait-Seconds 10
}

<#
.SYNOPSIS
Creates the basic test environment needed to perform the Sql data security tests - resource group, server and database
#>
function Create-BasicTestEnvironmentWithParams ($params, $location)
{
	New-AzResourceGroup -Name $params.rgname -Location $location
    New-AzStorageAccount -ResourceGroupName $params.rgname -Name $params.storageAccountName -Location $location -SkuName Standard_GRS -Kind StorageV2 -EnableHierarchicalNamespace $true
	$workspaceName = $params.workspaceName
	$workspaceLogin = $params.loginName
	$workspacePassword = $params.pwd
	$credentials = new-object System.Management.Automation.PSCredential($workspaceLogin, ($workspacePassword | ConvertTo-SecureString -asPlainText -Force))
    New-AzSynapseWorkspace -ResourceGroupName  $params.rgname -WorkspaceName $params.workspaceName -Location $location -SqlAdministratorLoginCredential $credentials -DefaultDataLakeStorageAccountName $params.storageAccountName -DefaultDataLakeStorageFilesystem $params.fileSystemName
}

<#
.SYNOPSIS
Creates the test environment needed to perform the Sql blob auditing tests
#>
function Create-BlobAuditingTestEnvironment ($testSuffix)
{
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
    Create-SqlTestEnvironmentWithParams $params $params.location
	New-AzOperationalInsightsWorkspace -ResourceGroupName $params.rgname -Name $params.logworkspaceName -Sku "Standard" -Location $params.location
	New-AzEventHubNamespace -ResourceGroupName $params.rgname -NamespaceName $params.eventHubNamespace -Location $params.location
}

<#
.SYNOPSIS
Gets the values of the parameters used at the blob auditing tests
#>
function Get-SqlBlobAuditingTestEnvironmentParameters ($testSuffix)
{
	$subscriptionId = (Get-AzContext).Subscription.Id
	return @{ 
			  rgname = "audit-cmdlet-test-rg" +$testSuffix;
			  workspaceName = "audit-cmdlet-workspace" +$testSuffix;
			  sqlPoolName = "auditsqlpool" + $testSuffix;
			  storageAccountName = "sqlstorage" + $testSuffix;
			  fileSystemName = "sqlcmdletfs" + $testSuffix;
			  loginName = "testlogin";
			  pwd = "testp@ssMakingIt1007Longer";
			  perfLevel = 'DW200c';
			  location = "eastus";
			  eventHubNamespace = "audit-cmdlet-event-hub-ns" + $testSuffix
			  logworkspaceName = "audit-cmdlet-logworkspace" +$testSuffix
			  storageAccountResourceId = "/subscriptions/" + $subscriptionId + "/resourceGroups/" + "audit-cmdlet-test-rg" + $testSuffix + "/providers/Microsoft.Storage/storageAccounts/" + "sqlstorage" + $testSuffix
		}
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the Sql blob auditing tests
#>
function Remove-BlobAuditingTestEnvironment ($testSuffix)
{
	$params = Get-SqlBlobAuditingTestEnvironmentParameters $testSuffix
	Remove-AzResourceGroup -Name $params.rgname -Force
}