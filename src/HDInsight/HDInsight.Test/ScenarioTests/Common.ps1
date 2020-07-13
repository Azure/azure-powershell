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
Generate the name for cluster,resource group,script action,workspace etc.
#>
function Generate-Name([string] $prefix="hdi-ps-test"){
	return getAssetName($prefix)
}

<#
.SYNOPSIS
Generate storage account name
#>
function Generate-StorageAccountName([string] $prefix="psstorage"){
	return getAssetName($prefix)
}

<#
.SYNOPSIS
Get service principal id
#>
function Get-PrincipalObjectId{
	return [Commands.HDInsight.Test.ScenarioTests.TestHelper]::GetServicePrincipalObjectId()
}

<#
.SYNOPSIS
Add key to vault.
#>
function Create-KeyIdentity{
	param(
		[string] $resourceGroupName="group-ps-cmktest",
		[string] $vaultName="vault-ps-cmktest",
		[string] $keyName="key-ps-cmktest"
		)
	$vault = [Commands.HDInsight.Test.ScenarioTests.TestHelper]::GetVault($resourceGroupName,$vaultName)
	$keyIdentity = [Commands.HDInsight.Test.ScenarioTests.TestHelper]::GenerateVaultKey($vault,$keyName)
	return $keyIdentity
}

<#
.SYNOPSIS
Create cluster
#>
function Create-Cluster{
    param(
      [string] $clusterName="hdi-ps-test",
      [string] $location="East US",
      [string] $resourceGroupName="group-ps-test",
      [string] $clusterType="Spark",
      [string] $storageAccountName="storagepstest",
      [string] $minSupportedTlsVersion="1.2",
      [bool] $enableCMK=$false,
      [string] $assignedIdentityName="ami-ps-cmktest",
	  [string] $vaultName="vault-ps-cmktest",
	  [string] $keyName="key-ps-cmktest"
    )

    $clusterName=Generate-Name($clusterName)
    $resourceGroupName=Generate-Name($resourceGroupName)

    $resourceGroup=New-AzResourceGroup -Name $resourceGroupName -Location $location

    $storageAccountName=Generate-StorageAccountName($storageAccountName)

    $storageAccount= New-AzStorageAccount -ResourceGroupName $resourceGroupName -Location $location -Name $storageAccountName -TypeString "Standard_RAGRS"

    $storageAccountKey=Get-AzStorageAccountKey -ResourceGroupName $resourceGroupName -Name $storageAccountName
    $storageAccountKey=$storageAccountKey[0].Value

    $httpUser="admin"
	$textPassword= "YourPw!00953"
    $httpPassword=ConvertTo-SecureString $textPassword -AsPlainText -Force
    $sshUser="sshuser"
    $sshPassword=$httpPassword
    $httpCredential=New-Object System.Management.Automation.PSCredential($httpUser, $httpPassword)
    $sshCredential=New-Object System.Management.Automation.PSCredential($sshUser, $sshPassword)
    
    $clusterSizeInNodes=2

    if($enableCMK)
    {
        # new user-assigned identity
        $assignedIdentity= New-AzUserAssignedIdentity -ResourceGroupName $resourceGroupName -Name $assignedIdentityName
        $assignedIdentityId=$assignedIdentity.Id
        # new key-vault 
        $encryptionKeyVault=New-AzKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroupName -Location $location
        $principalId = Get-PrincipalObjectId
        # add access police for key-vault
        $encryptionKeyVault=Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ObjectId $principalId -PermissionsToKeys create,import,delete,list -PermissionsToSecrets Get,Set -PermissionsToCertificates Get,List
        $encryptionKeyVault=Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ObjectId $assignedIdentity.PrincipalId -PermissionsToKeys Get,UnwrapKey,WrapKey -PermissionsToSecrets Get,Set,Delete
        # new key identity
        $encryptionKey=Create-KeyIdentity -resourceGroupName $resourceGroupName -vaultName  $vaultName -keyName $keyName
        $encryptionVaultUri=$encryptionKey.Vault
        $encryptionKeyVersion=$encryptionKey.Version
        $encryptionKeyName=$encryptionKey.Name
        # new hdi cluster with cmk
        $cluster=New-AzHDInsightCluster -Location $location -ResourceGroupName $resourceGroup.ResourceGroupName -ClusterName $clusterName `
        -ClusterSizeInNodes $clusterSizeInNodes -ClusterType $clusterType -DefaultStorageAccountName $storageAccountName `
        -DefaultStorageAccountKey $storageAccountKey -HttpCredential $httpCredential -SshCredential $sshCredential  `
        -AssignedIdentity $assignedIdentityId -EncryptionKeyName $encryptionKeyName -EncryptionKeyVersion $encryptionKeyVersion `
        -EncryptionVaultUri $encryptionVaultUri
    }
    else
    {
        $cluster=New-AzHDInsightCluster -Location $location -ResourceGroupName $resourceGroup.ResourceGroupName -ClusterName $clusterName `
        -ClusterSizeInNodes $clusterSizeInNodes -ClusterType $clusterType -DefaultStorageAccountName $storageAccountName `
        -DefaultStorageAccountKey $storageAccountKey -HttpCredential $httpCredential -SshCredential $sshCredential -MinSupportedTlsVersion $minSupportedTlsVersion
    }

    return $cluster
}

<#
.SYNOPSIS
Asserts if two tags are equal
#>
function Assert-Tags($tags1, $tags2)
{
    if($tags1.count -ne $tags2.count)
    {
        throw "Tag size not equal. Tag1: $tags1.count Tag2: $tags2.count"
    }

    foreach($key in $tags1.Keys)
    {
        if($tags1[$key] -ne $tags2[$key])
        {
            throw "Tag content not equal. Key:$key Tags1:" +  $tags1[$key] + "Tags2:" + $tags2[$key]
        }
    }
}

<#
.SYNOPSIS
Asserts if two compression types are equal
#>
function Assert-CompressionTypes($types1, $types2)
{
    if($types1.Count -ne $types1.Count)
    {
        throw "Array size not equal. Types1: $types1.count Types2: $types2.count"
    }

    foreach($value1 in $types1)
    {
        $found = $false
        foreach($value2 in $types2)
        {
            if($value1.CompareTo($value2) -eq 0)
            {
                $found = $true
                break
            }
        }
        if(-Not($found))
        {
            throw "Compression content not equal. " + $value1 + " cannot be found in second array"
        }
    }
}