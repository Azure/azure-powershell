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
using System.Text;
using StaticAnalysis.DependencyAnalyzer;
using StaticAnalysis.HelpAnalyzer;
using Xunit;

namespace StaticAnalysis.Test
{
    public class MatchingTests
    {
        private static Random Random = new Random();
        private static T GetClone<T>(T baseValue) where T : class, ICloneable
        {
            T result = null;
            if (baseValue != null)
            {
                result = baseValue.Clone() as T;
            }

            return result;
        }

        private static AssemblyVersionConflict CreateAssemblyVersionConflict(string directory, string assembly, string parentAssembly,
            int problemId, bool vary = false)
        {
            return new AssemblyVersionConflict
            {
                Directory = directory != null && vary? GetClone(directory).ToUpperInvariant() : GetClone(directory),
                AssemblyName = assembly!= null && vary ? GetClone(assembly).ToLowerInvariant() : GetClone(assembly),
                ParentAssembly = parentAssembly != null && vary? GetClone(parentAssembly).ToUpperInvariant() : GetClone(parentAssembly),
                ProblemId = problemId,
                Description = GetRandomString(),
                Remediation = GetRandomString(),
                ActualVersion = GetRandomVersion(),
                ExpectedVersion = GetRandomVersion(),
                Severity = Random.Next()
            };
        }

        private static HelpIssue CreateHelpIssue(string assembly, string helpFile, string target, int problemId, bool vary = false)
        {
            return new HelpIssue
            {
                Assembly = assembly != null && vary? GetClone(assembly).ToUpperInvariant() : GetClone(assembly),
                HelpFile = assembly!= null && vary ? GetClone(helpFile).ToLowerInvariant() : GetClone(helpFile),
                Target = target != null && vary? GetClone(target).ToUpperInvariant() : GetClone(target),
                ProblemId = problemId,
                Description = GetRandomString(),
                Remediation = GetRandomString(),
                Severity = Random.Next()
            };
        }


         private static ExtraAssembly CreateExtraAssembly(string directory, string assembly,
            int problemId, bool vary = false)
        {
            return new ExtraAssembly
            {
                Directory = directory != null && vary? GetClone(directory).ToUpperInvariant() : GetClone(directory),
                AssemblyName = assembly!= null && vary ? GetClone(assembly).ToLowerInvariant() : GetClone(assembly),
                ProblemId = problemId,
                Description = GetRandomString(),
                Remediation = GetRandomString(),
                Severity = Random.Next()
            };
        }

         private static MissingAssembly CreateMissingAssembly(string directory, string assembly,
            string version, string refAssembly, int problemId, bool vary = false)
        {
            return new MissingAssembly
            {
                Directory = directory != null && vary? GetClone(directory).ToUpperInvariant() : GetClone(directory),
                AssemblyName = assembly!= null && vary ? GetClone(assembly).ToLowerInvariant() : GetClone(assembly),
                AssemblyVersion = version,
                ReferencingAssembly = refAssembly,
                ProblemId = problemId,
                Description = GetRandomString(),
                Remediation = GetRandomString(),
                Severity = Random.Next(),
            };
        }

        private static SharedAssemblyConflict CreateSharedAssemblyConflict(string assembly, string version,
            int problemId, bool vary = false)
        {
            return new SharedAssemblyConflict
            {
                
                AssemblyName = assembly!= null && vary ? GetClone(assembly).ToLowerInvariant() : GetClone(assembly),
                AssemblyVersion = Version.Parse(version),
                ProblemId = problemId,
                Description = GetRandomString(),
                Remediation = GetRandomString(),
                Severity = Random.Next(),
                AssemblyPathsAndFileVersions = GetRandomStringVersionList()
            };
        }

        private static List<Tuple<string, Version>> GetRandomStringVersionList()
        {
            var result = new List<Tuple<string, Version>>();
            result.Add(new Tuple<string, Version>(GetRandomString(), GetRandomVersion()));
            result.Add(new Tuple<string, Version>(GetRandomString(), GetRandomVersion()));
            return result;
        }

        private static Version GetRandomVersion()
        {
            return new Version(Random.Next(), Random.Next(), Random.Next(), Random.Next());
        }

