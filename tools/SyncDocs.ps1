[CmdletBinding()]
param(
    [Parameter()]
    [string]$RepoName = "azure-docs-powershell",
    [Parameter()]
    [string]$OrgName = "NoriZC", #"MicrosoftDocs",
    [Parameter()]
    [string]$BranchName,
    [Parameter()]
    [string]$WorkSpace,
    [Parameter()]
    [string]$GithubToken
)

ls
#The location of repos
$WorkSpace = Join-Path $PSScriptRoot "../../"
Write-Host "WorkSpace Location:" $WorkSpace

$RepoCloneLink = "https://github.com/$OrgName/$RepoName.git"
$Config = Get-Content (Join-Path $PSScriptRoot "../.azure-pipelines/SyncDocsConfig.json") | ConvertFrom-Json
$TmpFolder = New-Item -ItemType Directory -Path tmp

foreach ($SyncPath in $Config.SyncPath)
{
    Write-Host "Back up $SyncPath from main branch."
    Copy-Item -Path $SyncPath -Destination "$TmpFolder/$SyncPath" -Recurse -Force
}

git config --global user.email "norizhang@microsoft.com"  #"azurepowershell@ms.com"
git config --global user.name "NoriZC"  #"azurepowershell"

cd $WorkSpace
git clone $RepoCloneLink
cd $RepoName
git checkout -b "$BranchName" "origin/main"\


foreach ($SyncPath in $Config.SyncPath)
{
    Copy-Item $TmpFolder\$SyncPath $WorkSpace\$RepoName\docs-conceptual\azps-9.3.0 -Force
    git add $WorkSpace\$RepoName\docs-conceptual\azps-9.3.0
}

git commit -m "Sync upcoming breaking changes doc from azure-powershell to $RepoName"
git remote set-url origin "https://$GithubToken@github.com/$OrgName/$RepoName.git"
git push origin "$BranchName" --force
