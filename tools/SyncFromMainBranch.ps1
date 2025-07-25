[CmdletBinding()]
param(
    [Parameter()]
    [string]$BranchName,
    [Parameter()]
    [string]$GithubToken,
	[Parameter()]
    [array]$SyncPaths,
	[Parameter()]
    [array]$UnSyncPaths
)

$TmpFolder = New-Item -ItemType Directory -Path tmp

foreach ($SyncPath in $SyncPaths)
{
    Write-Host "Back up $SyncPath from main branch."
    Copy-Item -Path $SyncPath -Destination "$TmpFolder/$SyncPath" -Recurse -Force
}

git config --global user.email "azurepowershell@ms.com"
git config --global user.name "azurepowershell"
git checkout -b "syncToolsFolder/$BranchName" "origin/$BranchName"

# There are some files or folders who need to be keeped in target branch.
foreach ($UnSyncPath in $UnSyncPaths)
{
    if (Test-Path -Path $UnSyncPath)
    {
        Write-Host "Back up $UnSyncPath from $BranchName branch."
        $ParentFolder = Split-Path -path $UnSyncPath -Parent
        Copy-Item -Path $UnSyncPath -Destination "$TmpFolder/$ParentFolder" -Recurse -Force
    }
}

foreach ($SyncPath in $SyncPaths)
{
    if (Test-Path -Path $SyncPath) {
        Remove-Item -Path $SyncPath -Recurse -Force
    }
    Copy-Item -Path "$TmpFolder/$SyncPath" -Destination $SyncPath -Recurse -Force
    git add $SyncPath
}

git commit -m "Sync tools folder from main branch to $BranchName branch"
git remote set-url origin "https://$GithubToken@github.com/Azure/azure-powershell.git"
git push origin "syncToolsFolder/$BranchName" --force
