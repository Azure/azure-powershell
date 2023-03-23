
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
    Create a in-memory object for ScriptSecureStringExecutionParameter
    .Description
    Create a in-memory object for ScriptSecureStringExecutionParameter

    .Outputs
    Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.ScriptSecureStringExecutionParameter
    .Link
    https://learn.microsoft.com/powershell/module/az.VMware/new-AzVMwareScriptSecureStringExecutionParameterObject
    #>
    function New-AzVMwareScriptSecureStringExecutionParameterObject {
        [OutputType('Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.ScriptSecureStringExecutionParameter')]
        [CmdletBinding(PositionalBinding=$false)]
        Param(
    
            [Parameter(HelpMessage="A secure value for the passed parameter, not to be stored in logs.")]
            [string]
            $SecureValue,
            [Parameter(Mandatory, HelpMessage="The parameter name.")]
            [string]
            $Name
        )

        process {
            $Object = [Microsoft.Azure.PowerShell.Cmdlets.VMware.Models.ScriptSecureStringExecutionParameter]::New()
    
            $Object.SecureValue = $SecureValue
            $Object.Name = $Name
            $Object.Type = "SecureValue"
            return $Object
        }
    }
    
