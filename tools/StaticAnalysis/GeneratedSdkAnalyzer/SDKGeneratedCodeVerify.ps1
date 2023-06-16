$FilesChangedPaths = "$PSScriptRoot/../../../artifacts/FilesChanged.txt"

$errors = New-Object System.Collections.Generic.List[System.Object]
# All errors should be logged using this function, as it tracks the errors in
# the $errors array, which is used in the finally block of the script to determine
# the return code.
function LogError([string]$message) {
    Write-Host -f Red "error: $message"
    $errors.Add($message)
}

try{
    if ((Test-Path $FilesChangedPaths -PathType Leaf) -and $FilesChangedPaths.EndsWith(".txt")) {
        # Read Changedfiles and check if generted sdk code is updated.
        $FilesChanged = Get-Content $FilesChangedPaths | Where-Object { ($_ -match "^src\\.*\.Sdk\\.*Generated.*")}
        # Collect Sdk paths whose files under Generated folder change.
        $ChangedSdks = New-Object System.Collections.Generic.List[System.Object]
        foreach ($_ in $FilesChanged) {
            $ChangedSdks.Add($_.Substring(0,$_.IndexOf('.Sdk'))+'.Sdk')
        }
        # Remove duplicated Sdks.
        $ChangedSdks = $ChangedSdks | select -unique
    }
    else {
        Write-Error "Only accept .txt files as input."
    }
    Write-Host "Preparing Autorest..."
    autorest --reset
    autorest --use:@microsoft.azure/autorest.csharp@2.3.90
    foreach ($_ in $ChangedSdks) {
        # Direct to the Sdk directory
        $module = ($_ -split "\/|\\")[1]
        Write-Host "Directing to " "$PSScriptRoot/../../../$_"
        cd "$PSScriptRoot/../../../$_"

        # Regenerate the Sdk under Generated folder
        Write-Host (Test-Path -Path "README.md" -PathType Leaf)
        if( Test-Path -Path "README.md" -PathType Leaf){
            Write-Host "Re-generating SDK under Generated folder for $module..."
            autorest.cmd README.md --version=v2
        }
        else {
            LogError "No README file detected under $_."
        }
        # See if the code is completely the same as we generated
        $changes = git status ".\Generated" --porcelain
        if ($changes -ne $null){
            $changes = $changes.replace("  ", "`n")
            Write-Host "gitstatus: $changes"
            Write-Host "loging error..."
            LogError "Generated code for $module is not up to date.`n       You may need to rebase on the latest main, regenerate code accroding to README.md file under $_`n"
        }
    }
}
finally {
    Write-Host ""
    Write-Host "Summary:" 
    Write-Host ""
    Write-Host "  $($errors.Count) error(s):"
    Write-Host ""

    foreach ($err in $errors) {
        Write-Host -f Red "error : $err"
    }

    if ($errors) {
        exit 1
    }
}
