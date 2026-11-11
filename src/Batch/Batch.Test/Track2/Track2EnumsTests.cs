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

using Microsoft.Azure.Commands.Batch.Track2;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using T1C = Microsoft.Azure.Batch.Common;
using T2 = Azure.Compute.Batch;

namespace Microsoft.Azure.Commands.Batch.Test.Track2
{
    public class Track2EnumsTests
    {
        // The enums of the shared PS objects (Track2ModelMapper); each group of cmdlets adds its own when it moves.
        public static IEnumerable<object[]> Pairs => new List<object[]>
        {
            new object[] { typeof(T1C.AutoUserScope), typeof(T2.AutoUserScope) },
            new object[] { typeof(T1C.ElevationLevel), typeof(T2.ElevationLevel) },
            new object[] { typeof(T1C.ContainerWorkingDirectory), typeof(T2.ContainerWorkingDirectory) },
        };

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [MemberData(nameof(Pairs))]
        public void EveryValueMapsBothWays(Type track1, Type track2)
        {
            List<object> known = track2.GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == track2).Select(p => p.GetValue(null)).ToList();
            Assert.NotEmpty(known);

            foreach (Enum value in Enum.GetValues(track1))
            {
                object sent = ToTrack2(track2, value);
                Assert.Contains(sent, known);
                Assert.Equal(value, ToTrack1(track1, sent));
            }

            foreach (object value in known)
            {
                object read = ToTrack1(track1, value);
                Assert.NotNull(read);
                Assert.Equal(value, ToTrack2(track2, (Enum)read));
            }
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ValuesTrack1DoesntHaveBecomeNull()
        {
            Assert.Null(Track2Enums.ToTrack1<T1C.ElevationLevel>(new T2.ElevationLevel("superUser")));
            Assert.Null(Track2Enums.ToTrack1<T1C.ElevationLevel>(null));
            Assert.Null(Track2Enums.ToTrack2OrNull<T2.ElevationLevel>(null));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("Shared")]
        [InlineData("shared")]
        [InlineData("VfsMounts")]
        [InlineData("aNewPath")]
        public void TextValuesAreSentAsTyped(string text)
        {
            T2.ContainerHostDataPath? value = Track2Enums.FromString<T2.ContainerHostDataPath>(text);

            Assert.Equal(text, value.ToString());
            Assert.Null(Track2Enums.FromString<T2.ContainerHostDataPath>(null));
        }

        private static object ToTrack2(Type track2, Enum value)
        {
            return typeof(Track2Enums).GetMethod(nameof(Track2Enums.ToTrack2), BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(track2).Invoke(null, new object[] { value });
        }

        private static object ToTrack1(Type track1, object value)
        {
            return typeof(Track2Enums).GetMethod(nameof(Track2Enums.ToTrack1), BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(track1).Invoke(null, new object[] { value });
        }
    }
}
