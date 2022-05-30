﻿using POC.Grpc.Lib.Proto.CustomTypes;

namespace POC.Grpc.Lib.Mappers
{
    public static class DecimalGrpcMapper
    {
        private const decimal NanoFactor = 1_000_000_000;

        public static decimal Map(DecimalGrpc grpcDecimal)
        {
            return grpcDecimal != null 
                ? grpcDecimal.Units + grpcDecimal.Nanos / NanoFactor 
                : 0;
        }

        public static DecimalGrpc Map(decimal value)
        {
            var units = decimal.ToInt64(value);
            var nanos = decimal.ToInt32((value - units) * NanoFactor);
            return new DecimalGrpc() { Units = units, Nanos = nanos };
        }
    }
}