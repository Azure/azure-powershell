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

.".\Scaffolding.ps1"

function Get-Address
{
    param([array] $lines)
    Write-Log $lines
    foreach ($hardline in $lines)
    {
         Write-Log $hardline
        if ($hardline.indexOf('http:') -gt 0)
        {
            $outputlines = $hardline.split("`r`n")
            Write-Log $outputlines
            foreach($line in $outputlines)
            {
                Write-Log $line
                $start = $line.indexOf('http://')
                if ($start -gt 0)
                {
                   return ($line.substring($start))
                }
            }
        }
    }

    throw "Unable to determine service address"
}

function Test-NodeHelloInEmulator
{
    Stop-AzureEmulator
    $loc = Get-Location
    Create-NodeBaseService "myNodeService"
    try
    {
	    $info = Start-AzureEmulator
        Write-Log "Emulator output: $info"
        $address = Get-Address $info
        Write-Log "Using service address '$address'"
	    Dump-Document $address
    }
    finally
    {
	    Set-Location $loc
	    Stop-AzureEmulator
	    rm -Recurse ".\myNodeService"
    }
}

function Test-PHPHelloInEmulator
{
    Stop-AzureEmulator
    $loc = Get-Location
    Create-PHPWebService "myPHPService"
    try
    {
	    $info = Start-AzureEmulator
        Write-Log "Emulator output: $info"
        $address = Get-Address $info
        Write-Log "Using service address '$address'"
	    Dump-Document $address
    }
    finally
    {
	    Set-Location $loc
	    Stop-AzureEmulator
	    rm -Recurse ".\myPHPService"
    }
}

function Test-NodeServiceCreation
{
    $loc = Get-Location
    Create-NodeBaseService "myNodeService01"
	Set-Location $loc
    rm -Recurse ".\myNodeService01"
}

function Test-PHPServiceCreation
{
    $loc = Get-Location
    Create-PHPBaseService "myPHPService01"
	Set-Location $loc
	rm -Recurse ".\myPHPService01"
}