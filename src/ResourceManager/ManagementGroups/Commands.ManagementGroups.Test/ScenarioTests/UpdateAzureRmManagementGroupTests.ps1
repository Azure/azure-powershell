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
Test Update-AzureRmManagementGroup
#>

function Test-UpdateManagementGroup
{
    $response = Update-AzureRmManagementGroup -GroupName TestPSNewGroup3
	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup3"
	$expectedName = "TestPSNewGroup3"
	$expectedDisplayName = "TestPSNewGroup3"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedParentDisplayName = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"

	Assert-AreEqual $response.TenantId $expectedTenantId
	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
}

function Test-UpdateManagementGroupWithDisplayName
{
    $response = Update-AzureRmManagementGroup -GroupName TestPSNewGroup2 -DisplayName TestNewGrp2DisplayName

	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup2"
	$expectedName = "TestPSNewGroup2"
	$expectedDisplayName = "TestNewGrp2DisplayName"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedParentDisplayName = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"

	Assert-AreEqual $response.TenantId $expectedTenantId
	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
}

function Test-UpdateManagementGroupWithParentId
{
    $response = Update-AzureRmManagementGroup -GroupName TestPSNewGroup1 -ParentId /providers/Microsoft.Management/managementGroups/testGroup123

	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup1"
	$expectedName = "TestPSNewGroup1"
	$expectedDisplayName = "TestPSNewGroup1"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/testGroup123"
	$expectedParentDisplayName = "TestGroup123"

	Assert-AreEqual $response.TenantId $expectedTenantId
	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
}

function Test-UpdateManagementGroupWithDisplayNameAndParentId
{
    $response = Update-AzureRmManagementGroup -GroupName TestPSNewGroup4 -DisplayName TestNewGrp4DisplayName -ParentId /providers/Microsoft.Management/managementGroups/testGroup123

	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup4"
	$expectedName = "TestPSNewGroup4"
	$expectedDisplayName = "TestNewGrp4DisplayName"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/testGroup123"
	$expectedParentDisplayName = "TestGroup123"

	Assert-AreEqual $response.TenantId $expectedTenantId
	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
}

