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
    [Parameter(Mandatory=$true, Position=1)]
    [ValidateNotNullOrEmpty()]
    [Uri]
    $ManageUrl,
    [Parameter(Mandatory=$true, Position=2)]
    [ValidateNotNullOrEmpty()]
    [string]
    $UserName,
    [Parameter(Mandatory=$true, Position=3)]
    [ValidateNotNullOrEmpty()]
    [string]
    $Password,
    [Parameter(Mandatory=$true, Position=4)]
    [ValidateNotNullOrEmpty()]
    [string]
    $SubscriptionID,
    [Parameter(Mandatory=$true, Position=5)]
    [ValidateNotNullOrEmpty()]
    [string]
    $SerializedCert
)

# Assuming $ManageUrl is in the following format: https://servername.domainname.com/
$FQSN = $ManageUrl.Host
$ServerName = $FQSN.Split('.')[0]

Write-Output "`$ManageUrl=$ManageUrl"
Write-Output "`$FQSN=$FQSN"
Write-Output "`$ServerName=$ServerName"
Write-Output "`$UserName=$UserName"
Write-Output "`$Password=$Password"
. .\CommonFunctions.ps1

Try
{
    Init-TestEnvironment
    Init-AzureSubscription $SubscriptionId $SerializedCert
    $sub = Get-AzureSubscription -Current

    $IsTestPass = $False

    ###############################################################################
    #	Test the connection context creation using the current subscription
    ###############################################################################
    # Test ByManageUrlWithCertAuth with Optional Parameters
    $context = New-AzureSqlDatabaseServerContext -ServerName $ServerName -UseSubscription
    Assert {$context.ServerName -eq $ServerName} `
        "Server name does not match. Actual:[$($context.ServerName)] expected:[$ServerName]"

    # Test ByFullyQualifiedServerNameWithCertAuth
    $context = New-AzureSqlDatabaseServerContext -FullyQualifiedServerName $FQSN -UseSubscription
    Assert {$context.ServerName -eq $ServerName} `
        "Server name does not match. Actual:[$($context.ServerName)] expected:[$ServerName]"

    Remove-AzureSubscription $sub.SubscriptionName -Force

    ###############################################################################
    #	Test the connection context creation using subscription data
    ###############################################################################
    # Test ByManageUrlWithCertAuth with Optional Parameters
    $context = New-AzureSqlDatabaseServerContext -ServerName $ServerName `
        -UseSubscription -SubscriptionName $sub.SubscriptionName
    Assert {$context.ServerName -eq $ServerName} `
        "Server name does not match. Actual:[$($context.ServerName)] expected:[$ServerName]"

    # Test ByFullyQualifiedServerNameWithCertAuth
    $context = New-AzureSqlDatabaseServerContext -FullyQualifiedServerName $FQSN `
        -UseSubscription -SubscriptionName $sub.SubscriptionName
    Assert {$context.ServerName -eq $ServerName} `
        "Server name does not match. Actual:[$($context.ServerName)] expected:[$ServerName]"
    
    ###############################################################################
    #	Test the connection context creation using sql authentication
    ###############################################################################
    $securePassword = ConvertTo-SecureString $Password -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential ($UserName, $securePassword)

    # Test ByManageUrlWithSqlAuth
    $context = New-AzureSqlDatabaseServerContext -ManageUrl $ManageUrl -Credential $credential
    Assert {$context.ServerName -eq $ServerName} `
        "Server name does not match. Actual:[$($context.ServerName)] expected:[$ServerName]"
    
    # Test ByManageUrlWithSqlAuth with Optional Parameters
    $context = New-AzureSqlDatabaseServerContext -ManageUrl $ManageUrl `
        -Credential $credential -ServerName $ServerName
    Assert {$context.ServerName -eq $ServerName} `
        "Server name does not match. Actual:[$($context.ServerName)] expected:[$ServerName]"

    # Test ByFullyQualifiedServerNameWithSqlAuth
    $context = New-AzureSqlDatabaseServerContext -FullyQualifiedServerName $FQSN -Credential $credential
    Assert {$context.ServerName -eq $ServerName} `
        "Server name does not match. Actual:[$($context.ServerName)] expected:[$ServerName]"

    If ($ManageUrl.Host.EndsWith(".database.windows.net", [StringComparison]::InvariantCultureIgnoreCase))
    {
        # Test ByServerNameWithSqlAuth iff the ManageUrl specified is a production server
        $context = New-AzureSqlDatabaseServerContext -ServerName $ServerName -Credential $credential
        Assert {$context.ServerName -eq $ServerName} `
            "Server name does not match. Actual:[$($context.ServerName)] expected:[$ServerName]"
    }
    
    $IsTestPass = $True
}
Finally
{
    Write-TestResult $IsTestPass
}
