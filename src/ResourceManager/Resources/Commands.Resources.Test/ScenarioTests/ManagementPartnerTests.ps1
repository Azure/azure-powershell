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
Tests get management partner
#>
function Test-GetPartner
{
	$partnerId="123457"
	$partner = Get-AzureRmManagementPartner -PartnerId $partnerId

	# Assert
	Assert-AreEqual $partnerId $partner.PartnerId
	Assert-NotNull $partner.TenantId
	Assert-NotNull $partner.ObjectId
    Assert-NotNull $partner.State
}


<#
.SYNOPSIS
Tests get management partner without parnter id
#>
function Test-GetPartnerNoPartnerId
{
	$partner = Get-AzureRmManagementPartner

	# Assert
	Assert-NotNull $partner.PartnerId
	Assert-NotNull $partner.TenantId
	Assert-NotNull $partner.ObjectId
    Assert-NotNull $partner.State
}


<#
.SYNOPSIS
Tests add management partner
#>
function Test-NewPartner
{
	$partnerId="123457"
	$partner = New-AzureRmManagementPartner -PartnerId $partnerId

	# Assert
	Assert-AreEqual $partnerId $partner.PartnerId
	Assert-NotNull $partner.TenantId
	Assert-NotNull $partner.ObjectId
    Assert-NotNull $partner.State
}


<#
.SYNOPSIS
Tests update management partner
#>
function Test-UpdatePartner
{
	$partnerId="123456"
	$partner = Update-AzureRmManagementPartner -PartnerId $partnerId

	# Assert
	Assert-AreEqual $partnerId $partner.PartnerId
	Assert-NotNull $partner.TenantId
	Assert-NotNull $partner.ObjectId
    Assert-NotNull $partner.State
}

<#
.SYNOPSIS
Tests remove management partner
#>
function Test-RemovePartner
{
	$partnerId="123456"
	$partner = Remove-AzureRmManagementPartner -PartnerId $partnerId
}
