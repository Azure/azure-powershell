// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PSDatabaseInfo.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.DataMigration.Models
{
    public abstract class PSDatabaseInfo
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
