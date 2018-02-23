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
Convert Hyper-V VM to Azure supported virtual hard disk files
#>
function ConvertTo-AzureRmVhd
{
    [CmdletBinding(SupportsShouldProcess = $true)]
    [OutputType([System.Management.Automation.PathInfo])]
    param
    (
        [Parameter(ParameterSetName = 'Hyper-V', Mandatory = $true)]
        [string]$HyperVVMName,
        
        [Parameter(ParameterSetName = 'Hyper-V', Mandatory = $true)]
        [string]$ExportPath,
        
        [Parameter(ParameterSetName = 'Hyper-V')]
        [string]$HyperVServer = 'localhost',
      
        [Parameter(ParameterSetName = 'Hyper-V')]
        [switch]$Force,
        
        [Parameter(ParameterSetName = 'Hyper-V')]
        [switch]$AsJob
    )

    if ($AsJob)
    {
        Start-Job -ScriptBlock ${function:ExecuteCmdlet} -Argumentlist $HyperVVMName,$ExportPath,$HyperVServer,$Force;
    }
    else
    {
        ExecuteCmdlet $HyperVVMName $ExportPath $HyperVServer $Force;
    }
}

function ExecuteCmdlet($HyperVVMName, $ExportPath, $HyperVServer, $Force)
{
    function Get-HyperVVhdFolder([string]$exportPath, [string]$hyperVVMName)
    {
        [string]$defaultVhdSubFolderName = 'Virtual Hard Disks';
        $vhdxFolder = Join-Path $exportPath "${hyperVVMName}\${defaultVhdSubFolderName}";
        return $vhdxFolder;
    }

    function Export-DiskFiles([string]$computerName, [string]$vmName, [string]$exportDir)
    {
        # Record the supposed to be exported VHD files first
        $vmObj = Get-VM -ComputerName $computerName -Name $vmName;
        if (-not $vmObj.HardDrives -or $vmObj.HardDrives.Count -le 0)
        {
            throw "No hard drives can be found from VM '$vmName'...";
        }
        [string[]]$vmDiskFileNames = @();
        foreach ($hd in $vmObj.HardDrives)
        {
            $vmDiskFileNames += (Split-Path -Path $hd.Path -Leaf);
        }
    
        # Start the real export process
        $st = Export-VM -ComputerName $computerName -Name $vmName -Path $exportDir;
  
        # Construct the final VHD file paths
        [string[]]$vhdFiles = @();
        foreach ($fileName in $vmDiskFileNames)
        {
            $vhdFullName = Join-Path (Get-HyperVVhdFolder $exportDir $vmName) $fileName;
            if (-not (Test-Path $vhdFullName))
            {
                throw "The VHD file '$vhdFullName' should have been exported, but it cannot be found.";
            }
            $vhdFiles += $vhdFullName;
        }
        Write-Debug "Exported VHD files: '$vhdFiles'";
        return $vhdFiles;
    }

    function TryGet-HyperVVM([string]$computerName, [string]$hvvmName)
    {
        if ([string]::IsNullOrEmpty($computerName))
        {
            Write-Warning "Hyper-V computer name cannot be null or empty.";
            return $false;
        }
        if ([string]::IsNullOrEmpty($hvvmName))
        {
            Write-Warning "Hyper-V VM name cannot be null or empty.";
            return $false;
        }

        try
        {
            $allVMs = Get-VM -ComputerName $computerName;
            $hvvm = $allVMs | where {$_.Name -eq $hvvmName};
            if ($hvvm -ne $null)
            {
                Write-Debug ("Found Hyper-V VM by name '$hvvmName': " + $hvvm);
                return $true;
            }
            else
            {
                Write-Warning ("Cannot find Hyper-V VM by name '$hvvmName'...");
                return $false;
            }
        }
        catch
        {
            throw;
        }
    }

    if (-not (TryGet-HyperVVM $HyperVServer $HyperVVMName))
    {
        throw "Cannot find VM '$HyperVVMName' from server '$HyperVServer'; exit.";
    }

    $vhdxFolder = Get-HyperVVhdFolder $ExportPath $HyperVVMName;
    [string[]]$vhdFiles = @();
    if (Test-Path $vhdxFolder)
    {
        if ($Force)
        {
            $st = rmdir -Recurse -Force $vhdxFolder;
        }
        else
        {
            throw "Export path already exists '$vhdxFolder'; please delete & retry...";
        }
    }

    if ($PSCmdlet.ShouldProcess($HyperVVMName, "Converting a Hyper-V VM to Azure supported VHD file(s)..."))
    {
        $vhdFiles = Export-DiskFiles $HyperVServer $HyperVVMName $ExportPath;

        # Convert the various VHD/VHDX file formats to fixed VHD files
        $convertedVhdPath = Join-Path $vhdxFolder "Converted";
        $st = mkdir $convertedVhdPath -Force;
        [array]$destFiles = @();
        foreach ($vhdFile in $vhdFiles)
        {
            $vhdFileName = Split-Path -Leaf -Path $vhdFile;
            $destFile = Join-Path $convertedVhdPath $vhdFileName.Replace('.vhdx', '.vhd');
            Write-Verbose "Converting '$($vhdFile)' to '$destFile'...";
            $st = Convert-VHD -Path $vhdFile -DestinationPath $destFile;
            $destFiles += (Resolve-Path $destFile);
        }
        Write-Output $destFiles;
    }
}
