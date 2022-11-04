function Assert-AreEqual
{
    param([object] $expected, [object] $actual, [string] $message)

  if (!$message)
  {
      $message = "Assertion failed because expected '$expected' does not match actual '$actual'"
  }

  if ($expected -ne $actual)
  {
      throw $message
  }

  return $true
}

function Assert-Null
{
    param([object] $actual, [string] $message)

  if (!$message)
  {
      $message = "Assertion failed because the object is not null: " + $actual
  }

  if ($actual -ne $null)
  {
      throw $message
  }

  return $true
}

$md5 = New-Object -TypeName System.Security.Cryptography.MD5CryptoServiceProvider

# CreateFileTree "C:\temp\filetree" 3 4
function CreateFileTree
{
    param([string]$rootFolder, [int]$depth, [int]$width)
    $depth -= 1
    New-Item -ItemType Directory -Force -Path $rootFolder | Out-Null
    for($i = 0; $i -lt $width; $i++)
    {
        if($depth -gt 0)
        {
            $newRoot = $rootFolder + "\" + "testfolder_"+$i;
            CreateFileTree $newRoot $depth $width
        }
        $filepath = $rootFolder + "\" + "testfile_"+$i

        $out = new-object byte[] ($i*1024); 
        (new-object Random).NextBytes($out); 
        [IO.File]::WriteAllBytes($filepath, $out)
    }
}


function GetRandomContainerName
{
    return "container"+(Get-Date).Ticks
}

function GetRandomAccountName 
{
    return "sto"+ (Get-Random)
}


#  $md5 = New-Object -TypeName System.Security.Cryptography.MD5CryptoServiceProvider
function GetFileContentMD5
{
    param([string]$filePath)
    $hash = [System.BitConverter]::ToString($md5.ComputeHash([System.IO.File]::ReadAllBytes($filePath)))
    return $hash
}

function CompareFileBlobMD5
{    
    param([string]$filePath, [Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob]$blob)
    $hash1 = (GetFileContentMD5 $filePath)
    $hash2 =  [System.BitConverter]::ToString($blob.BlobProperties.ContentHash)
    $hash1 | should -be $hash2
}

function CompareFileFileMD5
{    
    param([string]$filePath, [Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageFile]$file)
    $hash1 = (GetFileContentMD5 $filePath)
    $hash2 =  [System.BitConverter]::ToString($file.FileProperties.ContentHash)
    $hash1 | should -be $hash2
}

function CompareFileMD5
{    
    param([string]$filePath, [string]$filePath2)
    (GetFileContentMD5 $filePath) | should -Be  (GetFileContentMD5 $filePath2)
}

function CompareBlobMD5
{    
    param([Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob]$blob, 
        [Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob]$blob2)
    [System.BitConverter]::ToString($blob.BlobProperties.ContentHash) | should -Be  [System.BitConverter]::ToString($blob2.BlobProperties.ContentHash)
}

function CompareFileBlobList
{    
    param([string[]]$filePaths, [Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob[]]$blobs)
    
    $filePaths.Count | should -Be $blobs.Count

    for ($i = 0 ; $i -lt $filePaths.Count; $i++)
    {
        # echo $i
        CompareFileBlobMD5 $filePaths[$i] $blobs[$i]
    }
}

function CompareFileFileList
{    
    param([string[]]$filePaths, [Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageFile[]]$files)
    
    $filePaths.Count | should -Be $files.Count

    for ($i = 0 ; $i -lt $filePaths.Count; $i++)
    {
        # echo $i
        CompareFileFileMD5 $filePaths[$i] $files[$i]
    }
}

