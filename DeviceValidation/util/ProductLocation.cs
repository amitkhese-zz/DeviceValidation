using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DeviceValidation.util
{
    public static class ProductLocation
    {
        public const decimal AccuracyMaxLevel = 500.0M;
        public const decimal AccuracyMaxLevelOfTracker = 100.0M;
        public const string TrackerProductName = "TRACKER";

        // Right now we have single product as a exception, but it can be multiple in future so used KVT here.
        private static List<KeyValue<decimal>> ProductAccuracies = new List<KeyValue<decimal>>() {
                    new KeyValue<decimal>
                    {
                        KeyName = TrackerProductName,
                        value = AccuracyMaxLevelOfTracker
                    },
                };

        public static decimal GetProductsAccuracyMaxLevel(string productId)
        {
            return ProductAccuracies.Where(c => c.KeyName == productId)?.FirstOrDefault()?.value ?? AccuracyMaxLevel;
        }
    }
}
