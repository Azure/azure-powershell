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
    # Setup
	$partnerId="123457"
	$partner = New-AzureRmManagementPartner -PartnerId $partnerId

    # Test
	$partner = Get-AzureRmManagementPartner -PartnerId $partnerId

	# Assert
	Assert-AreEqual $partnerId $partner.PartnerId
	Assert-NotNull $partner.TenantId
	Assert-NotNull $partner.ObjectId
    Assert-NotNull $partner.State

    # cleanup
    Remove-AzureRmManagementPartner -PartnerId $partnerId
}


<#
.SYNOPSIS
Tests get management partner without parnter id
#>
function Test-GetPartnerNoPartnerId
{
	 # Setup
	$partnerId="123457"
	$partner = New-AzureRmManagementPartner -PartnerId $partnerId

    # Test
	$partner = Get-AzureRmManagementPartner

	# Assert
	Assert-AreEqual $partnerId $partner.PartnerId
	Assert-NotNull $partner.TenantId
	Assert-NotNull $partner.ObjectId
    Assert-NotNull $partner.State

    # cleanup
    Remove-AzureRmManagementPartner -PartnerId $partnerId
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

    # cleanup
    Remove-AzureRmManagementPartner -PartnerId $partnerId
}


<#
.SYNOPSIS
Tests update management partner
#>
function Test-UpdatePartner
{
	# Setup
	$partnerId="123457"
	$partner = New-AzureRmManagementPartner -PartnerId $partnerId

    # Test
    $newPartnerId="123456"
	$partner = Update-AzureRmManagementPartner -PartnerId $newPartnerId

	# Assert
	Assert-AreEqual $newPartnerId $partner.PartnerId
	Assert-NotNull $partner.TenantId
	Assert-NotNull $partner.ObjectId
    Assert-NotNull $partner.State

    # cleanup
    Remove-AzureRmManagementPartner -PartnerId $newPartnerId
}

<#
.SYNOPSIS
Tests remove management partner
#>
function Test-RemovePartner
{
	# Setup
	$partnerId="123457"
	$partner = New-AzureRmManagementPartner -PartnerId $partnerId
    
    # Test
	Remove-AzureRmManagementPartner -PartnerId $partnerId
}
