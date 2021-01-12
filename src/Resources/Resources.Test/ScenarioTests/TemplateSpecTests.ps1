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
        Assert-NotNull $returnedByGetOnSpecificVersion.Versions
        Assert-AreEqual $returnedByGetOnSpecificVersion.Versions.Length 1
 
        Assert-AreEqual "v1" $returnedByGetOnSpecificVersion.Versions[0].Name

        # Validate we get expected results when getting a specific version (by id, and version)

        $returnedByGetOnSpecificVersionById = Get-AzTemplateSpec -ResourceId $basicCreatedTemplateSpecV2.Id -Version "v2"

        Assert-NotNull $returnedByGetOnSpecificVersionById
        Assert-True { Get-AreObjectsEquivalent $basicCreatedTemplateSpecV2 $returnedByGetOnSpecificVersionById }
        Assert-NotNull $returnedByGetOnSpecificVersionById.Versions
        Assert-AreEqual $returnedByGetOnSpecificVersionById.Versions.Length 1
        Assert-AreEqual "v2" $returnedByGetOnSpecificVersionById.Versions[0].Name

        # Now let's get the template spec with all versions
        
        $returnedByGetOnTemplateSpecName = Get-AzTemplateSpec -ResourceGroupName $rgname -Name $rname

        Assert-NotNull $returnedByGetOnTemplateSpecName
        Assert-AreEqual $returnedByGetOnTemplateSpecName.Name $rname
        Assert-True { $returnedByGetOnTemplateSpecName.Versions -is [system.array] }
        Assert-AreEqual $returnedByGetOnTemplateSpecName.Versions.Length 2 # Should have 2 versions
        Assert-True { Get-AreObjectsEquivalent $returnedByGetOnTemplateSpecName.Versions[0] $basicCreatedTemplateSpecV1.Versions[0] }
        Assert-True { Get-AreObjectsEquivalent $returnedByGetOnTemplateSpecName.Versions[1] $basicCreatedTemplateSpecV2.Versions[0] }

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
        Assert-AreEqual $basicCreatedTemplateSpecV1.Versions.Length 1
        Assert-AreEqual $rname $basicCreatedTemplateSpecV1.Name
        Assert-AreEqual "My Basic Template Spec" $basicCreatedTemplateSpecV1.Description
        Assert-AreEqual "$rglocation".Replace(" ", "").ToLowerInvariant() $basicCreatedTemplateSpecV1.Location.Replace(" ", "").ToLowerInvariant()
        Assert-AreEqual "v1" $basicCreatedTemplateSpecV1.Versions[0].Name
        
        # For the ARM template itself we'll do some normalization to ensure a valid comparison:
        $normalizedSampleTemplateJson = $sampleTemplateJson | ConvertFrom-Json | ConvertTo-Json -Compress
        $normalizedTemplateJsonInV1 = $basicCreatedTemplateSpecV1.Versions[0].Template.ToString() | ConvertFrom-Json | ConvertTo-Json -Compress
        
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
        Assert-AreEqual $basicCreatedTemplateSpecV1.Length 1
        Assert-AreEqual $rname $basicCreatedTemplateSpecV1.Name
        Assert-AreEqual "My Basic Template Spec" $basicCreatedTemplateSpecV1.Description
        Assert-AreEqual "$rglocation".Replace(" ", "").ToLowerInvariant() $basicCreatedTemplateSpecV1.Location.Replace(" ", "").ToLowerInvariant()
        Assert-AreEqual "v1" $basicCreatedTemplateSpecV1.Versions[0].Name

        # For the ARM template itself we'll do some normalization to ensure a valid comparison:
        $normalizedSampleTemplateJson = $sampleTemplateJson | ConvertFrom-Json | ConvertTo-Json -Compress
        $normalizedTemplateJsonInV1 = $basicCreatedTemplateSpecV1.Versions[0].Template.ToString() | ConvertFrom-Json | ConvertTo-Json -Compress

        Assert-AreEqual $normalizedSampleTemplateJson $normalizedTemplateJsonInV1

        # Now let's try to update the root template spec by resource id:
        $updatedTemplateSpec = Set-AzTemplateSpec -ResourceId $basicCreatedTemplateSpecV1.Id -Description "Updated Description"
        Assert-AreEqual "Updated Description" $updatedTemplateSpec.Description

        # Try updating the version
        $updatedTemplateSpecv1 = Set-AzTemplateSpec -ResourceId $basicCreatedTemplateSpecV1.Id -Version "v1" -VersionDescription "Updated Version" -TemplateJson $sampleTemplateJson
        Assert-AreEqual "Updated Version" $updatedTemplateSpecv1.Versions[0].Description

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
Tests that a template spec can be removed with Remove-AzTemplateSpec
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

        $singleVersionRemovalResult = Remove-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Version "v1" -Force
        Assert-True { $singleVersionRemovalResult }
        Assert-Throws { Get-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Version "v1" }

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

