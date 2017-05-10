
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


#
# ChefExtensionTests.ps1
#

$PLACEHOLDER = "PLACEHOLDER1@";

<#
.SYNOPSIS
Test the usage of the Set virtual machine chef extension command
#>

function Test-SetAzureVMChefExtension
{
    # Setup
    $vmName = "vmtwo"
    $svcName = "stortwo"
    $storageName = "stortwo"
    $location = "West US"
    $TestOutputRoot = [System.AppDomain]::CurrentDomain.BaseDirectory;

    try
    {
        New-AzureStorageAccount -StorageAccountName $storageName -Location $location
        Set-CurrentStorageAccountName $storageName

        New-AzureService -ServiceName $svcName -Location $location
        New-AzureQuickVM -Windows -ImageName "a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-R2-20161214-en.us-127GB.vhd" -Name $vmName -ServiceName $svcName -AdminUsername "pstestuser" -Password $PLACEHOLDER
        $vm = Get-AzureVM -ServiceName $svcName -Name $vmName

        Set-AzureVMChefExtension -VM $vm -ValidationPem "$TestOutputRoot\Resources\ChefExtension\tstorgnztn-validator.pem" -ClientRb "$TestOutputRoot\Resources\ChefExtension\client.rb" -JsonAttribute '{"container_service": {"chef-init-test": {"command": "C:\\opscode\\chef\\bin"}}}' -ChefDaemonInterval 35 -Windows

        Update-AzureVM -VM $vm.VM -ServiceName $svcName -Name $vmName

        # Call Get-AzureVMDscExtensionStatus to check the status of the installation
        [TimeSpan] $timeout = [TimeSpan]::FromMinutes(60)
        $maxTime = [datetime]::Now + $timeout
        $status = Get-AzureVMChefExtension -VM $vm.VM

        while($true)
        {
            if($status -ne $null -and $status.State -ne $null)
            {
                if(($status.State -eq "Enable") -or ($status.State -eq "Error"))
                {
                    break;
                }
            }
        
            if([datetime]::Now -gt $maxTime)
            {
                Throw "The Chef Extension did not report any status within the given timeout from VM [$vmName]"
            }

            if ($env:AZURE_TEST_MODE -eq "Record"){
                sleep -Seconds 15
            }
            $status = Get-AzureVMChefExtension -VM $vm.VM
        }

        # Call Get-AzureVMChefExtension to ensure extension was installed on the VM
        $vm = Get-AzureVM -ServiceName $svcName -Name $vmName
        $extension = Get-AzureVMChefExtension -VM $vm.VM -Verbose
        Assert-NotNull $extension
        Assert-NotNull $extension.ExtensionName
        Assert-NotNull $extension.Publisher
        Assert-NotNull $extension.Version

        # Remove Extension
        Remove-AzureVMChefExtension -VM $vm.VM -Verbose
    }
    finally
    {
        # Cleanup
        Remove-AzureStorageAccount -StorageAccountName $storageName -ErrorAction SilentlyContinue
        Cleanup-CloudService $svcName
    }
}


<#
.SYNOPSIS
Test the usage of the Set virtual machine chef extension command with some advanced options
#>

