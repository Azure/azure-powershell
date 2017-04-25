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
Returns true if current mode is record
#>
function IsRecordMode()
{
	$mode = $env:AZURE_TEST_MODE
	return  $mode -ne $null -and $mode.ToUpperInvariant() -eq "RECORD"
}

<#
.SYNOPSIS
Writes a session containing a control number
#>
function InitializeReceivedControlNumberSession([Object] $resourceGroup, [String] $integrationAccountName, [String] $integrationAccountX12AgreementName, [String] $controlNumberValue, [bool] $oldformat)
{
	if (IsRecordMode)
	{
		$resourceId = "/subscriptions/" + $(getVariable "SubscriptionId") + "/resourceGroups/" + $resourceGroup.ResourceGroupName + "/providers/Microsoft.Logic/integrationAccounts/" + $integrationAccountName + "/sessions/X12-ICN-" + $integrationAccountX12AgreementName + "-" + $controlNumberValue

		if ($oldformat -eq $true)
		{
			$content = $controlNumberValue
		}
		else
		{
			# Create the control number in its modern format.
			$content = ConvertFrom-Json @"
{
    "ControlNumber":  $controlNumberValue,
    "ControlNumberChangedTime":  "\/Date(1487793941363)\/",
    "DecodeReceivedMessageFailure":  "false",
    "MessageType": "X12"
}
"@
		}
		New-AzureRmResource -ResourceId $resourceId -ApiVersion 2016-06-01 -Force -Location $resourceGroup.Location -Properties @{"content"=$content}
	}
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountReceivedIcn command
#>
function Test-GetIntegrationAccountReceivedIcn
{
	$agreementX12FilePath = "$TestOutputRoot\Resources\IntegrationAccountX12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)

	# This error string is less than ideal due to AutoRest bug https://github.com/Azure/autorest/issues/2022
	Assert-ThrowsContains { Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName "Random83da135" -Name "DoesNotMatter" -AgreementName "DoesNotMatter" -controlNumberValue "DoesNotMatter" } "Operation returned an invalid status code 'NotFound'"

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	$integrationAccountX12AgreementName = getAssetname

	Assert-ThrowsContains { Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name "Random83da135" -AgreementName "DoesNotMatter" -ControlNumberValue "DoesNotMatter" } "Operation returned an invalid status code 'NotFound'"

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement0 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content

	$result =  Get-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName
	Assert-AreEqual $integrationAccountX12AgreementName $result.Name

	$result1 =  Get-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName
	Assert-True { $result1.Count -gt 0 }

	# Because there is no actual B2B connector activity, no received control number will exist by default.
	# We also do not expose a Create cmdlet on received control numbers because the operators should not create one where does not exist.
	# So working this around by using ARM resource cmdlet to create a dummy entry.

	# Before the workaround the control number containing session ressource cannot be found in the integration account.
	Assert-ThrowsContains { Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -ControlNumberValue "1000" } "Operation returned an invalid status code 'NotFound'"

	# Now we create one with the legacy raw control number content. This cmdlet will intentionally fail to deserialize: it is meant only to operate on new control numbers that have been replicated for the purpose of disaster recovery.
	InitializeReceivedControlNumberSession -resourceGroup $resourceGroup -integrationAccountName $integrationAccountName -integrationAccountX12AgreementName $integrationAccountX12AgreementName -controlNumberValue "1000" -oldformat $true
	Assert-ThrowsContains { Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -ControlNumberValue "1000" } "is not in a valid format."

	InitializeReceivedControlNumberSession -resourceGroup $resourceGroup -integrationAccountName $integrationAccountName -integrationAccountX12AgreementName $integrationAccountX12AgreementName -controlNumberValue "1000" -oldformat $false
	$result =  Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountX12AgreementName -ControlNumberValue "1000"
	Assert-AreEqual "1000" $result.ControlNumber
	Assert-AreEqual "02/22/2017 20:05:41" $result.ControlNumberChangedTime
	Assert-AreEqual "X12" $result.MessageType

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzureRmIntegrationAccountReceivedIcn command
#>
function Test-RemoveIntegrationAccountReceivedIcn
{
	$agreementX12FilePath = "$TestOutputRoot\Resources\IntegrationAccountX12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	
	$integrationAccountAgreementName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner = New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner = New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement = New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content
	Assert-AreEqual $integrationAccountAgreementName $integrationAccountAgreement.Name
	Assert-AreEqual "X12" $integrationAccountAgreement.AgreementType

	Assert-ThrowsContains { Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000" } "Operation returned an invalid status code 'NotFound'"

	# Verify removing non-existing control number records is allowed.
	Remove-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000"

	InitializeReceivedControlNumberSession -resourceGroup $resourceGroup -integrationAccountName $integrationAccountName -integrationAccountX12AgreementName $integrationAccountAgreementName -controlNumberValue "1000" -oldformat $false
	$initialControlNumber = Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000"
	Assert-AreEqual "1000" $initialControlNumber.ControlNumber

	Remove-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000"

	Assert-ThrowsContains { Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000" } "Operation returned an invalid status code 'NotFound'"

	Assert-ThrowsContains { Remove-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName } "Cannot process command because of one or more missing mandatory parameters: ControlNumberValue."

	Remove-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000"

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountReceivedIcn command
#>
function Test-UpdateIntegrationAccountReceivedIcn
{
	$agreementX12FilePath = "$TestOutputRoot\Resources\IntegrationAccountX12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	
	$integrationAccountAgreementName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner = New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner = New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement = New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content
	Assert-AreEqual $integrationAccountAgreementName $integrationAccountAgreement.Name
	Assert-AreEqual "X12" $integrationAccountAgreement.AgreementType

	Assert-ThrowsContains { Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000" } "Operation returned an invalid status code 'NotFound'"

	InitializeReceivedControlNumberSession -resourceGroup $resourceGroup -integrationAccountName $integrationAccountName -integrationAccountX12AgreementName $integrationAccountAgreementName -controlNumberValue "1000" -oldformat $false
	$initialControlNumber = Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000"
	Assert-AreEqual "1000" $initialControlNumber.ControlNumber

	Set-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000" -IsMessageProcessingFailed $true

	$updatedControlNumber = Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000"
	Assert-AreNotEqual $initialControlNumber.ControlNumberChangedTime $updatedControlNumber.ControlNumberChangedTime
	Assert-AreEqual "1000" $updatedControlNumber.ControlNumber
	Assert-AreEqual $true $updatedControlNumber.IsMessageProcessingFailed

	Set-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000" -IsMessageProcessingFailed $false

	$updatedControlNumber = Get-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000"
	Assert-AreNotEqual $initialControlNumber.ControlNumberChangedTime $updatedControlNumber.ControlNumberChangedTime
	Assert-AreEqual "1000" $updatedControlNumber.ControlNumber
	Assert-AreEqual $false $updatedControlNumber.IsMessageProcessingFailed

	Remove-AzureRmIntegrationAccountReceivedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumberValue "1000"

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}
