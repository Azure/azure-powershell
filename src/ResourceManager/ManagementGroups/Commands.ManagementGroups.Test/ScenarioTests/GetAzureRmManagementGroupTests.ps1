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
Test Get-AzureRmManagementGroup
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

	Assert-NotNull $response
	Assert-Null $response.Children
	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
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

	$expectedChild0Id = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup3"
	$expectedChild0DisplayName = "TestPSGetGroup3"


	Assert-NotNull $response
	Assert-NotNull $response.Children

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName

	Assert-AreEqual $response.Children[0].ChildId $expectedChild0Id
	Assert-AreEqual $response.Children[0].DisplayName $expectedChild0DisplayName	
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

	$expectedChild0Id = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup3"
	$expectedChild0DisplayName = "TestPSGetGroup3"

	$expectedChild0Child0Id = "/providers/Microsoft.Management/managementGroups/TestPSGetGroup4"
	$expectedChild0Child0DisplayName = "TestPSGetGroup4"


	Assert-NotNull $response
	Assert-NotNull $response.Children

	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName

	Assert-AreEqual $response.Children[0].ChildId $expectedChild0Id
	Assert-AreEqual $response.Children[0].DisplayName $expectedChild0DisplayName	

	Assert-AreEqual $response.Children[0].Children[0].ChildId $expectedChild0Child0Id
	Assert-AreEqual $response.Children[0].Children[0].DisplayName $expectedChild0Child0DisplayName
}

