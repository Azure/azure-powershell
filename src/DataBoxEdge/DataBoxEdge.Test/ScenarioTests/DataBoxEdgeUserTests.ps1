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

function Get-User
{
    return getAssetName
}

<#
.SYNOPSIS
Negative test. Get resources from an non-existing empty group.
#>
function Test-GetNonExistingUser
{	
    $rgname = Get-DeviceResourceGroupName
    $dfname = Get-DeviceName
	$name = Get-User
	
    # Test
	Assert-ThrowsContains { Get-AzDataBoxEdgeUser -ResourceGroupName $rgname -DeviceName $dfname -Name $name  } "not find"    
}


<#
.SYNOPSIS
Tests Create New User
#>
function Test-CreateNewUser
{	
    $rgname = Get-DeviceResourceGroupName
    $dfname = Get-DeviceName
	$name = Get-User
	$password = ConvertTo-SecureString -String "01000000d08c9ddf0115d1118c7a00c04fc297eb01000000e770d502af3fa14e96c5ef76752be9370000000002000000000003660000c00000001000000060335e2334f37d829965a667087d7c7b0000000004800000a00000001000000020cfadf5cd14a21a449f0f277fa7b0ba3800000032917d5e5e230025f0cfa4cb05ea413f6976ea5d4d52a8679005a219edddd1ae9f2f92c959e2ef2e14915d55429fcc257cdaa712427e889f140000003798948a3e86cdc5a82c18dfbdb96ce821bcc6b6"
	$encryptionKey = Get-EncryptionKey
    # Test
	try
    {
        $expected = New-AzDataBoxEdgeUser $rgname $dfname $name -Password $password -EncryptionKey $encryptionKey
		Assert-AreEqual $expected.Name $name
    }
    finally
    {
		Remove-AzDataBoxEdgeUser $rgname $dfname $name
    }  
}


<#
.SYNOPSIS
Test remove User. Creates new user then removes user and try to get the user
#>
function Test-RemoveUser
{	
    $rgname = Get-DeviceResourceGroupName
    $dfname = Get-DeviceName
	$name = Get-User
	$password = ConvertTo-SecureString -String "01000000d08c9ddf0115d1118c7a00c04fc297eb01000000e770d502af3fa14e96c5ef76752be9370000000002000000000003660000c00000001000000060335e2334f37d829965a667087d7c7b0000000004800000a00000001000000020cfadf5cd14a21a449f0f277fa7b0ba3800000032917d5e5e230025f0cfa4cb05ea413f6976ea5d4d52a8679005a219edddd1ae9f2f92c959e2ef2e14915d55429fcc257cdaa712427e889f140000003798948a3e86cdc5a82c18dfbdb96ce821bcc6b6"
	$encryptionKey = Get-EncryptionKey
    # Test
	try
    {
        $expected = New-AzDataBoxEdgeUser $rgname $dfname $name -Password $password -EncryptionKey $encryptionKey
		Assert-AreEqual $expected.Name $name
		Remove-AzDataBoxEdgeUser $rgname $dfname $name
	}
    finally
    {
		Assert-ThrowsContains { Get-AzDataBoxEdgeUser -ResourceGroupName $rgname -DeviceName $dfname -Name $name  } "not find"    
    }  
}