<#
.SYNOPSIS
Tests that using a non-existant TemplateSpec throws the correct type of error
#>
function Test-TemplateSpecErrorType
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
        Assert-Throws { Get-AzTemplateSpec -ResourceGroupName $rgname -Name $rname }
        Assert-AreEqual $error.Exception.GetType().name TemplateSpecsErrorException
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates that when New-AzTemplateSpec is executed with a -Tags parameter value 
and neither the template spec or version exist, the Tags get applied to both the 
new template spec and the new template spec version.
#>
function Test-NewAppliesTagsToBothTemplateSpecAndVersionIfNotExist
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId
    $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"

    try
    {
        # Prepare our RG and create a new template spec/version with tags:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $tagsToApply = @{Tag1="Value1"; Tag2="Value2"}
        $basicCreatedTemplateSpecV1 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $tagsToApply

        # Both the template spec and version were new, so tags should have been applied to both:
        $returnedTemplateSpecTags = $basicCreatedTemplateSpecV1.Tags
        $returnedTemplateSpecVersionTags = $basicCreatedTemplateSpecV1.Versions[0].Tags

        Assert-True { AreHashtableEqual $tagsToApply $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $tagsToApply $returnedTemplateSpecVersionTags }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates that when New-AzTemplateSpec is executed with a -Tags parameter value 
and an underlying root template spec already exists, the tags are only applied to the
new template spec version specified by -Version
#>
function Test-NewAppliesTagsToOnlyVersionIfTemplateSpecExists
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId
    $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"

    try
    {
        # Prepare our RG and create a new template spec/version with tags:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $initialTemplateSpecTags = @{RootTag1="Value1"; RootTag2="Value2"}
        New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $initialTemplateSpecTags

        # Make sure tags only apply to the version on another create (overwrite):
        $tagsToApply = @{Tag1="Value1"; Tag2="Value2"}
        $updatedTemplateSpecWithV1 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $tagsToApply -Force

        $returnedTemplateSpecTags = $updatedTemplateSpecWithV1.Tags
        $returnedTemplateSpecVersionTags = $updatedTemplateSpecWithV1.Versions[0].Tags

        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $tagsToApply $returnedTemplateSpecVersionTags }

        # Delete the new version so we only have the root template spec:
        Remove-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Version "v1" -Force

        # Repeat the tags test with a new version (not an overwrite since we just deleted
        # the previous version:

        $tagsToApply = @{Tag1b="Value1b"; Tag2b="Value2b"}
        $updatedTemplateSpecWithV1 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $tagsToApply

        $returnedTemplateSpecTags = $updatedTemplateSpecWithV1.Tags
        $returnedTemplateSpecVersionTags = $updatedTemplateSpecWithV1.Versions[0].Tags

        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $tagsToApply $returnedTemplateSpecVersionTags }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates that when New-AzTemplateSpec is executed without the -Tags parameter and
the underlying root template spec already exists with tags... the parent/root template spec
tags are used for the newly created version specified by -Version (ie: The new version inherits
tags from its parent).
#>
function Test-NewAppliesInheritedTagsIfNoTagsSuppliedAndSpecExists
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId
    $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"

    try
    {
        # Prepare our RG and create a new template spec/version with tags:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $initialTemplateSpecTags = @{RootTag1="Value1"; RootTag2="Value2"}
        New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $initialTemplateSpecTags

        # Let's create another version without tags specified. It should inherit the
        # tags from the existing template spec:

        $updatedTemplateSpecWithV2 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v2" -TemplateJson $sampleTemplateJson 
        $returnedTemplateSpecTags = $updatedTemplateSpecWithV2.Tags
        $returnedTemplateSpecVersionTags = $updatedTemplateSpecWithV2.Versions[0].Tags

        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $returnedTemplateSpecTags $returnedTemplateSpecVersionTags }

        # Let's make sure if we explicitly specify no tags, we don't inherit the tags from
        # the parent template spec:

        $explicitNoTags = @{}
        $updatedTemplateSpecWithV3 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v3" -TemplateJson $sampleTemplateJson -Tag $explicitNoTags
        $returnedTemplateSpecTags = $updatedTemplateSpecWithV3.Tags
        $returnedTemplateSpecVersionTags = $updatedTemplateSpecWithV3.Versions[0].Tags

        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $explicitNoTags $returnedTemplateSpecVersionTags }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates that when New-AzTemplateSpec is executed against an already existing version 
