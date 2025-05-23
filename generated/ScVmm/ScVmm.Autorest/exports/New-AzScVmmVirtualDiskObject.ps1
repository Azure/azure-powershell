
# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# Code generated by Microsoft (R) AutoRest Code Generator.Changes may cause incorrect behavior and will be lost if the code
# is regenerated.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create an in-memory object for VirtualDisk.
.Description
Create an in-memory object for VirtualDisk.
.Example
New-AzScVmmVirtualDiskObject -Name 'Disk-Obj-1' -lun 0 -bus 0 -VhdType 'Dynamic' -BusType 'SCSI' -StorageQoSPolicyName 'Qos-1'

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.VirtualDisk
.Link
https://learn.microsoft.com/powershell/module/Az.ScVmm/new-azscvmmvirtualdiskobject
#>
function New-AzScVmmVirtualDiskObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Models.VirtualDisk])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.Int32]
    # Gets or sets the disk bus.
    ${Bus},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.String]
    # Gets or sets the disk bus type.
    ${BusType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.PSArgumentCompleterAttribute("true", "false")]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.String]
    # Gets or sets a value indicating diff disk.
    ${CreateDiffDisk},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.String]
    # Gets or sets the disk id.
    ${DiskId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.Int32]
    # Gets or sets the disk total size.
    ${DiskSizeGb},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.Int32]
    # Gets or sets the disk lun.
    ${Lun},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.String]
    # Gets or sets the name of the disk.
    ${Name},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.String]
    # The ID of the QoS policy.
    ${StorageQoSPolicyId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.String]
    # The name of the policy.
    ${StorageQoSPolicyName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.String]
    # Gets or sets the disk id in the template.
    ${TemplateDiskId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Category('Body')]
    [System.String]
    # Gets or sets the disk vhd type.
    ${VhdType}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        
        $testPlayback = $false
        $PSBoundParameters['HttpPipelinePrepend'] | Foreach-Object { if ($_) { $testPlayback = $testPlayback -or ('Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.PipelineMock' -eq $_.Target.GetType().FullName -and 'Playback' -eq $_.Target.Mode) } }

        if ($null -eq [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PowerShellVersion) {
            [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PowerShellVersion = $PSVersionTable.PSVersion.ToString()
        }         
        $preTelemetryId = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId
        if ($preTelemetryId -eq '') {
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId =(New-Guid).ToString()
            [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.module]::Instance.Telemetry.Invoke('Create', $MyInvocation, $parameterSet, $PSCmdlet)
        } else {
            $internalCalledCmdlets = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets
            if ($internalCalledCmdlets -eq '') {
                [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets = $MyInvocation.MyCommand.Name
            } else {
                [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets += ',' + $MyInvocation.MyCommand.Name
            }
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = 'internal'
        }

        $mapping = @{
            __AllParameterSets = 'Az.ScVmm.custom\New-AzScVmmVirtualDiskObject';
        }
        $cmdInfo = Get-Command -Name $mapping[$parameterSet]
        [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.MessageAttributeHelper]::ProcessCustomAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
        if ($null -ne $MyInvocation.MyCommand -and [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PromptedPreviewMessageCmdlets -notcontains $MyInvocation.MyCommand.Name -and [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.MessageAttributeHelper]::ContainsPreviewAttribute($cmdInfo, $MyInvocation)){
            [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.Runtime.MessageAttributeHelper]::ProcessPreviewMessageAttributesAtRuntime($cmdInfo, $MyInvocation, $parameterSet, $PSCmdlet)
            [Microsoft.WindowsAzure.Commands.Utilities.Common.AzurePSCmdlet]::PromptedPreviewMessageCmdlets.Enqueue($MyInvocation.MyCommand.Name)
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        if ($wrappedCmd -eq $null) {
            $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Function)
        }
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }

    finally {
        $backupTelemetryId = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId
        $backupInternalCalledCmdlets = [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
    }

}
end {
    try {
        $steppablePipeline.End()

        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = $backupTelemetryId
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::InternalCalledCmdlets = $backupInternalCalledCmdlets
        if ($preTelemetryId -eq '') {
            [Microsoft.Azure.PowerShell.Cmdlets.ScVmm.module]::Instance.Telemetry.Invoke('Send', $MyInvocation, $parameterSet, $PSCmdlet)
            [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        }
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::TelemetryId = $preTelemetryId

    } catch {
        [Microsoft.WindowsAzure.Commands.Common.MetricHelper]::ClearTelemetryContext()
        throw
    }
} 
}
