
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
.Example
PS C:\> New-AzImageBuilderDistributorObject -ManagedImageDistributor  -ArtifactTag @{tag='lucasManage'} -ImageId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/lucas-linux-imageshare -RunOutputName luacas-runout -Location eastus

RunOutputName Type         ImageId                                                                                                                                           Location
------------- ----         -------                                                                                                                                           --------
luacas-runout ManagedImage /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/lucas-linux-imageshare eastus
.Example
PS C:\> New-AzImageBuilderDistributorObject -ArtifactTag @{tag='vhd'} -VhdDistributor -RunOutputName image-vhd

RunOutputName Type
------------- ----
image-vhd     Vhd
.Example
PS C:\> New-AzImageBuilderDistributorObject -SharedImageDistributor -ArtifactTag @{tag='dis-share'} -GalleryImageId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/galleries/myimagegallery/images/lcuas-linux-share' -ReplicationRegion eastus2 -RunOutputName 'outname' -ExcludeFromLatest $false 

RunOutputName Type        ExcludeFromLatest GalleryImageId                                                                                                                                                        ReplicationRegi
                                                                                                                                                                                                                  on
------------- ----        ----------------- --------------                                                                                                                                                        ---------------
outname       SharedImage False             /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/galleries/myimagegallery/images/lcuas-linux-share {eastus2}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor
.Link
https://docs.microsoft.com/en-us/powershell/module/az.imagebuilder/new-AzImageBuilderDistributorObject
#>
function New-AzImageBuilderDistributorObject {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20200214.IImageTemplateDistributor])]
[CmdletBinding(DefaultParameterSetName='ManagedImageDistributor', PositionalBinding=$false)]
param(
    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Collections.Hashtable]
    # Tags that will be applied to the artifact once it has been created/updated by the distributor.
    ${ArtifactTag},

    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # The name to be used for the associated RunOutput.
    ${RunOutputName},

    [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Distribute as a Managed Disk Image.
    ${ManagedImageDistributor},

    [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Resource Id of the Managed Disk Image.
    ${ImageId},

    [Parameter(ParameterSetName='ManagedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Azure location for the image, should match if image already exists.
    ${Location},

    [Parameter(ParameterSetName='VhdDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Distribute via VHD in a storage account.
    ${VhdDistributor},

    [Parameter(ParameterSetName='SharedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Distribute via Shared Image Gallery.
    ${SharedImageDistributor},

    [Parameter(ParameterSetName='SharedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.Boolean]
    # Flag that indicates whether created image version should be excluded from latest.
    # Omit to use the default (false).
    ${ExcludeFromLatest},

    [Parameter(ParameterSetName='SharedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String[]]
    # A list of regions that the image will be replicated to.
    ${ReplicationRegion},

    [Parameter(ParameterSetName='SharedImageDistributor', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [System.String]
    # Resource Id of the Shared Image Gallery image.
    ${GalleryImageId},

    [Parameter(ParameterSetName='SharedImageDistributor')]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType])]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Support.SharedImageStorageAccountType]
    # Storage account type to be used to store the shared image.
    # Omit to use the default (Standard_LRS).
    ${StorageAccountType}
)

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            ManagedImageDistributor = 'Az.ImageBuilder.custom\New-AzImageBuilderDistributorObject';
            VhdDistributor = 'Az.ImageBuilder.custom\New-AzImageBuilderDistributorObject';
            SharedImageDistributor = 'Az.ImageBuilder.custom\New-AzImageBuilderDistributorObject';
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
