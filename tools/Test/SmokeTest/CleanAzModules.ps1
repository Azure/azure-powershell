# Remove Az.* modules
$modules = Get-Module -Name Az.* -ListAvailable
if ($modules) {
    Write-Host "Removing Az modules..."
    $modules.Path | ForEach-Object { 
        $dirctory = $_ | Split-Path | Split-Path
        if (Test-Path $dirctory ) {
            Remove-Item -Force -Recurse -Path "$dirctory\*"
            Remove-Item -Path $dirctory -Force
        }
    }
    Write-Host "Az modules removed."
}

# Check Az
$modules = Get-Module -Name Az.* -ListAvailable
if($modules){
    throw "Clean Az modules failed"
}
