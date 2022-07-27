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
ManagementGroupsTests
#>

function Test-GetManagementGroup
{
	New-AzManagementGroup -GroupName TestPSGetGroup1
	New-AzManagementGroup -GroupName TestPSGetGroup2 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup1"

	$response = Get-AzManagementGroup -GroupName TestPSGetGroup2

	#Remove-AzManagementGroup -GroupName TestPSGetGroup2
	#Remove-AzManagementGroup -GroupName TestPSGetGroup1

	$expectedType =  "Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup2"
	$expectedName = "TestPSGetGroup2"
	$expectedDisplayName = "TestPSGetGroup2"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup1"
	$expectedParentDisplayName = "TestPSGetGroup1"
	$expectedParentName = "TestPSGetGroup1"

	Assert-NotNull $response
	Assert-Null $response.Children
	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
	Assert-AreEqual $response.ParentName $expectedParentName
}

function Test-GetManagementGroupWithExpand
{
	New-AzManagementGroup -GroupName TestPSGetGroup1
	New-AzManagementGroup -GroupName TestPSGetGroup2 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup1"
	New-AzManagementGroup -GroupName TestPSGetGroup3 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup2"

	$response = Get-AzManagementGroup -GroupName TestPSGetGroup2 -Expand

	Remove-AzManagementGroup -GroupName TestPSGetGroup3
	Remove-AzManagementGroup -GroupName TestPSGetGroup2
	Remove-AzManagementGroup -GroupName TestPSGetGroup1

	$expectedType =  "Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup2"
	$expectedName = "TestPSGetGroup2"
	$expectedDisplayName = "TestPSGetGroup2"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup1"
	$expectedParentDisplayName = "TestPSGetGroup1"
	$expectedParentName = "TestPSGetGroup1"

	$expectedChild0Id = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup3"
	$expectedChild0DisplayName = "TestPSGetGroup3"
	$expectedChild0Name = "TestPSGetGroup3"

	Assert-NotNull $response
	Assert-NotNull $response.Children

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
	Assert-AreEqual $response.ParentName $expectedParentName

	Assert-AreEqual $response.Children[0].Type $expectedType
	Assert-AreEqual $response.Children[0].Id $expectedChild0Id
	Assert-AreEqual $response.Children[0].DisplayName $expectedChild0DisplayName
	Assert-AreEqual $response.Children[0].Name $expectedChild0Name
}

function Test-GetManagementGroupWithExpandAndRecurse
{
	New-AzManagementGroup -GroupName TestPSGetGroup1
	New-AzManagementGroup -GroupName TestPSGetGroup2 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup1"
	New-AzManagementGroup -GroupName TestPSGetGroup3 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup2"
	New-AzManagementGroup -GroupName TestPSGetGroup4 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup3"

	$response = Get-AzManagementGroup -GroupName TestPSGetGroup2 -Expand -Recurse

	Remove-AzManagementGroup -GroupName TestPSGetGroup4
	Remove-AzManagementGroup -GroupName TestPSGetGroup3
	Remove-AzManagementGroup -GroupName TestPSGetGroup2
	Remove-AzManagementGroup -GroupName TestPSGetGroup1

	$expectedType =  "Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup2"
	$expectedName = "TestPSGetGroup2"
	$expectedDisplayName = "TestPSGetGroup2"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup1"
	$expectedParentDisplayName = "TestPSGetGroup1"
	$expectedParentName = "TestPSGetGroup1"

	$expectedChild0Id = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup3"
	$expectedChild0DisplayName = "TestPSGetGroup3"
	$expectedChild0Name = "TestPSGetGroup3"

	$expectedChild0Child0Id = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup4"
	$expectedChild0Child0DisplayName = "TestPSGetGroup4"
	$expectedChild0Child0Name = "TestPSGetGroup4"

	Assert-NotNull $response
	Assert-NotNull $response.Children

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
	Assert-AreEqual $response.ParentName $expectedParentName

	Assert-AreEqual $response.Children[0].Type $expectedType
	Assert-AreEqual $response.Children[0].Id $expectedChild0Id
	Assert-AreEqual $response.Children[0].DisplayName $expectedChild0DisplayName
	Assert-AreEqual $response.Children[0].Name $expectedChild0Name

	Assert-AreEqual $response.Children[0].Children[0].Type $expectedType
	Assert-AreEqual $response.Children[0].Children[0].Id $expectedChild0Child0Id
	Assert-AreEqual $response.Children[0].Children[0].DisplayName $expectedChild0Child0DisplayName
	Assert-AreEqual $response.Children[0].Children[0].Name $expectedChild0Child0Name
}

