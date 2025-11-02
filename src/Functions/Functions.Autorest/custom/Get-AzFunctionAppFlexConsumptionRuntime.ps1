function Get-AzFunctionAppFlexConsumptionRuntime {
    [Microsoft.Azure.PowerShell.Cmdlets.Functions.Description('Gets the Flex Consumption function app runtimes supported at the specified location.')]
    [CmdletBinding(DefaultParameterSetName='ByLocation')]
    param(
        [Parameter(ParameterSetName='ByLocation', Mandatory=$true, HelpMessage='The location where Flex Consumption function apps are supported.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [ValidateNotNullOrEmpty()]
        [System.String]
        ${Location},

        # [Parameter(ParameterSetName='ByLocation', Mandatory=$true, HelpMessage='Name of the resource group to which the resource belongs.')]
        # [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        # [ValidateNotNullOrEmpty()]
        # [System.String]
        # ${ResourceGroupName},

        # [Parameter(ParameterSetName='ByLocation', HelpMessage='The Azure subscription ID.')]
        # [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        # [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        # [ValidateNotNullOrEmpty()]
        # [System.String[]]
        # ${SubscriptionId},

        [Parameter(ParameterSetName='ByLocation', Mandatory=$true, HelpMessage='The Flex Consumption function app runtime.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [ValidateSet("DotNet-Isolated", "Node", "Java", "Python", "PowerShell", "Custom")]
        [System.String]
        ${Runtime},

        [Parameter(ParameterSetName='ByLocation', HelpMessage='The function app runtime version.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Path')]
        [System.String]
        ${Version},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow)]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Functions.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend}
    )
    
    process {

        # RegisterFunctionsTabCompleters
        
        # if ($PsCmdlet.ParameterSetName -eq "ByObjectInput")
        # {            
        #     if ($PSBoundParameters.ContainsKey("InputObject"))
        #     {
        #         $PSBoundParameters.Remove("InputObject")  | Out-Null
        #     }

        #     $Name = $InputObject.Name
            
        #     $PSBoundParameters.Add("Name", $Name)  | Out-Null
        #     $PSBoundParameters.Add("ResourceGroupName", $InputObject.ResourceGroupName)  | Out-Null
        #     $PSBoundParameters.Add("SubscriptionId", $InputObject.SubscriptionId)  | Out-Null
        # }

        # if ($PsCmdlet.ShouldProcess($Name, "Get function app settings"))
        # {
        #     $settings = Az.Functions.internal\Get-AzWebAppApplicationSetting @PSBoundParameters
        #     if ($settings)
        #     {
        #         ConvertWebAppApplicationSettingToHashtable -ApplicationSetting $settings -ShowAllAppSettings
        #     }
        # }
        Get-FlexFunctionAppRuntime -Location $Location -Runtime $Runtime -VersionFilter $Version
    }
}
