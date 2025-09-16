function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $SqlMigrationServiceTestVariables = @{
        GroupName = "tsum38RG"
        SqlMigrationServiceName = "trialTD"
    }
    $RemoveNode = @{
        GroupName = "tsum38RG"
        SqlMigrationServiceName = "dms20211030"
    }
    $randomstring = RandomString -allChars $false -len 10
    $newSqlMigrationServiceName = "new-testing-sqlmigrationservice-" +  $randomstring
    $NewSqlMigrationServiceTestVariables = @{
        GroupName = "tsum38RG"
        SqlMigrationServiceName = $newSqlMigrationServiceName
        Location = "eastus"
    }
    $AuthKeyTestVariables = @{
        GroupName = "tsum38RG"
        SqlMigrationServiceName = "alias-dms"
    }
    $DatabaseMigrationTestVariablesMi = @{
        ResourceGroupName = "MigrationTesting"
        ManagedInstanceName = "migrationtestmi"
        TargetDbName = "discMiOn"
    }
    $DatabaseMigrationTestVariablesVm = @{
        ResourceGroupName = "tsum38RG"
        SqlVirtualMachineName = "unitTest"
        TargetDbName = "unitTestVm"
    }
    $DatabaseMigrationTestVariablesDb = @{
        ResourceGroupName = "tsum38RG"
        SqlDbInstanceName = "dmstestsqldb"
        TargetDbName = "at_sqldbtrgt3"
    }
    $newDatabaseMigrationNameMi = "MiUnitTest" + $randomstring
    $NewDatabaseMigrationTestVariablesMi = @{
        ResourceGroupName = "migrationTesting"
        ManagedInstanceName = "migrationtestmi"
        TargetDbName = $newDatabaseMigrationNameMi
        Kind = "SqlMi"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/MigrationTesting/providers/Microsoft.Sql/managedInstances/migrationtestmi"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.DataMigration/SqlMigrationServices/alias"
        TargetLocationStorageAccountResourceId = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/aaskhan/providers/Microsoft.Storage/storageAccounts/aasimmigrationtest"
        TargetLocationAccountKey = "accountKey"
        FileSharePath = "\\sampledomain.onmicrosoft.com\SharedBackup\tsuman"
        FileShareUsername = "domainUserName"
        FileSharePassword = "password"
        SourceSqlConnectionAuthentication = "SqlAuthentication"
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com"
        SourceSqlConnectionUserName = "domainUserName"
        SourceSqlConnectionPassword = "password"
        SourceDatabaseName = "AdventureWorks"
    }
    $newDatabaseMigrationNameVm = "VmUnitTest" + $randomstring
    $NewDatabaseMigrationTestVariablesVm = @{
        ResourceGroupName = "tsum38RG"
        SqlVirtualMachineName = "unitTest"
        TargetDbName = $newDatabaseMigrationNameVm
        Kind = "SqlVm"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/unitTest"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.DataMigration/SqlMigrationServices/alias"
        TargetLocationStorageAccountResourceId = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/aaskhan/providers/Microsoft.Storage/storageAccounts/aasimmigrationtest"
        TargetLocationAccountKey = "accountKey"
        FileSharePath = "\\sampledomain.onmicrosoft.com\SharedBackup\tsuman"
        FileShareUsername = "domainUserName"
        FileSharePassword = "password"
        SourceSqlConnectionAuthentication = "SqlAuthentication"
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com"
        SourceSqlConnectionUserName = "domainUserName"
        SourceSqlConnectionPassword = "password"
        SourceDatabaseName = "AdventureWorks"
    }

    $NewDatabaseMigrationTestVariablesDb = @{
        ResourceGroupName = "tsum38RG"
        SqlDbInstanceName = "dmstestsqldb"
        TargetDbName = "at_sqldbtrgt3"
        Kind = "SqlDb"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.Sql/servers/dmstestsqldb"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.DataMigration/SqlMigrationServices/dms20211030"
        TargetSqlConnectionAuthentication = "SqlAuthentication"
        TargetSqlConnectionDataSource = "db.windows.net"
        TargetSqlConnectionPassword = "password"
        TargetSqlConnectionUserName = "username"
        SourceSqlConnectionAuthentication = "SqlAuthentication"
        SourceSqlConnectionDataSource = "sampledomain.microsoft.com"
        SourceSqlConnectionUserName = "user"
        SourceSqlConnectionPassword = "password"
        SourceDatabaseName = "AdventureWorks"
    }
    $cutDatabaseMigrationNameMi = "MiUnitTestCut" + $randomstring
    $CutDatabaseMigrationTestVariablesMi = @{
        ResourceGroupName = "migrationTesting"
        ManagedInstanceName = "migrationtestmi"
        TargetDbName = $cutDatabaseMigrationNameMi
        Kind = "SqlMi"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/MigrationTesting/providers/Microsoft.Sql/managedInstances/migrationtestmi"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.DataMigration/SqlMigrationServices/alias"
        TargetLocationStorageAccountResourceId = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/aaskhan/providers/Microsoft.Storage/storageAccounts/aasimmigrationtest"
        TargetLocationAccountKey = "accountKey"
        FileSharePath = "\\sampledomain.onmicrosoft.com\SharedBackup\tsuman"
        FileShareUsername = "domainUserName"
        FileSharePassword = "password"
        SourceSqlConnectionAuthentication = "SqlAuthentication"
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com"
        SourceSqlConnectionUserName = "domainUserName"
        SourceSqlConnectionPassword = "password"
        SourceDatabaseName = "AdventureWorks"
    }
    $cutDatabaseMigrationNameVm = "VmUnitTestCut" + $randomstring
    $CutDatabaseMigrationTestVariablesVm = @{
        ResourceGroupName = "tsum38RG"
        SqlVirtualMachineName = "unitTest"
        TargetDbName = $cutDatabaseMigrationNameVm
        Kind = "SqlVm"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/unitTest"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.DataMigration/SqlMigrationServices/alias"
        TargetLocationStorageAccountResourceId = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/aaskhan/providers/Microsoft.Storage/storageAccounts/aasimmigrationtest"
        TargetLocationAccountKey = "accountKey"
        FileSharePath = "\\sampledomain.onmicrosoft.com\SharedBackup\tsuman"
        FileShareUsername = "domainUserName"
        FileSharePassword = "password"
        SourceSqlConnectionAuthentication = "SqlAuthentication"
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com"
        SourceSqlConnectionUserName = "domainUserName"
        SourceSqlConnectionPassword = "password"
        SourceDatabaseName = "AdventureWorks"
    }
    $stopDatabaseMigrationNameMi = "MiUnitTestStop" + $randomstring
    $StopDatabaseMigrationTestVariablesMi = @{
        ResourceGroupName = "migrationTesting"
        ManagedInstanceName = "migrationtestmi"
        TargetDbName = $stopDatabaseMigrationNameMi
        Kind = "SqlMi"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/MigrationTesting/providers/Microsoft.Sql/managedInstances/migrationtestmi"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.DataMigration/SqlMigrationServices/alias"
        TargetLocationStorageAccountResourceId = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/aaskhan/providers/Microsoft.Storage/storageAccounts/aasimmigrationtest"
        TargetLocationAccountKey = "accountKey"
        FileSharePath = "\\sampledomain.onmicrosoft.com\SharedBackup\tsuman"
        FileShareUsername = "domainUserName"
        FileSharePassword = "password"
        SourceSqlConnectionAuthentication = "SqlAuthentication"
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com"
        SourceSqlConnectionUserName = "domainUserName"
        SourceSqlConnectionPassword = "password"
        SourceDatabaseName = "AdventureWorks"
    }
    $stopDatabaseMigrationNameVm = "VmUnitTestStop" + $randomstring
    $StopDatabaseMigrationTestVariablesVm = @{
        ResourceGroupName = "tsum38RG"
        SqlVirtualMachineName = "unitTest"
        TargetDbName = $stopDatabaseMigrationNameVm
        Kind = "SqlVm"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.SqlVirtualMachine/sqlVirtualMachines/unitTest"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.DataMigration/SqlMigrationServices/alias"
        TargetLocationStorageAccountResourceId = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/aaskhan/providers/Microsoft.Storage/storageAccounts/aasimmigrationtest"
        TargetLocationAccountKey = "accountKey"
        FileSharePath = "\\sampledomain.onmicrosoft.com\SharedBackup\tsuman"
        FileShareUsername = "domainUserName"
        FileSharePassword = "password"
        SourceSqlConnectionAuthentication = "SqlAuthentication"
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com"
        SourceSqlConnectionUserName = "domainUserName"
        SourceSqlConnectionPassword = "password"
        SourceDatabaseName = "AdventureWorks"
    }

    $StopDatabaseMigrationTestVariablesDb = @{
        ResourceGroupName = "tsum38RG"
        SqlDbInstanceName = "dmstestsqldb"
        MigrationService  = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.DataMigration/SqlMigrationServices/dms20211030"
        TargetSqlConnectionAuthentication = "SqlAuthentication"
        TargetSqlConnectionDataSource = "db.windows.net"
        TargetSqlConnectionPassword = "password"
        TargetSqlConnectionUserName = "username"
        SourceSqlConnectionAuthentication = "SqlAuthentication"
        SourceSqlConnectionDataSource = "sampledomain.microsoft.com"
        SourceSqlConnectionUserName = "user"
        SourceSqlConnectionPassword = "password"
        SourceDatabaseName = "AdventureWorks"
        TargetDbName = "at_sqldbtrgt2"
        Scope =  "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/tsum38RG/providers/Microsoft.Sql/servers/dmstestsqldb"

    }

    $DeleteDatabaseMigrationTestVariablesDb = @{
        ResourceGroupName = "DMSv2-TestRG"
        SqlDbInstanceName = "amakumtest"
        Kind = "SqlDb"
        TargetDbName = "CompanyDB5"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourcegroups/DMSv2-TestRG/providers/Microsoft.DataMigration/sqlmigrationservices/amakum-dms-eastus2"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/DMSv2-TestRG/providers/Microsoft.Sql/servers/amakumtest"
        SourceDatabaseName = "CompanyDB5"
        SourceSqlConnectionDataSource = "100.79.161.22"
        SourceSqlConnectionUserName = "amakum"
        SourceSqlConnectionAuthentication = "SQLAuthentication"
        SourceSqlConnectionPassword = "sourcepassword"
        TargetSqlConnectionDataSource = "amakumtest.database.windows.net"
        TargetSqlConnectionUserName = "amakum"
        TargetSqlConnectionAuthentication = "SQLAuthentication"
        TargetSqlConnectionPassword = "targetpassword"
        MigrationOperationId = "47ca6f55-b313-4c82-8a0e-89146d94ad19"
    }

    $DatabaseMigrationRetryTestVariables = @{
        ResourceGroupName = "DMSv2-TestRG"
        SqlDbInstanceName = "amakumtest"
        Kind = "SqlDb"
        TargetDbName = "CompanyDB6"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourcegroups/DMSv2-TestRG/providers/Microsoft.DataMigration/sqlmigrationservices/amakum-dms-eastus2"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/DMSv2-TestRG/providers/Microsoft.Sql/servers/amakumtest"
        SourceDatabaseName = "CompanyDB6"
        SourceSqlConnectionDataSource = "100.79.161.22"
        SourceSqlConnectionUserName = "amakum"
        SourceSqlConnectionAuthentication = "SQLAuthentication"
        SourceSqlConnectionPassword = "sourcepassword"
        TargetSqlConnectionDataSource = "amakumtest.database.windows.net"
        TargetSqlConnectionUserName = "amakum"
        TargetSqlConnectionAuthentication = "SQLAuthentication"
        TargetSqlConnectionPassword = "targetpassword"
        MigrationOperationId = "47ca6f55-b313-4c82-8a0e-89146d94ad19"
    }

    $DeleteDatabaseMigrationMITestVariablesDb = @{
        ResourceGroupName = "DMSv2-TestRG"
        ManagedInstanceName = "nihartestrelease"
        TargetDbName = "CompanyDB8"
        Kind = "SqlMi"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/DMSv2-TestRG/providers/Microsoft.Sql/managedInstances/nihartestrelease"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourcegroups/DMSv2-TestRG/providers/Microsoft.DataMigration/sqlmigrationservices/amakum-dms-eastus2"
        AzureBlobStorageAccountResourceId = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourcegroups/DMSv2-TestRG/providers/Microsoft.Storage/storageAccounts/amakumpstest"
        AzureBlobAccountKey = "storageaccountkey"
        AzureBlobContainerName = "test"
        SourceSqlConnectionAuthentication = "SqlAuthentication"
        SourceSqlConnectionDataSource = "100.79.161.22"
        SourceSqlConnectionUsername = "amakum"
        SourceSqlConnectionPassword = "sourcepassword"
        SourceDatabaseName = "CompanyDB8"
    }

    $DeleteDatabaseMigrationVmTestVariablesDb = @{
        ResourceGroupName = "DMSv2-TestRG"
        SqlVirtualMachineName = "amakumvmpstest"
        TargetDbName = "CompanyDB14"
        Kind = "SqlVM"
        Scope = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourceGroups/DMSv2-TestRG/providers/Microsoft.SqlVirtualMachine/SqlVirtualMachines/amakumvmpstest"
        MigrationService = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourcegroups/DMSv2-TestRG/providers/Microsoft.DataMigration/sqlmigrationservices/amakum-dms-eastus2"
        AzureBlobStorageAccountResourceId = "/subscriptions/f133ff51-53dc-4486-a487-47049d50ab9e/resourcegroups/DMSv2-TestRG/providers/Microsoft.Storage/storageAccounts/amakumpstest"
        AzureBlobAccountKey = "AccountKey"
        AzureBlobContainerName = "test"
        SourceSqlConnectionAuthentication = "SqlAuthentication"
        SourceSqlConnectionDataSource = "100.79.161.22"
        SourceSqlConnectionUserName = "amakum"
        SourceSqlConnectionPassword = "sourcepassword"
        SourceDatabaseName = "CompanyDB14"
    }

    $env.add("TestSqlMigrationService", $SqlMigrationServiceTestVariables) | Out-Null
    $env.add("TestNewSqlMigrationService",$NewSqlMigrationServiceTestVariables) | Out-Null
    $env.add("TestAuthKey",$AuthKeyTestVariables) | Out-Null
    $env.add("TestDatabaseMigrationMi", $DatabaseMigrationTestVariablesMi) | Out-Null
    $env.add("TestDatabaseMigrationVm", $DatabaseMigrationTestVariablesVm) | Out-Null
    $env.add("TestDatabaseMigrationDb", $DatabaseMigrationTestVariablesDb) | Out-Null
    $env.add("TestNewDatabaseMigrationMi", $NewDatabaseMigrationTestVariablesMi) | Out-Null
    $env.add("TestNewDatabaseMigrationVm", $NewDatabaseMigrationTestVariablesVm) | Out-Null
    $env.add("TestNewDatabaseMigrationDb", $NewDatabaseMigrationTestVariablesDb) | Out-Null
    $env.add("RemoveNode",$RemoveNode) | Out-Null
    $env.add("TestStopDatabaseMigrationMi", $StopDatabaseMigrationTestVariablesMi) | Out-Null
    $env.add("TestStopDatabaseMigrationVm", $StopDatabaseMigrationTestVariablesVm) | Out-Null
    $env.add("TestStopDatabaseMigrationDb", $StopDatabaseMigrationTestVariablesDb) | Out-Null
    $env.add("TestCutDatabaseMigrationMi", $CutDatabaseMigrationTestVariablesMi) | Out-Null
    $env.add("TestCutDatabaseMigrationVm", $CutDatabaseMigrationTestVariablesVm) | Out-Null
    $env.add("TestDeleteDatabaseMigrationDb", $DeleteDatabaseMigrationTestVariablesDb) | Out-Null
    $env.add("TestRetryDatabaseMigrationDb", $DatabaseMigrationRetryTestVariables) | Out-Null
    $env.add("TestDeleteMiMigration", $DeleteDatabaseMigrationMITestVariablesDb ) | Out-Null
    $env.add("TestDeleteDatabaseMigrationVm", $DeleteDatabaseMigrationVmTestVariablesDb) | Out-Null

    # For any resources you created for test, you should add it to $env here.
    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }
    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}
