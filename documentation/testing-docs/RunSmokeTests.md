# Running Tests with Auto Login #

This script will allow to login as long as you have required certificate installed on your machine

## WorkFlow #1 ##

1. Will Check if the certificate is installed
2. If not will ask you to login (one time) to access KeyVault
3. Download Certificate, install certificate on the machine (will prompt to set certificate password)
4. Login using the recently installed certificate
5. Set the context for Test Subscription
6. Download PublishSettings file from keyVault to enable log into ASM
7. Run Tests
8. Clean up - Delete any locally downloaded certificates or publishsettings file

## WorkFlow #2 ##

1. Check if certificate is installed
2. If Yes, log in using certificate
3. Download publishsettings file from KeyVault
4. Log into ASM using publish settings file
5. Run Tests
6. Clean up


The script that kick starts running test is RunInstallationTests.ps1
This script takes two parameters

1. uninstallLocalCert
	1. $true: will uninstalled existing certificate
	2. $false: will not uninstall existing certificate

1. runOnCIMachine
	1. $true:
		1. this mode will allow to fail fast, especially if it detects local certificate is not installed and needs manual login, it will fail
		2. this will also set the DebugPreference = "Continue", this allows you to get more verbose output of the various cmdlets that are executed as part of the test
	2. $false: will check if the local certificate is installed, if not manually will prompt user to log in and install the certificate from KeyVault



