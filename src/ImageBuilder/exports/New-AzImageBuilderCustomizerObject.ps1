
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
.Example
PS C:\> New-AzImageBuilderCustomizerObject -WindowsUpdateCustomizer -Filter ("BrowseOnly", "IsInstalled") -SearchCriterion "BrowseOnly=0 and IsInstalled=0"  -UpdateLimit 100 -CustomizerName 'WindUpdate'

Name       Type          Filter                    SearchCriterion                UpdateLimit
----       ----          ------                    ---------------                -----------
WindUpdate WindowsUpdate {BrowseOnly, IsInstalled} BrowseOnly=0 and IsInstalled=0 100
.Example
PS C:\> New-AzImageBuilderCustomizerObject -FileCustomizer -CustomizerName 'filecus' -Destination 'c:\\buildArtifacts\\index.html' -SourceUri 'https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/index.html'

Name    Type Destination                    Sha256Checksum SourceUri
----    ---- -----------                    -------------- ---------
filecus File c:\\buildArtifacts\\index.html                https://github.com/danielsollondon/azvmimagebuilder/blob/master/quickquickstarts/exampleArtifacts/buildArtifacts/…

.Example
PS C:\> $inline = @("mkdir c:\\buildActions", "echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt")
PS C:\> New-AzImageBuilderCustomizerObject -PowerShellCustomizer -CustomizerName settingUpMgmtAgtPath -RunElevated $false -Inline $inline

Name                 Type       Inline                                                                                                  RunElevated ScriptUri Sha256Checksum
----                 ----       ------                                                                                                  ----------- --------- --------------
settingUpMgmtAgtPath PowerShell {mkdir c:\\buildActions, echo Azure-Image-Builder-Was-Here  > c:\\buildActions\\buildActionsOutput.txt} False

.Example
PS C:\> New-AzImageBuilderCustomizerObject -RestartCustomizer -CustomizerName 'restcus' -RestartCommand 'shutdown /f /r /t 0 /c \"packer restart\"' -RestartCheckCommand 'powershell -command "& {Write-Output "restarted."}"' -RestartTimeout '10m'

Name    Type           RestartCheckCommand                                 RestartCommand                            RestartTimeout
----    ----           -------------------                                 --------------                            --------------
restcus WindowsRestart powershell -command "& {Write-Output "restarted."}" shutdown /f /r /t 0 /c \"packer restart\" 10m
.Example
PS C:\> New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName downloadBuildArtifacts -ScriptUri "https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh" 

Name                   Type  Inline ScriptUri                                                                                                      Sha256Checksum
----                   ----  ------ ---------                                                                                                      --------------
downloadBuildArtifacts Shell        https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer
.Link
https://docs.microsoft.com/en-us/powershell/module/az.imagebuilder/new-AzImageBuilderCustomizerObject
#>
function New-AzImageBuilderCustomizerObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer])]
[CmdletBinding(DefaultParameterSetName='ShellCustomizer', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Alias('Name')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Friendly Name to provide context on what this customization step does.
    ${CustomizerName},

    [Parameter(ParameterSetName='ShellCustomizer', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Runs a shell script during the customization phase (Linux).
    # Corresponds to Packer shell provisioner.
    # Exactly one of 'scriptUri' or 'inline' can be specified.
    ${ShellCustomizer},

    [Parameter(ParameterSetName='ShellCustomizer')]
    [Parameter(ParameterSetName='PowerShellCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String[]]
    # Array of shell commands to execute.
    ${Inline},

    [Parameter(ParameterSetName='ShellCustomizer')]
    [Parameter(ParameterSetName='PowerShellCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # URI of the shell script to be run for customizing.
    # It can be a github link, SAS URI for Azure Storage, etc.
    ${ScriptUri},

    [Parameter(ParameterSetName='ShellCustomizer')]
    [Parameter(ParameterSetName='PowerShellCustomizer')]
    [Parameter(ParameterSetName='FileCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # SHA256 checksum of the shell script provided in the scriptUri field.
    ${Sha256Checksum},

    [Parameter(ParameterSetName='PowerShellCustomizer', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Runs the specified PowerShell on the VM (Windows).
    # Corresponds to Packer powershell provisioner.
    # Exactly one of 'scriptUri' or 'inline' can be specified.
    ${PowerShellCustomizer},

    [Parameter(ParameterSetName='PowerShellCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Boolean]
    # If specified, the PowerShell script will be run with elevated privileges.
    ${RunElevated},

    [Parameter(ParameterSetName='PowerShellCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Int32[]]
    # Valid exit codes for the PowerShell script.
    # [Default: 0].
    ${ValidExitCode},

    [Parameter(ParameterSetName='FileCustomizer', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Uploads files to VMs (Linux, Windows).
    # Corresponds to Packer file provisioner.
    ${FileCustomizer},

    [Parameter(ParameterSetName='FileCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # The absolute path to a file (with nested directory structures already created) where the file (from sourceUri) will be uploaded to in the VM.
    ${Destination},

    [Parameter(ParameterSetName='FileCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # The URI of the file to be uploaded for customizing the VM.
    # It can be a github link, SAS URI for Azure Storage, etc.
    ${SourceUri},

    [Parameter(ParameterSetName='WindowsUpdateCustomizer', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Installs Windows Updates.
    # Corresponds to Packer Windows Update Provisioner (https://github.com/rgl/packer-provisioner-windows-update).
    ${WindowsUpdateCustomizer},

    [Parameter(ParameterSetName='WindowsUpdateCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String[]]
    # Array of filters to select updates to apply.
    # Omit or specify empty array to use the default (no filter).
    # Refer to above link for examples and detailed description of this field.
    ${Filter},

    [Parameter(ParameterSetName='WindowsUpdateCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Criteria to search updates.
    # Omit or specify empty string to use the default (search all).
    # Refer to above link for examples and detailed description of this field.
    ${SearchCriterion},

    [Parameter(ParameterSetName='WindowsUpdateCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Int32]
    # Maximum number of updates to apply at a time.
    # Omit or specify 0 to use the default (1000).
    ${UpdateLimit},

    [Parameter(ParameterSetName='RestartCustomizer', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Reboots a VM and waits for it to come back online (Windows).
    # Corresponds to Packer windows-restart provisioner.
    ${RestartCustomizer},

    [Parameter(ParameterSetName='RestartCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Command to check if restart succeeded [Default: ''].
    ${RestartCheckCommand},

    [Parameter(ParameterSetName='RestartCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Command to execute the restart [Default: 'shutdown /r /f /t 0 /c packer restart']
    ${RestartCommand},

    [Parameter(ParameterSetName='RestartCustomizer')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Restart timeout specified as a string of magnitude and unit, e.g.
    # '5m' (5 minutes) or '2h' (2 hours) [Default: '5m'].
    ${RestartTimeout}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            ShellCustomizer = 'Az.ImageBuilder.custom\New-AzImageBuilderCustomizerObject';
            PowerShellCustomizer = 'Az.ImageBuilder.custom\New-AzImageBuilderCustomizerObject';
            FileCustomizer = 'Az.ImageBuilder.custom\New-AzImageBuilderCustomizerObject';
            WindowsUpdateCustomizer = 'Az.ImageBuilder.custom\New-AzImageBuilderCustomizerObject';
            RestartCustomizer = 'Az.ImageBuilder.custom\New-AzImageBuilderCustomizerObject';
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
