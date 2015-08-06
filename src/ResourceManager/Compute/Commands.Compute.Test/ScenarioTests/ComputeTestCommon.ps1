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
    
    $oldErrorActionPreferenceValue = $ErrorActionPreference;
    $ErrorActionPreference = "SilentlyContinue";
    
    try
    {
        $assetName = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetAssetName($testName, "crptestps");
    }
    catch
    {
        if (($Error.Count -gt 0) -and ($Error[0].Exception.Message -like '*Unable to find type*'))
        {
            $assetName = Get-RandomItemName;
        }
        else
        {
            throw;
        }
    }
    finally
    {
        $ErrorActionPreference = $oldErrorActionPreferenceValue;
    }

    return $assetName
}


<#
.SYNOPSIS
Gets test mode - 'Record' or 'Playback'
#>
function Get-ComputeTestMode
{
    $oldErrorActionPreferenceValue = $ErrorActionPreference;
    $ErrorActionPreference = "SilentlyContinue";
    
    try
    {
        $testMode = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode;
        $testMode = $testMode.ToString();
    }
    catch
    {
        if (($Error.Count -gt 0) -and ($Error[0].Exception.Message -like '*Unable to find type*'))
        {
            $testMode = 'Record';
        }
        else
        {
            throw;
        }
    }
    finally
    {
        $ErrorActionPreference = $oldErrorActionPreferenceValue;
    }

    return $testMode;
}

# Get Compute Test Location
function Get-ComputeTestLocation
{
    return $env:AZURE_COMPUTE_TEST_LOCATION;
}

# Cleans the created resource group
function Clean-ResourceGroup($rgname)
{
    Remove-AzureResourceGroup -Name $rgname -Force;
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

    $vmSizes = Get-AzureVMSize -Location $location | where { $_.NumberOfCores -ge 4 -and $_.MaxDataDiskCount -ge 8 };

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
Gets default CRP Image
#>
function Get-DefaultCRPImage
{
    param([string] $loc = "westus", [string] $query = '*Microsoft*Windows*Server')

    $result = (Get-AzureVMImagePublisher -Location $loc) | select -ExpandProperty PublisherName | where { $_ -like $query };
    if ($result.Count -eq 1)
    {
        $defaultPublisher = $result;
    }
    else
    {
        $defaultPublisher = $result[0];
    }

    $result = (Get-AzureVMImageOffer -Location $loc -PublisherName $defaultPublisher) | select -ExpandProperty Offer | where { $_ -like '*Windows*' };
    if ($result.Count -eq 1)
    {
        $defaultOffer = $result;
    }
    else
    {
        $defaultOffer = $result[0];
    }

    $result = (Get-AzureVMImageSku -Location $loc -PublisherName $defaultPublisher -Offer $defaultOffer) | select -ExpandProperty Skus;
    if ($result.Count -eq 1)
    {
        $defaultSku = $result;
    }
    else
    {
        $defaultSku = $result[0];
    }

    $result = (Get-AzureVMImage -Location $loc -Offer $defaultOffer -PublisherName $defaultPublisher -Skus $defaultSku) | select -ExpandProperty Version;
    if ($result.Count -eq 1)
    {
        $defaultVersion = $result;
    }
    else
    {
        $defaultVersion = $result[0];
    }
    
    $vmimg = Get-AzureVMImage -Location $loc -Offer $defaultOffer -PublisherName $defaultPublisher -Skus $defaultSku -Version $defaultVersion;

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
    return Create-ComputeVMImageObject 'SUSE' 'openSUSE' '13.2' 'latest';
}

<#
.SYNOPSIS
Gets VMM Images
#>
function Get-MarketplaceImage
{
    param([string] $location = "westus", [string] $pubFilter = '*', [string] $offerFilter = '*')

    $imgs = Get-AzureVMImagePublisher -Location $location | where { $_.PublisherName -like $pubFilter } | Get-AzureVMImageOffer | where { $_.Offer -like $offerFilter } | Get-AzureVMImageSku | Get-AzureVMImage | Get-AzureVMImage | where { $_.PurchasePlan -ne $null };

    return $imgs;
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

    $vm = New-AzureVMConfig -VMName $vmname -VMSize $vmsize;

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
    foreach ($str in $sstr)
    {
        $st = Write-Verbose ('Search String ' + $index++ + " : `'" + $str + "`'");
        Assert-True { $output.Contains($str) }
        $st = Write-Verbose "Found.";
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
