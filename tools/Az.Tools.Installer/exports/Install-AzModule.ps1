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

function Install-AzModule {

<#
    .Synopsis
        Installs Azure PowerShell modules.

    .Description
        Installs Azure PowerShell modules.

    .Example
        C:\PS> Install-AzModule -Repository PSGallery -RemoveAzureRm -RequiredAzVersion 6.3 -UseExactAccountVersion -Confirm:$false -Debug

        C:\PS> Install-AzModule -Name Storage,Compute,Network,Blockchain -Repository PSGallery -AllowPrerelease -Confirm:$false -Debug
#>

    [OutputType([PSCustomObject[]])]
    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false, SupportsShouldProcess)]
    param(
        [Parameter(ParameterSetName = 'Default', HelpMessage = 'Az modules to install.', ValueFromPipelineByPropertyName = $true, Position = 0)]
        [string[]]
        ${Name},

        [Parameter(ParameterSetName = 'Default', HelpMessage = 'Required Az Version.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${RequiredAzVersion},

        [Parameter(ParameterSetName = 'Default', HelpMessage = 'The Registered Repostory.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository},

        [Parameter(ParameterSetName = 'Default', HelpMessage = 'Allow preview modules to be installed.')]
        [Switch]
        ${AllowPrerelease},

        [Parameter(ParameterSetName = 'Default', HelpMessage = 'Use exact account version.')]
        [Switch]
        ${UseExactAccountVersion},

        [Parameter(ParameterSetName = 'ByPackagePath', Mandatory, Position = 0)]
        [ValidateNotNullOrEmpty()]
        [string]
        ${PackagePath},

        [Parameter(HelpMessage = 'Scope to install modules. Accepted values: CurrentUser, AllUser.')]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        ${Scope},

        [Parameter(HelpMessage = 'Remove given module installed previously.')]
        [Switch]
        ${RemovePrevious},

        [Parameter(HelpMessage = 'Remove all AzureRm modules.')]
        [Switch]
        ${RemoveAzureRm},

        [Parameter(HelpMessage = 'Installs modules and overrides warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [Switch]
        ${Force}
    )

    process {
        $cmdStarted = Get-Date
        $Invoker = $MyInvocation.MyCommand
        $ppsedition = $PSVersionTable.PSEdition
        Write-Debug "Powershell $ppsedition Version $($PSVersionTable.PSVersion)"

        if ($PSCmdlet.ParameterSetName -eq 'Default') {
            Install-AzModule_Default @PSBoundParameters
        }
        else {
            Install-AzModule_ByPackagePath @PSBoundParameters
        }

        <#
        Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
            -IsSuccess $true `
            -StartDateTime $cmdStarted `
            -Duration ((Get-Date) - $cmdStarted)
        #>
    }
}
