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

function Test-ListManagementGroups
{
    $response = Get-AzureRmManagementGroup

	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedGroupCount = 8

	$expectedIdForGroup2 = "/providers/Microsoft.Management/managementGroups/testGroup123"
	$expectedNameForGroup2 = "testGroup123"
	$expectedDisplayNameForGroup2 = "TestGroup123"

	Assert-NotNull $response

	Assert-AreEqual $response.Count $expectedGroupCount
	Assert-AreEqual $response[0].TenantId $expectedTenantId
	Assert-AreEqual $response[0].Type $expectedType

	Assert-AreEqual $response[1].TenantId $expectedTenantId
	Assert-AreEqual $response[1].Type $expectedType
	Assert-AreEqual $response[1].Id $expectedIdForGroup2
	Assert-AreEqual $response[1].Name $expectedNameForGroup2
	Assert-AreEqual $response[1].DisplayName $expectedDisplayNameForGroup2
}

function Test-GetManagementGroup
{
	$response = Get-AzureRmManagementGroup -GroupName testGroup123

	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/testGroup123"
	$expectedName = "testGroup123"
	$expectedDisplayName = "TestGroup123"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedParentDisplayName = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"

	Assert-NotNull $response
	Assert-Null $response.Children
	Assert-AreEqual $response.TenantId $expectedTenantId
	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName
}

function Test-GetManagementGroupWithExpand
{
	$response = Get-AzureRmManagementGroup -GroupName testGroup123 -Expand

	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/testGroup123"
	$expectedName = "testGroup123"
	$expectedDisplayName = "TestGroup123"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedParentDisplayName = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"

	$expectedChild0Id = "/providers/Microsoft.Management/managementGroups/testGroup123Child1"
	$expectedChild0DisplayName = "TestGroup123->Child1"

	$expectedChild1Id = "/subscriptions/394ae65d-9e71-4462-930f-3332dedf845c"
	$expectedChild1DisplayName = "Pay-As-You-Go"


	Assert-NotNull $response
	Assert-NotNull $response.Children

	Assert-AreEqual $response.TenantId $expectedTenantId
	Assert-AreEqual $response.Type $expectedType
	Assert-AreEqual $response.Id $expectedId
	Assert-AreEqual $response.Name $expectedName
	Assert-AreEqual $response.DisplayName $expectedDisplayName
	Assert-AreEqual $response.ParentId $expectedParentId
	Assert-AreEqual $response.ParentDisplayName $expectedParentDisplayName

	Assert-AreEqual $response.Children[0].ChildId $expectedChild0Id
	Assert-AreEqual $response.Children[0].DisplayName $expectedChild0DisplayName	

	Assert-AreEqual $response.Children[1].ChildId $expectedChild1Id
	Assert-AreEqual $response.Children[1].DisplayName $expectedChild1DisplayName
}

function Test-GetManagementGroupWithExpandAndRecurse
{
	$response = Get-AzureRmManagementGroup -GroupName testGroup123 -Expand -Recurse

	$expectedTenantId = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedType =  "/providers/Microsoft.Management/managementGroups"
	$expectedId = "/providers/Microsoft.Management/managementGroups/testGroup123"
	$expectedName = "testGroup123"
	$expectedDisplayName = "TestGroup123"
	$expectedParentId = "/providers/Microsoft.Management/managementGroups/6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"
	$expectedParentDisplayName = "6b2064b9-34bd-46e6-9092-52f2dd5f7fc0"

	$expectedChild0Id = "/providers/Microsoft.Management/managementGroups/testGroup123Child1"
	$expectedChild0DisplayName = "TestGroup123->Child1"

	$expectedChild0Child0Id = "/providers/Microsoft.Management/managementGroups/testGroup123Child1Child1"
	$expectedChild0Child0DisplayName = "TestGroup123->Child1->Child1"


	Assert-NotNull $response
	Assert-NotNull $response.Children

	Assert-AreEqual $response.TenantId $expectedTenantId
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

