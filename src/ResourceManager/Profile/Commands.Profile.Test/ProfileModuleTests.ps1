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

function Verify-TestRepoDeleted
{
    $createdRepo = Get-PSRepository -Name "ProfileModuleTest" -ErrorAction Ignore
    if($createdRepo)
    {
        Unregister-PSRepository -Name "ProfileModuleTest"
    }
}

<#
.SYNOPSIS
Tests warning gets printed on incompatible modules with profile
#>
function Test-LoadProfileModule
{
    $testPassed = $false
    # Clean environment
    Verify-TestRepoDeleted

    # Push current profile module
    Get-PackageProvider -Name NuGet -ForceBootstrap
    $global:pushedProfileModule = $(Get-Module AzureRM.Profile).Path 
    Remove-Module AzureRM.Profile
    try {
        Register-PSRepository -Name "ProfileModuleTest" -SourceLocation (Resolve-Path "$TestOutputRoot\FakeModuleRepo").Path -InstallationPolicy Trusted
        try {
            Install-Module AzureRM.ApiManagement -Scope CurrentUser -Repository ProfileModuleTest -RequiredVersion 998.9.8
            $global:buffer = Import-Module $global:pushedProfileModule 2>&1 3>&1 | Out-String
            Write-Warning $global:buffer
            Assert-True { $global:buffer -Like "*AzureRM.ApiManagement 998.9.8 is not compatible with AzureRM.Profile*" }
            $testPassed = $true
        } catch [system.exception] {
            Write-Error $_
        } finally {
            Uninstall-Module AzureRM.ApiManagement -ErrorAction Ignore
            Uninstall-Module AzureRM.Profile -ErrorAction Ignore
        }
    } catch [system.exception] {
        Write-Error $_
    } finally {
        Verify-TestRepoDeleted
    }
    Assert-True { $testPassed -eq $true } "testPassed = $testPassed"
}