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
Describes a unit of image customization
.Description
Describes a unit of image customization

.Link
https://docs.microsoft.com/en-us/powershell/module/az.imagebuilder/new-AzImageBuilderCustomizerObject
#>
function New-AzImageBuilderCustomizerObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer')]
    [CmdletBinding(PositionalBinding=$false, DefaultParameterSetName="ShellCustomizer")]
    Param(
        #region CustomizerCommon
        [Parameter(Mandatory, HelpMessage="Friendly Name to provide context on what this customization step does.")]
        [Alias('Name')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${CustomizerName},
        [Parameter(ParameterSetName='ShellCustomizer', HelpMessage="Array of shell commands to execute.")]
        [Parameter(ParameterSetName='PowerShellCustomizer', HelpMessage="Array of shell commands to execute.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string[]]
        ${Inline},
        [Parameter(ParameterSetName='PowerShellCustomizer', HelpMessage="URI of the shell script to be run for customizing. It can be a github link, SAS URI for Azure Storage, etc.")]
        [Parameter(ParameterSetName='ShellCustomizer', HelpMessage="URI of the shell script to be run for customizing. It can be a github link, SAS URI for Azure Storage, etc.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${ScriptUri},
        [Parameter(ParameterSetName='ShellCustomizer', HelpMessage="SHA256 checksum of the shell script provided in the scriptUri field.")]
        [Parameter(ParameterSetName='FileCustomizer', HelpMessage="SHA256 checksum of the shell script provided in the scriptUri field.")]
        [Parameter(ParameterSetName='PowerShellCustomizer', HelpMessage="SHA256 checksum of the shell script provided in the scriptUri field.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Sha256Checksum},
        #endregion CustomizerCommon
    
        #region FileCustomizer
        [Parameter(ParameterSetName='FileCustomizer', Mandatory, HelpMessage="Uploads files to VMs (Linux, Windows). Corresponds to Packer file provisioner.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${FileCustomizer},
        [Parameter(ParameterSetName='FileCustomizer', HelpMessage="The absolute path to a file (with nested directory structures already created) where the file (from sourceUri) will be uploaded to in the VM.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Destination},
        [Parameter(ParameterSetName='FileCustomizer', HelpMessage="The URI of the file to be uploaded for customizing the VM. It can be a github link, SAS URI for Azure Storage, etc.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${SourceUri},
        #endregion FileCustomizer
    
        #region ShellCustomizer
        [Parameter(ParameterSetName='ShellCustomizer', Mandatory, HelpMessage="Runs a shell script during the customization phase (Linux). Corresponds to Packer shell provisioner. Exactly one of 'scriptUri' or 'inline' can be specified.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${ShellCustomizer},
        #endregion ShellCustomizer
    
        #region PowerShellCustomizer
        [Parameter(ParameterSetName='PowerShellCustomizer', Mandatory, HelpMessage="Runs the specified PowerShell on the VM (Windows). Corresponds to Packer powershell provisioner. Exactly one of 'scriptUri' or 'inline' can be specified.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${PowerShellCustomizer},
        [Parameter(ParameterSetName='PowerShellCustomizer', HelpMessage="If specified, the PowerShell script will be run with elevated privileges.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Boolean]
        ${RunElevated},
        [Parameter(ParameterSetName='PowerShellCustomizer', HelpMessage="Valid exit codes for the PowerShell script. [Default: 0].")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [int[]]
        ${ValidExitCode},
        #endregion PowerShellCustomizer
    
        #region WindowsUpdateCustomizer
        [Parameter(ParameterSetName='WindowsUpdateCustomizer', Mandatory, HelpMessage="Installs Windows Updates. Corresponds to Packer Windows Update Provisioner (https://github.com/rgl/packer-provisioner-windows-update).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${WindowsUpdateCustomizer},
        [Parameter(ParameterSetName='WindowsUpdateCustomizer', HelpMessage="Array of filters to select updates to apply. Omit or specify empty array to use the default (no filter). Refer to above link for examples and detailed description of this field.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string[]]
        ${Filter},
        [Parameter(ParameterSetName='WindowsUpdateCustomizer', HelpMessage="Criteria to search updates. Omit or specify empty string to use the default (search all). Refer to above link for examples and detailed description of this field.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${SearchCriterion},
        [Parameter(ParameterSetName='WindowsUpdateCustomizer', HelpMessage="Maximum number of updates to apply at a time. Omit or specify 0 to use the default (1000).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [int]
        ${UpdateLimit},
        #endregion WindowsUpdateCustomizer
    
        #region RestartCustomizer
        [Parameter(ParameterSetName='RestartCustomizer', Mandatory, HelpMessage="Reboots a VM and waits for it to come back online (Windows). Corresponds to Packer windows-restart provisioner.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${RestartCustomizer},
        [Parameter(ParameterSetName='RestartCustomizer', HelpMessage="Command to check if restart succeeded [Default: ''].")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${RestartCheckCommand},
        [Parameter(ParameterSetName='RestartCustomizer', HelpMessage="Command to execute the restart [Default: 'shutdown /r /f /t 0 /c packer restart']")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${RestartCommand},
        [Parameter(ParameterSetName='RestartCustomizer', HelpMessage="Restart timeout specified as a string of magnitude and unit, e.g. '5m' (5 minutes) or '2h' (2 hours) [Default: '5m'].")]
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
        } elseif ($PSBoundParameters.ContainsKey('RestartCustomizer')) {
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