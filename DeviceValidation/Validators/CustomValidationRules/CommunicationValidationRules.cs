using System;
using System.Collections.Generic;
using DeviceV2.Util;
using FluentValidation;

namespace DeviceV2.Validators.CustomValidationRules
{
    public static class CommunicationValidationRules
    {
        public static IRuleBuilderOptions<T, long> ValidateCallType<T>(this IRuleBuilder<T, long> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, callType, context) =>
            {
                /*
                    0: Emergency call started
                    1: Call started by the watch
                    2: Call declined by the watch
                    3: Call from parent to watch
                    4: Call from watch to parent
                    5: Missed call from parent
                    6: Call ended
                 */
                var allowedCallTypes = new List<long>() { 0, 1, 2, 3, 4, 5, 6 };

                context.MessageFormatter
                    .AppendArgument("AllowedCallTypes", allowedCallTypes.ConvertListToString(", "));

                return allowedCallTypes.Contains(callType);
            }).WithMessage("[{PropertyName}] of [{PropertyValue}] must be within allowed range of [{AllowedCallTypes}]");
        }

        public static IRuleBuilderOptions<T, long> ValidateMessageType<T>(this IRuleBuilder<T, long> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, messageType, context) =>
            {
                /*
                    0: MMS with attachment (in that case parameter "attachment"
                       is mandatory)
                    1: MMS Group message (in that case parameter "attachment" is
                       forbidden and should not be present)
                    2: Regular message (in that case parameter "attachment" is
                       forbidden and should not be present)
                 */
                var allowedMessageTypes = new List<long>() { 0, 1, 2 };

                context.MessageFormatter
                    .AppendArgument("AllowedMessageTypes", allowedMessageTypes.ConvertListToString(", "));

                return allowedMessageTypes.Contains(messageType);
            }).WithMessage("[{PropertyName}] of [{PropertyValue}] must be within allowed range of [{AllowedMessageTypes}]");
        }

        public static IRuleBuilderOptions<T, long> ValidateMessageDirection<T>(this IRuleBuilder<T, long> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, direction, context) =>
            {
                /*
                    0: Incoming to watch
                    1: Outgoing from watch
                 */
                var allowedDirections = new List<long>() { 0, 1 };

                context.MessageFormatter
                    .AppendArgument("AllowedDirections", allowedDirections.ConvertListToString(", "));

                return allowedDirections.Contains(direction);
            }).WithMessage("[{PropertyName}] of [{PropertyValue}] must be within allowed range of [{AllowedDirections}]");
        }

        public static IRuleBuilderOptions<T, string> ValidateCellNetworkTypes<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.Must((rootObject, network, context) =>
            {
                /*
                    NOTE: Below information about the valid network types from source below
                    https://www.eeweb.com/cellular-network-types/

                    GSM: Global System for Mobile Communication means that
                    cellular phones connect to it by searching for cells in the immediate vicinity.

                    GPRS: General Packet Radio Service permits for advanced data services.

                    CDMA: Code Division Multiple Access is a form of multiplexing,
                    which allows numerous signals to occupy a single transmission
                    channel, optimizing the use of available bandwidth.

                    MOBITEX: Mobitex is originally designed for text pagers with 512
                    bytes of data transmission rate.

                    EDGE: Enhanced Data for Global Evolution is an extension to the GSM/GPRS
                    networks. EDGE supports peak theoretical network data rates of 474 kbps,
                    with average throughput of 70 to 130 kbps on both the downlink and the uplink.
                */
                var allowedNetworks = new List<string>() { "GSM", "GPRS", "CDMA", "MOBITEX", "EDGE" };

                context.MessageFormatter
                    .AppendArgument("AllowedNetworks", allowedNetworks.ConvertListToString(", "));

                return allowedNetworks.Contains(network.ToUpper());
            }).WithMessage("[{PropertyName}] of [{PropertyValue}] must be within allowed range of [{AllowedNetworks}]");
        }
    }
}
