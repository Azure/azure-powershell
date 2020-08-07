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

$PLACEHOLDER = "PLACEHOLDER1@"
$TestOutputRoot = [System.AppDomain]::CurrentDomain.BaseDirectory;
$TemplatesPath = Join-Path $TestOutputRoot "Templates";
$ConfigFilesPath = Join-Path $TestOutputRoot "ConfigFiles";

<#
.SYNOPSIS
Gets valid resource name for compute test
#>
function Get-ComputeTestResourceName
{
    $stack = Get-PSCallStack
    $testName = $null;
    foreach ($frame in $stack)
    {
        if ($frame.Command.StartsWith("Test-", "CurrentCultureIgnoreCase"))
        {
            $testName = $frame.Command;
        }
    }

    try
    {
        $assetName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetAssetName($testName, "crptestps");
    }
    catch
    {
        if ($PSItem.Exception.Message -like '*Unable to find type*')
        {
            $assetName = Get-RandomItemName;
        }
        else
        {
            throw;
        }
    }

    return $assetName
}

<#
.SYNOPSIS
Gets test mode - 'Record' or 'Playback'
#>
function Get-ComputeTestMode
{
    try
    {
        $testMode = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode;
        $testMode = $testMode.ToString();
    }
    catch
    {
        if ($PSItem.Exception.Message -like '*Unable to find type*')
        {
            $testMode = 'Record';
        }
        else
        {
            throw;
        }
    }

    return $testMode;
}

# Get Compute Test Location
function Get-ComputeTestLocation
{
    return $env:AZURE_COMPUTE_TEST_LOCATION;
}

# Get Compute Default Test Location
function Get-ComputeDefaultLocation
{
    $test_location = Get-ComputeTestLocation;
    if ($test_location -eq '' -or $test_location -eq $null)
    {
        $test_location = 'westus';
    }

    return $test_location;
}

# Create key vault resources
function Create-KeyVault
{
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [string] $resourceGroupName,
        [Parameter(Mandatory=$true, Position=1)]
        [string] $location,
        [Parameter(Mandatory=$false, Position=2)]
        [string] $vaultName
    )

    # initialize parameters if needed
    if ([string]::IsNullOrEmpty($resourceGroupName)) { $resourceGroupName = Get-ComputeTestResourceName }
    if ([string]::IsNullOrEmpty($location)) { $location = Get-ComputeVMLocation }
    if ([string]::IsNullOrEmpty($vaultName)) { $vaultName = 'kv' + $resourceGroupName }

    # create vault
    $vault = New-AzKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroupName -Location $location -Sku standard
    $vault = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $resourceGroupName

    # create access policy
    $servicePrincipalName = (Get-AzContext).Account.Id
    Assert-NotNull $servicePrincipalName
    #Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ResourceGroupName $resourceGroupName -ServicePrincipalName $servicePrincipalName -PermissionsToKeys Create
    Set-AzKeyVaultAccessPolicy -VaultName $vaultName -ResourceGroupName $resourceGroupName -EnabledForDiskEncryption -EnabledForDeployment -EnabledForTemplateDeployment

    # create key encryption key 
    #$kekName = 'kek' + $resourceGroupName
    #$kek = Add-AzKeyVaultKey -VaultName $vaultName -Name $kekName -Destination "Software"

    # return the newly created key vault properties
    $properties = New-Object PSObject -Property @{
        DiskEncryptionKeyVaultId = $vault.ResourceId
        DiskEncryptionKeyVaultUrl = $vault.VaultUri
        #KeyEncryptionKeyVaultId = $vault.ResourceId
        #KeyEncryptionKeyUrl = $kek.Key.kid
    }
    return $properties
}

