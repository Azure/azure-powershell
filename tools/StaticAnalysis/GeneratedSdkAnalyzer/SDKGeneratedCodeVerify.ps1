$FilesChangedPaths = "$PSScriptRoot/../../../artifacts/FilesChanged.txt"
# All errors should be logged using this function, as it tracks the errors in
# the $errors array, which is used in the finally block of the script to determine
# the return code.
[string[]] $errors = @()

function LogError([string]$message) {
    Write-Host -f Red "error: $message"
    $script:errors += $message
}
# Extract changed modules who did changes on generated  

$ErrorActionPreference = 'Stop'
# $Env:NODE_OPTIONS = "--max-old-space-size=8192"
Set-StrictMode -Version 1

try{
    # . (Join-Path $PSScriptRoot\..\common\scripts common.ps1)
    # When the input $MarkdownPaths is the path of txt file contained markdown paths
    Write-Host (Resolve-Path $FilesChangedPaths)
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
        Write-Error "Only accept .txt files as input."
    }
    foreach ($_ in $ChangedModules) {
        # Direct to the Sdk directory
        $module = ($_ -split "\/|\\")[1]
        Write-Host "Directing to " $PSScriptRoot/../../../$_
        cd $PSScriptRoot/../../../$_

        # Regenerate the Sdk under Generated folder
        Write-Host (Test-Path -Path "README.md" -PathType Leaf)
        if( Test-Path -Path "README.md" -PathType Leaf){
            Write-Host "Re-generating SDK under Generated folder for $module..."
            autorest --reset
            Write-Host "1"
            autorest --use:@microsoft.azure/autorest.csharp@2.3.90
            Write-Host "2"
            autorest.cmd README.md --version=v2
            Write-Host "3"
        }
        else {
            LogError "No README file detected."
        }

        Write-Host "git status"
        # See if the code is completely the same as we generated
        $changes = git status --porcelain
        if (!$changes -eq $null){
            LogError `
    "Generated code for $module is not up to date.`
        You may need to rebase on the latest main, `
        re-generate code accroding to README.md file under $_`
        "
        }
    }
}
finally {
    Write-Host ""
    Write-Host "Summary:"
    Write-Host ""
    Write-Host "   $($errors.Length) error(s)"
    Write-Host ""

    foreach ($err in $errors) {
        Write-Host -f Red "error : $err"
    }

    if ($errors) {
        exit 1
    }
}
