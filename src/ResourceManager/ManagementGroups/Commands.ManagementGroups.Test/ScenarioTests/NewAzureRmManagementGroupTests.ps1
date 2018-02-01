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
    $response = New-AzureRmManagementGroup -GroupName TestPSNewGroup4
	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup4"
	$expectedName = "TestPSNewGroup4"
	$expectedDisplayName = "TestPSNewGroup4"

	Assert-AreEqual $response.TenantId $expectedTenantId
	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-Null $response.ParentId 
	Assert-Null $response.ParentDisplayName 
}

function Test-NewManagementGroupWithDisplayName
{
    $response = New-AzureRmManagementGroup -GroupName TestPSNewGroup1 -DisplayName TestNewGrp1DisplayName

	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup1"
	$expectedName = "TestPSNewGroup1"
	$expectedDisplayName = "TestNewGrp1DisplayName"

	Assert-AreEqual $response.TenantId $expectedTenantId
	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-Null $response.ParentId 
	Assert-Null $response.ParentDisplayName 
}

function Test-NewManagementGroupWithParentId
{
    $response = New-AzureRmManagementGroup -GroupName TestPSNewGroup2 -ParentId /providers/Microsoft.Management/managementGroups/testGroup123

	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup2"
	$expectedName = "TestPSNewGroup2"
	$expectedDisplayName = "TestPSNewGroup2"
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

function Test-NewManagementGroupWithDisplayNameAndParentId
{
    $response = New-AzureRmManagementGroup -GroupName TestPSNewGroup3 -DisplayName TestNewGrp3DisplayName -ParentId /providers/Microsoft.Management/managementGroups/testGroup123

	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/TestPSNewGroup3"
	$expectedName = "TestPSNewGroup3"
	$expectedDisplayName = "TestNewGrp3DisplayName"
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

