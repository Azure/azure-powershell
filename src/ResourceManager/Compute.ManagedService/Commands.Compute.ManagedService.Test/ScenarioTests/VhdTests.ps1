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
Test ConvertTo-AzureRmVhd
#>
function Test-ConvertToAzureRmVhd
{
    $scriptExists = Test-Path $PSScriptRoot\ConvertTo-AzureRmVhd.ps1;
    Assert-AreEqual $true $scriptExists;

    # Mock
    function Get-Module($name)
    {
        # Mock hard drive objects
        $md = New-Object –TypeName PSObject;
        $md | Add-Member –MemberType NoteProperty –Name Name –Value $name;
        $md | Add-Member –MemberType NoteProperty –Name Version –Value '9.9';
        return $md;
    }
    function Login-AzureRmAccount {};
    function Get-AzureRmVM {};
    function Get-VM([string]$ComputeName, [string]$Name = $null)
    {
        # Mock hard drive objects
        $hd1 = New-Object –TypeName PSObject;
        $hd1 | Add-Member –MemberType NoteProperty –Name Path –Value "$PSScriptRoot\hd1.vhd";
        $hd2 = New-Object –TypeName PSObject;
        $hd2 | Add-Member –MemberType NoteProperty –Name Path –Value "$PSScriptRoot\hd2.vhd";
        
        # Mock VM objects
        $vmObj1 = New-Object –TypeName PSObject;
        $vmObj1 | Add-Member –MemberType NoteProperty –Name Name –Value $Name;
        $vmObj1 | Add-Member –MemberType NoteProperty –Name HardDrives –Value (New-object System.Collections.Arraylist);
        $vmObj1.HardDrives.Add($hd1);
        $vmObj1.HardDrives.Add($hd2);
        $vmObj2 = New-Object –TypeName PSObject;
        $vmObj2 | Add-Member –MemberType NoteProperty –Name Name –Value ($Name + 'test');
        $vmObj2 | Add-Member –MemberType NoteProperty –Name HardDrives –Value (New-object System.Collections.Arraylist);
        $vmObj2.HardDrives.Add($hd2);
        $vmObj2.HardDrives.Add($hd1);

        if ([string]::IsNullOrEmpty($Name))
        {
            return @($vmObj2, $vmObj1);
        }
        else
        {
            return $vmObj1;
        }
    }
    function Export-VM($ComputerName, $Name, $Path)
    {
        $exportVhdDir = Join-Path (Join-Path $Path $Name) 'Virtual Hard Disks';
        $st = mkdir $exportVhdDir -Force;
        $mockVM = Get-VM $ComputerName $Name;
        foreach ($hd in $mockVM.HardDrives)
        {
            $st = Set-Content -Force -Path (Join-Path $exportVhdDir (Split-Path -Leaf -Path $hd.Path)) -Value 'hd';
        }
        $object = New-Object –TypeName PSObject;
        $object | Add-Member –MemberType NoteProperty –Name State –Value 'Completed';
        return $object;
    }
    function Convert-VHD($Path, $DestinationPath)
    {
        $destFolder = Split-Path -Parent -Path $DestinationPath;
        $st = mkdir -Force $destFolder;
        $st = Copy-Item -Force -Path $Path -Destination $DestinationPath;
    }
    function Remove-TestFolder()
    {
        $testFolder = ".\test\Virtual Hard Disks";
        if (Test-Path $testFolder)
        {
            $st = rmdir $testFolder -Recurse -Force;
        }
    }

    # Import Convert VHD functions
    . $PSScriptRoot\ConvertTo-AzureRmVhd.ps1;

    # Test Convert VHD
    Remove-TestFolder;
    ConvertTo-AzureRmVhd -HyperVVMName 'test' -ExportPath '.';
    Remove-TestFolder;
    $files = ConvertTo-AzureRmVhd -HyperVVMName 'test' -ExportPath '.' -HyperVServer 'localhost' -Force;
    Assert-AreEqual 2 $files.Count;

    # Try to Convert VHDs from non-existing VMs
    $expectedException = $false;
    $expectedErrorMessage = "Cannot find VM 'testNonExistingVM' from server 'localhost'; exit.";
    try
    {
        Remove-TestFolder;
        ConvertTo-AzureRmVhd -HyperVVMName 'testNonExistingVM' -ExportPath '.' -HyperVServer 'localhost';
    }
    catch
    {
        if ($_ -like $expectedErrorMessage)
        {
            $expectedException = $true;
        }
    }
    if (-not $expectedException)
    {
        throw "Expected exception from calling New-AzureRmVM was not caught: '$expectedErrorMessage'.";
    }
    $expectedException = $false;
    try
    {
        ConvertTo-AzureRmVhd -HyperVVMName 'testNonExistingVM' -ExportPath '.' -AsJob | Wait-Job | Receive-Job -ErrorAction Stop;
    }
    catch
    {
        if ($_ -like $expectedErrorMessage)
        {
            $expectedException = $true;
        }
    }
    if (-not $expectedException)
    {
        throw "Expected exception from calling New-AzureRmVM was not caught: '$expectedErrorMessage'.";
    }
}
