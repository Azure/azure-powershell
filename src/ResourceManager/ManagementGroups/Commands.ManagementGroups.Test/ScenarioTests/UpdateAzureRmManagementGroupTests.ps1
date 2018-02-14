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

