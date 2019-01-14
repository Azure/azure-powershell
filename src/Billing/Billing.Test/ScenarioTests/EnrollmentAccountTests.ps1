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

# NOTE: This test requires manual setup in your current environment. The following is required:
# 1. An enrollment account in EA. Please go to http://ea.azure.com/ to add and manage enrollment accounts.
# 2. Run your test as either a user with an enrollment in EA.
#    2b. Alternatively, you can grant a service principal access to your enrollment account using RBAC by running the following:
#           New-AzureRmRoleAssignment -Scope /providers/Microsoft.Billing/enrollmentAccounts/<object id of the user with an enrollment in EA> -RoleDefinitionName Contributor -ServicePrincipalName <SPN>
#        You can then run the tests below using this service principal.

<#
.SYNOPSIS
List billing periods
#>
function Test-ListEnrollmentAccounts
{
    $enrollmentAccounts = Get-AzureRmEnrollmentAccount

    Assert-True {$enrollmentAccounts.Count -ge 1}
	Assert-NotNull $enrollmentAccounts[0].ObjectId
	Assert-NotNull $enrollmentAccounts[0].PrincipalName
}

<#
.SYNOPSIS
Get billing period with specified name
#>
function Test-GetEnrollmentAccountWithName
{
    $enrollmentAccounts = @(Get-AzureRmEnrollmentAccount)

	$enrollmentAccountObjectId = $enrollmentAccounts[0].ObjectId
    $enrollmentAccount = Get-AzureRmEnrollmentAccount -ObjectId $enrollmentAccountObjectId

	Assert-AreEqual $enrollmentAccountObjectId $enrollmentAccount.ObjectId
	Assert-NotNull $enrollmentAccount.PrincipalName
}
