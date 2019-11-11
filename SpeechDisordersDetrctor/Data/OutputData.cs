using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeechDisordersDetrctor.Data
{
    class OutPutData
    {
        [ColumnName("Score")]
        public float[] Score;
    }
}
