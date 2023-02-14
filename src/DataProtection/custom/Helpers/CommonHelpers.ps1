
function GetDatasourceSetInfo
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
<<<<<<< HEAD
		[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.IDatasource]
=======
		[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.IDatasource]
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
		$DatasourceInfo
	)

	process 
	{
<<<<<<< HEAD
		$DataSourceSetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.DatasourceSet]::new()
=======
		$DataSourceSetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.DatasourceSet]::new()
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
		$DataSourceSetInfo.DatasourceType = $DatasourceInfo.Type
        $DataSourceSetInfo.ObjectType = "DatasourceSet"
        $splitResourceId = $DatasourceInfo.ResourceId.Split("/")
        $DataSourceSetInfo.ResourceId =  [System.String]::Join('/', $splitResourceId[0..($splitResourceId.Count -3)]) 
        $DataSourceSetInfo.ResourceLocation = $DatasourceInfo.ResourceLocation
        $DataSourceSetInfo.ResourceName = $splitResourceId[$splitResourceId.Count -3]
        $splitResourceType = $DatasourceInfo.ResourceType.Split("/")
        $DataSourceSetInfo.ResourceType =  [System.String]::Join('/', $splitResourceType[0..($splitResourceType.Count -2)])     # Use manifest for datasource set type
        $DataSourceSetInfo.ResourceUri = ""

		return $DataSourceSetInfo
	}
}

function GetDatasourceInfo
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$ResourceId,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$ResourceLocation,

		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$DatasourceType
	)

	process
	{

		$manifest = LoadManifest -DatasourceType $DatasourceType.ToString()
<<<<<<< HEAD
		$DataSourceInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20220501.Datasource]::new()
=======
		$DataSourceInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Api20221201.Datasource]::new()
>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
		$DataSourceInfo.ObjectType = "Datasource"
        $DataSourceInfo.ResourceId = $ResourceId
        $DataSourceInfo.ResourceLocation = $ResourceLocation
        $DataSourceInfo.ResourceName = $ResourceId.Split("/")[-1]
        $DataSourceInfo.ResourceType = $manifest.resourceType
        $DataSourceInfo.ResourceUri = ""

        if($manifest.isProxyResource -eq $false)
        {
            $DataSourceInfo.ResourceUri = $ResourceId
        }

        $DataSourceInfo.Type = $manifest.datasourceType

		return $DataSourceInfo
	}
}

function GetClientDatasourceType
{
	[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.DoNotExportAttribute()]
	param(
		[Parameter(Mandatory=$true)]
		[ValidateNotNullOrEmpty()]
		[System.String]
		$ServiceDatasourceType
	)

	process
	{
		$datasourceTypes = GetDatasourceTypes
		foreach($datasourceInfo in $datasourceTypes.supportedDatasourceTypes)
		{
			if($datasourceInfo.serviceDatasourceType -eq $ServiceDatasourceType)
			{
				return $datasourceInfo.clientDatasourceType
			}
		}
		return ""
	}
}