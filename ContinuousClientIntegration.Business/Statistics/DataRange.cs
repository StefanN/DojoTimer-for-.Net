using System.Collections.Generic;

namespace ContinuousClientIntegration.Business.Statistics
{
    public class DataRange
    {
        public List<DataPoint> DataPoints { get; private set; }
        public string Id { get; private set; }
        public string Description { get; private set; }


        public DataRange(string id, string description)
        {
            DataPoints = new List<DataPoint>();
            Id = id;
            Description = description;
        }
    }
}
