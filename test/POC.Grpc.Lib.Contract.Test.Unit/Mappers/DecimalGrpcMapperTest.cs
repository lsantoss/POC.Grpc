using NUnit.Framework;
using POC.Grpc.Lib.Contract.Mappers;
using POC.Grpc.Lib.Contract.Proto.Common.CustomTypes;
using POC.Grpc.Test.Tools.Base.Unit;
using POC.Grpc.Test.Tools.Constants;
using System;

namespace POC.Grpc.Lib.Contract.Test.Unit.Mappers
{
    internal class DecimalGrpcMapperTest : UnitTest
    {
        private const decimal NanoFactor = DecimalConstants.NanoFactor;

        [Test]
        [TestCase(-1, 75)]
        [TestCase(-1, 0)]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(1, 75)]
        public void Map_Decimal_To_DecimalGrpc(long units, int nanos)
        {
            //Arrange
            var input = Convert.ToDecimal($"{units},{nanos}");

            //Act
            var decimalGrpc = DecimalGrpcMapper.Map(input);
            var valueDecimal = DecimalGrpcMapper.Map(decimalGrpc);

            TestContext.WriteLine($"Input: {input}");
            TestContext.WriteLine($"Decimal: {valueDecimal}");
            TestContext.WriteLine($"DecimalGrpc: {decimalGrpc}");

            //Assert
            Assert.That(valueDecimal, Is.EqualTo(input));
        }

        [Test]
        [TestCase(-1.75)]
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(175)]
        public void Map_DecimalGrpc_To_Decimal_Valid_Parameter(decimal value)
        {
            //Arrange
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * NanoFactor);
            var decimalGrpc = new DecimalGrpc() { Units = units, Nanos = nanos };

            //Act
            var valueDecimal = DecimalGrpcMapper.Map(decimalGrpc);

            TestContext.WriteLine($"Input: {value}");
            TestContext.WriteLine($"Decimal: {valueDecimal}");
            TestContext.WriteLine($"DecimalGrpc: {decimalGrpc}");

            //Assert
            Assert.That(valueDecimal, Is.EqualTo(value));
        }

        [Test]
        public void Map_DecimalGrpc_To_Decimal_Null_Parameter()
        {
            //Act
            var valueDecimal = DecimalGrpcMapper.Map(null);

            TestContext.WriteLine($"Decimal: {valueDecimal}");
            TestContext.WriteLine($"DecimalGrpc: {null}");

            //Assert
            Assert.That(valueDecimal, Is.Zero);
        }
    }
}