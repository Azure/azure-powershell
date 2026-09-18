# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
    .Synopsis
    Connects azure-powershell repo to azure-powershell-common repo for debugging.

    .Description
    Connects azure-powershell repo to azure-powershell-common repo for debugging.

    .Parameter CommonRepoPath
    Path to the common repo. Relative or absolute.

    .Example
    Connect-DevCommonRepo -CommonRepoPath ../azure-powershell-common
#>
function Connect-DevCommonRepo {
    [CmdletBinding()]
    param()

    $context = Get-DevContext

    Write-Host "1/2 Adding common projects to sln and csproj"

    $CommonRepoPath = $context.AzurePowerShellCommonRepositoryRoot
    $CommonProjects = Get-ChildItem -Path "$CommonRepoPath/src/" -Include *.csproj -Exclude *.test.* -Recurse
    $CommonProjects = $CommonProjects.FullName


    $RepoRoot = $Context.AzurePowerShellRepositoryRoot

    Push-Location "$RepoRoot/src/Accounts"
    try {
        foreach ($csproj in $CommonProjects) {
            $csproj = [System.IO.Path]::GetFullPath($csproj)
            dotnet sln add $csproj
            if ($LASTEXITCODE -ne 0) {
                throw "Failed to add $csproj to Accounts.sln"
            }
            <#
                known common project references:
                    Authentication.csproj -> Authentication.Abstractions, ResourceManager
                    Accounts.csproj -> Authentication.Abstractions, ResourceManager, Common
                    Accounts.Test.csproj -> Authentication.Abstractions, ResourceManager, Common
                    TestFx.csproj -> Graph.Rbac.csproj
                    AssemblyLoading.csproj -> Common
            #>
            # add all common projects to Authentication.csproj because it will be referenced by most Az projects
            dotnet add ./Authentication/Authentication.csproj reference $csproj
            if ($LASTEXITCODE -ne 0) {
                throw "Failed to add $csproj to Authentication.csproj"
            }
        }

        # AssemblyLoading.csproj references Common.csproj and does not reference Authentication.csproj
        dotnet add ./AssemblyLoading/AssemblyLoading.csproj reference "$CommonRepoPath/src/Common/Common.csproj"
        if ($LASTEXITCODE -ne 0) {
            throw "Failed to add Common.csproj to AssemblyLoading.csproj"
        }

        # add common project references below for csproj which does not reference Authentication.csproj
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

function Disconnect-DevCommonRepo {
    Write-Host  "Please run the following commands to undo Connect-DevCommonRepo. Double check those files do not have wanted changes.
    git checkout -- ./src/Accounts/Accounts.sln
    git checkout -- ./src/Accounts/AssemblyLoading/AssemblyLoading.csproj
    git checkout -- ./src/Accounts/Authentication/Authentication.csproj
    git checkout -- ./tools/Common.Netcore.Dependencies.targets
    "
}

Export-ModuleMember -Function Connect-DevCommonRepo, Disconnect-DevCommonRepo
