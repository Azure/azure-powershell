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
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
        $x = New-AzVM -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel

        Assert-AreEqual $vmname $x.Name;
        Assert-Null $x.Identity
        Assert-False { $x.AdditionalCapabilities.UltraSSDEnabled };

        $nic = Get-AzNetworkInterface -ResourceGroupName $vmname  -Name $vmname
        Assert-NotNull $nic
        Assert-False { $nic.EnableAcceleratedNetworking }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmWithDeleteOptions
{
    # Setup
    $vmname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
        $x = New-AzVM -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -NetworkInterfaceDeleteOption "Delete" -OSDiskDeleteOption "Detach" -DataDiskSizeInGb 32 -DataDiskDeleteOption "Delete"

        Assert-AreEqual $vmname $x.Name;
        Assert-Null $x.Identity
        Assert-False { $x.AdditionalCapabilities.UltraSSDEnabled };

        Assert-AreEqual $x.NetworkProfile.NetworkInterfaces[0].DeleteOption "Delete"
        Assert-AreEqual $x.StorageProfile.OSDisk.DeleteOption "Detach"
        
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmFromSIGImage
{
    #This test needs to be run form the following subscription in record mode :
    # 9e223dbe-3399-4e19-88eb-0975f02ac87f
    #The vm needs to be created in the one of the following regions :
    # "South Central US", "East US 2" and "Central US"
    #To see more information on the steps to create a new SIG image go here: https://aka.ms/AA37jbt
    # Setup
    $vmname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
        $x = New-AzVM -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -Location "East US 2" -Size "Standard_D2s_v3" -Image "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/SIGTestGroupoDoNotDelete/providers/Microsoft.Compute/galleries/SIGTestGalleryDoNotDelete/images/SIGTestImageWindowsDoNotDelete" 

        Assert-AreEqual $vmname $x.Name;
        Assert-Null $x.Identity
        Assert-False { $x.AdditionalCapabilities.UltraSSDEnabled };

        $nic = Get-AzNetworkInterface -ResourceGroupName $vmname  -Name $vmname
        Assert-NotNull $nic
        Assert-False { $nic.EnableAcceleratedNetworking }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm with ultraSSD
#>
function Test-SimpleNewVmWithUltraSSD
{
    # Setup
    $vmname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
        #As of now the ultrasd feature is only supported in east us 2 and in the size Standard_D2s_v3, on the features GA the restriction will be lifted
        #Use the follwing command to figure out the one to use 
        #Get-AzComputeResourceSku | where {$_.ResourceType -eq "disks" -and $_.Name -eq "UltraSSD_LRS" }
        $x = New-AzVM -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -Location "eastus2" -EnableUltraSSD -Zone 2 -Size "Standard_D2s_v3"

        Assert-AreEqual $vmname $x.Name;
        Assert-Null $x.Identity
        Assert-True { $x.AdditionalCapabilities.UltraSSDEnabled };

        $nic = Get-AzNetworkInterface -ResourceGroupName $vmname  -Name $vmname
        Assert-NotNull $nic
        Assert-False { $nic.EnableAcceleratedNetworking }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm with Accelerated Net enabled
#>
function Test-SimpleNewVmWithAccelNet
{
    # Setup
    $vmname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
        $x = New-AzVM -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -Size "Standard_D12_v2"

        Assert-AreEqual $vmname $x.Name;
        Assert-Null $x.Identity

        $nic = Get-AzNetworkInterface -ResourceGroupName $vmname  -Name $vmname
        Assert-NotNull $nic
        Assert-True { $nic.EnableAcceleratedNetworking }
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm with system assigned identity
#>
function Test-SimpleNewVmSystemAssignedIdentity
{
    # Setup
    $vmname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
        $x = New-AzVM -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -SystemAssignedIdentity

        Assert-AreEqual $vmname $x.Name;
        Assert-AreEqual "SystemAssigned" $x.Identity.Type     
        Assert-NotNull  $x.Identity.PrincipalId
        Assert-NotNull  $x.Identity.TenantId
        Assert-Null $x.Identity.IdentityIds     
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm win Win10 and data disks
#>
function Test-NewVmWin10
{
    $vmname = Get-ResourceName
    
    try {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
            [string]$domainNameLabel = "$vmname-$vmname".tolower();
        $x = New-AzVM `
                  -Name $vmname `
                  -Credential $cred `
                  -DomainNameLabel $domainNameLabel `
                  -ImageName "Win10" `
                  -DataDiskSizeInGb 32,64

            Assert-AreEqual 2 $x.StorageProfile.DataDisks.Count
        Assert-AreEqual $vmname $x.Name; 
        Assert-Null $x.Identity
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm with system assigned identity and user assigned identity
#>
function Test-SimpleNewVmUserAssignedIdentitySystemAssignedIdentity
{
    # Setup
    $vmname = "UAITG123456"

    try
    {
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
        # $newUserId = $newUserIdentity.Id
        $newUserId = "/subscriptions/24fb23e3-6ba3-41f0-9b6e-e41131d5d61e/resourcegroups/UAITG123456/providers/Microsoft.ManagedIdentity/userAssignedIdentities/UAITG123456Identity"

        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
        $x = New-AzVM -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -UserAssignedIdentity $newUserId -SystemAssignedIdentity

        Assert-AreEqual $vmname $x.Name;
        Assert-AreEqual "UserAssigned" $x.Identity.Type     
        Assert-NotNull  $x.Identity.PrincipalId
        Assert-NotNull  $x.Identity.TenantId
        Assert-NotNull $x.Identity.UserAssignedIdentities
        Assert-AreEqual 1 $x.Identity.UserAssignedIdentities.Count
        Assert-True { $x.Identity.UserAssignedIdentities.ContainsKey($newUserId) }
        Assert-NotNull  $x.Identity.UserAssignedIdentities[$newUserId].PrincipalId
        Assert-NotNull  $x.Identity.UserAssignedIdentities[$newUserId].ClientId
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmWithAvailabilitySet
{
    # Setup
    $rgname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$vmname = $rgname
        [string]$asname = $rgname
        [string]$domainNameLabel = "$vmname-$rgname".tolower();

        # Common
        $r = New-AzResourceGroup -Name $rgname -Location "eastus"
        $a = New-AzAvailabilitySet `
            -ResourceGroupName $rgname `
            -Name $asname `
            -Location "eastus" `
            -Sku "Aligned" `
            -PlatformUpdateDomainCount 2 `
            -PlatformFaultDomainCount 2

        $x = New-AzVM `
            -ResourceGroupName $rgname `
            -Name $vmname `
            -Credential $cred `
            -DomainNameLabel $domainNameLabel `
            -AvailabilitySetName $asname

        Assert-AreEqual $vmname $x.Name;        
        Assert-AreEqual $a.Id $x.AvailabilitySetReference.Id
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmWithDefaultDomainName
{
    # Setup
    $rgname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string] $vmname = "ps9301"

        # Common
        $x = New-AzVM -ResourceGroupName $rgname -Name $vmname -Credential $cred

        Assert-AreEqual $vmname $x.Name
        $fqdn = $x.FullyQualifiedDomainName
        $split = $fqdn.Split(".")
        Assert-AreEqual "eastus" $split[1] 
        Assert-AreEqual "cloudapp" $split[2]
        Assert-AreEqual "azure" $split[3]
        Assert-AreEqual "com" $split[4]
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmWithDefaultDomainName2
{
    # Setup
    $rgname = Get-ResourceName
    $rgname2 = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string] $vmname = "vm"

        # Common
        $x = New-AzVM `
            -ResourceGroupName $rgname `
            -Name $vmname `
            -Credential $cred `
            -ImageName "ubuntults"

        # second VM
        $x2 = New-AzVM `
            -ResourceGroupName $rgname2 `
            -Name $vmname `
            -Credential $cred `
            -ImageName "ubuntults"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
        Clean-ResourceGroup $rgname2
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmWithAvailabilitySet2
{
    # Setup
    $rgname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$vmname = "myVM"
        [string]$asname = "myAvailabilitySet"

        # Common
        $r = New-AzResourceGroup -Name $rgname -Location "eastus"
        $a = New-AzAvailabilitySet `
            -ResourceGroupName $rgname `
            -Name $asname `
            -Location "eastus" `
            -Sku "Aligned" `
            -PlatformUpdateDomainCount 2 `
            -PlatformFaultDomainCount 2

        $x = New-AzVM `
            -ResourceGroupName $rgname `
            -Name $vmname `
            -Credential $cred `
            -VirtualNetworkName "myVnet" `
            -SubnetName "mySubnet" `
            -OpenPorts 80,3389 `
            -PublicIpAddressName "myPublicIpAddress" `
            -SecurityGroupName "myNetworkSecurityGroup" `
            -AvailabilitySetName $asname `
            -DomainNameLabel "myvm-ad9300"

        Assert-AreEqual $vmname $x.Name;        
        Assert-AreEqual $a.Id $x.AvailabilitySetReference.Id
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmImageName
{
    # Setup
    $vmname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmname-$vmname".tolower()

        # Common
        $imgversion = Get-VMImageVersion -publisher "MicrosoftWindowsServer" -offer "WindowsServer" -sku "2016-Datacenter"
        $x = New-AzVM `
            -Name $vmname `
            -Credential $cred `
            -DomainNameLabel $domainNameLabel `
            -ImageName ("MicrosoftWindowsServer:WindowsServer:2016-Datacenter:" + $imgversion)

        Assert-AreEqual $vmname $x.Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New Vm
#>
function Test-SimpleNewVmImageNameMicrosoftSqlUbuntu
{
    # Setup
    $vmname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "xsd3490285".tolower()

        # Common
        $x = New-AzVM `
            -Name $vmname `
            -Credential $cred `
            -DomainNameLabel $domainNameLabel `
            -ImageName "MicrosoftSQLServer:SQL2017-Ubuntu1604:Enterprise:latest"

        Assert-AreEqual $vmname $x.Name
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Parameter Set for New Vm with PPG
#>
function Test-SimpleNewVmPpg
{
    # Setup
    $rgname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        $ppgname = "MyPpg"
        $vmname = "MyVm"
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
        $rg = New-AzResourceGroup -Name $rgname -Location "eastus"
        $ppg = New-AzProximityPlacementGroup `
            -ResourceGroupName $rgname `
            -Name $ppgname `
            -Location "eastus"
        $vm = New-AzVM -Name $vmname -ResourceGroup $rgname -Credential $cred -DomainNameLabel $domainNameLabel -ProximityPlacementGroup $ppgname

        Assert-AreEqual $vm.ProximityPlacementGroup.Id $ppg.Id
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test Simple Parameter Set for New Vm with PPG Id
#>
function Test-SimpleNewVmPpgId
{
    # Setup
    $rgname = Get-ResourceName
    $vmname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        $ppgname = "MyPpg"
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
        $rg = New-AzResourceGroup -Name $rgname -Location "eastus"
        $ppg = New-AzProximityPlacementGroup `
            -ResourceGroupName $rgname `
            -Name $ppgname `
            -Location "eastus"
        $vm = New-AzVM -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -ProximityPlacementGroupId $ppg.Id

        Assert-AreEqual $vm.ProximityPlacementGroup.Id $ppg.Id
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Test Simple Paremeter Set for New VM with eviction policy, priority and max price.
#>
function Test-SimpleNewVmBilling
{
    # Setup
    $vmname = Get-ResourceName

    try
    {
        $username = "admin01"
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force
        $cred = new-object -typename System.Management.Automation.PSCredential -argumentlist $username, $password
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Common
        $vm = New-AzVM -Name $vmname -Credential $cred -DomainNameLabel $domainNameLabel -EvictionPolicy 'Deallocate' -Priority 'Low' -MaxPrice 0.2;

        Assert-AreEqual $vmname $vm.Name;
        Assert-AreEqual 'Deallocate' $vm.EvictionPolicy;
        Assert-AreEqual 'Low' $vm.Priority;     
        Assert-AreEqual 0.2 $vm.BillingProfile.MaxPrice;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}

<#
.SYNOPSIS
Testing creating VM with a shared gallery image from a different subscription.
#>
function Test-SimpleGalleryCrossTenant
{
    # Setup
    # In order to record this test, please use another subscription to create a gallery image and share the image to the test subscription.  And then set the gallery image id here.
    $imageId = "/subscriptions/97f78232-382b-46a7-8a72-964d692c4f3f/resourceGroups/xwRg/providers/Microsoft.Compute/galleries/galleryForCirrus/images/xwGalleryImageForCirrusWindows/versions/1.0.0";

    $vmname = Get-ComputeTestResourceName;

    try
    {
        # Common
        $loc = Get-ComputeVMLocation;

        # OS & Image
        $user = "Foo12";
        $password = Get-PasswordForVM | ConvertTo-SecureString -AsPlainText -Force;
        $cred = New-Object System.Management.Automation.PSCredential ($user, $password);
        [string]$domainNameLabel = "$vmname-$vmname".tolower();

        # Virtual Machine
        New-AzVM -Name $vmname -Location $loc -Credential $cred -DomainNameLabel $domainNameLabel -ImageName $imageId

        $vm = Get-AzVM -ResourceGroupName $vmname -Name $vmname;
        Assert-AreEqual $imageId $vm.StorageProfile.ImageReference.Id;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $vmname
    }
}
