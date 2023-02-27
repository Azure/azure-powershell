function New-AzDeployment {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IDeploymentExtended')]
    [CmdletBinding(DefaultParameterSetName='CreateWithTemplateFileParameterFile', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Resources.Description('You can provide the template and parameters directly in the request or link to JSON files.')]
    param(
        [Parameter(HelpMessage='The name of the deployment. If not provided, the name of the template file will be used. If a template file is not used, a random GUID will be used for the name.')]
        [Alias('DeploymentName')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='deploymentName', Required, PossibleTypes=([System.String]), Description='The name of the deployment.')]
        [System.String]
        # The name of the deployment. If not provided, the name of the template file will be used. If a template file is not used, a random GUID will be used for the name.
        ${Name},

        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(ParameterSetName='CreateRGWithTemplateFileParameterFile', Mandatory, HelpMessage='The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateFileParameterJson', Mandatory, HelpMessage='The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateFileParameterObject', Mandatory, HelpMessage='The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateJsonParameterFile', Mandatory, HelpMessage='The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateJsonParameterJson', Mandatory, HelpMessage='The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateJsonParameterObject', Mandatory, HelpMessage='The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateObjectParameterFile', Mandatory, HelpMessage='The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateObjectParameterJson', Mandatory, HelpMessage='The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateObjectParameterObject', Mandatory, HelpMessage='The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.')]
        [System.String]
        # The name of the resource group to deploy the resources to. The name is case insensitive. The resource group must already exist.
        ${ResourceGroupName},

        [Parameter(ParameterSetName='CreateWithTemplateFileParameterFile', Mandatory, HelpMessage='Local path to the JSON template file.')]
        [Parameter(ParameterSetName='CreateWithTemplateFileParameterJson', Mandatory, HelpMessage='Local path to the JSON template file.')]
        [Parameter(ParameterSetName='CreateWithTemplateFileParameterObject', Mandatory, HelpMessage='Local path to the JSON template file.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateFileParameterFile', Mandatory, HelpMessage='Local path to the JSON template file.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateFileParameterJson', Mandatory, HelpMessage='Local path to the JSON template file.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateFileParameterObject', Mandatory, HelpMessage='Local path to the JSON template file.')]
        [System.String]
        # Local path to the JSON template file.
        ${TemplateFile},

        [Parameter(ParameterSetName='CreateWithTemplateJsonParameterFile', Mandatory, HelpMessage='The string representation of the JSON template.')]
        [Parameter(ParameterSetName='CreateWithTemplateJsonParameterJson', Mandatory, HelpMessage='The string representation of the JSON template.')]
        [Parameter(ParameterSetName='CreateWithTemplateJsonParameterObject', Mandatory, HelpMessage='The string representation of the JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateJsonParameterFile', Mandatory, HelpMessage='The string representation of the JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateJsonParameterJson', Mandatory, HelpMessage='The string representation of the JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateJsonParameterObject', Mandatory, HelpMessage='The string representation of the JSON template.')]
        [System.String]
        # The string representation of the JSON template.
        ${TemplateJson},

        [Parameter(ParameterSetName='CreateWithTemplateObjectParameterFile', Mandatory, HelpMessage='The hashtable representation of the JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateObjectParameterFile', Mandatory, HelpMessage='The hashtable representation of the JSON template.')]
        [Parameter(ParameterSetName='CreateWithTemplateObjectParameterJson', Mandatory, HelpMessage='The hashtable representation of the JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateObjectParameterJson', Mandatory, HelpMessage='The hashtable representation of the JSON template.')]
        [Parameter(ParameterSetName='CreateWithTemplateObjectParameterObject', Mandatory, HelpMessage='The hashtable representation of the JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateObjectParameterObject', Mandatory, HelpMessage='The hashtable representation of the JSON template.')]
        [System.Collections.Hashtable]
        # The hashtable representation of the JSON template.
        ${TemplateObject},

        [Parameter(ParameterSetName='CreateWithTemplateFileParameterFile', Mandatory, HelpMessage='Local path to the parameter JSON template file.')]
        [Parameter(ParameterSetName='CreateWithTemplateJsonParameterFile', Mandatory, HelpMessage='Local path to the parameter JSON template file.')]
        [Parameter(ParameterSetName='CreateWithTemplateObjectParameterFile', Mandatory, HelpMessage='Local path to the parameter JSON template file.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateFileParameterFile', Mandatory, HelpMessage='Local path to the parameter JSON template file.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateJsonParameterFile', Mandatory, HelpMessage='Local path to the parameter JSON template file.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateObjectParameterFile', Mandatory, HelpMessage='Local path to the parameter JSON template file.')]
        [System.String]
        # Local path to the parameter JSON template file.
        ${TemplateParameterFile},

        [Parameter(ParameterSetName='CreateWithTemplateFileParameterJson', Mandatory, HelpMessage='The string representation of the parameter JSON template.')]
        [Parameter(ParameterSetName='CreateWithTemplateJsonParameterJson', Mandatory, HelpMessage='The string representation of the parameter JSON template.')]
        [Parameter(ParameterSetName='CreateWithTemplateObjectParameterJson', Mandatory, HelpMessage='The string representation of the parameter JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateFileParameterJson', Mandatory, HelpMessage='The string representation of the parameter JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateJsonParameterJson', Mandatory, HelpMessage='The string representation of the parameter JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateObjectParameterJson', Mandatory, HelpMessage='The string representation of the parameter JSON template.')]
        [System.String]
        # The string representation of the parameter JSON template.
        ${TemplateParameterJson},

        [Parameter(ParameterSetName='CreateWithTemplateFileParameterObject', Mandatory, HelpMessage='The hashtable representation of the parameter JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateFileParameterObject', Mandatory, HelpMessage='The hashtable representation of the parameter JSON template.')]
        [Parameter(ParameterSetName='CreateWithTemplateJsonParameterObject', Mandatory, HelpMessage='The hashtable representation of the parameter JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateJsonParameterObject', Mandatory, HelpMessage='The hashtable representation of the parameter JSON template.')]
        [Parameter(ParameterSetName='CreateWithTemplateObjectParameterObject', Mandatory, HelpMessage='The hashtable representation of the parameter JSON template.')]
        [Parameter(ParameterSetName='CreateRGWithTemplateObjectParameterObject', Mandatory, HelpMessage='The hashtable representation of the parameter JSON template.')]
        [System.Collections.Hashtable]
        # The hashtable representation of the parameter JSON template.
        ${TemplateParameterObject},

        [Parameter(Mandatory, HelpMessage='The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources.')]
        [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.DeploymentMode])]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='mode', Required, PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.DeploymentMode]), Description='The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Support.DeploymentMode]
        # The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources.
        ${Mode},

        [Parameter(HelpMessage='Specifies the type of information to log for debugging. The permitted values are none, requestContent, responseContent, or both requestContent and responseContent separated by a comma. The default is none. When setting this value, carefully consider the type of information you are passing in during deployment. By logging information about the request or response, you could potentially expose sensitive data that is retrieved through the deployment operations.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='detailLevel', PossibleTypes=([System.String]), Description='Specifies the type of information to log for debugging. The permitted values are none, requestContent, responseContent, or both requestContent and responseContent separated by a comma. The default is none. When setting this value, carefully consider the type of information you are passing in during deployment. By logging information about the request or response, you could potentially expose sensitive data that is retrieved through the deployment operations.')]
        [System.String]
        # Specifies the type of information to log for debugging. The permitted values are none, requestContent, responseContent, or both requestContent and responseContent separated by a comma. The default is none. When setting this value, carefully consider the type of information you are passing in during deployment. By logging information about the request or response, you could potentially expose sensitive data that is retrieved through the deployment operations.
        ${DeploymentDebugLogLevel},

        [Parameter(HelpMessage='The location to store the deployment data.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Runtime.Info(SerializedName='location', PossibleTypes=([System.String]), Description='The location to store the deployment data.')]
        [System.String]
        # The location to store the deployment data.
        ${Location},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(HelpMessage='Run the command as a job')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command as a job
        ${AsJob},

        [Parameter(HelpMessage='Run the command asynchronously')]
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Run the command asynchronously
        ${NoWait}

    )

    process {
        if ($PSBoundParameters.ContainsKey("TemplateFile"))
        {
            if (!(Test-Path -Path $TemplateFile))
            {
                throw "Unable to find template file '$TemplateFile'."
            }

            if (!$PSBoundParameters.ContainsKey("Name"))
            {
                $DeploymentName = (Get-Item -Path $TemplateFile).BaseName
                $null = $PSBoundParameters.Add("Name", $DeploymentName)
            }

            $TemplateJson = [System.IO.File]::ReadAllText($TemplateFile)
            $null = $PSBoundParameters.Add("Template", $TemplateJson)
            $null = $PSBoundParameters.Remove("TemplateFile")
        }
        elseif ($PSBoundParameters.ContainsKey("TemplateJson"))
        {
            $null = $PSBoundParameters.Add("Template", $TemplateJson)
            $null = $PSBoundParameters.Remove("TemplateJson")
        }
        elseif ($PSBoundParameters.ContainsKey("TemplateObject"))
        {
            $TemplateJson = ConvertTo-Json -InputObject $TemplateObject
            $null = $PSBoundParameters.Add("Template", $TemplateJson)
            $null = $PSBoundParameters.Remove("TemplateObject")
        }

        if ($PSBoundParameters.ContainsKey("TemplateParameterFile"))
        {
            if (!(Test-Path -Path $TemplateParameterFile))
            {
                throw "Unable to find template parameter file '$TemplateParameterFile'."
            }

            $ParameterJson = [System.IO.File]::ReadAllText($TemplateParameterFile)
            $ParameterObject = ConvertFrom-Json -InputObject $ParameterJson
            $ParameterHashtable = @{}
            $ParameterObject.PSObject.Properties | ForEach-Object { $ParameterHashtable[$_.Name] = $_.Value }
            $ParameterHashtable.Remove("`$schema")
            $ParameterHashtable.Remove("contentVersion")
            $NestedValues = $ParameterHashtable.parameters
            if ($null -ne $NestedValues)
            {
                $ParameterHashtable.Remove("parameters")
                $NestedValues.PSObject.Properties | ForEach-Object { $ParameterHashtable[$_.Name] = $_.Value }
            }

            $ParameterJson = ConvertTo-Json -InputObject $ParameterHashtable
            $null = $PSBoundParameters.Add("DeploymentPropertyParameter", $ParameterJson)
            $null = $PSBoundParameters.Remove("TemplateParameterFile")
        }
        elseif ($PSBoundParameters.ContainsKey("TemplateParameterJson"))
        {
            $null = $PSBoundParameters.Add("DeploymentPropertyParameter", $TemplateParameterJson)
            $null = $PSBoundParameters.Remove("TemplateParameterJson")
        }
        elseif ($PSBoundParameters.ContainsKey("TemplateParameterObject"))
        {
            $TemplateParameterObject.Remove("`$schema")
            $TemplateParameterObject.Remove("contentVersion")
            $NestedValues = $TemplateParameterObject.parameters
            if ($null -ne $NestedValues)
            {
                $TemplateParameterObject.Remove("parameters")
                $NestedValues.PSObject.Properties | ForEach-Object { $TemplateParameterObject[$_.Name] = $_.Value }
            }

            $TemplateParameterJson = ConvertTo-Json -InputObject $TemplateParameterObject
            $null = $PSBoundParameters.Add("DeploymentPropertyParameter", $TemplateParameterJson)
            $null = $PSBoundParameters.Remove("TemplateParameterObject")
        }

        if (!$PSBoundParameters.ContainsKey("Name"))
        {
            $DeploymentName = (New-Guid).Guid
            $null = $PSBoundParameters.Add("Name", $DeploymentName)
        }

        if ($PSBoundParameters.ContainsKey("ResourceGroupName"))
        {
            Az.Resources.TestSupport.private\New-AzDeployment_CreateExpanded @PSBoundParameters
        }
        else
        {
            Az.Resources.TestSupport.private\New-AzDeployment_CreateExpanded @PSBoundParameters
        }
    }
}