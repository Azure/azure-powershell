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
Test New-AzIntegrationAccountAgreement command
#>
function Test-CreateIntegrationAccountAgreementX12
{
	$agreementX12FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "X12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountX12AgreementName = getAssetname
	$integrationAccountX12AgreementName1 = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	
	$hostPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities
	
	$childItems = New-Object PSObject |
	   Add-Member -PassThru NoteProperty Item1 'ChildItem' |
	   Add-Member -PassThru NoteProperty Item2 1 |
	   Add-Member -PassThru NoteProperty Item3 ("Prop1","Prop2","Prop3") 

	$items = (New-Object PSObject |
	   Add-Member -PassThru NoteProperty Property1 'Main' |
	   Add-Member -PassThru NoteProperty Property2 $childItems
	)
	$metadata = $items | ConvertTo-JSON -Compress
	
	Assert-ThrowsContains {New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifier "AA" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content -Metadata "test" } "Invalid metadata."

	$integrationAccountAgreement0 =  New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content -Metadata $metadata
	Assert-AreEqual $integrationAccountX12AgreementName $integrationAccountAgreement0.Name

	$integrationAccountAgreement1 =  New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName1 -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContentFilePath $agreementX12FilePath
	Assert-AreEqual $integrationAccountX12AgreementName1 $integrationAccountAgreement1.Name

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test New-AzIntegrationAccountAgreement command
#>
function Test-CreateIntegrationAccountAgreementAS2
{
	$agreementAS2FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "AS2AgreementContent.json"
	$agreementAS2Content = [IO.File]::ReadAllText($agreementAS2FilePath)

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountAS2AgreementName = getAssetname
	$integrationAccountAS2AgreementName1 = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement3 =  New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAS2AgreementName -AgreementType "AS2" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementAS2Content
	Assert-AreEqual $integrationAccountAS2AgreementName $integrationAccountAgreement3.Name

	$integrationAccountAgreement4 =  New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAS2AgreementName1 -AgreementType "AS2" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContentFilePath $agreementAS2FilePath
	Assert-AreEqual $integrationAccountAS2AgreementName1 $integrationAccountAgreement4.Name

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test New-AzIntegrationAccountAgreement command
#>
function Test-CreateIntegrationAccountAgreementEdifact
{
	$agreementEdifactFilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "EdifactAgreementContent.json"
	$agreementEdifactContent = [IO.File]::ReadAllText($agreementEdifactFilePath)
	
	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountEdifactAgreementName = getAssetname
	$integrationAccountEdifactAgreementName1 = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement5 =  New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountEdifactAgreementName -AgreementType "Edifact" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementEdifactContent
	Assert-AreEqual $integrationAccountEdifactAgreementName $integrationAccountAgreement5.Name

	$integrationAccountAgreement6 =  New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountEdifactAgreementName1 -AgreementType "Edifact" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContentFilePath $agreementEdifactFilePath
	Assert-AreEqual $integrationAccountEdifactAgreementName1 $integrationAccountAgreement6.Name

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}


<#
.SYNOPSIS
Test New-AzIntegrationAccountAgreement command with negative scenario.
#>
function Test-CreateIntegrationAccountAgreementWithFailure
{
	$agreementX12FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "X12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountX12AgreementName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities
	
	Assert-ThrowsContains {New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner "TestGuest" -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content} "The partner 'TestGuest' could not be found in integration account '$integrationAccountName'."

	Assert-ThrowsContains {New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner "TestHost" -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content} "The partner 'TestHost' could not be found in integration account '$integrationAccountName'."

	Assert-ThrowsContains {New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "BB" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "BB" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content} "The qualifier 'BB' for partner '$guestPartnerName' is invalid."

	Assert-ThrowsContains {New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "OO" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "OO" -AgreementContent $agreementX12Content} "The qualifier 'OO' for partner '$hostPartnerName' is invalid."

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountAgreement command
#>
function Test-GetIntegrationAccountAgreement
{
	$agreementX12FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "X12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)

	Assert-ThrowsContains { Get-AzIntegrationAccountAgreement -ResourceGroupName "Random83da135" -IntegrationAccountName "DoesNotMatter" -AgreementName "DoesNotMatter" } "Resource group 'Random83da135' could not be found."

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountX12AgreementName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement0 =  New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content

	$result =  Get-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName
	Assert-AreEqual $integrationAccountX12AgreementName $result.Name

	$result1 =  Get-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result1.Count -gt 0 }

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Remove-AzIntegrationAccountAgreement command
#>
function Test-RemoveIntegrationAccountAgreement
{
	$agreementX12FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "X12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountX12AgreementName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName
	
	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement0 =  New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content

	Remove-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName -Force	

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Set-AzIntegrationAccountAgreement command
#>
function Test-UpdateIntegrationAccountAgreement
{
	$agreementX12FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "X12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)
	
	$agreementAS2FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "AS2AgreementContent.json"
	$agreementAS2Content = [IO.File]::ReadAllText($agreementAS2FilePath)

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)
	
	$integrationAccountAgreementName = getAssetname

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname	
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$integrationAccountAgreement =  New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content
	Assert-AreEqual $integrationAccountAgreementName $integrationAccountAgreement.Name
	Assert-AreEqual "X12" $integrationAccountAgreement.AgreementType

	Assert-ThrowsContains {Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ"  -Force} "Either 'Host' business Identity qualifier or qualifier value is not specified."
	Assert-ThrowsContains {Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ"  -HostIdentityQualifierValue "AA" -GuestIdentityQualifierValue "ZZ"  -Force} "Either 'Host' business Identity qualifier or qualifier value is not specified."

	Assert-ThrowsContains {Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -HostIdentityQualifierValue "AA" -Force} "Either 'Guest' business Identity qualifier or qualifier value is not specified."
	Assert-ThrowsContains {Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifier "AA" -HostIdentityQualifierValue "AA" -Force} "Either 'Guest' business Identity qualifier or qualifier value is not specified."


	$updatedIntegrationAccountAgreement =  Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "AS2" -AgreementContent $agreementAS2Content -Force
	Assert-AreEqual "AS2" $updatedIntegrationAccountAgreement.AgreementType

	$updatedIntegrationAccountAgreement =  Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "AS2" -AgreementContentFilePath $agreementAS2FilePath -Force
	Assert-AreEqual "AS2" $updatedIntegrationAccountAgreement.AgreementType

	$updatedIntegrationAccountAgreement =  Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -GuestIdentityQualifier "XX" -GuestIdentityQualifierValue "XX" -Force
	Assert-AreEqual "XX" $updatedIntegrationAccountAgreement.GuestIdentity.Qualifier
	Assert-AreEqual "XX" $updatedIntegrationAccountAgreement.GuestIdentity.Value

	$updatedIntegrationAccountAgreement =  Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -HostIdentityQualifier "BB" -HostIdentityQualifierValue "BB" -Force
	Assert-AreEqual "BB" $updatedIntegrationAccountAgreement.HostIdentity.Qualifier
	Assert-AreEqual "BB" $updatedIntegrationAccountAgreement.HostIdentity.Value

	Assert-ThrowsContains {Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner "TestGuest" -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -Force} "The partner 'TestGuest' could not be found in integration account '$integrationAccountName'."

	Assert-ThrowsContains {Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner "TestHost" -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -Force} "The partner 'TestHost' could not be found in integration account '$integrationAccountName'."

	Assert-ThrowsContains {Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "BB" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "BB" -HostIdentityQualifierValue "AA" -Force} "The qualifier 'BB' for partner '$guestPartnerName' is invalid."

	Assert-ThrowsContains {Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "OO" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "OO" -Force} "The qualifier 'OO' for partner '$hostPartnerName' is invalid."

	$updatedIntegrationAccountAgreement =  Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -GuestPartner $hostPartnerName -HostPartner $guestPartnerName -Force
	Assert-AreEqual $hostPartnerName $updatedIntegrationAccountAgreement.GuestPartner
	Assert-AreEqual $guestPartnerName $updatedIntegrationAccountAgreement.HostPartner

	$childItems = New-Object PSObject |
	   Add-Member -PassThru NoteProperty Item1 'ChildItem' |
	   Add-Member -PassThru NoteProperty Item2 1 |
	   Add-Member -PassThru NoteProperty Item3 ("Prop1","Prop2","Prop3") 

	$items = (New-Object PSObject |
	   Add-Member -PassThru NoteProperty Property1 'Main' |
	   Add-Member -PassThru NoteProperty Property2 $childItems
	)

	$metadata = $items | ConvertTo-JSON -Compress

	Assert-ThrowsContains {Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -Metadata "test" -Force} "Invalid metadata."

	$updatedIntegrationAccountAgreement =  Set-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountAgreementName -Metadata $metadata	-Force
	
	$result = $updatedIntegrationAccountAgreement.Metadata.ToString() | ConvertFrom-JSON 
	Assert-AreEqualObjectProperties $items $result 
	
	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}

<#
.SYNOPSIS
Test Get-AzIntegrationAccountAgreement command : paging test
#>
function Test-ListIntegrationAccountAgreement
{
	$agreementX12FilePath = Join-Path (Join-Path $TestOutputRoot "Resources") "X12AgreementContent.json"
	$agreementX12Content = [IO.File]::ReadAllText($agreementX12FilePath)

	$resourceGroup = TestSetup-CreateResourceGroup
	$integrationAccountName = "IA-" + (getAssetname)

	$integrationAccount = TestSetup-CreateIntegrationAccount $resourceGroup.ResourceGroupName $integrationAccountName

	$hostPartnerName = getAssetname
	$guestPartnerName = getAssetname
	$hostBusinessIdentities = @(("AA","AA"), ("BB","BB"))
	$guestBusinessIdentities = @(("ZZ","ZZ"), ("XX","XX"))
	$hostPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $hostPartnerName -BusinessIdentities $hostBusinessIdentities
	$guestPartner =  New-AzIntegrationAccountPartner -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -PartnerName $guestPartnerName -BusinessIdentities $guestBusinessIdentities

	$val=0
	while($val -ne 1)
	{
		$val++ ;
		$integrationAccountX12AgreementName = getAssetname
		New-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -AgreementName $integrationAccountX12AgreementName -AgreementType "X12" -GuestPartner $guestPartnerName -HostPartner $hostPartnerName -GuestIdentityQualifier "ZZ" -HostIdentityQualifier "AA" -GuestIdentityQualifierValue "ZZ" -HostIdentityQualifierValue "AA" -AgreementContent $agreementX12Content
	}

	$result =  Get-AzIntegrationAccountAgreement -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName
	Assert-True { $result.Count -eq 1 }

	Remove-AzIntegrationAccount -ResourceGroupName $resourceGroup.ResourceGroupName -IntegrationAccountName $integrationAccountName -Force
}