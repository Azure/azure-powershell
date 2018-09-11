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

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.WindowsAzure.Commands.Tools.Vhd.Model
{
    public class IndexRange : IEquatable<IndexRange>
    {
        static IndexRangeComparer comparer = new IndexRangeComparer();

        public static IEnumerable<IndexRange> SubstractRanges(IEnumerable<IndexRange> source, IEnumerable<IndexRange> ranges)
        {
            var onlyInSource = source.Where(e => !ranges.Any(r => r.Intersects(e)));

            var irs =
                from ur in ranges
                from r in source
                where r.Intersects(ur)
                from ir in r.Subtract(ur)
                select ir;

            var result = irs.Distinct(new IndexRangeComparer()).ToList();
            result.AddRange(onlyInSource);
            result.Sort((r1, r2) => r1.CompareTo(r2));
            return result;
        }

        public static IndexRange FromLength(long startIndex, long length)
        {
            return new IndexRange(startIndex, startIndex + length - 1);
        }

        public IndexRange(long startIndex, long endIndex)
        {
            this.StartIndex = startIndex;
            this.EndIndex = endIndex;
        }

        public bool After(IndexRange range)
        {
            if (Intersects(range))
            {
                return false;
            }

            return (this.StartIndex > range.EndIndex);
        }

        public IEnumerable<IndexRange> Subtract(IndexRange range)
        {
            if (this.Equals(range))
            {
                return new List<IndexRange>();
            }
            if (!this.Intersects(range))
            {
                return new List<IndexRange> { this };
            }
            var intersection = this.Intersection(range);
            if (this.Equals(intersection))
            {
                return new List<IndexRange>();
            }
            if (intersection.StartIndex == this.StartIndex)
            {
                return new List<IndexRange> { new IndexRange(intersection.EndIndex + 1, this.EndIndex) };
            }
            if (intersection.EndIndex == this.EndIndex)
            {
                return new List<IndexRange> { new IndexRange(this.StartIndex, intersection.StartIndex - 1) };
            }
            return new List<IndexRange>
                       {
                           new IndexRange(this.StartIndex, intersection.StartIndex - 1),
                           new IndexRange(intersection.EndIndex + 1, this.EndIndex)
                       };
        }

        public bool Abuts(IndexRange range)
        {
            return !this.Intersects(range) && this.Gap(range) == null;
        }

        public IndexRange Gap(IndexRange range)
        {
            if (this.Intersects(range))
                return null;
            if (this.CompareTo(range) > 0)
            {
                var r = new IndexRange(range.EndIndex + 1, this.StartIndex - 1);
                if (r.Length <= 0)
                    return null;
                return r;
            }
            var result = new IndexRange(this.EndIndex + 1, range.StartIndex - 1);
            if (result.Length <= 0)
                return null;
            return result;
        }

        public int CompareTo(IndexRange range)
        {
            return this.StartIndex != range.StartIndex ?
                                                           this.StartIndex.CompareTo(range.StartIndex) :
                                                                                                           this.EndIndex.CompareTo(range.EndIndex);
        }

        public IndexRange Merge(IndexRange range)
        {
            if (!this.Abuts(range))
            {
                throw new ArgumentOutOfRangeException("range", "Ranges must be adjacent.");
            }
            if (this.CompareTo(range) > 0)
            {
                return new IndexRange(range.StartIndex, this.EndIndex);
            }
            return new IndexRange(this.StartIndex, range.EndIndex);
        }

        public IEnumerable<IndexRange> PartitionBy(int size)
        {
            if (this.Length <= size)
            {
                return new List<IndexRange> { this };
            }
            var result = new List<IndexRange>();
            long count = this.Length / size;
            long remainder = this.Length % size;
            for (long i = 0; i < count; i++)
            {
                result.Add(IndexRange.FromLength(this.StartIndex + i * size, size));
            }
            if (remainder != 0)
            {
                result.Add(IndexRange.FromLength(this.StartIndex + count * size, remainder));
            }
            return result;
        }

        public IndexRange Intersection(IndexRange range)
        {
            if (!this.Intersects(range))
            {
                return null;
            }
            var start = Math.Max(range.StartIndex, this.StartIndex);
            var end = Math.Min(range.EndIndex, this.EndIndex);

            return new IndexRange(start, end);
        }

        public bool Intersects(IndexRange range)
        {
            var start = Math.Max(range.StartIndex, this.StartIndex);
            var end = Math.Min(range.EndIndex, this.EndIndex);
            return start <= end;
        }

        public bool Includes(IndexRange range)
        {
            return this.Includes(range.StartIndex) && this.Includes(range.EndIndex);
        }

        public long EndIndex { get; private set; }

        public long StartIndex { get; private set; }

        public bool Includes(long value)
        {
            return value >= StartIndex && value <= EndIndex;
        }

        public long Length
        {
            get { return EndIndex - StartIndex + 1; }
        }

        public bool Equals(IndexRange other)
        {
            return other != null && this.StartIndex == other.StartIndex && this.EndIndex == other.EndIndex;
        }

        public override string ToString()
        {
            return String.Format("[{0},{1}]", StartIndex, EndIndex);
        }

        public override bool Equals(object obj)
        {
            var range = obj as IndexRange;
            return range != null && comparer.Equals(this, range);
        }

        public override int GetHashCode()
        {
            return comparer.GetHashCode(this);
        }
    }
}