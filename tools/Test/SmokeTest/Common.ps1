function Get-ModulePreviousVersion{
  param(
  [string]
  [Parameter(Mandatory = $true, Position = 0)]
  $gallery,
  [string]
  [Parameter(Mandatory = $true, Position = 1)]
  $moduleName
  ) 
  if ($gallery -eq "LocalRepo") {
    $modules = Find-Module $moduleName -Repository PSGallery -AllVersions | Sort-Object {[System.Version]$_.Version} -Descending
    $previousVersion = $modules[0].Version
  } else {
    $modules = Find-Module $moduleName -Repository $gallery -AllVersions | Sort-Object {[System.Version]$_.Version} -Descending
    $previousVersion = $modules[1].Version
  }

  Write-Host "The previous version of $moduleName is:", $previousVersion
  return $previousVersion
}


function Remove-AzModules {
  param (
    [string]
    [PSDefaultValue(Help = "Az")]
    $ModuleName = "Az"
  )
  
  Write-Host "Removing $ModuleName modules..."
  $ModuleName = $ModuleName + ".*"
  $modules = Get-Module -Name $ModuleName -ListAvailable
  if ($modules) {
    $modules.Path | ForEach-Object { 
      $dirctory = $_ | Split-Path | Split-Path
      if (Test-Path $dirctory ) {
        Remove-Item -Path $dirctory -Recurse -Force
      }
    }

    # Check remove result
    $modules = Get-Module -Name $ModuleName -ListAvailable
    if ($modules) {
      throw "Remove $ModuleName modules failed."
    }
    else {
      Write-Host "$ModuleName modules removed."
    }
  }else{
    Write-Host "$ModuleName is not found."
  }
}