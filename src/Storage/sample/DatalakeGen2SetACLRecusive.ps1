# $id is logon Azure Account Id (log on with "Add-AzAccount")
# For testing out failure cases: Assign the 'Storage Blob Data Contributor' role to the logon Azure account, else assign 'Storage Blob Data Owner' role 
# For remove Acl recursive, the Acl entries with EntityId can be removed (not matter in default scope or not). The ACL entries without EntityID remove behavior need more detail doc.
$accountName = 
$accountKey = 
$filesystemName = 
$id =  
$localSrcFile = 

############################

Add-AzAccount

# create 2 storage credential for sharedkey and oauth
$ctx = New-AzStorageContext  $accountName -StorageAccountKey $accountKey 
$ctx2 = New-AzStorageContext  $accountName

# create file system
$container1 = New-AzDatalakeGen2FileSystem -Context $ctx -Name $filesystemName

# prepare the items to set acl resusive
New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Directory -Path dir0 
New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Directory -Path dir0/dir0
New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Directory -Path dir0/dir1
New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Directory -Path dir0/dir2
New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force
New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file2 -Source $localSrcFile -Force
New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file3 -Source $localSrcFile -Force
New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file3 -Source $localSrcFile -Force
New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force 
New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file5 -Source $localSrcFile -Force

Update-AzDataLakeGen2Item -Context $ctx -filesystem $filesystemName -Permission --x--x--x
Get-AzDataLakeGen2ChildItem -Context $ctx -FileSystem $filesystemName  -Recurse | Update-AzDataLakeGen2Item -Permission rwxr-x---

# check the items permission
Get-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName
Get-AzDataLakeGen2ChildItem -Context $ctx2 -FileSystem $filesystemName -Recurse -FetchProperty

# create valid ACL for update/set
$acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -Permission rwx 
$acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType group -Permission r-x -InputObject $acl1 
$acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType other -Permission "---" -InputObject $acl1
$acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType Mask -Permission "---" -InputObject $acl1
$acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission rwx -InputObject $acl1 
$acl1 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission rwx -DefaultScope -InputObject $acl1 
$acl1

# create valid ACL for remove/update
$acl2 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission r-x 
$acl2 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -EntityId $id -Permission r-x -DefaultScope -InputObject $acl2
$acl2


## Directory
    Set-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0 -Acl $acl1 
    Update-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0/dir2 -Acl $acl2
    # skip -path to run on container root dir
    Remove-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName  -Acl $acl2 

## file
    Set-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Acl $acl1
    Update-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Acl $acl2
    Remove-AzDataLakeGen2AclRecursive -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Acl $acl2

# set acl recursive chunk by chunk, (run cmdlet once will set acl on MaxBatchCount * BatchSize items) 
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
        $result = Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 2  -ContinuationToken $token -MaxBatchCount 2 
    }
    echo $result
    $TotalFilesSuccess += $result.TotalFilesSuccessfulCount
    $TotalDirectoriesSuccess += $result.TotalDirectoriesSuccessfulCount
    $totalFailure += $result.TotalFailureCount
    $FailedEntries += $result.FailedEntries
    $token = $result.ContinuationToken
}while (($token -ne $null) -and (($ContinueOnFailure) -or ($result.TotalFailureCount -eq 0)))
echo ""
echo "[Result Summary]"
echo "TotalDirectoriesSuccessfulCount: `t$($TotalDirectoriesSuccess)"
echo "TotalFilesSuccessfulCount: `t`t`t$($TotalFilesSuccess)"
echo "TotalFailureCount: `t`t`t`t`t$($totalFailure)"
echo "FailedEntries:"$($FailedEntries | ft)



### resume from failure with continueation token

    function ResetFileToFail
    {
        # reset the file to make it failure in set acl resusive
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
        New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
    }

    # Set ACL recursively 
        # ContinueOnFailure
        $result = Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 3 -ContinueOnFailure
        $result
        $result.FailedEntries | ft 
        # Rsume: fix failed entety, set acl one by one again
        foreach ($path in $result.FailedEntries.Name)
        {
            # fix failed entry 
            New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path $path -Source $localSrcFile -Force # | Update-AzDataLakeGen2Item -Permission rwxr-x---
            #setACL again
            Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path $path -Acl $acl1
        }  

        ResetFileToFail

        # Default: will fail on the first failure batch
        $result = Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 3 
        $result
        $result.FailedEntries | ft 
        # Resume: fix the permission issue and continue set ACL recusive with ContinuationToken
        New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x--- 
        New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
        $result = Set-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl1  -BatchSize 3 -ContinuationToken $result.ContinuationToken
        $result

        ResetFileToFail

    # Update ACL recursively 
        # ContinueOnFailure
        $result = Update-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 3 -ContinueOnFailure
        $result
        $result.FailedEntries | ft 
        # Rsume: fix failed entety, Update acl one by one again
        foreach ($path in $result.FailedEntries.Name)
        {
            # fix failed entry
            New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path $path -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
            #setACL again
            Update-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path $path -Acl $acl2
        }

        ResetFileToFail

        # Default: will fail on the first failure batch
        $result = Update-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 3 
        $result
        $result.FailedEntries | ft 
        # Resume: fix the permission issue and continue Update ACL recusive with ContinuationToken
        New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
        New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
        $result = Update-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 3  -ContinuationToken $result.ContinuationToken
        $result
    
        ResetFileToFail

    # remove ACL recursively 
        # ContinueOnFailure
        $result = Remove-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 20 -ContinueOnFailure
        $result
        $result.FailedEntries | ft 
        # Rsume: fix failed entety, remove acl one by one again
        foreach ($path in $result.FailedEntries.Name)
        {
            # fix failed entry
            New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path $path -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
            #setACL again
            Remove-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path $path -Acl $acl2
        }

        ResetFileToFail

        # Default: will fail on the first failure batch
        $result = Remove-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 20 
        $result
        $result.FailedEntries | ft 
        # Resume: fix the permission issue and continue Update ACL recusive with ContinuationToken
        New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
        New-AzDataLakeGen2Item -Context $ctx2 -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
        $result = Remove-AzDataLakeGen2AclRecursive -Context $ctx2 -FileSystem $filesystemName -Path dir0 -Acl $acl2 -BatchSize 20  -ContinuationToken $result.ContinuationToken
        $result
    
# Cleanup
Remove-AzDatalakeGen2FileSystem -Context $ctx -Name $filesystemName -Force