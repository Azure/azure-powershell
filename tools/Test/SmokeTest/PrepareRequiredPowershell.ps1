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
        Write-Host "Installing latest PowerShell package using dotnet tool install command."
        dotnet tool install PowerShell
      }
      else {
        dotnet tool install PowerShell --version $requiredPsVersion 
      }
      if ([Version](dotnet --version) -gt [Version]"9.0.0") {
        if((dotnet tool list --local --format json | ConvertFrom-Json).data.where({ $_.packageId -eq 'powershell' }).Count -gt 0) {
          Write-Host "PowerShell $requiredPsVersion has been installed successfully."
        } else {
          throw "Failed to install PowerShell $requiredPsVersion. Please ensure the PS version is correct and target framework of the package is compatible with the OS platform. Please refer to https://www.nuget.org/packages/PowerShell for more details."
        }
      } else {
        Write-Host "Dotnet version is less than 9.0.0, skipping the verification of PowerShell installation"
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

# Remove Az.* modules
. "$PSScriptRoot/Common.ps1"
Remove-AzModules

# If all images update AzureRM to Az, below codes should be deleted.
# Remove AzureRM.* modules
Remove-AzModules "AzureRM"
# If all images update AzureRM to Az, above codes should be deleted.

# Prepare PowerShell as required
Install-PowerShell $requiredPsVersion
 
