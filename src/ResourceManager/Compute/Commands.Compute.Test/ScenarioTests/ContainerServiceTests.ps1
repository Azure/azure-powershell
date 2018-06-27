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
Test Container Service
#>
function Test-ContainerService
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'australiasoutheast';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        $csName = 'cs' + $rgname;
        $masterDnsPrefixName = 'master' + $rgname;
        $agentPoolDnsPrefixName = 'ap' + $rgname;
        $agentPoolProfileName = 'AgentPool1';
        $vmSize = 'Standard_A1';

        $orchestratorType = 'DCOS';
        $adminUserName = 'acslinuxadmin';
        $sshPublicKey =
            "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2" +
            "MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2" +
            "oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgE" +
            "Sgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h" +
            "9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417" + 
            "u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4" +
            "bL acs-bot@microsoft.com";

        $job = New-AzureRmContainerServiceConfig -Location $loc -OrchestratorType $orchestratorType `
            -MasterDnsPrefix $masterDnsPrefixName -AdminUsername $adminUserName -SshPublicKey $sshPublicKey `
        | Add-AzureRmContainerServiceAgentPoolProfile -Name $agentPoolProfileName -VmSize $vmSize -DnsPrefix $agentPoolDnsPrefixName -Count 1 `
        | New-AzureRmContainerService -ResourceGroupName $rgname -Name $csName -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $container = $job | Receive-Job

        $cs = Get-AzureRmContainerService -ResourceGroupName $rgname -Name $csName;
        $output = $cs | Out-String;
        Assert-True { $output.Contains("AgentPoolProfiles") };

        $cslist = Get-AzureRmContainerService -ResourceGroupName $rgname;
        $output = $cslist | Out-String;
        Assert-False { $output.Contains("AgentPoolProfiles") };

        $job = Remove-AzureRmContainerService -ResourceGroupName $rgname -Name $csName -Force -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;
        $st = $job | Receive-Job
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Container Service Update
#>
function Test-ContainerServiceUpdate
{
    # Setup
    $rgname = Get-ComputeTestResourceName

    try
    {
        # Common
        $loc = 'australiasoutheast';
        New-AzureRMResourceGroup -Name $rgname -Location $loc -Force;

        $csName = 'cs' + $rgname;
        $masterDnsPrefixName = 'master' + $rgname;
        $agentPoolDnsPrefixName = 'ap' + $rgname;
        $agentPoolProfileName = 'AgentPool1';
        $vmSize = 'Standard_A1';

        $orchestratorType = 'DCOS';
        $adminUserName = 'acslinuxadmin';
        $sshPublicKey =
            "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQDorij8dGcKUBTbvHylBpm5NZ2" +
            "MtDgn1+jbyHE8N4dCS4ZoIl6Pdoa1At/GjXVhIRuz1hlyT2ey5BaC8iQnQTh/f2" +
            "oyNctQ5+2KX1sgFlvaQAJCVn0tN7yDT29ZiIE2kfL3RCV5HH7p+NjBQ/cvtaOgE" +
            "Sgoi/CI3S58w1XaRdDKo5Uz0U0DDuuB5lO5dq4nceAH8sx2bFTNjlgJcoyxi13h" +
            "9CYkymm0mVaZkwiIJY8cU+UrupZKCMboBbCM7Q2spmRQ1tGicT5g84PsCqUf417" + 
            "u+Jvtf0kD1GdsCyMGALzBDS0scORhMiXHZ/vEM6rOPCIBpH7IzeULhWGXZfPdg4" +
            "bL acs-bot@microsoft.com";

        $container = New-AzureRmContainerServiceConfig -Location $loc `
            -OrchestratorType $orchestratorType `
            -MasterDnsPrefix $masterDnsPrefixName `
            -MasterCount 1 `
            -AdminUsername $adminUserName `
            -SshPublicKey $sshPublicKey `
        | Add-AzureRmContainerServiceAgentPoolProfile -Name $agentPoolProfileName `
            -VmSize $vmSize `
            -DnsPrefix $agentPoolDnsPrefixName `
            -Count 1 `
        | New-AzureRmContainerService -ResourceGroupName $rgname -Name $csName;

        $job = Get-AzureRmContainerService -ResourceGroupName $rgname -Name $csName `
        | Remove-AzureRmContainerServiceAgentPoolProfile -Name $agentPoolProfileName `
        | Add-AzureRmContainerServiceAgentPoolProfile -Name $agentPoolProfileName `
            -VmSize $vmSize `
            -DnsPrefix $agentPoolDnsPrefixName `
            -Count 2 `
        | Update-AzureRmContainerService -AsJob;
        $result = $job | Wait-Job;
        Assert-AreEqual "Completed" $result.State;

        $st = Get-AzureRmContainerService -ResourceGroupName $rgname -Name $csName | Remove-AzureRmContainerService -Force;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