function Test-NewManagementGroup
{
    $response = New-AzManagementGroup -GroupName TestPSNewGroup
	Remove-AzManagementGroup -GroupName TestPSNewGroup

	$expectedType =  "Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup"
	$expectedName = "TestPSNewGroup"
	$expectedDisplayName = "TestPSNewGroup"

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-NotNull $response.ParentId 
	Assert-NotNull $response.ParentDisplayName 

}

function Test-NewManagementGroupWithDisplayName
{
    $response = New-AzManagementGroup -GroupName TestPSNewGroup2 -DisplayName TestDisplayName
	Remove-AzManagementGroup -GroupName TestPSNewGroup2

	$expectedType =  "Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup2"
	$expectedName = "TestPSNewGroup2"
	$expectedDisplayName = "TestDisplayName"

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-NotNull $response.ParentId 
	Assert-NotNull $response.ParentDisplayName 
}

function Test-NewManagementGroupWithParentId
{
	New-AzManagementGroup -GroupName TestParent5
    $response = New-AzManagementGroup -GroupName TestPSNewGroup5 -ParentId /providers/Microsoft.Management/managementGroups/TestParent5
	Remove-AzManagementGroup -GroupName TestPSNewGroup5
	Remove-AzManagementGroup -GroupName TestParent5

	$expectedType =  "Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup5"
	$expectedName = "TestPSNewGroup5"
	$expectedDisplayName = "TestPSNewGroup5"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/TestParent5"
	$expectedParentDisplayName = "TestParent5"

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
}

function Test-NewManagementGroupWithDisplayNameAndParentId
{
	New-AzManagementGroup -GroupName TestParent4
    $response = New-AzManagementGroup -GroupName TestPSGroup4 -DisplayName TestDisplayName -ParentId /providers/Microsoft.Management/managementGroups/TestParent4
	Remove-AzManagementGroup -GroupName TestPSGroup4
	Remove-AzManagementGroup -GroupName TestParent4

	$expectedType =  "Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSGroup4"
	$expectedName = "TestPSGroup4"
	$expectedDisplayName = "TestDisplayName"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/TestParent4"
	$expectedParentDisplayName = "TestParent4"

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
}

function Test-UpdateManagementGroupWithDisplayName
{
	New-AzManagementGroup -GroupName TestPSUpdateGroup1
    $response = Update-AzManagementGroup -GroupName TestPSUpdateGroup1 -DisplayName TestDisplayName
	Remove-AzManagementGroup -GroupName TestPSUpdateGroup1

	$expectedType =  "Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSUpdateGroup1"
	$expectedName = "TestPSUpdateGroup1"
	$expectedDisplayName = "TestDisplayName"

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
}

function Test-UpdateManagementGroupWithParentId
{
	New-AzManagementGroup -GroupName TestPSUpdateGroupParent2
	New-AzManagementGroup -GroupName TestPSUpdateGroup2
    $response = Update-AzManagementGroup -GroupName TestPSUpdateGroup2 -ParentId /providers/Microsoft.Management/managementGroups/TestPSUpdateGroupParent2
	Remove-AzManagementGroup -GroupName TestPSUpdateGroup2
	Remove-AzManagementGroup -GroupName TestPSUpdateGroupParent2

	$expectedType =  "Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSUpdateGroup2"
    $expectedName = "TestPSUpdateGroup2"
	$expectedDisplayName = "TestPSUpdateGroup2"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/TestPSUpdateGroupParent2"
	$expectedParentDisplayName = "TestPSUpdateGroupParent2"

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
}

