
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
Create or update a virtual machine image template
.Description
Create or update a virtual machine image template
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

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplate
.Inputs
Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IImageBuilderIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplate
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

INPUTOBJECT <IImageBuilderIdentity>: Identity Parameter
  [Id <String>]: Resource identity path
  [ImageTemplateName <String>]: The name of the image Template
  [ResourceGroupName <String>]: The name of the resource group.
  [RunOutputName <String>]: The name of the run output
  [SubscriptionId <String>]: Subscription credentials which uniquely identify Microsoft Azure subscription. The subscription Id forms part of the URI for every service call.

PARAMETER <IImageTemplate>: Image template is an ARM resource managed by Microsoft.VirtualMachineImages provider
  Location <String>: Resource location
  Distribute <IImageTemplateDistributor[]>: The distribution targets where the image output needs to go to.
    RunOutputName <String>: The name to be used for the associated RunOutput.
    Type <String>: Type of distribution.
    ImageId <String>: Resource Id of the Managed Disk Image
    Location <String>: Azure location for the image, should match if image already exists
    GalleryImageId <String>: Resource Id of the Shared Image Gallery image
    ReplicationRegion <String[]>: A list of regions that the image will be replicated to
    [ArtifactTag <IImageTemplateDistributorArtifactTags>]: Tags that will be applied to the artifact once it has been created/updated by the distributor.
      [(Any) <String>]: This indicates any property can be added to this object.
    [ExcludeFromLatest <Boolean?>]: Flag that indicates whether created image version should be excluded from latest. Omit to use the default (false).
    [StorageAccountType <SharedImageStorageAccountType?>]: Storage account type to be used to store the shared image. Omit to use the default (Standard_LRS).
  SourceType <String>: Specifies the type of source image you want to start with.
  [Tag <IResourceTags>]: Resource tags
    [(Any) <String>]: This indicates any property can be added to this object.
  [BuildTimeoutInMinute <Int32?>]: Maximum duration to wait while building the image template. Omit or specify 0 to use the default (4 hours).
  [Customize <IImageTemplateCustomizer[]>]: Specifies the properties used to describe the customization steps of the image, like Image source etc
    Type <String>: The type of customization tool you want to use on the Image. For example, "Shell" can be shell customizer
    [Name <String>]: Friendly Name to provide context on what this customization step does
    [Inline <String[]>]: Array of shell commands to execute
    [ScriptUri <String>]: URI of the shell script to be run for customizing. It can be a github link, SAS URI for Azure Storage, etc
    [Sha256Checksum <String>]: SHA256 checksum of the shell script provided in the scriptUri field
    [RestartCheckCommand <String>]: Command to check if restart succeeded [Default: '']
    [RestartCommand <String>]: Command to execute the restart [Default: 'shutdown /r /f /t 0 /c "packer restart"']
    [RestartTimeout <String>]: Restart timeout specified as a string of magnitude and unit, e.g. '5m' (5 minutes) or '2h' (2 hours) [Default: '5m']
    [Filter <String[]>]: Array of filters to select updates to apply. Omit or specify empty array to use the default (no filter). Refer to above link for examples and detailed description of this field.
    [SearchCriterion <String>]: Criteria to search updates. Omit or specify empty string to use the default (search all). Refer to above link for examples and detailed description of this field.
    [UpdateLimit <Int32?>]: Maximum number of updates to apply at a time. Omit or specify 0 to use the default (1000)
    [Inline <String[]>]: Array of PowerShell commands to execute
    [RunElevated <Boolean?>]: If specified, the PowerShell script will be run with elevated privileges
    [ScriptUri <String>]: URI of the PowerShell script to be run for customizing. It can be a github link, SAS URI for Azure Storage, etc
    [Sha256Checksum <String>]: SHA256 checksum of the power shell script provided in the scriptUri field above
    [ValidExitCode <Int32[]>]: Valid exit codes for the PowerShell script. [Default: 0]
    [Destination <String>]: The absolute path to a file (with nested directory structures already created) where the file (from sourceUri) will be uploaded to in the VM
    [Sha256Checksum <String>]: SHA256 checksum of the file provided in the sourceUri field above
    [SourceUri <String>]: The URI of the file to be uploaded for customizing the VM. It can be a github link, SAS URI for Azure Storage, etc
  [IdentityType <ResourceIdentityType?>]: The type of identity used for the image template. The type 'None' will remove any identities from the image template.
  [IdentityUserAssignedIdentity <IImageTemplateIdentityUserAssignedIdentities>]: The list of user identities associated with the image template. The user identity dictionary key references will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}'.
    [(Any) <IComponentsVrq145SchemasImagetemplateidentityPropertiesUserassignedidentitiesAdditionalproperties>]: This indicates any property can be added to this object.
  [LastRunStatusEndTime <DateTime?>]: End time of the last run (UTC)
  [LastRunStatusMessage <String>]: Verbose information about the last run state
  [LastRunStatusRunState <RunState?>]: State of the last run
  [LastRunStatusRunSubState <RunSubState?>]: Sub-state of the last run
  [LastRunStatusStartTime <DateTime?>]: Start time of the last run (UTC)
  [ProvisioningErrorCode <ProvisioningErrorCode?>]: Error code of the provisioning failure
  [ProvisioningErrorMessage <String>]: Verbose error message about the provisioning failure
  [VMProfileOsdiskSizeGb <Int32?>]: Size of the OS disk in GB. Omit or specify 0 to use Azure's default OS disk size.
  [VMProfileVmsize <String>]: Size of the virtual machine used to build, customize and capture images. Omit or specify empty string to use the default (Standard_D1_v2).
  [VnetConfigSubnetId <String>]: Resource id of a pre-existing subnet.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.imagebuilder/new-azimagebuildertemplate
#>
function New-AzImageBuilderTemplate {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplate])]
[CmdletBinding(DefaultParameterSetName='CreateViaIdentity', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='Create', Mandatory)]
    [Alias('Name')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Path')]
    [System.String]
    # The name of the image Template
    ${ImageTemplateName},

    [Parameter(ParameterSetName='Create', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Path')]
    [System.String]
    # The name of the resource group.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='Create')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription Id forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='CreateViaIdentity', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.IImageBuilderIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter(Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplate]
    # Image template is an ARM resource managed by Microsoft.VirtualMachineImages provider
    # To construct, see NOTES section for PARAMETER properties and create a hash table.
    ${Parameter},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
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
            Create = 'Az.ImageBuilder.private\New-AzImageBuilderTemplate_Create';
            CreateViaIdentity = 'Az.ImageBuilder.private\New-AzImageBuilderTemplate_CreateViaIdentity';
        }
        if (('Create') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
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
