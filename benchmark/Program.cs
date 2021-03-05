using System;
using System.Linq;
using ZigBeeNet;
using ZigBeeNet.ZCL.Protocol;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


namespace benchmark
{
    static class DataTypeValues
    {
        public static DataType[] Values {get;}
        public static int Count {get;}
        static DataTypeValues()
        {
            Values = Enum.GetValues(typeof(DataType)).Cast<DataType>().ToArray();
            Count = Values.Length;
        }
    }

    public class ZclDataTypeBenchmark {
        [Benchmark]
        public ZclDataType Get() => ZclDataType.Get(data);

        // [Benchmark]
        // public ZclDataType GetDict() => ZclDataType.Get((byte)data);

        // [Benchmark]
        // public ZclDataType GetKeyedValue() => ZclDataType.GetKeyedValue(data);

        [Benchmark]
        public ZclDataType GetSquareArray() => ZclDataType.GetSquareArray(data);

        [Benchmark]
        public ZclDataType GetArray() => ZclDataType.GetArray(data);

        static int pos = 0;
        private DataType data;

        public ZclDataTypeBenchmark()
        {
            data = DataTypeValues.Values[pos];
            pos = (pos+1)%DataTypeValues.Count;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            // foreach (var v in DataTypeValues.Values)
            //     if (ZclDataType.Get(v) != ZclDataType.GetKeyedValue(v))
            //         throw new Exception($"ZclDataType is different for {v}!!!");

            foreach (var v in DataTypeValues.Values)
                if (ZclDataType.Get(v) != ZclDataType.GetSquareArray(v))
                    throw new Exception($"ZclDataType is different for {v}!!!");

            // get all DataType values
            var summary = BenchmarkRunner.Run<ZclDataTypeBenchmark>();

        }
    }
}
