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
    Tests upgrading a server with result from upgrade hint cmdlet
#>
function Test-ServerUpgradeWithUpgradeHint
{
    # Setup
    $server = Create-ServerForServerUpgradeTest
    
    # Create a basic database
    $databaseName = Get-DatabaseName
    $database = New-AzureRmSqlDatabase -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition Basic -MaxSizeBytes 1GB
    Assert-AreEqual $database.DatabaseName $databaseName

    try
    {
        $mapping = Get-AzureRmSqlServerUpgradeHint -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName

        Start-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -ServerVersion 12.0 -ScheduleUpgradeAfterUtcDateTime ((Get-Date).AddMinutes(1).ToUniversalTime()) -DatabaseCollection $mapping.Databases -ElasticPoolCollection $hint.ElasticPools

        while ($true)
        {
            $upgrade = Get-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName
            if ($upgrade.Status -eq "Completed")
            {
                # Upgrade is successful
                $server = Get-AzureRmSqlServer -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName
                Assert-AreEqual $server.ServerVersion "12.0"
                break
            }
            elseif ($upgrade.Status -eq "Stopped")
            {
                # Upgrade failed
                $server = Get-AzureRmSqlServer -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName
                Assert-AreEqual $server.ServerVersion "2.0"
                break
            }
            Wait-Seconds 10
        }
    }
    finally
    {
        Remove-AzureRmResourceGroup -Name $server.ResourceGroupName -Force
    }
}

<#
    .SYNOPSIS
    Tests upgrading a server and then cancel the upgrade
#>
function Test-ServerUpgradeAndCancel
{
    # Setup
    $server = Create-ServerForServerUpgradeTest

    try
    {
        Start-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -ServerVersion 12.0

        $upgrade = Get-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName
        Assert-AreEqual $upgrade.Status "Queued"

        Stop-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -Force
        
        $upgrade = Get-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName
        Assert-AreEqual $upgrade.Status "Cancelling"

        while ($true)
        {
            $upgrade = Get-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName
            if ($upgrade.Status -eq "Stopped")
            {
                break
            }
            Wait-Seconds 10
        }

        # Upgrade is cancelled
        $server = Get-AzureRmSqlServer -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName
        Assert-AreEqual $server.ServerVersion "2.0"
    }
    finally
    {
        Remove-AzureRmResourceGroup -Name $server.ResourceGroupName -Force
    }
}

<#
    .SYNOPSIS
    Tests upgrading a server with invalid parameters
#>
function Test-ServerUpgradeNegative
{
    # Setup
    $server = Create-ServerForServerUpgradeTest

    # Create a basic database
    $databaseName = Get-DatabaseName
    $database = New-AzureRmSqlDatabase -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -DatabaseName $databaseName -Edition Basic -MaxSizeBytes 1GB
    Assert-AreEqual $database.DatabaseName $databaseName

    try
    {
        Assert-Throws { Start-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName }
        Assert-Throws { Start-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -ServerVersion 13.0}
        Assert-Throws { Start-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -ScheduleUpgradeAfterUtcDateTime ((Get-Date).ToUniversalTime())}

        $recommendedDatabase = New-Object -TypeName Microsoft.Azure.Management.Sql.Models.RecommendedDatabaseProperties
        $recommendedDatabase.Name = databaseName
        $recommendedDatabase.TargetEdition = "InvalidEdition"
        $recommendedDatabase.TargetServiceLevelObjective = "S0"
        Assert-Throws { Start-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -DatabaseCollection ($recommendedDatabase)}

        $recommendedDatabase.TargetEdition = "Premium"
        $recommendedDatabase.TargetServiceLevelObjective = "S0"
        Assert-Throws { Start-AzureRmSqlServerUpgrade -ResourceGroupName $server.ResourceGroupName -ServerName $server.ServerName -DatabaseCollection ($recommendedDatabase)}
    }
    finally
    {
        Remove-AzureRmResourceGroup -Name $server.ResourceGroupName -Force
    }
}

<#
    .SYNOPSIS
    Creates a resource group and server for server upgrade tests
#>
function Create-ServerForServerUpgradeTest()
{
    $location = "West US"
    $rgName = Get-ResourceGroupName

    $rg = New-AzureRmResourceGroup -Name $rgName -Location $location

    $serverName = Get-ServerName
    $version = "2.0"
    $serverLogin = "testusername"
    $serverPassword = "t357ingP@s5w0rd!"
    $credentials = New-Object System.Management.Automation.PSCredential($serverLogin, ($serverPassword | ConvertTo-SecureString -asPlainText -Force)) 

    $server = New-AzureRmSqlServer -ResourceGroupName  $rgName -ServerName $serverName -Location $location -ServerVersion $version -SqlAdministratorCredentials $credentials
    return $server
}