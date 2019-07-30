# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.SYNOPSIS
Full DataSet ADLSGen2 CRUD cycle
#>
function Test-AdlsGen2Crud
{
	$resourceGroup = getAssetName

	try
	{
		$AccountName = getAssetName
		$ShareName = getAssetName
		$DataSetName = getAssetName
		$StorageAccountId = getAssetName
		$FileSystemName = getAssetName
		$createdFileSystemDataset = New-AzDataShareDataSet -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $DataSetName -StorageAccountResourceId $StorageAccountId -FileSystem $FileSystemName

		Assert-NotNull $createdFileSystemDataset
		Assert-AreEqual $DataSetName $createdFileSystemDataset.Name

		$FolderPath = getAssetName
		$createdFolderDataset = New-AzDataShareDataSet -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $DataSetName -StorageAccountResourceId $StorageAccountId -FileSystem $FileSystemName -FolderPath $FolderPath

		Assert-NotNull $createdFolderDataset
		Assert-AreEqual $DataSetName $createdFolderDataset.Name

		$FilePath = getAssetName
		$createdFileDataSet = New-AzDataShareDataSet -ResourceGroupName $resourceGroup -AccountName $AccountName -ShareName $ShareName -Name $DataSetName -StorageAccountResourceId $StorageAccountId -FileSystem $FileSystemName -FilePath $FilePath

		Assert-NotNull $createdFileDataSet
		Assert-AreEqual $DataSetName $createdFileDataSet.Name
	}
	finally
	{
		Remove-AzResourceGroup -Name $resourceGroup -Force
	}
}