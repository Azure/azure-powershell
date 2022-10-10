
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
Registers Sql Migration Service on Integration Runtime.
.Description
Registers Sql Migration Service on Integration Runtime.
#>



function Register-AzDataMigrationIntegrationRuntime 
{
    [OutputType([System.Boolean])]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Description('Registers Sql Migration Service on Integration Runtime')]

    param(
        [Parameter(Mandatory, HelpMessage='AuthKey of Sql Migration Service')]
        [System.String]
        # AuthKey of Sql Migration Service to be registered
        ${AuthKey},

        [Parameter(HelpMessage='Path of SHIR msi')]
        [System.String]
        #Path of SHIR msi for installation.
        ${IntegrationRuntimePath},

        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Returns true when the command succeeds
        ${PassThru}
    )

    process 
    {
        # Entry point
        $OSPlatform = Get-OSName

        # Validate if OS is windows, as currently SHIR is only supported in Windows
        if(-not $OSPlatform.Contains("Windows"))
        {
            throw "This command cannot be run in non-windows environment"
            Break;
        }

        # Script must be run as admin
        If (-NOT ([Security.Principal.WindowsPrincipal] [Security.Principal.WindowsIdentity]::GetCurrent()).IsInRole(`
        [Security.Principal.WindowsBuiltInRole] "Administrator"))
        {
            throw "Failed: You do not have Administrator rights to run this command!`nPlease re-run this command as an Administrator!"
            Break
        }
        
        # Validate if given authKey is not empty
        $null = Validate-Input $PSBoundParameters.AuthKey
        # If SHIR MSI path is provided Perform installation of SHIR
        if($PSBoundParameters.ContainsKey("IntegrationRuntimePath"))
        {
            $path = $PSBoundParameters.IntegrationRuntimePath

            if ([string]::IsNullOrEmpty($path))
            {
                throw "Gateway path is not specified"
            }

            if (!(Test-Path -Path $path))
            {
                throw "Invalid gateway path: $path"
            }

            if($PSCmdlet.ShouldProcess('Local Machine','Installation of Microsoft Integration Runtime'))
            {
                Install-Gateway $path
            }
            
        }

         # Check if SHIR is Installed or not
        if(-Not (Check-WhetherGatewayInstalled("Microsoft Integration Runtime")))
        {
            throw "Failed: No installed Integration Runtime found!"
        }

        if($PSCmdlet.ShouldProcess('Microsoft Integration Runtime','Register AuthKey'))
        {
            # Register authkeys on SHIR
            $result = Register-IR $PSBoundParameters.AuthKey
            # Returns True, if command ran successfully and -PassThru parameter is specified
            if($PSBoundParameters.ContainsKey("PassThru"))
            {
                return $result;
            }
        }
        
    }
}
