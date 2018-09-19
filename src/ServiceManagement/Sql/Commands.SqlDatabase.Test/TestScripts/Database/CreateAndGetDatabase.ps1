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
    $Name,
    [Parameter(Mandatory=$true, Position=1)]
    [ValidateNotNullOrEmpty()]
    [string]
    $ManageUrl,
    [Parameter(Mandatory=$true, Position=2)]
    [ValidateNotNullOrEmpty()]
    [string]
    $UserName,
    [Parameter(Mandatory=$true, Position=3)]
    [ValidateNotNullOrEmpty()]
    [string]
    $Password,
    [Parameter(Mandatory=$true, Position=1)]
    [ValidateNotNullOrEmpty()]
    [string]
    $ServerName,
    [Parameter(Mandatory=$true, Position=2)]
    [ValidateNotNullOrEmpty()]
    [string]
    $SubscriptionID,
    [Parameter(Mandatory=$true, Position=3)]
    [ValidateNotNullOrEmpty()]
    [string]
    $SerializedCert,
    [Parameter(Mandatory=$true, Position=4)]
    [ValidateNotNullOrEmpty()]
    [string]
    $Endpoint
)

$IsTestPass = $False

Write-Output "`$Name=$Name"
Write-Output "`$ManageUrl=$ManageUrl"
Write-Output "`$UserName=$UserName"
Write-Output "`$Password=$Password"
Write-Output "`$ServerName=$ServerName"
Write-Output "`$SubscriptionID=$SubscriptionID"
Write-Output "`$SerializedCert=$SerializedCert"
Write-Output "`$Endpoint=$Endpoint"
$NameStartWith = $Name

. .\Database\CreateAndGetDatabase-ScenarioFunctions.ps1
. .\CommonFunctions.ps1

Try
{
    Init-TestEnvironment
    
    $database = $null
    $database2 = $null
    $defaultCollation = "SQL_Latin1_General_CP1_CI_AS"
    $defaultEdition = "Web"
    $defaultMaxSizeGB = "1"
    $defaultIsReadOnly = $false
    $defaultIsFederationRoot = $false
    $defaultIsSystemObject = $false

    # Using Sql Auth
    try
    {    
        Write-Output "Test 1: Using Sql Auth"

        $context = Get-ServerContextByManageUrlWithSqlAuth -ManageUrl $ManageUrl -UserName $UserName -Password $Password

        Scenerio1-CreateWithRequiredParameters -Context $context
    
        Scenerio2-CreateWithOptionalParameters -Context $context
    }
    finally
    {
        # Drop Database
        Drop-Databases $Context $NameStartWith
    }
    
    # Using Cert Auth
    try
    {    
        Write-Output "Test 2: Using Cert Auth"

        Init-AzureSubscription $SubscriptionId $SerializedCert $Endpoint
        $sub = Get-AzureSubscription -Current

        $context = Get-ServerContextByServerNameWithCertAuth $ServerName
        Scenerio1-CreateWithRequiredParameters -Context $context
    
        Scenerio2-CreateWithOptionalParameters -Context $context
    }
    finally
    {
        # Drop Database
        Drop-Databases $Context $NameStartWith
        Remove-AzureSubscription $sub.SubscriptionName -Force
    }

    # Using Cert Auth with server name
    try
    {    
        Write-Output "Test 3: Using Cert Auth with Server Name"

        Init-AzureSubscription $SubscriptionId $SerializedCert $Endpoint
        $sub = Get-AzureSubscription -Current

        Scenerio1-CreateWithRequiredParameters -ServerName $ServerName
    
        Scenerio2-CreateWithOptionalParameters -ServerName $ServerName
    
    }
    finally
    {
        # Drop Database
        Drop-Databases $Context $NameStartWith
        Remove-AzureSubscription $sub.SubscriptionName -Force
    }

    $IsTestPass = $True
}
Finally
{
    Drop-Databases $Context $NameStartWith
}

Write-TestResult $IsTestPass


