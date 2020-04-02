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

function New-AzImageBuilderCustomizer {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    Param(
        #region CustomizerCommon
        [Parameter(Mandatory)]
        [Alias('Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${CustomizerName},
        [Parameter(ParameterSetName='ShellCustomizer')]
        [Parameter(ParameterSetName='PowerShellCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string[]]
        ${Inline},
        [Parameter(ParameterSetName='PowerShellCustomizer')]
        [Parameter(ParameterSetName='ShellCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${ScriptUri},
        [Parameter(ParameterSetName='ShellCustomizer', Mandatory)]
        [Parameter(ParameterSetName='FileCustomizer', Mandatory)]
        [Parameter(ParameterSetName='PowerShellCustomizer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Sha256Checksum},
        #endregion CustomizerCommon
    
        #region FileCustomizer
        [Parameter(ParameterSetName='FileCustomizer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${FileCustomizer},
        [Parameter(ParameterSetName='FileCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Destination},
        [Parameter(ParameterSetName='FileCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${SourceUri},
        #endregion FileCustomizer
    
        #region ShellCustomizer
        [Parameter(ParameterSetName='ShellCustomizer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${ShellCustomizer},
        #endregion ShellCustomizer
    
        #region PowerShellCustomizer
        [Parameter(ParameterSetName='PowerShellCustomizer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${PowerShellCustomizer},
        [Parameter(ParameterSetName='PowerShellCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Boolean]
        ${RunElevated},
        [Parameter(ParameterSetName='PowerShellCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [int[]]
        ${ValidExitCode},
        #endregion PowerShellCustomizer
    
        #region WindowsUpdateCustomizer
        [Parameter(ParameterSetName='WindowsUpdateCustomizer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${WindowsUpdateCustomizer},
        [Parameter(ParameterSetName='WindowsUpdateCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string[]]
        ${Filter},
        [Parameter(ParameterSetName='WindowsUpdateCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${SearchCriterion},
        [Parameter(ParameterSetName='WindowsUpdateCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [int]
        ${UpdateLimit},
        #endregion WindowsUpdateCustomizer
    
        #region RestartCustomizer
        [Parameter(ParameterSetName='RestartCustomizer', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${RestartCustomizer},
        [Parameter(ParameterSetName='RestartCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${RestartCheckCommand},
        [Parameter(ParameterSetName='RestartCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${RestartCommand},
        [Parameter(ParameterSetName='RestartCustomizer')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${RestartTimeout}
        #endregion RestartCustomizer
    )
    
    process {
        if ($PSBoundParameters.ContainsKey('PowerShellCustomizer')) {
            $Customizer = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplatePowerShellCustomizer]::New()
            $Customizer.Type = "PowerShell"
            $Customizer.Inline = $Inline
            $Customizer.RunElevated = $RunElevated
            $Customizer.ScriptUri = $ScriptUri
            $Customizer.Sha256Checksum = $Sha256Checksum
            $Customizer.ValidExitCode = $ValidExitCode
        } elseif ($PSBoundParameters.ContainsKey('WindowsRestartCustomizer')) {
            $Customizer = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateRestartCustomizer]::New()
            $Customizer.Type = "WindowsRestart"
            $Customizer.RestartCheckCommand = $RestartCheckCommand
            $Customizer.RestartCommand = $RestartCommand
            $Customizer.RestartTimeout = $RestartTimeout
        } elseif ($PSBoundParameters.ContainsKey('WindowsUpdateCustomizer')) {
            $Customizer = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateWindowsUpdateCustomizer]::New()
            $Customizer.Type = "WindowsUpdate"
            $Customizer.Filter = $Filter
            $Customizer.SearchCriterion = $SearchCriterion
            $Customizer.UpdateLimit = $UpdateLimit
        } elseif ($PSBoundParameters.ContainsKey('ShellCustomizer')) {
            $Customizer = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateShellCustomizer]::New()
            $Customizer.Type = "Shell"
            $Customizer.Inline = $Inline
            $Customizer.ScriptUri = $ScriptUri
            $Customizer.Sha256Checksum = $Sha256Checksum
        } elseif ($PSBoundParameters.ContainsKey('FileCustomizer')) {
            $Customizer = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateFileCustomizer]::New()
            $Customizer.Type = "File"
            $Customizer.Destination = $Destination
            $Customizer.Sha256Checksum = $Sha256Checksum
            $Customizer.SourceUri = $SourceUri
        }
        $Customizer.Name = $CustomizerName

        return $Customizer
    }
}