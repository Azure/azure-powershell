$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'AzPostgreSqlFlexibleServerDatabase.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AzPostgreSqlFlexibleServerDatabase' {

    It 'ViaName' {
        { 
            #CreateExpanded
            $db = New-AzPostgreSqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Charset UTF8 -Collation en_US.utf8
            $db.Name | Should -Be $env.databaseName
            $db.Charset | Should -Be "UTF8"
            $db.Collation | Should -Be "en_US.utf8"

            $db = Get-AzPostgreSqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $db.Charset | Should -Be "UTF8"
            $db.Collation | Should -Be "en_US.utf8"

            $dbs = Get-AzPostgreSqlFlexibleServerDatabase -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
            $dbs.Count | Should -BeGreaterOrEqual 1

            Remove-AzPostgreSqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
        
            #ClientIPAddress
            $db = New-AzPostgreSqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Charset UTF8 -Collation en_US.utf8
            $db.Name | Should -Be $env.databaseName
            $db.Charset | Should -Be "UTF8"
            $db.Collation | Should -Be "en_US.utf8"

            $db = Get-AzPostgreSqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName
            $db.Charset | Should -Be "UTF8"
            $db.Collation | Should -Be "en_US.utf8"
            Remove-AzPostgreSqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName 
        
        } | Should -Not -Throw
    }

    It 'ViaIdentity' {
        {
            #AllowAll
            
            $db = New-AzPostgreSqlFlexibleServerDatabase -Name $env.databaseName -ResourceGroupName $env.resourceGroup -ServerName $env.flexibleServerName -Charset UTF8 -Collation en_US.utf8
            $db.Name | Should -Be $env.databaseName
            $db.Charset | Should -Be "UTF8"
            $db.Collation | Should -Be "en_US.utf8"

            $db = Get-AzPostgreSqlFlexibleServerDatabase -InputObject $db
            $db.Charset | Should -Be "UTF8"
            $db.Collation | Should -Be "en_US.utf8"

            Remove-AzPostgreSqlFlexibleServerDatabase -InputObject $db

        } | Should -Not -Throw
    }
}