// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.

namespace Microsoft.Azure.Management.DataMigration.Models
{
    using System.Linq;

    /// <summary>
    /// Input for the task that collects user tables for the given list of
    /// databases
    /// </summary>
    public partial class GetUserTablesSqlTaskInput
    {
        /// <summary>
        /// Initializes a new instance of the GetUserTablesSqlTaskInput class.
        /// </summary>
        public GetUserTablesSqlTaskInput()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GetUserTablesSqlTaskInput class.
        /// </summary>

        /// <param name="connectionInfo">Connection information for SQL Server
        /// </param>

        /// <param name="selectedDatabases">List of database names to collect tables for
        /// </param>
        public GetUserTablesSqlTaskInput(SqlConnectionInfo connectionInfo, System.Collections.Generic.IList<string> selectedDatabases)

        {
            this.ConnectionInfo = connectionInfo;
            this.SelectedDatabases = selectedDatabases;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();


        /// <summary>
        /// Gets or sets connection information for SQL Server
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "connectionInfo")]
        public SqlConnectionInfo ConnectionInfo {get; set; }

        /// <summary>
        /// Gets or sets list of database names to collect tables for
        /// </summary>
        [Newtonsoft.Json.JsonProperty(PropertyName = "selectedDatabases")]
        public System.Collections.Generic.IList<string> SelectedDatabases {get; set; }
        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (this.ConnectionInfo == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "ConnectionInfo");
            }
            if (this.SelectedDatabases == null)
            {
                throw new Microsoft.Rest.ValidationException(Microsoft.Rest.ValidationRules.CannotBeNull, "SelectedDatabases");
            }
            if (this.ConnectionInfo != null)
            {
                this.ConnectionInfo.Validate();
            }

        }
    }
}