# Create a new virtual machine with other necessary resources configured
function Create-VirtualMachine
{
    Param
    (
        [Parameter(Mandatory=$false, Position=0)]
        [string] $rgname,
        [Parameter(Mandatory=$false, Position=1)]
        [string] $vmname,
        [Parameter(Mandatory=$false, Position=2)]
        [string] $loc       
    )

    # initialize parameters if needed
    if ([string]::IsNullOrEmpty($rgname)) { $rgname = Get-ComputeTestResourceName }
    if ([string]::IsNullOrEmpty($vmname)) { $vmname = 'vm' + $rgname }
    if ([string]::IsNullOrEmpty($loc)) { $loc = Get-ComputeVMLocation } 

    # Common
    $g = New-AzResourceGroup -Name $rgname -Location $loc -Force;

    # VM Profile & Hardware
    $vmsize = 'Standard_A2';
    $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
    Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

    # NRP
    $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
    $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
    $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
    $subnetId = $vnet.Subnets[0].Id;
    $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
    $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
    $pubipId = $pubip.Id;
    $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
    $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
    $nicId = $nic.Id;

    $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

    # Storage Account (SA)
    $stoname = 'sto' + $rgname;
    $stotype = 'Standard_GRS';
    $sa = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
    Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
    $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname).Key1;

    $osDiskName = 'osDisk';
    $osDiskCaching = 'ReadWrite';
    $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
    $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
    $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
    $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

    $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 -VhdUri $dataDiskVhdUri1 -CreateOption Empty;
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 -VhdUri $dataDiskVhdUri2 -CreateOption Empty;
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 -VhdUri $dataDiskVhdUri3 -CreateOption Empty;
    $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

    Assert-AreEqual $p.StorageProfile.OsDisk.Caching $osDiskCaching;
    Assert-AreEqual $p.StorageProfile.OsDisk.Name $osDiskName;
    Assert-AreEqual $p.StorageProfile.OsDisk.Vhd.Uri $osDiskVhdUri;
    Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;

    # OS & Image
    $user = "Foo12";
    $password = $PLACEHOLDER;
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $computerName = 'test';
    $vhdContainer = "https://$stoname.blob.core.windows.net/test";

    $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

    $imgRef = Get-DefaultCRPWindowsImageOffline;
    $p = ($imgRef | Set-AzVMSourceImage -VM $p);

    Assert-AreEqual $p.OSProfile.AdminUsername $user;
    Assert-AreEqual $p.OSProfile.ComputerName $computerName;
    Assert-AreEqual $p.OSProfile.AdminPassword $password;
    Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

    Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
    Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
    Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
    Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

    # Virtual Machine
    $v = New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

    $vm = Get-AzVM -ResourceGroupName $rgname -VMName $vmname
    return $vm
}

# Create a new virtual machine with other necessary resources configured
function Create-VirtualMachineNoDataDisks
{
    Param
    (
        [Parameter(Mandatory=$false, Position=0)]
        [string] $rgname,
        [Parameter(Mandatory=$false, Position=1)]
        [string] $vmname,
        [Parameter(Mandatory=$false, Position=2)]
        [string] $loc       
    )

    # initialize parameters if needed
    if ([string]::IsNullOrEmpty($rgname)) { $rgname = Get-ComputeTestResourceName }
    if ([string]::IsNullOrEmpty($vmname)) { $vmname = 'vm' + $rgname }
    if ([string]::IsNullOrEmpty($loc)) { $loc = Get-ComputeVMLocation } 

    # Common
    $g = New-AzResourceGroup -Name $rgname -Location $loc -Force;

    # VM Profile & Hardware
    $vmsize = 'Standard_D2S_V3';
    $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize;
    Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

    # NRP
    $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
    $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
    $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
    $subnetId = $vnet.Subnets[0].Id;
    $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Dynamic -DomainNameLabel ('pubip' + $rgname);
    $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
    $pubipId = $pubip.Id;
    $nic = New-AzNetworkInterface -Force -Name ('nic' + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId -PublicIpAddressId $pubip.Id;
    $nic = Get-AzNetworkInterface -Name ('nic' + $rgname) -ResourceGroupName $rgname;
    $nicId = $nic.Id;

    $p = Add-AzVMNetworkInterface -VM $p -Id $nicId;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count 1;
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[0].Id $nicId;

    # Storage Account (SA)
    $stoname = 'sto' + $rgname;
    $stotype = 'Standard_GRS';
    $sa = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
    Retry-IfException { $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname; }
    $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname).Key1;

    $osDiskName = 'osDisk';
    $osDiskCaching = 'ReadWrite';
    $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";

    $p = Set-AzVMOSDisk -VM $p -Name $osDiskName -VhdUri $osDiskVhdUri -Caching $osDiskCaching -CreateOption FromImage;

    Assert-AreEqual $p.StorageProfile.OsDisk.Caching $osDiskCaching;
    Assert-AreEqual $p.StorageProfile.OsDisk.Name $osDiskName;
    Assert-AreEqual $p.StorageProfile.OsDisk.Vhd.Uri $osDiskVhdUri;
    Assert-AreEqual $p.StorageProfile.DataDisks.Count 0;

    # OS & Image
    $user = "Foo12";
    $password = $PLACEHOLDER;
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $computerName = 'test';
    $vhdContainer = "https://$stoname.blob.core.windows.net/test";

    $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

    $imgRef = Get-DefaultCRPWindowsImageOffline;
    $p = ($imgRef | Set-AzVMSourceImage -VM $p);

    Assert-AreEqual $p.OSProfile.AdminUsername $user;
    Assert-AreEqual $p.OSProfile.ComputerName $computerName;
    Assert-AreEqual $p.OSProfile.AdminPassword $password;
    Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;

    Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
    Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
    Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
    Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;

    # Virtual Machine
    $v = New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

    $vm = Get-AzVM -ResourceGroupName $rgname -VMName $vmname
    return $vm
}

