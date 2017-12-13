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
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVm
{
    # Setup
    $vmname = Get-ResourceName

    try
    {
		$username = "admin01"
		$password = "werWER345#%^" | ConvertTo-SecureString -AsPlainText -Force
		$cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password

        # Common
		$x = New-AzureRmVM -Name $vmname -Credential $cred

		Assert-AreEqual $vmname $x.Name;		
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}
