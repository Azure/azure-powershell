function Get-AzFunctionAppFlexConsumptionRuntime {
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Gets the Flex Consumption function app runtimes supported at the specified location.')]
    [CmdletBinding(DefaultParameterSetName='AllRuntimes')]
    param(
        [Parameter(ParameterSetName='AllRuntimes', Mandatory=$true, HelpMessage='The location where Flex Consumption function apps are supported.')]
        [Parameter(ParameterSetName='AllVersions', Mandatory=$true)]
        [Parameter(ParameterSetName='ByVersion', Mandatory=$true)]
        [Parameter(ParameterSetName='DefaultOrLatest', Mandatory=$true)]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Location},

        [Parameter(ParameterSetName='ByVersion', Mandatory=$true, HelpMessage='The Flex Consumption function app runtime.')]
        [Parameter(ParameterSetName='AllVersions', Mandatory=$true)]
        [Parameter(ParameterSetName='DefaultOrLatest', Mandatory=$true)]
        [ValidateSet("DotNet-Isolated", "Node", "Java", "PowerShell", "Python", "Custom")]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Runtime},

        [Parameter(ParameterSetName='ByVersion', Mandatory=$true, HelpMessage='The function app runtime version.')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Version},

        [Parameter(ParameterSetName='DefaultOrLatest', Mandatory=$true, HelpMessage='Get the default or latest version of the specified runtime.')]
        [switch]
        $DefaultOrLatest
    )
    
    process {

        RegisterFunctionsTabCompleters

        # Validate Flex Consumption location
        Validate-FlexConsumptionLocation -Location $Location

        switch ($PSCmdlet.ParameterSetName) {
            'AllRuntimes' {
                # Return all runtimes
                foreach ($runtimeName in $FlexConsumptionSupportedRuntimes)
                {
                    Get-FlexFunctionAppRuntime -Location $Location -Runtime $runtimeName
                }
            }
            'AllVersions' {
                # Return all versions for the specified runtime
                Get-FlexFunctionAppRuntime -Location $Location -Runtime $Runtime
            }
            'ByVersion' {
                # Return specific version
                Get-FlexFunctionAppRuntime -Location $Location -Runtime $Runtime -Version $Version
            }
            'DefaultOrLatest' {
                # Return default/latest version
                Get-FlexFunctionAppRuntime -Location $Location -Runtime $Runtime -DefaultOrLatest:$true
            }
        }
    }
}
