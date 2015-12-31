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
   Two options
   1. Run `<repo-root>\tools\CLU\BuildAndInstallClu.bat` which build and generate all cmdlet packages and deploy to under `<repo root>\drop\clurun` folder, with 3 flavors `win7-x64`, `osx.10.10-x64` and `ubuntu.14.04-x64`. When you have a clean environment or just pull from upstream, you should clean temporary bits such as `git clean -xdf`, and run this command.
   2. Run `<repo-root>\tools\CLU\BuildCmdlet <package name like Microsoft.Azure.Commands.Profile>` <name like: Microsoft.Azure.Commands.Profile>", this will build and refresh an individual cmdlet package.

After #1 above is finished, you can run `drop\clurun\<platform>\azure.bat help` to explore.

To debug, set environment variable of `DebugCLU` to "1". Then on running any command, you will be prompted to attach a debugger.

There is also `<repo-root>\tools\CLU\SetupEnv.bat` which is a windows batch wrapping around the `BuildAndInstallClu.bat`, plus set the `DebugCLU` for you, and add the `drop\clurun\win7-x64\azure.bat` to the PATH environment variable.

To test on osx/linux boxes, do #1, open `<repo-root>\drop\clurun`, copy the flavor folder to your target machine, and run the "azure.sh" inside. Make sure set execution permission using `chmod +x azure.sh clurun`

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
- Scenario tests should be saved under `./examples` directory with one directory per package. Each scenario tests should (eventually) consist of both `.ps1` and `.sh` files and should cover "P0" scenarios.

##### XUnit Automation For Bash Scenario Tests
- The ```Commands.Common.ScenarioTest``` project contains classes that enable executing bash scenario tests in Visual Studio, or cross-platform using dnx.

- To implement an xunit bash scenario test you must
  - Add a ```[Collection("SampleCollection")]``` attribute to your test class
  - Add a field to your class of type ```ScenarioTestFixture``` and add a constructor that initializes it
    ```C#
    [Collection("SampleCollection")]
    public class SampleTestClass
    {
        ScenarioTestFixture _fixture;
        public SampleTestClass(ScenarioTestFixture fixture)
        {
            _fixture = fixture;
        }
    ```
    - Use the fixture in your test method to create a script runner for your directory and to run your test script:
    ```C#
    [Fact]
    public void RunSampleTest()
    {
        _fixture.GetRunner("resource-management").RunScript("01-ResourceGroups");
    }
    ```
    - Set the environment variable 'TestCredentials' to a connection string providing the credentials to use during test execution. Possible fields include:
    
      |  Field (case sensitive) |  Description  |
      | ------------- |:-------------|
      |  Username     | an OrgId user name |
      | ServicePrincipal | a service principal name |
      | Password      | the password or application secret to sue for authentication |
      | TenantId      | (required for Service authentication) The tenant guid to authenticate against |
      | SubscriptionId | (optional) Selects a particular subscription by id.  If not provided, the first listed subscription will be selected |
    - The infrastructure automatically generates a resource group name and assigns the value to the bash variable ```"$resourceGroupName"```.  If your scripts require additional variables, you can add these to your environment before running tests, or you can generate values using the ScriptRunner (for the tests using that runner).
    ```C#
        runner.EnvironmentVariables.Add("myVariableName", runner.GenerateName("myres"));
    ```
    - Tests can be executed in vs, or by runnign ```dnx test project.json```.  If you execute dnx test from the project directory, it will work without modification and a log file for each script will be written to the test results directory ```..\TestResults```.  If you execute dnx test from a different directory, you must set the following environment variables to provide the path to the examples directory and where to write log files:
    
      |  Environment Variable  |  Description  |
      | ------------- |:-------------|
      |  ExamplesDirectory     | The path to the 'examples' directory ($pshome/examples) |
      | TestDirectory | The path to the directory where logs will be written |
      
##### Running Bash Tests using Bash shell
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


