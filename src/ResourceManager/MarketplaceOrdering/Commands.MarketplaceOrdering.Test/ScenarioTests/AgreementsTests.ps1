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
Get Agreement Terms
#>
function Test-GetAgreementTerms
{
	$PublisherId = "microsoft-ads"
	$ProductId = "windows-data-science-vm"
	$PlanId = "windows2016"
    $agreementTerms = Get-AzureRmMarketplaceTerms -Publisher $PublisherId -Product $ProductId -Name $PlanId

	Assert-NotNull $agreementTerms
	Assert-NotNull $agreementTerms.LicenseTextLink
	Assert-NotNull $agreementTerms.PrivacyPolicyLink
	Assert-NotNull $agreementTerms.Signature
}

<#
.SYNOPSIS
Set Agrement Terms - Reject
#>
function Test-SetAgreementTermsNotAccepted
{
	$PublisherId = "microsoft-ads"
	$ProductId = "windows-data-science-vm"
	$PlanId = "windows2016"
    $agreementTerms = Get-AzureRmMarketplaceTerms -Publisher $PublisherId -Product $ProductId -Name $PlanId

	Assert-NotNull $agreementTerms
	Assert-NotNull $agreementTerms.LicenseTextLink
	Assert-NotNull $agreementTerms.PrivacyPolicyLink
	Assert-NotNull $agreementTerms.Signature

	$newAgreementTerms = Set-AzureRmMarketplaceTerms -Publisher $PublisherId -Product $ProductId -Name $PlanId -Reject
	Assert-NotNull $newAgreementTerms
	Assert-NotNull $newAgreementTerms.LicenseTextLink
	Assert-NotNull $newAgreementTerms.PrivacyPolicyLink
	Assert-NotNull $newAgreementTerms.Signature
	Assert-AreEqual false $newAgreementTerms.Accepted
}

<#
.SYNOPSIS
Set Agrement Terms - Accept 
#>
function Test-SetAgreementTermsAccepted
{
	$PublisherId = "microsoft-ads"
	$ProductId = "windows-data-science-vm"
	$PlanId = "windows2016"
    $agreementTerms = Get-AzureRmMarketplaceTerms -Publisher $PublisherId -Product $ProductId -Name $PlanId

	Assert-NotNull $agreementTerms
	Assert-NotNull $agreementTerms.LicenseTextLink
	Assert-NotNull $agreementTerms.PrivacyPolicyLink
	Assert-NotNull $agreementTerms.Signature

	$newAgreementTerms = Set-AzureRmMarketplaceTerms -Publisher $PublisherId -Product $ProductId -Name $PlanId -Terms $agreementTerms -Accept
	Assert-NotNull $newAgreementTerms
	Assert-NotNull $newAgreementTerms.LicenseTextLink
	Assert-NotNull $newAgreementTerms.PrivacyPolicyLink
	Assert-NotNull $newAgreementTerms.Signature
	Assert-AreEqual true $newAgreementTerms.Accepted
}

<#
.SYNOPSIS
Set Agrement Terms pipeline - Accept
#>
function Test-SetAgreementTermsAcceptedPipelineGet
{
	$PublisherId = "microsoft-ads"
	$ProductId = "windows-data-science-vm"
	$PlanId = "windows2016"
	$newAgreementTerms = Get-AzureRmMarketplaceTerms -Publisher $PublisherId -Product $ProductId -Name $PlanId|Set-AzureRmMarketplaceTerms -Accept
	Assert-NotNull $newAgreementTerms
	Assert-NotNull $newAgreementTerms.LicenseTextLink
	Assert-NotNull $newAgreementTerms.PrivacyPolicyLink
	Assert-NotNull $newAgreementTerms.Signature
	Assert-AreEqual true $newAgreementTerms.Accepted
}

<#
.SYNOPSIS
Set Agrement Terms pipeline - Reject
#>
function Test-SetAgreementTermsRejectedPipelineGet
{
	$PublisherId = "microsoft-ads"
	$ProductId = "windows-data-science-vm"
	$PlanId = "windows2016"
	$newAgreementTerms = Get-AzureRmMarketplaceTerms -Publisher $PublisherId -Product $ProductId -Name $PlanId|Set-AzureRmMarketplaceTerms -Reject
	Assert-NotNull $newAgreementTerms
	Assert-NotNull $newAgreementTerms.LicenseTextLink
	Assert-NotNull $newAgreementTerms.PrivacyPolicyLink
	Assert-NotNull $newAgreementTerms.Signature
	Assert-AreEqual false $newAgreementTerms.Accepted
}