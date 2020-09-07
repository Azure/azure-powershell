# Remove Az.* modules
$modules = Get-Module -Name Az.* -ListAvailable
if ($modules) {
    Write-Host "Removing Az modules..."
    $modules.Path | ForEach-Object { 
        $dirctory = $_ | Split-Path | Split-Path
        if (Test-Path $dirctory ) {
            Remove-Item –path $dirctory –recurse -force
        }
    }
    Write-Host "Az modules removed."
}

# Check Az
Get-Module -Name Az.* -ListAvailable