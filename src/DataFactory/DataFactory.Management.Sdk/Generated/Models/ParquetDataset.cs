// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataFactory.Models
{
    using System.Linq;

    /// <summary>
    /// Parquet dataset.
    /// </summary>
    [Newtonsoft.Json.JsonObject("Parquet")]
    [Microsoft.Rest.Serialization.JsonTransformation]
    public partial class ParquetDataset : Dataset
    {
        /// <summary>
        /// Initializes a new instance of the ParquetDataset class.
        /// </summary>
        public ParquetDataset()
        {
            this.LinkedServiceName = new LinkedServiceReference();
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ParquetDataset class.
        /// </summary>

        /// <param name="additionalProperties">The Azure Data Factory nested object which identifies data within different
        /// data stores, such as tables, files, folders, and documents.
        /// </param>

        /// <param name="description">Dataset description.
        /// </param>

        /// <param name="structure">Columns that define the structure of the dataset. Type: array (or
        /// Expression with resultType array), itemType: DatasetDataElement.
        /// </param>

        /// <param name="schema">Columns that define the physical type schema of the dataset. Type: array
        /// (or Expression with resultType array), itemType: DatasetSchemaDataElement.
        /// </param>

        /// <param name="linkedServiceName">Linked service reference.
        /// </param>

        /// <param name="parameters">Parameters for dataset.
        /// </param>

        /// <param name="annotations">List of tags that can be used for describing the Dataset.
        /// </param>

        /// <param name="folder">The folder that this Dataset is in. If not specified, Dataset will appear
        /// at the root level.
        /// </param>

        /// <param name="location">The location of the parquet storage.
        /// </param>

        /// <param name="compressionCodec">The data compressionCodec. Type: string (or Expression with resultType
        /// string).
        /// </param>
        public ParquetDataset(LinkedServiceReference linkedServiceName, System.Collections.Generic.IDictionary<string, object> additionalProperties = default(System.Collections.Generic.IDictionary<string, object>), string description = default(string), object structure = default(object), object schema = default(object), System.Collections.Generic.IDictionary<string, ParameterSpecification> parameters = default(System.Collections.Generic.IDictionary<string, ParameterSpecification>), System.Collections.Generic.IList<object> annotations = default(System.Collections.Generic.IList<object>), DatasetFolder folder = default(DatasetFolder), DatasetLocation location = default(DatasetLocation), object compressionCodec = default(object))

        : base(linkedServiceName, additionalProperties, description, structure, schema, parameters, annotations, folder)
        {
            this.Location = location;
            this.CompressionCodec = compressionCodec;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets the location of the parquet storage.
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "typeProperties.location")]
        public DatasetLocation Location {get; set; }

        /// <summary>
        /// Gets or sets the data compressionCodec. Type: string (or Expression with
        /// resultType string).
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "typeProperties.compressionCodec")]
        public object CompressionCodec {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();


        }
    }
}