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

        $returnedByGetOnSpecificVersionById = Get-AzTemplateSpec -ResourceId $basicCreatedTemplateSpecV2.Id -Version "v2"

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

<#
.SYNOPSIS
Tests that we can create a basic template spec with New-AzTemplateSpec
#>
function Test-CreateTemplateSpec
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId

    try
    {
        # Prepare our RG and basic template spec:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"
        $basicCreatedTemplateSpecV1 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Description "My Basic Template Spec" -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

        # Check to make sure all of the properties match expectations

        Assert-NotNull $basicCreatedTemplateSpecV1
        Assert-AreEqual $rname $basicCreatedTemplateSpecV1.Name
        Assert-AreEqual "My Basic Template Spec" $basicCreatedTemplateSpecV1.Description
        Assert-AreEqual "$rglocation".Replace(" ", "").ToLowerInvariant() $basicCreatedTemplateSpecV1.Location.Replace(" ", "").ToLowerInvariant()
        Assert-AreEqual "v1" $basicCreatedTemplateSpecV1.Version.Name
        
        # For the ARM template itself we'll do some normalization to ensure a valid comparison:
        $normalizedSampleTemplateJson = $sampleTemplateJson | ConvertFrom-Json | ConvertTo-Json -Compress
        $normalizedTemplateJsonInV1 = $basicCreatedTemplateSpecV1.Version.Template.ToString() | ConvertFrom-Json | ConvertTo-Json -Compress
        
        Assert-AreEqual $normalizedSampleTemplateJson $normalizedTemplateJsonInV1

        # Make sure we can get the template spec back out:
        $returnedByGet = Get-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Version "v1"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests that we can create/update a basic template spec with Set-AzTemplateSpec
#>
function Test-SetTemplateSpec
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId

    try
    {
        # Prepare our RG and basic template spec:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"
        $basicCreatedTemplateSpecV1 = Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Description "My Basic Template Spec" -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson

        # Check to make sure all of the properties match expectations

        Assert-NotNull $basicCreatedTemplateSpecV1
        Assert-AreEqual $rname $basicCreatedTemplateSpecV1.Name
        Assert-AreEqual "My Basic Template Spec" $basicCreatedTemplateSpecV1.Description
        Assert-AreEqual "$rglocation".Replace(" ", "").ToLowerInvariant() $basicCreatedTemplateSpecV1.Location.Replace(" ", "").ToLowerInvariant()
        Assert-AreEqual "v1" $basicCreatedTemplateSpecV1.Version.Name

        # For the ARM template itself we'll do some normalization to ensure a valid comparison:
        $normalizedSampleTemplateJson = $sampleTemplateJson | ConvertFrom-Json | ConvertTo-Json -Compress
        $normalizedTemplateJsonInV1 = $basicCreatedTemplateSpecV1.Version.Template.ToString() | ConvertFrom-Json | ConvertTo-Json -Compress

        Assert-AreEqual $normalizedSampleTemplateJson $normalizedTemplateJsonInV1

        # Now let's try to update the root template spec by resource id:
        $updatedTemplateSpec = Set-AzTemplateSpec -ResourceId $basicCreatedTemplateSpecV1.Id -Description "Updated Description"
        Assert-AreEqual "Updated Description" $updatedTemplateSpec.Description

        # Try updating the version
        $updatedTemplateSpecv1 = Set-AzTemplateSpec -ResourceId $basicCreatedTemplateSpecV1.Id -Version "v1" -VersionDescription "Updated Version" -TemplateJson $sampleTemplateJson
        Assert-AreEqual "Updated Version" $updatedTemplateSpecv1.Version.Description

        # Make sure we can get the template spec back out:
        $returnedByGet = Get-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Version "v1"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests 
#>
function Test-RemoveTemplateSpec
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

        # Validate we can remove a single version:

        # Temporarily blocked due to backend issue. Re-enable when fixed.
        # $singleVersionRemovalResult = Remove-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Version "v1" -Force
        # Assert-True { $singleVersionRemovalResult }
        # Assert-Throws { Get-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Version "v1" }

        # Validate we can remove the entire template spec:

        $allVersionsRemovalResult = Remove-AzTemplateSpec -ResourceId $basicCreatedTemplateSpecV1.Id -Force # Note: Id is Id of the root template spec
        Assert-True { $allVersionsRemovalResult }
        Assert-Throws { Get-AzTemplateSpec -ResourceGroupName $rgname -Name $rname }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}