function Test-SetAzureVMChefExtensionAdvancedOptions
{
    # Setup
    $vmName = "vmthree"
    $svcName = "storthree"
    $storageName = "storthree"
    $location = "West US"
    $TestOutputRoot = [System.AppDomain]::CurrentDomain.BaseDirectory;

    try
    {
        New-AzureStorageAccount -StorageAccountName $storageName -Location $location
        Set-CurrentStorageAccountName $storageName

        New-AzureService -ServiceName $svcName -Location $location
        New-AzureQuickVM -Windows -ImageName "a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-R2-20161214-en.us-127GB.vhd" -Name $vmName -ServiceName $svcName -AdminUsername "pstestuser" -Password $PLACEHOLDER

        $vm = Get-AzureVM -ServiceName $svcName -Name $vmName

        Set-AzureVMChefExtension -VM $vm -ValidationPem "$TestOutputRoot\Resources\ChefExtension\tstorgnztn-validator.pem" -ClientRb "$TestOutputRoot\Resources\ChefExtension\client.rb" -Daemon "service" -SecretFile "$TestOutputRoot\Resources\ChefExtension\encrypted_data_bag_secret" -Windows

        Update-AzureVM -VM $vm.VM -ServiceName $svcName -Name $vmName

        # Call Get-AzureVMDscExtensionStatus to check the status of the installation
        [TimeSpan] $timeout = [TimeSpan]::FromMinutes(60)
        $maxTime = [datetime]::Now + $timeout
        $status = Get-AzureVMChefExtension -VM $vm.VM

        while($true)
        {
            if($status -ne $null -and $status.State -ne $null)
            {
                if(($status.State -eq "Enable") -or ($status.State -eq "Error"))
                {
                    break;
                }
            }
        
            if([datetime]::Now -gt $maxTime)
            {
                Throw "The Chef Extension did not report any status within the given timeout from VM [$vmName]"
            }

            if ($env:AZURE_TEST_MODE -eq "Record"){
                sleep -Seconds 15
            }
            $status = Get-AzureVMChefExtension -VM $vm.VM
        }

        # Call Get-AzureVMChefExtension to ensure extension was installed on the VM
        $vm = Get-AzureVM -ServiceName $svcName -Name $vmName
        $extension = Get-AzureVMChefExtension -VM $vm.VM -Verbose
        Assert-NotNull $extension
        Assert-NotNull $extension.ExtensionName
        Assert-NotNull $extension.Publisher
        Assert-NotNull $extension.Version

        # Remove Extension
        Remove-AzureVMChefExtension -VM $vm.VM -Verbose
    }
    finally
    {
        # Cleanup
        Remove-AzureStorageAccount -StorageAccountName $storageName -ErrorAction SilentlyContinue
        Cleanup-CloudService $svcName
    }
}

<#
.SYNOPSIS
Test the usage of the passing Daemon as task
#>

function Test-SetAzureVMChefExtensionDaemonTask
{
    # Setup
    $vmName = "vmseven"
    $svcName = "storseven"
    $storageName = "storseven"
    $location = "West US"
    $TestOutputRoot = [System.AppDomain]::CurrentDomain.BaseDirectory;

    try
    {
        New-AzureStorageAccount -StorageAccountName $storageName -Location $location
        Set-CurrentStorageAccountName $storageName

        New-AzureService -ServiceName $svcName -Location $location
        New-AzureQuickVM -Windows -ImageName "a699494373c04fc0bc8f2bb1389d6106__Windows-Server-2012-R2-20161214-en.us-127GB.vhd" -Name $vmName -ServiceName $svcName -AdminUsername "pstestuser" -Password $PLACEHOLDER

        $vm = Get-AzureVM -ServiceName $svcName -Name $vmName

        Set-AzureVMChefExtension -VM $vm -ValidationPem "$TestOutputRoot\Resources\ChefExtension\tstorgnztn-validator.pem" -ClientRb "$TestOutputRoot\Resources\ChefExtension\client.rb" -Daemon "task" -Windows

        Update-AzureVM -VM $vm.VM -ServiceName $svcName -Name $vmName

        # Call Get-AzureVMDscExtensionStatus to check the status of the installation
        [TimeSpan] $timeout = [TimeSpan]::FromMinutes(60)
        $maxTime = [datetime]::Now + $timeout
        $status = Get-AzureVMChefExtension -VM $vm.VM

        while($true)
        {
            if($status -ne $null -and $status.State -ne $null)
            {
                if(($status.State -eq "Enable") -or ($status.State -eq "Error"))
                {
                    break;
                }
            }
        
            if([datetime]::Now -gt $maxTime)
            {
                Throw "The Chef Extension did not report any status within the given timeout from VM [$vmName]"
            }

            if ($env:AZURE_TEST_MODE -eq "Record"){
                sleep -Seconds 15
            }
            $status = Get-AzureVMChefExtension -VM $vm.VM
        }

        # Call Get-AzureVMChefExtension to ensure extension was installed on the VM
        $vm = Get-AzureVM -ServiceName $svcName -Name $vmName
        $extension = Get-AzureVMChefExtension -VM $vm.VM -Verbose
        Assert-NotNull $extension
        Assert-NotNull $extension.ExtensionName
        Assert-NotNull $extension.Publisher
        Assert-NotNull $extension.Version

        # Remove Extension
        Remove-AzureVMChefExtension -VM $vm.VM -Verbose
    }
    finally
    {
        # Cleanup
        Remove-AzureStorageAccount -StorageAccountName $storageName -ErrorAction SilentlyContinue
        Cleanup-CloudService $svcName
    }
}
