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

# Loads Microsoft.WindowsAzure.Commands module
# Selects a subscription id to be used by the test

function Init-TestEnvironment
{
    $DebugPreference = "Continue"
    $ErrorActionPreference = "Continue"
    $FormatEnumerationLimit = 10000
    $ProgressPreference = "SilentlyContinue"
    $VerbosePreference = "SilentlyContinue"
    $WarningPreference = "Continue"
    $WhatIfPreference = $false

    # Setting to continue because WA sets a bunch of aliases which ask for 
    # confirmation when running the functional tests.
    $ConfirmPreference = "Continue"
    #$moduleLoaded = Get-Module -Name "Microsoft.WindowsAzure.Commands"
    if(!$moduleLoaded)
    {
        Import-Module .\Azure.psd1
    }
    $ConfirmPreference = "Medium"
}

function Init-AzureSubscription
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [ValidateNotNullOrEmpty()]
        [String]
        $SubscriptionID,
        [Parameter(Mandatory=$true, Position=1)]
        [ValidateNotNullOrEmpty()]
        [String]
        $SerializedCert,
        [Parameter(Mandatory=$false, Position=2)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ServiceEndpoint
    )
    # Deserialize the input certificate given in base 64 format.
    # Install it in the cert store.
    $storeName = [System.Security.Cryptography.X509Certificates.StoreName]
    $storeLocation = [System.Security.Cryptography.X509Certificates.StoreLocation]
    $X509Certificate2 = [System.Security.Cryptography.X509Certificates.X509Certificate2]
    $X509Store = [System.Security.Cryptography.X509Certificates.X509Store]
    $OpenFlags = [System.Security.Cryptography.X509Certificates.OpenFlags]
    
    $bytes = [System.Convert]::FromBase64String($SerializedCert)
    $myCert = New-Object $X509Certificate2(,$bytes)
    $store = New-Object $X509Store($StoreName::My, $StoreLocation::CurrentUser)
    $store.Open($OpenFlags::ReadWrite)
    if($store.Certificates.Contains($myCert) -ne $true)
    {
        $store.Add($myCert)
    }
    $store.Close()
    
    $subName = "MySub" + $SubscriptionID
	
    if($ServiceEndpoint)
    {
        Set-AzureSubscription -SubscriptionName $subName -SubscriptionId $SubscriptionID -Certificate $myCert `
            -ServiceEndpoint $ServiceEndpoint
    }
    else
    {
        Set-AzureSubscription -SubscriptionName $subName -SubscriptionId $SubscriptionID -Certificate $myCert `
            -ServiceEndpoint "https://management.core.windows.net"
    }
	
    Select-AzureSubscription -SubscriptionName $subName
}

function Get-ServerContextByManageUrlWithSqlAuth
{
	[CmdletBinding()]
	param
	(
		[Parameter(Mandatory=$true, Position=0)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ManageUrl,

		[Parameter(Mandatory=$true, Position=1)]
        [ValidateNotNullOrEmpty()]
        [String]
        $UserName,

		[Parameter(Mandatory=$true, Position=2)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Password
	)
    $securePassword = ConvertTo-SecureString $Password -AsPlainText -Force
    $credential = New-Object System.Management.Automation.PSCredential ($UserName, $securePassword)
    
    $context = New-AzureSqlDatabaseServerContext -ManageUrl $ManageUrl -Credential $credential
    return $context
}

function Get-ServerContextByServerNameWithCertAuth
{
    [CmdletBinding()]
    param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ServerName
    )
    
    $context = New-AzureSqlDatabaseServerContext -ServerName $ServerName -UseSubscription
    return $context
}

function Assert 
{
    #.Example
    # set-content C:\test2\Documents\test2 "hi"
    # C:\PS>assert { get-item C:\test2\Documents\test2 } "File wasn't created by Set-Content!"
    #
    [CmdletBinding()]
    param( 
       [Parameter(Position=0,ParameterSetName="Script",Mandatory=$true)]
       [ScriptBlock]$Condition
    ,
       [Parameter(Position=0,ParameterSetName="Bool",Mandatory=$true)]
       [bool]$Success
    ,
       [Parameter(Position=1,Mandatory=$true)]
       [string]$Message
    )

    $message = "ASSERT FAILED: $message"
  
    if($PSCmdlet.ParameterSetName -eq "Script") 
    {
        try 
        {
            $ErrorActionPreference = "STOP"
            $success = &$condition
        } 
        catch 
        {
            $success = $false
            $message = "$message`nEXCEPTION THROWN: $($_.Exception.GetType().FullName)"         
        }
    }
    if(!$success) 
    {
        throw $message
    }
}

function Validate-SqlDatabaseServerOperationContext 
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Model.SqlDatabaseServerOperationContext]
        $Actual, 
        [Parameter(Mandatory=$true, Position=1)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedServerName,
        [Parameter(Mandatory=$true, Position=2)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedOperationDescription
    )
    
    $expectedOperationStatus = "Success"
    Assert {$actual} "SqlDatabaseServerOperationContext is null"
    Assert {$actual.ServerName -eq $expectedServerName} "ServerName didn't match. Actual:[$($actual.ServerName)] `
                expected:[$expectedServerName]"
    Assert {$actual.OperationDescription -eq $expectedOperationDescription} "OperationDescription didn't match. `
                Actual:[$($actual.OperationDescription)] expected:[$expectedOperationDescription]"
    Assert {$actual.OperationStatus -eq $expectedOperationStatus} "OperationStatus didn't match. `
                Actual:[$($actual.OperationStatus)] expected:[$expectedOperationStatus]"
}

