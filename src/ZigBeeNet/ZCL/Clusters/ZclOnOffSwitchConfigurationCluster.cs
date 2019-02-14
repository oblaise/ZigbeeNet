﻿// License text here

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZigBeeNet.DAO;
using ZigBeeNet.ZCL.Protocol;
using ZigBeeNet.ZCL.Field;

/**
 *On/off Switch Configurationcluster implementation (Cluster ID 0x0007).
 *
 * Attributes and commands for configuring On/Off switching devices *
 * Code is auto-generated. Modifications may be overwritten!
 */
/* Autogenerated: 13.02.2019 - 21:42 */
namespace ZigBeeNet.ZCL.Clusters
{
   public class ZclOnOffSwitchConfigurationCluster : ZclCluster
   {
       /**
       * The ZigBee Cluster Library Cluster ID
       */
       public static ushort CLUSTER_ID = 0x0007;

       /**
       * The ZigBee Cluster Library Cluster Name
       */
       public static string CLUSTER_NAME = "On/off Switch Configuration";

       /* Attribute constants */
       /**
        * The SwitchTypeattribute  specifies  the  basic  functionality  of  the  On/Off  switching  device.       */
       public static ushort ATTR_SWITCHTYPE = 0x0000;

       /**
        * The SwitchActions attribute is 8 bits in length and specifies the commands of the On/Off cluster        * to be generated when the switch moves between its two states       */
       public static ushort ATTR_SWITCHACTIONS = 0x0010;


       // Attribute initialisation
       protected override Dictionary<ushort, ZclAttribute> InitializeAttributes()
       {
           Dictionary<ushort, ZclAttribute> attributeMap = new Dictionary<ushort, ZclAttribute>(2);

           ZclClusterType onoffSwitchConfiguration = ZclClusterType.GetValueById(ClusterType.ON_OFF_SWITCH_CONFIGURATION);

           attributeMap.Add(ATTR_SWITCHTYPE, new ZclAttribute(onoffSwitchConfiguration, ATTR_SWITCHTYPE, "SwitchType", ZclDataType.Get(DataType.ENUMERATION_8_BIT), true, true, false, false));
           attributeMap.Add(ATTR_SWITCHACTIONS, new ZclAttribute(onoffSwitchConfiguration, ATTR_SWITCHACTIONS, "SwitchActions", ZclDataType.Get(DataType.ENUMERATION_8_BIT), true, true, true, false));

        return attributeMap;
       }

       /**
       * Default constructor to create a On/off Switch Configuration cluster.
       *
       * @param zigbeeEndpoint the {@link ZigBeeEndpoint}
       */
       public ZclOnOffSwitchConfigurationCluster(ZigBeeEndpoint zigbeeEndpoint)
           : base(zigbeeEndpoint, CLUSTER_ID, CLUSTER_NAME)
       {
       }

       public Task<CommandResult> GetSwitchTypeAsync()
       {
           return Read(_attributes[ATTR_SWITCHTYPE]);
       }
       public byte GetSwitchType(long refreshPeriod)
       {
           if (_attributes[ATTR_SWITCHTYPE].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_SWITCHTYPE].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_SWITCHTYPE]);
       }

       public Task<CommandResult> SetSwitchActions(object value)
       {
           return Write(_attributes[ATTR_SWITCHACTIONS], value);
       }

       public Task<CommandResult> GetSwitchActionsAsync()
       {
           return Read(_attributes[ATTR_SWITCHACTIONS]);
       }
       public byte GetSwitchActions(long refreshPeriod)
       {
           if (_attributes[ATTR_SWITCHACTIONS].IsLastValueCurrent(refreshPeriod))
           {
               return (byte)_attributes[ATTR_SWITCHACTIONS].LastValue;
           }

           return (byte)ReadSync(_attributes[ATTR_SWITCHACTIONS]);
       }

   }
}