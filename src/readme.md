# Instructions for generating modules
- Get AutoRest and prequisites following [these instructions](https://github.com/Azure/autorest/blob/master/docs/powershell/readme.md)
- Clone this branch
- Generate the RP
  - Change to the RP directory
    ``` 
    PS c:\repos\azure-powershell\> cd src\AppService
    ```
  - run AutoRest
    ```
    PS c:\repos\azure-powershell\src\AppService> autorest
    ```
  - If generation is unsuccessful, file issues for any errors in the [autorest.powershell repo](https://github.com/azure/autorest.powershell/issues)
  - If generation is successful, build and run the module
    ```
    PS c:\repos\azure-powershell\src\AppService> .\AppService\build-module.ps -run
    ```
- Compare the exported API surface to the eixting API surface for these cmd;ets
- Make configuration changes and iterate again for simple API transformations
  - Cmdlet verb and noun renames
  - Cmdlet parameter renames
  - Suppression of cmdlets, models, or parameter sets
  - Swagger path transforms that impact generation
- Make appropriate simple customizations to the API surface
  - Simple chaining of API calls
  - Consolidation of parameters -> reducing the number of parameters by inferring the value of one parameter from another
  - Changing the output of the cmdlets
- Validate that help can be generated using the generate-help.ps1 script
- List remaining necessary API customizations for the module (in the bug)

## Special instructions for particular RPs
### AppService
- There is currently a [profile failure](https://github.com/Azure/autorest.powershell/issues/192) - try generating with only the latest profile
- This RP will require a lot of customization, cncentrate on the API outside the Create and Set methods
### Billing
- Billing is currently blocked on the a [c# generator issue](https://github.com/Azure/autorest.powershell/issues/193).  Try generating the Billing, Commerce, and Consumption RPs separately t get around this for a partial evaluation.
### Compute
- Compute contains at least one API
### DNS

### KeyVault
- KeyVault is currently blocked on a [compilation failure after generation](https://github.com/Azure/autorest.powershell/issues/195).  Try fixing this error in the generated code, or generatign just the data plane components for a partial evaluation.
### Monitor
- There is currently a [profile failure](https://github.com/Azure/autorest.powershell/issues/196) - try generating with only the latest profile
### Network
- Network will have particular issues with flattening and object creation cmdlets - this is a good RP to experiment with flattening settings.
### Resources
- Currently Resources does not contain Graph.RBAC, or some members of Microsoft.Authorization you might try adding these to the configuration
- Role assignment and policyassignment cmdlets will have to implement the Scope parameter
### ServiceBus
- ServiceBus only implements a single API Version
### Storage
- Only Storage Management is represented for this round, and due to [a profile issue](https://github.com/Azure/autorest.powershell/issues/188), only a single version is being used

## What to look for
- Correct verb, noun, and parameter names
- Flattening of complex parameters
- Logical proeprties of output types
- Correct and complete syntax for each cmdlet

## Known Issues (do not report)
- The generator only generates parameter sets that break down resource identifier into its component parts, piping parameter sets are not yet available
- The table format does not yet differentiate important fields
