


function Prepare-AzDataProtectionDatasourceInfo {
    [OutputType('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.IDatasource')]
    [CmdletBinding(PositionalBinding=$false, SupportsShouldProcess)]
    [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Description('Prepares Datasource object for backup')]

    param(
        [Parameter(ParameterSetName='GetById', Mandatory, HelpMessage='Location of Datasource')]
        [Parameter(ParameterSetName='GetByName', Mandatory, HelpMessage='Location of Datasource')]
        [System.String]
        # ...
        ${Location},

        [Parameter(ParameterSetName='GetById', Mandatory, HelpMessage='ARM ID of the datasource to be protected')]
        [System.String]
        # ...
        ${DatasourceId},

        [Parameter(ParameterSetName='GetById', Mandatory, HelpMessage='Datasource Type')]
        [Parameter(ParameterSetName='GetByName', Mandatory, HelpMessage='Datasource Type')]
        [System.String]
        [ValidateSet("PostGreSQLServer", "AzureBlob", IgnoreCase = $true)]
        # ...
        ${DatasourceType},

        [Parameter(ParameterSetName='GetByName', Mandatory, HelpMessage='Name the datasource to be protected')]
        [System.String]
        # ...
        ${Name},

        [Parameter(ParameterSetName='GetByName', Mandatory, HelpMessage='Subscription ID of the datasource to be protected')]
        [System.String]
        # ...
        ${SubscriptionId},

        [Parameter(ParameterSetName='GetByName', Mandatory, HelpMessage='ResourceGroup of the datasource to be protected')]
        [System.String]
        # ...
        ${ResourceGroup},

        [Parameter(ParameterSetName='GetByName', HelpMessage='Server name of the datasource to be protected')]
        [System.String]
        # ...
        ${ParentServerName}
    )

    process {

        $datasource = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api202001Alpha.Datasource]::new()
        $datasourceTypeMap = @{PostGreSQLServer = "Microsoft.DBforPostgreSQL/servers/databases"; AzureBlob = "Microsoft.Storage/storageAccounts/blobServices"}
        if($PSBoundParameters.ContainsKey("DatasourceId")){
            $datasource.ObjectType = "Datasource"
            $datasource.ResourceId = $DatasourceId
            $datasource.ResourceLocation = $Location
            $datasource.ResourceName = $DatasourceId.Split("/")[-1]
            $datasource.ResourceType = $datasourceTypeMap[$DatasourceType]
            $datasource.ResourceUri = ""
            $datasource.Type = $datasourceTypeMap[$DatasourceType]
        }

        $datasource
       
    }
}