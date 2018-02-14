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
Test New-AzureRmManagementGroup
#>

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