# Cleans the created resource group
function Clean-ResourceGroup($rgname)
{
    Remove-AzResourceGroup -Name $rgname -Force;
}

# Get Compute Test Tag
function Get-ComputeTestTag
{
    param ([string] $tagname)

    return @{ Name = $tagname; Value = (Get-Date).ToUniversalTime().ToString("u") };
}

######################
#
# Retry the given code block until it succeeds or times out.
#
#    param [ScriptBlock] $script : The code to test
#    param [int] $times          : The times of running the code
#    param [string] $message     : The text of the exception that should be thrown
#######################
function Retry-IfException
{
    param([ScriptBlock] $script, [int] $times = 30, [string] $message = "*")

    if ($times -le 0)
    {
        throw 'Retry time(s) should not be equal to or less than 0.';
    }

    $oldErrorActionPreferenceValue = $ErrorActionPreference;
    $ErrorActionPreference = "SilentlyContinue";

    $iter = 0;
    $succeeded = $false;
    while (($iter -lt $times) -and (-not $succeeded))
    {
        $iter += 1;

        &$script;

        if ($Error.Count -gt 0)
        {
            $actualMessage = $Error[0].Exception.Message;

            Write-Output ("Caught exception: '$actualMessage'");

            if (-not ($actualMessage -like $message))
            {
                $ErrorActionPreference = $oldErrorActionPreferenceValue;
                throw "Expected exception not received: '$message' the actual message is '$actualMessage'";
            }

            $Error.Clear();
            Wait-Seconds 10;
            continue;
        }

        $succeeded = $true;
    }

    $ErrorActionPreference = $oldErrorActionPreferenceValue;
}

<#
.SYNOPSIS
Gets random resource name
#>
function Get-RandomItemName
{
    param([string] $prefix = "crptestps")
    
    if ($prefix -eq $null -or $prefix -eq '')
    {
        $prefix = "crptestps";
    }

    $str = $prefix + ((Get-Random) % 10000);
    return $str;
}

<#
.SYNOPSIS
Gets default VM size string
#>
function Get-DefaultVMSize
{
    param([string] $location = "westus")

    $vmSizes = Get-AzVMSize -Location $location | where { $_.NumberOfCores -ge 4 -and $_.MaxDataDiskCount -ge 8 };

    foreach ($sz in $vmSizes)
    {
        if ($sz.Name -eq 'Standard_A3')
        {
            return $sz.Name;
        }
    }

    return $vmSizes[0].Name;
}


<#
.SYNOPSIS
Gets default RDFE Image
#>
function Get-DefaultRDFEImage
{
    param([string] $loca = "East Asia", [string] $query = '*Windows*Data*Center*')

    $d = (Azure\Get-AzVMImage | where {$_.ImageName -like $query -and ($_.Location -like "*;$loca;*" -or $_.Location -like "$loca;*" -or $_.Location -like "*;$loca" -or $_.Location -eq "$loca")});

    if ($d -eq $null)
    {
        return $null;
    }
    else
    {
        return $d[-1].ImageName;
    }
}

<#
.SYNOPSIS
Gets default storage type string
#>
function Get-DefaultStorageType
{
    return 'Standard_GRS';
}

<#
.SYNOPSIS
Gets default CRP Image
#>
function Get-DefaultCRPImage
{
    param([string] $loc = "westus", [string] $query = '*Microsoft*Windows*Server*')

    $result = (Get-AzVMImagePublisher -Location $loc) | select -ExpandProperty PublisherName | where { $_ -like $query };
    if ($result.Count -eq 1)
    {
        $defaultPublisher = $result;
    }
    else
    {
        $defaultPublisher = $result[0];
    }

    $result = (Get-AzVMImageOffer -Location $loc -PublisherName $defaultPublisher) | select -ExpandProperty Offer | where { $_ -like '*WindowsServer*' -and -not ($_ -like '*HUB')  };
    if ($result.Count -eq 1)
    {
        $defaultOffer = $result;
    }
    else
    {
        $defaultOffer = $result[0];
    }

    $result = (Get-AzVMImageSku -Location $loc -PublisherName $defaultPublisher -Offer $defaultOffer) | select -ExpandProperty Skus;
    if ($result.Count -eq 1)
    {
        $defaultSku = $result;
    }
    else
    {
        $defaultSku = $result[0];
    }

    $result = (Get-AzVMImage -Location $loc -Offer $defaultOffer -PublisherName $defaultPublisher -Skus $defaultSku) | select -ExpandProperty Version;
    if ($result.Count -eq 1)
    {
        $defaultVersion = $result;
    }
    else
    {
        $defaultVersion = $result[0];
    }
    
    $vmimg = Get-AzVMImage -Location $loc -Offer $defaultOffer -PublisherName $defaultPublisher -Skus $defaultSku -Version $defaultVersion;

    return $vmimg;
}

