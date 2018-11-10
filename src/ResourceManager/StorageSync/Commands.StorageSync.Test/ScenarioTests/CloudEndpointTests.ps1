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
Test CloudEndpoint
.DESCRIPTION
SmokeTest
#>
function Test-CloudEndpoint
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $cloudEndpointName = Get-ResourceName("cep")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices")
        $StorageAccountShareName = "testfs" #Get-ResourceName("fs")
        $StorageAccountName = Get-ResourceName("sa")
        $StorageAccountTenantId = (Get-AzureRmTenant).Id

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Resource: $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        $storageAccount = New-AzureRmStorageAccount  -SkuName Standard_LRS -ResourceGroupName $resourceGroupName -Name $StorageAccountName -Location $resourceLocation
        $key = Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $StorageAccountName
        Write-Verbose "Resource: $StorageAccountName | Key: $key[0]" 
        $context = New-AzureStorageContext -StorageAccountName $storageAccount.StorageAccountName -StorageAccountKey $key[0].Value
        Write-Verbose "Resource: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"

        if(IsLive)
        {
            $azureFileShare = New-AzureStorageShare -Name $StorageAccountShareName -Context $context
            $azureFileShareName = $azureFileShare.Name 
        }
        else 
        {
                $azureFileShareName = $StorageAccountShareName
        }

        $storageAccountResourceId = $storageAccount.Id

        Write-Verbose "Resource: $cloudEndpointName | Loc: $resourceLocation | Type : CloudEndpoint"
        $cloudEndpoint = New-AzureRmStorageSyncCloudEndpoint -ResourceGroupName $syncGroup.ResourceGroupName  -StorageSyncServiceName $syncGroup.StorageSyncServiceName -SyncGroupName $syncGroup.SyncGroupName -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId -Verbose

        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $storageAccountResourceId $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Get CloudEndpoint by Name"
        $cloudEndpoint = Get-AzureRMStorageSyncCloudEndpoint -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName -CloudEndpointName $cloudEndpointName 

        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $StorageAccount.Id $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Get CloudEndpoint by ParentObject"
        $cloudEndpoint = Get-AzureRMStorageSyncCloudEndpoint -ParentObject $syncGroup -Name $cloudEndpointName -Verbose
        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $StorageAccount.Id $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Get CloudEndpoint by ParentResourceId"
        $cloudEndpoint = Get-AzureRMStorageSyncCloudEndpoint -ParentResourceId $syncGroup.ResourceId -Name $cloudEndpointName -Verbose
        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $StorageAccount.Id $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Removing CloudEndpoint: $cloudEndpointName"
        Remove-AzureRMStorageSyncCloudEndpoint -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName -Name $cloudEndpointName -AsJob | Wait-Job

        Write-Verbose "Executing Piping Scenarios"
        New-AzureRMStorageSyncCloudEndpoint -ParentObject $syncGroup -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId | Get-AzureRMStorageSyncCloudEndpoint  | Remove-AzureRMStorageSyncCloudEndpoint -Force -AsJob | Wait-Job

        New-AzureRMStorageSyncCloudEndpoint -ParentResourceId $syncGroup.ResourceId -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId | Remove-AzureRMStorageSyncCloudEndpoint -Force -AsJob | Wait-Job

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        if(IsLive)
        {
            Write-Verbose "Removing: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"
            $azureFileShare = Remove-AzureStorageShare -Name $StorageAccountShareName -Context $context -Force
        }

        Write-Verbose "Removing $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        Remove-AzureRmStorageAccount -Force -ResourceGroupName $resourceGroupName -Name $StorageAccountName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
       Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test NewCloudEndpoint
