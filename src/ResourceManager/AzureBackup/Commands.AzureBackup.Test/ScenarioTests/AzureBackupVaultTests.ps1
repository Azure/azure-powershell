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
$Location = "SouthEast Asia"
$CertTargetLocation = (Get-Item -Path ".\" -Verbose).FullName;

function Test-GetAzureBackupVaultCredentialsReturnsFileNameAndDownloadsCert
{
	$fileName = Get-AzureBackupVaultCredentials -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -TargetLocation $CertTargetLocation
	Assert-NotNull $fileName 'File name should not be null';
	$certFileFullPath = [io.path]::combine($CertTargetLocation, $fileName);
	Assert-True {{ Test-Path $certFileFullPath }}
}

function Test-SetAzureBackupVaultStorageTypeWithFreshResourceDoesNotThrowException
{
	# TODO: Create a new resource and use it for these calls. At the end, delete it.

	Set-AzureBackupVaultStorageType -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -Type GeoRedundant

	Set-AzureBackupVaultStorageType -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -Type LocallyRedundant

	Set-AzureBackupVaultStorageType -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -Type GeoRedundant

	Set-AzureBackupVaultStorageType -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -Type LocallyRedundant
}

function Test-SetAzureBackupVaultStorageTypeWithLockedResourceThrowsException
{
	# One of them is bound to fail

	Assert-Throws { Set-AzureBackupVaultStorageType -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -Type GeoRedundant }

	Assert-Throws { Set-AzureBackupVaultStorageType -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -Location $Location -Type LocallyRedundant }
}
