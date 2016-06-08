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

[CmdletBinding()]
Param
(
    [Parameter(Mandatory=$true, Position=0)]
    [ValidateNotNullOrEmpty()]
    [string]
    $subscriptionID, 
    [Parameter(Mandatory=$true, Position=1)]
    [ValidateNotNullOrEmpty()]
    [String]
    $SerializedCert,
    [Parameter(Mandatory=$true, Position=2)]
    [ValidateNotNullOrEmpty()]
    [String]
    $serverLocation,
    [Parameter(Mandatory=$true, Position=3)]
    [ValidateNotNullOrEmpty()]
    [String]
    $OutputFile
)
Write-Output "`$subscriptionID=$subscriptionID"
Write-Output "`$SerializedCert=$SerializedCert"
Write-Output "`$serverLocation=$serverLocation"
Write-Output "`$OutputFile=$OutputFile"

. .\CommonFunctions.ps1

Try
{
    Init-TestEnvironment
    Init-AzureSubscription -subscriptionID $subscriptionID -SerializedCert $SerializedCert
    $isTestPass = $False
    
    # Get SqlDatabaseOperationContext format
    $SqlDatabaseOperationContext = New-AzureSqlDatabaseServer -AdministratorLogin "mylogin1" `
                                        -AdministratorLoginPassword "Sql@zure1" -Location $serverLocation
    $server = $SqlDatabaseOperationContext
    
    # Get SqlDatabaseServerContext format
    $SqlDatabaseServerContext = Get-AzureSqlDatabaseServer $server.ServerName
    
    # Get SqlDatabaseFirewallRuleContext format
    $SqlDatabaseFirewallRuleContext = New-AzureSqlDatabaseServerFirewallRule $server.ServerName `
                                        -RuleName "test" -StartIpAddress "1.0.0.0" -EndIpAddress "2.0.0.0"
    
    # write the dynamic content in comma separated line
    "$ServerLocation#$($SqlDatabaseOperationContext.ServerName)"  > $OutputFile
    
    # write output object to output file
    $SqlDatabaseOperationContext.GetType().Name >> $OutputFile
    $SqlDatabaseOperationContext | ft -Wrap -AutoSize >> $OutputFile
    $SqlDatabaseOperationContext | fl >> $OutputFile

    $SqlDatabaseServerContext.GetType().Name >> $OutputFile
    $SqlDatabaseServerContext | ft -Wrap -AutoSize >> $OutputFile
    $SqlDatabaseServerContext | fl >> $OutputFile

    $SqlDatabaseFirewallRuleContext.GetType().Name >> $OutputFile
    $SqlDatabaseFirewallRuleContext | ft -Wrap -AutoSize >> $OutputFile
    $SqlDatabaseFirewallRuleContext | fl >> $OutputFile
    
    $isTestPass = $True
}
Finally
{
    Drop-Server $server
    Write-TestResult $IsTestPass
}

