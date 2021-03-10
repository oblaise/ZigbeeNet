using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ZigBeeNet.Security;
using ZigBeeNet.ZCL.Field;
using ZigBeeNet.ZDO;
using ZigBeeNet.ZDO.Field;

namespace ZigBeeNet.ZCL.Protocol
{
    public class ZclDataType
    {
        private static ZclDataType[] InitData = {
                new ZclDataType("8-bit data", typeof(byte), 0x08, false, DataType.DATA_8_BIT),
                new ZclDataType("16-bit data", null, 0x09, false, DataType.DATA_16_BIT),
                new ZclDataType("24-bit data", null, 0x0A, false, DataType.DATA_24_BIT),
                new ZclDataType("32-bit data", null, 0x0B, false, DataType.DATA_32_BIT),
                new ZclDataType("40-bit data", null, 0x0C, false, DataType.DATA_40_BIT),
                new ZclDataType("48-bit data", null, 0x0D, false, DataType.DATA_48_BIT),
                new ZclDataType("56-bit data", null, 0x0E, false, DataType.DATA_56_BIT),
                new ZclDataType("64-bit data", null, 0x0F, false, DataType.DATA_64_BIT),
                new ZclDataType("Boolean", typeof(bool), 0x10, false, DataType.BOOLEAN),
                new ZclDataType("8-bit Bitmap", typeof(byte), 0x18, false, DataType.BITMAP_8_BIT),
                new ZclDataType("16-bit Bitmap", typeof(ushort), 0x19, false, DataType.BITMAP_16_BIT),
                new ZclDataType("24-bit Bitmap", typeof(uint), 0x1A, false, DataType.BITMAP_24_BIT),
                new ZclDataType("32-bit Bitmap", typeof(uint), 0x1B, false, DataType.BITMAP_32_BIT),
                new ZclDataType("40-bit Bitmap", typeof(ulong), 0x1C, false, DataType.BITMAP_40_BIT),
                new ZclDataType("48-bit Bitmap", typeof(ulong), 0x1D, false, DataType.BITMAP_48_BIT),
                new ZclDataType("56-bit Bitmap", typeof(ulong), 0x1E, false, DataType.BITMAP_56_BIT),
                new ZclDataType("64-bit Bitmap", typeof(ulong), 0x1F, false, DataType.BITMAP_64_BIT),
                new ZclDataType("Unsigned 8-bit integer", typeof(byte), 0x20, true, DataType.UNSIGNED_8_BIT_INTEGER),
                new ZclDataType("Unsigned 16-bit integer", typeof(ushort), 0x21, true, DataType.UNSIGNED_16_BIT_INTEGER),
                new ZclDataType("Unsigned 24-bit integer", typeof(uint), 0x22, true, DataType.UNSIGNED_24_BIT_INTEGER),
                new ZclDataType("Unsigned 32-bit integer", typeof(uint), 0x23, true, DataType.UNSIGNED_32_BIT_INTEGER),
                new ZclDataType("Unsigned 40-bit integer", typeof(ulong), 0x24, true, DataType.UNSIGNED_40_BIT_INTEGER),
                new ZclDataType("Unsigned 48-bit integer", typeof(ulong), 0x25, true, DataType.UNSIGNED_48_BIT_INTEGER),
                new ZclDataType("Unsigned 56-bit integer", typeof(ulong), 0x26, true, DataType.UNSIGNED_56_BIT_INTEGER),
                new ZclDataType("Unsigned 64-bit integer", typeof(ulong), 0x27, true, DataType.UNSIGNED_64_BIT_INTEGER),
                new ZclDataType("Signed 8-bit Integer", typeof(sbyte), 0x28, true, DataType.SIGNED_8_BIT_INTEGER),
                new ZclDataType("Signed 16-bit Integer", typeof(short), 0x29, true, DataType.SIGNED_16_BIT_INTEGER),
                new ZclDataType("Signed 24-bit Integer", typeof(int), 0x2A, true, DataType.SIGNED_24_BIT_INTEGER),
                new ZclDataType("Signed 32-bit Integer", typeof(int), 0x2B, true, DataType.SIGNED_32_BIT_INTEGER),
                new ZclDataType("Signed 40-bit Integer", typeof(long), 0x2C, true, DataType.SIGNED_40_BIT_INTEGER),
                new ZclDataType("Signed 48-bit Integer", typeof(long), 0x2D, true, DataType.SIGNED_48_BIT_INTEGER),
                new ZclDataType("Signed 56-bit Integer", typeof(long), 0x2E, true, DataType.SIGNED_56_BIT_INTEGER),
                new ZclDataType("Signed 64-bit Integer", typeof(long), 0x2F, true, DataType.SIGNED_64_BIT_INTEGER),
                new ZclDataType("8-bit Enumeration", typeof(byte), 0x30, false, DataType.ENUMERATION_8_BIT),
                new ZclDataType("16-bit Enumeration", typeof(ushort), 0x31, false, DataType.ENUMERATION_16_BIT),
                new ZclDataType("32-bit Enumeration", typeof(uint), 0x33, false, DataType.ENUMERATION_32_BIT),
                new ZclDataType("Semi precision float", typeof(float), 0x38, true, DataType.FLOAT_16_BIT),
                new ZclDataType("Single precision float", typeof(float), 0x39, true, DataType.FLOAT_32_BIT),
                new ZclDataType("Double precision float", typeof(double), 0x3A, true, DataType.FLOAT_64_BIT),
                new ZclDataType("Octet string", typeof(ByteArray), 0x41, false, DataType.OCTET_STRING),
                new ZclDataType("Character String", typeof(string), 0x42, false, DataType.CHARACTER_STRING),
                new ZclDataType("Long Octet string", typeof(ByteArray), 0x43, false, DataType.LONG_OCTET_STRING),
                new ZclDataType("Long Character String", typeof(string), 0x44, false, DataType.LONG_CHARACTER_STRING),
                new ZclDataType("ARRAY", null, 0x48, false, DataType.ORDERED_SEQUENCE_ARRAY),
                new ZclDataType("ORDERED_SEQUENCE_STRUCTURE", null, 0x4C, false, DataType.ORDERED_SEQUENCE_STRUCTURE),
                new ZclDataType("SET", null, 0x50, false, DataType.COLLECTION_SET),
                new ZclDataType("COLLECTION_BAG", null, 0x51, false, DataType.COLLECTION_BAG),
                new ZclDataType("Time", null, 0xE0, true, DataType.TIME_OF_DAY),
                new ZclDataType("Date", null, 0xE1, true, DataType.DATE),
                new ZclDataType("UTCTime", typeof(DateTime), 0xE2, true, DataType.UTCTIME),
                new ZclDataType("ClusterId", typeof(int), 0xE8, false, DataType.CLUSTERID),
                new ZclDataType("AttributeId", null, 0xE9, false, DataType.ATTRIBUTEID),
                new ZclDataType("BACNetId", null, 0xEA, false, DataType.BACNET_OID),
                new ZclDataType("IEEE Address", typeof(IeeeAddress), 0xF0, false, DataType.IEEE_ADDRESS),
                new ZclDataType("ZigBee Key", typeof(ZigBeeKey), 0xF1, false, DataType.SECURITY_KEY),
                new ZclDataType("Byte array", typeof(ByteArray), 0x00, false, DataType.BYTE_ARRAY),
                new ZclDataType("N X Attribute identifier", typeof(ushort), 0x00, false, DataType.N_X_ATTRIBUTE_IDENTIFIER),
                new ZclDataType("N X Attribute information", typeof(AttributeInformation), 0x00, false, DataType.N_X_ATTRIBUTE_INFORMATION),
                new ZclDataType("N X Attribute record", typeof(AttributeRecord), 0x00, false, DataType.N_X_ATTRIBUTE_RECORD),
                new ZclDataType("N X Attribute report", typeof(AttributeReport), 0x00, false, DataType.N_X_ATTRIBUTE_REPORT),
                new ZclDataType("N X Attribute reporting status record", typeof(AttributeReportingStatusRecord), 0x00, false, DataType.N_X_ATTRIBUTE_REPORTING_STATUS_RECORD),
                new ZclDataType("N X Attribute reporting configuration record", typeof(AttributeReportingConfigurationRecord), 0x00, false, DataType.N_X_ATTRIBUTE_REPORTING_CONFIGURATION_RECORD),
                new ZclDataType("N X Attribute selector", typeof(object), 0x00, false, DataType.N_X_ATTRIBUTE_SELECTOR),
                new ZclDataType("N X Attribute status record", typeof(AttributeStatusRecord), 0x00, false, DataType.N_X_ATTRIBUTE_STATUS_RECORD),
                new ZclDataType("N x Extended Attribute Information", typeof(ExtendedAttributeInformation), 0x00, false, DataType.N_X_EXTENDED_ATTRIBUTE_INFORMATION),
                new ZclDataType("N X Extension field set", typeof(ExtensionFieldSet), 0x00, false, DataType.N_X_EXTENSION_FIELD_SET),
                new ZclDataType("N X Neighbors information", typeof(NeighborInformation), 0x00, false, DataType.N_X_NEIGHBORS_INFORMATION),
                new ZclDataType("N X Read attribute status record", typeof(ReadAttributeStatusRecord), 0x00, false, DataType.N_X_READ_ATTRIBUTE_STATUS_RECORD),
                new ZclDataType("N x Unsigned 8-bit Integer", typeof(List<byte>), 0x00, false, DataType.N_X_UNSIGNED_8_BIT_INTEGER),
                new ZclDataType("N X Unsigned 16-bit integer", typeof(List<ushort>), 0x00, false, DataType.N_X_UNSIGNED_16_BIT_INTEGER),
                new ZclDataType("N X Write attribute record", typeof(WriteAttributeRecord), 0x00, false, DataType.N_X_WRITE_ATTRIBUTE_RECORD),
                new ZclDataType("N X Write attribute status record", typeof(WriteAttributeStatusRecord), 0x00, false, DataType.N_X_WRITE_ATTRIBUTE_STATUS_RECORD),
                new ZclDataType("X Unsigned 8-bit integer", typeof(List<byte>), 0x00, false, DataType.X_UNSIGNED_8_BIT_INTEGER),
                new ZclDataType("Zcl Status", typeof(ZclStatus), 0x00, false, DataType.ZCL_STATUS),
                new ZclDataType("EXTENDED_PANID", typeof(ExtendedPanId), 0x00, false, DataType.EXTENDED_PANID),
                new ZclDataType("Binding Table", typeof(BindingTable), 0x00, false, DataType.BINDING_TABLE),
                new ZclDataType("Complex Descriptor", typeof(ComplexDescriptor), 0x00, false, DataType.COMPLEX_DESCRIPTOR),
                new ZclDataType("Endpoint", typeof(int), 0x00, false, DataType.ENDPOINT),
                new ZclDataType("Neighbor Table", typeof(NeighborTable), 0x00, false, DataType.NEIGHBOR_TABLE),
                new ZclDataType("Node Descriptor", typeof(NodeDescriptor), 0x00, false, DataType.NODE_DESCRIPTOR),
                new ZclDataType("NWK address", typeof(ushort), 0x00, false, DataType.NWK_ADDRESS),
                new ZclDataType("N x Binding Table", typeof(BindingTable), 0x00, false, DataType.N_X_BINDING_TABLE),
                new ZclDataType("N X IEEE Address", typeof(ulong), 0x00, false, DataType.N_X_IEEE_ADDRESS),
                new ZclDataType("Power Descriptor", typeof(PowerDescriptor), 0x00, false, DataType.POWER_DESCRIPTOR),
                new ZclDataType("Routing Table", typeof(RoutingTable), 0x00, false, DataType.ROUTING_TABLE),
                new ZclDataType("Simple Descriptor", typeof(SimpleDescriptor), 0x00, false, DataType.SIMPLE_DESCRIPTOR),
                new ZclDataType("User Descriptor", typeof(UserDescriptor), 0x00, false, DataType.USER_DESCRIPTOR),
                new ZclDataType("Zdo Status", typeof(ZdoStatus), 0x00, false, DataType.ZDO_STATUS),
                new ZclDataType("Unsigned 8 bit Integer Array", typeof(byte[]), 0x00, false, DataType.UNSIGNED_8_BIT_INTEGER_ARRAY),
                new ZclDataType("RAW_OCTET", typeof(ByteArray), 0x00, false, DataType.RAW_OCTET),
                new ZclDataType("ZigBee Data Type", typeof(ZclDataType), 0x00, false, DataType.ZIGBEE_DATA_TYPE),
            };

