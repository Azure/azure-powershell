$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMariaDbConnectionString.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzMariaDbConnectionString' {
    It 'ServerName' {
        $ADONETStr = "Server=$($env.rstrbc01).mariadb.database.azure.com; Port=3306; Database={your_database}; Uid=$($env.AdminLogin)@$($env.rstrbc01); Pwd={your_password}; SslMode=Preferred;"
        $JDBCStr = "String url =`"jdbc:mariadb://$($env.rstrbc01).mariadb.database.azure.com:3306/{your_database}?useSSL=true`"; myDbConn = DriverManager.getConnection(url, `"$($env.AdminLogin)@$($env.rstrbc01)`", {your_password});"
        $NodejsStr = "var conn = mysql.createConnection({host: `"$($env.rstrbc01).mariadb.database.azure.com`", user: `"$($env.AdminLogin)@$($env.rstrbc01)`", password: {your_password}, database: {your_database}, port: 3306, ssl:{ca:fs.readFileSync({ca-cert filename})}});"
        $PHPStr = "`$con=mysqli_init();mysqli_ssl_set(`$con, NULL, NULL, {ca-cert filename}, NULL, NULL); mysqli_real_connect(`$con, `"$($env.rstrbc01).mariadb.database.azure.com`", `"$($env.AdminLogin)@$($env.rstrbc01)`", {your_password}, {your_database}, 3306);"
        $PythonStr = "cnx = mysql.connector.connect(user=`"$($env.AdminLogin)@$($env.rstrbc01)`", password={your_password}, host=`"$($env.rstrbc01).mariadb.database.azure.com`", port=3306, database={your_database}, ssl_ca={ca-cert filename}, ssl_verify_cert=true)";
        $RubyStr = "client = Mysql2::Client.new(username: `"$($env.AdminLogin)@$($env.rstrbc01)`", password: {your_password}, database: {your_database}, host: `"$($env.rstrbc01).mariadb.database.azure.com`", port: 3306, sslca:{ca-cert filename}, sslverify:false, sslcipher:`"AES256-SHA`")"
        $WebAppStr = "Database={your_database}; Data Source=$($env.rstrbc01).mariadb.database.azure.com; User Id=$($env.AdminLogin)@$($env.rstrbc01); Password={your_password}"
        
        $client = 'ADO.NET'
        $conStr = Get-AzMariaDbConnectionString -Client $client -Name $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        $conStr | Should -Be $ADONETStr

        $client = 'JDBC'
        $conStr = Get-AzMariaDbConnectionString -Client $client -Name $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        $conStr | Should -Be $JDBCStr

        $client = 'Node.js'
        $conStr = Get-AzMariaDbConnectionString -Client $client -Name $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        $conStr | Should -Be $NodejsStr

        $client = 'PHP'
        $conStr = Get-AzMariaDbConnectionString -Client $client -Name $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        $conStr | Should -Be $PHPStr

        $client = 'Python'
        $conStr = Get-AzMariaDbConnectionString -Client $client -Name $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        $conStr | Should -Be $PythonStr
        
        $client = 'Ruby'
        $conStr = Get-AzMariaDbConnectionString -Client $client -Name $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        $conStr | Should -Be $RubyStr

        $client = 'WebAPP'
        $conStr = Get-AzMariaDbConnectionString -Client $client -Name $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        $conStr | Should -Be $WebAppStr
    } 
    It 'ServerNameObject' {
        $ADONETStr = "Server=$($env.rstrbc01).mariadb.database.azure.com; Port=3306; Database={your_database}; Uid=$($env.AdminLogin)@$($env.rstrbc01); Pwd={your_password}; SslMode=Preferred;"
        $JDBCStr = "String url =`"jdbc:mariadb://$($env.rstrbc01).mariadb.database.azure.com:3306/{your_database}?useSSL=true`"; myDbConn = DriverManager.getConnection(url, `"$($env.AdminLogin)@$($env.rstrbc01)`", {your_password});"
        $NodejsStr = "var conn = mysql.createConnection({host: `"$($env.rstrbc01).mariadb.database.azure.com`", user: `"$($env.AdminLogin)@$($env.rstrbc01)`", password: {your_password}, database: {your_database}, port: 3306, ssl:{ca:fs.readFileSync({ca-cert filename})}});"
        $PHPStr = "`$con=mysqli_init();mysqli_ssl_set(`$con, NULL, NULL, {ca-cert filename}, NULL, NULL); mysqli_real_connect(`$con, `"$($env.rstrbc01).mariadb.database.azure.com`", `"$($env.AdminLogin)@$($env.rstrbc01)`", {your_password}, {your_database}, 3306);"
        $PythonStr = "cnx = mysql.connector.connect(user=`"$($env.AdminLogin)@$($env.rstrbc01)`", password={your_password}, host=`"$($env.rstrbc01).mariadb.database.azure.com`", port=3306, database={your_database}, ssl_ca={ca-cert filename}, ssl_verify_cert=true)";
        $RubyStr = "client = Mysql2::Client.new(username: `"$($env.AdminLogin)@$($env.rstrbc01)`", password: {your_password}, database: {your_database}, host: `"$($env.rstrbc01).mariadb.database.azure.com`", port: 3306, sslca:{ca-cert filename}, sslverify:false, sslcipher:`"AES256-SHA`")"
        $WebAppStr = "Database={your_database}; Data Source=$($env.rstrbc01).mariadb.database.azure.com; User Id=$($env.AdminLogin)@$($env.rstrbc01); Password={your_password}"
        
        $mariadb = Get-AzMariaDbServer -Name $env.rstrbc01 -ResourceGroupName $env.ResourceGroup
        
        $client = 'ADO.NET'
        $conStr = Get-AzMariaDbConnectionString -Client $client -InputObject $mariadb
        $conStr | Should -Be $ADONETStr

        $client = 'JDBC'
        $conStr = Get-AzMariaDbConnectionString -Client $client -InputObject $mariadb
        $conStr | Should -Be $JDBCStr

        $client = 'Node.js'
        $conStr = Get-AzMariaDbConnectionString -Client $client -InputObject $mariadb
        $conStr | Should -Be $NodejsStr

        $client = 'PHP'
        $conStr = Get-AzMariaDbConnectionString -Client $client -InputObject $mariadb
        $conStr | Should -Be $PHPStr

        $client = 'Python'
        $conStr = Get-AzMariaDbConnectionString -Client $client -InputObject $mariadb
        $conStr | Should -Be $PythonStr
        
        $client = 'Ruby'
        $conStr = Get-AzMariaDbConnectionString -Client $client -InputObject $mariadb
        $conStr | Should -Be $RubyStr

        $client = 'WebAPP'
        $conStr = Get-AzMariaDbConnectionString -Client $client -InputObject $mariadb
        $conStr | Should -Be $WebAppStr
    } 
}
