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
Test the basic usage of the Set/Get/Test/Remove virtual machine Azure Enhanced Monitoring extension command
#>

function Log($test, $message)
{
	Out-File -FilePath "$test.log" -Append -InputObject $message
}

function Test-AEMExtensionBasicWindowsWAD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc
        $vmname = $vm.Name

        # Get with not extension
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        # Test with not extension
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-False { $testResult.Result } (GetWrongTestResult $testResult $true)

        # Set and Get command.
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorage -EnableWAD
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.AzureCAT.AzureEnhancedMonitoring'
        Assert-AreEqual $extension.ExtensionType 'AzureCATExtensionHandler'
        Assert-AreEqual $extension.Name 'AzureCATExtensionHandler'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg

        # Test command.
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WaitTimeInMinutes 50 -SkipStorageCheck
        Assert-True { $testResult.Result }  (GetWrongTestResult $testResult $false)
        Assert-True { ($testResult.PartialResults.Count -gt 0) }

        # Remove command.
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionBasicWindows
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc
        $vmname = $vm.Name

        # Get with not extension
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        # Test with not extension
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-False { $testResult.Result }

        # Set and Get command.
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorage
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.AzureCAT.AzureEnhancedMonitoring'
        Assert-AreEqual $extension.ExtensionType 'AzureCATExtensionHandler'
        Assert-AreEqual $extension.Name 'AzureCATExtensionHandler'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg

        # Test command.
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WaitTimeInMinutes 50 -SkipStorageCheck
        Assert-True { $testResult.Result }
        Assert-True { ($testResult.PartialResults.Count -gt 0) }

        # Remove command.
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedWindowsWAD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Debug "Start the test Test-AEMExtensionAdvancedWindows"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2
        $vmname = $vm.Name
        Write-Host "Test-AEMExtensionAdvancedWindows: VM created"

        # Get with not extension
        Write-Debug "Test-AEMExtensionAdvancedWindows: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"

        # Test with not extension
        Write-Debug "Test-AEMExtensionAdvancedWindows: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-False { $res.Result } (GetWrongTestResult $res $true)
        Write-Debug "Test-AEMExtensionAdvancedWindows: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Debug "Test-AEMExtensionAdvancedWindows: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage -EnableWAD
        Write-Debug "Test-AEMExtensionAdvancedWindows: Set done"
        Write-Debug "Test-AEMExtensionAdvancedWindows: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.AzureCAT.AzureEnhancedMonitoring'
        Assert-AreEqual $extension.ExtensionType 'AzureCATExtensionHandler'
        Assert-AreEqual $extension.Name 'AzureCATExtensionHandler'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg
        Write-Debug "Test-AEMExtensionAdvancedWindows: Get done"

        # Test command.
        Write-Debug "Test-AEMExtensionAdvancedWindows: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-True { $res.Result } (GetWrongTestResult $res $false)
        Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Debug "Test-AEMExtensionAdvancedWindows: Test done"

        # Remove command.
        Write-Debug "Test-AEMExtensionAdvancedWindows: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Debug "Test-AEMExtensionAdvancedWindows: Remove done"

        Write-Debug "Test-AEMExtensionAdvancedWindows: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        Write-Debug "Test-AEMExtensionAdvancedWindows: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedWindows
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Debug "Start the test Test-AEMExtensionAdvancedWindows"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2
        $vmname = $vm.Name
        Write-Debug "Test-AEMExtensionAdvancedWindows: VM created"

        # Get with not extension
        Write-Debug "Test-AEMExtensionAdvancedWindows: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"

        # Test with not extension
        Write-Debug "Test-AEMExtensionAdvancedWindows: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-False { $res.Result }
        Write-Debug "Test-AEMExtensionAdvancedWindows: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Debug "Test-AEMExtensionAdvancedWindows: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Write-Debug "Test-AEMExtensionAdvancedWindows: Set done"
        Write-Debug "Test-AEMExtensionAdvancedWindows: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.AzureCAT.AzureEnhancedMonitoring'
        Assert-AreEqual $extension.ExtensionType 'AzureCATExtensionHandler'
        Assert-AreEqual $extension.Name 'AzureCATExtensionHandler'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg
        Write-Debug "Test-AEMExtensionAdvancedWindows: Get done"

        # Test command.
        Write-Debug "Test-AEMExtensionAdvancedWindows: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-True { $res.Result }
        Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Debug "Test-AEMExtensionAdvancedWindows: Test done"

        # Remove command.
        Write-Debug "Test-AEMExtensionAdvancedWindows: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Debug "Test-AEMExtensionAdvancedWindows: Remove done"

        Write-Debug "Test-AEMExtensionAdvancedWindows: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        Write-Debug "Test-AEMExtensionAdvancedWindows: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedWindowsMD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Debug "Start the test Test-AEMExtensionAdvancedWindowsMD"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2 -useMD
        $vmname = $vm.Name
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: VM created"

        # Get with not extension
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"

        # Test with not extension
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-False { $res.Result }
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Set done"
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.AzureCAT.AzureEnhancedMonitoring'
        Assert-AreEqual $extension.ExtensionType 'AzureCATExtensionHandler'
        Assert-AreEqual $extension.Name 'AzureCATExtensionHandler'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg
		Assert-True { ($extension.PublicSettings.Contains("osdisk.caching")) }
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Get done"

        # Test command.
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-True { $res.Result }
        Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Test done"

        # Remove command.
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Remove done"

        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        Write-Debug "Test-AEMExtensionAdvancedWindowsMD: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedLinuxMD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Host "Start the test Test-AEMExtensionAdvancedLinuxMD"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2 -useMD -linux
		$vmname = $vm.Name
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname
		Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Empty -DiskSizeInGB 2059 | Update-AzVM
		
        
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: VM created"

        # Get with not extension
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null" "Extension is not null"

        # Test with not extension
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
		$tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        Assert-False { $res.Result } "Test result is not false $out"
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Set done"
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Get done"

        # Test command.
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
		$tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        Assert-True { $res.Result } "Test result is not false $out"
        Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Test done"

        # Remove command.
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Remove done"

        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionBasicLinuxWAD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
       # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -linux
        $vmname = $vm.Name

        # Get with not extension
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        # Test with not extension
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-False { $testResult.Result }

        # Set and Get command.
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorage -EnableWAD
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg

        # Test command.
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WaitTimeInMinutes 50 -SkipStorageCheck
        Assert-True { $testResult.Result }
        Assert-True { ($testResult.PartialResults.Count -gt 0) }

        # Remove command.
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionBasicLinux
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
       # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -linux
        $vmname = $vm.Name

        # Get with not extension
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        # Test with not extension
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-False { $testResult.Result }

        # Set and Get command.
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorage
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg

        # Test command.
        $testResult = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WaitTimeInMinutes 50 -SkipStorageCheck
        Assert-True { $testResult.Result }
        Assert-True { ($testResult.PartialResults.Count -gt 0) }

        # Remove command.
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedLinuxWAD
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Debug "Start the test Test-AEMExtensionAdvancedLinux"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2 -linux
        $vmname = $vm.Name
        Write-Debug "Test-AEMExtensionAdvancedLinux: VM created"

        # Get with not extension
        Write-Debug "Test-AEMExtensionAdvancedLinux: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"

        # Test with not extension
        Write-Debug "Test-AEMExtensionAdvancedLinux: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Write-Debug ("Test-AEMExtensionAdvancedLinux: Test result " + $res.Result)
        Assert-False { $res.Result } (GetWrongTestResult $res $true)
        Write-Debug "Test-AEMExtensionAdvancedLinux: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Debug "Test-AEMExtensionAdvancedLinux: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage -EnableWAD
        Write-Debug "Test-AEMExtensionAdvancedLinux: Set done"
        Write-Debug "Test-AEMExtensionAdvancedLinux: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg
        Write-Debug "Test-AEMExtensionAdvancedLinux: Get done"

        # Test command.
        Write-Debug "Test-AEMExtensionAdvancedLinux: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-True { $res.Result } (GetWrongTestResult $res $false)
        Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Debug "Test-AEMExtensionAdvancedLinux: Test done"

        # Remove command.
        Write-Debug "Test-AEMExtensionAdvancedLinux: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Debug "Test-AEMExtensionAdvancedLinux: Remove done"

        Write-Debug "Test-AEMExtensionAdvancedLinux: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        Write-Debug "Test-AEMExtensionAdvancedLinux: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedLinux
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        Write-Debug "Start the test Test-AEMExtensionAdvancedLinux"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_DS2' -stotype 'Premium_LRS' -nicCount 2 -linux
        $vmname = $vm.Name
        Write-Debug "Test-AEMExtensionAdvancedLinux: VM created"

        # Get with not extension
        Write-Debug "Test-AEMExtensionAdvancedLinux: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"

        # Test with not extension
        Write-Debug "Test-AEMExtensionAdvancedLinux: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Write-Debug ("Test-AEMExtensionAdvancedLinux: Test result " + $res.Result)
        Assert-False { $res.Result }
        Write-Debug "Test-AEMExtensionAdvancedLinux: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Debug "Test-AEMExtensionAdvancedLinux: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Write-Debug "Test-AEMExtensionAdvancedLinux: Set done"
        Write-Debug "Test-AEMExtensionAdvancedLinux: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg
        Write-Debug "Test-AEMExtensionAdvancedLinux: Get done"

        # Test command.
        Write-Debug "Test-AEMExtensionAdvancedLinux: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
        Assert-True { $res.Result }
        Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Debug "Test-AEMExtensionAdvancedLinux: Test done"

        # Remove command.
        Write-Debug "Test-AEMExtensionAdvancedLinux: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Debug "Test-AEMExtensionAdvancedLinux: Remove done"

        Write-Debug "Test-AEMExtensionAdvancedLinux: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        Write-Debug "Test-AEMExtensionAdvancedLinux: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedLinuxMD_E
{
    $rgname = Get-ComputeTestResourceName
    $loc = "eastus2"

    try
    {
        Write-Debug "Start the test Test-AEMExtensionAdvancedLinuxMD_E"
        # Setup

		$ultraSSDInfo = Get-AzComputeResourceSku | where { $_.LocationInfo.Location -eq $loc -and $_.Name -eq "UltraSSD_LRS" };
		Write-Debug "Test-AEMExtensionAdvancedLinuxMD_E: Got UltraSSD info $($ultraSSDInfo)"
		
		$zoneparams = @{}
		if ($ultraSSDInfo) 
		{
			$zoneparams.Add("zone", $ultraSSDInfo.LocationInfo.Zones[0])	
		}
		
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_E4s_v3' -stotype 'Premium_LRS' -nicCount 2 -useMD -linux @zoneparams
		Write-Debug "Test-AEMExtensionAdvancedLinuxMD_E: VM created"
		$vmname = $vm.Name
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname
		Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Empty -DiskSizeInGB 2059 | Update-AzVM
		Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Empty -DiskSizeInGB 16000 | Update-AzVM
		Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Empty -DiskSizeInGB 32000 | Update-AzVM

		if ($ultraSSDInfo) 
		{		
    
            $nul = Stop-AzVm -ResourceGroupName $rgname -Name $vmname -Force
            $vm = Get-AzVM -ResourceGroupName $rgname -VMName $vmname
            $vm | update-azvm -UltraSSDEnabled $true
            $nul = Start-AzVm -ResourceGroupName $rgname -Name $vmname
            
			$ultraDisk = New-AzDiskConfig -SkuName UltraSSD_LRS -DiskSizeGB 512 -DiskIOPSReadWrite 5000 -DiskMBpsReadWrite 20 -CreateOption Empty -Location $loc -Zone $ultraSSDInfo.LocationInfo.Zones[0] `
				| New-AzDisk -ResourceGroupName $rgname -DiskName "ultrassd"
            
            Add-AzVMDataDisk -VM $vm  -ManagedDiskId $ultraDisk.Id -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Attach `
                | Update-AzVM
		}
		else 
		{
			Write-Debug "Test-AEMExtensionAdvancedLinuxMD_E: not testing UltraSSD because the resource sku is not available"
		}
        
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: VM created"

        # Get with not extension
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null" "Extension is not null"

        # Test with not extension
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
		$tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        Assert-False { $res.Result } "Test result is not false $out"
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Set done"
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Get done"

        # Test command.
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
		$tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        Assert-True { $res.Result } "Test result is not false $out"
        Assert-True { ($res.PartialResults.Count -gt 0) }
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Test done"

        # Remove command.
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Remove done"

        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        Write-Debug "Test-AEMExtensionAdvancedLinuxMD: Get after remove done"
    }
	catch 
	{
		Write-Debug "Exception while runnign test: $($_)"
		throw
	}
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Test-AEMExtensionAdvancedLinuxMD_D
{
    $rgname = Get-ComputeTestResourceName
    $loc = "southeastasia"

    try
    {
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Start the test Test-AEMExtensionAdvancedLinuxMD"
        # Setup
        $vm = Create-AdvancedVM -rgname $rgname -loc $loc -vmsize 'Standard_D2s_v3' -stotype 'Premium_LRS' -nicCount 2 -useMD -linux

		Log "Test-AEMExtensionAdvancedLinuxMD_D" "VM created"
		$vmname = $vm.Name
		$vm = Get-AzVM -ResourceGroupName $rgname -Name $vmname
		Add-AzVMDataDisk -VM $vm -StorageAccountType Premium_LRS -Lun (($vm.StorageProfile.DataDisks | select -ExpandProperty Lun | Measure-Object -Maximum).Maximum + 1) -CreateOption Empty -DiskSizeInGB 2059 | Update-AzVM
		
        
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: VM created"

        # Get with not extension
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Get with no extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null" "Extension is not null"

        # Test with not extension
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Test with no extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
		$tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        Assert-False { $res.Result } "Test result is not false $out"
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Test done"

        $stoname = 'sto' + $rgname + "2";
        New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type 'Standard_LRS';

        # Set and Get command.
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Set with no extension"
        Set-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -WADStorageAccountName $stoname -SkipStorage
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Set done"
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Get with extension"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.OSTCExtensions'
        Assert-AreEqual $extension.ExtensionType 'AzureEnhancedMonitorForLinux'
        Assert-AreEqual $extension.Name 'AzureEnhancedMonitorForLinux'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-NotNull $settings.cfg
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Get done"

        # Test command.
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Test with extension"
        $res = Test-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname -SkipStorageCheck
		$tmp = $res;$out = &{while ($true) { if ($tmp) { foreach ($tmpRes in $tmp) {($tmpRes.TestName  + " " + $tmpRes.Result)};$tmp = @($tmp.PartialResults)} else {break}}};
        Assert-True { $res.Result } "Test result is not false $out"
        Assert-True { ($res.PartialResults.Count -gt 0) }
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Test done"

        # Remove command.
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Remove with extension"
        Remove-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Remove done"

        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Get after remove"
        $extension = Get-AzVMAEMExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension "Extension is not null"
        Log "Test-AEMExtensionAdvancedLinuxMD_D" "Test-AEMExtensionAdvancedLinuxMD: Get after remove done"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

function Create-AdvancedVM($rgname, $vmname, $loc, $vmsize, $stotype, $nicCount, [Switch] $linux, [Switch] $useMD, $zone)
{
	Write-Debug "Start Create-AdvancedVM"
	
    # Initialize parameters
    $rgname = if ([string]::IsNullOrEmpty($rgname)) { Get-ComputeTestResourceName } else { $rgname }
    $vmname = if ([string]::IsNullOrEmpty($vmname)) { 'vm' + $rgname } else { $vmname }
    $loc = if ([string]::IsNullOrEmpty($loc)) { Get-ComputeVMLocation } else { $loc }
    $vmsize = if ([string]::IsNullOrEmpty($vmsize)) { 'Standard_A2' } else { $vmsize }
    $stotype = if ([string]::IsNullOrEmpty($stotype)) { 'Standard_LRS' } else { $stotype }
    $nicCount = if ([string]::IsNullOrEmpty($nicCount)) { 1 } else { [int]$nicCount }

    # Common
    $g = New-AzResourceGroup -Name $rgname -Location $loc -Force;

    # VM Profile & Hardware
	$zoneparams = @{}
	if ($zone) 
	{
		$zoneparams.Add("Zone", $zone)	
	}
    $p = New-AzVMConfig -VMName $vmname -VMSize $vmsize @zoneparams;
    Assert-AreEqual $p.HardwareProfile.VmSize $vmsize;

	Write-Debug "Start Create-AdvancedVM - Config done"

    # NRP
    $subnet = New-AzVirtualNetworkSubnetConfig -Name ('subnet' + $rgname) -AddressPrefix "10.0.0.0/24";
    $vnet = New-AzVirtualNetwork -Force -Name ('vnet' + $rgname) -ResourceGroupName $rgname -Location $loc -AddressPrefix "10.0.0.0/16" -Subnet $subnet;
    $vnet = Get-AzVirtualNetwork -Name ('vnet' + $rgname) -ResourceGroupName $rgname;
    $subnetId = $vnet.Subnets[0].Id;
    $pubip = New-AzPublicIpAddress -Force -Name ('pubip' + $rgname) -ResourceGroupName $rgname -Location $loc -AllocationMethod Static -DomainNameLabel ('pubip' + $rgname) -Sku Standard;
    $pubip = Get-AzPublicIpAddress -Name ('pubip' + $rgname) -ResourceGroupName $rgname;
    $pubipId = $pubip.Id;
    
	Write-Debug "Start Create-AdvancedVM - adding pip $($pubip.Id)"
    $pibparams = @{}
    $pibparams.Add("PublicIpAddressId", $pubip.Id)
    $nicPrimParams = @{}
    $nicPrimParams.Add("Primary", $true)
    for ($i = 0;$i -lt $nicCount;$i++)
    {
        $nic = New-AzNetworkInterface -Force -Name ('nic' + $i + $rgname) -ResourceGroupName $rgname -Location $loc -SubnetId $subnetId @pibparams
        $nic = Get-AzNetworkInterface -Name ('nic' + $i + $rgname) -ResourceGroupName $rgname;
        $nicId = $nic.Id;

        $p = Add-AzVMNetworkInterface -VM $p -Id $nicId @nicPrimParams;
        Assert-AreEqual $p.NetworkProfile.NetworkInterfaces[$i].Id $nicId;

        $pibparams = @{}
        $nicPrimParams = @{}
    }
    Assert-AreEqual $p.NetworkProfile.NetworkInterfaces.Count $nicCount;   
	Write-Debug "Start Create-AdvancedVM 1"
    # Storage Account (SA)
    $stoname = 'sto' + $rgname;
    $s = New-AzStorageAccount -ResourceGroupName $rgname -Name $stoname -Location $loc -Type $stotype;
    $global:stoaccount = Get-AzStorageAccount -ResourceGroupName $rgname -Name $stoname;
    $stokey = (Get-AzStorageAccountKey -ResourceGroupName $rgname -Name $stoname).Key1;

    $osDiskName = 'osDisk';
    $osDiskCaching = 'ReadWrite';
    $osDiskVhdUri = "https://$stoname.blob.core.windows.net/test/os.vhd";
    $dataDiskVhdUri1 = "https://$stoname.blob.core.windows.net/test/data1.vhd";
    $dataDiskVhdUri2 = "https://$stoname.blob.core.windows.net/test/data2.vhd";
    $dataDiskVhdUri3 = "https://$stoname.blob.core.windows.net/test/data3.vhd";

	$osURI = @{}
	$disk1Uri = @{}
	$disk2Uri = @{}
	$disk3Uri = @{}
	Write-Debug "Start Create-AdvancedVM 2"
	if (-not $useMD)
	{
		$osURI = @{"VhdUri"=$osDiskVhdUri}
		$disk1Uri = @{"VhdUri"=$dataDiskVhdUri1}
		$disk2Uri = @{"VhdUri"=$dataDiskVhdUri2}
		$disk3Uri = @{"VhdUri"=$dataDiskVhdUri3}
	}

    $p = Set-AzVMOSDisk -VM $p -Name $osDiskName @osURI -Caching $osDiskCaching -CreateOption FromImage -DiskSizeInGB 128;
	Write-Debug "Start Create-AdvancedVM 3"
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk1' -Caching 'ReadOnly' -DiskSizeInGB 10 -Lun 1 @disk1Uri -CreateOption Empty;
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk2' -Caching 'ReadOnly' -DiskSizeInGB 11 -Lun 2 @disk2Uri -CreateOption Empty;
    $p = Add-AzVMDataDisk -VM $p -Name 'testDataDisk3' -Caching 'ReadOnly' -DiskSizeInGB 12 -Lun 3 @disk3Uri -CreateOption Empty;
    $p = Remove-AzVMDataDisk -VM $p -Name 'testDataDisk3';

    Assert-AreEqual $p.StorageProfile.OsDisk.Caching $osDiskCaching;
    Assert-AreEqual $p.StorageProfile.OsDisk.Name $osDiskName;
	if (-not $useMD)
	{
		Assert-AreEqual $p.StorageProfile.OsDisk.Vhd.Uri $osDiskVhdUri;
	}
    Assert-AreEqual $p.StorageProfile.DataDisks.Count 2;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[0].DiskSizeGB 10;
    Assert-AreEqual $p.StorageProfile.DataDisks[0].Lun 1;
	if (-not $useMD)
	{
		Assert-AreEqual $p.StorageProfile.DataDisks[0].Vhd.Uri $dataDiskVhdUri1;
	}
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Caching 'ReadOnly';
    Assert-AreEqual $p.StorageProfile.DataDisks[1].DiskSizeGB 11;
    Assert-AreEqual $p.StorageProfile.DataDisks[1].Lun 2;
	if (-not $useMD)
	{
		Assert-AreEqual $p.StorageProfile.DataDisks[1].Vhd.Uri $dataDiskVhdUri2;
	}
	Write-Debug "Start Create-AdvancedVM 4"
    # OS & Image
    $user = "Foo12";
    $password = $PLACEHOLDER;
    $securePassword = ConvertTo-SecureString $password -AsPlainText -Force;
    $cred = New-Object System.Management.Automation.PSCredential ($user, $securePassword);
    $computerName = 'test';
    $vhdContainer = "https://$stoname.blob.core.windows.net/test";
	Write-Debug "Start Create-AdvancedVM 5"
    if ($linux)
    {
        $p = Set-AzVMOperatingSystem -VM $p -Linux -ComputerName $computerName -Credential $cred;

        $imgRef = Get-LinuxImage;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);
    }
    else
    {
        $p = Set-AzVMOperatingSystem -VM $p -Windows -ComputerName $computerName -Credential $cred -ProvisionVMAgent;

        $imgRef = Get-DefaultCRPWindowsImageOffline;
        $p = ($imgRef | Set-AzVMSourceImage -VM $p);
    }
	Write-Debug "Start Create-AdvancedVM 6"
    Assert-AreEqual $p.OSProfile.AdminUsername $user;
    Assert-AreEqual $p.OSProfile.ComputerName $computerName;
    Assert-AreEqual $p.OSProfile.AdminPassword $password;
    if (-not $linux)
    {
        Assert-AreEqual $p.OSProfile.WindowsConfiguration.ProvisionVMAgent $true;
    }

    Assert-AreEqual $p.StorageProfile.ImageReference.Offer $imgRef.Offer;
    Assert-AreEqual $p.StorageProfile.ImageReference.Publisher $imgRef.PublisherName;
    Assert-AreEqual $p.StorageProfile.ImageReference.Sku $imgRef.Skus;
    Assert-AreEqual $p.StorageProfile.ImageReference.Version $imgRef.Version;
	Write-Debug "Start Create-AdvancedVM 7"
	$vmConfig = $p | convertto-json
	Write-Debug "Start Create-AdvancedVM 8 $vmConfig"
    # Virtual Machine
    $p = Set-AzVMBootDiagnostics -VM $p -Disable
	Write-Debug "Start Create-AdvancedVM - creating VM $($vmConfig)"
	
	Write-Debug "Start Create-AdvancedVM - creating VM $($vmConfig)"
    $v = New-AzVM -ResourceGroupName $rgname -Location $loc -VM $p;

    $vm = Get-AzVM -ResourceGroupName $rgname -VMName $vmname
    return $vm
}

function Get-LinuxImage
{
    return Create-ComputeVMImageObject 'SUSE' 'SLES' '12-SP4' 'latest';
}

function GetWrongTestResult($TestResult, $searchFor, $level)
{	
	$result = ""

	if (-not $level) {$level = 0}

	if ($TestResult.Result -eq $searchFor)
	{
		$result += [String]::new("`t", $level) + $TestResult.TestName + " is not expected. Actual result is " +  $TestResult.Result + [Environment]::NewLine
	}
	foreach ($tmpRes in $TestResult.PartialResults) 
	{
		$result += GetWrongTestResult $tmpRes $searchFor ($level+1)
	}

	return $result
}
