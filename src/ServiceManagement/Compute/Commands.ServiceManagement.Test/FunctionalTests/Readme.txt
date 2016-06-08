
The functional tests in this folder covers 'Service Management IaaS' cmdlets.
These tests exercise the cmdlets from End to End with no mocking in 
any of the layers.

Dependencies
------------
These tests require an active subscription in which VMs will be created. 
It also needs to know the location/region where the VM should
be created.

Functional test reads the following information
1. Subscription information from the resource file PublishSettingsFile property
In order to make it work with your subscriptions, place your publishsettings file in the Artifacts folder and rename it to 'AzurePSTest.publishsettings'
It uses the first subscription id from this file.

2. Location information from the resource Location
To change the location, update the Location property with your desired location.


Running functional tests
------------------------
These tests have to be executed from Visual Studio with MSTest.
