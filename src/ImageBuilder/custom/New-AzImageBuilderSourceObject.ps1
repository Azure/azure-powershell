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
Describes a virtual machine image source for building, customizing and distributing.
.Description
Describes a virtual machine image source for building, customizing and distributing.

.Link
https://docs.microsoft.com/en-us/powershell/module/az.imagebuilder/New-AzImageBuilderSourceObject
#>
function New-AzImageBuilderSourceObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource')]
    [CmdletBinding(PositionalBinding=$false, DefaultParameterSetName="ManagedImage")]
    Param(
        #region SourceType-PlatformImage
        [Parameter(ParameterSetName='PlatformImage', Mandatory, HelpMessage="Describes an image source from [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).")]
        [Parameter(ParameterSetName='PlatformImagePlanInfo', Mandatory, HelpMessage="Describes an image source from [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${SourceTypePlatformImage},
        [Parameter(ParameterSetName='PlatformImage', HelpMessage="Image offer from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).")]
        [Parameter(ParameterSetName='PlatformImagePlanInfo', HelpMessage="Image offer from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Offer},
        [Parameter(ParameterSetName='PlatformImagePlanInfo', Mandatory, HelpMessage="Name of the purchase plan.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${PlanName},
        [Parameter(ParameterSetName='PlatformImagePlanInfo', Mandatory, HelpMessage="Product of the purchase plan.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${PlanProduct},
        [Parameter(ParameterSetName='PlatformImagePlanInfo', Mandatory, HelpMessage="Publisher of the purchase plan.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${PlanPublisher},
        [Parameter(ParameterSetName='PlatformImage', HelpMessage="Image Publisher in [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).")]
        [Parameter(ParameterSetName='PlatformImagePlanInfo', HelpMessage="Image Publisher in [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Publisher},
        [Parameter(ParameterSetName='PlatformImage', HelpMessage="Image sku from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).")]
        [Parameter(ParameterSetName='PlatformImagePlanInfo', HelpMessage="Image sku from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Sku},
        [Parameter(ParameterSetName='PlatformImage', HelpMessage="Image version from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).")]
        [Parameter(ParameterSetName='PlatformImagePlanInfo', HelpMessage="Image version from the [Azure Gallery Images](https://docs.microsoft.com/en-us/rest/api/compute/virtualmachineimages).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Version},
        #endregion SourceType-PlatformImage

        #region SourceType-ManagedImage
        [Parameter(ParameterSetName='ManagedImage', Mandatory, HelpMessage="Describes an image source that is a managed image in customer subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${SourceTypeManagedImage},
        [Parameter(ParameterSetName='ManagedImage', HelpMessage="ARM resource id of the managed image in customer subscription.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${ImageId},
        #endregion SourceType-ManagedImage

        #region SourceType-SharedImageVersion
        [Parameter(ParameterSetName='SharedImageVersion', Mandatory, HelpMessage="Describes an image source that is an image version in a shared image gallery.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${SourceTypeSharedImageVersion},
        [Parameter(ParameterSetName='SharedImageVersion', HelpMessage="ARM resource id of the image version in the shared image gallery.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${ImageVersionId}
        #endregion SourceType-SharedImageVersion
    )

    
    process {
        if ($PSBoundParameters.ContainsKey('SourceTypePlatformImage')) {
            $Source = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplatePlatformImageSource]::New()
            $Source.Type = "PlatformImage"
            $Source.Offer = $Offer
            if ($PSBoundParameters.ContainsKey('PlanName')) {
                $Source.PlanInfoPlanName = $PlanName
                $Source.PlanInfoPlanProduct = $PlanProduct
                $Source.PlanInfoPlanPublisher = $PlanPublisher
            }
            $Source.Publisher = $Publisher
            $Source.Sku = $Sku
            $Source.Version = $Version
        } elseif ($PSBoundParameters.ContainsKey('SourceTypeManagedImage')) {
            $Source = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateManagedImageSource]::New()
            $Source.Type = "ManagedImage"
            $Source.ImageId = $ImageId
        } elseif ($PSBoundParameters.ContainsKey('SourceTypeSharedImageVersion')) {
            $Source = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateSharedImageVersionSource]::New()
            $Source.Type = "SharedImageVersion"
            $Source.ImageVersionId = $ImageVersionId
        }

        return $Source
    }
}