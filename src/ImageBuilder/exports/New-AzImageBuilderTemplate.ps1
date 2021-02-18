
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
Create a virtual machine image template
.Description
Create a virtual machine image template
.Example
PS C:\> $srcPlatform = New-AzImageBuilderSourceObject -SourceTypePlatformImage -Publisher 'Canonical'  -Offer 'UbuntuServer' -Sku '18.04-LTS' -Version 'latest'
PS C:\> $disSharedImg = New-AzImageBuilderDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/galleries/testsharedgallery/images/imagedefinition-linux/versions/1.0.0' -ReplicationRegion 'eastus2' -RunOutputName 'runoutput-01'  -ExcludeFromLatest $false
PS C:\> $customizer = New-AzImageBuilderCustomizerObject -ShellCustomizer -CustomizerName 'CheckSumCompareShellScript' -ScriptUri 'https://raw.githubusercontent.com/danielsollondon/azvmimagebuilder/master/quickquickstarts/customizeScript2.sh' -Sha256Checksum 'ade4c5214c3c675e92c66e2d067a870c5b81b9844b3de3cc72c49ff36425fc93'
PS C:\> $userAssignedIdentity = '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/wyunchi-imagebuilder/providers/Microsoft.ManagedIdentity/userAssignedIdentities/image-builder-user-assign-identity'
PS C:\> New-AzImageBuilderTemplate -ImageTemplateName platform-shared-img -ResourceGroupName wyunchi-imagebuilder -Source $srcPlatform -Distribute $disSharedImg -Customize $customizer -Location eastus  -UserAssignedIdentityId $userAssignedIdentity

Location Name                Type
-------- ----                ----
PlanInfoPlanName      :
PlanInfoPlanPublisher :
Sku                   : 18.04-LTS
Version               : latest
PlanInfo              : Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.PlatformImagePurchasePlan

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplate
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

CUSTOMIZE <IImageTemplateCustomizer[]>: Specifies the properties used to describe the customization steps of the image, like Image source etc.
  Type <String>: The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
  [Name <String>]: Friendly Name to provide context on what this customization step does

DISTRIBUTE <IImageTemplateDistributor[]>: The distribution targets where the image output needs to go to.
  RunOutputName <String>: The name to be used for the associated RunOutput.
  Type <String>: Type of distribution.
  [ArtifactTag <IImageTemplateDistributorArtifactTags>]: Tags that will be applied to the artifact once it has been created/updated by the distributor.
    [(Any) <String>]: This indicates any property can be added to this object.

SOURCE <IImageTemplateSource>: Describes a virtual machine image source for building, customizing and distributing.
  Type <String>: Specifies the type of source image you want to start with.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.imagebuilder/New-AzImageBuilderTemplate
#>
function New-AzImageBuilderTemplate {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplate])]
[CmdletBinding(DefaultParameterSetName='Name', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(Mandatory)]
    [Alias('Name')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Path')]
    [System.String]
    # The name of the image Template.
    ${ImageTemplateName},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Path')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    ${SubscriptionId},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor[]]
    # The distribution targets where the image output needs to go to.
    # To construct, see NOTES section for DISTRIBUTE properties and create a hash table.
    ${Distribute},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource]
    # Describes a virtual machine image source for building, customizing and distributing.
    # To construct, see NOTES section for SOURCE properties and create a hash table.
    ${Source},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateIdentityUserAssignedIdentities]))]
    [System.String]
    # The id of user assigned identity.
    ${UserAssignedIdentityId},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Resource location.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Int32]
    # Maximum duration to wait while building the image template.
    # Omit or specify 0 to use the default (4 hours).
    ${BuildTimeoutInMinute},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateCustomizer[]]
    # Specifies the properties used to describe the customization steps of the image, like Image source etc.
    # To construct, see NOTES section for CUSTOMIZE properties and create a hash table.
    ${Customize},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.DateTime]
    # End time of the last run (UTC).
    ${LastRunStatusEndTime},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Verbose information about the last run state.
    ${LastRunStatusMessage},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState])]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunState]
    # State of the last run.
    ${LastRunStatusRunState},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState])]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.RunSubState]
    # Sub-state of the last run.
    ${LastRunStatusRunSubState},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.DateTime]
    # Start time of the last run (UTC).
    ${LastRunStatusStartTime},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode])]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.ProvisioningErrorCode]
    # Error code of the provisioning failure.
    ${ProvisioningErrorCode},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Verbose error message about the provisioning failure.
    ${ProvisioningErrorMessage},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IResourceTags]))]
    [System.Collections.Hashtable]
    # Resource tags.
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Int32]
    # Size of the OS disk in GB.
    # Omit or specify 0 to use Azure's default OS disk size.
    ${VMProfileOsdiskSizeInGb},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Size of the virtual machine used to build, customize and capture images.
    # Omit or specify empty string to use the default (Standard_D1_v2).
    ${VMProfileVmSize},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Resource id of a pre-existing subnet.
    ${VnetConfigSubnetId},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Azure')]
    [System.Management.Automation.PSObject]
    # region HideParameter
    #  The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    # endregion HideParameter
    ${ProxyUseDefaultCredentials}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            Name = 'Az.ImageBuilder.custom\New-AzImageBuilderTemplate';
        }
        if (('Name') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
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