        private static Dictionary<int, ZclDataType> _codeTypeMapping;
        private static ZclDataTypeDictionnary _codeTypeMappingKeyed;
        private static ZclDataTypeDirectArray _codeTypeMappingArray;
        private static ZclDataTypeSquareArray _codeTypeMappingSquareArray;


        internal Type DataClass { get; set; }
        public string Label { get; set; }
        public int Id { get; set; }
        public bool IsAnalog { get; set; }
        public DataType DataType { get; set; }

        public ZclDataType()
        {

        }

        private ZclDataType(string label, Type dataClass, int id, bool analogue, DataType dataType)
        {
            this.Label = label;
            this.DataClass = dataClass;
            this.Id = id;
            this.IsAnalog = analogue;
            this.DataType = dataType;
        }

        public static Dictionary<int, ZclDataType> CreateDict()
        {
            var d=new Dictionary<int, ZclDataType>(InitData.Length);
            foreach (var v in InitData)
                d.Add((int)v.DataType,v);
            return d;
        }

        public static ZclDataTypeDictionnary CreateZclDataTypeDictionnary()
        {
            var d = new ZclDataTypeDictionnary();
            foreach (var v in InitData)
                d.Add(v);
            return d;
        } 
        public static ZclDataTypeDirectArray CreateZclDataTypeDirectArray()
        {
            var d = new ZclDataTypeDirectArray();
            foreach (var v in InitData)
                d.Add(v);
            return d;
        }
        