function Test-UpdateManagementGroupWithDisplayNameAndParentId
{
	New-AzManagementGroup -GroupName TestPSUpdateGroupParent3
	New-AzManagementGroup -GroupName TestPSUpdateGroup3
    $response = Update-AzManagementGroup -GroupName TestPSUpdateGroup3 -DisplayName TestDisplayName -ParentId /providers/Microsoft.Management/managementGroups/TestPSUpdateGroupParent3
	Remove-AzManagementGroup -GroupName TestPSUpdateGroup3
	Remove-AzManagementGroup -GroupName TestPSUpdateGroupParent3

	$expectedType =  "Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSUpdateGroup3"
	$expectedName = "TestPSUpdateGroup3"
	$expectedDisplayName = "TestDisplayName"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/TestPSUpdateGroupParent3"
	$expectedParentDisplayName = "TestPSUpdateGroupParent3"

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
}

function Test-RemoveManagementGroup
{
	New-AzManagementGroup -GroupName TestPSRemoveGroup
	
	$getresponse = Get-AzManagementGroup -GroupName TestPSRemoveGroup

    $response = Remove-AzManagementGroup -GroupName TestPSRemoveGroup

	Assert-NotNull $getresponse
	Assert-Null $response
}

function Test-NewRemoveManagementGroupSubscription
{
	New-AzManagementGroup -GroupName TestSubGroup

	$newMGSub = New-AzManagementGroupSubscription -GroupName TestSubGroup -SubscriptionId 5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de

	$getresponse = Get-AzManagementGroup -GroupName TestSubGroup -Expand

	$response2 = Remove-AzManagementGroupSubscription -GroupName TestSubGroup -SubscriptionId 5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de
	
	$getresponse2 = Get-AzManagementGroup -GroupName TestSubGroup -Expand

	#Remove-AzManagementGroup -GroupName TestSubGroup

	$expectedType =  "Microsoft.Management/managementGroups/subscriptions"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestSubGroup/subscriptions/5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de"
	$expectedDisplayName = "Visual Studio Enterprise Subscription"
    $expectedParent = "/providers/Microsoft.Management/managementGroups/TestSubGroup"
    $expectedState = "Active"
    $expectedTenant = "c7a87cda-9a66-4920-b0f8-869baa04efe0"

	Assert-AreEqual $newMGSub.Type $expectedType
	Assert-AreEqual $newMGSub.Id $expectedId
	Assert-AreEqual $newMGSub.DisplayName $expectedDisplayName
    Assert-AreEqual $newMGSub.Parent $expectedParent
    Assert-AreEqual $newMGSub.State $expectedState
    Assert-AreEqual $newMGSub.Tenant $expectedTenant

	#Assert-Null $response1
	#Assert-Null $response2
	#Assert-Null $getresponse2.Children
}

