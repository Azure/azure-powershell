Invoke-LiveTestScenario -Name "File basics" -Description "Test File basic operation" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $storageAccountName = New-LiveTestStorageAccountName
    $shareName = New-LiveTestResourceName
    $testfile512path = "$PSScriptRoot\TestFiles\testfile512"
    $localDestFile = "$PSScriptRoot\TestFiles\dest"
    $location = $rg.Location
    $account = New-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Location $location -SkuName Standard_GRS -AllowSharedKeyAccess $true -Tag @{"Az.Sec.DisableAllowSharedKeyAccess::Skip" = "For Powershell test."}
    $ctx = $account.Context 
    $ctx1 = New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey (Get-AzStorageAccountKey -ResourceGroupName $rgName -Name $storageAccountName)[0].Value

    $objectName1 = "filetest1.txt." 
    $objectName2 = "filetest2.txt"   

    #Create a file share 
    New-AzStorageShare $shareName -Context $ctx
    $Share = Get-AzStorageShare -Name $shareName -Context $ctx
    Assert-AreEqual $Share.Count 1
    Assert-AreEqual $Share[0].Name $shareName

    # upload file
    $t = Set-AzStorageFileContent -source $testfile512path -ShareName $shareName -Path $objectName1 -Force -Context $ctx -asjob
    $t | wait-job
    Assert-AreEqual $t.State "Completed"
    Assert-AreEqual $t.Error $null

    # upload/remove file/dir with -DisAllowTrailingDot            
    $dirName1WithTrailingDot = "testdir1.."      
    $dirName1WithOutTrailingDot = "testdir1" 
    $objectPathWithoutTrailingDot  = "testdir1/filetest1.txt"    
    New-AzStorageDirectory -ShareName $shareName -Path $dirName1WithTrailingDot -Context $ctx1 -DisAllowTrailingDot
    $file11 = Set-AzStorageFileContent -source $testfile512path -ShareName $shareName -Path "$($dirName1WithTrailingDot)/$($objectName1)" -Force -Context $ctx1 -DisAllowTrailingDot
    $file = Get-AzStorageFile -ShareName $shareName -Path $objectPathWithoutTrailingDot -Context $ctx1 -DisAllowTrailingDot
    Assert-AreEqual $file.Count 1
    Assert-AreEqual $file[0].ShareFileClient.Path $objectPathWithoutTrailingDot
    Remove-AzStorageFile -ShareName $shareName -Path "$($dirName1WithTrailingDot)/$($objectName1)" -Context $ctx1 -DisAllowTrailingDot
    Remove-AzStorageDirectory -ShareName $shareName -Path $dirName1WithTrailingDot -Context $ctx1 -DisAllowTrailingDot

    # list file        
    $file = Get-AzStorageFile -ShareName $shareName -Context $ctx
    Assert-AreEqual $file.Count 1
    Assert-AreEqual $file[0].Name $objectName1
    Assert-NotNull $file[0].ListFileProperties.Properties.ETag

    if ($Env:OS -eq "Windows_NT")
    {
        Set-AzStorageFileContent -source $testfile512path -ShareName $shareName -Path $objectName1  -PreserveSMBAttribute -Force -Context $ctx
    }
    else
    {
        Set-AzStorageFileContent -source $testfile512path -ShareName $shareName -Path $objectName1 -Force -Context $ctx
    }
    $file = Get-AzStorageFile -ShareName $shareName -Context $ctx 
    Assert-AreEqual $file.Count 1
    Assert-AreEqual $file[0].Name $objectName1
    Assert-NotNull $file[0].ListFileProperties.Properties.ETag
    if ($Env:OS -eq "Windows_NT")
    {
        $localFileProperties = Get-ItemProperty $testfile512path
        Assert-AreEqual $localFileProperties.CreationTime.ToUniversalTime().Ticks $file[0].ListFileProperties.Properties.CreatedOn.ToUniversalTime().Ticks
        Assert-AreEqual $localFileProperties.LastWriteTime.ToUniversalTime().Ticks $file[0].ListFileProperties.Properties.LastWrittenOn.ToUniversalTime().Ticks
        Assert-AreEqual $localFileProperties.Attributes.ToString() $file[0].ListFileProperties.FileAttributes.ToString()
    }

    Start-AzStorageFileCopy -SrcShareName $shareName -SrcFilePath $objectName1 -DestShareName $shareName -DestFilePath $objectName2 -Force -Context $ctx -DestContext $ctx
    Get-AzStorageFileCopyState -ShareName $shareName -FilePath $objectName2 -Context $ctx -WaitForComplete
    $file = Get-AzStorageFile -ShareName $shareName -Context $ctx
    Assert-AreEqual $file.Count 2
    Assert-AreEqual $file[0].Name $objectName1
    Assert-AreEqual $file[1].Name $objectName2

    $t = Get-AzStorageFileContent -ShareName $shareName -Path $objectName1 -Destination $localDestFile -Force -Context $ctx -asjob
    $t | wait-job
    Assert-AreEqual $t.State "Completed"
    Assert-AreEqual $t.Error $null   
    Assert-AreEqual (Get-FileHash -Path $localDestFile -Algorithm MD5).Hash (Get-FileHash -Path $testfile512path -Algorithm MD5).Hash
           
    if ($Env:OS -eq "Windows_NT")
    {
        Get-AzStorageFileContent -ShareName $shareName -Path $objectName1 -Destination $localDestFile -PreserveSMBAttribute -Force -Context $ctx1
    }
    else
    {
        Get-AzStorageFileContent -ShareName $shareName -Path $objectName1 -Destination $localDestFile -Force -Context $ctx
    }
    Assert-AreEqual (Get-FileHash -Path $localDestFile -Algorithm MD5).Hash (Get-FileHash -Path $testfile512path -Algorithm MD5).Hash
    if ($Env:OS -eq "Windows_NT")
    {
        $file = Get-AzStorageFile -ShareName $shareName -Path $objectName1 -Context $ctx1
        $localFileProperties = Get-ItemProperty $testfile512path
        Assert-AreEqual $localFileProperties.CreationTime.ToUniversalTime().Ticks $file[0].FileProperties.SmbProperties.FileCreatedOn.ToUniversalTime().Ticks
        Assert-AreEqual $localFileProperties.LastWriteTime.ToUniversalTime().Ticks $file[0].FileProperties.SmbProperties.FileLastWrittenOn.ToUniversalTime().Ticks
        Assert-AreEqual $localFileProperties.Attributes.ToString() $file[0].FileProperties.SmbProperties.FileAttributes.ToString()
    }

    $fileName1 = "new" + $objectName1
    $file = Get-AzStorageFile -ShareName $shareName -Path $objectName1 -Context $ctx

    $file2 = Rename-AzStorageFile -ShareName $shareName -SourcePath $objectName1 -DestinationPath $fileName1 -Context $ctx
    Assert-AreEqual $file2.Name $fileName1 
    Assert-AreEqual $file.FileProperties.ContentType $file2.FileProperties.ContentType
    Assert-AreEqual $file.FileProperties.ContentLength $file2.FileProperties.ContentLength

    $file3 = $file2 | Rename-AzStorageFile -DestinationPath $fileName1 -Context $ctx1 -Force
    Assert-AreEqual $file3.Name $fileName1 
    Assert-AreEqual $file2.FileProperties.ContentType $file3.FileProperties.ContentType
    Assert-AreEqual $file2.FileProperties.ContentLength $file3.FileProperties.ContentLength
   
    Remove-AzStorageFile -ShareName $shareName -Path $fileName1 -Context $ctx
    $file = Get-AzStorageFile -ShareName $shareName -Context $ctx
    Assert-AreEqual $file.Count 1
    Assert-AreEqual $file[0].Name $objectName2

    $dirName = "filetestdir"
    New-AzStorageDirectory -ShareName $shareName -Path $dirName -Context $ctx    
    $file = Get-AzStorageShare -Name $shareName -Context $ctx1 | Get-AzStorageFile -ExcludeExtendedInfo
    Assert-AreEqual $file.Count 2
    Assert-AreEqual $file[0].Name $dirName
    Assert-AreEqual $file[0].GetType().Name "AzureStorageFileDirectory"
    Assert-Null $file[0].ListFileProperties.Properties.ETag
    Assert-AreEqual $file[1].Name $objectName2
    Assert-AreEqual $file[1].GetType().Name "AzureStorageFile"
    Assert-Null $file[1].ListFileProperties.Properties.ETag

    $newDir = "new" + $dirName + ".."
    $dir = Get-AzStorageFile -ShareName $shareName -Path $dirName -Context $ctx
    $dir2 = Rename-AzStorageDirectory -ShareName $shareName -SourcePath $dirName -DestinationPath $newDir -Context $ctx1
    Assert-AreEqual $newDir $dir2.Name
    Assert-AreEqual $dir.ListFileProperties.IsDirectory $dir2.ListFileProperties.IsDirectory
    Assert-AreEqual $dir.ListFileProperties.FileAttributes $dir2.ListFileProperties.FileAttributes

    $newDir2 = "new2" + $dirName
    $dir3 = $dir2 | Rename-AzStorageDirectory -DestinationPath $newDir2 -Context $ctx1
    Assert-AreEqual $newDir2 $dir3.Name
    Assert-AreEqual $dir2.ListFileProperties.IsDirectory $dir3.ListFileProperties.IsDirectory
    Assert-AreEqual $dir2.ListFileProperties.FileAttributes $dir3.ListFileProperties.FileAttributes

    $dir3 | Remove-AzStorageDirectory
    $file = Get-AzStorageFile -ShareName $shareName -Context $ctx
    Assert-AreEqual $file.Count 1
    Assert-AreEqual $file[0].Name $objectName2
    Assert-AreEqual $file[0].GetType().Name "AzureStorageFile"

    # Clean Storage Account
    Remove-AzStorageShare -Name $shareName -Force -Context $ctx
}