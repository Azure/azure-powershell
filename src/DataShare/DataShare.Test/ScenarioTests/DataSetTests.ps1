# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Full DataSet CRUD cycle
#>
function Test-DataSetCrud
{
	try
	{
		$resourceGroup = getAssetName
		$AccountName = getAssetName
		$ShareName = getAssetName
		$DataSetName = getAssetName
		$StorageAccountId = getAssetName
		$ContainerName = getAssetName
		$createdContainerDataset = New-AzDataShareDataSet -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $DataSetName -StorageAccountResourceId $StorageAccountId -Container $ContainerName

		Assert-NotNull $createdContainerDataset
		Assert-AreEqual $DataSetName $createdContainerDataset.Name
	
		$Prefix = getAssetName
		$createdBlobFolder = New-AzDataShareDataSet -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $DataSetName -StorageAccountResourceId $StorageAccountId -Container $ContainerName -FolderPath $Prefix

		Assert-NotNull $createdBlobFolder
		Assert-AreEqual $DataSetName $createdBlobFolder.Name

		$FilePath = getAssetName
		$createdBlob = New-AzDataShareDataSet -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $DataSetName -StorageAccountResourceId $StorageAccountId -Container $ContainerName -FilePath $FilePath

		Assert-NotNull $createdBlob
		Assert-AreEqual $DataSetName $createdBlob.Name

		$retreivedDataset = Get-AzDataShareDataSet -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $DataSetName

		Assert-NotNull $retreivedDataset
		Assert-AreEqual $DataSetName $retreivedDataset.Name

		$ResourceId = getAssetName
		$retreivedDataset = Get-AzDataShareDataSet -ResourceId $ResourceId

		Assert-NotNull $retreivedDataset
		Assert-AreEqual $DataSetName $retreivedDataset.Name
	}
	finally
	{
		Remove-AzResourceGroup -Name $resourceGroup -Force
	}
}
