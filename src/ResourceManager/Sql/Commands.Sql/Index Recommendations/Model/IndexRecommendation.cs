using System;
using Microsoft.Azure.Management.Sql.Models;

namespace Microsoft.Azure.Commands.Sql.Model
{
    public class IndexRecommendation : RecommendedIndexProperties
    {
        /// <summary>
        /// Copy constructor from base class
        /// </summary>
        /// <param name="other">Source object</param>
        public IndexRecommendation(RecommendedIndexProperties other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            this.Action = other.Action;
            this.Columns = other.Columns;
            this.Created = other.Created;
            this.EstimatedImpact = other.EstimatedImpact;
            this.IncludedColumns = other.IncludedColumns;
            this.IndexScript = other.IndexScript;
            this.IndexType = other.IndexType;
            this.LastModified = other.LastModified;
            this.ReportedImpact = other.ReportedImpact;
            this.Schema = other.Schema;
            this.State = other.State;
            this.Table = other.Table;
            this.Columns = other.Columns;
        }

        /// <summary>
        /// Azure SQL Database name on which this index should be created.
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// Name of recommended index.
        /// </summary>
        public string Name { get; set; }
    }
}
