<#
The MIT License (MIT)

Copyright (c) 2017 Microsoft

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
#>

Import-Module -Name (Join-Path -Path $PSScriptRoot -ChildPath .. | Join-Path -ChildPath .. | Join-Path -ChildPath "GeneratedHelpers.psm1")
<#
.DESCRIPTION
    Create an ip pool.

.PARAMETER StartIpAddress
    The starting Ip address.

.PARAMETER EndIpAddress
    The ending Ip address.

.PARAMETER AddressPrefix
    The address prefix.

.PARAMETER Pool
    Ip pool object to send.

.PARAMETER IpPool
    Ip pool name.

.PARAMETER Location
    Location of the resource.

.EXAMPLE

New-AzsIpPool -Location "local" -StartIpAddress "100.10.20.30" -AddressPrefix "100.10.20.30/24" -IpPool "MyTestIpPool" -EndIpAddress "100.10.20.130"

NumberOfIpAddressesInTransition StartIpAddress  Type                                           AddressPrefix NumberOfIpAddresses
0                               100.10.20.30   Microsoft.Fabric.Admin/fabricLocations/ipPools               100

#>
function New-IpPool
{
    [OutputType([Microsoft.AzureStack.Management.Fabric.Admin.Models.IpPool])]
    [CmdletBinding(DefaultParameterSetName='IpPools_Create')]
    param(
        [Parameter(Mandatory = $true, ParameterSetName = 'IpPools_Create')]
        [System.String]
        $StartIpAddress,
        
        [Parameter(Mandatory = $true, ParameterSetName = 'IpPools_Create')]
        [System.String]
        $AddressPrefix,

        [Parameter(Mandatory = $true, ParameterSetName = 'IpPools_Create')]
        [System.String]
        $IpPool,

        [Parameter(Mandatory = $true, ParameterSetName = 'IpPools_Create')]
        [System.String]
        $EndIpAddress,
    
        [Parameter(Mandatory = $true, ParameterSetName = 'IpPools_Create')]
        [System.String]
        $Location
    )

    Begin 
    {
	}

    Process {
    
    $ErrorActionPreference = 'Stop'
    

    $Pool = New-Object -TypeName Microsoft.AzureStack.Management.Fabric.Admin.Models.IpPool
    
        $PSBoundParameters.GetEnumerator() | ForEach-Object { 
            if(Get-Member -InputObject $Pool -Name $_.Key -MemberType Property)
            {
                $Pool.$($_.Key) = $_.Value
            }
        }
    
        if(Get-Member -InputObject $Pool -Name Validate -MemberType Method)
        {
            $Pool.Validate()
        }

    $FabricAdminClient = Get-ServiceClient

    if ('IpPools_Create' -eq $PsCmdlet.ParameterSetName) {
        Write-Verbose -Message 'Performing operation CreateWithHttpMessagesAsync on $FabricAdminClient.'
        $taskResult = $FabricAdminClient.IpPools.CreateWithHttpMessagesAsync($Location, $IpPool, $Pool)
    } else {
        Write-Verbose -Message 'Failed to map parameter set to operation method.'
        throw 'Module failed to find operation to execute.'
    }

    if ($TaskResult) {
        $result = $null
        $ErrorActionPreference = 'Stop'
                    
        $null = $taskResult.AsyncWaitHandle.WaitOne()
                    
        Write-Debug -Message "$($taskResult | Out-String)"

        if($taskResult.IsFaulted)
        {
            Write-Verbose -Message 'Operation failed.'
            Throw "$($taskResult.Exception.InnerExceptions | Out-String)"
        } 
        elseif ($taskResult.IsCanceled)
        {
            Write-Verbose -Message 'Operation got cancelled.'
            Throw 'Operation got cancelled.'
        }
        else
        {
            Write-Verbose -Message 'Operation completed successfully.'

            if($taskResult.Result -and
                (Get-Member -InputObject $taskResult.Result -Name 'Body') -and
                $taskResult.Result.Body)
            {
                $result = $taskResult.Result.Body
                Write-Debug -Message "$($result | Out-String)"
                $result
            }
        }
        
    }
    }

    End {
    }
}
