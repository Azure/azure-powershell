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
Create, update, and delete storage insights
#>
function Test-DataSourceCreateUpdateDelete
{
    $wsname = Get-ResourceName
    $dsName = Get-ResourceName
    $saname = Get-ResourceName
    $rgname = Get-ResourceGroupName
    #$said = Get-StorageResourceId $rgname $saname
	$subId1 = "0b88dfdb-55b3-4fb0-b474-5b6dcbe6b2ef"
	$subId2 = "bc8edd8f-a09f-499d-978d-6b5ed2f84852"
    $wslocation = Get-ProviderLocation
    
    New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

    # Create a workspace to house the storage insight
    $workspace = New-AzureRmOperationalInsightsWorkspace -ResourceGroupName $rgname -Name $wsname -Location $wslocation -Force

    # Create a storage insight
    $dataSource = New-AzureRmOperationalInsightsAzureAuditDataSource -ResourceGroupName $rgname -WorkspaceName $wsname -Name $dsName -SubscriptionId $subId1
    Assert-AreEqual $dsName $dataSource.Name
    Assert-NotNull $dataSource.ResourceId
    Assert-AreEqual $rgname $dataSource.ResourceGroupName
    Assert-AreEqual $wsname $dataSource.WorkspaceName
    Assert-AreEqual $subId1 $dataSource.Properties.SubscriptionId
    Assert-AreEqual "AzureAuditLog" $dataSource.Kind

    # Get the storage insight that was created
    $dataSource = Get-AzureRmOperationalInsightsDataSource -ResourceGroupName $rgname -WorkspaceName $wsname -Name $dsName
    Assert-AreEqual $dsName $dataSource.Name
    Assert-NotNull $dataSource.ResourceId
    Assert-AreEqual $rgname $dataSource.ResourceGroupName
    Assert-AreEqual $wsname $dataSource.WorkspaceName
    Assert-AreEqual $subId1 $dataSource.Properties.SubscriptionId
    Assert-AreEqual "AzureAuditLog" $dataSource.Kind

    # Create a second storage insight for list testing
    $daNametwo = Get-ResourceName
    $dataSource = New-AzureRmOperationalInsightsAzureAuditDataSource -ResourceGroupName $rgname -WorkspaceName $wsname -Name $daNametwo -SubscriptionId $subId2

    # List the storage insight in the workspace (both param sets)
    $dataSources = Get-AzureRmOperationalInsightsDataSource -ResourceGroupName $rgname -WorkspaceName $wsname
    Assert-AreEqual 2 $dataSources.Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $dsName}).Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $daNametwo}).Count

    $dataSources = Get-AzureRmOperationalInsightsDataSource -Workspace $workspace
    Assert-AreEqual 2 $dataSources.Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $dsName}).Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $daNametwo}).Count

    # Delete one of the storage insights
    Remove-AzureRmOperationalInsightsDataSource -ResourceGroupName $rgname -WorkspaceName $wsname -Name $daNametwo -Force
    Assert-ThrowsContains { Get-AzureRmOperationalInsightsDataSource -Workspace $workspace -Name $daNametwo } "NotFound"
    $dataSources = Get-AzureRmOperationalInsightsDataSource -Workspace $workspace
    Assert-AreEqual 1 $dataSources.Count
    Assert-AreEqual 1 ($dataSources | Where {$_.Name -eq $dsName}).Count
    Assert-AreEqual 0 ($dataSources | Where {$_.Name -eq $daNametwo}).Count

    # Perform an update on the storage insight
	$dataSource = $dataSources[0]
	$dataSource.Properties.SubscriptionId = $subId2
    $dataSource = Set-AzureRmOperationalInsightsDataSource -DataSource $dataSource
    Assert-AreEqual "AzureAuditLog" $dataSource.Kind
    Assert-AreEqual $subId2 $dataSource.Properties.SubscriptionId

    # Delete the remaining storage insight via piping
    Remove-AzureRmOperationalInsightsDataSource -Workspace $workspace -Name $dsName -Force
    Assert-ThrowsContains { Get-AzureRmOperationalInsightsDataSource -Workspace $workspace -Name $dsName } "NotFound"
    $dataSources = Get-AzureRmOperationalInsightsDataSource -Workspace $workspace
    Assert-AreEqual 0 $dataSources.Count
}

<#
.SYNOPSIS
Validate that data source creation fails without a valid parent workspace
#>
function Test-DataSourceCreateFailsWithoutWorkspace
{
    $wsname = Get-ResourceName
    $dsName = Get-ResourceName
    $saname = Get-ResourceName
    $rgname = Get-ResourceGroupName
	$subId1 = "0b88dfdb-55b3-4fb0-b474-5b6dcbe6b2ef"
    $wslocation = Get-ProviderLocation
    
    New-AzureRmResourceGroup -Name $rgname -Location $wslocation -Force

    Assert-ThrowsContains { New-AzureRmOperationalInsightsAzureAuditDataSource -ResourceGroupName $rgname -WorkspaceName $wsname -Name $dsName -SubscriptionId $subId1 } "ResourceNotFound"
}