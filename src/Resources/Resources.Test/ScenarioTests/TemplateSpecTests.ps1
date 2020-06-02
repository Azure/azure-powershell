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
.SYNOPSIS
Returns whether or not the objects are equivalent (matching properties)
#>
function Get-AreObjectsEquivalent
{
    param(
        [PSObject] $Lhs,
        [PSObject] $Rhs
    )

    if ($Lhs -eq $Rhs) {
        return $true;
    }

    $diff = Compare-Object $Lhs $Rhs 
    return !($diff)
}


<#
.SYNOPSIS
Tests Template Spec GET operations with different parameter sets for PowerShell
#>
function Test-GetTemplateSpec
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId

    try
    {
        # Prepare our RG and basic template spec (with two versions):

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"
        $basicCreatedTemplateSpecV1 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson
        $basicCreatedTemplateSpecV2 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v2" -TemplateJson $sampleTemplateJson

        # Validate we get expected results when getting a specific version (by rg name, template spec name, and version)
        
        $returnedByGetOnSpecificVersion = Get-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Version "v1"

        Assert-NotNull $returnedByGetOnSpecificVersion
        Assert-True { Get-AreObjectsEquivalent $basicCreatedTemplateSpecV1 $returnedByGetOnSpecificVersion }
        Assert-NotNull $returnedByGetOnSpecificVersion.Version
        Assert-AreEqual "v1" $returnedByGetOnSpecificVersion.Version.Name

        # Validate we get expected results when getting a specific version (by id, and version)

        $returnedByGetOnSpecificVersionById = Get-AzTemplateSpec -Id $basicCreatedTemplateSpecV2.Id -Version "v2"

        Assert-NotNull $returnedByGetOnSpecificVersionById
        Assert-True { Get-AreObjectsEquivalent $basicCreatedTemplateSpecV2 $returnedByGetOnSpecificVersionById }
        Assert-NotNull $returnedByGetOnSpecificVersionById.Version
        Assert-AreEqual "v2" $returnedByGetOnSpecificVersionById.Version.Name

        # Now let's get the template spec with all versions
        
        $returnedByGetOnTemplateSpecName = Get-AzTemplateSpec -ResourceGroupName $rgname -Name $rname

        Assert-NotNull $returnedByGetOnTemplateSpecName
        Assert-AreEqual $returnedByGetOnTemplateSpecName.Name $rname
        Assert-Null $returnedByGetOnTemplateSpecName.Version # Should not be specific Version
        Assert-True { $returnedByGetOnTemplateSpecName.Versions -is [system.array] }
        Assert-AreEqual $returnedByGetOnTemplateSpecName.Versions.Length 2 # Should have 2 versions
        Assert-True { Get-AreObjectsEquivalent $returnedByGetOnTemplateSpecName.Versions[0] $basicCreatedTemplateSpecV1.Version }
        Assert-True { Get-AreObjectsEquivalent $returnedByGetOnTemplateSpecName.Versions[1] $basicCreatedTemplateSpecV2.Version }

        # Do a list on the resource group

        $returnedByListOnResourceGroup = Get-AzTemplateSpec -ResourceGroupName $rgname
        Assert-AreNotEqual 0 $returnedByListOnResourceGroup.Length
        Assert-True { $returnedByListOnResourceGroup.Name.contains($rname) }

        # Do a list on the current subscription

        $returnedByListOnCurrentSub = Get-AzTemplateSpec
        Assert-AreNotEqual 0 $returnedByListOnCurrentSub.Length
        Assert-True { $returnedByListOnCurrentSub.Name.contains($rname) }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}