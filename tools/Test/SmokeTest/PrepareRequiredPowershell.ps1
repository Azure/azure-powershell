[cmdletbinding()]
param(
  [string]
  [Parameter(Mandatory = $true, Position = 0)]
  $requiredPsVersion
)

function Remove-AzModules {
  param (
    [string]
    [PSDefaultValue(Help = "Az")]
    $ModuleName = "Az"
  )

  $ModuleName = $ModuleName + ".*"
  $modules = Get-Module -Name $ModuleName -ListAvailable
  if ($modules) {
    Write-Host "Removing $ModuleName modules..."
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
  }
}

function Install-PowerShell {
  param (
    [string]
    [Parameter(Mandatory = $true, Position = 0)]
    $requiredPsVersion
  )
  
  $preinstalledPsVersion = $PSVersionTable.PSVersion.ToString()
  Write-Host "The preinstalled version of Powershell is", $preinstalledPsVersion

  # Prepare powershell
  if ($requiredPsVersion -ne $preinstalledPsVersion) {
    Write-Host "Installing PS $requiredPsVersion..."
    dotnet --version
    dotnet new tool-manifest --force
    dotnet tool install PowerShell --version $requiredPsVersion 
    dotnet tool list
  }  

  # Update PowershellGet to the latest one
  if ($requiredPsVersion -ne $preinstalledPsVersion) {
    $command = "Install-Module -Repository PSGallery -Name PowerShellGet -Scope CurrentUser -Force `
    Exit"
    dotnet tool run pwsh -c $command
  }else{
    Install-Module -Repository PSGallery -Name PowerShellGet -Scope CurrentUser -Force
  }
}

# Image "macOS-10.15" preinstalled Az modules
# Image "vs2017-win2016" and "ubuntu-18.04" preinstalled AzureRM modules. 

# Remove Az.* modules
Remove-AzModules

# If all images update AzureRM to Az, below codes should be deleted.
# Remove AzureRM.* modules
Remove-AzModules "AzureRM"
# If all images update AzureRM to Az, above codes should be deleted.

# Prepare PowerShell as required
Install-PowerShell $requiredPsVersion
 