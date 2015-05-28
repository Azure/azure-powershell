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
Generate Dynamic Tests
#>

$func_get_all_vm_locations =
@'

function get_all_vm_locations
{
    $locations = Get-AzureLocation | where { $_.Name -like 'Microsoft.Compute/virtualMachines' } | select -ExpandProperty Locations;

    for ($i = 0; $i -lt $locations.Count; $i++)
    {
        $locations[$i] = ($locations[$i] -Replace ' ', '').ToLower();
    }

    return $locations;
}

'@;


function Generate-DynamicTests
{
    $num_total_generated_tests = 3;
    $base_folder = '.\generated';

    for ($i = 1; $i -le $num_total_generated_tests; $i++)
    {
        $st = Write-Host ('Generating Test #' + $i);

        $generated_file_name = $base_folder + '\' + 'ps_test_' + $i + '.ps1';

        $st = New-Item -Path $generated_file_name -Value $null -Force;

        $st = $func_get_all_vm_locations | Out-File -FilePath $generated_file_name -Force;
    }
}