        private static string GetRandomString()
        {
            var length = Random.Next(5, 30);
            var builder = new StringBuilder();
            for (int i = 0; i < length; ++i)
            {
                builder.Append(Random.Next('A', 'z'));
            }

            return builder.ToString();
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("", null , null, int.MinValue)]
        [InlineData("", "", "", int.MinValue)]
        [InlineData("dir1/dir2/file/", "MyAssembly", "MyParentAssembly", int.MaxValue)]
        [InlineData("\\dir1\\dir2\\dir3\\", "My.Longer.Assembly", "My.Longer.ParentAssembly", 2000)]
        [InlineData("\\dir1\\dir2\\啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", "ᠠᡷᢀᡨᡩᡪᡫ", 0)]
        public void CanMatchAsssemblyVersionConflict(string directory, string assembly, string parentAssembly, int problemId)
        {
            var conflict1 = CreateAssemblyVersionConflict(directory, assembly, parentAssembly, problemId);
            var conflict2 = CreateAssemblyVersionConflict(directory, assembly, parentAssembly, problemId, true);
            Assert.True(conflict1.Match(conflict2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("dir1/dir2/file/", "MyAssembly", "MyParentAssembly", int.MaxValue)]
        [InlineData("\\dir1\\dir2\\dir3\\", "My.Longer.Assembly", "My.Longer.ParentAssembly", 2000)]
        [InlineData("\\dir1\\dir2\\啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", "ᠠᡷᢀᡨᡩᡪᡫ", 0)]
       public void CanRoundTripAssemblyVersionConflict(string directory, string assembly, string parentAssembly, int problemId)
        {
            var conflict1 = CreateAssemblyVersionConflict(directory, assembly, parentAssembly, problemId);
            var conflict2 = new AssemblyVersionConflict().Parse(conflict1.FormatRecord());
            Assert.True(conflict1.Match(conflict2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("", null , null, int.MinValue)]
        [InlineData("", "", "", int.MinValue)]
        [InlineData("dir1/dir2/file/", "MyAssembly", "MyParentAssembly", int.MaxValue)]
        [InlineData("\\dir1\\dir2\\dir3\\", "My.Longer.Assembly", "My.Longer.ParentAssembly", 2000)]
        [InlineData("\\dir1\\dir2\\啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", "ᠠᡷᢀᡨᡩᡪᡫ", 0)]
        public void CanContrastAssemblyVersionConflict(string directory, string assembly, string parentAssembly, int problemId)
        {
            var conflict1 = CreateAssemblyVersionConflict(directory, assembly, parentAssembly, problemId);
            var conflict2 = CreateAssemblyVersionConflict(GetRandomString(), assembly, parentAssembly, problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateAssemblyVersionConflict(directory, GetRandomString(), parentAssembly, problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateAssemblyVersionConflict(directory, assembly, GetRandomString(), problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateAssemblyVersionConflict(directory, assembly, parentAssembly, Random.Next());
            Assert.False(conflict1.Match(conflict2));
        }


        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("", null ,  int.MinValue)]
        [InlineData("", "",  int.MinValue)]
        [InlineData("dir1/dir2/file/", "MyAssembly", int.MaxValue)]
        [InlineData("\\dir1\\dir2\\dir3\\", "My.Longer.Assembly", 1000)]
        [InlineData("\\dir1\\dir2\\啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", 0)]
        public void CanMatchExtraAssembly(string directory, string assembly, int problemId)
        {
            var conflict1 = CreateExtraAssembly(directory, assembly, problemId);
            var conflict2 = CreateExtraAssembly(directory, assembly, problemId, true);
            Assert.True(conflict1.Match(conflict2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("dir1/dir2/file/", "MyAssembly", int.MaxValue)]
        [InlineData("\\dir1\\dir2\\dir3\\", "My.Longer.Assembly", 1000)]
        [InlineData("\\dir1\\dir2\\啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", 0)]
        public void CanRoundTripExtraAssembly(string directory, string assembly, int problemId)
        {
            var conflict1 = CreateExtraAssembly(directory, assembly, problemId);
            var conflict2 = new ExtraAssembly().Parse(conflict1.FormatRecord());
            Assert.True(conflict1.Match(conflict2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("", null ,  int.MinValue)]
        [InlineData("", "",  int.MinValue)]
        [InlineData("dir1/dir2/file/", "MyAssembly", int.MaxValue)]
        [InlineData("\\dir1\\dir2\\dir3\\", "My.Longer.Assembly", 1000)]
        [InlineData("\\dir1\\dir2\\啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", 0)]
        public void CanContrastExtraAssembly(string directory, string assembly, int problemId)
        {
            var conflict1 = CreateExtraAssembly(directory, assembly, problemId);
            var conflict2 = CreateExtraAssembly(GetRandomString(), assembly, problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateExtraAssembly(directory, GetRandomString(), problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateExtraAssembly(directory, assembly, Random.Next());
            Assert.False(conflict1.Match(conflict2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("", null , "1.0", null, int.MinValue)]
        [InlineData("", "", "2.0", "", int.MinValue)]
        [InlineData("dir1/dir2/file/", "MyAssembly", "1.9.9", "MyRefAssembly", int.MaxValue)]
        [InlineData("\\dir1\\dir2\\dir3\\", "My.Longer.Assembly", "9.9.999.9999", "My.Longer.Ref.Assembly", 100)]
        [InlineData("\\dir1\\dir2\\啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", "1.2.3.4","ᠠᡷᢀᡨᡩᡪᡫ", 0)]
        public void CanMatchMissingAssembly(string directory, string assembly, string version, string refAssembly, 
            int problemId)
        {
            var conflict1 = CreateMissingAssembly(directory, assembly, version, refAssembly, problemId);
            var conflict2 = CreateMissingAssembly(directory, assembly, version, refAssembly, problemId, true);
            Assert.True(conflict1.Match(conflict2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("dir1/dir2/file/", "MyAssembly", "1.9.9", "MyRefAssembly", int.MaxValue)]
        [InlineData("\\dir1\\dir2\\dir3\\", "My.Longer.Assembly", "9.9.999.9999", "My.Longer.Ref.Assembly", 100)]
        [InlineData("\\dir1\\dir2\\啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", "1.2.3.4","ᠠᡷᢀᡨᡩᡪᡫ", 0)]
        public void CanRoundTripMissingAssembly(string directory, string assembly, string version, string refAssembly, 
            int problemId)
        {
            var conflict1 = CreateMissingAssembly(directory, assembly, version, refAssembly, problemId);
            var conflict2 = new MissingAssembly().Parse(conflict1.FormatRecord());
            Assert.True(conflict1.Match(conflict2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("", null , "1.0", null, int.MinValue)]
        [InlineData("", "", "2.0", "", int.MinValue)]
        [InlineData("dir1/dir2/file/", "MyAssembly", "1.9.9", "MyRefAssembly", int.MaxValue)]
        [InlineData("\\dir1\\dir2\\dir3\\", "My.Longer.Assembly", "9.9.999.9999", "My.Longer.Ref.Assembly", 100)]
        [InlineData("\\dir1\\dir2\\啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", "1.2.3.4","ᠠᡷᢀᡨᡩᡪᡫ", 0)]
        public void CanContrastMissingAssembly(string directory, string assembly, string version, string refAssembly, 
           int problemId)
        {
            var conflict1 = CreateMissingAssembly(directory, assembly, version, refAssembly, problemId);
            var conflict2 = CreateMissingAssembly(GetRandomString(), assembly, version, refAssembly, problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateMissingAssembly(directory, GetRandomString(), version, refAssembly, problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateMissingAssembly(directory, assembly, GetRandomVersion().ToString(), refAssembly, problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateMissingAssembly(directory, assembly, version, GetRandomString(), problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateMissingAssembly(directory, assembly, version, refAssembly, Random.Next());
            Assert.False(conflict1.Match(conflict2));
       }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null, "1.0", int.MinValue)]
        [InlineData("", "1.0.2", int.MinValue)]
        [InlineData("MyAssembly", "9.99.999.9999", int.MaxValue)]
        [InlineData("My.Longer.Assembly", "0.0.0.1", 2000)]
        [InlineData("㙉㙊䵯䵰䶴䶵", "0.0.1", 0)]
        public void CanMatchSharedAssemblyConflict(string assembly, string version, int problemId)
        {
            var conflict1 = CreateSharedAssemblyConflict(assembly, version, problemId);
            var conflict2 = CreateSharedAssemblyConflict(assembly, version, problemId, true);
            Assert.True(conflict1.Match(conflict2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData("MyAssembly", "9.99.999.9999", int.MaxValue)]
        [InlineData("My.Longer.Assembly", "0.0.0.1", 2000)]
        [InlineData("㙉㙊䵯䵰䶴䶵", "0.0.1", 0)]
        public void CanRoundTripSharedAssemblyConflict(string assembly, string version, int problemId)
        {
            var conflict1 = CreateSharedAssemblyConflict(assembly, version, problemId);
            var conflict2 = new SharedAssemblyConflict().Parse(conflict1.FormatRecord());
            Assert.True(conflict1.Match(conflict2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null, "1.0", int.MinValue)]
        [InlineData("", "1.0.2", int.MinValue)]
        [InlineData("MyAssembly", "9.99.999.9999", int.MaxValue)]
        [InlineData("My.Longer.Assembly", "0.0.0.1", 2000)]
        [InlineData("㙉㙊䵯䵰䶴䶵", "0.0.1", 0)]
        public void CanContrastSharedAssemblyConflict(string assembly, string version, int problemId)
        {
            var conflict1 = CreateSharedAssemblyConflict(assembly, version, problemId);
            var conflict2 = CreateSharedAssemblyConflict(GetRandomString(), version, problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateSharedAssemblyConflict(assembly, GetRandomVersion().ToString(), problemId);
            Assert.False(conflict1.Match(conflict2));
            conflict2 = CreateSharedAssemblyConflict(assembly, version, Random.Next());
            Assert.False(conflict1.Match(conflict2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null, null, null, int.MinValue)]
        [InlineData("", "", "", int.MinValue)]
        [InlineData( "MyAssembly", "MyHelpFile", "MyTarget", int.MaxValue)]
        [InlineData("My.Longer.Assembly", "My.Longer.Helpfile", "My.Longer.Target", 100)]
        [InlineData("啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", "ᠠᡷᢀᡨᡩᡪᡫ", 0)]
        public void CanMatchHelpIssue(string assembly, string helpFile, string target, int problemId)
        {
            var help1 = CreateHelpIssue(assembly, helpFile, target, problemId);
            var help2 = CreateHelpIssue(assembly, helpFile, target, problemId, true);
            Assert.True(help1.Match(help2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData( "MyAssembly", "MyHelpFile", "MyTarget", int.MaxValue)]
        [InlineData("My.Longer.Assembly", "My.Longer.Helpfile", "My.Longer.Target", 100)]
        [InlineData("啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", "ᠠᡷᢀᡨᡩᡪᡫ", 0)]
        public void CanRoundTripHelpIssue(string assembly, string helpFile, string target, int problemId)
        {
            var help1 = CreateHelpIssue(assembly, helpFile, target, problemId);
            var help2 = new HelpIssue().Parse(help1.FormatRecord());
            Assert.True(help1.Match(help2));
        }

        [Theory]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        [InlineData(null, null, null, int.MinValue)]
        [InlineData("", "", "", int.MinValue)]
        [InlineData( "MyAssembly", "MyHelpFile", "MyTarget", int.MaxValue)]
        [InlineData("My.Longer.Assembly", "My.Longer.Helpfile", "My.Longer.Target", 100)]
        [InlineData("啊齄丂狛狜隣郎隣兀﨩", "㙉㙊䵯䵰䶴䶵", "ᠠᡷᢀᡨᡩᡪᡫ", 0)]
        public void CanContrastHelpIssue(string assembly, string helpFile, string target, int problemId)
        {
            var help1 = CreateHelpIssue(assembly, helpFile, target, problemId);
            var help2 = CreateHelpIssue(GetRandomString(), helpFile, target, problemId);
            Assert.False(help1.Match(help2));
            help2 = CreateHelpIssue(assembly, GetRandomString(), target, problemId);
            Assert.False(help1.Match(help2));
            help2 = CreateHelpIssue(assembly, helpFile, GetRandomString(), problemId);
            Assert.False(help1.Match(help2));
            help2 = CreateHelpIssue(assembly, helpFile, target, Random.Next());
            Assert.False(help1.Match(help2));
        }

    }
}
