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

function Install-AzModule{
    [OutputType([System.Collections.Hashtable])]
    [CmdletBinding(DefaultParameterSetName = 'All', PositionalBinding = $false)]
    param(
        [Parameter(HelpMessage = 'Maximum Az Version.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${MaximumVersion},

        [Parameter(HelpMessage = 'Minimum Az Version.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${MinimumVersion},

        [Parameter(HelpMessage = 'Required Az Version.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${RequiredVersion},

        [Parameter(HelpMessage = 'The Registered Repostory.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${Repository},

        [Parameter(HelpMessage = 'Remove given module installed previously.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${RemovePrevious},

        [Parameter(HelpMessage = 'Remove corresponding AzureRm modules.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${RemoveAzureRm},

        [Parameter(HelpMessage = 'Overrides warning messages about installation conflicts about existing commands on a computer. Overwrites existing commands that have the same name as commands being installed by a module.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${AllowClobber},

        [Parameter(HelpMessage = 'Installs modules and overrides warning messages about module installation conflicts. If a module with the same name already exists on the computer, Force allows for multiple versions to be installed. If there is an existing module with the same name and version, Force overwrites that version.')]
        [ValidateNotNullOrEmpty()]
        [Switch]
        ${Force},

        [Parameter(ParameterSetName = 'AllAndPreview', Mandatory, HelpMessage = 'Allow preview modules to be installed.')]
        [Parameter(ParameterSetName = 'ByNameAndPreview', Mandatory, HelpMessage = 'Allow preview modules to be installed.')]
        [ValidateNotNullOrEmpty()]
        [String]
        ${AllowPrerelease},

        [Parameter(ParameterSetName = 'ByName', Mandatory, HelpMessage = 'Az modules to install.')]
        [Parameter(ParameterSetName = 'ByNameAndPreview', Mandatory, HelpMessage = 'Az modules to install.')]
        [ValidateNotNullOrEmpty()]
        [String[]]
        ${Name}
    )
    
    begin {

    }

    process {

        $remove_azurerm = $null
        $remove_previous = $null
        $module_name = $null
        $required = ''
        $maximum = ''
        $minimum = ''

        if ($PSBoundParameters.ContainsKey('RemoveAzureRm')) {
            $remove_azurerm = $PSBoundParameters['RemoveAzureRm']
            $null = $PSBoundParameters.Remove('RemoveAzureRm')
        }

        if ($PSBoundParameters.ContainsKey('RemovePrevious')) {
            $remove_previous = $PSBoundParameters['RemovePrevious']
            $null = $PSBoundParameters.Remove('RemovePrevious')
        }

        if ($PSBoundParameters.ContainsKey('Name')) {
            $module_name = $PSBoundParameters['Name']
            $null = $PSBoundParameters.Remove('Name')
        }

        if ($PSBoundParameters.ContainsKey('MaximumVersion')) {
            $maximum = $PSBoundParameters['MaximumVersion']
            $null = $PSBoundParameters.Remove('MaximumVersion')
        }

        if ($PSBoundParameters.ContainsKey('MinimumVersion')) {
            $minimum = $PSBoundParameters['MinimumVersion']
            $null = $PSBoundParameters.Remove('MinimumVersion')
        }

        if ($PSBoundParameters.ContainsKey('RequiredVersion')) {
            $required = $PSBoundParameters['RequiredVersion']
            $null = $PSBoundParameters.Remove('RequiredVersion')
        }

        if ($PSCmdlet.ParameterSetName -eq 'ByName') {

            

        } elseif ($PSCmdlet.ParameterSetName -eq 'ByNameAndPreview') {

            # Install specified modules, preview if there are any

        } elseif ($PSCmdlet.ParameterSetName -eq 'AllAndPreview') {

            # Install Az and all preview modules

        } else {
            
            #Install Az package
            
        }


    }

    end {

    }
}

