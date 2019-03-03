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
Gets the values of the parameters used at the tests
#>
function Get-ManagedDataClassificationTestEnvironmentParameters ($testSuffix)
{
	return @{ rgname = "sql-dc-cmdlet-test-rg" +$testSuffix;
			  serverName = "sql-dc-cmdlet-server" +$testSuffix;
			  databaseName = "sql-dc-cmdlet-db" + $testSuffix;
		}
}

<#
.SYNOPSIS
Creates the test environment needed to perform the tests
#>
function Create-ManagedDataClassificationTestEnvironment ($testSuffix, $location = "West Central US")
{
	$params = Get-SqlDataClassificationManagedInstanceTestEnvironmentParameters $testSuffix
	Create-BasicManagedTestEnvironmentWithParams $params $location
}

<#
.SYNOPSIS
Removes the test environment that was needed to perform the tests
#>
function Remove-ManagedDataClassificationTestEnvironment ($testSuffix)
{
	$params = Get-SqlDataClassificationManagedInstanceTestEnvironmentParameters $testSuffix
	Remove-AzureRmResourceGroup -Name $params.rgname -Force
}