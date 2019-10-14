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
Gets valid resource group name
#>
function Get-DeviceResourceGroupName
{
    return "psrgpfortest"
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-DeviceName
{
    return "psdataboxedgedevice"
}

<#
.SYNOPSIS
Returns EncryptionKey
#>
function Get-EncryptionKey
{
	$encryptionKey = ConvertTo-SecureString -String "01000000d08c9ddf0115d1118c7a00c04fc297eb01000000e770d502af3fa14e96c5ef76752be9370000000002000000000003660000c0000000100000006019f93214b76a835d9733452ee47a1c0000000004800000a0000000100000000830aff3a8942248169a888690687ac808010000a2c4c90f211417d258a8cf7f26ad4c44817177953db509cbbbdef52b49409866349caecb6ec755ba7f106791700859ab6c0fd967c7de8df811e9c3ad4f6d7b807f0b863c63d05d8ed39ec8520cb5b6a252a2ce8db7a83135fd08f2155138642b9cc6a205df1ed5b53961d8125ddbbbf3504b0e1bf8db9d711506904520a1f6f31cfbbb9c1a5750cee6c7090e7fc9398891e3221a3c90aef798f05e52200ebfcad615c3802509c664f317d2b63933227dbbd3abfa5b280d1855643bd2f51fe97dfdecf4177c7084eeb5bbb56ec74319a37fd5bc724ea9728667879e8fb31e3f3949e22aa0bfbe545cb25ce24bd8ddcb4e0e1b8c6929e4573411f2e3f773a44e9b2959805e8e303e22140000005fc8b0ec0769223a9c400a0c3aa7e62b2975968e"
	return $encryptionKey 
}

<#
.SYNOPSIS
Gets valid storage account name
#>
function Get-StorageAccountName
{
    return getAssetName
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
Sleep in record mode only
#>
function SleepInRecordMode ([int]$SleepIntervalInSec)
{
    $mode = $env:AZURE_TEST_MODE
    if ( $mode -ne $null -and $mode.ToUpperInvariant() -eq "RECORD")
    {
        Wait-Seconds $SleepIntervalInSec 
    }
}

