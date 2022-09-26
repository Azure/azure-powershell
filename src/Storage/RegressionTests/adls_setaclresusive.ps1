# Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane.ps1 -Show All -Strict -ExcludeTagFilter "Preview" 
Import-Module C:\Users\weiwei\Desktop\PSH_Script\PSHTest\utils.ps1

function ResetFileToFail
{
    # Reset the file to make it failure in set acl resusive
    # New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
    New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
    $blob = Get-AzStorageBlob -Container $filesystemName -blob dir0/dir2/file4 -Context $ctx 
    $leaseID = $blob.ICloudBlob.AcquireLease($null, $null);
}


BeforeAll {
    # Replace the path to your local config file 
    $config = (Get-Content D:\code\azure-powershell\src\Storage\RegressionTests\config.json -Raw | ConvertFrom-Json).adlsSetAclConfig
    Import-Module C:\Users\weiwei\Desktop\PSH_Script\Assert.ps1
    Import-Module C:\Users\weiwei\Desktop\PSH_Script\PSHTest\utils.ps1
    $secpasswd = ConvertTo-SecureString $config.credentials.secpwd -AsPlainText -Force
    $cred = New-Object System.Management.Automation.PSCredential ($config.credentials.username, $secpasswd)
    Add-AzAccount -ServicePrincipal -Tenant $config.credentials.tenantId -SubscriptionId $config.credentials.subscriptionId -Credential $cred 

    $ctx = New-AzStorageContext  aclcbn06stf -StorageAccountKey $config.credentials.storageAccountKey
    $ctx2 = New-AzStorageContext  aclcbn06stf

    $filesystemName = "adlstest2"
    $localSrcFile = "C:\temp\testfile_1K_0"
    $id = $config.credentials.entityId
    $leaseID = $config.credentials.leaseId


    # create file system
    $container1 = New-AzDatalakeGen2FileSystem -Context $ctx -Name $filesystemName

    # prepare the items to set acl resusive
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Directory -Path dir0 
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Directory -Path dir0/dir0
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Directory -Path dir0/dir1
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Directory -Path dir0/dir2
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file2 -Source $localSrcFile -Force
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file3 -Source $localSrcFile -Force
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file3 -Source $localSrcFile -Force
    New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force 
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file5 -Source $localSrcFile -Force
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file6 -Source $localSrcFile -Force
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file7 -Source $localSrcFile -Force
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file8 -Source $localSrcFile -Force
    New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file9 -Source $localSrcFile -Force

    Update-AzDataLakeGen2Item -Context $ctx -filesystem $filesystemName -Permission --x--x--x
    Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName  -Recurse | Update-AzDataLakeGen2Item -Permission rwxr-x---

    # check the items permission
    $rootDir = Get-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName
    $rootDir.Path | Should -Be "/"
    $items =  Get-AzDataLakeGen2ChildItem -Context $ctx2 -FileSystem $filesystemName -Recurse #-FetchProperty
    foreach ($item in $items) {$item.Permissions.ToSymbolicPermissions() | should -BeLike "rwxr-x---*"}

    # create valid ACL for update/set
    $acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -Permission rwx 
    $acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType group -Permission r-x -InputObject $acl1 
    $acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType other -Permission "---" -InputObject $acl1
    $acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType Mask -Permission "---" -InputObject $acl1
    $acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission rwx -InputObject $acl1 
    $acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission rwx -DefaultScope -InputObject $acl1 
    $acl1.Count | should -Be 6

    # create valid ACL for remove/update
    $acl2 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission r-x 
    $acl2 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission r-x -DefaultScope -InputObject $acl2
    $acl2.Count | should -Be 2
}

