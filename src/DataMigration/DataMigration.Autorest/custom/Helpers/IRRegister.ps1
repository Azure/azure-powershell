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

# This script Register/ Re-register IR with provided Auth key.
# Requirements for Re-registration:
#   1. Service in IR will need to be in running state for this script to work.
#   2. Intranet port will need to be opened before registering with new auth key(This script does that automatically if the service in IR is in running state).

# Function Definitions

function Install-Gateway {

    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $path
    )

    process {
        # Check if SHIR is installed or not. If yes, don't install again
        if(Check-WhetherGatewayInstalled("Microsoft Integration Runtime"))
        {
            Write-Host "Microsoft Integration Runtime is already installed."
            return
        }
        # If not installed start installation
        Write-Host "Start Gateway installation"

        Start-Process -FilePath "msiexec.exe" -ArgumentList "/i `"$path`" /quiet /passive" -Wait
        Start-Sleep -Seconds 30 

        Write-Host "Succeed to install gateway"
    }
}

function Check-WhetherGatewayInstalled {

    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $name
    )

    process{
        
        # Check the uninstall software path in Registry to see if SHIR is installed or not.
        $installedSoftwares = Get-ChildItem "hklm:\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"
        foreach ($installedSoftware in $installedSoftwares)
        {          
            # DisplayName contains the name of the software
            $displayName = $installedSoftware.GetValue("DisplayName")
            if($DisplayName -eq "$name Preview" -or  $DisplayName -eq "$name")
            {
                return $true
            }
        }

        return $false
    }
}

# Get DiaCmdPath
function Get-CmdFilePath {
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param()

    process{
        # Use Registry to get the installed path of SHIR
        $filePath = Get-ItemPropertyValue "hklm:\Software\Microsoft\DataTransfer\DataManagementGateway\ConfigurationManager" "DiacmdPath" 
        if ([string]::IsNullOrEmpty($filePath))
        {
            throw "Failed: No installed IR found!"
        }

        return $filePath
    }
}

# Register/Re-register IR
function Register-IR {
    
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $key
    )

    process {
        Write-Host "Start to register IR with key: $key"

        $cmd = Get-CmdFilePath

        # Get directory path and parent directory path
        $directoryPath = Split-Path -Path $cmd
        $parentDirPath = Split-Path -Path $directoryPath

        $dmgCmdPath = "$directoryPath\dmgcmd.exe"
        $regIRScriptPath = "$parentDirPath\PowerShellScript\RegisterIntegrationRuntime.ps1"

        # Open Intranet Port (Necessary for Re-Register. Service has to be running for Re-Register to work.)
        Start-Process $dmgCmdPath "-EnableRemoteAccess 8060" -Wait

        # Register/ Re-register IR (6>&1 is used to capture the output of script)
        $result = & $regIRScriptPath -gatewayKey $key 6>&1
        if($result.ToString().Contains("successful"))
        {
            Write-Host $result;
            return $true;
        }
        else
        {
            throw $result;
        }
    }
}

# Validate script input params
function Validate-Input {
    [Microsoft.Azure.PowerShell.Cmdlets.DataMigration.DoNotExportAttribute()] 
    param(
        [Parameter(Mandatory=$true)]
        [System.String]
        $key
    )

    process {
        
        if ([string]::IsNullOrEmpty($key))
        {
            throw "Failed: IR Auth key is empty"
        }
    }
}

