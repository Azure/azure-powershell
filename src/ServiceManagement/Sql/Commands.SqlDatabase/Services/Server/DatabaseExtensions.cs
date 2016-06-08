// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Commands.SqlDatabase.Services.Server
{
    /// <summary>
    /// The <see cref="Database"/> extensions
    /// </summary>
    public partial class Database
    {
        /// <summary>
        /// Gets or sets the context from which this object was constructed.
        /// </summary>
        public IServerDataServiceContext Context;

        /// <summary>
        /// Gets the name of the service objective for this Database.
        /// </summary>
        public string ServiceObjectiveName;

        /// <summary>
        /// Copies all the internal fields from one database object into another.
        /// </summary>
        /// <param name="other">The database to be copied.</param>
        internal void CopyFields(Database other)
        {
            this._CollationName = other._CollationName;
            this._CreationDate = other._CreationDate;
            this._Edition = other._Edition;
            this._Id = other._Id;
            this._MaxSizeGB = other._MaxSizeGB;
            this._MaxSizeBytes = other._MaxSizeBytes;
            this._Name = other._Name;
            this._Server = other._Server;
            this.Context = other.Context;
            this._AssignedServiceObjectiveId = other.AssignedServiceObjectiveId;
            this.ServiceObjective = other.ServiceObjective;
        }
    }
}