function Validate-SqlDatabaseServerContext
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Model.SqlDatabaseServerContext]
        $Actual,
        [Parameter(Mandatory=$true, Position=1)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedAdministratorLogin,
        [Parameter(Mandatory=$true, Position=2)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedLocation,
        [Parameter(Mandatory=$true, Position=3)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedServerName,
        [Parameter(Mandatory=$true, Position=4)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedOperationDescription
    )

    Assert {$actual} "SqlDatabaseServerContext is null"
    Assert {$actual.AdministratorLogin -eq $ExpectedAdministratorLogin} "AdministratorLogin didn't match. `
                Actual:[$($actual.AdministratorLogin)] expected:[$ExpectedAdministratorLogin]"
    Assert {$actual.Location -eq $ExpectedLocation} "Location didn't match. Actual:[$($actual.Location)] `
                expected:[$ExpectedLocation]"
    Validate-SqlDatabaseServerOperationContext -Actual $actual -ExpectedServerName $ExpectedServerName `
                -ExpectedOperationDescription $ExpectedOperationDescription
}

function Validate-SqlDatabaseServerFirewallRuleContext
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Model.SqlDatabaseServerFirewallRuleContext]
        $Actual,
        [Parameter(Mandatory=$true, Position=1)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedRuleName,
        [Parameter(Mandatory=$true, Position=2)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedStartIpAddress,
        [Parameter(Mandatory=$true, Position=3)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedEndIpAddress,
        [Parameter(Mandatory=$true, Position=4)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedServerName,
        [Parameter(Mandatory=$true, Position=5)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedOperationDescription
    )

    Assert {$actual} "SqlDatabaseServerContext is null"
    Assert {$actual.RuleName -eq $ExpectedRuleName} "RuleName didn't match. Actual:[$($actual.RuleName)] 
            `expected:[$ExpectedRuleName]"
    Assert {$actual.StartIpAddress -eq $ExpectedStartIpAddress} "StartIpAddress didn't match. `
            Actual:[$($actual.StartIpAddress)] expected:[$ExpectedStartIpAddress]"
    Assert {$actual.EndIpAddress -eq $ExpectedEndIpAddress} "EndIpAddress didn't match. `
            Actual:[$($actual.EndIpAddress)] expected:[$ExpectedEndIpAddress]"
    Validate-SqlDatabaseServerOperationContext -Actual $actual -ExpectedServerName $ExpectedServerName `
            -ExpectedOperationDescription $ExpectedOperationDescription
}

function Validate-SqlDatabase
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server.Database]
        $Actual,
        [Parameter(Mandatory=$true, Position=1)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedName,
        [Parameter(Mandatory=$true, Position=2)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedCollationName,
        [Parameter(Mandatory=$true, Position=3)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedEdition,
        [Parameter(Mandatory=$true, Position=4)]
        [ValidateNotNullOrEmpty()]
        [String]
        $ExpectedMaxSizeGB,
        [Parameter(Mandatory=$true, Position=5)]
        [ValidateNotNullOrEmpty()]
        [bool]
        $ExpectedIsReadOnly,
        [Parameter(Mandatory=$true, Position=6)]
        [ValidateNotNullOrEmpty()]
        [bool]
        $ExpectedIsFederationRoot,
        [Parameter(Mandatory=$true, Position=7)]
        [ValidateNotNullOrEmpty()]
        [bool]
        $ExpectedIsSystemObject,
        [Parameter(Mandatory=$false, Position=8)]
        [ValidateNotNullOrEmpty()]
        [String]
        $Source
    )

    Assert {$actual} "SqlDatabaseServerContext is null"
    Assert {$actual.Name -eq $ExpectedName} "Database Name didn't match. Actual:[$($actual.Name)] `
            expected:[$ExpectedRuleName] | $Source"
    Assert {$actual.CollationName -eq $ExpectedCollationName} "CollationName didn't match. `
            Actual:[$($actual.CollationName)] expected:[$ExpectedCollationName] | $Source"
    Assert {$actual.Edition -eq $ExpectedEdition} "Edition didn't match. `
            Actual:[$($actual.Edition)] expected:[$ExpectedEdition] | $Source"
    Assert {$actual.MaxSizeGB -eq $ExpectedMaxSizeGB} "MaxSizeGB didn't match. `
            Actual:[$($actual.MaxSizeGB)] expected:[$ExpectedMaxSizeGB] | $Source"
    Assert {$actual.IsReadOnly -eq $ExpectedIsReadOnly} "IsReadOnly didn't match. `
            Actual:[$($actual.IsReadOnly)] expected:[$ExpectedIsReadOnly] | $Source"
    Assert {$actual.IsFederationRoot -eq $ExpectedIsFederationRoot} "IsFederationRoot didn't match. `
            Actual:[$($actual.IsFederationRoot)] expected:[$ExpectedIsFederationRoot] | $Source"
    Assert {$actual.IsSystemObject -eq $ExpectedIsSystemObject} "Edition didn't match. `
            Actual:[$($actual.IsSystemObject)] expected:[$ExpectedIsSystemObject] | $Source"
}

function Drop-Server
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Model.SqlDatabaseServerOperationContext]
        $Server
    )

    if($server)
    {
        # Drop server
        Write-Output "Dropping server $($server.ServerName) ..."
        Remove-AzureSqlDatabaseServer -ServerName $server.ServerName -Force
        Write-Output "Dropped server $($server.ServerName)"
    }
}

