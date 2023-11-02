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
        Install Azure PowerShell modules.

    .Description
        Install Azure PowerShell modules.

    .Example
        C:\PS> Install-AzModule -Repository PSGallery
    .Example
        C:\PS> Install-AzModule Storage,Compute,Network -Repository PSGallery -AllowPrerelease
    .Example
        C:\PS> Install-AzModule -Path https://my.repo.com/Az.Accounts.2.5.0.nupkg
#>

    [OutputType([PSCustomObject[]])]
    [CmdletBinding(DefaultParameterSetName = 'Default', PositionalBinding = $false, SupportsShouldProcess)]
    param(
        [Parameter(ParameterSetName = 'Default', HelpMessage = 'Az modules to install. Can be the names without Az. prefix', ValueFromPipelineByPropertyName = $true, Position = 0)]
        [string[]]
        ${Name},

        [Parameter(ParameterSetName = 'Default', HelpMessage = 'Required Az Version.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${RequiredAzVersion},

        [Parameter(ParameterSetName = 'Default', HelpMessage = 'The Registered Repository to install module from. If only one repository is registered in PowerShell, Install-AzModule will use it. If more than one, please specify the Repository.')]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Repository},

        [Parameter(ParameterSetName = 'Default', HelpMessage = 'Allow preview modules to be installed.')]
        [Switch]
        ${AllowPrerelease},

        [Parameter(ParameterSetName = 'Default', HelpMessage = 'Use the exact Az.Accounts version that meet the mininum requirement from the Az modules to install.')]
        [Switch]
        ${UseExactAccountVersion},

        [Parameter(ParameterSetName = 'ByPath', Mandatory, HelpMessage = "The url or local path of a nuget package to install the module from.")]
        [ValidateNotNullOrEmpty()]
        [string]
        ${Path},

        [Parameter(HelpMessage = 'Scope to install modules. Default value is `CurrentUser` for all the Powershell platforms. Accepted values: CurrentUser, AllUser.')]
        [ValidateSet('CurrentUser', 'AllUsers')]
        [string]
        ${Scope},

        [Parameter(HelpMessage = 'Remove the module specified installed previously.')]
        [Switch]
        ${RemovePrevious},

        [Parameter(HelpMessage = 'Remove all Azure and AzureRm modules.')]
        [Switch]
        ${RemoveAzureRm},

        [Parameter(HelpMessage = 'Installs modules and overrides the confirmation messages of each step.')]
        [Switch]
        ${Force}
    )

    process {
        $cmdStarted = Get-Date
        $Invoker = $MyInvocation.MyCommand
        $ppsedition = $PSVersionTable.PSEdition
        Write-Debug "Powershell $ppsedition Version $($PSVersionTable.PSVersion)"
        $IsSuccess = $false
        $errorRecords = @()

        try {
            $Invoker = $MyInvocation.MyCommand
            if ($PSCmdlet.ParameterSetName -eq 'Default') {
                Install-AzModule_Default @PSBoundParameters -Invoker $Invoker
            }
            else {
                Install-AzModule_ByPath @PSBoundParameters -Invoker $Invoker
            }
            $IsSuccess = $true
        }
        catch
        {
            Write-Error $PSItem.ToString() -ErrorVariable +errorRecords
            throw $PSItem
        }
        finally {
            if ($errorRecords.Count -gt 0)
            {
                Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
                -IsSuccess $false `
                -StartDateTime $cmdStarted `
                -Duration ((Get-Date) - $cmdStarted)
            }
            else
            {
                Send-PageViewTelemetry -SourcePSCmdlet $PSCmdlet `
                -IsSuccess $IsSuccess `
                -StartDateTime $cmdStarted `
                -Duration ((Get-Date) - $cmdStarted)
            }
        }
    }
}
