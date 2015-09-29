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
    Tests the Get-AzureRmSqlCapability cmdlet
#>
function Test-Capabilities
{
	$location = "North Europe"
	$all = Get-AzureRmSqlCapability $location
	Validate-Capabilities $all
	
	$default = Get-AzureRmSqlCapability $location -Defaults
	Validate-Capabilities $default
	
	$version = Get-AzureRmSqlCapability $location -ServerVersionName "12.0"
	Validate-Capabilities $default
	
	$edition = Get-AzureRmSqlCapability $location -EditionName "Premium"
	Validate-Capabilities $default
	
	$so = Get-AzureRmSqlCapability $location -ServiceObjectiveName "S3"
	Validate-Capabilities $default

}

<# 
    .SYNOPSIS
    Validates that a LocationCapabilities object is valid and has all properties filled out
#>
function Validate-Capabilities ($capabilities)
{
	Assert-NotNull $capabilities
	Assert-AreEqual $capabilities.Status "Available"
	Assert-True {$capabilities.SupportedServerVersions.Count -gt 0}

	foreach($version in $capabilities.SupportedServerVersions) {
		Assert-NotNull $version
		Assert-NotNull $version.ServerVersionName
		Assert-NotNull $version.Status
		Assert-True {$version.SupportedEditions.Count -gt 0}

		foreach($edition in $version.SupportedEditions) {
			Assert-NotNull $edition
			Assert-NotNull $edition.EditionName
			Assert-NotNull $edition.Status
			Assert-True {$edition.SupportedServiceObjectives.Count -gt 0}
			
			foreach($so in $edition.SupportedServiceObjectives) {
				Assert-NotNull $so
				Assert-NotNull $so.ServiceObjectiveName
				Assert-NotNull $so.Status
				Assert-NotNull $so.Id
				Assert-AreNotEqual $so.Id [System.Guid]::Empty
				Assert-True {$so.SupportedMaxSizes.Count -gt 0}
			
				foreach($size in $so.SupportedMaxSizes) {
					Assert-NotNull $size
					Assert-NotNull $size.Limit
					Assert-True { $size.Limit -gt 0 }
					Assert-NotNull $size.Unit
					Assert-NotNull $size.Status
				}
			}
		}
	}
}
