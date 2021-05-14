
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
Create a in-memory object for Container
.Description
Create a in-memory object for Container
.Example
PS C:\> New-AzContainerInstanceObject -Name "test-container" -Image alpine -RequestCpu 1 -RequestMemoryInGb 1.5

Name
----
test-container
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Container
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

ENVIRONMENTVARIABLE <IEnvironmentVariable[]>: The environment variables to set in the container instance.
  Name <String>: The name of the environment variable.
  [SecureValue <String>]: The value of the secure environment variable.
  [Value <String>]: The value of the environment variable.

PORT <IContainerPort[]>: The exposed ports on the container instance.
  Port <Int32>: The port number exposed within the container group.
  [Protocol <ContainerNetworkProtocol?>]: The protocol associated with the port.

VOLUMEMOUNT <IVolumeMount[]>: The volume mounts available to the container instance.
  MountPath <String>: The path within the container where the volume should be mounted. Must not contain colon (:).
  Name <String>: The name of the volume mount.
  [ReadOnly <Boolean?>]: The flag indicating whether the volume mount is read-only.
.Link
https://docs.microsoft.com/powershell/module//az.ContainerInstance/new-AzContainerInstanceObject
#>
function New-AzContainerInstanceObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Container])]
[CmdletBinding(PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The name of the image used to create the container instance.
    ${Image},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The user-provided name of the container instance.
    ${Name},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String[]]
    # The commands to execute within the container instance in exec form.
    ${Command},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[]]
    # The environment variables to set in the container instance.
    # To construct, see NOTES section for ENVIRONMENTVARIABLE properties and create a hash table.
    ${EnvironmentVariable},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Double]
    # The CPU limit of this container instance.
    ${LimitCpu},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Double]
    # The memory limit in GB of this container instance.
    ${LimitMemoryInGb},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The count of the GPU resource.
    ${LimitsGpuCount},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku])]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The SKU of the GPU resource.
    ${LimitsGpuSku},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String[]]
    # The commands to execute within the container.
    ${LivenessProbeExecCommand},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The failure threshold.
    ${LivenessProbeFailureThreshold},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The header name.
    ${LivenessProbeHttpGetHttpHeadersName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The header value.
    ${LivenessProbeHttpGetHttpHeadersValue},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The path to probe.
    ${LivenessProbeHttpGetPath},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The port number to probe.
    ${LivenessProbeHttpGetPort},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme])]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The scheme.
    ${LivenessProbeHttpGetScheme},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The initial delay seconds.
    ${LivenessProbeInitialDelaySecond},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The period seconds.
    ${LivenessProbePeriodSecond},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The success threshold.
    ${LivenessProbeSuccessThreshold},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The timeout seconds.
    ${LivenessProbeTimeoutSecond},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPort[]]
    # The exposed ports on the container instance.
    # To construct, see NOTES section for PORT properties and create a hash table.
    ${Port},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String[]]
    # The commands to execute within the container.
    ${ReadinessProbeExecCommand},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The failure threshold.
    ${ReadinessProbeFailureThreshold},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The header name.
    ${ReadinessProbeHttpGetHttpHeadersName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The header value.
    ${ReadinessProbeHttpGetHttpHeadersValue},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The path to probe.
    ${ReadinessProbeHttpGetPath},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The port number to probe.
    ${ReadinessProbeHttpGetPort},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme])]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The scheme.
    ${ReadinessProbeHttpGetScheme},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The initial delay seconds.
    ${ReadinessProbeInitialDelaySecond},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The period seconds.
    ${ReadinessProbePeriodSecond},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The success threshold.
    ${ReadinessProbeSuccessThreshold},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The timeout seconds.
    ${ReadinessProbeTimeoutSecond},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Double]
    # The CPU request of this container instance.
    ${RequestCpu},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Double]
    # The memory request in GB of this container instance.
    ${RequestMemoryInGb},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.Int32]
    # The count of the GPU resource.
    ${RequestsGpuCount},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku])]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [System.String]
    # The SKU of the GPU resource.
    ${RequestsGpuSku},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[]]
    # The volume mounts available to the container instance.
    # To construct, see NOTES section for VOLUMEMOUNT properties and create a hash table.
    ${VolumeMount}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            __AllParameterSets = 'Az.ContainerInstance.custom\New-AzContainerInstanceObject';
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
