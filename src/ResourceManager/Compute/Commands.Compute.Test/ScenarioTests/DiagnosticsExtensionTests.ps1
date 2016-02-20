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
Test the basic usage of the Set/Get/Remove virtual machine diagnostics extension command
#>
function Test-DiagnosticsExtensionBasic
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Setup
        $vm = Create-VirtualMachine -rgname $rgname -loc $loc
        $vmname = $vm.Name

        # This is the storage name defined in config file
        $storagename = 'definedinconfigstorage'
        $storagetype = 'Standard_GRS'
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $storagename -Location $loc -Type $storagetype

        # If diagnostics extension already exist, remove it
        $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
        if ($extension) {
            Remove-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
            $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
            Assert-Null $extension
        }

        # Test Set and Get command. It should use the storage account defined in configuration file
        Set-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname -DiagnosticsConfigurationPath "$TestOutputRoot\ConfigFiles\DiagnosticsExtensionConfig.xml"
        $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.Azure.Diagnostics'
        Assert-AreEqual $extension.ExtensionType 'IaaSDiagnostics'
        Assert-AreEqual $extension.Name 'Microsoft.Insights.VMDiagnosticsSettings'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-AreEqual $settings.storageAccount $storagename

        # Test Remove command.
        Remove-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
        $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
        Assert-Null $extension
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test specifying storage account name in command line.
The diagnostic extension should use this name instead of the one defined in config file.
#>
function Test-DiagnosticsExtensionSepcifyStorageAccountName
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Setup
        $vm = Create-VirtualMachine -rgname $rgname -loc $loc
        $vmname = $vm.Name

        # This storage name will be used in command line directly when set diagnostics extension
        $storagename = 'definedincommandline'
        $storagetype = 'Standard_GRS'
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $storagename -Location $loc -Type $storagetype

        # If diagnostics extension already exist, remove it
        $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
        if ($extension) {
            Remove-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
            $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
            Assert-Null $extension
        }

        Set-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname -DiagnosticsConfigurationPath "$TestOutputRoot\ConfigFiles\DiagnosticsExtensionConfig.xml" -StorageAccountName $storagename
        $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname

        Assert-NotNull $extension
        Assert-AreEqual $extension.Publisher 'Microsoft.Azure.Diagnostics'
        Assert-AreEqual $extension.ExtensionType 'IaaSDiagnostics'
        Assert-AreEqual $extension.Name 'Microsoft.Insights.VMDiagnosticsSettings'
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-AreEqual $settings.storageAccount $storagename
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test the case if we can't list the storage account key, the command should fail.
#>
function Test-DiagnosticsExtensionCantListSepcifyStorageAccountKey
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Setup
        $vm = Create-VirtualMachine -rgname $rgname -loc $loc
        $vmname = $vm.Name

        # If diagnostics extension already exist, remove it
        $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
        if ($extension) {
            Remove-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
            $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
            Assert-Null $extension
        }

        # Get a random storage account name, which we can't list the key
        $storagename = 'notexiststorage'
        Assert-ThrowsContains `
            { Set-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname -DiagnosticsConfigurationPath "$TestOutputRoot\ConfigFiles\DiagnosticsExtensionConfig.xml" -StorageAccountName $storagename } `
            'Storage account key'
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Test that we support config file in json format
#>
function Test-DiagnosticsExtensionSupportJsonConfig
{
    $rgname = Get-ComputeTestResourceName
    $loc = Get-ComputeVMLocation

    try
    {
        # Setup
        $vm = Create-VirtualMachine -rgname $rgname -loc $loc
        $vmname = $vm.Name
        $storagename = $vmname + "storage"
        $storagetype = 'Standard_GRS'
        New-AzureRmStorageAccount -ResourceGroupName $rgname -Name $storagename -Location $loc -Type $storagetype

        # If diagnostics extension already exist, remove it
        $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
        if ($extension) {
            Remove-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
            $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname
            Assert-Null $extension
        }

        Set-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname -DiagnosticsConfigurationPath "$TestOutputRoot\ConfigFiles\DiagnosticsExtensionConfig.json" -StorageAccountName $storagename
        $extension = Get-AzureRmVMDiagnosticsExtension -ResourceGroupName $rgname -VMName $vmname

        Assert-NotNull $extension
        $settings = $extension.PublicSettings | ConvertFrom-Json
        Assert-AreEqual $settings.storageAccount $storagename
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}