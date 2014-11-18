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

$scriptFolder = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
. ($scriptFolder + '.\SetupEnv.ps1')

try {
  git.exe| Out-Null
}
catch [System.Management.Automation.CommandNotFoundException] {
    if (Test-Path "$env:ADXSDKProgramFiles\Git\bin") {
        Write-Host Adding Git installation folder to the PATH environment variable, needed for some unit tests.
        $env:path = $env:path + ";$env:ADXSDKProgramFiles\Git\bin"
    }
}

#The detecting logic for django is not decent, but the best we can do so far.    
if (!(Test-Path "$env:SystemDrive\Python27")) {
    Write-Host "download Python, Pip and Django to $tempFileShare"
    $tempFileShare = $env:temp
    $client = New-Object System.Net.WebClient
    $client.DownloadFile("https://www.python.org/ftp/python/2.7.5/python-2.7.5.msi", "$tempFileShare\python-2.7.5.msi")
    $client.DownloadFile("https://raw.github.com/pypa/pip/master/contrib/get-pip.py", "$tempFileShare\get-pip.py");        
    Write-Host "Install..."
    Start-Process msiexec.exe "/i $tempFileShare\python-2.7.5.msi /passive" -Wait
    Start-Process "$env:SystemDrive\Python27\python.exe" "$tempFileShare\get-pip.py" -Wait
    Start-Process "$env:SystemDrive\Python27\scripts\pip.exe" "install Django==1.5" -Wait
    Remove-Item "$tempFileShare\python-2.7.5.msi"
    Remove-Item "$tempFileShare\get-pip.py"
}

$env:AZURE_TEST_MODE="Playback"