and has the -Tags parameter set to an empty hashtable (explicit no tags), any existing 
tags on the version are removed.
#>
function Test-NewRemovesTagsFromExistingVersionIfTagsExplicitlyEmpty
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId
    $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"

    try
    {
        # Prepare our RG and create a new template spec/version with tags:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $initialTemplateSpecTags = @{RootTag1="Value1"; RootTag2="Value2"}
        $initialTemplateSpecWithV1 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $initialTemplateSpecTags

        $returnedTemplateSpecTags = $initialTemplateSpecWithV1.Tags
        $returnedTemplateSpecVersionTags = $initialTemplateSpecWithV1.Versions[0].Tags

        # Verify the tags were set:
        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $returnedTemplateSpecTags $returnedTemplateSpecVersionTags }

        # Now remove them with an explicit empty tags hashtable:
        $explicitNoTags = @{}
        $updatedTemplateSpecWithV1 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $explicitNoTags -Force

        $returnedTemplateSpecTags = $updatedTemplateSpecWithV1.Tags
        $returnedTemplateSpecVersionTags = $updatedTemplateSpecWithV1.Versions[0].Tags

        # Verify the tags were removed from the version:

        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $explicitNoTags $returnedTemplateSpecVersionTags }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates that when Set-AzTemplateSpec is executed with a -Tags parameter value 
