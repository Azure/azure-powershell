# Work on CLU cmdlets

### Prerequsites

Visual Studio 2015 RTM with ASP.NET. For details, check out the [installation doc](http://docs.asp.net/en/latest/getting-started/installing-on-windows.html). 
  
Note, after done, run `dnvm list` command to check the 'coreclr' runtime is installed with right version of `1.0.0-rc1-final`. If not, run `dnvm install 1.0.0-rc1-final -r coreclr -a x64 -p`. Remember always use `-p` flag, so the selection can persist. 

### Project Artifacts

CLUPackages require some additional files to direct generation of indexing, and to provide shortcuts when files are installed.  These files can be copied from the Profile project and updated for each package.   

* Content\azure.lx, configures command dispatch, here are the changeable fields in this file 

    | Field         | Value         |
    | ------------- |:-------------:|
    | Modules      | Assembly name of cmdlets assembly |
    | NounPrefix      | ‘AzureRm’  The part of the cmdlet noun to remove in clu commands|

*	Content\package.cfg, configures index generation on  install, here are the changeable fields

    | Field         | Value         |
    | ------------- |:-------------:|
    | CommandAssemblies      | File name of cmdlets assembly(ies) |
    | NounPrefix      | ‘AzureRm’  The part of the cmdlet noun to remove in clu commands|
    | NounFirst       | if true, the verb comes at the end of the command (e.g. azure resource get)|
    
* \<modulename\>.nuspec.template, which contains nuspec format metadata about the package – the base temaplate is in tools\clu\Microsoft.Azure.Commands.nuspec.template.  Here are the special fields defined in this template:
   * %PackageId% - replace with the module name (Microsoft.Azure.Commands.\<rp-name\>)
   * %PackageTitle%  Title of the cmdlet package in nuget, replace with the title that should show up in nuget ui
   * %PackageVersion%, %ReferenceFiles%,%SourceFiles%,%ContentFiles%  - Filled in by build tool
   * %PackageSummary% - Summary field in nuget ui, replace with the summary data for your package
   * %PackageDescription% - Long description in package ui, replace with the long description for your package.
   * Almost all cmdlets packages should add a dependency to Microsoft.Azure.Commands.Profile package

* Ensure that project.json is set to expose a command entrypoint: `"compilationOptions": {"emitEntryPoint": true}`
* Ensure that the project implements at least one console entry point
```c#
      public class EntryStub
      {
          public static void Main(string[] args)
          {
              // empty entry point
          }
      }
``` 
   
### Package Creation and Testing
   2 options
   * Run `<repo-root>\tools\CLU\SetupEnv.bat` which build and generate all cmdlet packages and deploy to under `<repo root>\drop` folder. When you have a clean environment, you should always do this first.
   * Run `<repo-root>\tools\CLU\BuildCmdlet` <name like: Microsoft.Azure.Commands.Profile>", this will build and refresh an individual cmdlet package.

Once you are done with #1, in the same command window, you can type "azure help" to explore and run cmdlets. 

To debug, set environment variable of `DebugCLU` to "1"(#1 should set it up already). When you run any command, you will see a prompt telling you to attach debugger. 

To test on osx/linux boxes, do #1, open `<repo-root>\drop\clurun`, you should see subfolders for "osx" and "ubuntu", copy the folder to your target machine, and run the "azure.sh" inside. Make sure set execution permission using `chmod +x azure.sh clurun`

(All of those are subject to change, contact yugangw or adxsdkdev for any questions)

### Quick introductions on cmdlets
  *  Run commands using the ‘azure’ prefix, cmdlet nouns, and cmdlet verbs, for example, `azure environment get` maps to the cmdlet `Get-AzureRmEnvironment`
  *  Cmdlet parameters use the double dash (--) so for example, getting a subscription with a particular name would be: `azure subscription get –-SubscriptionName “name of subscription"`
  * To log in, 3 options
    * login interactively using device flow, this is the only option for msa account or any org-id with 2fa enforced, example: `azure account add`
    * login with user and password, this works on org-id w/o 2fa enforced, example: `azure account add --Username user@contoso.org  --Password password1`
    * login as service principal. Example: `azure account add --ServicePrincipal --TenantId <tenant> --ApplicationId <id> --Secret <secret>`
  * Piping between cmdlets should work the same way that Powerhell piping works
    ```azure subscription get --SubscriptionName | azure context set```
  * You can capture piped output using redirection to a file - the result will be the json serialization of the output object.
    ```azure subscription get > subscriptions.json```
  * You can use file input tu aparameter using '@' notation:
    ```azure command --param1 @file1.json```
    Reads input from file1.json and attempts to deserialize the .net object that is the Parameter type for ```param1```
    ```azure command --param1 @@file1.json```
    Does the same thing, but treats the input from ```file1.json``` as if it come from the pipeline, so that multiple objects will result in multiple invocations of ```ProcessRecord()``` for the target cmdlet.
  * There are some known issues with the current approach to sessions, which can cause session variables to not be propagated when running cmdlets in a pipeline, to work around this, set the 'CmdletSessionId' environment variable to a numeric value - all cmdlets running from the shell will use that session id, and sessions will work with pipelining 

    ```set CmdletSessionId=1010 ```

### Testing Cmdlets

#### Environment setup (Windows)
- Install latest version of [Git for Windows](https://git-scm.com/download/win) that has `bash 4.x` available.
- Install `jq` using chocolatey `choco install jq` (chocolatey can be installed from [here](https://chocolatey.org/)).

#### Test Infrastructure
Testing will consist of scenario tests and unit tests. Scenario tests should be written in a form of an example and be available in `.ps1` and `.sh` formats.

#### Scenario Tests
- Scenario tests should be saved under `./examples` directory and grouped by the package or service area. Each scenario tests should consist of both `.ps1` and `.sh` files and should cover "P0" scenarios.

##### Bash Tests
- Bash tests should be runnable from bash shell in windows/linux/mac environments.
- To manually run the tests; please set the following envt. variables for authentication and run `./examples/lib/testrunner.sh`
   ```bash
   export azureuser=<username@contosocorp.com>
   export azurepassword=<your_password>
   export PATH=$PATH:/<path-to-drop>/clurun/win7-x64/
   . /examples/lib/testrunner.sh
   ```
- All the parameters to the cmdlets should be passed in as envt. variables
- The current test runners will provide a unique resource group name via `$groupName` but may not remove it at the end if the test fails.
- The location for ARM will be provided via variable `$location`.
- "jq" package and BASH assert (e.g. `[ "foo" == "bar" ]`) should be used to validate the responses.

##### PowerShell Tests
TODO: Add section on PowerShell testing

#### Unit Tests
TODO: Add section on unit testing


