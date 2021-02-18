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
Tests an error is raised when setting an empty policy
#>
function Test-ErrorWhenSettingAnEmptyPolicy
{
	$message = "The provided policy definition is empty."
	Assert-Throws {Set-AzSqlInformationProtectionPolicy -FilePath "SqlInformationProtectionPolicies\Empty.json" } $message
}

<#
.SYNOPSIS
Tests an error is raised when setting a policy containing a label and an information type sharing same id.
#>
function Test-ErrorWhenInformationTypeAndSensitivityLabelShareSameId
{
	$message = "Ids should be unique. Please eliminate duplication of these ids: '50e58766-ab53-4846-be8a-35e0bb87723e'."
	Assert-Throws {Set-AzSqlInformationProtectionPolicy -FilePath "SqlInformationProtectionPolicies\InformationTypeAndSensitivityLabelSharingSameId.json" } $message
}

<#
.SYNOPSIS
Tests an error is raised when setting a policy containing information types sharing same display name.
#>
function Test-ErrorWhenInformationTypesShareSameDisplayName
{
	$message = "Display names should be unique. Please eliminate duplication of these names: 'Health'."
	Assert-Throws {Set-AzSqlInformationProtectionPolicy -FilePath "SqlInformationProtectionPolicies\InformationTypesSharingSameDisplayName.json" } $message
}

<#
.SYNOPSIS
Tests an error is raised when setting a policy containing information types sharing same id.
#>
function Test-ErrorWhenInformationTypesShareSameId
{
	$message = "Ids should be unique. Please eliminate duplication of these ids: '5c503e21-22c6-81fa-620b-f369b8ec38d1'."
	Assert-Throws {Set-AzSqlInformationProtectionPolicy -FilePath "SqlInformationProtectionPolicies\InformationTypesSharingSameId.json" } $message
}

<#
.SYNOPSIS
Tests an error is raised when setting a policy containing sensitivity labels sharing same display name.
#>
function Test-ErrorWhenSensitivityLabelsShareSameDisplayName
{
	$message = "Display names should be unique. Please eliminate duplication of these names: 'Public'."
	Assert-Throws {Set-AzSqlInformationProtectionPolicy -FilePath "SqlInformationProtectionPolicies\SensitivityLabelsSharingSameDisplayName.json" } $message
}

<#
.SYNOPSIS
Tests an error is raised when setting a policy containing sensitivity labels sharing same id.
#>
function Test-ErrorWhenSensitivityLabelsShareSameId
{
	$message = "Ids should be unique. Please eliminate duplication of these ids: '50e58766-ab53-4846-be8a-35e0bb87723e'."
	Assert-Throws {Set-AzSqlInformationProtectionPolicy -FilePath "SqlInformationProtectionPolicies\SensitivityLabelsSharingSameId.json" } $message
}

<#
.SYNOPSIS
Tests an error is raised when setting a policy containing information type and sensitivity label sharing same display name.
#>
function Test-ErrorWhenInformationTypeAndSensitivityLabelShareSameDisplayName
{
	$message = "Display names should be unique. Please eliminate duplication of these names: 'Public'."
	Assert-Throws {Set-AzSqlInformationProtectionPolicy -FilePath "SqlInformationProtectionPolicies\SensitivityLabelsSharingSameDisplayName.json" } $message
}

<#
.SYNOPSIS
Tests an error is raised when setting a policy containing an invalid rank.
#>
function Test-ErrorWhenRankIsInvalid
{
	$message = "Error converting value ""Non"" to type 'System.Nullable``1[Microsoft.Azure.Commands.SecurityCenter.Models.SqlInformationProtectionPolicy.PSSqlInformationProtectionRank]'. Path 'Labels.50e58766-ab53-4846-be8a-35e0bb87723e.Rank', line 6, position 19."
	Assert-Throws {Set-AzSqlInformationProtectionPolicy -FilePath "SqlInformationProtectionPolicies\InvalidRank.json" } $message
}

<#
.SYNOPSIS
Tests an error is raised when setting a policy containing missing rank.
#>
function Test-ErrorWhenRankIsMissing
{
	$message = "Required property 'Rank' not found in JSON. Path 'Labels.50e58766-ab53-4846-be8a-35e0bb87723e', line 8, position 5."
	Assert-Throws {Set-AzSqlInformationProtectionPolicy -FilePath "SqlInformationProtectionPolicies\MissingRank.json" } $message
}