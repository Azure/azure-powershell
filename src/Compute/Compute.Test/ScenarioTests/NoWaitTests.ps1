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
Test NoWait Switch Parameter
#>
function Test-NoWaitParameter
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
		# Common
        $loc = Get-ComputeVMLocation;
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        $vmname = 'vm' + $rgname;
        $user = "Foo12";
        $password = $PLACEHOLDER;
        $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
        [string]$domainNameLabel = "$vmname-$vmname".tolower();
        $vmobject = New-AzVm -Name $vmname -ResourceGroupName $rgname -Credential $cred -DomainNameLabel $domainNameLabel;

		$response = Start-AzVm -ResourceGroupName $rgname -Name $vmname -NoWait
		Assert-NotNull $response.RequestId
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname;
    }
}
