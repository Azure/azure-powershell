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
	$enrollmentAccountObjectId = "5479d56f-1390-4c3c-877d-fc4933baba21"
    $enrollmentAccount = Get-AzureRmEnrollmentAccount -ObjectId $enrollmentAccountObjectId

	Assert-AreEqual $enrollmentAccountObjectId $enrollmentAccount.ObjectId
	Assert-NotNull $enrollmentAccount.PrincipalName
}
