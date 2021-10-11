[CmdletBinding()]
param(
    [Parameter()]
    [string]$BranchName,
    [Parameter()]
    [string]$GithubToken
)

$Config = Get-Content (Join-Path $PSScriptRoot "config.json") | ConvertFrom-Json
$TmpFolder = New-Item -ItemType Directory -Path tmp

foreach ($SyncPath in $Config.SyncPath)
{
    Write-Host "Back up $SyncPath from main branch."
    Copy-Item -Path $SyncPath -Destination "$TmpFolder/$SyncPath" -Recurse
}

# git config --global user.email "azurepowershell@ms.com"
# git config --global user.name "azurepowershell"
# git checkout -b "syncToolsFolder-$BranchName" "origin/$BranchName"

foreach ($UnSyncPath in $Config.UnSyncPath)
{
    Write-Host "Back up $UnSyncPath from $BranchName branch."
    Copy-Item -Path $UnSyncPath -Destination "$TmpFolder/$UnSyncPath" -Recurse -Force
}

foreach ($SyncPath in $Config.SyncPath)
{
    Remove-Item -Path $SyncPath -Recurse
    Copy-Item -Path "$TmpFolder/$UnSyncPath" -Destination $SyncPath -Recurse
    # git add $SyncPath
}

# git commit -m "Sync tools folder from main branch to $BranchName branch"
# git remote set-url origin "https://$GithubToken@github.com/Azure/azure-powershell.git"
# git push origin "syncToolsFolder-$BranchName" --force