Describe "Set DataLakeGen2 Acl Recursive" {

    It "Set/update/remove on single Direcotry" {
        $Error.Clear()

        $result = Set-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0 -Acl $acl1 
        $result.TotalDirectoriesSuccessfulCount | should -BeGreaterOrEqual 0
        $result.TotalFilesSuccessfulCount | should -BeGreaterOrEqual 0
        $result.TotalFailureCount | should -Be 0
        $result.FailedEntries | should -Be $null

        $result = Update-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0/dir2 -Acl $acl2
        $result.TotalDirectoriesSuccessfulCount | should -BeGreaterOrEqual 0
        $result.TotalFilesSuccessfulCount | should -BeGreaterOrEqual 0
        $result.TotalFailureCount | should -Be 0
        $result.FailedEntries | should -Be $null

        # skip -path to run on container root dir
        $result = Remove-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName  -Acl $acl2
        $result.TotalDirectoriesSuccessfulCount | should -BeGreaterOrEqual 0
        $result.TotalFilesSuccessfulCount | should -BeGreaterOrEqual 0
        $result.TotalFailureCount | should -Be 0
        $result.FailedEntries | should -Be $null

        $Error.Count | should -be 0
    }

    It "Set/update/remove on single file" {
        $Error.Clear()

        $result = Set-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Acl $acl1
        $result.TotalDirectoriesSuccessfulCount | should -Be 0
        $result.TotalFilesSuccessfulCount | should -Be 1
        $result.TotalFailureCount | should -Be 0
        $result.FailedEntries | should -Be $null

        $result = Update-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Acl $acl2
        $result.TotalDirectoriesSuccessfulCount | should -Be 0
        $result.TotalFilesSuccessfulCount | should -Be 1
        $result.TotalFailureCount | should -Be 0
        $result.FailedEntries | should -Be $null

        $result = Remove-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Acl $acl2
        $result.TotalDirectoriesSuccessfulCount | should -Be 0
        $result.TotalFilesSuccessfulCount | should -Be 1
        $result.TotalFailureCount | should -Be 0
        $result.FailedEntries | should -Be $null

        $Error.Count | should -be 0
    }

    It "Set chunk by chunk" {
        $Error.Clear()

        # $ContinueOnFailure = $true
        $token = $null
        $TotalDirectoriesSuccess = 0
        $TotalFilesSuccess = 0
        $totalFailure = 0
        $FailedEntries = New-Object System.Collections.Generic.List[System.Object]
        do
        {
            #if ($ContinueOnFailure)
            #{
            #    $result = Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 2  -ContinuationToken $token -MaxBatchCount 2 -ContinueOnFailure
            #}
            #else
            #{
                $result = Set-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 2  -ContinuationToken $token -MaxBatchCount 2 
            #}
            echo $result
            $TotalFilesSuccess += $result.TotalFilesSuccessfulCount
            $TotalDirectoriesSuccess += $result.TotalDirectoriesSuccessfulCount
            $totalFailure += $result.TotalFailureCount
            if ($result.FailedEntries -ne $null)
            {
                $FailedEntries += $result.FailedEntries
            }
            if (($token -ne $null) -or ($result.TotalFailureCount -eq 0))
            {
                $token = $result.ContinuationToken
            }
        #}while (($token -ne $null) -and (($ContinueOnFailure) -or ($result.TotalFailureCount -eq 0)))
        }while (($token -ne $null) -and ($result.TotalFailureCount -eq 0))
        echo ""
        echo "[Result Summary]"
        echo "TotalDirectoriesSuccessfulCount: `t$($TotalDirectoriesSuccess)"
        echo "TotalFilesSuccessfulCount: `t`t`t$($TotalFilesSuccess)"
        echo "TotalFailureCount: `t`t`t`t`t$($totalFailure)"
        echo "ContinuationToken: `t`t`t`t`t$($token)"
        echo "FailedEntries:"$($FailedEntries | ft)

        ($TotalDirectoriesSuccess + $TotalFilesSuccess) | Should -Be ((Get-AzDataLakeGen2ChildItem -Context $ctx2 -FileSystem $filesystemName -Recurse -Path dir0).Count + 1)
        $totalFailure | should -be 0
        $token | should -BeNullOrEmpty
        $FailedEntries.Count | should -Be 0

        $Error.Count | should -be 0
    }

    It "Set chunk by chunk with ContinueOnFailure" {
        $Error.Clear()
        
        $ContinueOnFailure = $true

        $token = $null
        $TotalDirectoriesSuccess = 0
        $TotalFilesSuccess = 0
        $totalFailure = 0
        $FailedEntries = New-Object System.Collections.Generic.List[System.Object]
        do
        {
            if ($ContinueOnFailure)
            {
                $result = Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 2  -ContinuationToken $token -MaxBatchCount 2 -ContinueOnFailure
            }
            else
            {
                $result = Set-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 2  -ContinuationToken $token -MaxBatchCount 2 
            }
            echo $result
            $TotalFilesSuccess += $result.TotalFilesSuccessfulCount
            $TotalDirectoriesSuccess += $result.TotalDirectoriesSuccessfulCount
            $totalFailure += $result.TotalFailureCount
            if ($result.FailedEntries -ne $null)
            {
                $FailedEntries += $result.FailedEntries
            }
            if (($token -ne $null) -or ($result.TotalFailureCount -eq 0))
            {
                $token = $result.ContinuationToken
            }
        }while (($token -ne $null) -and (($ContinueOnFailure) -or ($result.TotalFailureCount -eq 0)))
        # }while (($token -ne $null) -and ($result.TotalFailureCount -eq 0))
        echo ""
        echo "[Result Summary]"
        echo "TotalDirectoriesSuccessfulCount: `t$($TotalDirectoriesSuccess)"
        echo "TotalFilesSuccessfulCount: `t`t`t$($TotalFilesSuccess)"
        echo "TotalFailureCount: `t`t`t`t`t$($totalFailure)"
        echo "ContinuationToken: `t`t`t`t`t$($token)"
        echo "FailedEntries:"$($FailedEntries | ft)

        ($TotalDirectoriesSuccess + $TotalFilesSuccess + $totalFailure) | Should -Be ((Get-AzDataLakeGen2ChildItem -Context $ctx2 -FileSystem $filesystemName -Recurse -Path dir0).Count + 1)
        $totalFailure | should -be 1
        $token | should -BeNullOrEmpty
        $FailedEntries.Count | should -Be 1

        $Error.Count | should -be 0
    }

    It "Set resume with ContinuationToken" {
        $Error.Clear()

        ResetFileToFail
        
        # Default: will fail on the first failure batch
        $result = Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 2
        ($result.ContinuationToken -eq $null) | should -Be $false
        $result.TotalFailureCount | should -Be 1
        $result.FailedEntries.Count | Should -Be 1 
        # Resume: fix the permission issue and continue set ACL recusive
        # New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x--- 
        New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---  | Out-Null
        $result = Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 3 -ContinuationToken $result.ContinuationToken
        ($result.ContinuationToken -eq $null) | should -Be $true
        $result.TotalFailureCount | should -Be 0
        $result.FailedEntries.Count | Should -Be 0 

        $Error.Count | should -be 0
    }

    It "Update resume with ContinuationToken" {
        $Error.Clear()

        ResetFileToFail

        $result = Update-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 3 
        ($result.ContinuationToken -eq $null) | should -Be $false
        $result.TotalFailureCount | should -Be 1
        $result.FailedEntries.Count | Should -Be 1 
        # Resume: fix the permission issue and continue set ACL recusive
        # New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x--- 
        New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
        $result = Update-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 3  -ContinuationToken $result.ContinuationToken
        ($result.ContinuationToken -eq $null) | should -Be $true
        $result.TotalFailureCount | should -Be 0
        $result.FailedEntries.Count | Should -Be 0 

        $Error.Count | should -be 0
    }

    It "REmove resume with ContinuationToken" {
        $Error.Clear()

        ResetFileToFail
        
        $result = Remove-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 20 
        ($result.ContinuationToken -eq $null) | should -Be $true
        $result.TotalFailureCount | should -Be 1
        $result.FailedEntries.Count | Should -Be 1 
        # Resume: fix the permission issue and continue set ACL recusive
        # New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x--- 
        New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
        $result = Remove-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 20  -ContinuationToken $result.ContinuationToken
        ($result.ContinuationToken -eq $null) | should -Be $true
        $result.TotalFailureCount | should -Be 0
        $result.FailedEntries.Count | Should -Be 0 

        $Error.Count | should -be 0
    }

    It "Set resume from failure by rerun set acl on the single failed files" {
        $Error.Clear()

        ResetFileToFail
        
        $result = Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 2 -ContinueOnFailure
        $result.ContinuationToken | should -BeNullOrEmpty
        $result.TotalFailureCount | should -Be 1
        $result.FailedEntries.Count | Should -Be 1 
        ($result.TotalDirectoriesSuccessfulCount + $result.TotalFilesSuccessfulCount + $result.TotalFailureCount) | Should -Be ((Get-AzDataLakeGen2ChildItem -Context $ctx2 -FileSystem $filesystemName -Recurse -Path dir0).Count + 1)
        # Rsume: fix failed entety, set acl one by one again
        foreach ($path in $result.FailedEntries.Name)
        {
            # fix failed entry 
            New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path $path -Source $localSrcFile -Force # | Update-AzDataLakeGen2Item -Permission rwxr-x---
            #setACL again
            $result = Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path $path -Acl $acl1
            $result.ContinuationToken | should -BeNullOrEmpty
            $result.TotalFailureCount | should -Be 0
            $result.FailedEntries.Count | Should -Be 0 
            $result.TotalDirectoriesSuccessfulCount | Should -Be 0
            $result.TotalFilesSuccessfulCount | Should -Be 1 
            $result.TotalFailureCount | Should -Be 0             
        } 
        
        #recover failure file    
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x--- 

        $Error.Count | should -be 0
    }

    It "Update resume from failure by rerun set acl on the single failed files"  {
        $Error.Clear()

        ResetFileToFail

        $result = Update-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 3 -ContinueOnFailure
        $result.ContinuationToken | should -BeNullOrEmpty
        $result.TotalFailureCount | should -Be 1
        $result.FailedEntries.Count | Should -Be 1 
        ($result.TotalDirectoriesSuccessfulCount + $result.TotalFilesSuccessfulCount + $result.TotalFailureCount) | Should -Be ((Get-AzDataLakeGen2ChildItem -Context $ctx2 -FileSystem $filesystemName -Recurse -Path dir0).Count + 1)
        # Rsume: fix failed entety, Update acl one by one again
        foreach ($path in $result.FailedEntries.Name)
        {
            # fix failed entry
            New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path $path -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
            #setACL again
            $result = Update-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path $path -Acl $acl2
            $result.ContinuationToken | should -BeNullOrEmpty
            $result.TotalFailureCount | should -Be 0
            $result.FailedEntries.Count | Should -Be 0 
            $result.TotalDirectoriesSuccessfulCount | Should -Be 0
            $result.TotalFilesSuccessfulCount | Should -Be 1 
            $result.TotalFailureCount | Should -Be 0 
        }

        #recover failure file    
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x--- 

        $Error.Count | should -be 0
    }

    It "Remove resume from failure by rerun set acl on the single failed files"  {
        $Error.Clear()

        ResetFileToFail

        $result = Remove-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 20 -ContinueOnFailure
        $result.ContinuationToken | should -BeNullOrEmpty
        $result.TotalFailureCount | should -Be 1
        $result.FailedEntries.Count | Should -Be 1 
        ($result.TotalDirectoriesSuccessfulCount + $result.TotalFilesSuccessfulCount + $result.TotalFailureCount) | Should -Be ((Get-AzDataLakeGen2ChildItem -Context $ctx2 -FileSystem $filesystemName -Recurse -Path dir0).Count + 1)
        # Rsume: fix failed entety, remove acl one by one again
        foreach ($path in $result.FailedEntries.Name)
        {
            # fix failed entry
            New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path $path -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
            #setACL again
            $result = Remove-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path $path -Acl $acl2
            $result.ContinuationToken | should -BeNullOrEmpty
            $result.TotalFailureCount | should -Be 0
            $result.FailedEntries.Count | Should -Be 0 
            $result.TotalDirectoriesSuccessfulCount | Should -Be 0
            $result.TotalFilesSuccessfulCount | Should -Be 1 
            $result.TotalFailureCount | Should -Be 0 
        }

        #recover failure file    
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x--- 

        $Error.Count | should -be 0
    }
    
    
    AfterAll { 
        #Cleanup
        Remove-AzDatalakeGen2FileSystem -Context $ctx -Name $filesystemName -Force   

    }
}