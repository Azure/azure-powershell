[CmdletBinding()]
param (
    [Parameter(Position=0)]
    [string] $FilesChangedPaths = "../../../artifacts/FilesChanged.txt"
)
# All errors should be logged using this function, as it tracks the errors in
# the $errors array, which is used in the finally block of the script to determine
# the return code.
function LogError([string]$message) {
    Write-Host -f Red "error: $message"
    $script:errors += $message
}
# Extract changed modules who did changes on generated  

$ErrorActionPreference = 'Stop'
# $Env:NODE_OPTIONS = "--max-old-space-size=8192"
Set-StrictMode -Version 1

# . (Join-Path $PSScriptRoot\..\common\scripts common.ps1)
# When the input $MarkdownPaths is the path of txt file contained markdown paths
    if ((Test-Path $FilesChangedPaths -PathType Leaf) -and $FilesChangedPaths.EndsWith(".txt")) {
        $FilesChanged = Get-Content $FilesChangedPaths | Where-Object { ($_ -match "^src\\.*\.Sdk\\.*Generated.*")}# -and (Test-Path $_) }
        # Write-Host "FilesChanged:" $FilesChanged
        $ChangedModules = New-Object System.Collections.Generic.List[System.Object]
        foreach ($_ in $FilesChanged) {
        $ChangedModules.Add($_.Substring(0,$_.IndexOf('.Sdk'))+'.Sdk')
        }
        $ChangedModules = $ChangedModules | select -unique
        # Write-Host $ChangedModules "c"
    }
    # When the input $MarkdownPaths is the path of a folder
    else {
        LogError "Only accept .txt files."
    }
    foreach ($_ in $ChangedModules) {
        # Filter the .md of overview in "\help\"
        Write-Host $_
    }