//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:3.0.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZigBeeNet.Hardware.Ember.Ezsp.Command
{
    using ZigBeeNet.Hardware.Ember.Internal.Serializer;
    using ZigBeeNet.Hardware.Ember.Ezsp.Structure;
    
    
    /// <summary>
    /// Class to implement the Ember EZSP command " clearTemporaryDataMaybeStoreLinkKey ".
    /// Clears the temporary data associated with CBKE and the key establishment, most notably the
    /// ephemeral public/private key pair. If storeLinKey is true it moves the unverified link key
    /// stored in temporary storage into the link key table. Otherwise it discards the key.
    /// This class provides methods for processing EZSP commands.
    /// </summary>
    public class EzspClearTemporaryDataMaybeStoreLinkKeyResponse : EzspFrameResponse
    {
        
        public const int FRAME_ID = 161;
        
        /// <summary>
        ///  The result of the CBKE operation.
        /// </summary>
        private EmberStatus _status;
        
        public EzspClearTemporaryDataMaybeStoreLinkKeyResponse(int[] inputBuffer) : 
                base(inputBuffer)
        {
            _status = deserializer.DeserializeEmberStatus();
        }
        
        /// <summary>
        /// The status to set as <see cref="EmberStatus"/> </summary>
        public void SetStatus(EmberStatus status)
        {
            _status = status;
        }
        
        /// <summary>
        ///  The result of the CBKE operation.
        /// Return the status as <see cref="EmberStatus"/>
        /// </summary>
        public EmberStatus GetStatus()
        {
            return _status;
        }
        
        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            builder.Append("EzspClearTemporaryDataMaybeStoreLinkKeyResponse [status=");
            builder.Append(_status);
            builder.Append(']');
            return builder.ToString();
        }
    }
}