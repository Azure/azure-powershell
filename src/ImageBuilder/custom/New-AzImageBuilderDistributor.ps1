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

function New-AzImageBuilderDistributor {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20190501Preview.IImageTemplateDistributor')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    Param(
        #region DistributorCommon
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [System.Collections.Hashtable]
        ${ArtifactTag},
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${RunOutputName},
        #endregion DistributorCommon
        
    
        #region VhdDistributor
        [Parameter(ParameterSetName='VhdDistributor', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${VhdDistributor},
        #endregion VhdDistributor
    
        #region ManagedImageDistributor
        [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${ManagedImageDistributor},
        [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${ImageId},
        [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${Location},
        #endregion ManagedImageDistributor
    
        #region SharedImageDistributor
        [Parameter(ParameterSetName='SharedImageDistributor', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Switch]
        ${SharedImageDistributor},
        [Parameter(ParameterSetName='SharedImageDistributor')]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [Boolean]
        ${ExcludeFromLatest},
        [Parameter(ParameterSetName='SharedImageDistributor', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string[]]
        ${ReplicationRegion},
        [Parameter(ParameterSetName='SharedImageDistributor', Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        [string]
        ${GalleryImageId}
        # [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType])]
        # [Parameter(ParameterSetName='SharedImageDistributor')]
        # [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
        # [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType]
        # ${StorageAccountType}
        #endregion SharedImageDistributor
    )
    
    process {
        if ($PSBoundParameters.ContainsKey('VhdDistributor')) {
            $Distributor = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20190501Preview.ImageTemplateVhdDistributor]::New()
            $Distributor.Type = "Vhd"
        } elseif ($PSBoundParameters.ContainsKey('ManagedImageDistributor')) {
            $Distributor = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20190501Preview.ImageTemplateManagedImageDistributor]::New()
            $Distributor.Type = "ManagedImage"
            $Distributor.ImageId = $ImageId
            $Distributor.Location = $Location
        } elseif ($PSBoundParameters.ContainsKey('SharedImageDistributor')) {
            $Distributor = [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20190501Preview.ImageTemplateSharedImageDistributor]::New()
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