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

$ResourceGroupName = "backuprg"
$ResourceName = "backuprn"
$Location = "southeastasia"
$CertTargetLocation = (Get-Item -Path ".\" -Verbose).FullName;

function Test-AzureBackupVaultScenario
{
	$vault = New-AzureRmBackupVault -ResourceGroupName $ResourceGroupName -Name $ResourceName -Region $Location -Storage "LocallyRedundant";
	Assert-AreEqual $vault.Name $ResourceName;
	Assert-AreEqual $vault.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $vault.Region $Location;
	Assert-AreEqual $vault.Storage "LocallyRedundant";

	$vault = Get-AzureRmBackupVault -ResourceGroupName $ResourceGroupName -Name $ResourceName
	Assert-AreEqual $vault.Name $ResourceName;
	Assert-AreEqual $vault.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $vault.Region $Location;
	Assert-AreEqual $vault.Storage "LocallyRedundant";
	
	$fileName = Get-AzureRmBackupVaultCredentials -vault $vault -TargetLocation $CertTargetLocation
	Assert-NotNull $fileName 'File name should not be null';
	$certFileFullPath = [io.path]::combine($CertTargetLocation, $fileName);
	Assert-True {{ Test-Path $certFileFullPath }}

	$vault = Set-AzureRmBackupVault -vault $vault -Storage "GeoRedundant";
	Assert-AreEqual $vault.Name $ResourceName;
	Assert-AreEqual $vault.ResourceGroupName $ResourceGroupName;
	Assert-AreEqual $vault.Region $Location;
	Assert-AreEqual $vault.Storage "GeoRedundant";

	Remove-AzureRmBackupVault -Vault $vault -Force;	
}
