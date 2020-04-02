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

function New-AzImageBuilderSource {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateSource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    Param(
        #region SourceType-PlatformImage
        [Parameter(ParameterSetName='PlatformImage', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${SourceTypePlatformImage},
        [Parameter(ParameterSetName='PlatformImage')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Offer},
        [Parameter(ParameterSetName='PlatformImage')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${PlanInfoPlanName},
        [Parameter(ParameterSetName='PlatformImage')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${PlanInfoPlanProduct},
        [Parameter(ParameterSetName='PlatformImage')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${PlanInfoPlanPublisher},
        [Parameter(ParameterSetName='PlatformImage')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Publisher},
        [Parameter(ParameterSetName='PlatformImage')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Sku},
        [Parameter(ParameterSetName='PlatformImage')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Version},
        #endregion SourceType-PlatformImage

        #region SourceType-ManagedImage
        [Parameter(ParameterSetName='ManagedImage', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${SourceTypeManagedImage},
        [Parameter(ParameterSetName='ManagedImage')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${ImageId},
        #endregion SourceType-ManagedImage

        #region SourceType-SharedImageVersion
        [Parameter(ParameterSetName='SharedImageVersion', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${SourceTypeSharedImageVersion},
        [Parameter(ParameterSetName='SharedImageVersion')]
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
            $Source.PlanInfoPlanName = $PlanInfoPlanName
            $Source.PlanInfoPlanProduct = $PlanInfoPlanProduct
            $Source.PlanInfoPlanPublisher = $PlanInfoPlanPublisher
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