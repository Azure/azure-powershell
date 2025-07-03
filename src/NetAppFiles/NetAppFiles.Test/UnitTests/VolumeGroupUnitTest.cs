using Microsoft.Azure.Commands.NetAppFiles.VolumeGroup;
using Microsoft.Azure.Management.NetApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Text;
using Xunit;
//using Microsoft.Azure.Commands.NetAppFiles.VolumeGroup;

namespace Microsoft.Azure.Commands.NetAppFiles.UnitTest
{    
    public class VolumeGroupUnitTest
    {
        [Fact]
        public void DataThroughputCalculation1024ShouldReturn400()
        {
            int expectedThroughput = 400;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(1024, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation2048ShouldReturn600()
        {
            int expectedThroughput = 600;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(2048, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation3063ShouldReturn800()
        {
            int expectedThroughput = 800;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(3063, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation5120ShouldReturn1000()
        {
            int expectedThroughput = 1000;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(5120, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation7168ShouldReturn1200()
        {
            int expectedThroughput = 1200;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(7168, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation6216ShouldReturn1400()
        {
            int expectedThroughput = 1400;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(9216, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation10240ShouldReturn1400()
        {
            int expectedThroughput = 1400;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(10240, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void DataThroughputCalculation11264ShouldReturn1500()
        {
            int expectedThroughput = 1500;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(11264, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void LogThroughputCalculation4096ShouldReturn250()
        {
            int expectedThroughput = 250;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(4096, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Log);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Fact]
        public void LogThroughputCalculation5120ShouldReturn500()
        {
            int expectedThroughput = 500;
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateThroughput(5120, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Log);
            Assert.Equal(expectedThroughput, throughput);
        }

        [Theory]
        [InlineData("SH1", "SH1", 2, "data", "SH1-data-mnt00002")]
        [InlineData("SH1", "", 1, "data", "SH1-data-mnt00001")]
        [InlineData("SH1", null, 1, "data", "SH1-data-mnt00001")]
        [InlineData("SH1", "SH1", 2, "shared", "SH1-shared")]
        [InlineData("SH1", "SH1", 2, "log", "SH1-log-mnt00002")]
        public void DataVolumeNameScaleup(string applicationId, string systemId, int numberOfHost, string volumeType, string expectedVolumeName)
        {
            //string expectedVolumeName = "SH1-data-mnt00001";
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateVolumeName(applicationId, systemId, volumeType, numberOfHost, NewAzureRmNetAppFilesVolumeGroup.SystemRoles.PRIMARY, null);
            Assert.Equal(expectedVolumeName, volumeName);
        }

        [Fact]
        public void DataVolumeNameScaleoutHost1()
        {
            string expectedVolumeName = "SH1-data-mnt00001";
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateVolumeName(NewAzureRmNetAppFilesVolumeGroup.DefaultSapApplicationId, NewAzureRmNetAppFilesVolumeGroup.DefaultSapSystemId, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data, 1, NewAzureRmNetAppFilesVolumeGroup.SystemRoles.PRIMARY, null);
            Assert.Equal(expectedVolumeName, volumeName);
        }

        [Fact]
        public void DataVolumeNameScaleoutHost2()
        {
            string expectedVolumeName = "SH1-data-mnt00002";
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateVolumeName(NewAzureRmNetAppFilesVolumeGroup.DefaultSapApplicationId, NewAzureRmNetAppFilesVolumeGroup.DefaultSapSystemId, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data, 2, NewAzureRmNetAppFilesVolumeGroup.SystemRoles.PRIMARY, null);
            Assert.Equal(expectedVolumeName, volumeName);
        }

        [Fact]
        public void LogVolumeNameScaleup()
        {
            string expectedVolumeName = "SH1-log-mnt00001";
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateVolumeName(NewAzureRmNetAppFilesVolumeGroup.DefaultSapApplicationId, NewAzureRmNetAppFilesVolumeGroup.DefaultSapSystemId, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Log, 1, NewAzureRmNetAppFilesVolumeGroup.SystemRoles.PRIMARY, null);
            Assert.Equal(expectedVolumeName, volumeName);
        }

        [Fact]
        public void SharedVolumeNameScaleup()
        {
            string expectedVolumeName = "SH1-shared";
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateVolumeName(NewAzureRmNetAppFilesVolumeGroup.DefaultSapApplicationId, NewAzureRmNetAppFilesVolumeGroup.DefaultSapSystemId, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Shared, 1, NewAzureRmNetAppFilesVolumeGroup.SystemRoles.PRIMARY, null);
            Assert.Equal(expectedVolumeName, volumeName);
        }

        [Theory]
        [InlineData(1024, 2, "data", 512)]
        [InlineData(10, 2, "data", 100)]
        [InlineData(10, 2, "log", 150)]
        [InlineData(1024, 2, "log", 150)]
        public void OracleDataThroughputCalculation(int throughPut, int numberOfVolumes, string volumeType, int expectedThroughput)
        {
            
            var throughput = NewAzureRmNetAppFilesVolumeGroup.CalculateOracleThroughput(throughPut, numberOfVolumes, volumeType);
            Assert.Equal(expectedThroughput, throughput);
        }


        [Theory]
        [InlineData(1024, 2, 20, 614)]
        [InlineData(24, 2, 20, 100)]        
        public void OracleUsageThresholdCalculationData(int oraDataBaseSize, int numberOfVolumes, int snapshotCapacity, int expected)
        {
            long gibibyte = 1024L * 1024L * 1024L;
            long expectedthreshold = expected * gibibyte;
            var threshold = NewAzureRmNetAppFilesVolumeGroup.CalulateOracleUsageThreshold(oraDataBaseSize, numberOfVolumes, snapshotCapacity, NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Data);
            Assert.Equal(expectedthreshold / gibibyte, threshold/gibibyte);
        }

        [Theory]
        [InlineData(1024, 2, 20, 100)]
        [InlineData(24, 2, 20, 100)]
        public void OracleUsageThresholdCalculationBinary(int oraDataBaseSize, int numberOfVolumes, int snapshotCapacity, int expected)
        {
            long gibibyte = 1024L * 1024L * 1024L;
            long expectedthreshold = expected * gibibyte;
            var threshold = NewAzureRmNetAppFilesVolumeGroup.CalulateOracleUsageThreshold(oraDataBaseSize, numberOfVolumes, snapshotCapacity, NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Binary);
            Assert.Equal(expectedthreshold / gibibyte, threshold / gibibyte);
        }

        [Theory]
        [InlineData(1024, 2, 20, 512)]
        [InlineData(24, 2, 20, 100)]
        public void OracleUsageThresholdCalculationBackup(int oraDataBaseSize, int numberOfVolumes, int snapshotCapacity, int expected)
        {
            long gibibyte = 1024L * 1024L * 1024L;
            long expectedthreshold = expected * gibibyte;
            var threshold = NewAzureRmNetAppFilesVolumeGroup.CalulateOracleUsageThreshold(oraDataBaseSize, numberOfVolumes, snapshotCapacity, NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Backup);
            Assert.Equal(expectedthreshold / gibibyte, threshold / gibibyte);
        }

        [Theory]
        [InlineData(150, 2, 100)]
        [InlineData(350, 2, 175)]
        public void OracleUsageThroughputCalculationData(int oracleThroughput, int numberOfVolumes, int expected)
        {
            var volumeThroughput = NewAzureRmNetAppFilesVolumeGroup.CalculateOracleThroughput(oracleThroughput, numberOfVolumes, NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Data);
            Assert.Equal(expected, volumeThroughput);
        }

        [Theory]
        [InlineData(150, 2, 150)]
        [InlineData(350, 2, 150)]
        public void OracleUsageThroughputCalculationBackup(int oracleThroughput, int numberOfVolumes, int expected)
        {
            var volumeThroughput = NewAzureRmNetAppFilesVolumeGroup.CalculateOracleThroughput(oracleThroughput, numberOfVolumes, NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Backup);
            Assert.Equal(expected, volumeThroughput);
        }

        [Theory]
        [InlineData(150, 2, 64)]
        [InlineData(350, 2, 64)]
        public void OracleUsageThroughputCalculationBinary(int oracleThroughput, int numberOfVolumes, int expected)
        {
            var volumeThroughput = NewAzureRmNetAppFilesVolumeGroup.CalculateOracleThroughput(oracleThroughput, numberOfVolumes, NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Binary);
            Assert.Equal(expected, volumeThroughput);
        }

        [Theory]
        [InlineData("or1", "ora1", 2, "data", "PRIMARY", "ora1-ora-data2")]
        [InlineData("or1", "ora1", 2, "data", "HA", "HA-ora1-ora-data2")]
        [InlineData("or1", "ora1", 2, "data", null, "ora1-ora-data2")]
        [InlineData("or1", "", 1, "data", "", "or1-ora-data1")]
        [InlineData("or1", null, 1, "data","", "or1-ora-data1")]
        [InlineData("or1", "ora1", 2, "binary",null, "ora1-ora-binary")]
        [InlineData("or1", "ora1", 2, "log", null, "ora1-ora-log")]
        public void OracleGenerateVolumeName(string applicationId, string systemId, int numberOfVolume, string volumeType, string systemRole, string expected)
        {
            var volumeName = NewAzureRmNetAppFilesVolumeGroup.GenerateOracleVolumeName(applicationId, systemId, volumeType, numberOfVolume, systemRole);
            Assert.Equal(expected, volumeName);
        }

        [Theory]
        [ClassData(typeof(ReplicationObjectData))]
        public void GetReplicationObject(int volumeNumber, string volumeType, NewAzureRmNetAppFilesVolumeGroup cmdLet, ReplicationObject expectedReplicationObject)
        {
            //string expectedVolumeName = "SH1-data-mnt00001";
            var replicationObject = cmdLet.GetReplicationObject(volumeNumber, volumeType);
            Assert.Equal(expectedReplicationObject.RemoteVolumeResourceId, replicationObject.RemoteVolumeResourceId);
            Assert.Equal(expectedReplicationObject.ReplicationSchedule, replicationObject.ReplicationSchedule);
        }
    }

    public class ReplicationObjectData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                1, NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Data, new NewAzureRmNetAppFilesVolumeGroup(){ DataReplicationSourceId= "remote1", DataReplicationSchedule="_10minutely" },new ReplicationObject {RemoteVolumeResourceId="remote1",ReplicationSchedule="_10minutely"}
            };
            yield return new object[] {
                2, NewAzureRmNetAppFilesVolumeGroup.SapVolumeType.Data, new NewAzureRmNetAppFilesVolumeGroup(){ Data2ReplicationSourceId= "remote2", Data2ReplicationSchedule="hourly" },new ReplicationObject {RemoteVolumeResourceId="remote2",ReplicationSchedule="hourly"}
            };
            yield return new object[] {
                2,NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Data, new NewAzureRmNetAppFilesVolumeGroup(){ Data2ReplicationSourceId= "remote3", Data2ReplicationSchedule="daily" },new ReplicationObject {RemoteVolumeResourceId="remote3",ReplicationSchedule="daily"}
            };
            yield return new object[] {
                2,NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Log, new NewAzureRmNetAppFilesVolumeGroup(){ DataReplicationSourceId= "remote3", DataReplicationSchedule="_10minutely", LogReplicationSourceId= "remoteLog3", LogReplicationSchedule="daily" },new ReplicationObject {RemoteVolumeResourceId="remoteLog3",ReplicationSchedule="daily"}
            };
            yield return new object[] {
                2,NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Binary, new NewAzureRmNetAppFilesVolumeGroup(){ DataReplicationSourceId= "remote", DataReplicationSchedule="_10minutely", LogMirrorReplicationSourceId= "remoteLogMirror", LogMirrorReplicationSchedule="daily", BinaryReplicationSourceId= "remoteBinary", BinaryReplicationSchedule="daily" },
                new ReplicationObject {RemoteVolumeResourceId="remoteBinary",ReplicationSchedule="daily"}
            };
            yield return new object[] {
                0,NewAzureRmNetAppFilesVolumeGroup.OracleVolumeType.Binary, new NewAzureRmNetAppFilesVolumeGroup(){ DataReplicationSourceId= "remote", DataReplicationSchedule="_10minutely", LogMirrorReplicationSourceId= "remoteLogMirror", LogMirrorReplicationSchedule="daily", BinaryReplicationSourceId= "remoteBinary", BinaryReplicationSchedule="daily" },
                new ReplicationObject {RemoteVolumeResourceId="remoteBinary",ReplicationSchedule="daily"}
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
