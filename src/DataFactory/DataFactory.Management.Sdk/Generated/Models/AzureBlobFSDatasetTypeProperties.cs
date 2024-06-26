// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using System.Linq;

    /// <summary>
    /// Azure Data Lake Storage Gen2 dataset properties.
    /// </summary>
    public partial class AzureBlobFSDatasetTypeProperties
    {
        /// <summary>
        /// Initializes a new instance of the AzureBlobFSDatasetTypeProperties class.
        /// </summary>
        public AzureBlobFSDatasetTypeProperties()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the AzureBlobFSDatasetTypeProperties class.
        /// </summary>

        /// <param name="folderPath">The path of the Azure Data Lake Storage Gen2 storage. Type: string (or
        /// Expression with resultType string).
        /// </param>

        /// <param name="fileName">The name of the Azure Data Lake Storage Gen2. Type: string (or Expression
        /// with resultType string).
        /// </param>

        /// <param name="format">The format of the Azure Data Lake Storage Gen2 storage.
        /// </param>

        /// <param name="compression">The data compression method used for the blob storage.
        /// </param>
        public AzureBlobFSDatasetTypeProperties(object folderPath = default(object), object fileName = default(object), DatasetStorageFormat format = default(DatasetStorageFormat), DatasetCompression compression = default(DatasetCompression))

        {
            this.FolderPath = folderPath;
            this.FileName = fileName;
            this.Format = format;
            this.Compression = compression;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the path of the Azure Data Lake Storage Gen2 storage. Type:
        /// string (or Expression with resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "folderPath")]
        public object FolderPath {get; set; }

        /// <summary>
        /// Gets or sets the name of the Azure Data Lake Storage Gen2. Type: string (or
        /// Expression with resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "fileName")]
        public object FileName {get; set; }

        /// <summary>
        /// Gets or sets the format of the Azure Data Lake Storage Gen2 storage.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "format")]
        public DatasetStorageFormat Format {get; set; }

        /// <summary>
        /// Gets or sets the data compression method used for the blob storage.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "compression")]
        public DatasetCompression Compression {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {



            if (this.Compression != null)
            {
                this.Compression.Validate();
            }
        }
    }
}