function Test-GetManagementGroupSubscription 
{
    New-AzManagementGroup -GroupName TestSubGroup

	New-AzManagementGroupSubscription -GroupName TestSubGroup -SubscriptionId 5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de

	Get-AzManagementGroup -GroupName TestSubGroup -Expand

    $getSub = Get-AzManagementGroupSubscription -GroupName TestSubGroup -SubscriptionId 5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de

	Remove-AzManagementGroupSubscription -GroupName TestSubGroup -SubscriptionId 5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de

	#Remove-AzManagementGroup -GroupName TestSubGroup

	$expectedType =  "Microsoft.Management/managementGroups/subscriptions"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestSubGroup/subscriptions/5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de"
	$expectedDisplayName = "Visual Studio Enterprise Subscription"
    $expectedParent = "/providers/Microsoft.Management/managementGroups/TestSubGroup"
    $expectedState = "Active"
    $expectedTenant = "c7a87cda-9a66-4920-b0f8-869baa04efe0"

	Assert-AreEqual $getSub.Type $expectedType
	Assert-AreEqual $getSub.Id $expectedId
	Assert-AreEqual $getSub.DisplayName $expectedDisplayName
    Assert-AreEqual $getSub.Parent $expectedParent
    Assert-AreEqual $getSub.State $expectedState
    Assert-AreEqual $getSub.Tenant $expectedTenant

	#Assert-Null $response1
	#Assert-Null $response2
	#Assert-Null $getresponse2.Children   
}

function Test-GetSubscriptionsUnderManagementGroup 
{
    New-AzManagementGroup -GroupName TestSubGroup1

	New-AzManagementGroupSubscription -GroupName TestSubGroup1 -SubscriptionId 5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de

	Get-AzManagementGroup -GroupName TestSubGroup1 -Expand

    $getSubsUnderMG = Get-AzManagementGroupSubscription -GroupName TestSubGroup1

	Remove-AzManagementGroupSubscription -GroupName TestSubGroup1 -SubscriptionId 5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de

    $expectedType =  "Microsoft.Management/managementGroups/subscriptions"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestSubGroup1/subscriptions/5602fbd9-fb0d-4fbb-98b3-10c8ea20b6de"
	$expectedDisplayName = "Visual Studio Enterprise Subscription"
    $expectedParent = "/providers/Microsoft.Management/managementGroups/TestSubGroup1"
    $expectedState = "Active"
    $expectedTenant = "c7a87cda-9a66-4920-b0f8-869baa04efe0"

    Assert-AreEqual $getSubsUnderMG[0].Type $expectedType
	Assert-AreEqual $getSubsUnderMG[0].Id $expectedId
	Assert-AreEqual $getSubsUnderMG[0].DisplayName $expectedDisplayName
    Assert-AreEqual $getSubsUnderMG[0].Parent $expectedParent
    Assert-AreEqual $getSubsUnderMG[0].State $expectedState
    Assert-AreEqual $getSubsUnderMG[0].Tenant $expectedTenant
}

function Test-GetEntities 
{
    $response = Get-AzManagementGroupEntity
    
    $expectedDisplayName = "Root Management Group"
    $expectedId = "/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0"
    $expectedName = "c7a87cda-9a66-4920-b0f8-869baa04efe0"
    $expectedType = "Microsoft.Management/managementGroups"
    
    Assert-NotNull $response

    Assert-AreEqual $response[0].DisplayName $expectedDisplayName
    Assert-AreEqual $response[0].Id $expectedId
    Assert-AreEqual $response[0].Name $expectedName
    Assert-AreEqual $response[0].TenantId $expectedName
    Assert-AreEqual $response[0].Type $expectedType

    Assert-Null $response[0].Parent
}

function Test-CheckNameAvailabilityTrue
{
    $nameAvailabilityResult = Get-AzManagementGroupNameAvailability -GroupName TestMG

    $expectedResult = $true

    Assert-AreEqual $nameAvailabilityResult.NameAvailable $expectedResult
}

function Test-CheckNameAvailabilityFalse
{
    $nameAvailabilityResult = Get-AzManagementGroupNameAvailability -GroupName testMG3

    $expectedResult = $false
    $expectedReason = "AlreadyExists"
    $expectedMessage = "The group with the specified name already exists"

    Assert-AreEqual $nameAvailabilityResult.NameAvailable $expectedResult
    Assert-AreEqual $nameAvailabilityResult.Reason $expectedReason
    Assert-AreEqual $nameAvailabilityResult.Message $expectedMessage
}

