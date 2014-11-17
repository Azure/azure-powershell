The functional tests in this folder covers 'Azure Sql Database Server' cmdlets.
These tests exercise the cmdlets from End to End with no mocking in 
any of the layers.

Dependencies
------------
These tests require an active subscription in which a sql database server will
be created. It also needs to know the location/region where the server should
be created.

Functional test reads the following information
1. Subscription information from 
'src\Management.Test\Resources\Azure.publishsettings'. 
It uses the first subscription id from this file.

2. Server location from 
'src\Management.SqlDatabase.Test\Resources\SqlDatabaseSettings.xml'.

Running functional tests
------------------------
These functional tests are not part of the unit tests executed by the target
 "Test" in build.proj.
In order to run these test, it has to be executed manually from Visual 
Studio like any other unit test.