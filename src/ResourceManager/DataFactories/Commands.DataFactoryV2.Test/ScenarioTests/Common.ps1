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
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid data factory name
#>
function Get-DataFactoryName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets the default location for a provider
#>
function Get-ProviderLocation($provider)
{
    # A Dogfood data center for ADF cmdlet mock testing
    "West Europe"
}

<#
.SYNOPSIS
Cleans the created resources
#>
function CleanUp($rgname, $dfname)
{
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        Remove-AzureRmDataFactoryV2 -ResourceGroupName $rgname -Name $dfname -Force
        Remove-AzureRmResourceGroup -Name $rgname -Force
    }
}

<#
.SYNOPSIS
Verifies the properties of two AdfSubResource PS objects
#>
function Verify-AdfSubResource ($expected, $actual, $rgname, $dfname, $name)
{
    Assert-NotNull $actual.Id
    Assert-NotNull $actual.ETag
    Assert-NotNull $actual.Name
    Assert-NotNull $actual.ResourceGroupName
    Assert-NotNull $actual.DataFactoryName

    Assert-AreEqual $rgname $actual.ResourceGroupName
    Assert-AreEqual $dfname $actual.DataFactoryName
    Assert-AreEqual $name $actual.Name

    Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
    Assert-AreEqual $expected.DataFactoryName $actual.DataFactoryName
    Assert-AreEqual $expected.Id $actual.Id
    Assert-AreEqual $expected.ETag $actual.ETag
    Assert-AreEqual $expected.Name $actual.Name
}