function Upload_Download_FileTree
{
    param([Microsoft.WindowsAzure.Commands.Storage.AzureStorageContext]$context, [string]$rootFolder)

    $containerName = GetRandomContainerName

    New-AzStorageShare -Name $containerName -Context $context

    $sourceroot = $rootFolder + "\" + $containerName
    CreateFileTree $sourceroot 3 2

    $fileToUpload = ls -File -Path $sourceroot -Recurse
    $DirToCreate = ls -Directory -Path $sourceroot -Recurse

    foreach ($dir in $DirToCreate)
    {
        New-AzStorageDirectory -ShareName $containerName -Path $dir.FullName.ToLower().Replace($sourceroot.ToLower() + "\", "")  -Context $context 
    }

    $files = New-Object System.Collections.Generic.List[Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageFile]
    Foreach ($file in $fileToUpload)
    {
        $destfile = Set-AzStorageFileContent -shareName $containerName -Source $file.FullName -Path $file.FullName.ToLower().Replace($sourceroot.ToLower() + "\", "") -Force -Context $context -PassThru
        $files.Add($destfile)
    }
    CompareFileFileList $fileToUpload.FullName $files
    
    $destroot = $sourceroot+"dest"
    New-Item -ItemType Directory -Force -Path $destroot | Out-Null
    Foreach ($f in $files)
    {
        Get-AzStorageFileContent -shareName $containerName -path $f.Name -Destination  $destroot -Context $context -Force | Out-Null
    }
    $downloadedFiles = ls -File -Path $destroot -Recurse
    CompareFileFileList $fileToUpload.FullName $files


    #cleanup
    rm $sourceroot -Force -Recurse
    rm $destroot -Force -Recurse
    Remove-AzStorageShare -Name $containerName -Context $context -Force
}

function Upload_Download_BlobTree
{
    param([Microsoft.WindowsAzure.Commands.Storage.AzureStorageContext]$context, [string]$rootFolder, [string]$blobType = "Block")

    $containerName = GetRandomContainerName

    New-AzStorageContainer -Name $containerName -Context $context

    $sourceroot = $rootFolder + "\" + $containerName
    CreateFileTree $sourceroot 3 2

    $fileToUpload = ls -File -Path $sourceroot -Recurse

    $blobs = New-Object System.Collections.Generic.List[Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob]
    Foreach ($file in $fileToUpload)
    {
        $blob = Set-AzStorageBlobContent -Container $containerName -BlobType $blobType -File $file.FullName -Blob $file.FullName.ToLower().Replace($sourceroot.ToLower() + "\", "") -Context $context
        $blobs.Add($blob)
    }
    CompareFileBlobList $fileToUpload.FullName $blobs
    
    $destroot = $sourceroot+"dest"
    New-Item -ItemType Directory -Force -Path $destroot | Out-Null
    Foreach ($b in $blobs)
    {
        Get-AzStorageBlobContent -Container $containerName -Blob $b.Name -Destination $destroot -Context $context | Out-Null
    }
    $downloadedFiles = ls -File -Path $destroot -Recurse
    CompareFileBlobList $downloadedFiles.FullName $blobs


    #cleanup
    rm $sourceroot -Force -Recurse
    rm $destroot -Force -Recurse
    Remove-AzStorageContainer -Name $containerName -Context $context -Force
}

### for encrytion scope


function ValidBlob
{
    param([Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob]$b, [System.String] $scopeName)

    # check blob content is same as source
    $destblob = $b | Get-AzStorageBlobContent -Destination $localDestFile -Force
    $srchash = [System.BitConverter]::ToString($md5.ComputeHash([System.IO.File]::ReadAllBytes($localSrcFile)))
    $desthash = [System.BitConverter]::ToString($md5.ComputeHash([System.IO.File]::ReadAllBytes($localDestFile)))
    $srchash  | should -Be $desthash

    # check blob properties
    $properties = $b.BlobClient.GetProperties().Value
    "image/jpeg"  | should -Be $properties.ContentType
    2  | should -Be $properties.Metadata.Count
    $scopeName  | should -Be $properties.EncryptionScope
    $true  | should -Be ($properties.BlobType.ToString().ToLower() -eq $b.Name.ToString().ToLower())
}
    
function uploadblob
{
    param([Microsoft.WindowsAzure.Commands.Storage.AzureStorageContext]$context)

    $b = Set-AzStorageBlobContent  -Context $context -File $localSrcFile -Container $containerName_es -Blob block -BlobType Block  -EncryptionScope $scopeName1 `
    -Properties @{"ContentType" = "image/jpeg"} -Metadata @{"tag1" = "value1"; "tag2" = "value22" } -Force  
    ValidBlob $b $scopeName1
    # update block blob encryption scope
    $b = Copy-AzStorageBlob -Context $context -SrcContainer $containerName_es -SrcBlob block -DestContainer $containerName_es -EncryptionScope $scopeName2 -Force
    ValidBlob $b $scopeName2

    $b = Set-AzStorageBlobContent  -Context $context -File $localSrcFile -Container $containerName_es  -Blob page -BlobType Page -EncryptionScope $scopeName1 `
        -Properties @{"ContentType" = "image/jpeg"} -Metadata @{"tag1" = "value1"; "tag2" = "value22" } -Force 
    ValidBlob $b $scopeName1

    $b = Set-AzStorageBlobContent  -Context $context -File $localSrcFile -Container $containerName_es  -Blob append -BlobType Append -EncryptionScope $scopeName1 `
        -Properties @{"ContentType" = "image/jpeg"} -Metadata @{"tag1" = "value1"; "tag2" = "value22" } -Force 
    ValidBlob $b $scopeName1
}

## for set acl recusive

function ResetFileToFail
{
    # reset the file to make it failure in set acl resusive
 #   New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir1/file1 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
    New-AzDataLakeGen2Item -Context $ctx -FileSystem $filesystemName -Path dir0/dir2/file4 -Source $localSrcFile -Force  | Update-AzDataLakeGen2Item -Permission rwxr-x---
}

            