function Drop-Database
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server.IServerDataServiceContext]
        $Context,
        [Parameter(Mandatory=$true, Position=1)]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server.Database]
        $Database
    )

    if($Database)
    {
        # Drop Database
        Write-Output "Dropping database $($Database.Name) ..."
        Remove-AzureSqlDatabase -Context $context -InputObject $Database -Force
        Write-Output "Dropped database $($Database.Name)"
    }
}

function Drop-DatabaseWithServerName
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [string]
        $ServerName,
        [Parameter(Mandatory=$true, Position=1)]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server.Database]
        $Database
    )

    if($Database)
    {
        # Drop Database
        Write-Output "Dropping database $($Database.Name) ..."
        Remove-AzureSqlDatabase -ServerName $ServerName -InputObject $Database -Force
        Write-Output "Dropped database $($Database.Name)"
    }
}

function Drop-Databases
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server.IServerDataServiceContext]
        $Context,
        [Parameter(Mandatory=$true, Position=1)]
        [String]
        $NameStartsWith
    )

    # Drop Database
    Write-Output "Dropping databases with name starts with $NameStartsWith ..."
    Get-AzureSqlDatabase $context | Where-Object {$_.Name.StartsWith($NameStartsWith)} `
        | Remove-AzureSqlDatabase -Context $context -Force
    Write-Output "Dropped database with name starts with $NameStartsWith"
}

function Drop-DatabasesWithServerName
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [string]
        $ServerName,
        [Parameter(Mandatory=$true, Position=1)]
        [String]
        $NameStartsWith
    )

    # Drop Database
    Write-Output "Dropping databases with name starts with $NameStartsWith ..."
    (Get-AzureSqlDatabase $ServerName) | Where-Object {$_.Name.StartsWith($NameStartsWith)} `
                | Remove-AzureSqlDatabase -Force
    Write-Output "Dropped database with name starts with $NameStartsWith"
}

function Write-TestResult
{
    [CmdletBinding()]
    Param
    (
        [Parameter(Mandatory=$true, Position=0)]
        [bool]
        $TestResult
    )

    if($IsTestPass)
    {
        Write-Output "PASS"
    }
    else
    {
        Write-Output "FAILED"
    }
}