function Test-CheckNameWithInvalidCharacters
{
    $nameAvailabilityResult = Get-AzManagementGroupNameAvailability -GroupName testMG3!

    $expectedResult = $false
    $expectedReason = "Invalid"
    $expectedMessage = "The provided management group name 'testMG3!' has these invalid characters: '!'. The name can only be an ASCII letter, digit, -, _, (, ), ."

    Assert-AreEqual $nameAvailabilityResult.NameAvailable $expectedResult
    Assert-AreEqual $nameAvailabilityResult.Reason $expectedReason
    Assert-AreEqual $nameAvailabilityResult.Message $expectedMessage
}

function Test-GetTenantBackfillStatus
{
	$getBackfillStatusResult = Get-AzTenantBackfillStatus

    $expectedTenantId = "c7a87cda-9a66-4920-b0f8-869baa04efe0"
    $expectedStatus = "Completed"

    Assert-AreEqual $getBackfillStatusResult.TenantId $expectedTenantId
    Assert-AreEqual $getBackfillStatusResult.Status $expectedStatus
}

function Test-StartTenantBackfill
{
    $startBackfillResult = Start-AzTenantBackfill

    $expectedTenantId = "c7a87cda-9a66-4920-b0f8-869baa04efe0"
    $expectedStatus = "Completed"

    Assert-AreEqual $startBackfillResult.TenantId $expectedTenantId
    Assert-AreEqual $startBackfillResult.Status $expectedStatus
}

function Test-NewAuthHierarchySetting 
{
    $newHierarchySetting = New-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -Authorization $true

    Remove-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0

    $expectedId = "/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default"
    $expectedType = "Microsoft.Management/managementGroups/settings"
    $expectedName = "default"
    $expectedTenant = "c7a87cda-9a66-4920-b0f8-869baa04efe0"
    $expectedAuth = $true

    Assert-NotNull $newHierarchySetting

    Assert-AreEqual $newHierarchySetting.Id $expectedId
    Assert-AreEqual $newHierarchySetting.Type $expectedType
    Assert-AreEqual $newHierarchySetting.Name $expectedName
    Assert-AreEqual $newHierarchySetting.TenantId $expectedTenant
    Assert-AreEqual $newHierarchySetting.RequireAuthorizationForGroupCreation $expectedAuth
}

function Test-NewDefaultMGHierarcySetting
{
    New-AzManagementGroup -GroupName defaultMG
    
    $newHierarchySetting = New-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -DefaultMG "/providers/Microsoft.Management/managementGroups/defaultMG"

    Remove-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0

    $expectedId = "/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default"
    $expectedType = "Microsoft.Management/managementGroups/settings"
    $expectedName = "default"
    $expectedTenant = "c7a87cda-9a66-4920-b0f8-869baa04efe0"
    $expecteddefaultMG = "defaultMG"

    Assert-NotNull $newHierarchySetting

    Assert-AreEqual $newHierarchySetting.Id $expectedId
    Assert-AreEqual $newHierarchySetting.Type $expectedType
    Assert-AreEqual $newHierarchySetting.Name $expectedName
    Assert-AreEqual $newHierarchySetting.TenantId $expectedTenant
    Assert-AreEqual $newHierarchySetting.DefaultManagementGroup $expecteddefaultMG
}

function Test-NewHierarchySettings
{
    New-AzManagementGroup -GroupName defaultMG
    
    $newHierarchySetting = New-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -Authorization $true -DefaultMG "/providers/Microsoft.Management/managementGroups/defaultMG"

    Remove-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0

    $expectedId = "/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default"
    $expectedType = "Microsoft.Management/managementGroups/settings"
    $expectedName = "default"
    $expectedTenant = "c7a87cda-9a66-4920-b0f8-869baa04efe0"
    $expecteddefaultMG = "defaultMG"
    $expectedAuth = $true

    Assert-NotNull $newHierarchySetting

    Assert-AreEqual $newHierarchySetting.Id $expectedId
    Assert-AreEqual $newHierarchySetting.Type $expectedType
    Assert-AreEqual $newHierarchySetting.Name $expectedName
    Assert-AreEqual $newHierarchySetting.TenantId $expectedTenant
    Assert-AreEqual $newHierarchySetting.RequireAuthorizationForGroupCreation $expectedAuth
    Assert-AreEqual $newHierarchySetting.DefaultManagementGroup $expecteddefaultMG
}