.DESCRIPTION
SmokeTest
#>
function Test-NewCloudEndpoint
{
  # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $cloudEndpointName = Get-ResourceName("cep")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices")
        $StorageAccountShareName = "testfs" #Get-StorageManagementTestResourceName
        $StorageAccountName = Get-ResourceName("sa")
        $StorageAccountTenantId = (Get-AzureRmTenant).Id

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Resource: $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        $storageAccount = New-AzureRmStorageAccount  -SkuName Standard_LRS -ResourceGroupName $resourceGroupName -Name $StorageAccountName -Location $resourceLocation
        $key = Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $StorageAccountName
        Write-Verbose "Resource: $StorageAccountName | Key: $key[0]" 
        $context = New-AzureStorageContext -StorageAccountName $storageAccount.StorageAccountName -StorageAccountKey $key[0].Value
        Write-Verbose "Resource: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"

        if(IsLive)
        {
            $azureFileShare = New-AzureStorageShare -Name $StorageAccountShareName -Context $context
            $azureFileShareName = $azureFileShare.Name 
        }
        else 
        {
                $azureFileShareName = $StorageAccountShareName
        }

        $storageAccountResourceId = $storageAccount.Id

        Write-Verbose "Resource: $cloudEndpointName | Loc: $resourceLocation | Type : CloudEndpoint"
        $cloudEndpoint = New-AzureRmStorageSyncCloudEndpoint -ResourceGroupName $syncGroup.ResourceGroupName  -StorageSyncServiceName $syncGroup.StorageSyncServiceName -SyncGroupName $syncGroup.SyncGroupName -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId -Verbose

        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $storageAccountResourceId $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Removing CloudEndpoint: $cloudEndpointName"
        Remove-AzureRMStorageSyncCloudEndpoint -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName -Name $cloudEndpointName -AsJob | Wait-Job

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        if(IsLive)
        {
            Write-Verbose "Removing: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"
            $azureFileShare = Remove-AzureStorageShare -Name $StorageAccountShareName -Context $context -Force
        }

        Write-Verbose "Removing $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        Remove-AzureRmStorageAccount -Force -ResourceGroupName $resourceGroupName -Name $StorageAccountName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
       Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test GetCloudEndpoint
.DESCRIPTION
SmokeTest
#>
function Test-GetCloudEndpoint
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $cloudEndpointName = Get-ResourceName("cep")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices")
        $StorageAccountShareName = "testfs" #Get-StorageManagementTestResourceName
        $StorageAccountName = Get-ResourceName("sa")
        $StorageAccountTenantId = (Get-AzureRmTenant).Id

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Resource: $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        $storageAccount = New-AzureRmStorageAccount  -SkuName Standard_LRS -ResourceGroupName $resourceGroupName -Name $StorageAccountName -Location $resourceLocation
        $key = Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $StorageAccountName
        Write-Verbose "Resource: $StorageAccountName | Key: $key[0]" 
        $context = New-AzureStorageContext -StorageAccountName $storageAccount.StorageAccountName -StorageAccountKey $key[0].Value
        Write-Verbose "Resource: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"

        if(IsLive)
        {
            $azureFileShare = New-AzureStorageShare -Name $StorageAccountShareName -Context $context
            $azureFileShareName = $azureFileShare.Name 
        }
        else 
        {
                $azureFileShareName = $StorageAccountShareName
        }

        $storageAccountResourceId = $storageAccount.Id

        Write-Verbose "Resource: $cloudEndpointName | Loc: $resourceLocation | Type : CloudEndpoint"
        $cloudEndpoint = New-AzureRmStorageSyncCloudEndpoint -ResourceGroupName $syncGroup.ResourceGroupName  -StorageSyncServiceName $syncGroup.StorageSyncServiceName -SyncGroupName $syncGroup.SyncGroupName -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId -Verbose

        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $storageAccountResourceId $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Get CloudEndpoint by Name"
        $cloudEndpoint = Get-AzureRMStorageSyncCloudEndpoint -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName -CloudEndpointName $cloudEndpointName 

        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $StorageAccount.Id $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Removing CloudEndpoint: $cloudEndpointName"
        Remove-AzureRMStorageSyncCloudEndpoint -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName -Name $cloudEndpointName -AsJob | Wait-Job

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        if(IsLive)
        {
            Write-Verbose "Removing: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"
            $azureFileShare = Remove-AzureStorageShare -Name $StorageAccountShareName -Context $context -Force
        }

        Write-Verbose "Removing $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        Remove-AzureRmStorageAccount -Force -ResourceGroupName $resourceGroupName -Name $StorageAccountName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
       Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test GetCloudEndpoints
.DESCRIPTION
SmokeTest
#>
function Test-GetCloudEndpoints
{
    # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $cloudEndpointName = Get-ResourceName("cep")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices")
        $StorageAccountShareName = "testfs" #Get-StorageManagementTestResourceName
        $StorageAccountName = Get-ResourceName("sa")
        $StorageAccountTenantId = (Get-AzureRmTenant).Id

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Resource: $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        $storageAccount = New-AzureRmStorageAccount  -SkuName Standard_LRS -ResourceGroupName $resourceGroupName -Name $StorageAccountName -Location $resourceLocation
        $key = Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $StorageAccountName
        Write-Verbose "Resource: $StorageAccountName | Key: $key[0]" 
        $context = New-AzureStorageContext -StorageAccountName $storageAccount.StorageAccountName -StorageAccountKey $key[0].Value
        Write-Verbose "Resource: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"

        if(IsLive)
        {
            $azureFileShare = New-AzureStorageShare -Name $StorageAccountShareName -Context $context
            $azureFileShareName = $azureFileShare.Name 
        }
        else 
        {
                $azureFileShareName = $StorageAccountShareName
        }

        $storageAccountResourceId = $storageAccount.Id

        Write-Verbose "Resource: $cloudEndpointName | Loc: $resourceLocation | Type : CloudEndpoint"
        $cloudEndpoint = New-AzureRmStorageSyncCloudEndpoint -ResourceGroupName $syncGroup.ResourceGroupName  -StorageSyncServiceName $syncGroup.StorageSyncServiceName -SyncGroupName $syncGroup.SyncGroupName -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId -Verbose

        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $storageAccountResourceId $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Get CloudEndpoint by SyncGroup"
        $cloudEndpoints = Get-AzureRMStorageSyncCloudEndpoint -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName

        Assert-AreEqual $cloudEndpoints.Length 1
        $cloudEndpoint = $cloudEndpoints[0]

        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $StorageAccount.Id $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Removing CloudEndpoint: $cloudEndpointName"
        Remove-AzureRMStorageSyncCloudEndpoint -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName -Name $cloudEndpointName -AsJob | Wait-Job

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        if(IsLive)
        {
            Write-Verbose "Removing: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"
            $azureFileShare = Remove-AzureStorageShare -Name $StorageAccountShareName -Context $context -Force
        }

        Write-Verbose "Removing $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        Remove-AzureRmStorageAccount -Force -ResourceGroupName $resourceGroupName -Name $StorageAccountName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
       Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test GetCloudEndpointParentObject
.DESCRIPTION
SmokeTest
#>
function Test-GetCloudEndpointParentObject
{
   # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $cloudEndpointName = Get-ResourceName("cep")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices")
        $StorageAccountShareName = "testfs" #Get-StorageManagementTestResourceName
        $StorageAccountName = Get-ResourceName("sa")
        $StorageAccountTenantId = (Get-AzureRmTenant).Id

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Resource: $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        $storageAccount = New-AzureRmStorageAccount  -SkuName Standard_LRS -ResourceGroupName $resourceGroupName -Name $StorageAccountName -Location $resourceLocation
        $key = Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $StorageAccountName
        Write-Verbose "Resource: $StorageAccountName | Key: $key[0]" 
        $context = New-AzureStorageContext -StorageAccountName $storageAccount.StorageAccountName -StorageAccountKey $key[0].Value
        Write-Verbose "Resource: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"

        if(IsLive)
        {
            $azureFileShare = New-AzureStorageShare -Name $StorageAccountShareName -Context $context
            $azureFileShareName = $azureFileShare.Name 
        }
        else 
        {
                $azureFileShareName = $StorageAccountShareName
        }

        $storageAccountResourceId = $storageAccount.Id

        Write-Verbose "Resource: $cloudEndpointName | Loc: $resourceLocation | Type : CloudEndpoint"
        $cloudEndpoint = New-AzureRmStorageSyncCloudEndpoint -ResourceGroupName $syncGroup.ResourceGroupName  -StorageSyncServiceName $syncGroup.StorageSyncServiceName -SyncGroupName $syncGroup.SyncGroupName -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId -Verbose

        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $storageAccountResourceId $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Get CloudEndpoint by ParentObject"
        $cloudEndpoint = Get-AzureRMStorageSyncCloudEndpoint -ParentObject $syncGroup -Name $cloudEndpointName -Verbose
        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $StorageAccount.Id $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Removing CloudEndpoint: $cloudEndpointName"
        Remove-AzureRMStorageSyncCloudEndpoint -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName -Name $cloudEndpointName -AsJob | Wait-Job

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        if(IsLive)
        {
            Write-Verbose "Removing: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"
            $azureFileShare = Remove-AzureStorageShare -Name $StorageAccountShareName -Context $context -Force
        }

        Write-Verbose "Removing $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        Remove-AzureRmStorageAccount -Force -ResourceGroupName $resourceGroupName -Name $StorageAccountName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
       Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test GetCloudEndpointParentResourceId
.DESCRIPTION
SmokeTest
#>
function Test-GetCloudEndpointParentResourceId
{
   # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $cloudEndpointName = Get-ResourceName("cep")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices")
        $StorageAccountShareName = "testfs" #Get-StorageManagementTestResourceName
        $StorageAccountName = Get-ResourceName("sa")
        $StorageAccountTenantId = (Get-AzureRmTenant).Id

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Resource: $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        $storageAccount = New-AzureRmStorageAccount  -SkuName Standard_LRS -ResourceGroupName $resourceGroupName -Name $StorageAccountName -Location $resourceLocation
        $key = Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $StorageAccountName
        Write-Verbose "Resource: $StorageAccountName | Key: $key[0]" 
        $context = New-AzureStorageContext -StorageAccountName $storageAccount.StorageAccountName -StorageAccountKey $key[0].Value
        Write-Verbose "Resource: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"

        if(IsLive)
        {
            $azureFileShare = New-AzureStorageShare -Name $StorageAccountShareName -Context $context
            $azureFileShareName = $azureFileShare.Name 
        }
        else 
        {
                $azureFileShareName = $StorageAccountShareName
        }

        $storageAccountResourceId = $storageAccount.Id

        Write-Verbose "Resource: $cloudEndpointName | Loc: $resourceLocation | Type : CloudEndpoint"
        $cloudEndpoint = New-AzureRmStorageSyncCloudEndpoint -ResourceGroupName $syncGroup.ResourceGroupName  -StorageSyncServiceName $syncGroup.StorageSyncServiceName -SyncGroupName $syncGroup.SyncGroupName -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId -Verbose

        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $storageAccountResourceId $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Get CloudEndpoint by ParentResourceId"
        $cloudEndpoint = Get-AzureRMStorageSyncCloudEndpoint -ParentResourceId $syncGroup.ResourceId -Name $cloudEndpointName -Verbose
        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $StorageAccount.Id $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Removing CloudEndpoint: $cloudEndpointName"
        Remove-AzureRMStorageSyncCloudEndpoint -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName -Name $cloudEndpointName -AsJob | Wait-Job

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        if(IsLive)
        {
            Write-Verbose "Removing: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"
            $azureFileShare = Remove-AzureStorageShare -Name $StorageAccountShareName -Context $context -Force
        }

        Write-Verbose "Removing $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        Remove-AzureRmStorageAccount -Force -ResourceGroupName $resourceGroupName -Name $StorageAccountName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test RemoveCloudEndpoint
.DESCRIPTION
SmokeTest
#>
function Test-RemoveCloudEndpoint
{
     # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $cloudEndpointName = Get-ResourceName("cep")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices")
        $StorageAccountShareName = "testfs" #Get-StorageManagementTestResourceName
        $StorageAccountName = Get-ResourceName("sa")
        $StorageAccountTenantId = (Get-AzureRmTenant).Id

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Resource: $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        $storageAccount = New-AzureRmStorageAccount  -SkuName Standard_LRS -ResourceGroupName $resourceGroupName -Name $StorageAccountName -Location $resourceLocation
        $key = Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $StorageAccountName
        Write-Verbose "Resource: $StorageAccountName | Key: $key[0]" 
        $context = New-AzureStorageContext -StorageAccountName $storageAccount.StorageAccountName -StorageAccountKey $key[0].Value
        Write-Verbose "Resource: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"

        if(IsLive)
        {
            $azureFileShare = New-AzureStorageShare -Name $StorageAccountShareName -Context $context
            $azureFileShareName = $azureFileShare.Name 
        }
        else 
        {
                $azureFileShareName = $StorageAccountShareName
        }

        $storageAccountResourceId = $storageAccount.Id

        Write-Verbose "Resource: $cloudEndpointName | Loc: $resourceLocation | Type : CloudEndpoint"
        $cloudEndpoint = New-AzureRmStorageSyncCloudEndpoint -ResourceGroupName $syncGroup.ResourceGroupName  -StorageSyncServiceName $syncGroup.StorageSyncServiceName -SyncGroupName $syncGroup.SyncGroupName -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId -Verbose

        Write-Verbose "Validating CloudEndpoint Properties"
        Assert-AreEqual $cloudEndpointName $cloudEndpoint.CloudEndpointName
        Assert-AreEqual $storageAccountResourceId $cloudEndpoint.StorageAccountResourceId
        Assert-AreEqual $StorageAccountTenantId $cloudEndpoint.StorageAccountTenantId

        Write-Verbose "Get CloudEndpoint by Name"
        $cloudEndpoint = Get-AzureRMStorageSyncCloudEndpoint -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName -CloudEndpointName $cloudEndpointName 

        Write-Verbose "Removing CloudEndpoint: $cloudEndpointName"
        Remove-AzureRMStorageSyncCloudEndpoint -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -SyncGroupName $syncGroupName -Name $cloudEndpointName -AsJob | Wait-Job

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        if(IsLive)
        {
            Write-Verbose "Removing: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"
            $azureFileShare = Remove-AzureStorageShare -Name $StorageAccountShareName -Context $context -Force
        }

        Write-Verbose "Removing $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        Remove-AzureRmStorageAccount -Force -ResourceGroupName $resourceGroupName -Name $StorageAccountName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
       Clean-ResourceGroup $resourceGroupName
    }
}

<#
.SYNOPSIS
Test RemoveCloudEndpointInputObject
.DESCRIPTION
SmokeTest
#>
function Test-RemoveCloudEndpointInputObject
{
     # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $cloudEndpointName = Get-ResourceName("cep")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices")
        $StorageAccountShareName = "testfs" #Get-StorageManagementTestResourceName
        $StorageAccountName = Get-ResourceName("sa")
        $StorageAccountTenantId = (Get-AzureRmTenant).Id

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Resource: $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        $storageAccount = New-AzureRmStorageAccount  -SkuName Standard_LRS -ResourceGroupName $resourceGroupName -Name $StorageAccountName -Location $resourceLocation
        $key = Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $StorageAccountName
        Write-Verbose "Resource: $StorageAccountName | Key: $key[0]" 
        $context = New-AzureStorageContext -StorageAccountName $storageAccount.StorageAccountName -StorageAccountKey $key[0].Value
        Write-Verbose "Resource: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"

        if(IsLive)
        {
            $azureFileShare = New-AzureStorageShare -Name $StorageAccountShareName -Context $context
            $azureFileShareName = $azureFileShare.Name 
        }
        else 
        {
                $azureFileShareName = $StorageAccountShareName
        }

        $storageAccountResourceId = $storageAccount.Id

        Write-Verbose "Resource: $cloudEndpointName | Loc: $resourceLocation | Type : CloudEndpoint"
        $cloudEndpoint = New-AzureRmStorageSyncCloudEndpoint -ResourceGroupName $syncGroup.ResourceGroupName  -StorageSyncServiceName $syncGroup.StorageSyncServiceName -SyncGroupName $syncGroup.SyncGroupName -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId -Verbose

        Write-Verbose "Removing CloudEndpoint: $cloudEndpointName"
        Remove-AzureRMStorageSyncCloudEndpoint -Force -InputObject $cloudEndpoint -AsJob | Wait-Job

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        if(IsLive)
        {
            Write-Verbose "Removing: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"
            $azureFileShare = Remove-AzureStorageShare -Name $StorageAccountShareName -Context $context -Force
        }

        Write-Verbose "Removing $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        Remove-AzureRmStorageAccount -Force -ResourceGroupName $resourceGroupName -Name $StorageAccountName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}


<#
.SYNOPSIS
Test RemoveCloudEndpointResourceId
.DESCRIPTION
SmokeTest
#>
function Test-RemoveCloudEndpointResourceId
{
     # Setup
    $resourceGroupName = Get-ResourceGroupName

    try
    {
        # Test
        $storageSyncServiceName = Get-ResourceName("sss")
        $syncGroupName = Get-ResourceName("sg")
        $cloudEndpointName = Get-ResourceName("cep")
        $resourceLocation = Get-StorageSyncLocation("Microsoft.StorageSync/storageSyncServices")
        $StorageAccountShareName = "testfs" #Get-StorageManagementTestResourceName
        $StorageAccountName = Get-ResourceName("sa")
        $StorageAccountTenantId = (Get-AzureRmTenant).Id

        Write-Verbose "RGName: $resourceGroupName | Loc: $resourceLocation | Type : ResourceGroup"
        New-AzureRmResourceGroup -Name $resourceGroupName -Location $resourceLocation;

        Write-Verbose "Resource: $storageSyncServiceName | Loc: $resourceLocation | Type : StorageSyncService"
        New-AzureRmStorageSyncService -ResourceGroupName $resourceGroupName -Location $resourceLocation -StorageSyncServiceName $storageSyncServiceName

        Write-Verbose "Resource: $syncGroupName | Loc: $resourceLocation | Type : SyncGroup"
        $syncGroup = New-AzureRmStorageSyncGroup -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName

        Write-Verbose "Resource: $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        $storageAccount = New-AzureRmStorageAccount  -SkuName Standard_LRS -ResourceGroupName $resourceGroupName -Name $StorageAccountName -Location $resourceLocation
        $key = Get-AzureRmStorageAccountKey -ResourceGroupName $resourceGroupName -Name $StorageAccountName
        Write-Verbose "Resource: $StorageAccountName | Key: $key[0]" 
        $context = New-AzureStorageContext -StorageAccountName $storageAccount.StorageAccountName -StorageAccountKey $key[0].Value
        Write-Verbose "Resource: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"

        if(IsLive)
        {
            $azureFileShare = New-AzureStorageShare -Name $StorageAccountShareName -Context $context
            $azureFileShareName = $azureFileShare.Name 
        }
        else 
        {
                $azureFileShareName = $StorageAccountShareName
        }

        $storageAccountResourceId = $storageAccount.Id

        Write-Verbose "Resource: $cloudEndpointName | Loc: $resourceLocation | Type : CloudEndpoint"
        $cloudEndpoint = New-AzureRmStorageSyncCloudEndpoint -ResourceGroupName $syncGroup.ResourceGroupName  -StorageSyncServiceName $syncGroup.StorageSyncServiceName -SyncGroupName $syncGroup.SyncGroupName -Name $cloudEndpointName -StorageAccountResourceId $storageAccountResourceId -StorageAccountShareName $azureFileShareName -StorageAccountTenantId $StorageAccountTenantId -Verbose

        Write-Verbose "Removing CloudEndpoint: $cloudEndpointName"
        Remove-AzureRMStorageSyncCloudEndpoint -Force -ResourceId $cloudEndpoint.ResourceId -AsJob | Wait-Job

        Write-Verbose "Removing SyncGroup: $syncGroupName"
        Remove-AzureRmStorageSyncGroup -Force -ResourceGroupName $resourceGroupName -StorageSyncServiceName $storageSyncServiceName -Name $syncGroupName -AsJob | Wait-Job

        Write-Verbose "Removing StorageSyncService: $storageSyncServiceName"
        Remove-AzureRmStorageSyncService -Force -ResourceGroupName $resourceGroupName -Name $storageSyncServiceName -AsJob | Wait-Job

        if(IsLive)
        {
            Write-Verbose "Removing: $StorageAccountShareName | Loc: $resourceLocation | Type : AzureStorageShare"
            $azureFileShare = Remove-AzureStorageShare -Name $StorageAccountShareName -Context $context -Force
        }

        Write-Verbose "Removing $StorageAccountName | Loc: $resourceLocation | Type : StorageAccount"
        Remove-AzureRmStorageAccount -Force -ResourceGroupName $resourceGroupName -Name $StorageAccountName
    }
    finally
    {
        # Cleanup
        Write-Verbose "Removing ResourceGroup : $resourceGroupName"
        Clean-ResourceGroup $resourceGroupName
    }
}