# Create Image Object
function Create-ComputeVMImageObject
{
    param ([string] $publisherName, [string] $offer, [string] $skus, [string] $version)

    $img = New-Object -TypeName 'Microsoft.Azure.Commands.Compute.Models.PSVirtualMachineImage';
    $img.PublisherName = $publisherName;
    $img.Offer = $offer;
    $img.Skus = $skus;
    $img.Version = $version;

    return $img;
}

# Get Default CRP Windows Image Object Offline
function Get-DefaultCRPWindowsImageOffline
{
    return Create-ComputeVMImageObject 'MicrosoftWindowsServer' 'WindowsServer' '2008-R2-SP1' 'latest';
}

# Get Default CRP Linux Image Object Offline
function Get-DefaultCRPLinuxImageOffline
{
    return Create-ComputeVMImageObject 'SUSE' 'openSUSE-Leap' '42.3' 'latest';
}

<#
.SYNOPSIS
Gets VMM Images
#>
function Get-MarketplaceImage
{
    param([string] $location = "westus", [string] $pubFilter = '*', [string] $offerFilter = '*')

    $imgs = Get-AzVMImagePublisher -Location $location | where { $_.PublisherName -like $pubFilter } | Get-AzVMImageOffer | where { $_.Offer -like $offerFilter } | Get-AzVMImageSku | Get-AzVMImage | Get-AzVMImage | where { $_.PurchasePlan -ne $null };

    return $imgs;
}

function Get-FirstMarketPlaceImage
{
    $img = Get-AzVMImagePublisher -Location westus | where { $_.PublisherName -eq "1e" } | Get-AzVMImageOffer | Get-AzVMImageSku | Get-AzVMImage | Get-AzVMImage | where {$_.PurchasePlan -ne $null }
    
    if ($img -eq $null)
    {
        $img = Get-MarketplaceImage[0]
    }

    return $img
}

<#
.SYNOPSIS
Gets default VM config object
#>
function Get-DefaultVMConfig
{
    param([string] $location = "westus")

    # VM Profile & Hardware
    $vmsize = Get-DefaultVMSize $location;
    $vmname = Get-RandomItemName 'crptestps';

    $vm = New-AzVMConfig -VMName $vmname -VMSize $vmsize;

    return $vm;
}

# Assert Output Contains
function Assert-OutputContains
{
    param([string] $cmd, [string[]] $sstr)
    
    $st = Write-Verbose ('Running Command : ' + $cmd);
    $output = Invoke-Expression $cmd | Out-String;

    $max_output_len = 1500;
    if ($output.Length -gt $max_output_len)
    {
        # Truncate Long Output in Logs
        $st = Write-Verbose ('Output String   : ' + $output.Substring(0, $max_output_len) + '...');
    }
    else
    {
        $st = Write-Verbose ('Output String   : ' + $output);
    }

    $index = 1;

    try
    {
        foreach ($str in $sstr)
        {
            $st = Write-Verbose ('Search String ' + $index++ + " : `'" + $str + "`'");
            Assert-True { $output.Contains($str) }
            $st = Write-Verbose "Found.";
        }
    }
    catch
    {
        Write-Verbose ("output: " + $output);
        Write-Verbose ("str: " + $str);
        throw;
    }
}


# Create a SAS Uri
function Get-SasUri
{
    param ([string] $storageAccount, [string] $storageKey, [string] $container, [string] $file, [TimeSpan] $duration, [Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPermissions] $type)

    $uri = [string]::Format("https://{0}.blob.core.windows.net/{1}/{2}", $storageAccount, $container, $file);

    $destUri = New-Object -TypeName System.Uri($uri);
    $cred = New-Object -TypeName Microsoft.WindowsAzure.Storage.Auth.StorageCredentials($storageAccount, $storageKey);
    $destBlob = New-Object -TypeName Microsoft.WindowsAzure.Storage.Blob.CloudPageBlob($destUri, $cred);
    $policy = New-Object Microsoft.WindowsAzure.Storage.Blob.SharedAccessBlobPolicy;
    $policy.Permissions = $type;
    $policy.SharedAccessExpiryTime = [DateTime]::UtcNow.Add($duration);
    $uri += $destBlob.GetSharedAccessSignature($policy);

    return $uri;
}

