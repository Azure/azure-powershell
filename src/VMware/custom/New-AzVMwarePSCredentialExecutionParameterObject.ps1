
    # ----------------------------------------------------------------------------------
    #
    # Copyright Microsoft Corporation
    # Licensed under the Apache License, Version 2.0 (the \"License\");
    # you may not use this file except in compliance with the License.
    # You may obtain a copy of the License at
    # http://www.apache.org/licenses/LICENSE-2.0
    # Unless required by applicable law or agreed to in writing, software
    # distributed under the License is distributed on an \"AS IS\" BASIS,
    # WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    # See the License for the specific language governing permissions and
    # limitations under the License.
    # ----------------------------------------------------------------------------------

    <#
    .Synopsis
    Create a in-memory object for PSCredentialExecutionParameter
    .Description
    Create a in-memory object for PSCredentialExecutionParameter

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.PSCredentialExecutionParameter
    .Link
    https://learn.microsoft.com/powershell/module/az.VMware/new-AzVMwarePSCredentialExecutionParameterObject
    #>
    function New-AzVMwarePSCredentialExecutionParameterObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.PSCredentialExecutionParameter')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(HelpMessage="password for login.")]
            [string]
            $Password,
            [Parameter(HelpMessage="username for login.")]
            [string]
            $Username,
            [Parameter(Mandatory, HelpMessage="The parameter name.")]
            [string]
            $Name
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.PSCredentialExecutionParameter]::New()
    
            $Object.Password = $Password
            $Object.Username = $Username
            $Object.Name = $Name
            $Object.Type = "Credential"
            return $Object
        }
    }
    
