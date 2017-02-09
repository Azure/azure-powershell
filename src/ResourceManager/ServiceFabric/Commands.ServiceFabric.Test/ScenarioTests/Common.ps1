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

function Get-ResourceGroupName
{
    return "sftestingrg";
}

function Get-ResourceGroupLocation
{
    return "South Central US";
}

function Get-ClusterName
{
    return "sftesting";
}

function Get-NewClusterName
{
	return 'sftestnew'
}

function Get-NewResourceGroupName
{
    return "sftestrgnew";
}

function Get-NodeTypeName
{
    return "nt1vm";
}

function Get-Cert
{
    return ".\Resources\test.pfx";
}

function Get-Pwd
{
    return "123";
}

function Get-KeyVaultName
{
    return "mykvn1";
}

function Get-KeyVaultResourceGroup
{
    return "mykvrg1";
}

function Get-KeyVaultResourceGroupLocation
{
    return "South Central US";
}

function Get-SecretUrl
{
	return 'https://mykvn1.vault.azure.net/secrets/newsftestrg1/2ab7432ce5554650a58509b43225d8aa'
}

function Get-ThumbprintByFile
{
    $CertPath = Get-Cert
    $CertPass = Get-Pwd
    $Cert = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2($CertPath, $CertPass)
	return $Cert.Thumbprint
}

function Get-DurabilityLevel
{
	return "silver"
}

function Get-ReliabilityLevel
{
	return "silver"
}

function Get-NewNodeTypeName
{
	return 'nnt1'
}

function Get-SectionName
{
	return 'NamingService'
}

function Get-ParameterName
{
	return 'MaxFileOperationTimeout'
}

function Get-ValueName
{
	return '5000'
}
