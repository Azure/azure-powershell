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
Gets DevSpaces controller name
#>
function Get-DevSpacesControllerName
{
    return 'devspaces' + (getAssetName)
}

<#
.SYNOPSIS
Gets DevSpaces controller Tag key
#>
function Get-DevSpacesControllerTagKey
{
     return 'tagKey' + (getAssetName)
}

<#
.SYNOPSIS
Gets DevSpaces controller Tag value
#>
function Get-DevSpacesControllerTagValue
{
    return 'tagValue' + (getAssetName)
}

<#
.SYNOPSIS
Compare two controllers.
#>
function Assert-AreEqualPSController($controller1, $controller2)
{
    Assert-AreEqual $controller1.Name $controller2.Name
    Assert-AreEqual $controller1.ResourceGroupName $controller2.ResourceGroupName 
    Assert-AreEqual $controller1.ProvisioningState $controller2.ProvisioningState 
    Assert-AreEqual $controller1.Location $controller2.Location 
}