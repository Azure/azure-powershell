function Set-AzRmStorageContainerImmutabilityPolicy {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IImmutabilityPolicy')]
    [CmdletBinding(DefaultParameterSetName='Update', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    [Microsoft.Azure.PowerShell.Cmdlets.Storage.Profile('latest-2019-04-30')]
    [Microsoft.Azure.PowerShell.Cmdlets.Storage.Description('Creates or updates an unlocked immutability policy. ETag in If-Match is honored if given but not required for this operation.')]
    param(
        [Parameter(Mandatory, HelpMessage='The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(SerializedName='accountName', Required, PossibleTypes=([System.String]), Description='The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.')]
        [System.String]
        # The name of the storage account within the specified resource group. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
        ${AccountName},

        [Parameter(Mandatory, HelpMessage='The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(SerializedName='containerName', Required, PossibleTypes=([System.String]), Description='The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.')]
        [System.String]
        # The name of the blob container within the specified storage account. Blob container names must be between 3 and 63 characters in length and use numbers, lower-case letters and dash (-) only. Every dash (-) character must be immediately preceded and followed by a letter or number.
        ${ContainerName},

        [Parameter(Mandatory, HelpMessage='The name of the resource group within the user''s subscription. The name is case insensitive.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(SerializedName='resourceGroupName', Required, PossibleTypes=([System.String]), Description='The name of the resource group within the user''s subscription. The name is case insensitive.')]
        [System.String]
        # The name of the resource group within the user's subscription. The name is case insensitive.
        ${ResourceGroupName},

        [Parameter(Mandatory, HelpMessage='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(SerializedName='subscriptionId', Required, PossibleTypes=([System.String]), Description='The ID of the target subscription.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # The ID of the target subscription.
        ${SubscriptionId},

        [Parameter(HelpMessage='The entity state (ETag) version of the immutability policy to update. A value of "*" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Header')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(SerializedName='If-Match', PossibleTypes=([System.String]), Description='The entity state (ETag) version of the immutability policy to update. A value of "*" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.')]
        [System.String]
        # The entity state (ETag) version of the immutability policy to update. A value of "*" can be used to apply the operation only if the immutability policy already exists. If omitted, this operation will always be applied.
        ${IfMatch},

        [Parameter(ParameterSetName='Update', ValueFromPipeline, HelpMessage='The ImmutabilityPolicy property of a blob container, including Id, resource name, resource type, Etag. To construct, see NOTES section for PARAMETER properties and create a hash table.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(SerializedName='parameters', PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IImmutabilityPolicy]), Description='The ImmutabilityPolicy property of a blob container, including Id, resource name, resource type, Etag.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.Api20180201.IImmutabilityPolicy]
        # The ImmutabilityPolicy property of a blob container, including Id, resource name, resource type, Etag.
        # To construct, see NOTES section for PARAMETER properties and create a hash table.
        ${Parameter},

        [Parameter(ParameterSetName='UpdateExpanded', Mandatory, HelpMessage='The immutability period for the blobs in the container since the policy creation, in days.')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Body')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.Info(SerializedName='body', Required, PossibleTypes=([System.Int32]), Description='The immutability period for the blobs in the container since the policy creation, in days.')]
        [System.Int32]
        # The immutability period for the blobs in the container since the policy creation, in days.
        ${ImmutabilityPeriod},

        [Parameter(HelpMessage='The credentials, account, tenant, and subscription used for communication with Azure.')]
        [Alias('AzureRMContext', 'AzureCredential')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Azure')]
        [System.Management.Automation.PSObject]
        # The credentials, account, tenant, and subscription used for communication with Azure.
        ${DefaultProfile},

        [Parameter(DontShow, HelpMessage='Wait for .NET debugger to attach')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Wait for .NET debugger to attach
        ${Break},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be appended to the front of the pipeline
        ${HttpPipelineAppend},

        [Parameter(DontShow, HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Runtime.SendAsyncStep[]]
        # SendAsync Pipeline Steps to be prepended to the front of the pipeline
        ${HttpPipelinePrepend},

        [Parameter(DontShow, HelpMessage='The URI for the proxy server to use')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Uri]
        # The URI for the proxy server to use
        ${Proxy},

        [Parameter(DontShow, HelpMessage='Credentials for a proxy server to use for the remote call')]
        [ValidateNotNull()]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Management.Automation.PSCredential]
        # Credentials for a proxy server to use for the remote call
        ${ProxyCredential},

        [Parameter(DontShow, HelpMessage='Use the default credentials for the proxy')]
        [Microsoft.Azure.PowerShell.Cmdlets.Storage.Category('Runtime')]
        [System.Management.Automation.SwitchParameter]
        # Use the default credentials for the proxy
        ${ProxyUseDefaultCredentials},

        [Parameter(HelpMessage='Indicate ExtendPolicy to Extend an existing ImmutabilityPolicy. After ImmutabilityPolicy is locked, it can only be extend.')]
        [System.Management.Automation.SwitchParameter]
        ${ExtendPolicy}
    )
    process {
        if ($PSBoundParameters.ContainsKey("ExtendPolicy")) {
            $null = $PSBoundParameters.Remove("ExtendPolicy")
            Az.Storage.internal\Invoke-AzExtendBlobContainerImmutabilityPolicy @PSBoundParameters
        } else {
            Az.Storage.internal\Set-AzRmStorageContainerImmutabilityPolicy @PSBoundParameters
        }   
    }
}
