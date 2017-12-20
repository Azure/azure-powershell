// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSSqlServerSqlDbSelectedDatabase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.DataMigration.Models.DatabaseInfo
{
    public class PSSqlServerSqlDbSelectedDatabase : PSDatabaseInfo
    {
        public string TargetDatabaseName { get; set; }

        public bool MakeSourceDbReadOnly { get; set; }

        public IDictionary<string, string> TableMap { get; set; }
    }
}
