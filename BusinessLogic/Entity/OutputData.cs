using Microsoft.ML.Data;

namespace BusinessLogic.Entity
{
    public class OutputData
    {
        [ColumnName("PredictedLabel")]
        public bool Class { get; set; }
    }
}
