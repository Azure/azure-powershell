$files = Get-ChildItem -Path $PSScriptRoot/../../src/ -Filter "*.cs" -Recurse

foreach ($file in $files) {
    $content = Get-Content $file.FullName
    $newContent = @()
    $ignoreBlock = $false
    $haveChanges = $false

    foreach ($line in $content) {
        if ($ignoreBlock) {
            if ($line.TrimEnd()[-1] -eq ']') {
                $ignoreBlock = $false
            }
        }
        elseif ($line -match '^\s*\[CmdletDeprecation' -or
                    $line -match '^\s*\[GenericBreakingChange' -or
                    $line -match '^\s*\[CmdletOutputBreakingChange' -or
                    $line -match '^\s*\[CmdletParameterBreakingChange') {
            if ($line.TrimEnd()[-1] -eq ']') {
                $ignoreBlock = $false
            } else {
                $ignoreBlock = $true
            }
            $haveChanges = $true
        }
        else {
            $newContent += $line
        }
    }
    if ($haveChanges) {
        Write-Host "Removing deprecation attributes from $file"
        $newContent | Set-Content $file.FullName
    }
}