# Get a Location according to resource provider.
function Get-ResourceProviderLocation
{
    param ([string] $provider)

    $namespace = $provider.Split("/")[0];
    if($provider.Contains("/"))
    {
        $type = $provider.Substring($namespace.Length + 1);
        $location = Get-AzResourceProvider -ProviderNamespace $namespace | where {$_.ResourceTypes[0].ResourceTypeName -eq $type};
  
        if ($location -eq $null)
        {
            return "westus";
        }
        else
        {
            return $location.Locations[0];
        }
    }
    return "westus";
}

function Get-ComputeVMLocation
{
    $result = Get-Location "Microsoft.Compute" "virtualMachines" "East US";
    $result = $result.Replace(' ', '');
    return $result
}

function Get-ComputeAvailabilitySetLocation
{
    Get-Location "Microsoft.Compute" "availabilitySets" "West US";
}

function Get-ComputeVMExtensionLocation
{
    Get-Location "Microsoft.Compute" "virtualMachines/extensions" "West US";
}

function Get-ComputeVMDiagnosticSettingLocation
{
    Get-Location "Microsoft.Compute" "virtualMachines/diagnosticSettings" "West US";
}

function Get-ComputeVMMetricDefinitionLocation
{
    Get-Location "Microsoft.Compute" "virtualMachines/metricDefinitions" "West US";
}

function Get-ComputeOperationLocation
{
    Get-Location "Microsoft.Compute" "locations/operations" "West US";
}

function Get-ComputeVMSizeLocation
{
    Get-Location "Microsoft.Compute" "locations/vmSizes" "West US";
}

function Get-ComputeUsageLocation
{
    Get-Location "Microsoft.Compute" "locations/usages" "West US";
}

function Get-ComputePublisherLocation
{
    Get-Location "Microsoft.Compute" "locations/publishers" "West US";
}

function Get-SubscriptionIdFromResourceGroup
{
    param ([string] $rgname)

    $rg = Get-AzResourceGroup -ResourceGroupName $rgname;

    $rgid = $rg.ResourceId;

    if ([string]::IsNullOrEmpty($rgid)) {
        #Get the subscription from the current context
        $context = get-Azcontext
        return $context.Subscription.SubscriptionId
    }

    # ResouceId is a form of "/subscriptions/<subId>/resourceGroups/<resourgGroupName>"
    # So return the second part to get subscription Id
    $first = $rgid.IndexOf('/', 1);
    $last = $rgid.IndexOf('/', $first + 1);
    return $rgid.Substring($first + 1, $last - $first - 1);
}

function Get-ComputeVmssLocation
{
    Get-ResourceProviderLocation "Microsoft.Compute/virtualMachineScaleSets"
}

function Verify-PSComputeLongRunningOperation
{
    param ($result)

    Assert-NotNull $result;
    $id = New-Object System.Guid;
    Assert-True { [System.Guid]::TryParse($result.OperationId, [REF] $id) };
    Assert-AreEqual "Succeeded" $result.Status;
    Assert-NotNull $result.StartTime;
    Assert-NotNull $result.EndTime;
    Assert-Null $result.Error;
}

function Verify-PSOperationStatusResponse
{
    param ($result)

    Assert-NotNull $result;
    $id = New-Object System.Guid;
    Assert-True { [System.Guid]::TryParse($result.Name, [REF] $id) };
    Assert-AreEqual "Succeeded" $result.Status;
    Assert-NotNull $result.StartTime;
    Assert-NotNull $result.EndTime;
    Assert-Null $result.Error;
}

function Get-VMImageVersion {
	param([string] $publisher, [string] $offer, [string] $sku, [string] $location)

	if ([string]::IsNullOrEmpty($location)) {
		$location = "East US"
	}

	return (Get-AzVMImage -PublisherName $publisher `
					 -Location $location `
					 -Offer $offer `
					 -Skus $sku | Sort-Object -Descending Version | select -First 1).Version
}


<#
.SYNOPSIS
Gets a sku that is available for the location, subscription, and resourceType
#>
function Get-AvailableSku
{
    param([string] $location, [string] $resourceType)

    $res = get-azcomputeresourcesku $location | where-object ResourceType -match $resourceType
    $res = $res.where({$_.restrictions.count -eq 0})
    if ($resourceType -match "virtualmachine"){
        $res = $res.where({$_.Name -notmatch "Standard_B"})
    }
    return $res[0].Name
}