function Test-RemoveHierarchySetting
{
    New-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -Authorization $true
    
    Remove-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0
}

function Test-UpdateAuthHierarchySetting
{
    New-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -Authorization $false
    
    $updateHierarchySetting = Update-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -Authorization $true

    Remove-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0

    $expectedId = "/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default"
    $expectedType = "Microsoft.Management/managementGroups/settings"
    $expectedName = "default"
    $expectedTenant = "c7a87cda-9a66-4920-b0f8-869baa04efe0"
    $expectedAuth = $true

    Assert-NotNull $updateHierarchySetting

    Assert-AreEqual $updateHierarchySetting.Id $expectedId
    Assert-AreEqual $updateHierarchySetting.Type $expectedType
    Assert-AreEqual $updateHierarchySetting.Name $expectedName
    Assert-AreEqual $updateHierarchySetting.TenantId $expectedTenant
    Assert-AreEqual $updateHierarchySetting.RequireAuthorizationForGroupCreation $expectedAuth
}

function Test-UpdateAuthHierarchySetting
{
    New-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -DefaultMG "/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0"

    New-AzManagementGroup -GroupName defaultMG
    
    $updateHierarchySetting = Update-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -DefaultMG "/providers/Microsoft.Management/managementGroups/defaultMG"

    Remove-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0

    $expectedId = "/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default"
    $expectedType = "Microsoft.Management/managementGroups/settings"
    $expectedName = "default"
    $expectedTenant = "c7a87cda-9a66-4920-b0f8-869baa04efe0"
    $expecteddefaultMG = "defaultMG"

    Assert-NotNull $updateHierarchySetting

    Assert-AreEqual $updateHierarchySetting.Id $expectedId
    Assert-AreEqual $updateHierarchySetting.Type $expectedType
    Assert-AreEqual $updateHierarchySetting.Name $expectedName
    Assert-AreEqual $updateHierarchySetting.TenantId $expectedTenant
    Assert-AreEqual $updateHierarchySetting.DefaultManagementGroup $expecteddefaultMG
}

function Test-UpdateBothHierarchySettings
{
    New-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -Authorization $false -DefaultMG "/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0"

    New-AzManagementGroup -GroupName defaultMG
    
    $updateHierarchySetting = Update-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0 -Authorization $true -DefaultMG "/providers/Microsoft.Management/managementGroups/defaultMG"

    Remove-AzManagementGroupHierarchySetting -GroupName c7a87cda-9a66-4920-b0f8-869baa04efe0

    $expectedId = "/providers/Microsoft.Management/managementGroups/c7a87cda-9a66-4920-b0f8-869baa04efe0/settings/default"
    $expectedType = "Microsoft.Management/managementGroups/settings"
    $expectedName = "default"
    $expectedTenant = "c7a87cda-9a66-4920-b0f8-869baa04efe0"
    $expecteddefaultMG = "defaultMG"
    $expectedAuth = $true

    Assert-NotNull $updateHierarchySetting

    Assert-AreEqual $updateHierarchySetting.Id $expectedId
    Assert-AreEqual $updateHierarchySetting.Type $expectedType
    Assert-AreEqual $updateHierarchySetting.Name $expectedName
    Assert-AreEqual $updateHierarchySetting.TenantId $expectedTenant
    Assert-AreEqual $updateHierarchySetting.DefaultManagementGroup $expecteddefaultMG
    Assert-AreEqual $updateHierarchySetting.RequireAuthorizationForGroupCreation $expectedAuth
}

