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

$ResourceGroupName = "backuprg"
$ResourceName = "backuprn"
$Name = "dev01testing"
$VMServiceName = "dev01testing"
$ContainerType = "IaasVMContainer"
$Location = "westus"

<#
.SYNOPSIS
Tests to register the container
#>
function Test-RegisterAzureBackupContainer
{
	$jobId = Register-AzureBackupContainer -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -location $Location -Name $VMName -ServiceName $VMServiceName
    
    Assert-NotNull $jobId 'JobID should not be null';
}

function Test-UnregisterAzureBackupContainer
{
    $container = Get-AzureBackupContainer -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -location $Location -ContainerResourceName $VMName -ContainerResourceGroupName $VMServiceName
	$jobId = Unregister-AzureBackupContainer -ResourceGroupName $ResourceGroupName -ResourceName $ResourceName -location $Location -AzureBackupContainer $container
    
    Assert-NotNull $jobId 'JobID should not be null';
}