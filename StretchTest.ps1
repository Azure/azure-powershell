# serverLogin: User
# serverPassWord: WSCwsc92


# Create stretch database with all parameters.

$resourcegroupName = "ShicWuTest"
$serverName = "shicwu-auseast1"
$databaseName = "TestDB1"
$collationName = "SQL_Latin1_General_CP1_CI_AS"
$maxSizeBytes = 250GB
$dwdb = New-AzureRmSqlDatabase -ResourceGroupName $resourcegroupName -ServerName $serverName -DatabaseName $databaseName `
		-CollationName $collationName -MaxSizeBytes $maxSizeBytes -Edition Stretch -RequestedServiceObjectiveName DS100
Assert-AreEqual $dwdb.DatabaseName $databaseName
Assert-AreEqual $dwdb.MaxSizeBytes $maxSizeBytes
Assert-AreEqual $dwdb.Edition Stretch
Assert-AreEqual $dwdb.CurrentServiceObjectiveName DS100
Assert-AreEqual $dwdb.CollationName $collationName



# Create and alter stretch database
$strechdb2 = Set-AzureRmSqlDatabase -ResourceGroupName "ShiCWuTest" -ServerName "shicwu-auseast1" -DatabaseName "TestDB1" `
-CollationName "Japanese_Bushu_Kakusu_100_CS_AS" -MaxSizeBytes 500GB -Edition Stretch -RequestedServiceObjectiveName DS100
Assert-AreEqual $strechdb2.DatabaseName $strechdb.DatabaseName
Assert-AreEqual $strechdb2.MaxSizeBytes $maxSizeBytes
Assert-AreEqual $strechdb2.Edition Stretch
Assert-AreEqual $strechdb2.CurrentServiceObjectiveName DS100
Assert-AreEqual $strechdb2.CollationName $collationName