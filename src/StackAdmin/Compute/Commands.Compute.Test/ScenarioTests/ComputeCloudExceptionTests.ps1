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

function Run-ComputeCloudExceptionTests
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;
        New-AzureRmResourceGroup -Name $rgname -Location $loc -Force;

        $compare = "*Resource*not found*OperationID : *";
        Assert-ThrowsLike { $s1 = Get-AzureRmVM -ResourceGroupName $rgname -Name 'test' } $compare;
        Assert-ThrowsLike { $s2 = Get-AzureRmVM -ResourceGroupName 'foo' -Name 'bar' } $compare;
        Assert-ThrowsLike { $s3 = Get-AzureRmAvailabilitySet -ResourceGroupName $rgname -Name 'test' } $compare;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
