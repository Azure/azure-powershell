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

using Microsoft.Azure.Management.CosmosDB.Models;

namespace Microsoft.Azure.Commands.CosmosDB.Models
{

    public class PSIndexes
    {
        public PSIndexes()
        {
        }

        public PSIndexes(Indexes indexes )
        {
            DataType = indexes.DataType;
            Precision = indexes.Precision;
            Kind = indexes.Kind;
        }

        //
        // Summary:
        //     Gets or sets the datatype for which the indexing behavior is applied to. Possible
        //     values include: 'String', 'Number', 'Point', 'Polygon', 'LineString', 'MultiPolygon'
        public string DataType { get; set; }
        //
        // Summary:
        //     Gets or sets the precision of the index. -1 is maximum precision.
        public int? Precision { get; set; }
        //
        // Summary:
        //     Gets or sets indicates the type of index. Possible values include: 'Hash', 'Range',
        //     'Spatial'
        public string Kind { get; set; }

        static public Indexes ConvertPSIndexesToIndexes(PSIndexes pSIndexes)
        {
            return new Indexes
            {
                DataType = pSIndexes.DataType,
                Precision = pSIndexes.Precision,
                Kind = pSIndexes.Kind
            };
        }
    }
}
