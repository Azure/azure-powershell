# Repo-Tasks Module

## Usage:

1. Double-click the shortcut located at `.\tools\PS-VSPrompt.lnk`, which will start VS Developer Prompt in PowerShell
2. Run the command `Import-Module .\Repo-Tasks.psd1` to import the `Repo-Tasks` module
	- During import, we allow users to load additional functions that they might want to use it in their session
	- If you have a `userPreference.ps1` file under the `%userprofile%/psFiles` directory, the `Repo-Tasks` module will try to load it by dot sourcing it
	- The module will also honor the environment variable `$env:psuserpreferences` and load `.ps1` files from the location that is pointed by `$env:psuserpreferences`
	- As long as you have exported all functions that you need from your `.ps1` file using `Export-ModuleMember -Function {{functionName}}`. We deliberately do this to avoid polluting the list of commands available (when you use `Get-Command`)
3. Currently, the `Repo-Tasks` module supports the following tasks:
	- `New-TestCredential`
		- Creates a credentials file (located in `C:/Users/\<currentuser\>/.azure/testcredentials.json`) that will be used to set the environment variable when scenario tests are run
	- `Set-TestEnvironment`
		- Will allow you create a test connection string required to setup the test environment in order to run tests. More information about the test environment can be found [here](./using-azure-test-framework.md)
	- `Start-Build`
		- Will allow you to kick off a full build, or build for a particular scope (_e.g._, `Start-Build -BuildScope ResourceManagment\Compute`)
	- `Get-BuildScopes`
		- Will allow you to find existing scopes that can be used to build from
	- `Invoke-CheckinTests`
		- Will build and run existing tests

### Note:
If you do not start your powershell session using the `PS-VSPrompt` shortcut, you will not have access to all the environment variables that are set as part of VS Developer Command prompt.