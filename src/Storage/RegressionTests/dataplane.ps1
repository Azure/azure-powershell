# Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane.ps1 -Show All -Strict -ExcludeTagFilter "Preview" 
C:\Users\weiwei\Desktop\PSH_Script\PSHTest\utils.ps1


BeforeAll {
    $filePathConfig = (Get-Content D:\psh_scripts\config.json -Raw | ConvertFrom-Json).filePaths
    Import-Module $filePathConfig.assert
    Import-Module $filePathConfig.utils
    $config = (Get-Content D:\psh_scripts\config.json -Raw | ConvertFrom-Json).dataplane
    $rootFolder = "C:\temp"
    cd $rootFolder

    $resourceGroupName = "weitry"
    $storageAccountName = "weirp1"
    $storageAccountName2 = "weirp3"
    
    # create oauth context
    $secpasswd = ConvertTo-SecureString $config.credentials.secpwd -AsPlainText -Force
    $cred = New-Object System.Management.Automation.PSCredential ($config.credentials.username, $secpasswd)
    Add-AzAccount -ServicePrincipal -Tenant $config.credentials.tenantId -SubscriptionId $config.credentials.subscriptionId -Credential $cred 
    $ctxoauth1 = New-AzStorageContext -StorageAccountName $storageAccountName
    $ctxoauth2 = New-AzStorageContext -StorageAccountName $storageAccountName2

    $ctx = New-AzStorageContext -StorageAccountName weirp1 -StorageAccountKey $config.credentials.storageAccountKey
    $ctx2 = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName2).Context

    # TODO: extract all the paths here to config file 
    $localSmallSrcFile = "C:\temp\testfile_1K_0"
    $localBigSrcFile = $config.files.localBigSrcFile
    $localSrcFile = "C:\temp\testfile_10240K_0" #The file need exist before test, and should be 512 bytes aligned
    $localDestFile = "C:\temp\test1.txt" # test will create the file
    $containerName = GetRandomContainerName
    # $containerName = "weitest"

    $blobCopySrcFile10M = "D:\storageRegressionTestFiles\test10mb"

    New-AzStorageContainer $containerName -Context $ctx
    New-AzStorageShare $containerName -Context $ctx
    New-AzStorageContainer -Name $containerName -Context $ctxoauth2

    
    $OriginalPref = $ProgressPreference
    $ProgressPreference = "SilentlyContinue"
}

