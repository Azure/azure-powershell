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
Test SshKeyResource creation
#>
function Test-SshKey
{
	$loc = 'westus'
	$rgname = Get-ComputeTestResourceName

	try 
	{
		New-AzResourceGroup -Name $rgname -Location $loc -Force;

		#create sshkey1
		$sshkey1 = New-AzSshKey -ResourceGroupName $rgname -Name "sshkey1"

		#create sshkey2
		$sshkey2 = New-AzSshKey -ResourceGroupName $rgname -Name "sshkey2"

		#Get-AzSshKey should return 2
		$sshKeysResult = Get-AzSshKey -ResourceGroupName $rgname
		Assert-AreEqual $sshKeysResult.count 2

		#update key1.publickey with publickey2
		Update-AzSshKey -ResourceGroupName $rgname -Name "sshkey1" -publickey $sshKey2.publicKey

		#check key1
		$sshkey1 = Get-AzSshKey -ResourceGroupName $rgname -Name "sshkey1"
		Assert-AreEqual $sshkey1.publickey $sshkey2.publickey

		#remove sshkey2
		Remove-AzSshKey -ResourceGroupName $rgname -Name "sshkey2"

		#getshould return1 
		$sshKeysResult = Get-AzSshKey -ResourceGroupName $rgname
		Assert-AreEqual $sshKeysResult.count 1
	}
	finally
	{
		Clean-ResourceGroup $rgname
	}

}
