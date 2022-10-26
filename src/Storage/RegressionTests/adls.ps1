# Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane.ps1 -Show All -Strict -ExcludeTagFilter "Preview" 
C:\Users\weiwei\Desktop\PSH_Script\PSHTest\utils.ps1


BeforeAll {
    Import-Module C:\Users\weiwei\Desktop\PSH_Script\Assert.ps1
    Import-Module C:\Users\weiwei\Desktop\PSH_Script\PSHTest\utils.ps1
    $rootFolder = "C:\temp"
    cd $rootFolder

    $rgname = "weitry";
   # $accountName = "weisanity1"
    $accountName = "weiadlscanary1"
    $ctx = (Get-AzStorageAccount -ResourceGroupName $rgname -Name $accountName).Context

    $localSrcFile = "C:\temp\testfile_1K_0" #The file need exist before test, and should be 512 bytes aligned
    $localDestFile = "C:\temp\test1.txt" # test will create the file
    $filesystemName = "filesystem1"
    $dirname1 = "dir1"
    $dirname2 = "dir2/"
    $dirname3 = "dir3/"
    $filepath11 = "dir1/__datetime=2020-09-14 09%3A00%3A00"
    $filepath12 = "dir1/f%3Aile2"
    $filepath21 = "dir2/file1"
    $filepath22 = "dir2/file2"
    $id = "d6f7e858-345d-45f6-849c-8175519656b7"

    $container1 = New-AzDatalakeGen2FileSystem -Context $ctx -Name $filesystemName
}