        public static ZclDataTypeSquareArray CreateZclDataTypeSquareArray()
        {
            var d = new ZclDataTypeSquareArray();
            foreach (var v in InitData)
                d.Add(v);
            return d;
        } 

        static ZclDataType()
        {
            _codeTypeMapping = CreateDict();
            _codeTypeMappingKeyed = CreateZclDataTypeDictionnary();
            _codeTypeMappingArray = CreateZclDataTypeDirectArray();
            _codeTypeMappingSquareArray = CreateZclDataTypeSquareArray();
        }

        public static ZclDataType Get(int id)
        {
            return _codeTypeMapping[id];
        }

        public static ZclDataType Get(DataType type)
        {
            return _codeTypeMapping.Values.Single(dt => dt.DataType == type);
        }

        public static ZclDataType GetKeyedValue(DataType type)
        {
            return _codeTypeMappingKeyed[type];
        }

        public static ZclDataType GetArray(DataType type)
        {
            return _codeTypeMappingArray[type];
        }
        
        public static ZclDataType GetSquareArray(DataType type)
        {
            return _codeTypeMappingSquareArray[type];
        }
        
        public override string ToString()
        {
            return Label;
        }


        public class ZclDataTypeDictionnary : KeyedCollection<DataType,ZclDataType>
        {
            