Describe "dataplane test" {

    It "Blob Version test" -Tag "blobversion" {
        $Error.Clear()

        #$resourceGroupName = "weitry"
        #$storageAccountName = "weiestesteuap"
        #$a = Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName
    
        #$ctx = $a.Context
        # $ctx = New-AzStorageContext -StorageAccountName $storageAccountName
        $localSrcFile = "C:\temp\testfile_2048K" #The file need exist before test, and should be 512 bytes aligned
        $localDestFile = "C:\temp\testversion.txt" # test will create the file
        #$containerName = "weibvtest"
        $blobname = "aa.txt"
        $blobname2 = "bb.txt"


        #New-AzStorageContainer $containerName -Context $ctx
        $b = Set-AzStorageBlobContent -Container $containerName -Blob $blobname1 -File $localSrcFile -Context $ctx -Force
        $b.ICloudBlob.snapshot() 
        $b = Set-AzStorageBlobContent -Container $containerName -Blob $blobname1 -File $localSrcFile -Context $ctx -Force

        #list with include version
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx  -IncludeVersion 
        $b.Count | should -BeGreaterOrEqual 3

        #list with include version with ContinuationToken
        $Total = 0
        $Token = $Null
        $Blobs
        do
        {
             $Blobs = Get-AzStorageBlob -Container $containerName -Context $ctx -IncludeVersion -MaxCount 2 -ContinuationToken $Token
             $Total += $Blobs.Count
             $Blobs.Count | should -BeLessOrEqual 2
             # $blobs | ft Name,ContinuationToken
             if($Blobs.Length -le 0) 
             { 
                # echo "length 0"
                Break;
             }
             $Token = $Blobs[$blobs.Count -1].ContinuationToken;
        }
        While ($Token -ne $Null)
        $Total | should -BeGreaterOrEqual 3

        # get single with versionID or Snapshottime
        $b1 = $b | ?{$_.VersionId -ne $null} | Select-Object -First 1
        $b11 = Get-AzStorageBlob -Container $containerName -Context $ctx  -Blob $b1.Name -VersionId $b1.VersionId
        $b1.VersionId  | should -be $b11.VersionId
        $b2 = $b | ?{$_.SnapshotTime -ne $null} | Select-Object -First 1
        $b21 = Get-AzStorageBlob -Container $containerName -Context $ctx  -Blob $b2.Name -SnapshotTime $b2.SnapshotTime
        $b2.SnapshotTime  | should -be $b21.SnapshotTime

    
        # TEst Copy
        $blobveresion = $b1 = $b | ?{$_.VersionId -ne $null -and !($_.BlobProperties.IsLatestVersion)} | Select-Object -First 1
        $blobveresion | Start-AzStorageBlobCopy  -DestContainer $containerName -DestBlob $blobname2 -Force # might fail for server issue, with "CannotVerifyCopySource"
        #$blobversionUri = $blobveresion | New-AzStorageBlobSASToken -Permission rt -FullUri -ExpiryTime (Get-Date).Add(6)
        #Start-AzStorageBlobCopy -AbsoluteUri $blobversionUri  -DestContainer $containerName -DestBlob $blobname2 -Force -DestContext $ctx # might fail for server issue, with "CannotVerifyCopySource"

        $blobsnapshot = $b | ?{$_.SnapshotTime -ne $null} | Select-Object -First 1
        $blobsnapshot | Start-AzStorageBlobCopy  -DestContainer $containerName -DestBlob $blobname2 -Force

        # Test download
        $blobveresion | Get-AzStorageBlobContent -Destination $localDestFile -Force
        $blobsnapshot | Get-AzStorageBlobContent -Destination $localDestFile -Force

        # TEst SAS
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx  -IncludeVersion 
        $blobveresion = $b1 = $b | ?{$_.VersionId -ne $null -and !($_.BlobProperties.IsLatestVersion)} | Select-Object -First 1
        $blobsnapshot = $b | ?{$_.SnapshotTime -ne $null} | Select-Object -First 1
        $blobbase = $b | ?{$_.IsLatestVersion} | Select-Object -First 1
        if ($ctx.StorageAccount.Credentials.IsSharedKey -or $ctx.StorageAccount.Credentials.IsToken)
        {
            #Blob SAS - version
            $sas = $blobveresion | New-AzStorageBlobSASToken -Permission wdlactxr -IPAddressOrRange 0.0.0.0-255.255.255.255 -Protocol HttpsOrHttp -ExpiryTime (Get-Date).AddDays(6) 
            $sascontext = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
            $b1 = Get-AzStorageBlob -Container $blobveresion.BlobBaseClient.BlobContainerName -Blob $blobveresion.BlobBaseClient.Name -VersionId $blobveresion.VersionId -Context $sascontext
            $b1.VersionId  | should -be $blobveresion.VersionId
            #Blob SAS - snapshot
            $sas = $blobsnapshot | New-AzStorageBlobSASToken -Permission wdlactxr -IPAddressOrRange 0.0.0.0-255.255.255.255 -Protocol HttpsOrHttp -ExpiryTime (Get-Date).AddDays(6) 
            $sascontext = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
            $b1 = Get-AzStorageBlob -Container $blobsnapshot.BlobBaseClient.BlobContainerName -Blob $blobsnapshot.BlobBaseClient.Name -SnapshotTime $blobsnapshot.SnapshotTime -Context $sascontext
            $blobsnapshot.SnapshotTime  | should -be $b1.SnapshotTime

            #Blob SAS - base
            $sas = $blobbase | New-AzStorageBlobSASToken -Permission wdlactxri -IPAddressOrRange 0.0.0.0-255.255.255.255 -Protocol HttpsOrHttp -ExpiryTime (Get-Date).AddDays(6) 
            $sascontext = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
            $b1 = Get-AzStorageBlob -Container $blobbase.BlobBaseClient.BlobContainerName -Blob $blobbase.BlobBaseClient.Name -Context $sascontext
            $b1.LastModified  | should -be $blobbase.BlobBaseClient.GetProperties().value.LastModified
        
            #container SAS - version
            $sas = New-AzStorageContainerSASToken -Name $containerName -Permission wdlacrtxi -IPAddressOrRange 0.0.0.0-255.255.255.255 -Protocol HttpsOrHttp -ExpiryTime (Get-Date).AddDays(6) -Context $ctx 
            $sascontext = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
            $b1 = Get-AzStorageBlob -Container $blobveresion.BlobBaseClient.BlobContainerName -Blob $blobveresion.BlobBaseClient.Name -VersionId $blobveresion.VersionId -Context $sascontext
            $b1.VersionId  | should -be $blobveresion.VersionId
        }
        if ($ctx.StorageAccount.Credentials.IsSharedKey)
        {
            #account SAS
            $sas = New-AzStorageAccountSASToken -Service Blob,Table -ResourceType Object,Service -Permission wdltxacfpuri -IPAddressOrRange 0.0.0.0-255.255.255.255 -Protocol HttpsOrHttp -ExpiryTime (Get-Date).AddDays(6) -Context $ctx 
            $sascontext = New-AzStorageContext -StorageAccountName $storageAccountName -SasToken $sas
            $b1 = Get-AzStorageBlob -Container $blobveresion.BlobBaseClient.BlobContainerName -Blob $blobveresion.BlobBaseClient.Name -VersionId $blobveresion.VersionId -Context $sascontext
            $b1.VersionId  | should -be $blobveresion.VersionId
        }

        #remove with versionID or Snapshottime
        Remove-AzStorageBlob -Container $containerName -Context $ctx  -Blob $blobveresion.Name -VersionId $blobveresion.VersionId
        $false  | should -be $blobveresion.BlobBaseClient.Exists().value
        Remove-AzStorageBlob -Container $containerName -Context $ctx  -Blob $blobsnapshot.Name -SnapshotTime $blobsnapshot.SnapshotTime
        $false  | should -be $blobsnapshot.BlobBaseClient.Exists().value

        #cleanup
        #Remove-AzStorageContainer $containerName -Context $ctx -Force
        $Error.Count | should -be 0

    }

    It "blob basic" {
        $Error.Clear()

        $sas = New-AzStorageAccountSASToken -Service Blob -ResourceType Service,Container -Permission rl -Context $ctx
        $ctxsas = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas

        # if the PR https://github.com/Azure/azure-powershell/pull/5420 is not merged, the following 2 cmdlets will fail.
        $c = Get-AzStorageContainerAcl -MaxCount 10 -Context $ctxsas
        $c = Get-AzStorageContainer -Name $containerName -Context $ctxsas
        $c.Permission.PublicAccess | should -be $null
        $c = Get-AzStorageContainer -Name $containerName -Context $ctx
        $c.Permission.PublicAccess | should -be "Off"

        #upload blob with write only sas
        $sas = New-AzStorageBlobSASToken -container $containerName -Blob test.txt -Permission w -Context $ctx
        $ctxsas = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
        $a = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob test.txt -Force -Properties @{"ContentType" = "image/jpeg"; "ContentMD5" = "i727sP7HigloQDsqadNLHw=="} -Metadata @{"tag1" = "value1"; "tag2" = "value22" } -Context $ctxsas
        $a = Set-AzStorageBlobContent -File testfile_2048K -Container $containerName -Blob test.txt -Force -Properties @{"ContentType" = "image/jpeg"; "ContentMD5" = "i727sP7HigloQDsqadNLHw=="} -Metadata @{"tag1" = "value1"; "tag2" = "value22" } -Context $ctxsas
        $a = Set-AzStorageBlobContent -File .\testfile_2048K -Container $containerName -Blob test.txt -Force -Context $ctxsas -StandardBlobTier cool 
        $a.ICloudBlob.Properties.StandardBlobTier | should -Be "Cool" 
        $b = Get-AzStorageContainer -Name $containerName -Context $ctx |Get-AzStorageBlob  
        $b.Count | Should -BeGreaterOrEqual 1

        # list/get blob with SAS without prefix "?"
        $sas = New-AzStorageBlobSASToken -container $containerName -Blob test.txt -Permission w -Context $ctx
        $ctxsas = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas.Substring(1)
        $bs = Get-AzStorageBlob -Container $containerName -Context $ctx
        $bs[0].BlobProperties | should -Not -Be $null
        $b = Get-AzStorageBlob -Container $containerName -Blob $bs[0].Name -Context $ctx
        $b.BlobProperties | should -Not -Be $null

        #copy with oauth 
        # cross account     
        $copyDest = Start-AzStorageBlobCopy -SrcContainer $containerName -SrcBlob test.txt -Context $ctxoauth1 -DestContainer $containerName -DestBlob test.txt -DestContext $ctxoauth2 -Force
        $copyDest | Get-AzStorageBlobCopyState -WaitForComplete
        $copydest.BlobBaseClient.Exists() | should -Be $true
        # same account   
        $copyDest = Start-AzStorageBlobCopy -SrcContainer $containerName -SrcBlob test.txt -Context $ctxoauth1 -DestContainer $containerName -DestBlob testcopysameaccount.txt -DestContext $ctxoauth1 -Force
        $copyDest | Get-AzStorageBlobCopyState -WaitForComplete
        $copydest.BlobBaseClient.Exists() | should -Be $true

        # copy with tier
        Start-AzStorageBlobCopy -AbsoluteUri $a.ICloudBlob.Uri.ToString() -DestContainer $containerName -DestBlob testtier.txt -Context $ctx -DestContext $ctx -Force -StandardBlobTier hot -RehydratePriority High
        (Get-AzStorageBlob -Container $containerName -Blob testtier.txt -Context $ctx).BlobProperties.AccessTier  | should -Be "hot"
        Start-AzStorageBlobCopy -srcContainer $containerName -SrcBlob test.txt -DestContainer $containerName -DestBlob testtier.txt -Context $ctx -DestContext $ctx -Force -RehydratePriority Standard
        (Get-AzStorageBlob -Container $containerName -Blob testtier.txt -Context $ctx).BlobProperties.AccessTier | should -Be "hot"
        Start-AzStorageBlobCopy -srcContainer $containerName -SrcBlob test.txt -DestContainer $containerName -DestBlob testtier.txt -Context $ctx -DestContext $ctx -Force -StandardBlobTier Archive 
        (Get-AzStorageBlob -Container $containerName -Blob testtier.txt -Context $ctx).BlobProperties.AccessTier  | should -Be "Archive"
        Start-AzStorageBlobCopy -srcContainer $containerName -SrcBlob test.txt -DestContainer $containerName -DestBlob test1.txt -Context $ctx -DestContext $ctx -Force          
        $b = Get-AzStorageBlob -Container $containerName -Context $ctx
        $copystate = Get-AzStorageBlobCopyState -Container $containerName -Blob test1.txt -Context $ctx
        $copystate.Status | Should -Be "Success"

        #Sync Copy, the copy source must be block blob currently 
        $b = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob test.txt -DestContainer $containerName -DestBlob "test/test2/test.txt" -Context $ctx -StandardBlobTier hot -RehydratePriority High -Force
        $b.Name | Should -Be "test/test2/test.txt"
        $b.AccessTier | should -Be "hot"
        $longblobName = "testblobsyncopy201234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789.txt"
        $b = $b | Copy-AzStorageBlob -DestContainer $containerName -DestBlob $longblobName -Context $ctx -Force
        $b.Name | Should -Be $longblobName
        $blobSasUri = $b | New-AzStorageBlobSASToken -Permission rt -ExpiryTime (Get-Date).AddDays(6) -FullUri
        $b = Copy-AzStorageBlob -AbsoluteUri $blobSasUri -DestContainer $containerName -DestBlob testblobsyncopy3.txt -Context $ctx -Force
        $b.Name | Should -Be "testblobsyncopy3.txt"
        
        Set-AzStorageBlobContent -Container $containerName -Blob smallblock -File $localSmallSrcFile -Context $ctx -Force
        $b = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob smallblock -DestContainer $containerName -DestBlob smallblock2 -Context $ctx -Force
        $b.Name | Should -Be "smallblock2"
        $b.Length | should -Be (Get-Item $localSmallSrcFile).Length

        Set-AzStorageBlobContent -Container $containerName -Blob bigfile -File $localBigSrcFile -Context $ctx -Force
        $b = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob bigfile -DestContainer $containerName -DestBlob bigfile2 -Context $ctx -Force
        $b.Name | Should -Be "bigfile2"
        $b.Length | should -Be (Get-Item $localBigSrcFile).Length


        # download blob
        Get-AzStorageBlobContent -Container $containerName -Blob test1.txt -Destination $localDestFile -Force -Context $ctx
        del $localDestFile
        Get-AzStorageBlobContent -Container $containerName -Blob test1.txt -Destination test1.txt -Force -Context $ctx
        del $localDestFile
        Get-AzStorageBlobContent -Container $containerName -Blob test1.txt -Force -Context $ctx
        del $localDestFile
        $Error.Count | should -be 0
    }

    It "download item with create sub folder" {
        $Error.Clear()

        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob "aa/bb/cc/dd.txt" -Force -Context $ctx
        Get-AzStorageBlobContent -Container $containerName -Blob "aa/bb/cc/dd.txt" -Force -Context $ctx -Destination .
        del "aa\bb\cc\dd.txt"
        Remove-Item -Path "aa" -Force -Recurse
        $Error.Count | should -be 0
    }

    It "Quick Query" -tag "qq"{
        $Error.Clear()
        $qaSrcFile = "C:\Users\weiwei\Desktop\PSH_Script\PSHTest\qq.txt"
        #$qaSrcFile = "C:\Users\weiwei\Desktop\PSH_Script\Newfeature\QA_testcsv.csv"
        $qaDestFile = "C:\Users\weiwei\Desktop\PSH_Script\PSHTest\QA_result.csv"
        $blobName = "testcsvcurrent.csv"
        $blob = Set-AzStorageBlobContent -Container $containerName -Blob $blobName -File $qaSrcFile -Context $ctx -Force
        $inputconfig = New-AzStorageBlobQueryConfig -AsCsv -ColumnSeparator "," -QuotationCharacter """" -EscapeCharacter "\" -HasHeader  -RecordSeparator "" 
        $outputconfig = New-AzStorageBlobQueryConfig -AsJson  -RecordSeparator "" 
        #$queryString = "SELECT * FROM BlobStorage WHERE _1 LIKE '1%%'"
        $queryString = "SELECT _2 from BlobStorage WHERE _1 > 250;"
        $result = Get-AzStorageBlobQueryResult -Container $containerName -Blob $blobName -QueryString $queryString -ResultFile $qaDestFile -Context $ctx -Force -InputTextConfiguration $inputconfig -OutputTextConfiguration $outputconfig  
        Assert-AreEqual $true ($result.BytesScanned -gt 0)
        Assert-AreEqual 0 $result.FailureCount
        Assert-AreEqual $null $result.BlobQueryError
        del $qaDestFile 
        $Error.Count | should -be 0
    }

    It "Set-AzStorageContainerAcl won't clean up the stored Access Policy" -Tag "accesspolicy" {
        $Error.Clear()

        ## regression test for Fix  Set-AzStorageContainerAcl can clean up the stored Access Policy
        New-AzStorageContainerStoredAccessPolicy -Container $containerName  -Policy 123 -Permission rw -Context $ctx
        New-AzStorageContainerStoredAccessPolicy -Container $containerName  -Policy 234 -Permission rwdl -Context $ctx
        $policy = Get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx
        $policy.Count | should -Be 2
        $policy[0].Policy | should -Be 123
        $policy[0].Permissions | should -Be rw
        $policy[0].ExpiryTime | should -Be $null
        $policy[0].StartTime | should -Be $null
        Set-AzStorageContainerAcl -Container $containerName  -Permission Blob -Context $ctx
        Set-AzStorageContainerAcl -Container $containerName  -Permission Off -Context $ctx
        $policy = Get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx
        $policy.Count | should -Be 2

        # test generate SAS with access policy and start / expire will success
        $sas = New-AzStorageContainerSASToken -Name $ContainerName -Policy 123  -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(1) -Context $ctx
        $sas.Length | should -BeGreaterThan 10

        $Error.Count | should -be 0
    }

    It "upload/download blob with as job" {
        $Error.Clear()

        $t = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob test.txt -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed" 

        $t = Set-AzStorageBlobContent -File testfile_2048K -Container $containerName -Blob test.txt -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed" 

        #download blob with asjob
        #del $localDestFile
        $t = Get-AzStorageBlobContent -Container $containerName -Blob test.txt -Destination $localDestFile -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed" 

        del $localDestFile
        $t = Get-AzStorageBlobContent -Container $containerName -Blob test.txt -Destination test1.txt -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed"  
        del $localDestFile

        Remove-AzStorageBlob -Container $containerName -Blob test.txt -Force -Context $ctx
        Get-AzStorageBlob -Container $containerName -Context $ctx
        $Error.Count | should -be 0
    }

    It "Blob Incremental Copy" {
        $Error.Clear()
    
        $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob page -Force -BlobType page -Context $ctx
        $task = $b.ICloudBlob.SnapshotAsync() 
        $task.Wait()
        $snapshot = $task.Result
        $uri = New-AzStorageBlobSASToken -CloudBlob $snapshot -Permission wrd -FullUri -Context $ctx
        if ($uri -notlike "*?snapshot=20*")
        {
            throw $t.Error;
        }
        $content = Invoke-RestMethod -uRI $uri #-Headers @{ "x-ms-version"=“2019-02-02"}
        $content.Length
        
        # Start-AzStorageBlobIncrementalCopy -srcContainer $containerName -SrcBlob page -SrcBlobSnapshotTime $snapshot.SnapshotTime -DestContainer $containerName -DestBlob page2 -UseTrack2 -Context $ctx -DestContext $ctx
        # Get-AzStorageBlobCopyState -Container $containerName -Blob page2 -Context $ctx

        Start-AzStorageBlobIncrementalCopy -srcContainer $containerName -SrcBlob page -SrcBlobSnapshotTime $snapshot.SnapshotTime -DestContainer $containerName -DestBlob page2  -Context $ctx -DestContext $ctx
        $Error.Count | should -be 0
    } 
  
    It "File basic" {  
        $Error.Clear()
        Get-AzStorageShare -Context $ctx
        Set-AzStorageShareQuota -ShareName $containerName -Quota 500 -Context $ctx
        New-AzStorageDirectory -ShareName $containerName -Path testdir -Context $ctx
        Set-AzStorageFileContent -source testfile_2048K -ShareName $containerName -Path test.txt -Force -Context $ctx
        Set-AzStorageFileContent -source $localSrcFile -ShareName $containerName -Path test.txt   -PreserveSMBAttribute -Force -Context $ctx
        $file = Get-AzStorageFile -ShareName $containerName -Path test.txt -Context $ctx		
        $localFileProperties = Get-ItemProperty $localSrcFile
        $localFileProperties.CreationTime.ToUniversalTime().Ticks | should -Be $file[0].FileProperties.SmbProperties.FileCreatedOn.ToUniversalTime().Ticks
        $localFileProperties.LastWriteTime.ToUniversalTime().Ticks | should -Be  $file[0].FileProperties.SmbProperties.FileLastWrittenOn.ToUniversalTime().Ticks
        $localFileProperties.Attributes.ToString() | should -Be  $file[0].FileProperties.SmbProperties.FileAttributes.ToString()

       # $localFileProperties.CreationTime.ToUniversalTime().Ticks | should -Be $file[0].FileProperties.SmbProperties.FileCreatedOn.ToUniversalTime().Ticks
       # $localFileProperties.LastWriteTime.ToUniversalTime().Ticks | should -Be  $file[0].FileProperties.SmbProperties.FileLastWrittenOn.ToUniversalTime().Ticks
       # $localFileProperties.Attributes.ToString() | should -Be  $file[0].FileProperties.SmbProperties.FileAttributes.ToString()
       
       # list files with/without extended properties
        $files = Get-AzStorageFile -ShareName $containerName -Context $ctx
        ($files | ?{$_.ListFileProperties.IsDirectory} | Select-Object -First 1 ).ListFileProperties.Properties.ETag.ToString().length | should -BeGreaterThan 1
        ($files | ?{$_.ListFileProperties.IsDirectory -eq $false} | Select-Object -First 1 ).ListFileProperties.Properties.ETag.ToString().length | should -BeGreaterThan 1
        $files = Get-AzStorageFile -ShareName $containerName -Context $ctx -ExcludeExtendedInfo
        ($files | ?{$_.ListFileProperties.IsDirectory} | Select-Object -First 1 ).ListFileProperties.Properties.ETag | should -Be $null
        ($files | ?{$_.ListFileProperties.IsDirectory -eq $false} | Select-Object -First 1 ).ListFileProperties.Properties.ETag | should -Be $null

        Start-AzStorageFileCopy -SrcShareName $containerName -SrcFilePath test.txt -DestShareName $containerName -DestFilePath test1.txt -Force -Context $ctx -DestContext $ctx
        Start-AzStorageFileCopy -SrcShareName $containerName -SrcFilePath test.txt -DestShareName $containerName -DestFilePath test1.txt -Force -Context $ctx 
        Get-AzStorageFileCopyState -ShareName $containerName -FilePath test1.txt -Context $ctx
        Get-AzStorageFile -ShareName $containerName -Context $ctx
        Get-AzStorageFileContent -ShareName $containerName -Path test.txt -Destination $localDestFile -Force -Context $ctx
        del $localDestFile
        Get-AzStorageFileContent -ShareName $containerName -Path test.txt -Destination test1.txt -Force -Context $ctx
        del $localDestFile
        Get-AzStorageFileContent -ShareName $containerName -Path test.txt -Destination .\test1.txt -Force -Context $ctx
        del $localDestFile
        Get-AzStorageFileContent -ShareName $containerName -Path test1.txt -PreserveSMBAttribute -Force -Context $ctx
        $file = Get-AzStorageFile -ShareName $containerName -Context $ctx | ? {$_.Name -eq "test1.txt"}
        $localFileProperties = Get-ItemProperty test1.txt
        $localFileProperties.CreationTime.ToUniversalTime().Ticks | should -Be $file[0].ListFileProperties.Properties.CreatedOn.ToUniversalTime().Ticks
        $localFileProperties.LastWriteTime.ToUniversalTime().Ticks | should -Be  $file[0].ListFileProperties.Properties.LastWrittenOn.ToUniversalTime().Ticks
        $localFileProperties.Attributes.ToString() | should -Be  $file[0].ListFileProperties.FileAttributes.ToString()
        
       # $localFileProperties.CreationTime.ToUniversalTime().Ticks | should -Be $file[0].FileProperties.SmbProperties.FileCreatedOn.ToUniversalTime().Ticks
       # $localFileProperties.LastWriteTime.ToUniversalTime().Ticks | should -Be  $file[0].FileProperties.SmbProperties.FileLastWrittenOn.ToUniversalTime().Ticks
      #  $localFileProperties.Attributes.ToString() | should -Be  $file[0].FileProperties.SmbProperties.FileAttributes.ToString()

        del $localDestFile -Force
        $Error.Count | should -be 0
    }

    It "upload/download file with asjob" {
        $Error.Clear()
    
        #upload file with asjob
        $t = Set-AzStorageFileContent -source $localSrcFile -ShareName $containerName -Path test.txt -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed"

        $t = Set-AzStorageFileContent -source .\testfile_2048K -ShareName $containerName -Path test.txt -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed"

        #download file with asjob
        #del $localDestFile
        $t = Get-AzStorageFileContent -ShareName $containerName -Path test.txt -Destination $localDestFile -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed"

        del $localDestFile
        $t = Get-AzStorageFileContent -ShareName $containerName -Path test.txt -Destination ..\temp\test1.txt  -Force -Context $ctx -asjob
        $t | wait-job
        $t.State | should -be "Completed"
        del $localDestFile
        $Error.Count | should -be 0
    }

    It "file handle" {
        $Error.Clear()

        #filehandle 
        Get-AzStorageFileHandle -ShareName $containerName -Context $ctx
        Get-AzStorageFileHandle -ShareName $containerName -Path testdir -Context $ctx
        Get-AzStorageFileHandle  -ShareName $containerName -Path test.txt -Context $ctx 
        Close-AzStorageFileHandle -ShareName $containerName -CloseAll -Recursive -Context $ctx
        Close-AzStorageFileHandle -ShareName $containerName -Path testdir -CloseAll -Recursive -Context $ctx
        Close-AzStorageFileHandle -ShareName $containerName -Path test.txt -CloseAll -Context $ctx

        Remove-AzStorageFile -ShareName $containerName -Path test.txt -Context $ctx
        Remove-AzStorageDirectory -ShareName $containerName -Path testdir -Context $ctx
        $Error.Count | should -be 0
    }

    It "blob to/from File Copy" {
        $Error.Clear()
    
        Set-AzStorageFileContent -source $localSrcFile -ShareName $containerName -Path test1.txt -Force -Context $ctx
        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob test.txt -Force -Context $ctx
        #blob<->File Copy
        Start-AzStorageBlobCopy  -SrcShareName $containerName -SrcFilePath test1.txt -DestContainer $containerName -DestBlob test2.txt -Force -Context $ctx -DestContext $ctx -StandardBlobTier Cool -RehydratePriority High
        Get-AzStorageBlobCopyState -Container $containerName -Blob test2.txt -Context $ctx    
        if ((Get-AzStorageBlob -Container $containerName -Blob test2.txt -Context $ctx).BlobProperties.AccessTier -ne "Cool") { throw;}
        Start-AzStorageFileCopy  -SrcContainerName $containerName -SrcBlobName test.txt  -DestShareName $containerName -DestFilePath test2.txt -Force -Context $ctx -DestContext $ctx
        Get-AzStorageFileCopyState -ShareName $containerName -FilePath test2.txt -Context $ctx

        $fileuri = New-AzStorageFileSASToken -ShareName $containerName -Path test1.txt -Permission rdwl -ExpiryTime 2029-12-12 -Context $ctx -FullUri
        Start-AzStorageBlobCopy -AbsoluteUri $fileuri -DestContainer $containerName -DestBlob testtier4.txt -Force  -DestContext $ctx #-RehydratePriority Standard
        if ((Get-AzStorageBlob -Container $containerName -Blob testtier4.txt -Context $ctx).BlobProperties.AccessTier -ne "hot") { throw;}
        Start-AzStorageBlobCopy -AbsoluteUri $fileuri -DestContainer $containerName -DestBlob testtier5.txt -Force  -DestContext $ctx -StandardBlobTier Archive
        if ((Get-AzStorageBlob -Container $containerName -Blob testtier5.txt -Context $ctx).BlobProperties.AccessTier -ne "Archive") { throw;}
        $Error.Count | should -be 0
    }

    It "Table test" { 
        $Error.Clear()
        Get-AzStorageTable -Context $ctx
        New-AzStorageTable -Name $containerName -Context $ctx
        Get-AzStorageTable -Context $ctx
        ##Table SAS
            New-AzStorageTableStoredAccessPolicy -Table $containerName -Policy p123 -Context $ctx -Permission r
            New-AzStorageTableStoredAccessPolicy -Table $containerName -Policy p456 -Context $ctx -Permission rdu
            get-AzStorageTableStoredAccessPolicy -Table $containerName -Context $ctx 
            get-AzStorageTableStoredAccessPolicy -Table $containerName -Policy p123 -Context $ctx 
            Remove-AzStorageTableStoredAccessPolicy -Table $containerName -Policy p123 -Context $ctx 
            set-AzStorageTableStoredAccessPolicy -Table $containerName -Policy p456 -Context $ctx -StartTime 2019-10-01 -ExpiryTime 2020-01-01
            New-AzStorageTableSASToken -Name $containerName -Policy p456 -Protocol HttpsOnly -IPAddressOrRange 12.0.0.1-20.4.0.0 -StartPartitionKey 123 -EndPartitionKey 456 -Context $ctx 
            New-AzStorageTableSASToken -Name $containerName -Permission ru -StartPartitionKey pk123 -EndPartitionKey pk456 -StartRowKey rk123 -EndRowKey rk456 -StartTime 2019-10-01 -ExpiryTime 2020-01-01 -Context $ctx -FullUri

        ## Table module
            #Import-module C:\code\AzureRmStorageTable\AzureRmStorageTable.psd1
            #For Linux        
            # Import-module /home/xtest/AzureRmStorageTable/AzureRmStorageTable.psd1
            $partitionKey1 = "partition1"
            $partitionKey2 = "partition2"
            $storageTable = (Get-AzStorageTable -Name $containerName -Context $ctx).CloudTable
            ### add  rows 
            Add-AzTableRow -table $storageTable -partitionKey $partitionKey1 -rowKey ("CA") -property @{"username"="Chris";"userid"=1;"DateTimeProperty"="2012-01-02T23:00:00";"DateTimeProperty@odata.type"="Edm.DateTime"}
            Add-AzTableRow -table $storageTable -partitionKey $partitionKey2 -rowKey ("NM2") -property @{"username"="Jessie";"userid"=2}
            Add-AzTableRow -table $storageTable -partitionKey $partitionKey1 -rowKey ("CD") -property @{"username"="ChrisLi";"userid"=3;"time"=(Get-Date)}
            Add-AzTableRow -table $storageTable -partitionKey $partitionKey1 -rowKey ("CC") -property @{"username"="ChrisLi";"userid"=4;"ff"=3213213213.3232132132131232132132323213233}
            ### Get Rows
            Get-AzTableRow -table $storageTable -partitionKey $partitionKey1 | ft userid,time,ff
            Get-AzTableRow -table $storageTable -columnName "username" -value "Chris" -operator Equal
            Get-AzTableRow -table $storageTable -customFilter "(userid eq 1)"
            # Create a filter and get the entity to be updated.
            [string]$filter = `
                [Microsoft.Azure.Cosmos.Table.TableQuery]::GenerateFilterCondition("username",`
                [Microsoft.Azure.Cosmos.Table.QueryComparisons]::Equal,"Jessie")
            $user = Get-AzTableRow -table $storageTable -customFilter $filter
            # Change the entity.
            $user.username = "Jessie2" 
            # To commit the change, pipe the updated record into the update cmdlet.
            $user | Update-AzTableRow -table $storageTable 
            # To see the new record, query the table.
            Get-AzTableRow -table $storageTable -customFilter "(username eq 'Jessie2')"
        ## Table API
            # Create Table Object - which reference to exist Table with SAS
            $tableSASUri = New-AzStorageTableSASToken -Name $containerName  -Permission "raud" -ExpiryTime (([DateTime]::UtcNow.AddDays(10))) -FullUri -Context $ctx
            $uri = [System.Uri]$tableSASUri
            $sasTable = New-Object -TypeName Microsoft.Azure.Cosmos.Table.CloudTable $uri 

            #Test run Table query - Query Entity
            $query = New-Object Microsoft.Azure.Cosmos.Table.TableQuery
            ## Define columns to select.
            $list = New-Object System.Collections.Generic.List[string]
            $list.Add("RowKey")
            $list.Add("username")
            $list.Add("userid")
            ## Set query details.
            $query.FilterString = "userid gt 0"
            $query.SelectColumns = $list
            $query.TakeCount = 20
            ## Execute the query.
            $sasTable.ExecuteQuerySegmentedAsync($query, $null)
            $storageTable.ExecuteQuerySegmentedAsync($query, $null) 

        ##Remove Table    
        Remove-AzStorageTable -Name $containerName -Force -Context $ctx

       # $Error.Count | should -be 0 
       # mark this line since Az.Table cmdlet will have error in $error with Get-Alias.
       # so check all errors are for Get-Alias       
        foreach ($e in $Error)
        {
            $e.Exception.Message | should -BeLike "This command cannot find a matching alias*"
        }
    }

    It "Queue test" {  
        $Error.Clear()
        Get-AzStorageQueue -Context $ctx
        New-AzStorageQueue -Name $containerName -Context $ctx
        Get-AzStorageQueue -Context $ctx
        $queue = Get-AzStorageQueue -Name $containerName -Context $ctx
        $queueMessage = New-Object -TypeName "Microsoft.Azure.Storage.Queue.CloudQueueMessage,$($queue.CloudQueue.GetType().Assembly.FullName)" -ArgumentList "This is message 1"
        $queue.CloudQueue.AddMessageAsync($QueueMessage)
        $queueMessage = New-Object -TypeName "Microsoft.Azure.Storage.Queue.CloudQueueMessage" -ArgumentList "This is message 2"
        $queue.CloudQueue.AddMessageAsync($QueueMessage)
        Remove-AzStorageQueue -Name $containerName -Force -Context $ctx
        Get-AzStorageQueue -Context $ctx
        $Error.Count | should -be 0
    }

    It "common service properties" {
        $Error.Clear()
        Set-AzStorageServiceLoggingProperty -ServiceType blob -RetentionDays 2 -Version 1.0 -LoggingOperations All -Context $ctx
        $properteis = Get-AzStorageServiceLoggingProperty -ServiceType blob -Context $ctx
        '1.0' | should -be $properteis.Version
        "All" | should -be  $properteis.LoggingOperations
        2 | should -be  $properteis.RetentionDays

        Set-AzStorageServiceMetricsProperty -ServiceType blob -Version 1.0 -MetricsType Hour -RetentionDays 2 -MetricsLevel Service -Context $ctx
        $properteis = Get-AzStorageServiceMetricsProperty -ServiceType Blob -MetricsType Hour -Context $ctx    
        '1.0' | should -be  $properteis.Version
        "Service" | should -be  $properteis.MetricsLevel
        '2.0' | should -be  $properteis.RetentionDays

        Set-AzStorageCORSRule -ServiceType blob -Context $ctx -CorsRules (@{
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
        $rule = Get-AzStorageCORSRule -ServiceType blob -Context $ctx
        $rule
        2  | should -be $rule.Count
        Remove-AzStorageCORSRule -ServiceType blob -Context $ctx    
        $rule = Get-AzStorageCORSRule -ServiceType blob -Context $ctx
        0  | should -be $rule.Count
    
        Enable-AzStorageDeleteRetentionPolicy -RetentionDays 5 -Context $ctx
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $true  | should -be $properteis.DeleteRetentionPolicy.Enabled
        5  | should -be $properteis.DeleteRetentionPolicy.RetentionDays
        Disable-AzStorageDeleteRetentionPolicy  -Context $ctx
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $false  | should -be $properteis.DeleteRetentionPolicy.Enabled
    
        Enable-AzStorageStaticWebsite -IndexDocument index.xml -ErrorDocument404Path error.xml  -Context $ctx 
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $true  | should -be $properteis.StaticWebsite.Enabled
        $properteis.StaticWebsite.IndexDocument  | should -be "index.xml"
        $properteis.StaticWebsite.ErrorDocument404Path | should -be "error.xml" 
        Disable-AzStorageStaticWebsite -Context $ctx     
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $false  | should -be $properteis.StaticWebsite.Enabled
        Enable-AzStorageStaticWebsite -Context $ctx 
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $true  | should -be $properteis.StaticWebsite.Enabled
        $null  | should -be $properteis.StaticWebsite.IndexDocument
        $null  | should -be $properteis.StaticWebsite.ErrorDocument404Path
        Disable-AzStorageStaticWebsite -Context $ctx 
        $properteis = Get-AzStorageServiceProperty -ServiceType blob -Context $ctx
        $false  | should -be $properteis.StaticWebsite.Enabled
        $Error.Count | should -be 0

    }

    It "Table service properties test"  {
        $Error.Clear()
        Set-AzStorageServiceLoggingProperty -ServiceType table -RetentionDays 2 -Version 1.0 -LoggingOperations All -Context $ctx
        $properteis = Get-AzStorageServiceLoggingProperty -ServiceType table -Context $ctx
        '1.0' | should -be  $properteis.Version
        "All" | should -be  $properteis.LoggingOperations
        2 | should -be  $properteis.RetentionDays

        Set-AzStorageServiceMetricsProperty -ServiceType table -Version 1.0 -MetricsType Hour -RetentionDays 2 -MetricsLevel Service -Context $ctx
        $properteis = Get-AzStorageServiceMetricsProperty -ServiceType table -MetricsType Hour -Context $ctx
        '1.0' | should -be  $properteis.Version
        "Service" | should -be  $properteis.MetricsLevel
        2 | should -be  $properteis.RetentionDays

        Set-AzStorageCORSRule -ServiceType table -Context $ctx -CorsRules (@{
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
        sleep 20
        $rule = Get-AzStorageCORSRule -ServiceType table -Context $ctx
        $rule.count | should -be 2
        2  | should -be  $rule.Count
        Remove-AzStorageCORSRule -ServiceType table -Context $ctx
        sleep 30  
        $rule = Get-AzStorageCORSRule -ServiceType table -Context $ctx
        0  | should -be  $rule.Count

        Get-AzStorageServiceProperty -ServiceType table -Context $ctx
        $Error.Count | should -be 0
    } 

    It "container access policy" -Tag "accesspolicy" {
        $Error.Clear()
        
        $con = get-AzStorageContainer $containerName -Context $ctx

        Get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx  | remove-AzStorageContainerStoredAccessPolicy  -Container $containerName -Context $ctx
        New-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test1 -Permission xcdlrwt -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2 -Permission ctr -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test3 -Permission "" -ExpiryTime (Get-Date).AddDays(365*2)
        $policy = get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx 
        $policy.Count | should -Be 3
        get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2
        Set-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2 -Permission xacdlrwt -StartTime (Get-Date).Add(-6) -ExpiryTime (Get-Date).AddDays(365)
        get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx 
        Remove-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test2
        Remove-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx -Policy test1 -PassThru
        get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx 

        $Error.Count | should -be 0

    }

    It "Share access policy" -Tag "accesspolicy" {
        $Error.Clear()
        
        $share = Get-AzStorageShare $containerName -Context $ctx

        New-AzStorageShareStoredAccessPolicy  $containerName -Context $ctx -Policy test1 -Permission lwr -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx -Policy test2 -Permission dclrw 
        get-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx 
        get-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx -Policy test2
        Set-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx -Policy test2 -Permission ldcrw -StartTime (Get-Date).Add(-6) -ExpiryTime (Get-Date).AddDays(365)
        get-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx 
        Remove-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx -Policy test2
        Remove-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx -Policy test1 -PassThru
        get-AzStorageShareStoredAccessPolicy -share $containerName -Context $ctx 

        $Error.Count | should -be 0
    }

    It "Queue access policy" -Tag "accesspolicy" {
        $Error.Clear()
        
        New-AzStorageQueue $containerName -Context $ctx
        $queue = Get-AzStorageQueue $containerName -Context $ctx

        New-AzStorageQueueStoredAccessPolicy  $containerName -Context $ctx -Policy test1 -Permission apru -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx -Policy test2 -Permission pu 
        get-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx 
        get-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx -Policy test2
        Set-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx -Policy test2 -Permission apru -StartTime (Get-Date).Add(-6) -ExpiryTime (Get-Date).AddDays(365)
        get-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx 
        Remove-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx -Policy test2
        Remove-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx -Policy test1 -PassThru
        get-AzStorageQueueStoredAccessPolicy $containerName -Context $ctx 

        Remove-AzStorageQueue $containerName -Context $ctx -Force

        $Error.Count | should -be 0
    }

    It "Table access policy" -Tag "accesspolicy" {
        $Error.Clear()
        
        New-AzStorageTable $containerName -Context $ctx

        $table = Get-AzStorageTable $containerName -Context $ctx

        New-AzStorageTableStoredAccessPolicy  $containerName -Context $ctx -Policy test1 -Permission qaud -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6)
        New-AzStorageTableStoredAccessPolicy $containerName -Context $ctx -Policy test2 -Permission au 
        get-AzStorageTableStoredAccessPolicy $containerName -Context $ctx 
        get-AzStorageTableStoredAccessPolicy $containerName -Context $ctx -Policy test2
        Set-AzStorageTableStoredAccessPolicy $containerName -Context $ctx -Policy test2 -Permission qad -StartTime (Get-Date).Add(-6) -ExpiryTime (Get-Date).AddDays(365)
        get-AzStorageTableStoredAccessPolicy $containerName -Context $ctx 
        Remove-AzStorageTableStoredAccessPolicy $containerName -Context $ctx -Policy test2
        Remove-AzStorageTableStoredAccessPolicy $containerName -Context $ctx -Policy test1 -PassThru
        get-AzStorageTableStoredAccessPolicy $containerName -Context $ctx 

        Remove-AzStorageTable $containerName -Context $ctx -Force

        $Error.Count | should -be 0
    }
    
    It "Encryption Scope"{
        $Error.Clear()

         ## Encryption Scope
        $secpasswd = ConvertTo-SecureString $config.credentials.secpwd -AsPlainText -Force
        $cred = New-Object System.Management.Automation.PSCredential ($config.credentials.username, $secpasswd)
        Add-AzAccount -ServicePrincipal -Tenant $config.credentials.tenantId -SubscriptionId $config.credentials.subscriptionId -Credential $cred 
       # $resourceGroupName = "weitry"
       # $storageAccountName = "weirp1"
        $scopeName1 = "testscope"
        $scopeName2 = "testscope2"    
        $md5 = New-Object -TypeName System.Security.Cryptography.MD5CryptoServiceProvider
        New-AzStorageEncryptionScope -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -EncryptionScopeName $scopeName1 -StorageEncryption
        New-AzStorageEncryptionScope -ResourceGroupName $resourceGroupName -StorageAccountName $storageAccountName -EncryptionScopeName $scopeName2 -StorageEncryption
        try{

            $containerName_es = "weitestencryscope3"
            $c = New-AzStorageContainer $containerName_es -Context $ctx -DefaultEncryptionScope $scopeName2 -PreventEncryptionScopeOverride $false -Permission Blob
            $scopeName2  | should -Be $c.BlobContainerProperties.DefaultEncryptionScope
            $false | should -Be  $c.BlobContainerProperties.PreventEncryptionScopeOverride
            $c.Permission.PublicAccess | should -be "Blob"

             uploadblob $ctx

             #SAS
            $sas = New-AzStorageContainerSASToken -Name $containerName_es -Permission wrdlt -ExpiryTime (Get-Date).AddDays(6) -Context $ctx #-EncryptionScope $scopeName1
            $ctxsas = New-AzStorageContext -StorageAccountName $storageAccountName  -SasToken $sas
            uploadblob $ctxsas

            ## upgrade blob with encrption scope in SAs
            $sas = New-AzStorageContainerSASToken -Name $containerName_es -Permission wrdlt -ExpiryTime (Get-Date).AddDays(6) -Context $ctx -EncryptionScope $scopeName1
            $ctxsas = New-AzStorageContext -StorageAccountName $storageAccountName  -SasToken $sas
            $b = Set-AzStorageBlobContent  -Context $ctxsas -File $localSrcFile -Container $containerName_es -Blob block -BlobType Block  -EncryptionScope $scopeName1  -Force  
            $b.BlobProperties.EncryptionScope | should -be $scopeName1

            #Oauth
            $ctxoauth = New-AzStorageContext -StorageAccountName $storageAccountName  
            uploadblob $ctxoauth
        }
        catch
        {
           Remove-AzStorageContainer $containerName_es -Context $ctx -Force
           throw; 
        }
        

        Remove-AzStorageContainer $containerName_es -Context $ctx -Force
        $Error.Count | should -be 0
    }   

    It "Upload Download FileTree" {
        $Error.Clear()

        Upload_Download_BlobTree $ctx c:\temp 'Block'
        Upload_Download_BlobTree $ctx c:\temp 'Page'
        Upload_Download_BlobTree $ctx c:\temp 'Append'
        Upload_Download_FileTree $ctx c:\temp

        $Error.Count | should -be 0
    }

    It "partition zone" {
        $Error.Clear()
        
        $resourceGroupName = "weitry"
        $name = "weirp1"
        $nameZone = "weirp1.z10"
        $key = $config.credentials.storageAccountKey
        
        # key
        $testctx = New-AzStorageContext -StorageAccountName $nameZone -StorageAccountKey $key
        $testctx.StorageAccountName | should -be $name
        $testctx.StorageAccount.Credentials.AccountName | should -be $name
        $testctx.StorageAccount.Credentials.IsSharedKey  | should -be $true
        $testctx.BlobEndPoint.Contains($nameZone) | should -be $true
        $testctx.FileEndPoint.Contains($nameZone) | should -be $true
        $testctx.QueueEndPoint.Contains($nameZone) | should -be $true
        $testctx.TableEndPoint.Contains($nameZone) | should -be $true

        #SAS
        $sas = New-AzStorageContainerSASToken -Context $testctx -Name testcon -Permission r
        $testctx = New-AzStorageContext -StorageAccountName $nameZone -SasToken $sas -Protocol Http
        $testctx.StorageAccountName | should -be $name
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsSAS  | should -be $true
        $testctx.BlobEndPoint.Contains($nameZone) | should -be $true
        $testctx.FileEndPoint.Contains($nameZone) | should -be $true
        $testctx.QueueEndPoint.Contains($nameZone) | should -be $true
        $testctx.TableEndPoint.Contains($nameZone) | should -be $true
        
        # anonymous
        $testctx = New-AzStorageContext -StorageAccountName $nameZone -Anonymous -Endpoint "test.com"
        $testctx.StorageAccountName | should -be $name
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsAnonymous | should -be $true
        $testctx.BlobEndPoint.Contains($nameZone) | should -be $true
        $testctx.FileEndPoint.Contains($nameZone) | should -be $true
        $testctx.QueueEndPoint.Contains($nameZone) | should -be $true
        $testctx.TableEndPoint.Contains($nameZone) | should -be $true
        
        # Oauth
        $testctx = New-AzStorageContext -StorageAccountName $nameZone -Environment AzureChinaCloud
        $testctx.StorageAccountName | should -be $name
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsToken | should -be $true
        $testctx.BlobEndPoint.Contains($nameZone) | should -be $true
        $testctx.FileEndPoint.Contains($nameZone) | should -be $true
        $testctx.QueueEndPoint.Contains($nameZone) | should -be $true
        $testctx.TableEndPoint.Contains($nameZone) | should -be $true

        $PrimaryEndpoint = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $name).PrimaryEndpoints
        
        # key
        $testctx = New-AzStorageContext -StorageAccountName $name -StorageAccountKey $key -BlobEndpoint $PrimaryEndpoint.Blob -FileEndpoint $PrimaryEndpoint.File -QueueEndpoint $PrimaryEndpoint.Queue -TableEndpoint $PrimaryEndpoint.Table
        $testctx.StorageAccountName | should -be $name
        $testctx.StorageAccount.Credentials.AccountName | should -be $name
        $testctx.StorageAccount.Credentials.IsSharedKey  | should -be $true
        $testctx.BlobEndPoint| should -be $PrimaryEndpoint.Blob
        $testctx.FileEndPoint | should -be $PrimaryEndpoint.File
        $testctx.QueueEndPoint | should -be $PrimaryEndpoint.Queue
        $testctx.TableEndPoint | should -be $PrimaryEndpoint.Table
        Get-AzStorageContainer -Context $ctx -MaxCount 1

        #SAS
        $sas = New-AzStorageContainerSASToken -Context $testctx -Name testcon -Permission r
        $testctx = New-AzStorageContext -SasToken $sas -BlobEndpoint $PrimaryEndpoint.Blob -FileEndpoint $PrimaryEndpoint.File -QueueEndpoint $PrimaryEndpoint.Queue -TableEndpoint $PrimaryEndpoint.Table
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsSAS  | should -be $true
        $testctx.BlobEndPoint| should -be $PrimaryEndpoint.Blob
        $testctx.FileEndPoint | should -be $PrimaryEndpoint.File
        $testctx.QueueEndPoint | should -be $PrimaryEndpoint.Queue
        $testctx.TableEndPoint | should -be $PrimaryEndpoint.Table
        Get-AzStorageContainer -Context $ctx -MaxCount 1
        
        # anonymous
        $testctx = New-AzStorageContext -Anonymous -BlobEndpoint $PrimaryEndpoint.Blob -FileEndpoint $PrimaryEndpoint.File -QueueEndpoint $PrimaryEndpoint.Queue -TableEndpoint $PrimaryEndpoint.Table
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsAnonymous | should -be $true
        $testctx.BlobEndPoint| should -be $PrimaryEndpoint.Blob
        $testctx.FileEndPoint | should -be $PrimaryEndpoint.File
        $testctx.QueueEndPoint | should -be $PrimaryEndpoint.Queue
        $testctx.TableEndPoint | should -be $PrimaryEndpoint.Table
        
        # Oauth
        $testctx = New-AzStorageContext -UseConnectedAccount -BlobEndpoint $PrimaryEndpoint.Blob -FileEndpoint $PrimaryEndpoint.File -QueueEndpoint $PrimaryEndpoint.Queue -TableEndpoint $PrimaryEndpoint.Table        
        $testctx.StorageAccount.Credentials.AccountName | should -be $null
        $testctx.StorageAccount.Credentials.IsToken | should -be $true
        $testctx.BlobEndPoint| should -be $PrimaryEndpoint.Blob
        $testctx.FileEndPoint | should -be $PrimaryEndpoint.File
        $testctx.QueueEndPoint | should -be $PrimaryEndpoint.Queue
        $testctx.TableEndPoint | should -be $PrimaryEndpoint.Table
        Get-AzStorageContainer -Context $ctx -MaxCount 1

        $Error.Count | should -be 0
    }
    

    It "Blob Tag" -Tag "Totest" {
        $Error.Clear()
        
        # upload blob 
            # only tag
            $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob testtagblob -Tag @{"tag3" = "value3"} -Context $ctx -Force
            $b.TagCount | should -Be 1
            #only tag condition
            $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob testtagblob2  -Context $ctx -Force #-TagCondition """tag3""='value3'"
            $b.TagCount | should -Be 0
            # tag and tag condition not match, when blob not exist won't fail, if overwrite will fail
            $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob testtagblob3 -Tag @{"tag3" = "value3"; "tag2" = "version" }  -Context $ctx -Force #-TagCondition """tag2""='value2'"
            $b.TagCount | should -Be 2
            # tag and tag condition matches 
            $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob tagtesttodelete -Tag @{"tag3" = "value3"; "tag2" = "value2" }  -Context $ctx -Force # -TagCondition """tag2""='value2'"
            $b.TagCount | should -Be 2

            # Should fail with 412 since TagCondition not match
            Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob testtagblob -Tag @{"tag3" = "value3"; "tag2" = "version" } -TagCondition """tag1""='nonevalue'" -Context $ctx -Force -ErrorAction SilentlyContinue
            $Error[0].Exception.Status | Should -Be 412
            $Error.Count | should -be 1
            $Error.Clear()

        # Set/Get Blob tag with tag condition
            $tags = Set-AzStorageBlobTag -Container $containerName -Context $ctx  -Blob testtagblob -Tag @{"tag3" = "value3"; "tag2" = "version" } -TagCondition """tag3""='value3'"
            $tags.Count | should -Be 2
            $tags = Get-AzStorageBlobTag -Container $containerName -Context $ctx  -Blob testtagblob -TagCondition """tag3""='value3'" 
            $tags.Count | should -Be 2

            #Should fail with 412 since TagCondition not match
            Set-AzStorageBlobTag -Container $containerName -Context $ctx  -Blob testtagblob -Tag @{"tag3" = "value3"; "tag2" = "version" } -TagCondition """tag2""='nonevalue'" -ErrorAction SilentlyContinue
            Get-AzStorageBlobTag -Container $containerName -Context $ctx  -Blob testtagblob -TagCondition """tag2""='nonevalue'"  -ErrorAction SilentlyContinue
            $Error[0].Exception.Status | Should -Be 412
            $Error[1].Exception.Status | Should -Be 412
            $Error.Count | should -be 2
            $Error.Clear()

            # Set/Get blob tag with pipeline
                # list blob in contaiener
                $b = Get-AzStorageBlob -Container $containerName -Context $ctx  -IncludeVersion -Prefix testtag -IncludeTag
                $b[0].TagCount | should -Be 2
                $b[0].Tags.Count | should -Be 2
                # Set/Get blob tag to a single blob with pipeline
                $tags = $b[0] | Set-AzStorageBlobTag -Tag @{"tag3" = "value3"}
                $tags.Count | should -Be 1
                $tags = $b[0] | Get-AzStorageBlobTag
                $tags.Count | should -Be 1


        # download blob with tag condition
            $b = Get-AzStorageBlobContent -Destination $localDestFile -Container $containerName -Blob testtagblob -TagCondition """tag3""='value3'" -Context $ctx -Force
            $b[0].TagCount | should -Be 1

            # Should fail with 412 since TagCondition not match
            Get-AzStorageBlobContent -Destination $localDestFile -Container $containerName -Blob testtagblob -TagCondition """tag3""='nonevalue'" -Context $ctx -Force  -ErrorAction SilentlyContinue
            $Error[0].Exception.Status | Should -Be 412
            $Error.Count | should -be 1
            $Error.Clear()

        # list Blob across containers by tag 
            #list with tag match
            $blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression """tag3""='value3'" -Context $ctx 
            $blobs.Count | should -BeGreaterOrEqual 3
            $blobs[0].ContentType | Should -Be $null
            $blobs[0].LastModified | Should -Be $null

            # list with tag match, and get blob properties for each blob (Will be slow as add 1 request for each blob)
            $blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression "tag3='value3'" -Context $ctx -GetBlobProperty
            $blobs.Count | should -BeGreaterOrEqual 3
            ($blobs | ?{$_.BlobClient.BlobContainerName -eq $containerName})[0].ContentType  | Should -Not -Be $null
            ($blobs | ?{$_.BlobClient.BlobContainerName -eq $containerName})[0].LastModified| Should -Not -Be $null

            # list blob inside a container with container sas
            $sas = New-AzStorageContainerSASToken -Name $containerName -Context $ctx -Permission f 
            $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
            $blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression """tag3""='value3'" -Context $sasctx -Container $containerName
            $blobs.Count | should -Be 3

            # list blobs inside specific containers with specific tag
            $blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression "@container='$($containerName)' AND ""tag3""='value3' AND ""tag2""='value2'" -Context $ctx -GetBlobProperty
            $blobs.Count | should -BeGreaterOrEqual 1
            $blobs[0].ContentType | Should -Not -Be $null

            #list blob by tag , and chunk by chunk (with continuation token)
            $MaxReturn = 2
            $Total = 0
            $Token = $Null
            do
             {
                 $Blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression """tag3""='value3'" -Context $ctx -MaxCount $MaxReturn  -ContinuationToken $Token
                 $Blobs
                 $Total += $Blobs.Count
                 if($Blobs.Length -le 0) { Break;}
                 $Token = $Blobs[$blobs.Count -1].ContinuationToken;
             }
             While ($Token.NextMarker -ne $Null -and $Token.NextMarker -ne "")
             $Total | should -Be (Get-AzStorageBlobByTag -TagFilterSqlExpression """tag3""='value3'" -Context $ctx).count

        # list Blob include Tag in a container
            $b = Get-AzStorageBlob -Container $containerName -Context $ctx -IncludeTag
            $b.Count | should -BeGreaterThan 1
            ($b | ?{ $_.Name -like "testtag*"})[0].Tags.Count | should -BeGreaterOrEqual 1

        # Get single blob with tag, with/without tag condition
            $b = Get-AzStorageBlob -Container $containerName -Context $ctx -Blob testtagblob -IncludeTag
            $b.Count | should -Be 1
            $b.Tags.Count | should -BeGreaterOrEqual 1
            $b = Get-AzStorageBlob -Container $containerName -Context $ctx -Blob testtagblob -IncludeTag -TagCondition """tag3""='value3'"
            $b.Count | should -Be 1
            $b.Tags.Count | should -BeGreaterOrEqual 1

            #Should fail with 412 since TagCondition not match
            $b = Get-AzStorageBlob -Container $containerName -Context $ctx -Blob testtagblob -IncludeTag -TagCondition """tag2""='nonevalue'" -ErrorAction SilentlyContinue
            $Error[0].Exception.Status | Should -Be 412
            $Error.Count | should -be 1
            $Error.Clear()

        #remove Blob with tag condition
            Remove-AzStorageBlob -Container $containerName -Context $ctx -Blob tagtesttodelete -TagCondition """tag3""='value3'"

            #Should fail with 412 since TagCondition not match
            $Error.Clear()
            Remove-AzStorageBlob -Container $containerName -Context $ctx -Blob testtagblob -TagCondition """tag2""='nonevalue'" -ErrorAction SilentlyContinue
            $Error[0].Exception.Status | Should -Be 412
            $Error.Count | should -be 1
            $Error.Clear()


        # Start/stop Blob Copy with tag condition and set tag (stop might fail if copy finish too soon)
            $b = Start-AzStorageBlobCopy -SrcContainer $containerName -Context $ctx -SrcBlob testtagblob -DestContainer $containerName -DestBlob tagcopydest -Tag @{"tag3" = "value3"; "tag2" = "version" }  -TagCondition """tag3""='value3'" -DestTagCondition """tag3""='value3'"
            $b.Name | should -Be  tagcopydest
            $b.TagCount | should -Be 2
            $Error.Count | should -be 0  
            $b | Stop-AzStorageBlobCopy -Force -TagCondition """tag3""='value3'" -ErrorAction SilentlyContinue # very possible fail as copy finish too soon, with error "There is currently no pending copy operation.", If so, this error can be ignored
            Assert-AreEqual $true (($Error.Count -eq 0) -or ($Error[0].Exception.Message.Contains("AbortCopyFromUri does not support the TagConditions condition(s).")) -or ($Error[0].Exception.Message.Contains("There is currently no pending copy operation.")))
            $Error.Count | should -BeLessOrEqual 1
            $Error.Clear()

            #Should fail with 412 since TagCondition not match
            $b = Start-AzStorageBlobCopy -SrcContainer $containerName -Context $ctx -SrcBlob testtagblob -DestContainer $containerName -DestBlob tagcopydest -Tag @{"tag3" = "value3"; "tag2" = "version" }  -TagCondition """tag2""='nonevalue'" -Force  -ErrorAction SilentlyContinue
            $b = Start-AzStorageBlobCopy -SrcContainer $containerName -Context $ctx -SrcBlob testtagblob -DestContainer $containerName -DestBlob tagcopydest -Tag @{"tag3" = "value3"; "tag2" = "version" }  -DestTagCondition """tag2""='nonevalue'" -Force  -ErrorAction SilentlyContinue
            Stop-AzStorageBlobCopy -Container $containerName -Blob tagcopydest -Force -TagCondition """tag2""='nonevalue'" -Context $ctx  -ErrorAction SilentlyContinue
            $Error[0].Exception.Status | Should -Be 412
            $Error[1].Exception.Status | Should -Be 412
            $Error[2].Exception.Status | Should -Be 412
            $Error.Count | should -be 3
            $Error.Clear()

        # tag sas
            if ($ctx.StorageAccount.Credentials.IsSharedKey -or $ctx.StorageAccount.Credentials.IsToken)
            { 
                #blob sas + t
                $sas = New-AzStorageBlobSASToken -Container $containerName -Context $ctx  -Blob testtagblob -Permission t 
                $sascontext = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
                $tags = Get-AzStorageBlobTag -Container $containerName  -Blob testtagblob -Context $sascontext 
                $tags.count | should -BeGreaterOrEqual 1

                #container sas + t
                $sas = New-AzStorageContainerSASToken -Container $containerName -Context $ctx  -Permission t 
                $sascontext = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
                $tags = Get-AzStorageBlobTag -Container $containerName  -Blob testtagblob -Context $sascontext 
                $tags.count | should -BeGreaterOrEqual 1
            }

            if ($ctx.StorageAccount.Credentials.IsSharedKey)
            {
                #accountSAS + t ,f
                $sas = New-AzStorageAccountSASToken -Service Blob,Queue,File,Table -ResourceType Service,Container,Object -Context $ctx  -Permission rtxfy
                $sascontext = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
                $tags = Get-AzStorageBlobTag -Container $containerName  -Blob testtagblob -Context $sascontext -TagCondition """tag3""='value3'" 
                $tags.count | should -BeGreaterOrEqual 1
                $blobs = Get-AzStorageBlobByTag -TagFilterSqlExpression """tag3""='value3'" -Context  $sascontext  -GetBlobProperty 
                $blobs.Count | should -BeGreaterOrEqual 1
            }

        $Error.Count | should -be 0

    }

    It "Download Managed Disk"  {
        $Error.Clear()        
        
        # Disk is https://ms.portal.azure.com/#@microsoft.onmicrosoft.com/resource/subscriptions/{SubscriptionId}/resourceGroups/weitry/providers/Microsoft.Compute/disks/weioauthsas_download1G/overview
        $ResourceGroupName = "weitry"
        $DiskName = "weioauthsas_download1G"

        #Generate the SAS Uri to download
        New-AzDiskUpdateConfig -DataAccessAuthMode "AzureActiveDirectory" | Update-AzDisk -ResourceGroupName $ResourceGroupName -DiskName $DiskName
        $diskSas = Grant-AzDiskAccess -ResourceGroupName $ResourceGroupName -DiskName $DiskName -DurationInSecond 86400 -Access 'Read'
        $sasUri = $diskSas.AccessSAS

        # Download
        $blob = Get-AzStorageBlobContent -Uri $sasUri  -Destination $localDestFile -Force # -debug 
        $blob.Length | should -Be (Get-Item $localDestFile).Length

        #revoke the Sas Uri access
        Revoke-AzDiskAccess -ResourceGroupName $ResourceGroupName -DiskName $DiskName

        $Error.Count | should -be 0
    }
    
    It "HNS softdelete"  {
        $Error.Clear()
        
        $rgname = "weitry";
        $accountName = "weiadlscanary1"
        $ctx = (Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountName).Context

        $localSrcFile = "C:\temp\testfile_1K_0" 
        $filesystemName = "weihnssoftdelete"

        # enable soft delete (on blob, also on hns)
        Enable-AzStorageDeleteRetentionPolicy -RetentionDays 1  -Context $ctx 

        # create file system and items
        New-AzDatalakeGen2FileSystem -Name $filesystemName -Context $ctx        
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Directory -Path dir0 
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Directory -Path dir0/dir0
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Directory -Path dir0/dir1
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Directory -Path dir0/dir2
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir1/file2 -Source $localSrcFile -Force
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file3 -Source $localSrcFile -Force
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force 

        $items = Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName -Recurse
        $items.Count | should -be 8

        Remove-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Force -Path dir0/dir1/file1
        Remove-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Force -Path dir0/dir2/file3 
        Remove-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Force -Path dir0/dir2        

        $items = Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName -Recurse
        $items.Count | should -be 4

        $items = Get-AzDataLakeGen2DeletedItem -Context $ctx -FileSystem $filesystemName -Path dir0/dir2
        $items.Count | should -be 2

        $items = Get-AzDataLakeGen2DeletedItem -Context $ctx -FileSystem $filesystemName 
        $items.Count | should -be 3

        # item[0] should be dir0/dir1/file1
        $items0 = $items[0] | Restore-AzDataLakeGen2DeletedItem 
        $items0.Path | should -be $items[0].Path
        $items0.File.Exists() | should -be $true
        
        # item[1] should be dir0/dir2
        $items1 = Restore-AzDataLakeGen2DeletedItem -Context $ctx -FileSystem $filesystemName  -Path $items[1].Path -DeletionId $items[1].DeletionId 
        $items1.Path | should -be $items[1].Path
        $items1.Directory.Exists() | should -be $true

        $items = Get-AzDataLakeGen2DeletedItem -Context $ctx -FileSystem $filesystemName 
        $items.Count | should -be 1

        $items = Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName -Recurse
        $items.Count | should -be 7

        Remove-AzDatalakeGen2FileSystem -Name $filesystemName -Context $ctx -Force

        $Error.Count | should -be 0
    }

    It "Cross type blob copy"  {
        $Error.Clear()     
        
        $blobTypes = @("Block", "Page", "Append")

        $containerSAS = New-AzStorageContainerSASToken -Name $containerName -Permission  rwdl -ExpiryTime (Get-Date).AddDays(100) -Context $ctx
        $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $containerSAS

        # Create the containers and upload the src blobs 
        if ($false) { 
            New-AzStorageContainer -Name $containerName -Context $ctx
            New-AzStorageContainer -Name $containerName -Context $ctx2

            foreach ($srcType in $blobTypes) {
                $smallSrcBlob = Set-AzStorageBlobContent -File $blobCopySrcFile10M -Container $containerName -Blob "$($srctype)SmallSource" -Context $ctx -BlobType $srctype -Properties @{"ContentType" = "image/jpeg"} -Metadata @{"tag1" = "value1"; "tag2" = "value2"}
                $largeSrcBlob = Set-AzStorageBlobContent -File $localBigSrcFile -Container $containerName -Blob "$($srctype)LargeSource" -Context $ctx -BlobType $srctype -Properties @{"ContentType" = "image/jpeg"} -Metadata @{"tag1" = "value1"; "tag2" = "value2"}
            }
        }
        
        # tests for 9 directions of blob type conversions 
        foreach ($srcType in $blobTypes) {
            foreach ($destType in $blobTypes) { 
                # Small src file. Key ctx
                $smallDestBlob = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob "$($srctype)SmallSource" -Context $ctx -DestContainer $containerName -DestBlob "$($srcType)TO$($destType)SmallDest" -DestContext $ctx2 -DestBlobType $destType -Force
                $smallDestBlob.Name | Should -Be "$($srctype)TO$($desttype)SmallDest"
                $smallDestBlob.BlobProperties.ContentType | Should -Be "image/jpeg"
                $smallDestBlob.BlobProperties.ContentLength | Should -Be (Get-Item $blobCopySrcFile10M).Length
                $smallDestBlob.BlobProperties.Metadata.Count | Should -Be 2 
                $smallDestBlob.BlobBaseClient.AccountName | Should -Be $storageAccountName2

                # compare content 
                $smallDestBlob | Get-AzStorageBlobContent -Destination $localDestFile -Force 
                CompareFileMD5 $localBigSrcFile $localDestFile
                del $localDestFile
                $smallDestBlob | Remove-AzStorageBlob

                # Small src file. Sas ctx
                $smallDestBlob2 = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob "$($srctype)SmallSource" -Context $sasctx -DestContainer $containerName -DestBlob "$($srcType)TO$($destType)SmallDest2"  -DestBlobType $destType -Force
                $smallDestBlob2.Name | Should -Be "$($srctype)TO$($desttype)SmallDest2"
                $smallDestBlob2.BlobProperties.ContentType | Should -Be "image/jpeg"
                $smallDestBlob2.BlobProperties.ContentLength | Should -Be (Get-Item $blobCopySrcFile10M).Length
                $smallDestBlob2.BlobProperties.Metadata | Should -Be 2 
                $smallDestBlob2.BlobBaseClient.AccountName | Should -Be $storageAccountName
                
                $smallDestBlob2 | Get-AzStorageBlobContent -Destination $localDestFile -Force 
                CompareFileMD5 $localBigSrcFile $localDestFile
                del $localDestFile
                $smallDestBlob2 | Remove-AzStorageBlob

                # Small src file. oauth ctx 
                $smallDestBlob3 = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob "$($srctype)SmallSource" -Context $ctxoauth1 -DestContainer $containerName -DestBlob "$($srcType)TO$($destType)SmallDest3" -DestContext $ctxoauth2  -DestBlobType $destType -Force
                $smallDestBlob3.Name | Should -Be "$($srctype)TO$($desttype)SmallDest3"
                $smallDestBlob3.BlobProperties.ContentType | Should -Be "image/jpeg"
                $smallDestBlob3.BlobProperties.ContentLength | Should -Be (Get-Item $blobCopySrcFile10M).Length
                $smallDestBlob3.BlobProperties.Metadata | Should -Be 2 
                $smallDestBlob3.BlobBaseClient.AccountName | Should -Be $storageAccountName2

                $smallDestBlob3 | Get-AzStorageBlobContent -Destination $localDestFile -Force 
                CompareFileMD5 $localBigSrcFile $localDestFile
                del $localDestFile
                $smallDestBlob3 | Remove-AzStorageBlob

                $largeDestBlob = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob "$($srcType)BigSource" -Context $ctx -DestContainer $containerName -DestBlob "$($srcType)TO$($destType)BigDest" -DestContext $ctxoauth1 -DestBlobType $destType -Force
                $largeDestBlob.Name | Should -Be "$($srcType)TO$($destType)BigDest"
                $largeDestBlob.BlobProperties.ContentType | Should -Be "image/jpeg"
                $largeDestBlob.BlobProperties.ContentLength | Should -Be (Get-Item $blobCopySrcFile10M).Length
                $largeDestBlob.BlobProperties.Metadata | Should -Be 2 
                $largeDestBlob.BlobBaseClient.AccountName | Should -Be $storageAccountName

                $largeDestBlob | Get-AzStorageBlobContent -Destination $localDestFile -Force 
                CompareFileMD5 $localBigSrcFile $localDestFile
                del $localDestFile
                $largeDestBlob | Remove-AzStorageBlob
            }
        }

        # Block to block with access tier and rehydrate priority set 
        $blockToBlock1 = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob "BlockSmallSource" -Context $ctx -DestContainer $containerName -DestBlob "BlockToBlockWithAccessTier" -DestContext $ctx2 -DestBlobType $destType -StandardBlobTier "Cool" -RehydratePriority High -Force
        $blockToBlock1.AccessTier | Should -Be "Cool"

        # blob version 
        $smallSrcBlob = Set-AzStorageBlobContent -File $blobCopySrcFile10M -Container $containerName -Blob "$($srctype)SmallSource" -Context $ctx -BlobType $srctype -Properties @{"ContentType" = "image/jpeg"} -Metadata @{"tag1" = "value1"; "tag2" = "value2"}
        $blobs = Get-AzStorageBlob -Container $containerName -Context $ctx -IncludeVersion
        $blobVersion = $blob[1]
        $destBlob = $blobVersion | Copy-AzStorageBlob -DestBlob "blobVersionToBlock" -DestBlobType Block -DestContext $ctx2 -Force
        $destBlob.Name | Should -Be "blobVersionToBlock"

        $Error.Count | should -be 0
    }

    
    It "File cmdlet pipeline - for track2 migration"  {
        $Error.Clear() 

        $ctx2 = (Get-AzStorageAccount -ResourceGroupName $resourceGroupName -Name $storageAccountName2).Context

        $sas = New-AzStorageAccountSASToken -Service File -ResourceType Container,Object,Service -Permission rwdl -ExpiryTime (Get-Date).AddDays(6) -Context $ctx
        $ctxaccountsas = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas

        # All following File request will run with RequestIntent=Backup 
        $shareName = GetRandomContainerName
        $shareName2 = $shareName +2
        $shareName3 = $shareName +3

        # Prepare data
            $s = New-AzStorageShare -Name $shareName -Context $ctx

            New-AzStorageDirectory -ShareName $shareName -Path dir1 -Context $ctx 
            New-AzStorageDirectory -ShareName $shareName -Path dir1/dir2 -Context $ctx 
            Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path dir1/test1 -Context $ctx -Force
            Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path testfile -Context $ctx -Force

            $s.ShareClient.CreateSnapshot()

        # create Share
            $share2 = New-AzStorageShare -Name $shareName2 -Context $ctx

        # Get share 
            $shares = Get-AzStorageShare -Context $ctx
            $shares.count | should -BeGreaterOrEqual 3
            $s = Get-AzStorageShare -Name $shareName -Context $ctx
            $s.Name | should -be $shareName


        ## snapshot ##
            $shareSnapshot = $s.ShareClient.CreateSnapshot()
            $ss = (Get-AzStorageShare -Context $ctx | ?{$_.IsSnapshot -and $_.Name -eq $shareName}) |Select-Object -First 1


        ### Delete 
            $share2 = Get-AzStorageShare -Name $shareName2 -Context $ctx
            Set-AzStorageFileContent  -ShareName $shareName2 -Source C:\temp\1.txt -Path testfile -Context $ctx -Force

            Remove-AzStorageShare -Share $share2.CloudFileShare -Force 
            $share2.ShareClient.Exists().Value | should -be $false

            $share3 = New-AzStorageShare -Name $shareName3 -Context $ctxaccountsas
            $shareSnapshot3 = $share3.ShareClient.CreateSnapshot()
            Remove-AzStorageShare -Name $shareName3 -IncludeAllSnapshot -Context $ctx
            $share3.ShareClient.Exists().Value | should -be $false


            # delete share snapshot fail with -IncludeAllSnapshot
            Remove-AzStorageShare -Share $ss.CloudFileShare  -IncludeAllSnapshot -ErrorAction SilentlyContinue -Context $ctx # Should fail 
            $Error.Count | should -BeLessOrEqual 1
            $Error[0].Exception.Message| should -BeLike "*'IncludeAllSnapshot' should only be specified to delete a base share, and should not be specified to delete a Share snapshot*"
            $Error.Clear()

        # set share quota
            $sq = $ss | Set-AzStorageShareQuota -Quota 4096
            $sq.ShareProperties.QuotaInGB | should -be 4096
            $sq = Set-AzStorageShareQuota -Name $shareName -Context $ctx -Quota 1024
            $sq.ShareProperties.QuotaInGB | should -be 1024
            $sq = Set-AzStorageShareQuota -Share $s.CloudFileShare -Quota 2048
            $sq.ShareProperties.QuotaInGB | should -be 2048
            $sq = Set-AzStorageShareQuota -Name $shareName -Quota 1024  -Context $ctx 
            $sq.ShareProperties.QuotaInGB | should -be 1024

        ## ACCESS POLICY
            New-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx -Policy 123 -Permission rwdl -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(200)
            New-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx -Policy 1234  -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(200) 
            New-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx -Policy abc -Permission rwdlc 
            New-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx -Policy abcd -Permission rwdlc -ExpiryTime (Get-Date).AddDays(100)

            $policies = Get-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx
            $policies.Count | should -be 4    

            Set-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx -Policy abc -Permission r
            $policies = Get-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx
            $policies.Count | should -be 4
            ($policies | ?{ $_.Policy -eq "abc"}).Permissions | should -be r 
    
            Remove-AzStorageShareStoredAccessPolicy -ShareName $shareName  -Policy abc -PassThru  -Context $ctx
            $policies = Get-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx
            $policies.Count | should -be 3
            Remove-AzStorageShareStoredAccessPolicy -ShareName $shareName  -Policy 1234 -Context $ctx 
            $policies = Get-AzStorageShareStoredAccessPolicy -ShareName $shareName -Context $ctx
            $policies.Count | should -be 2
    
            $policies = Get-AzStorageShareStoredAccessPolicy -ShareName $shareName -Policy abcd -Context $ctx | Remove-AzStorageShareStoredAccessPolicy -ShareName $shareName  -Context $ctx 


        # Share SAS
            $saslist = New-Object System.Collections.Generic.List[System.String]
            $saslist.Add((New-AzStorageShareSASToken -ShareName $shareName -Policy 123  -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOnly -Context $ctx))
            $saslist.Add((New-AzStorageShareSASToken -ShareName $shareName -Permission rl -Context $ctx ))
            $saslist.Add((New-AzStorageShareSASToken -ShareName $shareName -Permission rlwd -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOrHttp -Context $ctx))
            foreach ($sas in $saslist)
            {
                $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
                Get-AzStorageFile -ShareName $shareName -Context $sasctx
            }

            $sasUri = New-AzStorageShareSASToken -ShareName $shareName -Permission rlwd -IPAddressOrRange "12.3.4-5.6.7.8" -Protocol HttpsOnly -Context $ctx -FullUri
            $sasUri | should -BeLike "$($ctx.StorageAccount.FileEndpoint)*$($shareName)*sp=rwdl*sig=*"

        #File SAS
            $f1 = Get-AzStorageFile -ShareName $shareName  -Path dir1/test1 -Context $ctx 
            $fs1 = $ss | Get-AzStorageFile  -Path dir1/test1 

            $saslist = New-Object System.Collections.Generic.List[System.String]

            $saslist.Add((New-AzStorageFileSASToken -ShareName $shareName -Path $f1.ShareFileClient.Path -Permission rlwd -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOnly -ExpiryTime 2050-10-10 -Context $ctx))
            $saslist.Add((New-AzStorageFileSASToken -ShareName $shareName -Path $f1.ShareFileClient.Path -Policy 123 -Protocol HttpsOnly -IPAddressOrRange "0.0.0.0-255.255.255.255" -Context $ctx ))
           # $saslist.Add(($f1 | New-AzStorageFileSASToken -Permission rlwd -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOnly -ExpiryTime 2050-10-10 -Context $ctx ))
           # $saslist.Add(($f1 | New-AzStorageFileSASToken -Policy 123 -Protocol HttpsOnly -IPAddressOrRange "0.0.0.0-255.255.255.255" -Context $ctx))
           # $saslist.Add(($fs1 | New-AzStorageFileSASToken -Permission rlwd -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOnly -ExpiryTime 2050-10-10 -Context $ctx)) 

            foreach ($sas in $saslist)
            {
                $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
                Get-AzStorageFile -ShareName $shareName -Path $f1.ShareFileClient.Path -Context $sasctx
            }

        # Directory

            $sas = $ss | New-AzStorageShareSASToken -Permission rlwd -IPAddressOrRange "0.0.0.0-255.255.255.255" -Protocol HttpsOnly 
            $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
            $d = Get-AzStorageFile -ShareName $shareName -Context $sasctx

            $d2 = $s | New-AzStorageDirectory -Path dir2 
            $d2.ShareDirectoryClient.Path | should -be dir2

            $d2 = Get-AzStorageFile -ShareName $shareName -Path dir2 -Context $ctx
            $d3 = $d2| New-AzStorageDirectory -Path dir3
            $d3.ShareDirectoryClient.Path | should -be dir2/dir3
            Remove-AzStorageDirectory -Directory $d3.CloudFileDirectory

            $d3 = New-AzStorageDirectory -ShareName $shareName -Path dir2/dir3 -Context $sasctx 
            $d3.ShareDirectoryClient.Path | should -be dir2/dir3

            $d4 = New-AzStorageDirectory -Directory $d2.CloudFileDirectory -Path dir4 
            $d4.ShareDirectoryClient.Path | should -be dir2/dir4 
    
            $d5 = New-AzStorageDirectory -ShareName $shareName -Path dir2/dir5 -Context $ctx
            $d5.ShareDirectoryClient.Path | should -be dir2/dir5
    
            $d = Get-AzStorageFile -ShareName $shareName -Context $sasctx
            $ds = $d | ?{$_.Name -eq "dir2"} | Get-AzStorageFile
            $ds.Count | should -BeGreaterOrEqual 3

            Remove-AzStorageDirectory -ShareName $shareName -Path dir2/dir3 -Context $ctx 
            $d4 | Remove-AzStorageDirectory -Context $ctx 
            Remove-AzStorageDirectory -Share $s.CloudFileShare -Path dir2/dir5
    
            $ds = $d | ?{$_.Name -eq "dir2"} | Get-AzStorageFile
            $ds.Count | should -Be 0

            $s | Remove-AzStorageDirectory -Path dir2 
            $d2.ShareDirectoryClient.Exists().value | should -be $false

        # File remove
            # remove by manul parameter    
            $f = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx  
            $f.ShareFileClient.Exists().value | should -be $true

            $f = Remove-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx -PassThru    
            $f.ShareFileClient.Exists().value | should -be $false
            Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path dir1/test1 -Context $ctx -Force
            $f.ShareFileClient.Exists().value | should -be $true

            #remove by file pipeline
            $f | Remove-AzStorageFile  
            $f.ShareFileClient.Exists().value | should -be $false
            Set-AzStorageFileContent -Share $s.CloudFileShare -Source $localSrcFile -Path dir1/test1  -Force
            $f.ShareFileClient.Exists().value | should -be $true

            Remove-AzStorageFile  -File $f.CloudFile    
            $f.ShareFileClient.Exists().value | should -be $false 
            $dir1 = Get-AzStorageFile -ShareName $shareName -Path dir1 -Context $ctx
            Set-AzStorageFileContent -Directory $dir1.CloudFileDirectory -Source $localSrcFile -Path test1 -Force
            $f.ShareFileClient.Exists().value | should -be $true

            # remove by dir pipeline
            $s | Get-AzStorageFile -Path dir1 | Remove-AzStorageFile -Path test1  -PassThru
            $f.ShareFileClient.Exists().value | should -be $false
            Set-AzStorageFileContent -ShareName $shareName -Source $localSrcFile -Path dir1/test1 -Context $ctx -Force
            $f.ShareFileClient.Exists().value | should -be $true

            Remove-AzStorageFile -Directory $dir1.CloudFileDirectory  -Path test1  -PassThru
            $f.ShareFileClient.Exists().value | should -be $false
            $dir1 | Set-AzStorageFileContent -Source $localSrcFile -Path test1 -Force
            $f.ShareFileClient.Exists().value | should -be $true
    
            # remove by share pipeline
            $s | Remove-AzStorageFile -Path dir1/test1  -PassThru
            $f.ShareFileClient.Exists().value | should -be $false
            $dir1 | Set-AzStorageFileContent -Source $localSrcFile -Path test1 -Force
            $f.ShareFileClient.Exists().value | should -be $true

            Remove-AzStorageFile -Share $s.CloudFileShare  -Path dir1/test1  -PassThru
            $f.ShareFileClient.Exists().value | should -be $false
            $dir1 | Set-AzStorageFileContent -Source $localSrcFile -Path test1 -Force
            $f.ShareFileClient.Exists().value | should -be $true

            # remove file from snapshot should fail
            $Error.Count | should -Be 0
            $ss  | Remove-AzStorageFile -Path dir1/test1  -PassThru -ErrorAction SilentlyContinue # Should fail 
            $Error.Count | should -BeLessOrEqual 1
            $Error[0].Exception.Message| should -BeLike "*Value for one of the query parameters specified in the request URI is invalid.*"
            $Error.Clear()

        # File Copy

            ### prepare blob

            # manual parameters

            # Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force # will fail, aligne with before
    
            $Error.Count | should -Be 0
            New-AzStorageContainer -Name $shareName -Context $ctx -ErrorAction SilentlyContinue
            $b = Set-AzStorageblobContent -Container $shareName -File $localSrcFile -blob testblob -Context $ctx -Force
            New-AzStorageShare -Name $shareName -Context $ctx2 -ErrorAction SilentlyContinue
            New-AzStorageDirectory -ShareName $shareName -Path dir1 -Context $ctx2 -ErrorAction SilentlyContinue
            $Error.Clear()

    
            $fsrc = $s | Get-AzStorageFile -Path dir1/test1 -Context $ctx 
            $f = Start-AzStorageFileCopy -SrcShareName $shareName -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctx -DestContext $ctx2 -Force
            $f | Get-AzStorageFileCopyState -WaitForComplete
            $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
            $f.ShareFileClient.Path | should -be "dir1/copydest"
            $f.FileProperties.ContentLength | should -be $fsrc.Length
            $f = Start-AzStorageFileCopy -SrcShareName $shareName -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctx -Force
            $f | Get-AzStorageFileCopyState -WaitForComplete
            $f.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
            $f.ShareFileClient.Path | should -be "dir1/copydest"
            $f.FileProperties.ContentLength | should -be $fsrc.Length

            $f = Start-AzStorageFileCopy -SrcContainerName  $shareName -SrcBlobName testblob -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctx -DestContext $ctx2 -Force
            $f | Get-AzStorageFileCopyState -WaitForComplete
            $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
            $f.ShareFileClient.Path | should -be "dir1/copydest"
            $f.FileProperties.ContentLength | should -be $b.Length
            $f = Start-AzStorageFileCopy -SrcContainerName  $shareName -SrcBlobName testblob -DestShareName $shareName -DestFilePath dir1/copydest -Context $ctx -Force
            $f | Get-AzStorageFileCopyState -WaitForComplete
            $f.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
            $f.ShareFileClient.Path | should -be "dir1/copydest"
            $f.FileProperties.ContentLength | should -Be $b.Length



            # from file object 
            $f1 = $ss | Get-AzStorageFile -Path dir1/test1 -Context $ctx 
            $fd = Get-AzStorageFile -ShareName $shareName  -Path dir1/copydest -Context $ctx 
                # fail since not dest context
                #$f1  | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force
                #Start-AzStorageFileCopy -SrcFile $f1.CloudFile  -DestShareName $shareName -DestFilePath dir1/copydest -Force
                # fail since not dest context
                #$f1  | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force -Context $ctx 
                #Start-AzStorageFileCopy -SrcFile $f1.CloudFile  -DestShareName $shareName -DestFilePath dir1/copydest -Force -Context $ctx 

                # success
                $f2 = $f1  | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx 
                $f2 | Get-AzStorageFileCopyState -WaitForComplete
                $f2.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
                $f2.ShareFileClient.Path | should -be "dir1/copydest"
                $f2.FileProperties.ContentLength | should -Be $f1.Length

                $f2 = Start-AzStorageFileCopy -SrcFile $f1.CloudFile  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx 
                $f2 | Get-AzStorageFileCopyState -WaitForComplete
                $f2.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
                $f2.ShareFileClient.Path | should -be "dir1/copydest"
                $f2.FileProperties.ContentLength | should -Be $f1.Length

                $fdest = Get-AzStorageFile -ShareName $shareName -Path dir1/copydest -Context  $ctx2
                $f2 = Start-AzStorageFileCopy -SrcFile $f1.CloudFile  -DestFile $fdest.CloudFile -Force #-DestContext $ctx   
                $f2 | Get-AzStorageFileCopyState -WaitForComplete
                $f2.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
                $f2.ShareFileClient.Path | should -be "dir1/copydest"
                $f2.FileProperties.ContentLength | should -Be $f1.Length
         
                $f2 = $f1  | Start-AzStorageFileCopy  -DestFile $fdest.CloudFile -Force
                $f2 | Get-AzStorageFileCopyState -WaitForComplete
                $f2.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
                $f2.ShareFileClient.Path | should -be "dir1/copydest"
                $f2.FileProperties.ContentLength | should -Be $f1.Length

            # From Share object
                $f2 = Start-AzStorageFileCopy -SrcShare $s.CloudFileShare -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx 
                $f2 | Get-AzStorageFileCopyState -WaitForComplete
                $f2.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
                $f2.ShareFileClient.Path | should -be "dir1/copydest"
                $f2.FileProperties.ContentLength | should -Be (Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx).Length

                # copy from file in share snapshot
                $f2 = Start-AzStorageFileCopy -SrcShare $ss.CloudFileShare -SrcFilePath dir1/test1 -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx 
                $copystatus = $f2 | Get-AzStorageFileCopyState -WaitForComplete
                $f2.ShareFileClient.AccountName | should -be $ctx.StorageAccountName
                $f2.ShareFileClient.Path | should -be "dir1/copydest"
                $f2.FileProperties.ContentLength | should -Be $f1.Length  
                #check copy status
                $srcfile = Get-AzStorageFile -Share $ss.CloudFileShare -Path dir1/test1          
                $copystatus.Status | should -be Success
                $copystatus.Source| should -BeLike "$($srcfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
                $copystatus.TotalBytes | should -be $srcfile.Length
                $copystatus.BytesCopied | should -be $srcfile.Length

            # From blob object
            $b = Get-AzStorageBlob -Containe $shareName -Blob testblob -Context $ctx 
            $bs = $b.ICloudBlob.Snapshot()
            $bs.FetchAttributes()
                # fail since not dest context
                #$b | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force
                #Start-AzStorageFileCopy -SrcBlob $b.ICloudBlob  -DestShareName $shareName -DestFilePath dir1/copydest -Force
                # fail since not dest context
                #$b | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force -Context $ctx 
                #Start-AzStorageFileCopy -SrcBlob $b.ICloudBlob  -DestShareName $shareName -DestFilePath dir1/copydest -Force -Context $ctx 
                # success
                $f = $b | Start-AzStorageFileCopy  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx2 
                $f | Get-AzStorageFileCopyState -WaitForComplete
                $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
                $f.ShareFileClient.Path | should -be "dir1/copydest"
                $f.FileProperties.ContentLength | should -Be $b.Length

                $f = Start-AzStorageFileCopy -SrcBlob $b.ICloudBlob  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx2 
                $f | Get-AzStorageFileCopyState -WaitForComplete
                $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
                $f.ShareFileClient.Path | should -be "dir1/copydest"
                $f.FileProperties.ContentLength | should -Be $b.Length
        
                $fdest = Get-AzStorageFile -ShareName $shareName -Path dir1/copydest -Context  $ctx2
                $f = Start-AzStorageFileCopy -SrcBlob $bs -DestFile $fdest.CloudFile -Force
                $copystatus = $f | Get-AzStorageFileCopyState -WaitForComplete
                $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
                $f.ShareFileClient.Path | should -be "dir1/copydest"
                $f.FileProperties.ContentLength | should -Be $bs.Properties.Length
                #check copy status
                $srcfile = Get-AzStorageFile -Share $ss.CloudFileShare -Path dir1/test1          
                $copystatus.Status | should -be Success
                $copystatus.Source| should -BeLike "$($bs.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
                $copystatus.TotalBytes | should -be $bs.Properties.Length
                $copystatus.BytesCopied | should -be $bs.Properties.Length

            # from container object
                $c = Get-AzStorageContainer -Name  $shareName -Context $ctx 
                $f = Start-AzStorageFileCopy -SrcContainer $c.CloudBlobContainer  -SrcBlobName testblob  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx2 
                $f | Get-AzStorageFileCopyState -WaitForComplete
                $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
                $f.ShareFileClient.Path | should -be "dir1/copydest"
                $f.FileProperties.ContentLength | should -Be $b.Length
            # from Uri
                $uri1 = New-AzStorageFileSASToken -ShareName $shareName -Path dir1/test1 -Permission rwdl -FullUri -Context $ctx 
                $f = Start-AzStorageFileCopy -AbsoluteUri $uri1  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx2 
                $f | Get-AzStorageFileCopyState -WaitForComplete
                $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
                $f.ShareFileClient.Path | should -be "dir1/copydest"
                #$f.FileProperties.ContentLength | should -Be $f1.Length

                $f = Start-AzStorageFileCopy -AbsoluteUri $uri1  -DestFile $fdest.CloudFile -Force 
                $f | Get-AzStorageFileCopyState -WaitForComplete
                $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
                $f.ShareFileClient.Path | should -be "dir1/copydest"

                $f = Start-AzStorageFileCopy -AbsoluteUri $uri1  -DestShareName $shareName -DestFilePath dir1/copydest -Force -DestContext $ctx2 
                $f | Get-AzStorageFileCopyState -WaitForComplete
                $f.ShareFileClient.AccountName | should -be $ctx2.StorageAccountName
                $f.ShareFileClient.Path | should -be "dir1/copydest"



        # Get copy state
            ## Prepare a big blob
            $biglocalfile = $localBigSrcFile
            $bigfile = Set-AzStorageFileContent -ShareName $shareName -Source $biglocalfile -Path bigfile -Context $ctx2 -Force -PassThru

            ## start copy     
            $bigdestfile = Start-AzStorageFileCopy -SrcFile  $bigfile.CloudFile -DestShareName $shareName -DestFilePath dir1/bigcopydest -DestContext $ctx -Force

            # get copy status in different ways
            $fd = Get-AzStorageFile -ShareName $shareName  -Path dir1/bigcopydest -Context $ctx 
            $fd.FileProperties.CopyStatus | should -be Pending
            $fd.FileProperties.CopySource | should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"

            $copystatus = $bigdestfile | Get-AzStorageFileCopyState
            $copystatus.Status | should -be Pending
            $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
            $copystatus.TotalBytes | should -be $bigfile.Length
            $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length

            $copystatus = Get-AzStorageFileCopyState -ShareName $shareName  -FilePath dir1/bigcopydest -Context $ctx 
            $copystatus.Status | should -be Pending
            $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
            $copystatus.TotalBytes | should -be $bigfile.Length
            $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length

            $copystatus = Get-AzStorageFileCopyState -File $bigdestfile.CloudFile
            $copystatus.Status | should -be Pending
            $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
            $copystatus.TotalBytes | should -be $bigfile.Length
            $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length

            # wait for complete
            $copystatus = $fd | Get-AzStorageFileCopyState -WaitForComplete
            $copystatus.Status | should -be Success
            $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
            $copystatus.TotalBytes | should -be $bigfile.Length
            $copystatus.BytesCopied | should -be $bigfile.Length
    
            $bigdestfile = Start-AzStorageFileCopy -SrcFile  $bigfile.CloudFile -DestShareName $shareName -DestFilePath dir1/bigcopydest -DestContext $ctx -Force
            Get-AzStorageFileCopyState -ShareName $shareName  -FilePath dir1/bigcopydest -Context $ctx -WaitForComplete
            $copystatus.Status | should -be Success
            $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
            $copystatus.TotalBytes | should -be $bigfile.Length
            $copystatus.BytesCopied | should -be $bigfile.Length

            $fd | Remove-AzStorageFile 


        # Stop copy 
            # by pipeline
            Start-AzStorageFileCopy -SrcFile  $bigfile.CloudFile -DestShareName $shareName -DestFilePath dir1/bigcopydest -DestContext $ctx -Force
            $fd = Get-AzStorageFile -ShareName $shareName  -Path dir1/bigcopydest -Context $ctx 
            ($fd | Get-AzStorageFileCopyState).Status | should -be Pending
            $stopmessage = $fd | Stop-AzStorageFileCopy -CopyId $fd.FileProperties.CopyId
            $stopmessage | should -BeLike "Stopped the copy task on file '$($fd.ShareFileClient.Uri.ToString())' successfully."
            $copystatus = $fd | Get-AzStorageFileCopyState
            $copystatus.Status | should -be Aborted
            $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
            $copystatus.TotalBytes | should -be $bigfile.Length
            $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length 

            # manually
            Start-AzStorageFileCopy -SrcFile  $bigfile.CloudFile -DestShareName $shareName -DestFilePath dir1/bigcopydest -DestContext $ctx -Force
            ($fd | Get-AzStorageFileCopyState).Status | should -be Pending
            $stopmessage = Stop-AzStorageFileCopy -ShareName $shareName  -FilePath dir1/bigcopydest -Context $ctx -Force
            $stopmessage | should -BeLike "Stopped the copy task on file '$($fd.ShareFileClient.Uri.ToString())' successfully."
            $copystatus = $fd | Get-AzStorageFileCopyState
            $copystatus.Status | should -be Aborted
            $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
            $copystatus.TotalBytes | should -be $bigfile.Length
            $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length 

            # by file object
            Start-AzStorageFileCopy -SrcFile  $bigfile.CloudFile -DestShareName $shareName -DestFilePath dir1/bigcopydest -DestContext $ctx -Force
            ($fd | Get-AzStorageFileCopyState).Status | should -be Pending
            $stopmessage = Stop-AzStorageFileCopy -File $fd.CloudFile -Context $ctx -Force
            $stopmessage | should -BeLike "Stopped the copy task on file '$($fd.ShareFileClient.Uri.ToString())' successfully."
            $copystatus = $fd | Get-AzStorageFileCopyState
            $copystatus.Status | should -be Aborted
            $copystatus.Source| should -BeLike "$($bigfile.CloudFile.SnapshotQualifiedStorageUri.PrimaryUri.ToString())*"
            $copystatus.TotalBytes | should -be $bigfile.Length
            $copystatus.BytesCopied | should -BeLessOrEqual $bigfile.Length 

        # List file handles
            #List from share
            Get-AzStorageFileHandle -ShareName $shareName -Context $ctx
            Get-AzStorageFileHandle -ShareName $shareName -Context $ctx -Recursive        
            Get-AzStorageFileHandle -ShareName $shareName -Context $ctx -Recursive -Skip 1 -First 3
            $share = Get-AzStorageShare -Name $shareName -Context $ctx
            $share | Get-AzStorageFileHandle  -Recursive 
            $share.CloudFileShare | Get-AzStorageFileHandle  -Recursive 

            # list from dir
            Get-AzStorageFileHandle -ShareName $shareName -Path dir1 -Context $ctx        
            Get-AzStorageFileHandle -ShareName $shareName -Path dir1 -Context $ctx -Recursive
            $dir = Get-AzStorageFile -ShareName $shareName -Path dir1 -Context $ctx
            $dir | Get-AzStorageFileHandle  -Recursive 
            $dir.CloudFileDirectory | Get-AzStorageFileHandle  -Recursive 

            #list from file
            Get-AzStorageFileHandle  -ShareName $shareName -Path dir1/test1  -Context $ctx
            Get-AzStorageFileHandle  -ShareName $shareName -Path dir1/test1  -Context $ctx -Skip 1 -First 1
            $file = Get-AzStorageFile -ShareName $shareName -Path dir1/test1  -Context $ctx
            $file | Get-AzStorageFileHandle  -Recursive 
            $file.CloudFile | Get-AzStorageFileHandle  -Recursive 


        # close file handles
            $h =Get-AzStorageFileHandle -ShareName $containerName -Context $ctx -Recursive   
            $h.Count | should -BeGreaterOrEqual 0


            # From Share - close all
            Close-AzStorageFileHandle -ShareName $shareName -CloseAll -Context $ctx -PassThru
            Close-AzStorageFileHandle -ShareName $shareName -CloseAll -Recursive -Context $ctx
            $share = Get-AzStorageShare -Name $shareName -Context $ctx
            $share | Close-AzStorageFileHandle  -Recursive -CloseAll -PassThru
            $share.CloudFileShare | Close-AzStorageFileHandle  -CloseAll -PassThru

            # From Dir - close all
            Close-AzStorageFileHandle -ShareName $shareName -Path dir1 -CloseAll -Context $ctx
            Close-AzStorageFileHandle -ShareName $shareName -Path dir1 -CloseAll -Recursive -Context $ctx
            $dir = Get-AzStorageFile -ShareName $shareName -Path dir1 -Context $ctx
            $dir | Close-AzStorageFileHandle  -CloseAll 
            $dir.CloudFileDirectory | Close-AzStorageFileHandle  -Recursive -CloseAll -PassThru
        
            # From file - close all
            Close-AzStorageFileHandle -ShareName $shareName -Path dir1/test1 -CloseAll -Context $ctx -PassThru
            $file = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx
            $file | Close-AzStorageFileHandle  -CloseAll  
            $file.CloudFile | Close-AzStorageFileHandle  -CloseAll 

            # From Share - Close single
            if ($h.count -ge 5)
            {
                $h[0] |  Close-AzStorageFileHandle -ShareName $shareName -Context $ctx
                $h[1] |  Close-AzStorageFileHandle -share $share.CloudFileShare 
                $share = Get-AzStorageShare -Name $shareName -Context $ctx
                $share |  Close-AzStorageFileHandle -FileHandle $h[2] 
                $share.CloudFileShare |  Close-AzStorageFileHandle -FileHandle $h[3] 
                Close-AzStorageFileHandle -ShareName $shareName -Context $ctx -FileHandle $h[4] 
            }

            # TEst continueation token
            Close-AzStorageFileHandle -ShareName $shareName -CloseAll -Recursive -Context $ctx -PassThru
            Close-AzStorageFileHandle -ShareName $shareName -Path dir1 -CloseAll -Recursive -Context $ctx -PassThru

        # Download file

            $share = Get-AzStorageShare -Name $shareName -Context $ctx
            $snapshot = $share.ShareClient.CreateSnapshot().value

            # Set-AzStorageFileContent -ShareName $containerName -Path 0size -Source C:\temp\0  -Context $ctx -force 
        
            $file = Get-AzStorageFileContent -Destination $localDestFile -ShareName $shareName -Path $bigfile.ShareFileClient.Path -CheckMd5 -Context $ctx2 -force -PassThru
            CompareFileFileMD5 $localDestFile $file

            # del $localDestFile

            # share pipeline
            $sharesnapshot = Get-AzStorageShare -Name $shareName -Context $ctx -SnapshotTime $snapshot.Snapshot        
            $file = $sharesnapshot | Get-AzStorageFileContent -Destination $localDestFile -Path dir1/test1  -PassThru   -force
            CompareFileFileMD5 $localDestFile $file        
            $file = Get-AzStorageFileContent -Destination $localDestFile -Share $sharesnapshot.CloudFileShare -Path dir1/test1 -PassThru -force 
            CompareFileFileMD5 $localDestFile $file

            #dir pipeline
            $dir = $share | Get-AzStorageFile -Path dir1
            $file = $dir | Get-AzStorageFileContent -Destination $localDestFile -Path test1 -force -PassThru
            CompareFileFileMD5 $localDestFile $file  

            del $localDestFile

            $file = $dir.CloudFileDirectory | Get-AzStorageFileContent -Destination $localDestFile -Path test1 -force -PassThru
            CompareFileFileMD5 $localDestFile $file  

            #file pipeline
            $file = Get-AzStorageFile -ShareName $shareName -Path dir1/test1 -Context $ctx  
            $file = Get-AzStorageFileContent -Destination $localDestFile -File $file.CloudFile -force -PassThru
            CompareFileFileMD5 $localDestFile $file      
            $file = $file | Get-AzStorageFileContent -Destination $localDestFile  -force -PassThru
            CompareFileFileMD5 $localDestFile $file 


        $Error.Count | should -be 0
    }

    It "Test case name"  {
        $Error.Clear()        


        $Error.Count | should -be 0
    }

    AfterAll {    
        $ProgressPreference = $OriginalPref
        Remove-AzStorageShare -Name $containerName -Force -Context $ctx -PassThru
        Remove-AzStorageContainer -Name $containerName -Force -Context $ctx -PassThru
        Remove-AzStorageContainer -Name $containerName -Context $ctxoauth2 -Force
    }
}