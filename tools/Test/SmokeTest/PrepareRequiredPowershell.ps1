[cmdletbinding()]
param(
  [string]
  [Parameter(Mandatory = $false, Position = 0)]
  $requiredPsVersion
)

function Install-PowerShell {
  param (
    [string]
    [Parameter(Mandatory = $false, Position = 0)]
    $requiredPsVersion
  )
  
  $windowsPowershellVersion = "5.1.14"

  # Prepare powershell
  if ($requiredPsVersion -ne $windowsPowershellVersion) {
    Write-Host "Installing PS $requiredPsVersion..."
    dotnet --version
    dotnet new tool-manifest --force
    if('latest' -eq $requiredPsVersion){
      dotnet tool install PowerShell
    }else {
      dotnet tool install PowerShell --version $requiredPsVersion 
    }
    dotnet tool list
  }else {
    Write-Host "Powershell", $requiredPsVersion, "has been installed"
  }

  # Update PowershellGet to the latest one
  Write-Host "Updating PowershellGet to lastest version"
  if ($requiredPsVersion -eq $windowsPowershellVersion) {
    Install-Module -Repository PSGallery -Name PowerShellGet -Scope CurrentUser -AllowClobber -Force
  }else{
    $command = "Install-Module -Repository PSGallery -Name PowerShellGet -Scope CurrentUser -AllowClobber -Force `
    Exit"
    dotnet tool run pwsh -c $command
  }
}

# Image "macOS-10.15" preinstalled Az modules
# Image "vs2017-win2016" and "ubuntu-18.04" preinstalled AzureRM modules. 

# Remove Az.* modules
. "$PSScriptRoot/Common.ps1"
Remove-AzModules

# If all images update AzureRM to Az, below codes should be deleted.
# Remove AzureRM.* modules
Remove-AzModules "AzureRM"
# If all images update AzureRM to Az, above codes should be deleted.

# Prepare PowerShell as required
Install-PowerShell $requiredPsVersion
 
