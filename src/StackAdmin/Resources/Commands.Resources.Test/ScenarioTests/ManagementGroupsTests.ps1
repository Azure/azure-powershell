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
	New-AzureRmManagementGroup -GroupName TestPSGetGroup1
	New-AzureRmManagementGroup -GroupName TestPSGetGroup2 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup1"

	$response = Get-AzureRmManagementGroup -GroupName TestPSGetGroup2

	Remove-AzureRmManagementGroup -GroupName TestPSGetGroup2
	Remove-AzureRmManagementGroup -GroupName TestPSGetGroup1

	$expectedType =  "/providers/Microsoft.Management/managementGroups"
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
	New-AzureRmManagementGroup -GroupName TestPSGetGroup1
	New-AzureRmManagementGroup -GroupName TestPSGetGroup2 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup1"
	New-AzureRmManagementGroup -GroupName TestPSGetGroup3 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup2"

	$response = Get-AzureRmManagementGroup -GroupName TestPSGetGroup2 -Expand

	Remove-AzureRmManagementGroup -GroupName TestPSGetGroup3
	Remove-AzureRmManagementGroup -GroupName TestPSGetGroup2
	Remove-AzureRmManagementGroup -GroupName TestPSGetGroup1

	$expectedType =  "/providers/Microsoft.Management/managementGroups"
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
	New-AzureRmManagementGroup -GroupName TestPSGetGroup1
	New-AzureRmManagementGroup -GroupName TestPSGetGroup2 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup1"
	New-AzureRmManagementGroup -GroupName TestPSGetGroup3 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup2"
	New-AzureRmManagementGroup -GroupName TestPSGetGroup4 -ParentId "/providers/Microsoft.Management/managementGroups/TestPSGetGroup3"

	$response = Get-AzureRmManagementGroup -GroupName TestPSGetGroup2 -Expand -Recurse

	Remove-AzureRmManagementGroup -GroupName TestPSGetGroup4
	Remove-AzureRmManagementGroup -GroupName TestPSGetGroup3
	Remove-AzureRmManagementGroup -GroupName TestPSGetGroup2
	Remove-AzureRmManagementGroup -GroupName TestPSGetGroup1

	$expectedType =  "/providers/Microsoft.Management/managementGroups"
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
    $response = New-AzureRmManagementGroup -GroupName TestPSNewGroup
	Remove-AzureRmManagementGroup -GroupName TestPSNewGroup

	$expectedType =  "/providers/Microsoft.Management/managementGroups"
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
    $response = New-AzureRmManagementGroup -GroupName TestPSNewGroup2 -DisplayName TestDisplayName
	Remove-AzureRmManagementGroup -GroupName TestPSNewGroup2

	$expectedType =  "/providers/Microsoft.Management/managementGroups"
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
	New-AzureRmManagementGroup -GroupName TestParent5
    $response = New-AzureRmManagementGroup -GroupName TestPSNewGroup5 -ParentId /providers/Microsoft.Management/managementGroups/TestParent5
	Remove-AzureRmManagementGroup -GroupName TestPSNewGroup5
	Remove-AzureRmManagementGroup -GroupName TestParent5

	$expectedType =  "/providers/Microsoft.Management/managementGroups"
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
	New-AzureRmManagementGroup -GroupName TestParent4
    $response = New-AzureRmManagementGroup -GroupName TestPSGroup4 -DisplayName TestDisplayName -ParentId /providers/Microsoft.Management/managementGroups/TestParent4
	Remove-AzureRmManagementGroup -GroupName TestPSGroup4
	Remove-AzureRmManagementGroup -GroupName TestParent4

	$expectedType =  "/providers/Microsoft.Management/managementGroups"
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
	New-AzureRmManagementGroup -GroupName TestPSUpdateGroup1
    $response = Update-AzureRmManagementGroup -GroupName TestPSUpdateGroup1 -DisplayName TestDisplayName
	Remove-AzureRmManagementGroup -GroupName TestPSUpdateGroup1

	$expectedType =  "/providers/Microsoft.Management/managementGroups"
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
	New-AzureRmManagementGroup -GroupName TestPSUpdateGroupParent2
	New-AzureRmManagementGroup -GroupName TestPSUpdateGroup2
    $response = Update-AzureRmManagementGroup -GroupName TestPSUpdateGroup2 -ParentId /providers/Microsoft.Management/managementGroups/TestPSUpdateGroupParent2
	Remove-AzureRmManagementGroup -GroupName TestPSUpdateGroup2
	Remove-AzureRmManagementGroup -GroupName TestPSUpdateGroupParent2

	$expectedType =  "/providers/Microsoft.Management/managementGroups"
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
	New-AzureRmManagementGroup -GroupName TestPSUpdateGroupParent3
	New-AzureRmManagementGroup -GroupName TestPSUpdateGroup3
    $response = Update-AzureRmManagementGroup -GroupName TestPSUpdateGroup3 -DisplayName TestDisplayName -ParentId /providers/Microsoft.Management/managementGroups/TestPSUpdateGroupParent3
	Remove-AzureRmManagementGroup -GroupName TestPSUpdateGroup3
	Remove-AzureRmManagementGroup -GroupName TestPSUpdateGroupParent3

	$expectedType =  "/providers/Microsoft.Management/managementGroups"
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
	New-AzureRmManagementGroup -GroupName TestPSRemoveGroup
	
	$getresponse = Get-AzureRmManagementGroup -GroupName TestPSRemoveGroup

    $response = Remove-AzureRmManagementGroup -GroupName TestPSRemoveGroup

	$getresponse2 = Get-AzureRmManagementGroup -GroupName TestPSRemoveGroup

	Assert-NotNull $getresponse
	Assert-Null $getresponse2
	Assert-Null $response
}

function Test-NewRemoveManagementGroupSubscription
{
	New-AzureRmManagementGroup -GroupName TestSubGroup

	$response1 = New-AzureRmManagementGroupSubscription -GroupName TestSubGroup -SubscriptionId 394ae65d-9e71-4462-930f-3332dedf845c

	$getresponse = Get-AzureRmManagementGroup -GroupName TestSubGroup -Expand

	$response2 = Remove-AzureRmManagementGroupSubscription -GroupName TestSubGroup -SubscriptionId 394ae65d-9e71-4462-930f-3332dedf845c
	
	$getresponse2 = Get-AzureRmManagementGroup -GroupName TestSubGroup -Expand

	Remove-AzureRmManagementGroup -GroupName TestSubGroup

	$expectedType =  "/subscriptions"
	$expectedId = "/subscriptions/394ae65d-9e71-4462-930f-3332dedf845c"
	$expectedName = "394ae65d-9e71-4462-930f-3332dedf845c"
	$expectedDisplayName = "Pay-As-You-Go"

	Assert-AreEqual $getresponse.Children[0].Type $expectedType
	Assert-AreEqual $getresponse.Children[0].Id $expectedId
	Assert-AreEqual $getresponse.Children[0].DisplayName $expectedDisplayName
	Assert-AreEqual $getresponse.Children[0].Name $expectedName

	Assert-Null $response1
	Assert-Null $response2
	Assert-Null $getresponse2.Children
}

