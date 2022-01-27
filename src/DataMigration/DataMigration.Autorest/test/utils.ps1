function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
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
        FileSharePassword = "domainPassword" 
        SourceSqlConnectionAuthentication = "SqlAuthentication" 
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com" 
        SourceSqlConnectionUserName = "domainUserName" 
        SourceSqlConnectionPassword = "domainPassword" 
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
        FileSharePassword = "domainPassword" 
        SourceSqlConnectionAuthentication = "SqlAuthentication" 
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com" 
        SourceSqlConnectionUserName = "domainUserName" 
        SourceSqlConnectionPassword = "domainPassword" 
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
        FileSharePassword = "domainPassword" 
        SourceSqlConnectionAuthentication = "SqlAuthentication" 
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com" 
        SourceSqlConnectionUserName = "domainUserName" 
        SourceSqlConnectionPassword = "domainPassword" 
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
        FileSharePassword = "domainPassword" 
        SourceSqlConnectionAuthentication = "SqlAuthentication" 
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com" 
        SourceSqlConnectionUserName = "domainUserName" 
        SourceSqlConnectionPassword = "domainPassword" 
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
        FileSharePassword = "domainPassword" 
        SourceSqlConnectionAuthentication = "SqlAuthentication" 
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com" 
        SourceSqlConnectionUserName = "domainUserName" 
        SourceSqlConnectionPassword = "domainPassword" 
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
        FileSharePassword = "domainPassword" 
        SourceSqlConnectionAuthentication = "SqlAuthentication" 
        SourceSqlConnectionDataSource = "sampledomain.onmicrosoft.com" 
        SourceSqlConnectionUserName = "domainUserName" 
        SourceSqlConnectionPassword = "domainPassword" 
        SourceDatabaseName = "AdventureWorks"
    }

    $env.add("TestSqlMigrationService", $SqlMigrationServiceTestVariables) | Out-Null
    $env.add("TestNewSqlMigrationService",$NewSqlMigrationServiceTestVariables) | Out-Null
    $env.add("TestAuthKey",$AuthKeyTestVariables) | Out-Null
    $env.add("TestDatabaseMigrationMi", $DatabaseMigrationTestVariablesMi) | Out-Null
    $env.add("TestDatabaseMigrationVm", $DatabaseMigrationTestVariablesVm) | Out-Null
    $env.add("TestNewDatabaseMigrationMi", $NewDatabaseMigrationTestVariablesMi) | Out-Null
    $env.add("TestNewDatabaseMigrationVm", $NewDatabaseMigrationTestVariablesVm) | Out-Null
    $env.add("RemoveNode",$RemoveNode) | Out-Null
    $env.add("TestStopDatabaseMigrationMi", $StopDatabaseMigrationTestVariablesMi) | Out-Null
    $env.add("TestStopDatabaseMigrationVm", $StopDatabaseMigrationTestVariablesVm) | Out-Null
    $env.add("TestCutDatabaseMigrationMi", $CutDatabaseMigrationTestVariablesMi) | Out-Null
    $env.add("TestCutDatabaseMigrationVm", $CutDatabaseMigrationTestVariablesVm) | Out-Null

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

