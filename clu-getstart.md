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
    
* Tools\Azure.Bat: contains the batch file command for running cmdlets in the clu.  Do not change
* \<modulename\>.nuspec.template, which contains nuspec format metadata about the package – the base temaplate is in tools\clu\Microsoft.Azure.Commands.nuspec.template.
   * %PackageId% - replace with the module name (Microsoft.Azure.Commands.\<rp-name\>)
   * %PackageTitle%  Title of the cmdlet package in nuget
   * %PackageVersion%, %ReferenceFiles%,%SourceFiles%,%ContentFiles%  - Filled in by build tool
   * %PackageSummary% - Summary field in nuget ui
   * %PackageDescription% - Log description in package ui
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
  *  Cmdlet parameters use the double dash (--) so for example, getting a subscription with a particular name would be: `azure subscription get –SubscriptionName “name of subscription"`
  * To log in, 3 options
    * login interactively using device flow, this is the only option for msa account or any org-id with 2fa enforced, example: `azure account add`
    * login with user and password, this works on org-id w/o 2fa enforced, example: `azure account add --Username user@contoso.org  --Password password1`
    * login as service principal. Example: `azure account add --ServicePrincipal --TenantId <tenant> --ApplicationId <id> --Secret <secret>`
