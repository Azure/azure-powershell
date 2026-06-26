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
function Test-SimpleNewVmss
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $lbName = $vmssname + "LoadBalancer"
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();
        $stnd = "Standard";

        # Common
        $x = New-AzVmss -Name $vmssname -Credential $cred -DomainNameLabel $domainNameLabel -LoadBalancerName $lbName -SecurityType $stnd

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-False { $x.VirtualMachineProfile.AdditionalCapabilities.UltraSSDEnabled };
        Assert-AreEqual "Standard_DS1_v2" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
        Assert-False { $x.SinglePlacementGroup }
        Assert-Null $x.Identity  

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $vmssname 
        Assert-NotNull $lb
        Assert-AreEqual $lbName $lb.Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmssFromSIGImage
{
    #This test needs to be run form the following subscription in record mode :
    # 9e223dbe-3399-4e19-88eb-0975f02ac87f
    #The vm needs to be created in the one of the following regions :
    # "South Central US", "East US 2" and "Central US"
    #To see more information on the steps to create a new SIG image go here: https://aka.ms/AA37jbt
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $lbName = $vmssname + "LoadBalancer"
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();

        # Common
        $x = New-AzVmss -Name $vmssname -Credential $cred -DomainNameLabel $domainNameLabel -LoadBalancerName $lbName -Location "East US 2" -VmSize "Standard_D2s_v3" -ImageName "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/SIGTestGroupoDoNotDelete/providers/Microsoft.Compute/galleries/SIGTestGalleryDoNotDelete/images/SIGTestImageWindowsDoNotDelete" 

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-False { $x.VirtualMachineProfile.AdditionalCapabilities.UltraSSDEnabled };
        Assert-AreEqual "Standard_D2s_v3" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/SIGTestGroupoDoNotDelete/providers/Microsoft.Compute/galleries/SIGTestGalleryDoNotDelete/images/SIGTestImageWindowsDoNotDelete" $x.VirtualMachineProfile.StorageProfile.ImageReference.Id
        Assert-Null $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
        Assert-False { $x.SinglePlacementGroup }
        Assert-Null $x.Identity  

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $vmssname 
        Assert-NotNull $lb
        Assert-AreEqual $lbName $lb.Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmssWithUltraSSD
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $lbName = $vmssname + "LoadBalancer"
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();

        # Common
        #As of now the ultrasd feature is only supported in east us 2 and in the size Standard_D2s_v3, on the features GA the restriction will be lifted
        #Use the follwing command to figure out the one to use 
        #Get-AzComputeResourceSku | where {$_.ResourceType -eq "disks" -and $_.Name -eq "UltraSSD_LRS" }
        $x = New-AzVmss -Name $vmssname -Credential $cred -DomainNameLabel $domainNameLabel -LoadBalancerName $lbName -Location "east us 2" -EnableUltraSSD -Zone 3 -VmSize "Standard_D2s_v3"

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-True { $x.AdditionalCapabilities.UltraSSDEnabled };
        Assert-AreEqual "Standard_D2s_v3" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
        Assert-False { $x.SinglePlacementGroup }
        Assert-Null $x.Identity  

        $lb = Get-AzLoadBalancer -Name $lbName -ResourceGroupName $vmssname 
        Assert-NotNull $lb
        Assert-AreEqual $lbName $lb.Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm failure when custom load balancer exists
#>
function Test-SimpleNewVmssLbErrorScenario
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $lbName = $vmssname
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();
        $stnd = "Standard";

        $x = New-AzVmss -Name $vmssname -Credential $cred -DomainNameLabel $domainNameLabel -SecurityType $stnd

        Assert-AreEqual $vmssname $x.Name;
        $lb = Get-AzLoadBalancer -Name $vmssname -ResourceGroupName $vmssname 
        Remove-AzVmss -Name $vmssname -ResourceGroupName $vmssname -Force

        $exceptionFound = $false
        $errorMessageMatched = $false

        try
        {
            $newVmssName = $vmssname + "New"
            $x = New-AzVmss -Name $newVmssName -Credential $cred -DomainNameLabel $domainNameLabel -ResourceGroupName $vmssname -LoadBalancerName $lbName -SecurityType $stnd
        }
        catch
        {
            $errorMessage = $_.Exception.Message
            $exceptionFound = ( $errorMessage -clike "Existing loadbalancer config is not compatible with what is required by the cmdlet*" )
            $rId = $lb.ResourceId
            $errorMessageMatched = ( $errorMessage -like "*$rId*" )
        }

        Assert-True { $exceptionFound }
        Assert-True { $errorMessageMatched }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

function Test-SimpleNewVmssWithSystemAssignedIdentity
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();
        $stnd = "Standard";

        # Common
        $x = New-AzVmss -Name $vmssname -Credential $cred -DomainNameLabel $domainNameLabel -SystemAssignedIdentity -SinglePlacementGroup -SecurityType $stnd

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-AreEqual "Standard_DS1_v2" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
        Assert-AreEqual "SystemAssigned" $x.Identity.Type     
        Assert-NotNull  $x.Identity.PrincipalId
        Assert-NotNull  $x.Identity.TenantId
        Assert-True { $x.SinglePlacementGroup }
        Assert-Null $x.Identity.IdentityIds  
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

function Test-SimpleNewVmssWithsystemAssignedUserAssignedIdentity
{
    # Setup
    $vmssname = "UAITG123456"

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();
        $stnd = "Standard";

        # To record this test run these commands first :
        # New-AzResourceGroup -Name UAITG123456 -Location 'Central US'
        # New-AzUserAssignedIdentity -ResourceGroupName  UAITG123456 -Name UAITG123456Identity
        # 
        # Now get the identity :
        # 
        # Get-AzUserAssignedIdentity -ResourceGroupName UAITG123456 -Name UAITG123456Identity
        # Note down the Id and use it in the PS code
        # $identityName = $vmname + "Identity"
        # $newUserIdentity =  New-AzUserAssignedIdentity -ResourceGroupName $vmname -Name $identityName

        #$newUserId = $newUserIdentity.Id
        
        $newUserId = "/subscriptions/24fb23e3-6ba3-41f0-9b6e-e41131d5d61e/resourcegroups/UAITG123456/providers/Microsoft.ManagedIdentity/userAssignedIdentities/UAITG123456Identity"

        # Common
        $x = New-AzVmss -Name $vmssname -Credential $cred -DomainNameLabel $domainNameLabel -UserAssignedIdentity $newUserId -SystemAssignedIdentity -SinglePlacementGroup -SecurityType $stnd

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-AreEqual "Standard_DS1_v2" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
        Assert-AreEqual "UserAssigned" $x.Identity.Type     
        Assert-NotNull  $x.Identity.PrincipalId
        Assert-NotNull  $x.Identity.TenantId
        Assert-NotNull $x.Identity.UserAssignedIdentities
        Assert-AreEqual 1 $x.Identity.UserAssignedIdentities.Count
        Assert-True { $x.Identity.UserAssignedIdentities.ContainsKey($newUserId) }
        Assert-NotNull $x.Identity.UserAssignedIdentities[$newUserId].PrincipalId
        Assert-NotNull $x.Identity.UserAssignedIdentities[$newUserId].ClientId
        Assert-True { $x.SinglePlacementGroup }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmssImageName
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();

        # Common
        $x = New-AzVmss `
            -Name $vmssname `
            -Credential $cred `
            -DomainNameLabel $domainNameLabel `
            -SinglePlacementGroup `
            -ImageName "MicrosoftWindowsServer:WindowsServer:2016-Datacenter:latest"

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-AreEqual "Standard_DS1_v2" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
        Assert-True { $x.SinglePlacementGroup }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

function Test-SimpleNewVmssWithoutDomainName
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        $stnd = "Standard";
        
        # Common
        $x = New-AzVmss -Name $vmssname -Credential $cred -SinglePlacementGroup -SecurityType $stnd

        Assert-AreEqual $vmssname $x.Name;
        Assert-AreEqual $vmssname $x.ResourceGroupName;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].Name;
        Assert-AreEqual $vmssname $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Name;
        Assert-AreEqual "Standard_DS1_v2" $x.Sku.Name
        Assert-AreEqual $username $x.VirtualMachineProfile.OsProfile.AdminUsername
        Assert-AreEqual "2016-Datacenter" $x.VirtualMachineProfile.StorageProfile.ImageReference.Sku
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].LoadBalancerBackendAddressPools;
        Assert-NotNull $x.VirtualMachineProfile.NetworkProfile.NetworkInterfaceConfigurations[0].IpConfigurations[0].Subnet
        Assert-True { $x.SinglePlacementGroup }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmssPpg
{
    # Setup
    $rgname = Get-ResourceName

    try
    {
        $vmssname = "MyVmss"
        $ppgname = "MyPpg"
        $lbName = $vmssname + "LoadBalancer"
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();
        $stnd = "Standard";

        # Common
        $rg = New-AzResourceGroup -Name $rgname -Location "eastus"
        $ppg = New-AzProximityPlacementGroup `
            -ResourceGroupName $rgname `
            -Name $ppgname `
            -Location "eastus"
        $vmss = New-AzVmss -Name $vmssname -ResourceGroup $rgname -Credential $cred -DomainNameLabel $domainNameLabel -LoadBalancerName $lbName -ProximityPlacementGroupId $ppgname -SecurityType $stnd

        Assert-AreEqual $vmss.ProximityPlacementGroup.Id $ppg.Id
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set With HostGroup (automatic placement)
#>
function Test-SimpleNewVmssHostGroup
{
    # Setup
    $rgname = Get-ResourceName

    try
    {
        # Common
        [string]$loc = Get-Location "Microsoft.Resources" "resourceGroups" "East US 2 EUAP";
        $loc = $loc.Replace(' ', '');
        $zone = "2"
        $stnd = "Standard";
        
        # Creating the resource group
        New-AzResourceGroup -Name $rgname -Location $loc -Force;

        # Hostgroup and Host
        $hostGroupName = $rgname + "HostGroup"
        $hostGroup = New-AzHostGroup -ResourceGroupName $rgname -Name $hostGroupName -Location $loc -PlatformFaultDomain 2 -Zone $zone -SupportAutomaticPlacement $true -Tag @{key1 = "val1"};

        $Sku = "Dsv3-Type1"
        $hostName = $rgname + "Host"
        New-AzHost -ResourceGroupName $rgname -HostGroupName $hostGroupName -Name $hostName -Location $loc -Sku $Sku -PlatformFaultDomain 1 -Tag @{test = "true"}

        # Creating a new vmss
        $VmSku = "Standard_D2s_v3"
        $vmssname = "MyVmss"
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        $vmss = New-AzVmss -Name $vmssname -ResourceGroup $rgname -Credential $cred -HostGroupId $hostGroup.Id -Zone $zone -VmSize $VmSku -DomainNameLabel "myvmss-48e3cf" -SecurityType $stnd

        Assert-AreEqual $vmss.HostGroup.Id $hostGroup.Id
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vmss with eviction policy, priority, and max price.
#>
function Test-SimpleNewVmssBilling
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();

        # Common
        $x = New-AzVmss -Name $vmssname -Location "westus2" -Credential $cred -DomainNameLabel $domainNameLabel `
                        -EvictionPolicy 'Deallocate' -Priority 'Low' -MaxPrice 0.2;
    }
    catch
    {
        Assert-True { $Error[0].ToString().Contains("OS provisioning failure"); }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vmss with ScaleInPolicy.
#>
function Test-SimpleNewVmssScaleInPolicy
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();

        # Common
        New-AzVmss -Name $vmssname -Location "westus2" -Credential $cred -DomainNameLabel $domainNameLabel `
                   -ScaleInPolicy 'Default';
        $vm = Get-AzVmss -ResourceGroupName $vmssname -Name $vmssname;
        Assert-AreEqual "Default" $vm.ScaleInPolicy.Rules;
    }
    catch
    {
        Assert-True { $Error[0].ToString().Contains("OS provisioning failure"); }
        $vm = Get-AzVmss -ResourceGroupName $vmssname -Name $vmssname;
        Assert-AreEqual "Default" $vm.ScaleInPolicy.Rules;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vmss with SkipExtensionsOnOverprovisionedVMs.
#>
function Test-SimpleNewVmssSkipExtOverprovision
{
    # Setup
    $vmssname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmssname$vmssname".tolower();
        $stnd = "Standard";

        # Common
        New-AzVmss -Name $vmssname -Location "westus2" -Credential $cred -DomainNameLabel $domainNameLabel -SecurityType $stnd `
                   -SkipExtensionsOnOverprovisionedVMs;
        $vmss = Get-AzVmss -ResourceGroupName $vmssname -Name $vmssname;
        Assert-True { $vmss.DoNotRunExtensionsOnOverprovisionedVMs };
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmssname
    }
}

<#
.SYNOPSIS
Test New-AzVmssLifecycleHookConfig creates an in-memory lifecycle hook config object.
#>
function Test-VmssLifecycleHookConfig
{
    # Test creating a lifecycle hook config object in memory (no Azure calls needed)
    $hook = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSScheduling' -WaitDuration 'PT8H'
    Assert-NotNull $hook
    Assert-AreEqual 'UpgradeAutoOSScheduling' $hook.Type
    Assert-AreEqual ([System.TimeSpan]::FromHours(8)) $hook.WaitDuration
    # When -DefaultAction is omitted, the cmdlet leaves it null so the SDK omits the field
    # from the request and the service applies its own default.
    Assert-Null $hook.DefaultAction

    # With explicit default action
    $hook2 = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSRollingBatchStarting' -WaitDuration 'PT30M' -DefaultAction 'Approve'
    Assert-NotNull $hook2
    Assert-AreEqual 'UpgradeAutoOSRollingBatchStarting' $hook2.Type
    Assert-AreEqual ([System.TimeSpan]::FromMinutes(30)) $hook2.WaitDuration
    Assert-AreEqual 'Approve' $hook2.DefaultAction

    # Without wait duration
    $hook3 = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSScheduling'
    Assert-NotNull $hook3
    Assert-Null $hook3.WaitDuration
    Assert-Null $hook3.DefaultAction
}

<#
.SYNOPSIS
Test Set-AzVmssLifecycleHooksProfile attaches hooks to a VMSS config and round-trips through the service.
#>
function Test-SetVmssLifecycleHooksProfile
{
    # Tests the Set-AzVmssLifecycleHooksProfile builder cmdlet end-to-end:
    # Build VMSS config -> attach hook via Set-AzVmssLifecycleHooksProfile -> deploy -> verify hook round-tripped from service.
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = "eastus2euap"
        New-AzResourceGroup -Name $rgname -Location $loc -Force

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24" -DefaultOutboundAccess $false
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet
        $subnetId = $vnet.Subnets[0].Id

        $vmssName       = 'vmss' + $rgname
        $adminUsername  = 'Foo12'
        $adminPassword  = $PLACEHOLDER
        $ipCfg          = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId -Primary

        # Build a basic VMSS config WITHOUT hooks
        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 1 -SkuName 'Standard_DS1_v2' -UpgradePolicyMode 'Automatic' `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
                -ImageReferenceOffer 'WindowsServer' -ImageReferenceSku '2022-Datacenter' `
                -ImageReferenceVersion 'latest' -ImageReferencePublisher 'MicrosoftWindowsServer'

        # Attach hook via the builder cmdlet under test
        $hook = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSScheduling' -WaitDuration 'PT8H' -DefaultAction 'Approve'
        $vmss = Set-AzVmssLifecycleHooksProfile -VirtualMachineScaleSet $vmss -LifecycleHook $hook

        # Pre-deploy assertion: hook is on the in-memory object
        Assert-NotNull $vmss.LifecycleHooksProfile
        Assert-AreEqual 1 $vmss.LifecycleHooksProfile.LifecycleHooks.Count

        # Deploy
        $created = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss
        Assert-NotNull $created

        # Read back from service and verify the hook round-tripped
        $read = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName
        Assert-NotNull $read.LifecycleHooksProfile
        Assert-AreEqual 1 $read.LifecycleHooksProfile.LifecycleHooks.Count
        Assert-AreEqual 'UpgradeAutoOSScheduling' $read.LifecycleHooksProfile.LifecycleHooks[0].Type
        Assert-AreEqual ([System.TimeSpan]::FromHours(8)) $read.LifecycleHooksProfile.LifecycleHooks[0].WaitDuration
        Assert-AreEqual 'Approve' $read.LifecycleHooksProfile.LifecycleHooks[0].DefaultAction
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test New-AzVmssConfig with -LifecycleHooksProfile parameter round-trips through the service.
#>
function Test-NewVmssConfigWithLifecycleHooksProfile
{
    # Tests the inline -LifecycleHooksProfile parameter on New-AzVmssConfig end-to-end:
    # Build profile -> New-AzVmssConfig -LifecycleHooksProfile -> deploy -> verify hook round-tripped from service.
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = "eastus2euap"
        New-AzResourceGroup -Name $rgname -Location $loc -Force

        # NRP
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24" -DefaultOutboundAccess $false
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet
        $subnetId = $vnet.Subnets[0].Id

        $vmssName       = 'vmss' + $rgname
        $adminUsername  = 'Foo12'
        $adminPassword  = $PLACEHOLDER
        $ipCfg          = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId -Primary

        # Build a LifecycleHooksProfile inline and pass it directly to New-AzVmssConfig
        $hook = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSScheduling' -WaitDuration 'PT8H' -DefaultAction 'Approve'
        $hooksProfile = [Microsoft.Azure.Management.Compute.Models.LifecycleHooksProfile]::new()
        $hooksProfile.LifecycleHooks = [System.Collections.Generic.List[Microsoft.Azure.Management.Compute.Models.LifecycleHook]]::new()
        $hooksProfile.LifecycleHooks.Add($hook)

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 1 -SkuName 'Standard_DS1_v2' -UpgradePolicyMode 'Automatic' -LifecycleHooksProfile $hooksProfile `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
                -ImageReferenceOffer 'WindowsServer' -ImageReferenceSku '2022-Datacenter' `
                -ImageReferenceVersion 'latest' -ImageReferencePublisher 'MicrosoftWindowsServer'

        # Pre-deploy assertion: profile is on the in-memory object
        Assert-NotNull $vmss.LifecycleHooksProfile
        Assert-AreEqual 1 $vmss.LifecycleHooksProfile.LifecycleHooks.Count

        # Deploy
        $created = New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss
        Assert-NotNull $created

        # Read back from service and verify
        $read = Get-AzVmss -ResourceGroupName $rgname -VMScaleSetName $vmssName
        Assert-NotNull $read.LifecycleHooksProfile
        Assert-AreEqual 1 $read.LifecycleHooksProfile.LifecycleHooks.Count
        Assert-AreEqual 'UpgradeAutoOSScheduling' $read.LifecycleHooksProfile.LifecycleHooks[0].Type
        Assert-AreEqual ([System.TimeSpan]::FromHours(8)) $read.LifecycleHooksProfile.LifecycleHooks[0].WaitDuration
        Assert-AreEqual 'Approve' $read.LifecycleHooksProfile.LifecycleHooks[0].DefaultAction
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}


<#
.SYNOPSIS
End-to-end test for Get-AzVmssLifecycleHookEvent (List + Get-single) and Update-AzVmssLifecycleHookEvent
(WaitUntil delay + ActionState=Approved).

Uses the seekAutoOSUpgradeApproval admin REST endpoint (via Invoke-AzRestMethod) to synthesize a
lifecycle hook event on demand, instead of waiting for the platform's AutoOSUpgrade scheduler.

Flow:
  1. Deploy a 1-instance Uniform VMSS with AutomaticOSUpgrade enabled, Application Health (Linux)
     extension, and a UpgradeAutoOSScheduling lifecycle hook attached.
  2. POST to /seekAutoOSUpgradeApproval with the same platformImageReference used for the VMSS.
  3. LIST events -- should now contain exactly 1.
  4. GET the event by name.
  5. UPDATE -WaitUntil by +10 min.
  6. UPDATE -ActionState 'Approved'.
  7. GET the event again -- assert both updates persisted.
#>
function Test-VmssLifecycleHookEventEndToEnd
{
    $rgname = Get-ComputeTestResourceName

    try
    {
        $loc = "eastus2euap"
        New-AzResourceGroup -Name $rgname -Location $loc -Force

        # NRP (subnet must be defaultOutboundAccess=$false for the sub's policy)
        $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24" -DefaultOutboundAccess $false
        $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet
        $subnetId = $vnet.Subnets[0].Id

        # Image reference (must match the body of seekAutoOSUpgradeApproval below)
        $publisher = 'canonical'
        $offer     = '0001-com-ubuntu-server-focal'
        $sku       = '20_04-lts-gen2'
        $version   = 'latest'

        $vmssName       = 'vmss' + $rgname
        $adminUsername  = 'foo12'
        $adminPassword  = $PLACEHOLDER
        $ipCfg          = New-AzVmssIPConfig -Name 'test' -SubnetId $subnetId -Primary

        # 1-instance Uniform VMSS with AutoOSUpgrade + Application Health extension + lifecycle hook attached.
        $hook = New-AzVmssLifecycleHookConfig -Type 'UpgradeAutoOSScheduling' -WaitDuration 'PT1H' -DefaultAction 'Approve'

        $vmss = New-AzVmssConfig -Location $loc -SkuCapacity 1 -SkuName 'Standard_DS1_v2' `
                -OrchestrationMode 'Uniform' -UpgradePolicyMode 'Automatic' -EnableAutomaticOSUpgrade `
            | Add-AzVmssNetworkInterfaceConfiguration -Name 'test' -Primary $true -IPConfiguration $ipCfg `
            | Set-AzVmssOSProfile -ComputerNamePrefix 'test' -AdminUsername $adminUsername -AdminPassword $adminPassword `
            | Set-AzVmssStorageProfile -OsDiskCreateOption 'FromImage' -OsDiskCaching 'None' `
                -ImageReferenceOffer $offer -ImageReferenceSku $sku `
                -ImageReferenceVersion $version -ImageReferencePublisher $publisher

        # AutoOSUpgrade requires a health probe or health extension.
        Add-AzVmssExtension -VirtualMachineScaleSet $vmss `
            -Name 'AppHealth' `
            -Publisher 'Microsoft.ManagedServices' `
            -Type 'ApplicationHealthLinux' `
            -TypeHandlerVersion '1.0' `
            -Setting @{ protocol = 'http'; port = 80; requestPath = '/' } `
            -AutoUpgradeMinorVersion $true | Out-Null

        $vmss = Set-AzVmssLifecycleHooksProfile -VirtualMachineScaleSet $vmss -LifecycleHook $hook

        New-AzVmss -ResourceGroupName $rgname -Name $vmssName -VirtualMachineScaleSet $vmss

        # Synthesize a lifecycle hook event via the admin REST endpoint.
        # The platformImageReference must match the image used to deploy the VMSS.
        $subId = (Get-AzContext).Subscription.Id
        $apiPath = "/subscriptions/$subId/resourceGroups/$rgname/providers/Microsoft.Compute/virtualMachineScaleSets/$vmssName/seekAutoOSUpgradeApproval?api-version=2025-11-01"
        $body = @{
            platformImageReference = @{
                publisher = $publisher
                offer     = $offer
                sku       = $sku
                version   = $version
            }
        } | ConvertTo-Json -Depth 5
        $approval = Invoke-AzRestMethod -Method POST -Path $apiPath -Payload $body
        Assert-True { $approval.StatusCode -ge 200 -and $approval.StatusCode -lt 300 } "seekAutoOSUpgradeApproval returned HTTP $($approval.StatusCode): $($approval.Content)"

        # Bounded short poll for the synthesized event to materialize (event count must reach 1).
        $events = $null
        for ($i = 0; $i -lt 10; $i++)
        {
            $events = Get-AzVmssLifecycleHookEvent -ResourceGroupName $rgname -VMScaleSetName $vmssName
            if ($events -and @($events).Count -gt 0) { break }
            Start-TestSleep -Seconds 30
        }
        Assert-NotNull $events "Expected Get-AzVmssLifecycleHookEvent to return at least one event after seekAutoOSUpgradeApproval"
        Assert-AreEqual 1 @($events).Count
        $event = @($events)[0]

        # GET single event by name and verify
        $fetched = Get-AzVmssLifecycleHookEvent -ResourceGroupName $rgname -VMScaleSetName $vmssName -Name $event.Name
        Assert-NotNull $fetched
        Assert-AreEqual $event.Name $fetched.Name

        # UPDATE WaitUntil: delay by 10 min
        $currentWaitUntil = [DateTime]::Parse($fetched.Properties.WaitUntil).ToUniversalTime()
        $newWaitUntilStr  = $currentWaitUntil.AddMinutes(10).ToString("yyyy-MM-ddTHH:mm:ssZ")
        Update-AzVmssLifecycleHookEvent -ResourceGroupName $rgname -VMScaleSetName $vmssName -Name $event.Name -WaitUntil $newWaitUntilStr

        # UPDATE ActionState: mark the single target resource Approved
        Update-AzVmssLifecycleHookEvent -ResourceGroupName $rgname -VMScaleSetName $vmssName -Name $event.Name -ActionState 'Approved'

        # Re-GET and verify both updates persisted
        $fetched2 = Get-AzVmssLifecycleHookEvent -ResourceGroupName $rgname -VMScaleSetName $vmssName -Name $event.Name
        Assert-NotNull $fetched2
        Assert-AreEqual 1 $fetched2.Properties.TargetResources.Count
        Assert-AreEqual 'Approved' $fetched2.Properties.TargetResources[0].ActionState
        $updatedWaitUntil = [DateTime]::Parse($fetched2.Properties.WaitUntil).ToUniversalTime()
        Assert-True { $updatedWaitUntil -gt $currentWaitUntil } "Expected WaitUntil to be updated to a later timestamp"
    }
    finally
    {
        Clean-ResourceGroup $rgname
    }
}