and neither the template spec or version exist, the Tags get applied to both the 
new template spec and the new template spec version.
#>
function Test-SetAppliesTagsToBothTemplateSpecAndVersionIfNotExist
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId
    $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"

    try
    {
        # Prepare our RG and create a new template spec/version with tags:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $tagsToApply = @{Tag1="Value1"; Tag2="Value2"}
        $basicCreatedTemplateSpecV1 = Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $tagsToApply

        # Both the template spec and version were new, so tags should have been applied to both:
        $returnedTemplateSpecTags = $basicCreatedTemplateSpecV1.Tags
        $returnedTemplateSpecVersionTags = $basicCreatedTemplateSpecV1.Versions[0].Tags

        Assert-True { AreHashtableEqual $tagsToApply $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $tagsToApply $returnedTemplateSpecVersionTags }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates that when Set-AzTemplateSpec only applies tags to the version when
tag values are provided with -Tags, a -Version is specified, and the root/parent 
template spec already exists.
#>
function Test-SetAppliesTagsOnlyToVersionIfVersionSpecified
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId
    $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"

    try
    {
        # Prepare our RG and create a new template spec with tags:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $initialTemplateSpecTags = @{RootTag1="Value1"; RootTag2="Value2"}
        Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Tag $initialTemplateSpecTags

        # We have a template spec with no versions. Create a version an make sure the
        # the tags only apply to the version when -Version is present:

        $tagsToApply = @{Tag1="Value1"; Tag2="Value2"}
        $updatedTemplateSpecWithV1 = Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $tagsToApply
        $returnedTemplateSpecTags = $updatedTemplateSpecWithV1.Tags
        $returnedTemplateSpecVersionTags = $updatedTemplateSpecWithV1.Versions[0].Tags

        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $tagsToApply $returnedTemplateSpecVersionTags }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates that when Set-AzTemplateSpec applies tags only to the root template spec
when tag values are provided with -Tags and no -Version value is provided.
#>
function Test-SetAppliesTagsToTemplateSpecIfNoVersionSpecified
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId
    $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"

    try
    {
        # Prepare our RG and create a new template spec without tags:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $initialTemplateSpec = Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation
        Assert-True { AreHashtableEqual @{} $initialTemplateSpec.Tags }

        # We have a template spec with no versions. Create a version with some tags:

        $versionTagsToApply = @{Tag1="Value1"; Tag2="Value2"}
        Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $versionTagsToApply

        # Now update only the template spec tags (not the version's):
        $templateSpecTagsToApply = @{RootTag1="RootValue1"; RootTag2="RootValue2"}
        $updatedTemplateSpecWithAllVersions = Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Tag $templateSpecTagsToApply

        $returnedTemplateSpecTags = $updatedTemplateSpecWithAllVersions.Tags
        $returnedTemplateSpecVersionTags = $updatedTemplateSpecWithAllVersions.Versions[0].Tags

        Assert-True { AreHashtableEqual $templateSpecTagsToApply $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $versionTagsToApply $returnedTemplateSpecVersionTags }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates that when Set-AzTemplateSpec is executed without the -Tags parameter and
the underlying root template spec already exists with tags... the parent/root template spec
tags are used for the newly created version specified by -Version (ie: The new version inherits
tags from its parent).
#>
function Test-SetAppliesInheritedTagsIfNewVersionAndNoTagsProvidedAndSpecExists
{

    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId
    $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"

    try
    {
        # Prepare our RG and create a new template spec/version with tags:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $initialTemplateSpecTags = @{RootTag1="Value1"; RootTag2="Value2"}
        Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $initialTemplateSpecTags

        # Let's create another version without tags specified. It should inherit the
        # tags from the existing template spec:

        $updatedTemplateSpecWithV2 = Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v2" -TemplateJson $sampleTemplateJson 
        $returnedTemplateSpecTags = $updatedTemplateSpecWithV2.Tags
        $returnedTemplateSpecVersionTags = $updatedTemplateSpecWithV2.Versions[0].Tags

        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $returnedTemplateSpecTags $returnedTemplateSpecVersionTags }

        # Let's make sure if we explicitly specify no tags, we don't inherit the tags from
        # the parent template spec:

        $explicitNoTags = @{}
        $updatedTemplateSpecWithV3 = Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v3" -TemplateJson $sampleTemplateJson -Tag $explicitNoTags
        $returnedTemplateSpecTags = $updatedTemplateSpecWithV3.Tags
        $returnedTemplateSpecVersionTags = $updatedTemplateSpecWithV3.Versions[0].Tags

        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $explicitNoTags $returnedTemplateSpecVersionTags }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Validates Set-AzTemplateSpec removes tags on existing template specs/versions
when executed with -Tags set to an empty hashtable (explicit no tags).
#>
function Test-SetRemovesTagsIfTagsExplicitlyEmpty
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $rglocation = "West US 2"
    $subId = (Get-AzContext).Subscription.SubscriptionId
    $sampleTemplateJson = Get-Content -Raw -Path "sampleTemplate.json"

    try
    {
        # Prepare our RG and create a new template spec/version with tags:

        New-AzResourceGroup -Name $rgname -Location $rglocation

        $initialTemplateSpecTags = @{RootTag1="Value1"; RootTag2="Value2"}
        $initialTemplateSpecWithV1 = New-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $initialTemplateSpecTags

        $returnedTemplateSpecTags = $initialTemplateSpecWithV1.Tags
        $returnedTemplateSpecVersionTags = $initialTemplateSpecWithV1.Versions[0].Tags

        # Verify the tags were set:
        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $returnedTemplateSpecTags $returnedTemplateSpecVersionTags }

        # Attempt to remove the tags from the version:

        $explicitNoTags = @{}
        $updatedTemplateSpecWithV1 = Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Version "v1" -TemplateJson $sampleTemplateJson -Tag $explicitNoTags

        $returnedTemplateSpecTags = $updatedTemplateSpecWithV1.Tags
        $returnedTemplateSpecVersionTags = $updatedTemplateSpecWithV1.Versions[0].Tags

        # Verify the tags were removed on the version:

        Assert-True { AreHashtableEqual $initialTemplateSpecTags $returnedTemplateSpecTags }
        Assert-True { AreHashtableEqual $explicitNoTags $returnedTemplateSpecVersionTags }

        # Attempt to remove the tags from the root template spec:

        $updatedTemplateSpec = Set-AzTemplateSpec -ResourceGroupName $rgname -Name $rname -Location $rgLocation -Tag $explicitNoTags
        $returnedTemplateSpecTags = $updatedTemplateSpec.Tags

        # Verify the tags were removed on the template spec:
        Assert-True { AreHashtableEqual $explicitNoTags $returnedTemplateSpecTags }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}