Describe "dataplane test" {

    It "ADLS test" {
        $Error.Clear()

        #list all FileSystems
        Get-AzDatalakeGen2FileSystem -Context $ctx

        # Create Folder, and show properties/metadata in console
        $dir1 = New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $dirname1 -Directory -Permission rwxrwxrwx -Umask ---rwx---  -Property @{"ContentEncoding" = "UDF12"; "CacheControl" = "READ"} -Metadata  @{"tag1" = "value1"; "tag2" = "value2" }
        $dir1.Permissions.ToSymbolicPermissions() | should -be "rwx---rwx"
        $dir1.Properties.Metadata.Count | should -Be (2+1)
        $dir1.Properties.CacheControl | should -Be "READ"
        $dir1.IsDirectory | should -be $true
        $dir2 = New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $dirname2 -Directory
        $dir2.IsDirectory | should -be $true
        #$dir11 = New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $dirname11 -Directory

        # Create File, and show properties/matadata in console (Note, Permission/Umask is not supported)
        $sas = New-AzStorageContainerSASToken -Name $filesystemName -Permission rwdl -Context $ctx
        $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
        $file1 = New-AzDataLakeGen2Item -Context $sasctx -FileSystem $filesystemName -Path $filepath11 -Source $localSrcFile -Permission rwxrwxrwx -Umask ---rwx--- -Property @{"ContentEncoding" = "UDF8"; "CacheControl" = "READ"} -Metadata  @{"tag1" = "value1"; "tag2" = "value2" } $file1.IsDirectory | should -Be $false
        $file1.Permissions.ToSymbolicPermissions() | should -be "rwx---rwx"
        $file1.Properties.Metadata.Count  | should -Be 2
        $file1.Properties.ContentEncoding | should -Be "UDF8"
        $file1.Properties.ContentLength | should -Be (Get-Item $localSrcFile).Length
        ## create a file with task
        $task = New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $filepath12 -Source $localSrcFile -Force -asjob
        $task | Wait-Job
        $task.State | should -be "Completed"
        $task.Output[0].IsDirectory | should -be $false
        $task.Output[0].Properties.ContentLength | should -Be (Get-Item $localSrcFile).Length
        ## create a Datalake gen2 file and with the  source file name
        $destPath = $dirname1 + "\"+ (Get-Item $localSrcFile).Name
        $file2 = New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $destPath -Source $localSrcFile -Force
        $file2.IsDirectory | should -Be $false 
        $file2.Path | should -Be $destPath 

        # download content of a file (add -Force to avoid prompt)
        Get-AzDataLakeGen2ItemContent -Context $ctx -FileSystem $filesystemName -Path $filepath11 -Destination $localDestFile -Force
        ## download by pipeline and force overwrite
        Get-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $filepath11  |  Get-AzDataLakeGen2ItemContent -Destination $localDestFile -force
        ## download with a task.
        $task = Get-AzDataLakeGen2ItemContent -Context $ctx -FileSystem $filesystemName -Path $filepath11 -Destination $localDestFile -AsJob -Force
        $task | Wait-Job
        $task.Output

        # Sync copy a blob in the account
        Copy-AzStorageBlob -srcContainer $filesystemName -srcBlob $filepath11 -DestContainer $filesystemName -DestBlob $filepath12 -Context $ctx -Force

        # List Items (Will not fetch ACL/permission/owner, until add parameter '-FetchPermission')
        # Get root dir
        $result = Get-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName
        $result.Path | should -be "/"
        ## List direct Items from a container
        $result = Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName
        $result.count | should -be 2
        ## List recursively from a container, and fetch ACL/permission/owner (by default only show permission, See Get-AzDataLakeGen2Item sample for how to show other properties)
        $result = Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName -Recurse -FetchPermission
        $result.count | should -be 5
        ## List direct Items from a Folder
        Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName -Path $dirname1
        ## List recursively from a Folder, and fetch ACL/permission/owner (by default only show permission, See Get-AzDataLakeGen2Item sample for how to show other properties)
        Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName -Path $dirname1 -Recurse -FetchProperty

        ## List all items in a contaiener recursively with Continuation Token (when there are many items, we can list chunk by chunk to avoid OOM)
        $MaxReturn = 2  # this is just for sample, the MaxReturn can be much bigger, like 10000
        $Total = 0
        $Token = $Null
        do
         {
             $items = Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName -Recurse -MaxCount $MaxReturn  -ContinuationToken $Token
             echo $items 
             $Total += $items.Count
             if($items.Length -le 0) { Break;}
             $Token = $items[$items.Count -1].ContinuationToken;
         }
         While ($Token -ne $Null)
        echo "Total $Total items in container $filesystemName"

        # Get an Item (Will always fetch ACL/permission/owner)
        ## Get a folder, and show properties with dfs SAS
        $sas = New-AzDataLakeGen2SasToken -FileSystem $filesystemName -Path $dirname1 -Permission rw -Context $ctx -Protocol Https -IPAddressOrRange 0.0.0.0-255.255.255.0 -StartTime (Get-Date) -ExpiryTime (Get-Date).AddDays(6)  -EncryptionScope scope1
        $sas | should -BeLike "*ses=scope1*"
        $ctxsas = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
        $dir1 = Get-AzDataLakeGen2Item -Context $ctxsas -FileSystem $filesystemName -Path $dirname1
        $dir1.Name | should -be $dirname1
        $dir1.ACL.Length | should -BeGreaterThan 1
        $dir1.Permissions.Owner.value__ | should -BeGreaterOrEqual 1
        $dir1.Group | should -Not -be $null
        $dir1.Owner | should -Not -be $null
        $dir1.Properties.Metadata.Count | should -BeGreaterOrEqual 1
        $dir1.Properties.LastModified | should -Not -Be $null
        ## Get a file, and show properties
        $file1 = Get-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $filepath11
        $filepath11.Contains($file1.Name ) | should -be $true
        $file1.ACL.Length | should -BeGreaterThan 1
        $file1.Permissions.Owner.value__ | should -BeGreaterOrEqual 1
        $file1.Group | should -Not -be $null
        $file1.Owner | should -Not -be $null
        $file1.Properties.Metadata.Count  | should -BeGreaterOrEqual 1
        $file1.Properties| should -Not -Be $null

        # Update Folder
        ## create ACL with 3 ACEs
        $acl = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -Permission rw- 
        $acl = Set-AzDataLakeGen2ItemAclObject -AccessControlType group -Permission rw- -InputObject $acl 
        $acl = Set-AzDataLakeGen2ItemAclObject -AccessControlType other -Permission "-wx" -InputObject $acl
        $acl = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission rwx -InputObject $acl 
        $acl = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission r-x -InputObject $acl 
        $acl
        ## update the Folder (ACL, permission,owner, group, metadata, property can be updated with any conbination)
        $file = Update-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $dirname1 `
                         -Acl $acl `
                         -Property @{"ContentEncoding" = "UDF8"; "CacheControl" = "READ"; "ContentDisposition" = "True"; "ContentLanguage" = "EN-US"} `
                         -Metadata  @{"tag1" = "value1"; "tag2" = "value2" } `
                         -Permission rw-rw-rwx `
                         -Owner '$superuser' `
                         -Group '$superuser'  
        
        $sas =$file | New-AzDataLakeGen2SasToken  -Permission racwdlmeop 
        $ctxsas = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas
        Update-AzDataLakeGen2Item -Context $ctxsas -FileSystem $filesystemName -Path $dirname1 -Group '$superuser'               

        # update the file with pipeline (ACL, permission,owner, group, metadata, property can be updated with any conbination)
        $file = Get-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $filepath11 | Update-AzDataLakeGen2Item  `
                        -Acl $acl `
                        -Property @{"ContentType" = "image/jpeg"; "ContentEncoding" = "UDF8"; "CacheControl" = "READ"; "ContentDisposition" = "True"; "ContentLanguage" = "EN-US"} `
                        -Metadata  @{"tag1" = "value1"; "tag2" = "value2" } `
                        -Permission rw-rw-rwx `
                        -Owner '$superuser' `
                        -Group '$superuser'
        
        Update-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $filepath11 -Owner $id 
        # NOTE: ContentMD5 can also be updated on File, but if update ContentMD5 to a value not match the file Content, the file might can't be download with some tools like Storage Explorer
        # $file = Update-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $filepath11 -Property @{"ContentMD5" = "i727sP7HigloQDsqadNLHw=="}
        $file
        $file.ACL
        $file.Properties.Metadata
        $file.Properties

        # Set ACL recursively of all items in a container
        Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName -Recurse | Update-AzDataLakeGen2Item -Acl $acl

        # Set ACL recursively 
        # StopOnFailure, BatchSize are optional
        #Set-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Acl $acl -StopOnFailure -BatchSize 2000
        #Update-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path $dir1 -Acl $acl -StopOnFailure -BatchSize 2000
        #Remove-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Acl $acl -StopOnFailure -BatchSize 2000


        #Update ACL by adding an ACL Entry 
        ## Get the origin ACL
        $acl = (Get-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $filepath11).ACL
        ## Add an ACL entry
        $acl = New-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission "rwx" -InputObject $acl
        ## Setback ACL to Item
        Update-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $filepath11 -Acl $acl
        (Get-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $filepath11).ACL


        # move folder dir1 to dir3, then move back with pipeline
        $dir3 = Move-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $dirname1 -DestFileSystem $filesystemName -DestPath $dirname3 -Force #-Umask --------x -PathRenameMode Posix
        $dir3
        $dir1 = $dir3 | Move-AzDataLakeGen2Item -DestFileSystem $filesystemName -DestPath $dirname1 
        $dir1

        #rename Dir with SAS
        $sasrd = New-AzStorageContainerSASToken -Name $filesystemName -Permission rd -Context $ctx
        $sasctxrd = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sasrd
        $sasw = New-AzStorageContainerSASToken -Name $filesystemName -Permission w -Context $ctx
        $dir3 = Move-AzDataLakeGen2Item -Context $sasctxrd -FileSystem $filesystemName -Path $dirname1 -DestFileSystem $filesystemName -DestPath "$($dirname3)$($sasw)" -Force
        $dir3
        $dir1 = Move-AzDataLakeGen2Item -Context $sasctxrd -FileSystem $filesystemName -Path $dirname3 -DestFileSystem $filesystemName -DestPath "$($dirname1)$($sasw)"
        $dir1

        ## move file, then move back with pipeline
        $file2 = Move-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path $filepath11 -DestFileSystem $filesystemName -DestPath $filepath22 -Force #-Umask rwxrwx--x -PathRenameMode Posix
        $file2
        $file1 = $file2 | Move-AzDataLakeGen2Item -Context $ctx -DestFileSystem $filesystemName -DestPath $filepath11 
        $file1

        #remove folder with delete only SAS        
        $sas = New-AzStorageContainerSASToken -Name $filesystemName -Permission d -Context $ctx
        $sasctx = New-AzStorageContext -StorageAccountName $ctx.StorageAccountName -SasToken $sas 
        Remove-AzDataLakeGen2Item  -Context $sasctx -FileSystem $filesystemName -Path $dirname2 -Force
        #Remove-AzDataLakeGen2Item  -Context $ctx -FileSystem $filesystemName -Path $dirname2 -Force

        #remove file, without prompt
        Remove-AzDataLakeGen2Item  -Context $ctx -FileSystem $filesystemName -Path $filepath11 -Force

        # Remove all items in a container with with pipeline
        Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName | Remove-AzDataLakeGen2Item -Force

        $Error.Count | should -be 0

    }
    
    
    AfterAll { 
        #Cleanup
        Remove-AzDatalakeGen2FileSystem -Context $ctx -Name $filesystemName -Force   

    }
}