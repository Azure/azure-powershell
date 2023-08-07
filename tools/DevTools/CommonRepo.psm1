<#
  .Synopsis
  Connects azure-powershell repo to azure-powershell-common repo for debugging.

  .Description
  Connects azure-powershell repo to azure-powershell-common repo for debugging.

  .Parameter CommonRepoPath
  Path to the common repo. Relative or absolute.

  .Example
  Connect-CommonRepo -CommonRepoPath ../azure-powershell-common
#>
function Connect-CommonRepo {
  [CmdletBinding()]
  param(
    [Parameter(Mandatory)]
    [system.string]
    ${CommonRepoPath}
  )

  Write-Host "1/2 Adding common projects to sln and csproj"

  $CommonRepoPath = (Resolve-Path $CommonRepoPath).Path
  $CommonProjects = Get-ChildItem -Path "$CommonRepoPath/src/" -Include *.csproj -Exclude *.test.* -Recurse
  $CommonProjects = $CommonProjects.FullName


  $RepoRoot = "$PSScriptRoot/../.."

  Push-Location "$RepoRoot/src/Accounts"
  try {
    foreach ($csproj in $CommonProjects) {
      $csproj = [System.IO.Path]::GetFullPath($csproj)
      dotnet sln add $csproj
      if ($LASTEXITCODE -ne 0) {
        throw "Failed to add $csproj to Accounts.sln"
      }
      dotnet add ./Authentication/Authentication.csproj reference $csproj
      if ($LASTEXITCODE -ne 0) {
        throw "Failed to add $csproj to Authentication.csproj"
      }
    }

    dotnet add ./AssemblyLoading/AssemblyLoading.csproj reference "$CommonRepoPath/src/Common/Common.csproj"
    if ($LASTEXITCODE -ne 0) {
      throw "Failed to add Common.csproj to AssemblyLoading.csproj"
    }
  }
  finally {
    Pop-Location
  }


  Write-Host "2/2: Remove the dependency of those common projects from .targets file"

  $Patterns = @(
    '<PackageReference Include="Microsoft.Azure.PowerShell'
  )
  $TargetsFile = (Resolve-Path "$RepoRoot/tools/Common.Netcore.Dependencies.targets").Path
  (Get-Content $TargetsFile) | ForEach-Object { # https://stackoverflow.com/questions/10480673/find-and-replace-in-files-fails
    [string]$line = $_
    $IsMatch = $false
    foreach ($pattern in $patterns) {
      if ($line.IndexOf($pattern) -ne -1) {
        $IsMatch = $true
        break
      }
    }
    if ($IsMatch -and -not $line.StartsWith('<!--')) {
      return "<!--$line-->"
    }
    else {
      return $line
    }
  } | Set-Content $TargetsFile

  Write-Host "Done connecting both repositories."
}

function Disconnect-CommonRepo {
  Write-Host  "Please run the following commands to undo Connect-CommonRepo. Double check those files do not have wanted changes.
  git checkout -- ./src/Accounts/Accounts.sln
  git checkout -- ./src/Accounts/Accounts/Accounts.csproj
  git checkout -- ./src/Accounts/AssemblyLoading/AssemblyLoading.csproj
  git checkout -- ./src/Accounts/Authentication/Authentication.csproj
  git checkout -- ./tools/Common.Netcore.Dependencies.targets
  "
}

Export-ModuleMember -Function Connect-CommonRepo, Disconnect-CommonRepo
