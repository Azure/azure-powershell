# Sync doc from Azure/azure-powershell to MicrosoftDocs/azure-docs-powershell
[CmdletBinding()]
param(
    [Parameter()]
    [string]$RepoName = "azure-docs-powershell",
    [Parameter()]
    [string]$OrgName = "MicrosoftDocs",
    [Parameter()]
    [string]$BranchName,
    [Parameter()]
    [string]$WorkSpace,
    [Parameter()]
    [string]$GithubToken
)

# The absolute location of repos
$WorkSpace = (Resolve-Path (Join-Path $PSScriptRoot "../../")).Path
$RepoCloneLink = "https://github.com/$OrgName/$RepoName.git"
$Config = Get-Content (Join-Path $PSScriptRoot "../.azure-pipelines/SyncDocsConfig.json") | ConvertFrom-Json
$TmpFolder = Resolve-Path (New-Item -ItemType Directory -Path tmp)
# Get az version to match target folder
$AzVersion = (Import-PowerShellDataFile -Path "$PSScriptRoot\Az\Az.psd1").ModuleVersion

foreach ($SyncPath in $Config.SyncPath)
{
    Write-Host "Back up $SyncPath from main branch."
    Copy-Item -Path $SyncPath -Destination $TmpFolder -Recurse -Force
}

$SyncFile = Split-Path $SyncPath -Leaf

git config --global user.email "65331932+azure-powershell-bot@users.noreply.github.com"
git config --global user.name "azure-powershell-bot"

cd $WorkSpace
git clone $RepoCloneLink
cd $RepoName
git checkout -b $BranchName


foreach ($SyncPath in $Config.SyncPath)
{
    $Date = Get-Date -Format MM/dd/yyyy
    $Header = @"
---
description: Learn about upcoming breaking changes to the Azure Az PowerShell module
ms.custom: devx-track-azurepowershell
ms.date: $Date
ms.devlang: powershell
ms.service: azure-powershell
ms.topic: conceptual
title: Upcoming breaking changes in Azure PowerShell
---

"@

    $Header + (Get-Content $TmpFolder\$SyncFile -Raw) | Set-Content $TmpFolder\$SyncFile
    Copy-Item $TmpFolder\$SyncFile (Join-Path $WorkSpace $RepoName/docs-conceptual/azps-$AzVersion) -Force
    git add (Join-Path $WorkSpace $RepoName/docs-conceptual/azps-$AzVersion)
}

git commit -m "Sync upcoming breaking changes doc from azure-powershell repo."
git remote set-url origin "https://$GithubToken@github.com/$OrgName/$RepoName.git"
git push origin "$BranchName" --force
