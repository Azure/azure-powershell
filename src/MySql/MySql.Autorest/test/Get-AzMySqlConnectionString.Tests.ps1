$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMySqlConnectionString.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMySqlConnectionString' {
    It 'Get' {
        $connectionString = Get-AzMySqlConnectionString -Client ADO.NET -Name $env.serverName -ResourceGroupName $env.resourceGroup
        $connectionString | Should -Be "Server=$($env.serverName).mysql.database.azure.com; Port=3306; Database={your_database}; Uid=mysql_test@$($env.serverName); Pwd={your_password}; SslMode=Preferred;"
    }

    It 'GetViaIdentity' {
        $server = Get-AzMySqlServer -ResourceGroupName $env.resourceGroup -ServerName $env.serverName

        $PHPConnectionString = Get-AzMySqlConnectionString -Client PHP -InputObject $server
        $PHPExpect = '$con=mysqli_init();mysqli_ssl_set($con, NULL, NULL, {ca-cert filename}, NULL, NULL); mysqli_real_connect($con, "' + $env.serverName + '.mysql.database.azure.com", "mysql_test@' + $env.serverName + '", {your_password}, {your_database}, 3306);'
        $PHPConnectionString | Should -Be $PHPExpect

        $JDBCConnectionString = Get-AzMySqlConnectionString -Client JDBC -InputObject $server
        $JDBCExpect = 'String url ="jdbc:mysql://'+ $env.serverName + '.mysql.database.azure.com:3306/{your_database}?useSSL=true"; myDbConn = DriverManager.getConnection(url, "mysql_test@' + $env.serverName + '", {your_password});'
        $JDBCConnectionString | Should -Be $JDBCExpect

        $NodeConnectionString = Get-AzMySqlConnectionString -Client Node.js -InputObject $server
        $NodeExpect = 'var conn = mysql.createConnection({host: "' + $env.serverName + '.mysql.database.azure.com", user: "mysql_test@' + $env.serverName + '", password: {your_password}, database: {your_database}, port: 3306, ssl:{ca:fs.readFileSync({ca-cert filename})}});'
        $NodeConnectionString | Should -Be $NodeExpect

        $PythonConnectionString = Get-AzMySqlConnectionString -Client Python -InputObject $server
        $PythonExpect = 'cnx = mysql.connector.connect(user="mysql_test@'+ $env.serverName + '", password={your_password}, host="' + $env.serverName +'.mysql.database.azure.com", port=3306, database={your_database}, ssl_ca={ca-cert filename}, ssl_verify_cert=true)'
        $PythonConnectionString | Should -Be $PythonExpect

        $RubyConnectionString = Get-AzMySqlConnectionString -Client Ruby -InputObject $server
        $RubyExpect = 'client = Mysql2::Client.new(username: "mysql_test@' + $env.serverName + '", password: {your_password}, database: {your_database}, host: "' + $env.serverName + '.mysql.database.azure.com", port: 3306, sslca:{ca-cert filename}, sslverify:false, ' + 'sslcipher:"AES256-SHA")'
        $RubyConnectionString | Should -Be $RubyExpect

        $WebConnectionString = Get-AzMySqlConnectionString -Client WebApp -InputObject $server
        $WebExpect = "Database={your_database}; Data Source=$($env.serverName).mysql.database.azure.com; User Id=mysql_test@$($env.serverName); Password={your_password}"
        $WebConnectionString | Should -Be $WebExpect
    }
}
