using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace _002_MultipleImplementations
{
    public class OperationRequest
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty(PropertyName = "operation")]
        public MathOperationType OperationType { get; set; }

        public int X { get; set; }
        public int Y { get; set; }

        public int OperationEnumValue {get;set;}
    }

    public enum MathOperationType
    {
        Add = 0,
        Subtract = 1,
        Multiply = 2,
        Divide = 3
    }
}
