# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Full DataSetMapping CRUD cycle
#>
function Test-BlobDataSetMappingCrud
{
	$resourceGroup = getAssetName

	try
	{
		$AccountName = getAssetName
		$ShareSubscriptionName = getAssetName
		$DataSetMappingName = getAssetName
		$StorageAccountId = getAssetName
		$DataSetId = getAssetName
		$ContainerName = getAssetName
		$createdContainerDatasetMapping = New-AzDataShareDataSetMapping -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareSubscriptionName -Name $DataSetMappingName -StorageAccountResourceId $StorageAccountId -DataSetId $DataSetId -Container $ContainerName

		Assert-NotNull $createdContainerDatasetMapping
		Assert-AreEqual $DataSetMappingName $createdContainerDatasetMapping.Name
		Assert-AreEqual "ok" $createdContainerDatasetMapping.DataSetMappingStatus

		$Prefix = getAssetName
		$createdBlobFolderMapping = New-AzDataShareDataSetMapping -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareSubscriptionName -Name $DataSetMappingName -StorageAccountResourceId $StorageAccountId -DataSetId $DataSetId -Container $ContainerName -FolderPath $Prefix

		Assert-NotNull $createdBlobFolderMapping
		Assert-AreEqual $DataSetMappingName $createdBlobFolderMapping.Name
		Assert-AreEqual "ok" $createdBlobFolderMapping.DataSetMappingStatus

		$FilePath = getAssetName
		$createdBlobMapping = New-AzDataShareDataSetMapping -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareSubscriptionName -Name $DataSetMappingName -StorageAccountResourceId $StorageAccountId -DataSetId $DataSetId -Container $ContainerName -FilePath $FilePath

		Assert-NotNull $createdBlobMapping
		Assert-AreEqual $DataSetMappingName $createdBlobMapping.Name
		Assert-AreEqual "ok" $createdBlobMapping.DataSetMappingStatus

		$retreivedDatasetMapping = Get-AzDataShareDataSetMapping -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareSubscriptionName -Name $DataSetMappingName
	
		Assert-NotNull $retreivedDatasetMapping
		Assert-AreEqual $DataSetMappingName $retreivedDatasetMapping.Name

		$ResourceId = getAssetName
		$retreivedDatasetMapping = Get-AzDataShareDataSetMapping -ResourceId $ResourceId

		Assert-NotNull $retreivedDatasetMapping
		Assert-AreEqual $DataSetMappingName $retreivedDatasetMapping.Name
	}
	finally
	{
		Remove-AzResourceGroup -Name $resourceGroup -Force
	}
}

function Test-AdlsGen2DataSetMappingCrud
{
	$resourceGroup = getAssetName
    $AccountName = getAssetName
	$ShareSubscriptionName = getAssetName
    $DataSetMappingName = getAssetName
	$StorageAccountId = getAssetName
	$DataSetId = getAssetName
	$FileSystemName = getAssetName
	$createdFileSystemDatasetMapping = New-AzDataShareDataSetMapping -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareSubscriptionName -Name $DataSetMappingName -StorageAccountResourceId $StorageAccountId -DataSetId $DataSetId -FileSystem $FileSystemName

	Assert-NotNull $createdFileSystemDatasetMapping
	Assert-AreEqual $DataSetMappingName $createdFileSystemDatasetMapping.Name
	Assert-AreEqual "ok" $createdFileSystemDatasetMapping.DataSetMappingStatus

	$FolderPath = getAssetName
	$createdFolderDatasetMapping = New-AzDataShareDataSetMapping -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareSubscriptionName -Name $DataSetMappingName -StorageAccountResourceId $StorageAccountId -DataSetId $DataSetId -FileSystem $FileSystemName -FolderPath $FolderPath

	Assert-NotNull $createdFolderDatasetMapping
	Assert-AreEqual $DataSetMappingName $createdFolderDatasetMapping.Name
	Assert-AreEqual "ok" $createdFolderDatasetMapping.DataSetMappingStatus

	$FilePath = getAssetName
	$createdFileDataSetMapping = New-AzDataShareDataSetMapping -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareSubscriptionName $ShareSubscriptionName -Name $DataSetMappingName -StorageAccountResourceId $StorageAccountId -DataSetId $DataSetId -FileSystem $FileSystemName -FilePath $FilePath

	Assert-NotNull $createdFileDataSetMapping
	Assert-AreEqual $DataSetMappingName $createdFileDataSetMapping.Name
	Assert-AreEqual "ok" $createdFileDataSetMapping.DataSetMappingStatus
}