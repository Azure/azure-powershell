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
Test Invoke-AzVmAssessPatch cmdlet
#>
function Test-InvokeAzVmAssessPatch
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        $loc = $loc.Replace(' ', '');

        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # VM Profile & Hardware
        $vmsize = 'Standard_DS2_v2';
        $vmname = 'vm' + $rgname;

        # OS & Image
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);

        New-AzVm -resourcegroupname $rgname -location $loc -name $vmName -credential $cred -size $vmsize
        $patchResult = invoke-azvmassesspatch -resourcegroupname $rgname -vmname $vmname
        
        Assert.NotNull($patchResult);
        Assert.Equal("Succeeded", $patchResult.Status);
        Assert.NotNull($patchResult.StartDateTime);

    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}