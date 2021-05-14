
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
Create a in-memory object for Container
.Description
Create a in-memory object for Container

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Container
.Link
https://docs.microsoft.com/powershell/module//az.ContainerInstance/new-AzContainerInstanceObject
#>
function New-AzContainerInstanceObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Container')]
    [CmdletBinding(PositionalBinding=$false)]
    Param(

        [Parameter(HelpMessage="The commands to execute within the container instance in exec form.")]
        [string[]]
        $Command,
        [Parameter(HelpMessage="The environment variables to set in the container instance.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[]]
        $EnvironmentVariable,
        [Parameter(Mandatory, HelpMessage="The name of the image used to create the container instance.")]
        [string]
        $Image,
        [Parameter(HelpMessage="The CPU limit of this container instance.")]
        [double]
        $LimitCpu,
        [Parameter(HelpMessage="The memory limit in GB of this container instance.")]
        [double]
        $LimitMemoryInGb,
        [Parameter(HelpMessage="The count of the GPU resource.")]
        [int]
        $LimitsGpuCount,
        [Parameter(HelpMessage="The SKU of the GPU resource.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku])]
        [string]
        $LimitsGpuSku,
        [Parameter(HelpMessage="The commands to execute within the container.")]
        [string[]]
        $LivenessProbeExecCommand,
        [Parameter(HelpMessage="The failure threshold.")]
        [int]
        $LivenessProbeFailureThreshold,
        [Parameter(HelpMessage="The header name.")]
        [string]
        $LivenessProbeHttpGetHttpHeadersName,
        [Parameter(HelpMessage="The header value.")]
        [string]
        $LivenessProbeHttpGetHttpHeadersValue,
        [Parameter(HelpMessage="The path to probe.")]
        [string]
        $LivenessProbeHttpGetPath,
        [Parameter(HelpMessage="The port number to probe.")]
        [int]
        $LivenessProbeHttpGetPort,
        [Parameter(HelpMessage="The scheme.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme])]
        [string]
        $LivenessProbeHttpGetScheme,
        [Parameter(HelpMessage="The initial delay seconds.")]
        [int]
        $LivenessProbeInitialDelaySecond,
        [Parameter(HelpMessage="The period seconds.")]
        [int]
        $LivenessProbePeriodSecond,
        [Parameter(HelpMessage="The success threshold.")]
        [int]
        $LivenessProbeSuccessThreshold,
        [Parameter(HelpMessage="The timeout seconds.")]
        [int]
        $LivenessProbeTimeoutSecond,
        [Parameter(Mandatory, HelpMessage="The user-provided name of the container instance.")]
        [string]
        $Name,
        [Parameter(HelpMessage="The exposed ports on the container instance.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPort[]]
        $Port,
        [Parameter(HelpMessage="The commands to execute within the container.")]
        [string[]]
        $ReadinessProbeExecCommand,
        [Parameter(HelpMessage="The failure threshold.")]
        [int]
        $ReadinessProbeFailureThreshold,
        [Parameter(HelpMessage="The header name.")]
        [string]
        $ReadinessProbeHttpGetHttpHeadersName,
        [Parameter(HelpMessage="The header value.")]
        [string]
        $ReadinessProbeHttpGetHttpHeadersValue,
        [Parameter(HelpMessage="The path to probe.")]
        [string]
        $ReadinessProbeHttpGetPath,
        [Parameter(HelpMessage="The port number to probe.")]
        [int]
        $ReadinessProbeHttpGetPort,
        [Parameter(HelpMessage="The scheme.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.Scheme])]
        [string]
        $ReadinessProbeHttpGetScheme,
        [Parameter(HelpMessage="The initial delay seconds.")]
        [int]
        $ReadinessProbeInitialDelaySecond,
        [Parameter(HelpMessage="The period seconds.")]
        [int]
        $ReadinessProbePeriodSecond,
        [Parameter(HelpMessage="The success threshold.")]
        [int]
        $ReadinessProbeSuccessThreshold,
        [Parameter(HelpMessage="The timeout seconds.")]
        [int]
        $ReadinessProbeTimeoutSecond,
        [Parameter(HelpMessage="The CPU request of this container instance.")]
        [double]
        $RequestCpu,
        [Parameter(HelpMessage="The memory request in GB of this container instance.")]
        [double]
        $RequestMemoryInGb,
        [Parameter(HelpMessage="The count of the GPU resource.")]
        [int]
        $RequestsGpuCount,
        [Parameter(HelpMessage="The SKU of the GPU resource.")]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Support.GpuSku])]
        [string]
        $RequestsGpuSku,
        [Parameter(HelpMessage="The volume mounts available to the container instance.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[]]
        $VolumeMount
    )

    process {
        $Object = [Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Container]::New()

        $Object.Command = $Command
        $Object.EnvironmentVariable = $EnvironmentVariable
        $Object.Image = $Image
        $Object.LimitCpu = $LimitCpu
        $Object.LimitMemoryInGb = $LimitMemoryInGb
        $Object.LimitsGpuCount = $LimitsGpuCount
        $Object.LimitsGpuSku = $LimitsGpuSku
        $Object.LivenessProbeExecCommand = $LivenessProbeExecCommand
        $Object.LivenessProbeFailureThreshold = $LivenessProbeFailureThreshold
        $Object.LivenessProbeHttpGetHttpHeadersName = $LivenessProbeHttpGetHttpHeadersName
        $Object.LivenessProbeHttpGetHttpHeadersValue = $LivenessProbeHttpGetHttpHeadersValue
        $Object.LivenessProbeHttpGetPath = $LivenessProbeHttpGetPath
        $Object.LivenessProbeHttpGetPort = $LivenessProbeHttpGetPort
        $Object.LivenessProbeHttpGetScheme = $LivenessProbeHttpGetScheme
        $Object.LivenessProbeInitialDelaySecond = $LivenessProbeInitialDelaySecond
        $Object.LivenessProbePeriodSecond = $LivenessProbePeriodSecond
        $Object.LivenessProbeSuccessThreshold = $LivenessProbeSuccessThreshold
        $Object.LivenessProbeTimeoutSecond = $LivenessProbeTimeoutSecond
        $Object.Name = $Name
        if(!$PSBoundParameters.ContainsKey("Port"))
        {
            $Port = New-AzContainerInstancePortObject -Port 80
        }
        $Object.Port = $Port
        $Object.ReadinessProbeExecCommand = $ReadinessProbeExecCommand
        $Object.ReadinessProbeFailureThreshold = $ReadinessProbeFailureThreshold
        $Object.ReadinessProbeHttpGetHttpHeadersName = $ReadinessProbeHttpGetHttpHeadersName
        $Object.ReadinessProbeHttpGetHttpHeadersValue = $ReadinessProbeHttpGetHttpHeadersValue
        $Object.ReadinessProbeHttpGetPath = $ReadinessProbeHttpGetPath
        $Object.ReadinessProbeHttpGetPort = $ReadinessProbeHttpGetPort
        $Object.ReadinessProbeHttpGetScheme = $ReadinessProbeHttpGetScheme
        $Object.ReadinessProbeInitialDelaySecond = $ReadinessProbeInitialDelaySecond
        $Object.ReadinessProbePeriodSecond = $ReadinessProbePeriodSecond
        $Object.ReadinessProbeSuccessThreshold = $ReadinessProbeSuccessThreshold
        $Object.ReadinessProbeTimeoutSecond = $ReadinessProbeTimeoutSecond
        if(!$PSBoundParameters.ContainsKey("RequestCpu"))
        {
            $RequestCpu = 1.0
        }
        $Object.RequestCpu = $RequestCpu
        if(!$PSBoundParameters.ContainsKey("RequestMemoryInGb"))
        {
            $RequestMemoryInGb = 1.5
        }
        $Object.RequestMemoryInGb = $RequestMemoryInGb
        $Object.RequestsGpuCount = $RequestsGpuCount
        $Object.RequestsGpuSku = $RequestsGpuSku
        $Object.VolumeMount = $VolumeMount
        return $Object
    }
}

