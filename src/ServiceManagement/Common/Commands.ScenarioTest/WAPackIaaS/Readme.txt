
The functional tests in this folder covers 'WAPack IaaS' cmdlets.
These tests exercise the cmdlets from End to End with no mocking in 
any of the layers.



Dependencies

------------

These tests require an active subscription in which VMs will be created.
The tests also require a set of VMTemplates and VHDs preloaded into the environment.



Subscription information from the resource file PublishSettingsFile property
In order to make it work with your subscriptions, place your publishsettings file in the Artifacts folder and rename it to 'WAPackTestConfig.publishsettings'.
It uses the first subscription id from this file.



Running functional tests

------------------------

Build the complete solution first and then these tests have to be executed from Visual Studio with MSTest.

