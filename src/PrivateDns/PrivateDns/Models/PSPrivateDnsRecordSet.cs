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

namespace Microsoft.Azure.Commands.PrivateDns.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Azure.Management.PrivateDns.Models;

    /// <summary>
    /// Represents a set of records with the same name, with the same type and in the same zone.
    /// </summary>
    public class PSPrivateDnsRecordSet : ICloneable
    {
        /// <summary>
        /// Gets or sets the ID of the record set.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the name of this record set, relative to the name of the zone to which it belongs and WITHOUT a terminating '.' (dot) character.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of the zone to which this recordset belongs.
        /// </summary>
        public string ZoneName { get; set; }

        /// <summary>
        /// Gets or sets the name of the resource group to which this record set belongs.
        /// </summary>
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the TTL of all the records in this record set.
        /// </summary>
        public uint Ttl { get; set; }

        /// <summary>
        /// Gets or sets the Etag of this record set.
        /// </summary>
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the type of DNS records in this record set. Only records of this type may be added to this record set.
        /// </summary>
        public RecordType RecordType { get; set; }

        /// <summary>
        /// Gets or sets the list of records in this record set.
        /// </summary>
        public List<PSPrivateDnsRecordBase> Records { get; set; }

        /// <summary>
        /// Gets or sets the tags of this record set.
        /// </summary>
        public Hashtable Metadata { get; set; }

        /// <summary>
        /// Gets or sets the provisioning state of the record set
        /// </summary>
        public bool? IsAutoRegistered { get; set; }

        /// <summary>
        /// Returns a deep copy of this record set
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            var clone = new PSPrivateDnsRecordSet
            {
                Name = this.Name,
                Id = this.Id,
                ZoneName = this.ZoneName,
                ResourceGroupName = this.ResourceGroupName,
                Ttl = this.Ttl,
                Etag = this.Etag,
                RecordType = this.RecordType,
                IsAutoRegistered = this.IsAutoRegistered
            };

            if (this.Records != null)
            {
                clone.Records = this.Records.Select(record => record.Clone()).Cast<PSPrivateDnsRecordBase>().ToList();
            }

            if (this.Metadata != null)
            {
                clone.Metadata = (Hashtable)this.Metadata.Clone();
            }

            return clone;
        }
    }

    /// <summary>
    /// Represents a Private DNS record that is part of a <see cref="PSPrivateDnsRecordSet"/>.
    /// </summary>
    public abstract class PSPrivateDnsRecordBase : ICloneable
    {
        public abstract object Clone();

        public const int TxtRecordMaxLength = 1024;

        public const int TxtRecordMinLength = 0;

        public const int TxtRecordChunkSize = 255;

        internal abstract object ToMamlRecord();

        internal static PSPrivateDnsRecordBase FromMamlRecord(object record)
        {
            switch (record)
            {
                case Management.PrivateDns.Models.ARecord _:
                {
                    var mamlRecord = (Management.PrivateDns.Models.ARecord)record;
                    return new ARecord
                    {
                        Ipv4Address = mamlRecord.Ipv4Address
                    };
                }
                case Management.PrivateDns.Models.AaaaRecord _:
                {
                    var mamlRecord = (Management.PrivateDns.Models.AaaaRecord)record;
                    return new AaaaRecord
                    {
                        Ipv6Address = mamlRecord.Ipv6Address
                    };
                }
                case Management.PrivateDns.Models.CnameRecord _:
                {
                    var mamlRecord = (Management.PrivateDns.Models.CnameRecord)record;
                    return new CnameRecord
                    {
                        Cname = mamlRecord.Cname
                    };
                }
                case Management.PrivateDns.Models.MxRecord _:
                {
                    var mamlRecord = (Management.PrivateDns.Models.MxRecord)record;
                    return new MxRecord
                    {
                        Exchange = mamlRecord.Exchange,
                        Preference = (ushort) mamlRecord.Preference,
                    };
                }
                case Management.PrivateDns.Models.SrvRecord _:
                {
                    var mamlRecord = (Management.PrivateDns.Models.SrvRecord)record;
                    return new SrvRecord
                    {
                        Port = (ushort) mamlRecord.Port,
                        Priority = (ushort) mamlRecord.Priority,
                        Target = mamlRecord.Target,
                        Weight = (ushort) mamlRecord.Weight,
                    };
                }
                case Management.PrivateDns.Models.SoaRecord _:
                {
                    var mamlRecord = (Management.PrivateDns.Models.SoaRecord)record;
                    return new SoaRecord
                    {
                        Email = mamlRecord.Email,
                        ExpireTime = (uint) mamlRecord.ExpireTime.GetValueOrDefault(),
                        Host = mamlRecord.Host,
                        MinimumTtl = (uint) mamlRecord.MinimumTtl.GetValueOrDefault(),
                        RefreshTime = (uint) mamlRecord.RefreshTime.GetValueOrDefault(),
                        RetryTime = (uint) mamlRecord.RetryTime.GetValueOrDefault(),
                        SerialNumber = (uint) mamlRecord.SerialNumber.GetValueOrDefault(),
                    };
                }
                case Management.PrivateDns.Models.TxtRecord _:
                {
                    var mamlRecord = (Management.PrivateDns.Models.TxtRecord)record;
                    return new TxtRecord
                    {
                        Value = ToPowerShellTxtValue(mamlRecord.Value),
                    };
                }
                case Management.PrivateDns.Models.PtrRecord _:
                {
                    var mamlRecord = (Management.PrivateDns.Models.PtrRecord)record;
                    return new PtrRecord
                    {
                        Ptrdname = mamlRecord.Ptrdname,
                    };
                }
                default:
                    return null;
            }
        }

        private static string ToPowerShellTxtValue(ICollection<string> value)
        {
            if (value == null || value.Count == 0)
            {
                return null;
            }
            
            var sb = new StringBuilder();
            foreach (var s in value)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// Represents a Private DNS record of type A that is part of a <see cref="PSPrivateDnsRecordSet"/>.
    /// </summary>
    public class ARecord : PSPrivateDnsRecordBase
    {
        /// <summary>
        /// Gets or sets the IPv4 address of this A record in string notation
        /// </summary>
        public string Ipv4Address { get; set; }

        public override string ToString()
        {
            return this.Ipv4Address;
        }

        internal override object ToMamlRecord()
        {
            return new Management.PrivateDns.Models.ARecord
            {
                Ipv4Address = this.Ipv4Address,
            };
        }

        /// <summary>
        /// Creates a deep copy of this object
        /// </summary>
        /// <returns>A clone of this object</returns>
        public override object Clone()
        {
            return new ARecord { Ipv4Address = this.Ipv4Address };
        }
    }

    /// <summary>
    /// Represents a Private DNS record of type AAAA that is part of a <see cref="PSPrivateDnsRecordSet"/>.
    /// </summary>
    public class AaaaRecord : PSPrivateDnsRecordBase
    {
        /// <summary>
        /// Gets or sets the IPv6 address of this AAAA record in string notation.
        /// </summary>
        public string Ipv6Address { get; set; }

        public override string ToString()
        {
            return this.Ipv6Address;
        }

        internal override object ToMamlRecord()
        {
            return new Management.PrivateDns.Models.AaaaRecord
            {
                Ipv6Address = this.Ipv6Address,
            };
        }

        /// <summary>
        /// Cerates a deep copy of this object
        /// </summary>
        /// <returns>A clone of this object</returns>
        public override object Clone()
        {
            return new AaaaRecord { Ipv6Address = this.Ipv6Address };
        }
    }

    /// <summary>
    /// Represents a Private DNS record of type CNAME that is part of a <see cref="PSPrivateDnsRecordSet"/>.
    /// </summary>
    public class CnameRecord : PSPrivateDnsRecordBase
    {
        /// <summary>
        /// Gets or sets the canonical name for this CNAME record without a terminating dot.
        /// </summary>
        public string Cname { get; set; }

        public override string ToString()
        {
            return this.Cname;
        }

        internal override object ToMamlRecord()
        {
            return new Management.PrivateDns.Models.CnameRecord
            {
                Cname = this.Cname,
            };
        }

        /// <summary>
        /// Creates a deep copy of this object
        /// </summary>
        /// <returns>A clone of this object</returns>
        public override object Clone()
        {
            return new CnameRecord { Cname = this.Cname };
        }
    }

    /// <summary>
    /// Represents a Private DNS record of type TXT that is part of a <see cref="PSPrivateDnsRecordSet"/>.
    /// </summary>
    public class TxtRecord : PSPrivateDnsRecordBase
    {
        /// <summary>
        /// Gets or sets the text value of this TXT record.
        /// </summary>
        public string Value { get; set; }

        public override string ToString()
        {
            return this.Value;
        }

        internal override object ToMamlRecord()
        {
            var letters = this.Value.ToCharArray();
            var splitValues = new List<string>();

            var remaining = letters.Length;
            var begin = 0;
            while (remaining > 0)
            {
                if (remaining < TxtRecordChunkSize)
                {
                    splitValues.Add(new string(letters, begin, remaining));
                    remaining = 0;
                }
                else
                {
                    splitValues.Add(new string(letters, begin, TxtRecordChunkSize));
                    begin += TxtRecordChunkSize;
                    remaining -= TxtRecordChunkSize;
                }
            }

            return new Management.PrivateDns.Models.TxtRecord
            {
                Value = splitValues,
            };
        }

        /// <summary>
        /// Cerates a deep copy of this object
        /// </summary>
        /// <returns>A clone of this object</returns>
        public override object Clone()
        {
            return new TxtRecord { Value = this.Value };
        }
    }

    /// <summary>
    /// Represents a Private DNS record of type MX that is part of a <see cref="PSPrivateDnsRecordSet"/>.
    /// </summary>
    public class MxRecord : PSPrivateDnsRecordBase
    {
        /// <summary>
        /// Gets or sets the preference metric for this MX record.
        /// </summary>
        public ushort Preference { get; set; }

        /// <summary>
        /// Gets or sets the domain name of the mail host, without a terminating dot
        /// </summary>
        public string Exchange { get; set; }

        public override string ToString()
        {
            return $"[{Preference},{Exchange}]";
        }

        internal override object ToMamlRecord()
        {
            return new Management.PrivateDns.Models.MxRecord
            {
                Exchange = this.Exchange,
                Preference = this.Preference,
            };
        }

        /// <summary>
        /// Cerates a deep copy of this object
        /// </summary>
        /// <returns>A clone of this object</returns>
        public override object Clone()
        {
            return new MxRecord { Exchange = this.Exchange, Preference = this.Preference };
        }
    }

    /// <summary>
    /// Represents a Private DNS record of type SRV that is part of a <see cref="PSPrivateDnsRecordSet"/>.
    /// </summary>
    public class SrvRecord : PSPrivateDnsRecordBase
    {
        /// <summary>
        /// Gets or sets the domain name of the target for this SRV record, without a terminating dot.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the weight metric for this SRV record.
        /// </summary>
        public ushort Weight { get; set; }

        /// <summary>
        /// Gets or sets the port for this SRV record
        /// </summary>
        public ushort Port { get; set; }

        /// <summary>
        /// Gets or sets the priority metric for this SRV record.
        /// </summary>
        public ushort Priority { get; set; }

        public override string ToString()
        {
            return $"[{Priority},{Weight},{Port},{Target}]";
        }

        internal override object ToMamlRecord()
        {
            return new Management.PrivateDns.Models.SrvRecord
            {
                Priority = this.Priority,
                Target = this.Target,
                Weight = this.Weight,
                Port = this.Port,
            };
        }

        /// <summary>
        /// Cerates a deep copy of this object
        /// </summary>
        /// <returns>A clone of this object</returns>
        public override object Clone()
        {
            return new SrvRecord
            {
                Priority = this.Priority,
                Target = this.Target,
                Weight = this.Weight,
                Port = this.Port
            };
        }
    }

    /// <summary>
    /// Represents a Private DNS record of type SOA that is part of a <see cref="PSPrivateDnsRecordSet"/>.
    /// </summary>
    public class SoaRecord : PSPrivateDnsRecordBase
    {
        /// <summary>
        /// Gets or sets the domain name of the authoritative name server for this SOA record, without a temrinating dot.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the email for this SOA record.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the serial number of this SOA record.
        /// </summary>
        public uint SerialNumber { get; set; }

        /// <summary>
        /// Gets or sets the refresh value for this SOA record.
        /// </summary>
        public uint RefreshTime { get; set; }

        /// <summary>
        /// Gets or sets the retry time for SOA record.
        /// </summary>
        public uint RetryTime { get; set; }

        /// <summary>
        /// Gets or sets the expire time for this SOA record.
        /// </summary>
        public uint ExpireTime { get; set; }

        /// <summary>
        /// Gets or sets the minimum TTL for this SOA record.
        /// </summary>
        public uint MinimumTtl { get; set; }

        public override string ToString()
        {
            return $"[{Host},{Email},{RefreshTime},{RetryTime},{ExpireTime},{MinimumTtl}]";
        }

        internal override object ToMamlRecord()
        {
            return new Management.PrivateDns.Models.SoaRecord
            {
                Host = this.Host,
                Email = this.Email,
                SerialNumber = this.SerialNumber,
                RefreshTime = this.RefreshTime,
                RetryTime = this.RetryTime,
                ExpireTime = this.ExpireTime,
                MinimumTtl = this.MinimumTtl,
            };
        }

        /// <summary>
        /// Cerates a deep copy of this object
        /// </summary>
        /// <returns>A clone of this object</returns>
        public override object Clone()
        {
            return new SoaRecord
            {
                Host = this.Host,
                Email = this.Email,
                SerialNumber = this.SerialNumber,
                RefreshTime = this.RefreshTime,
                RetryTime = this.RetryTime,
                ExpireTime = this.ExpireTime,
                MinimumTtl = this.MinimumTtl,
            };
        }
    }

    /// <summary>
    /// Represents a Private DNS record of type PTR that is part of a <see cref="PSPrivateDnsRecordSet"/>.
    /// </summary>
    public class PtrRecord : PSPrivateDnsRecordBase
    {
        /// <summary>
        /// Gets or sets the ptr for this record.
        /// </summary>
        public string Ptrdname { get; set; }

        public override string ToString()
        {
            return this.Ptrdname;
        }

        public override object Clone()
        {
            return new PtrRecord()
            {
                Ptrdname = this.Ptrdname,
            };
        }

        internal override object ToMamlRecord()
        {
            return new Management.PrivateDns.Models.PtrRecord
            {
                Ptrdname = this.Ptrdname,
            };
        }
    }
}
