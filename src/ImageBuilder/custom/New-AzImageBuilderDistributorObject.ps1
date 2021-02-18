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
Generic distribution object
.Description
Generic distribution object

.Link
https://docs.microsoft.com/en-us/powershell/module/az.imagebuilder/new-AzImageBuilderDistributorObject
#>
function New-AzImageBuilderDistributorObject {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor')]
    [CmdletBinding(PositionalBinding=$false, DefaultParameterSetName="ManagedImageDistributor")]
    Param(
        #region DistributorCommon
        [Parameter(Mandatory, HelpMessage="Tags that will be applied to the artifact once it has been created/updated by the distributor.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [System.Collections.Hashtable]
        ${ArtifactTag},
        [Parameter(Mandatory, HelpMessage="The name to be used for the associated RunOutput.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${RunOutputName},
        #endregion DistributorCommon
        
    
        #region VhdDistributor
        [Parameter(ParameterSetName='VhdDistributor', Mandatory, HelpMessage="Distribute via VHD in a storage account.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${VhdDistributor},
        #endregion VhdDistributor
    
        #region ManagedImageDistributor
        [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory, HelpMessage="Distribute as a Managed Disk Image.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${ManagedImageDistributor},
        [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory, HelpMessage="Resource Id of the Managed Disk Image.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${ImageId},
        [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory, HelpMessage="Azure location for the image, should match if image already exists.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Location},
        #endregion ManagedImageDistributor
    
        #region SharedImageDistributor
        [Parameter(ParameterSetName='SharedImageDistributor', Mandatory, HelpMessage="Distribute via Shared Image Gallery.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${SharedImageDistributor},
        [Parameter(ParameterSetName='SharedImageDistributor', Mandatory, HelpMessage="Flag that indicates whether created image version should be excluded from latest. Omit to use the default (false).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Boolean]
        ${ExcludeFromLatest},
        [Parameter(ParameterSetName='SharedImageDistributor', Mandatory, HelpMessage="A list of regions that the image will be replicated to.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string[]]
        ${ReplicationRegion},
        [Parameter(ParameterSetName='SharedImageDistributor', Mandatory, HelpMessage="Resource Id of the Shared Image Gallery image.")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${GalleryImageId},
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType])]
        [Parameter(ParameterSetName='SharedImageDistributor', HelpMessage="Storage account type to be used to store the shared image. Omit to use the default (Standard_LRS).")]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType]
        ${StorageAccountType}
        #endregion SharedImageDistributor
    )
    
    process {
        if ($PSBoundParameters.ContainsKey('VhdDistributor')) {
            $Distributor = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateVhdDistributor]::New()
            $Distributor.Type = "VHD"
        } elseif ($PSBoundParameters.ContainsKey('ManagedImageDistributor')) {
            $Distributor = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateManagedImageDistributor]::New()
            $Distributor.Type = "ManagedImage"
            $Distributor.ImageId = $ImageId
            $Distributor.Location = $Location
        } elseif ($PSBoundParameters.ContainsKey('SharedImageDistributor')) {
            $Distributor = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.ImageTemplateSharedImageDistributor]::New()
            $Distributor.Type = "SharedImage"
            $Distributor.ExcludeFromLatest = $ExcludeFromLatest
            $Distributor.GalleryImageId = $GalleryImageId
            $Distributor.ReplicationRegion = $ReplicationRegion
            $Distributor.StorageAccountType = $StorageAccountType
        }
        $Distributor.ArtifactTag = $ArtifactTag
        $Distributor.RunOutputName = $RunOutputName

        return $Distributor
    }
}