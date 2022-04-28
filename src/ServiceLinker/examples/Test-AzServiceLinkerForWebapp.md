### Example 1: Test Linker
```powershell
Test-AzServiceLinkerForWebapp -Webapp servicelinker-webapp -ResourceGroupName servicelinker-test-group -Name postgresql_connection  | fl
```

```output
EndTime    : 2022-04-28T10:08:48.3853396Z
Message    : {"ConnectionName":"postgresql_connection","IsConnectionAvailable":true,"ValidationDetail":
             [{"Name":"The target existence is validated","Description":null,"Result":0},{"Name":"The       
             target service firewall is validated","Description":null,"Result":0},{"Name":"The
             configured values (except username/password) is validated","Description":null,"Result":0}] 
             ,"ReportStartTimeUtc":"2022-04-28T10:08:45.018802Z","ReportEndTimeUtc":"2022-04-28T10:08:4 
             8.254394Z","SourceId":null,"TargetId":"/subscriptions/937bc588-a144-4083-8612-5f9ffbbddb14 
             /resourceGroups/servicelinker-test-group/providers/Microsoft.DBforPostgreSQL/servers 
             /test-postgresql/databases/testdb","AuthType":4}
ResourceId : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-grou
             p/providers/Microsoft.Web/sites/servicelinker-webapp/providers/Microsoft.ServiceLinker/lin
             kers/postgresql_connection
StartTime  : 2022-04-28T10:08:43.7039493Z
Status     : Succeeded
```

Test Linker