            protected override DataType GetKeyForItem(ZclDataType item)
            {
                return item.DataType ;
            }
        }

        public class ZclDataTypeSquareArray : IEnumerable<ZclDataType>
        {
            ZclDataType[][] _values;
            const int _rowSizeBit=4;
            const int _columnSizeBit=(8-_rowSizeBit);
            const int _rowCount=0x01<<_rowSizeBit;
            const int _columnCount=256>>_rowSizeBit;
            const int _columnMask=0xff>>_rowSizeBit;


            public ZclDataTypeSquareArray()
            {
                _values = new ZclDataType[_rowCount][];
            }
            
            public void Add(ZclDataType data)
            {
                int row = ((byte)data.DataType)>>_columnSizeBit;
                int column = ((byte)data.DataType) & _columnMask;
                ZclDataType[] _row = _values[row] ?? (_values[row] = new ZclDataType[_columnCount]);
                _row[column]=data;
            }

            public ZclDataType this[DataType data] => _values[((byte)data)>>_columnSizeBit]?[((byte)data) & _columnMask];

            IEnumerator<ZclDataType> IEnumerable<ZclDataType>.GetEnumerator()
            {
                for (int i=0;i<_rowCount;i++)
                    for (int j=0;j<_columnCount;j++)
                        if (_values[i]?[j]!=null)
                            yield return _values[i][j];
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ((IEnumerable<ZclDataType>)this).GetEnumerator();
        }

        public class ZclDataTypeDirectArray : IEnumerable<ZclDataType>
        {
            ZclDataType[] _values;
            public ZclDataTypeDirectArray()
            {
                _values = new ZclDataType[256];
            }

            public void Add(ZclDataType data)
            {
                _values[(byte)data.DataType]=data;
            }

            public ZclDataType this[DataType data] => _values[((byte)data)];

            IEnumerator<ZclDataType> IEnumerable<ZclDataType>.GetEnumerator() => _values.Where( d => !(d is null)).GetEnumerator();

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => ((IEnumerable<ZclDataType>)this).GetEnumerator();

        }

    }
}

