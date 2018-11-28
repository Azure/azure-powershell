﻿# ----------------------------------------------------------------------------------
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
function InitializeGeneratedControlNumberSession([Object] $resourceGroup, [String] $integrationAccountName, [String] $integrationAccountAgreementName, [String] $agreementType, [bool] $oldformat)
{
	if (IsRecordMode)
	{
		$resourceId = "/subscriptions/" + $(getVariable "SubscriptionId") + "/resourceGroups/" + $resourceGroup.ResourceGroupName + "/providers/Microsoft.Logic/integrationAccounts/" + $integrationAccountName + "/sessions/" + $integrationAccountAgreementName + "-ICN"

		if ($oldformat -eq $true)
		{
			$content = "256"
		}
		else
		{
			# Create the control number in its modern format.
			$content = ConvertFrom-Json @"
{
    "ControlNumber":  "1000",
    "ControlNumberChangedTime":  "\/Date(1487793941363)\/",
    "MessageType": "$agreementType"
}
"@
		}
		New-AzureRmResource -ResourceId $resourceId -ApiVersion 2016-06-01 -Force -Location $resourceGroup.Location -Properties @{"content"=$content}
	}
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountGeneratedIcn command
#>
function Test-GetIntegrationAccountGeneratedControlNumber-NoAgreementType()
{
	$agreementFilePath = Join-Path $TestOutputRoot "\Resources\IntegrationAccountX12AgreementContent.json"
	$agreementContent = [IO.File]::ReadAllText($agreementFilePath)

	# This error string is less than ideal due to AutoRest bug https://github.com/Azure/autorest/issues/2022
	Assert-ThrowsContains { Get-AzureRmIntegrationAccountGeneratedIcn -ResourceGroupName "Random83da135" -Name "DoesNotMatter" -AgreementName "DoesNotMatter" } "Operation returned an invalid status code 'NotFound'"

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	$integrationAccountAgreementName = getAssetname + "X12"

	Assert-ThrowsContains { Get-AzureRmIntegrationAccountGeneratedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name "Random83da135" -AgreementName "DoesNotMatter" } "Operation returned an invalid status code 'NotFound'"

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement0 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementContent

	$result =  Get-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName
	Assert-AreEqual $integrationAccountAgreementName $result.Name

	$result1 =  Get-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName
	Assert-True { $result1.Count -gt 0 }

	# Because there is no actual B2B connector activity, no generated control number will exist by default.
	# We also do not expose a Create cmdlet on generated control numbers because the operators should not create one where does not exist.
	# So working this around by using ARM resource cmdlet to create a dummy entry.

	# Before the workaround the control number containing session ressource cannot be found in the integration account.
	Assert-ThrowsContains { Get-AzureRmIntegrationAccountGeneratedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName } "Operation returned an invalid status code 'NotFound'"

	# Now we create one with the legacy raw control number content. This cmdlet will intentionally fail to deserialize: it is meant only to operate on new control numbers that have been replicated for the purpose of disaster recovery.
	InitializeGeneratedControlNumberSession -agreementType "X12" -resourceGroup $resourceGroup -integrationAccountName $integrationAccountName -integrationAccountAgreementName $integrationAccountAgreementName -oldformat $true
	Assert-ThrowsContains { Get-AzureRmIntegrationAccountGeneratedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName } "is not in a valid format."

	InitializeGeneratedControlNumberSession -agreementType "X12" -resourceGroup $resourceGroup -integrationAccountName $integrationAccountName -integrationAccountAgreementName $integrationAccountAgreementName -oldformat $false
	$result =  Get-AzureRmIntegrationAccountGeneratedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName
	Assert-AreEqual "1000" $result.ControlNumber
	Assert-AreEqual "02/22/2017 20:05:41" $result.ControlNumberChangedTime
    Assert-AreEqual "X12" $result.MessageType

	$result1 =  Get-AzureRmIntegrationAccountGeneratedIcn -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName
	Assert-True { $result1.Count -gt 0 }

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountGeneratedIcn command
#>
function Test-GetIntegrationAccountGeneratedControlNumber
{
  Test-GetIntegrationAccountGeneratedControlNumberInternal -agreementType "X12"
  Test-GetIntegrationAccountGeneratedControlNumberInternal -agreementType "Edifact"
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountGeneratedIcn command
#>
function Test-GetIntegrationAccountGeneratedControlNumberInternal([String] $agreementType)
{
	$agreementFilePath = Join-Path $TestOutputRoot "\Resources\IntegrationAccount${agreementType}AgreementContent.json"
	$agreementContent = [IO.File]::ReadAllText($agreementFilePath)

	# This error string is less than ideal due to AutoRest bug https://github.com/Azure/autorest/issues/2022
	Assert-ThrowsContains { Get-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName "Random83da135" -Name "DoesNotMatter" -AgreementName "DoesNotMatter" } "Operation returned an invalid status code 'NotFound'"

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	$integrationAccountAgreementName = getAssetname + $agreementType

	Assert-ThrowsContains { Get-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName $resourceGroup.ResourceGroupName -Name "Random83da135" -AgreementName "DoesNotMatter" } "Operation returned an invalid status code 'NotFound'"

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement0 =  New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType $agreementType -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementContent

	$result =  Get-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName
	Assert-AreEqual $integrationAccountAgreementName $result.Name

	$result1 =  Get-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName
	Assert-True { $result1.Count -gt 0 }

	# Because there is no actual B2B connector activity, no generated control number will exist by default.
	# We also do not expose a Create cmdlet on generated control numbers because the operators should not create one where does not exist.
	# So working this around by using ARM resource cmdlet to create a dummy entry.

	# Before the workaround the control number containing session ressource cannot be found in the integration account.
	Assert-ThrowsContains { Get-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName } "Operation returned an invalid status code 'NotFound'"

	# Now we create one with the legacy raw control number content. This cmdlet will intentionally fail to deserialize: it is meant only to operate on new control numbers that have been replicated for the purpose of disaster recovery.
	InitializeGeneratedControlNumberSession -agreementType $agreementType -resourceGroup $resourceGroup -integrationAccountName $integrationAccountName -integrationAccountAgreementName $integrationAccountAgreementName -oldformat $true
	Assert-ThrowsContains { Get-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName } "is not in a valid format."

	InitializeGeneratedControlNumberSession -agreementType $agreementType -resourceGroup $resourceGroup -integrationAccountName $integrationAccountName -integrationAccountAgreementName $integrationAccountAgreementName -oldformat $false
	$result =  Get-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName
	Assert-AreEqual "1000" $result.ControlNumber
	Assert-AreEqual "02/22/2017 20:05:41" $result.ControlNumberChangedTime
    Assert-AreEqual $agreementType $result.MessageType

	$result1 =  Get-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName
	Assert-True { $result1.Count -gt 0 }

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountGeneratedIcn command
#>
function Test-UpdateIntegrationAccountGenCN
{
  Test-UpdateIntegrationAccountGenCNInternal -agreementType "X12"
  Test-UpdateIntegrationAccountGenCNInternal -agreementType "Edifact"
}

<#
.SYNOPSIS
Test Set-AzureRmIntegrationAccountGeneratedIcn command
#>
function Test-UpdateIntegrationAccountGenCNInternal([String] $agreementType)
{
	$agreementFilePath = Join-Path $TestOutputRoot "\Resources\IntegrationAccount${agreementType}AgreementContent.json"
	$agreementContent = [IO.File]::ReadAllText($agreementFilePath)

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname
	
	$integrationAccountAgreementName = getAssetname + $agreementType

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner = New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner = New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement = New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType $agreementType -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementContent
	Assert-AreEqual $integrationAccountAgreementName $integrationAccountAgreement.Name
	Assert-AreEqual $agreementType $integrationAccountAgreement.AgreementType

	# Verify inserting new control number records is not allowed
	Assert-ThrowsContains { Set-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumber "789" } "Operation returned an invalid status code 'NotFound'"

	InitializeGeneratedControlNumberSession -agreementType $agreementType -resourceGroup $resourceGroup -integrationAccountName $integrationAccountName -integrationAccountAgreementName $integrationAccountAgreementName -oldformat $false
	$initialControlNumber = Get-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName
	Assert-AreEqual "1000" $initialControlNumber.ControlNumber

	# Tests the conversion and value incrementation as shown in the cmdlet help.
	$incrementedControlNumberValue = [convert]::ToString([convert]::ToInt32($initialControlNumber.ControlNumber, 10) + 100, 10)
	Assert-AreEqual "1100" $incrementedControlNumberValue

	$updatedControlNumber = Set-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -ControlNumber $incrementedControlNumberValue
	Assert-AreEqual $incrementedControlNumberValue $updatedControlNumber.ControlNumber

	# PowerShell fails to distinguish tick-level differences, hence using -ge instead of -gt
	Assert-True { return ($updatedControlNumber.ControlNumberChangedTime -ge $initialControlNumber.ControlNumberChangedTime) }

	Assert-ThrowsContains { Set-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName } "Cannot process command because of one or more missing mandatory parameters: ControlNumber."

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountGeneratedIcn command : paging test
#>
function Test-ListIntegrationAccountGenCN
{
  Test-ListIntegrationAccountGenCNInternal -agreementType "X12"
  Test-ListIntegrationAccountGenCNInternal -agreementType "Edifact"
}

<#
.SYNOPSIS
Test Get-AzureRmIntegrationAccountGeneratedIcn command : paging test
#>
function Test-ListIntegrationAccountGenCNInternal([String] $agreementType)
{
	$agreementFilePath = Join-Path $TestOutputRoot "\Resources\IntegrationAccount${agreementType}AgreementContent.json"
	$agreementContent = [IO.File]::ReadAllText($agreementFilePath)

	$agreementAS2FilePath = Join-Path $TestOutputRoot "\Resources\IntegrationAccountAS2AgreementContent.json"
	$agreementAS2Content = [IO.File]::ReadAllText($agreementAS2FilePath)
	$integrationAccountAS2AgreementName = getAssetname

	$resourceGroup = TestSetup-CreateNamedResourceGroup "IntegrationAccountPsCmdletTest"
	$integrationAccountName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzureRmIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	# Add an AS2 agreement for which the ICN listing should skip
	New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAS2AgreementName -AgreementType "AS2" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementAS2Content

	# The test script here is checked in with 2 iterations. For actual pagination test, run the test manually in record mode with 200. Don't check-in the session file as it will be huge.
	$val=0
	while($val -ne 2)
	{
		$val++ ;
		$integrationAccountAgreementName = getAssetname + $agreementType
		New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType $agreementType -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementContent

		InitializeGeneratedControlNumberSession -agreementType $agreementType -resourceGroup $resourceGroup -integrationAccountName $integrationAccountName -integrationAccountAgreementName $integrationAccountAgreementName -oldformat $false
	}

	# Add one more X12/Edifact agreement with no generated ICN for which the ICN listing should catch and handle not found exception.
	$integrationAccountAgreementName = getAssetname + $agreementType
	New-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType $agreementType -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementContent

	$result =  Get-AzureRmIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName
	Assert-True { $result.Count -eq 4 }

	$result1 =  Get-AzureRmIntegrationAccountGeneratedIcn -AgreementType $agreementType -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName
	Assert-True { $result1.Count -eq 3 }

	Remove-AzureRmIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -Name $integrationAccountName -Force
}