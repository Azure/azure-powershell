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
Test register secret management extension
#>
function Test-ExtensionRegister
{
	Register-SecretVault -Name AzKeyVault -ModuleName Az.KeyVault -VaultParameters @{ AZKVaultName = 'xdmkv'; SubscriptionId = '<sub>' }

	Get-SecretVault

	Unregister-SecretVault -Name AzKeyVault
}

<#
.SYNOPSIS
Test secret management extension function
#>
function Test-SecretManagementExtension
{
	Register-SecretVault -Name AzKeyVault -ModuleName Az.KeyVault -VaultParameters @{ AZKVaultName = 'xdmkv'; SubscriptionId = '<sub>' }

	Get-SecretInfo -Vault AzKeyVault

	[byte[]]$Arr = 1, 2, 3
	Set-Secret -Name byteArraySecret -Secret $Arr -Vault AzKeyVault #ByteArray

	Set-Secret -Name stringSecret -Secret 'test' -Vault AzKeyVault # String value

	$credential = [System.Management.Automation.PSCredential]::new('<user>', ('<pwd>' | ConvertTo-SecureString -AsPlainText -Force)) 
	Set-Secret -Name credentialSecret -Secret $credential -Vault AzKeyVault # PSCredential

	$hashtable = @{'<key>'='<value>'}
	Set-Secret -Name hashtableSecret -Secret $hashtable -Vault AzKeyVault # Hashtable

	$secure = ConvertTo-SecureString -String "<text1>" -AsPlainText -Force
	Set-Secret -Name secureSecret -SecureStringSecret $secure -Vault AzKeyVault

	$secureString = ConvertTo-SecureString -String "<text2>" -AsPlainText -Force
	Set-Secret -Name secureStringSecret -SecureStringSecret $secureString -Vault AzKeyVault

	Get-SecretInfo -Vault AzKeyVault 

	Get-Secret -Vault AzKeyVault -Name secureSecret

	Get-SecretInfo -Vault AzKeyVault | Remove-Secret -Vault AzKeyVault	
}