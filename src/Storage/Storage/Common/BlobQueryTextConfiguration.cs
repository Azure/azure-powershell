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

using Azure.Storage.Blobs.Models;
using System.Collections.Generic;

namespace Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel
{
    /// <summary>
    /// Enum to define the type of BlobQueryConfig
    /// </summary>
    public enum BlobQueryConfigType
    {
        Csv,
        Json
    }

    /// <summary>
    ///  Wrapper Class for PSBlobQueryTextConfiguration, BlobQueryCsvTextConfiguration, BlobQueryJsonTextConfiguration
    /// </summary>
    public abstract class PSBlobQueryTextConfiguration
    {
        public BlobQueryConfigType Type { get; set; }
        public string RecordSeparator { get; set; }       

        public BlobQueryTextConfiguration ParseBlobQueryTextConfiguration()
        {
            if (this.Type == BlobQueryConfigType.Csv) //csv
            {
                PSBlobQueryCsvTextConfiguration csvconfig = (PSBlobQueryCsvTextConfiguration)this;
                return new BlobQueryCsvTextConfiguration()
                {
                    RecordSeparator = csvconfig.RecordSeparator,
                    ColumnSeparator = csvconfig.ColumnSeparator,
                    QuotationCharacter = csvconfig.QuotationCharacter,
                    EscapeCharacter = csvconfig.EscapeCharacter,
                    HasHeaders = csvconfig.HasHeaders
                };
            }
            else //json
            {
                PSBlobQueryJsonTextConfiguration jsonconfig = (PSBlobQueryJsonTextConfiguration)this;
                return new BlobQueryJsonTextConfiguration()
                {
                    RecordSeparator = jsonconfig.RecordSeparator
                };
            }
        }
    }

    /// <summary>
    ///  Wrapper Class for BlobQueryJsonTextConfiguration
    /// </summary>
    public class PSBlobQueryJsonTextConfiguration : PSBlobQueryTextConfiguration
    {
        public PSBlobQueryJsonTextConfiguration() { }

        public PSBlobQueryJsonTextConfiguration(BlobQueryJsonTextConfiguration config)
        {
            this.RecordSeparator = config.RecordSeparator;
            this.Type = BlobQueryConfigType.Json;
        }

        public BlobQueryJsonTextConfiguration ParseBlobQueryJsonTextConfiguration()
        {
            return new BlobQueryJsonTextConfiguration()
            {
                RecordSeparator = this.RecordSeparator
            };
        }
    }

    /// <summary>
    ///  Wrapper Class for BlobQueryCsvTextConfiguration
    /// </summary>
    public class PSBlobQueryCsvTextConfiguration : PSBlobQueryTextConfiguration
    {
        public string ColumnSeparator { get; set; }
        public char? QuotationCharacter { get; set; }
        public char? EscapeCharacter { get; set; }
        public bool HasHeaders { get; set; }


        public PSBlobQueryCsvTextConfiguration() { }

        public PSBlobQueryCsvTextConfiguration(BlobQueryCsvTextConfiguration config)
        {
            this.RecordSeparator = config.RecordSeparator;
            this.ColumnSeparator = config.ColumnSeparator;
            this.QuotationCharacter = config.QuotationCharacter;
            this.EscapeCharacter = config.EscapeCharacter;
            this.HasHeaders = config.HasHeaders;
            this.Type = BlobQueryConfigType.Csv;
        }

        public BlobQueryCsvTextConfiguration ParseBlobQueryCsvTextConfiguration()
        {
            return new BlobQueryCsvTextConfiguration()
            {
                RecordSeparator = this.RecordSeparator,
                ColumnSeparator = this.ColumnSeparator,
                QuotationCharacter = this.QuotationCharacter,
                EscapeCharacter = this.EscapeCharacter,
                HasHeaders = this.HasHeaders
            };
        }
    }

    /// <summary>
    /// Wrapper of BlobQueryError
    /// </summary>
    public class PSBlobQueryError
    {
        public string Name { get; }
        public string Description { get; }
        public bool IsFatal { get; }
        public long Position { get; }

        public PSBlobQueryError (BlobQueryError error)
        {
            this.Name = error.Name;
            this.Description = error.Description;
            this.IsFatal = error.IsFatal;
            this.Position = error.Position;
        }
    }

    /// <summary>
    /// Used to output the query result, which include scanned bytes and errors
    /// </summary>
    public class BlobQueryOutput
    {
        public long BytesScanned { get; set; }
        public int FailureCount { get; set; }
        public PSBlobQueryError[] BlobQueryError { get; set; }

        public BlobQueryOutput() { }
        public BlobQueryOutput(long bytesScanned, List<PSBlobQueryError> errors)
        {
            this.BytesScanned = bytesScanned;
            this.FailureCount = errors is null ? 0 : errors.Count;
            this.BlobQueryError = (errors is null || errors.Count == 0) ? null : errors.ToArray();
        }
    }
}
