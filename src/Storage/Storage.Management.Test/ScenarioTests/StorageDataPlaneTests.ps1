

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
    Tests File-only related commands.
#>
function Test-File
{        
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try{
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

        $localSrcFile = "localsrcfiletestfile.psd1" #The file need exist before test, and should be 512 bytes aligned
        New-Item $localSrcFile -ItemType File -Force
        $localDestFile = "localdestfiletestfile1.txt"    

        $objectName1 = "filetest1.txt" 
        $objectName2 = "filetest2.txt"  
        $shareName = "filetestshare" 

        #Create a file share 
        New-AzStorageShare $shareName -Context $storageContext
        $Share = Get-AzStorageShare -Name $shareName -Context $storageContext
        Assert-AreEqual $Share.Count 1
        Assert-AreEqual $Share[0].Name $shareName

        $t = Set-AzStorageFileContent -source $localSrcFile -ShareName $shareName -Path $objectName1 -Force -Context $storageContext -asjob
		$t | wait-job
		Assert-AreEqual $t.State "Completed"
		Assert-AreEqual $t.Error $null
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName1
		Set-AzStorageFileContent -source $localSrcFile -ShareName $shareName -Path $objectName1 -Force -Context $storageContext
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName1

        Start-AzStorageFileCopy -SrcShareName $shareName -SrcFilePath $objectName1 -DestShareName $shareName -DestFilePath $objectName2 -Force -Context $storageContext -DestContext $storageContext
        Get-AzStorageFileCopyState -ShareName $shareName -FilePath $objectName2 -Context $storageContext -WaitForComplete
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 2
        Assert-AreEqual $file[0].Name $objectName1
        Assert-AreEqual $file[1].Name $objectName2

        $t = Get-AzStorageFileContent -ShareName $shareName -Path $objectName1 -Destination $localDestFile -Force -Context $storageContext  -asjob
		$t | wait-job
		Assert-AreEqual $t.State "Completed"
		Assert-AreEqual $t.Error $null   
        Assert-AreEqual (Get-FileHash -Path $localDestFile -Algorithm MD5).Hash (Get-FileHash -Path $localSrcFile -Algorithm MD5).Hash
		Get-AzStorageFileContent -ShareName $shareName -Path $objectName1 -Destination $localDestFile -Force -Context $storageContext
        Assert-AreEqual (Get-FileHash -Path $localDestFile -Algorithm MD5).Hash (Get-FileHash -Path $localSrcFile -Algorithm MD5).Hash

        Remove-AzStorageFile -ShareName $shareName -Path $objectName1 -Context $storageContext
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName2

        $dirName = "filetestdir"
        New-AzStorageDirectory -ShareName $shareName -Path $dirName -Context $storageContext    
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 2
        Assert-AreEqual $file[0].Name $objectName2
        Assert-AreEqual $file[0].GetType().Name "CloudFile"
        Assert-AreEqual $file[1].Name $dirName
        Assert-AreEqual $file[1].GetType().Name "CloudFileDirectory"
        Remove-AzStorageDirectory -ShareName $shareName -Path $dirName -Context $storageContext  
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName2
        Assert-AreEqual $file[0].GetType().Name "CloudFile"  

        # Clean Storage Account
        Remove-AzStorageShare -Name $shareName -Force -Context $storageContext
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
    
}

<#
    .SYNOPSIS
    Tests Blob-only related commands.
#>
function Test-Blob
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try{

        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

        $localSrcFile = "localsrcblobtestfile.psd1" #The file need exist before test, and should be 512 bytes aligned
        New-Item $localSrcFile -ItemType File -Force
        $localDestFile = "localdestblobtestfile.txt"
        $localDestFile2 = "localdestblobtestfile2.txt"

        $containerName = "blobtestcontainer"          
        $objectName1 = "blobtest1.txt"
        $objectName2 = "blobtest2.txt"
        $ContentType = "image/jpeg"
        $ContentMD5 = "i727sP7HigloQDsqadNLHw=="

        # Create Container for blob
        New-AzStorageContainer $containerName -Context $storageContext

        # Upload local file to Azure Storage Blob.
        $t = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob $objectName1 -Force -Properties @{"ContentType" = $ContentType; "ContentMD5" = $ContentMD5} -Context $storageContext -asjob
		$t | wait-job
		Assert-AreEqual $t.State "Completed"
		Assert-AreEqual $t.Error $null
        $blob = Get-AzStorageContainer -Name $containerName -Context $storageContext | Get-AzStorageBlob
        Assert-AreEqual $blob.Count 1
        Assert-AreEqual $blob.Name $objectName1
        Assert-AreEqual $blob.ICloudBlob.Properties.ContentType $ContentType
        Assert-AreEqual $blob.ICloudBlob.Properties.ContentMD5 $ContentMD5
		Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob $objectName2 -Force -Properties @{"ContentType" = $ContentType; "ContentMD5" = $ContentMD5} -Context $storageContext
        $blob = Get-AzStorageContainer -Name $containerName -Context $storageContext | Get-AzStorageBlob
        Assert-AreEqual $blob.Count 2
        Get-AzStorageBlob -Container $containerName -Blob $objectName2 -Context $storageContext | Remove-AzStorageBlob -Force 

        # Copy blob to the same container, but with a different name.
        Start-AzStorageBlobCopy -srcContainer $containerName -SrcBlob $objectName1 -DestContainer $containerName -DestBlob $objectName2 -Context $storageContext -DestContext $storageContext
        Get-AzStorageBlobCopyState -Container $containerName -Blob $objectName2 -Context $storageContext
        $blob = Get-AzStorageBlob -Container $containerName -Context $storageContext
        Assert-AreEqual $blob.Count 2
        Assert-AreEqual $blob[0].Name $objectName1
        Assert-AreEqual $blob[1].Name $objectName2

        # Download storage blob to compare with the local file.
        Get-AzStorageBlobContent -Container $containerName -Blob $objectName2 -Destination $localDestFile -Force -Context $storageContext
        Assert-AreEqual (Get-FileHash -Path $localDestFile -Algorithm MD5).Hash (Get-FileHash -Path $localSrcFile -Algorithm MD5).Hash
        $t = Get-AzStorageBlobContent -Container $containerName -Blob $objectName2 -Destination $localDestFile2 -Force -Context $storageContext -asjob
		$t | wait-job
		Assert-AreEqual $t.State "Completed"
		Assert-AreEqual $t.Error $null
        Assert-AreEqual (Get-FileHash -Path $localDestFile2 -Algorithm MD5).Hash (Get-FileHash -Path $localSrcFile -Algorithm MD5).Hash

        Remove-AzStorageBlob -Container $containerName -Blob $objectName2 -Force -Context $storageContext
        $blob = Get-AzStorageBlob -Container $containerName -Context $storageContext
        Assert-AreEqual $blob.Count 1
        Assert-AreEqual $blob[0].Name $objectName1
        
        $pageBlobName1 = "blobpage1"
        $pageBlobName2 = "blobpage2"
        $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob $pageBlobName1 -Force -BlobType page -Context $storageContext
        $task = $b.ICloudBlob.SnapshotAsync() 
		$task.Wait()
		$snapshot = $task.Result  
        $blob = Get-AzStorageBlob -Container $containerName -Context $storageContext | Where-Object {$_.Name -eq $pageBlobName1}
        Assert-AreEqual $blob.Count 2
        Assert-AreEqual $blob[0].ICloudBlob.IsSnapshot $true
        Assert-AreEqual $blob[1].ICloudBlob.IsSnapshot $false

        # Copy snapshot of the source page blob to a destination page blob. The snapshot is copied such that only differential changes 
        # between the previously copied snapshot are transferred to the destination.
        Start-AzStorageBlobIncrementalCopy -srcContainer $containerName -SrcBlob $pageBlobName1 -SrcBlobSnapshotTime $snapshot.SnapshotTime -DestContainer $containerName -DestBlob $pageBlobName2 -Context $storageContext -DestContext $storageContext
        Get-AzStorageBlobCopyState -WaitForComplete -Container $containerName -Blob $pageBlobName2 -Context $storageContext
		$blob = Get-AzStorageBlob -Container $containerName -Context $storageContext | Where-Object {$_.Name -eq $pageBlobName2}
        Assert-AreEqual $blob.Count 2
        Assert-AreEqual $blob[0].ICloudBlob.IsSnapshot $true
        Assert-AreEqual $blob[1].ICloudBlob.IsSnapshot $false

        # Clean Storage Account
        Remove-AzStorageContainer -Name $containerName -Force -Context $storageContext
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
}

<#
    .SYNOPSIS
    Tests Queue related commands.
#>
function Test-Queue
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try
    {
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

        $queueName = "queue-test"
        New-AzStorageQueue -Name $queueName -Context $storageContext
        $queue = Get-AzStorageQueue -Name $queueName -Context $storageContext
        Assert-AreEqual $queue.Count 1
        Assert-AreEqual $queue[0].Name $queueName

		$queueMessage = New-Object -TypeName "Microsoft.Azure.Storage.Queue.CloudQueueMessage" -ArgumentList "This is message 1"
        $queue.CloudQueue.AddMessageAsync($QueueMessage)
        
        $queueCount1 = (Get-AzStorageQueue -Context $storageContext).Count
        Remove-AzStorageQueue -Name $queueName -Force -Context $storageContext
        $queue2 = Get-AzStorageQueue -Context $storageContext # modified, it did not assign to anything 
        if ($null -eq $queue2) { # modified, PS guidelines require null on the left side
            $queueCount2 = 0
        }
        else {
            $queueCount2 = $queue2.Count
        }    
        Assert-AreEqual ($queueCount1-$queueCount2) 1
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
}

<#
    .SYNOPSIS
    Tests Table related commands.
#>
function Test-Table
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try
    {
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue
		
        # Create Table
        $tableName = "tabletest"
        New-AzStorageTable -Name $tableName -Context $storageContext
        $table =Get-AzStorageTable -Name $tableName -Context $storageContext
        Assert-AreEqual $table.Count 1
        Assert-AreEqual $table[0].Name $tableName

        #Test run Table query - Insert Entity
        $partitionKey = "p123"
        $rowKey = "row123"
        $entity = New-Object -TypeName Microsoft.Azure.Cosmos.Table.DynamicTableEntity -ArgumentList $partitionKey, $rowKey
        $entity.Properties.Add("Name", "name1")
        $entity.Properties.Add("ID", 4567)
        $result = $table.CloudTable.ExecuteAsync([Microsoft.Azure.Cosmos.Table.TableOperation]::Insert($entity)) 
        
        # Create Table Object - which reference to exist Table with SAS
        $tableSASUri = New-AzureStorageTableSASToken -Name $tablename  -Permission "raud" -ExpiryTime (([DateTime]::UtcNow.AddDays(10))) -FullUri -Context $storageContext
        $uri = [System.Uri]$tableSASUri
        $sasTable = New-Object -TypeName Microsoft.Azure.Cosmos.Table.CloudTable $uri 

        #Test run Table query - Query Entity
        $query = New-Object Microsoft.Azure.Cosmos.Table.TableQuery
        ## Define columns to select.
        $list = New-Object System.Collections.Generic.List[string]
        $list.Add("RowKey")
        $list.Add("ID")
        $list.Add("Name")
        ## Set query details.
        $query.FilterString = "ID gt 0"
        $query.SelectColumns = $list
        $query.TakeCount = 20
        ## Execute the query.
        $result = $sasTable.ExecuteQuerySegmentedAsync($query, $null) 
        Assert-AreEqual $result.Result.Results.Count 1

        # Get/Remove Table
        $tableCount1 = (Get-AzStorageTable -Context $storageContext).Count
        Remove-AzStorageTable -Name $tableName -Force -Context $storageContext
        $table2 = Get-AzStorageTable -Context $storageContext
        if ($null -eq $table2) { 
        $tableCount2 = 0
        }
        else {
        $tableCount2 = $table2.Count
        }    
        Assert-AreEqual ($tableCount1-$tableCount2) 1
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
}

<#
    .SYNOPSIS
    Tests Copy commands between Blobs and Files.
#>
function Test-BlobFileCopy
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try
    {
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue
    
        $localSrcFile = "localsrcblobfilecopytestfile.psd1" #The file need exist before test, and should be 512 bytes aligned
        New-Item $localSrcFile -ItemType File -Force     

        $objectName1 = "blobfilecopytest1.txt"
        $objectName2 = "blobfilecopytest2.txt"
        $objectName3 = "blobfilecopytest3.txt"

        #Blob Creation
        $ContentType = "image/jpeg"
        $ContentMD5 = "i727sP7HigloQDsqadNLHw=="
        
        $containerName = "blobfilecopytestcontainer"  
        New-AzStorageContainer $containerName -Context $storageContext
        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob $objectName1 -Force -Properties @{"ContentType" = $ContentType; "ContentMD5" = $ContentMD5} -Context $storageContext
        $blob = Get-AzStorageContainer -Name $containerName -Context $storageContext |Get-AzStorageBlob
        Assert-AreEqual $blob.Count 1
        Assert-AreEqual $blob.Name $objectName1
        Assert-AreEqual $blob.ICloudBlob.Properties.ContentType $ContentType
        Assert-AreEqual $blob.ICloudBlob.Properties.ContentMD5 $ContentMD5           

        $shareName = "blobfilecopytestshare"
        #File Creation
        New-AzStorageShare $shareName -Context $storageContext
        $Share = Get-AzStorageShare -Name $shareName -Context $storageContext
        Assert-AreEqual $Share.Count 1
        Assert-AreEqual $Share[0].Name $shareName

        Set-AzStorageFileContent -source $localSrcFile -ShareName $shareName -Path $objectName2 -Force -Context $storageContext
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName2

        #blob<->File Copy
        Start-AzStorageBlobCopy  -SrcShareName $shareName -SrcFilePath $objectName2 -DestContainer $containerName -DestBlob $objectName3 -Force -Context $storageContext -DestContext $storageContext
        Get-AzStorageBlobCopyState -Container $containerName -Blob $objectName3 -Context $storageContext    
        $blob = Get-AzStorageBlob -Container $containerName -Blob $objectName3 -Context $storageContext
        Assert-AreEqual $blob.Count 1
        Assert-AreEqual $blob[0].Name $objectName3

        Start-AzStorageFileCopy  -SrcContainerName $containerName -SrcBlobName $objectName1  -DestShareName $shareName -DestFilePath $objectName3 -Force -Context $storageContext -DestContext $storageContext
        Get-AzStorageFileCopyState -ShareName $shareName -FilePath $objectName3 -Context $storageContext    
        $file = Get-AzStorageFile -ShareName $shareName -Path $objectName3 -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName3

        # Clean Storage Account
        Remove-AzStorageShare -Name $shareName -Force -Context $storageContext
        Remove-AzStorageContainer -Name $containerName -Force -Context $storageContext
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
}

<#
    .SYNOPSIS
    Tests Azure storage service loggin property, service metrics property and CORSRule commands.
#>
function Test-Common
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try
    {
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

        # wait at most 120*5s=600s for the set sevice proeprty updated on server.
        $retryTimes = 120
        
        # B/F/Q Service properties, in same code path
        $version = "1.0"
        $retentionDays = 2
        $LoggingOperations = "All"

        Set-AzStorageServiceLoggingProperty -ServiceType blob -RetentionDays $retentionDays -Version $version -LoggingOperations $LoggingOperations -Context $storageContext
        $i = 0
		$propertyUpdated = $false
		while (($i -lt $retryTimes ) -and ($propertyUpdated -eq $false))
		{
			$property = Get-AzStorageServiceLoggingProperty -ServiceType blob -Context $storageContext
			if (($property.RetentionDays -eq $retentionDays) -and ($property.Version -eq $version) -and ($property.LoggingOperations -eq $LoggingOperations))
			{
				$propertyUpdated = $true
			}
			else
			{
				sleep 5
				$i = $i + 5
			}
		} 
		$property = Get-AzStorageServiceLoggingProperty -ServiceType blob -Context $storageContext
		Assert-AreEqual $LoggingOperations $property.LoggingOperations.ToString() 
        Assert-AreEqual $version $property.Version 
        Assert-AreEqual $retentionDays $property.RetentionDays  

        $MetricsLevel = "Service"
        Set-AzStorageServiceMetricsProperty -ServiceType blob -Version $version -MetricsType Hour -RetentionDays $retentionDays -MetricsLevel $MetricsLevel -Context $storageContext
        $i = 0
		$propertyUpdated = $false
		while (($i -lt $retryTimes ) -and ($propertyUpdated -eq $false))
		{
			$property = Get-AzStorageServiceMetricsProperty -ServiceType Blob -MetricsType Hour -Context $storageContext
			if (($property.RetentionDays -eq $retentionDays) -and ($property.Version -eq $version) -and ($property.MetricsLevel.ToString()  -eq $MetricsLevel))
			{
				$propertyUpdated = $true
			}
			else
			{
				sleep 5
				$i = $i + 5
			}
		} 				
		$property = Get-AzStorageServiceMetricsProperty -ServiceType Blob -MetricsType Hour -Context $storageContext
        Assert-AreEqual $MetricsLevel $property.MetricsLevel.ToString() 
        Assert-AreEqual $version $property.Version 
        Assert-AreEqual $retentionDays $property.RetentionDays 

        Set-AzStorageCORSRule -ServiceType blob -Context $storageContext -CorsRules (@{
            AllowedHeaders=@("x-ms-blob-content-type","x-ms-blob-content-disposition");
            AllowedOrigins=@("*");
            MaxAgeInSeconds=30;
            AllowedMethods=@("Get","Connect")},
            @{
            AllowedOrigins=@("http://www.fabrikam.com","http://www.contoso.com"); 
            ExposedHeaders=@("x-ms-meta-data*","x-ms-meta-customheader"); 
            AllowedHeaders=@("x-ms-meta-target*","x-ms-meta-customheader");
            MaxAgeInSeconds=30;
            AllowedMethods=@("Put")})
		$i = 0
		$corsRuleUpdated = $false
		while (($i -lt $retryTimes ) -and ($corsRuleUpdated -eq $false))
		{
			$cors = Get-AzStorageCORSRule -ServiceType blob -Context $storageContext
			if ($cors.Count -eq 2)
			{
				$corsRuleUpdated = $true
			}
			else
			{
				sleep 5
				$i = $i + 5
			}
		}
        $cors = Get-AzStorageCORSRule -ServiceType blob -Context $storageContext
        Assert-AreEqual 2 $cors.Count 

        Remove-AzStorageCORSRule -ServiceType blob -Context $storageContext
		$i = 0
		$corsRuleUpdated = $false
		while (($i -lt $retryTimes ) -and ($corsRuleUpdated -eq $false))
		{
			$cors = Get-AzStorageCORSRule -ServiceType blob -Context $storageContext
			if ($cors.Count -eq 0)
			{
				$corsRuleUpdated = $true
			}
			else
			{
				sleep 5
				$i = $i + 5
			}
		}
        $cors = Get-AzStorageCORSRule -ServiceType blob -Context $storageContext
        Assert-AreEqual 0 $cors.Count    
		
        # Table Service properties
        $version = "1.0"
        $retentionDays = 3
        $LoggingOperations = "Delete"

        Set-AzStorageServiceLoggingProperty -ServiceType table -RetentionDays $retentionDays -Version $version -LoggingOperations $LoggingOperations -Context $storageContext
        $i = 0
		$propertyUpdated = $false
		while (($i -lt $retryTimes ) -and ($propertyUpdated -eq $false))
		{
			$property = Get-AzStorageServiceLoggingProperty -ServiceType table -Context $storageContext
			if (($property.RetentionDays -eq $retentionDays) -and ($property.Version -eq $version) -and ($property.LoggingOperations -eq $LoggingOperations))
			{
				$propertyUpdated = $true
			}
			else
			{
				sleep 5
				$i = $i + 5
			}
		} 
		$property = Get-AzStorageServiceLoggingProperty -ServiceType table -Context $storageContext
		Assert-AreEqual $LoggingOperations $property.LoggingOperations.ToString() 
        Assert-AreEqual $version $property.Version 
        Assert-AreEqual $retentionDays $property.RetentionDays  

        $MetricsLevel = "ServiceAndApi"
        Set-AzStorageServiceMetricsProperty -ServiceType table -Version $version -MetricsType Minute -RetentionDays $retentionDays -MetricsLevel $MetricsLevel -Context $storageContext
        $i = 0
		$propertyUpdated = $false
		while (($i -lt $retryTimes ) -and ($propertyUpdated -eq $false))
		{
			$property = Get-AzStorageServiceMetricsProperty -ServiceType table -MetricsType Minute -Context $storageContext
			if (($property.RetentionDays -eq $retentionDays) -and ($property.Version -eq $version) -and ($property.MetricsLevel.ToString()  -eq $MetricsLevel))
			{
				$propertyUpdated = $true
			}
			else
			{
				sleep 5
				$i = $i + 5
			}
		} 				
		$property = Get-AzStorageServiceMetricsProperty -ServiceType table -MetricsType Minute -Context $storageContext
        Assert-AreEqual $MetricsLevel $property.MetricsLevel.ToString() 
        Assert-AreEqual $version $property.Version 
        Assert-AreEqual $retentionDays $property.RetentionDays 

        Set-AzStorageCORSRule -ServiceType table -Context $storageContext -CorsRules (@{
            AllowedHeaders=@("x-ms-blob-content-type");
            AllowedOrigins=@("*");
            MaxAgeInSeconds=20;
            AllowedMethods=@("Get","Connect")})
		$i = 0
		$corsRuleUpdated = $false
		while (($i -lt $retryTimes ) -and ($corsRuleUpdated -eq $false))
		{
			$cors = Get-AzStorageCORSRule -ServiceType table -Context $storageContext
			if ($cors.Count -eq 1)
			{
				$corsRuleUpdated = $true
			}
			else
			{
				sleep 5
				$i = $i + 5
			}
		}
        $cors = Get-AzStorageCORSRule -ServiceType table -Context $storageContext
        Assert-AreEqual 1 $cors.Count 

        Remove-AzStorageCORSRule -ServiceType table -Context $storageContext
		$i = 0
		$corsRuleUpdated = $false
		while (($i -lt $retryTimes ) -and ($corsRuleUpdated -eq $false))
		{
			$cors = Get-AzStorageCORSRule -ServiceType table -Context $storageContext
			if ($cors.Count -eq 0)
			{
				$corsRuleUpdated = $true
			}
			else
			{
				sleep 5
				$i = $i + 5
			}
		}
        $cors = Get-AzStorageCORSRule -ServiceType table -Context $storageContext
        Assert-AreEqual 0 $cors.Count   
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }    
}

function New-TestResourceGroupAndStorageAccount
{ 
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    $location = Get-ProviderLocation ResourceManagement    
    $storageAccountType = 'Standard_LRS'# Standard Geo-Reduntand Storage
    New-AzResourceGroup -Name $ResourceGroupName -Location $location
    New-AzStorageAccount -Name $storageAccountName -ResourceGroupName $ResourceGroupName -Location $location -Type $storageAccountType
}
