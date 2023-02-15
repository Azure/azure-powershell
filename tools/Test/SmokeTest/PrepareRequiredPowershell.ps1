[cmdletbinding()]
param(
  [string]
  [Parameter(Mandatory = $false)]
  $requiredPsVersion,
  [string]
  [Parameter(Mandatory = $false)]
  $AgentOS,
  [string]
  [AllowEmptyString()]
  [Parameter(Mandatory = $false)]
  $PowerShellPath
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
    if ('preview' -eq $requiredPsVersion) {
      Write-Host "PowerShell preview package has been extracted to $PowerShellPath."
    } else {
      dotnet --version
      dotnet new tool-manifest --force
      if ( 'latest' -eq $requiredPsVersion ) {
        dotnet tool install PowerShell
      }
      else {
        dotnet tool install PowerShell --version $requiredPsVersion 
      }
      dotnet tool list
    }
    
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
    if ('preview' -eq $requiredPsVersion) {
      # Change the mode of 'pwsh' to 'rwxr-xr-x' to allow execution
      if ($AgentOS -ne "Windows_NT") { chmod 755 "$PowerShellPath/pwsh" }
      . "$PowerShellPath/pwsh" -c $command
    } else {
      dotnet tool run pwsh -c $command
    }
  }

  #Install ThreadJob for Windows PowerShell
  if ($requiredPsVersion -eq $windowsPowershellVersion) {
    Write-Host "Install ThreadJob for Windows PowerShell."
    $installedModule = Get-Module -ListAVailable -Name ThreadJob
    if ($installedModule -eq $null) {
      try {
        Install-Module -Name ThreadJob -Repository PSGallery -Scope CurrentUser -AllowClobber -Force
        Write-Host "Install ThreadJob successfully."
      }
      catch {
        Write-Host "Fail to install ThreadJob from PSGallery."
        Write-Host $_
      }
    }
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
 
