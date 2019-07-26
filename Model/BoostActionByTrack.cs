using System.Collections.Generic;

namespace Model
{
    public class BoostActionByTrack
    {
        public string TrackLink { get; set; }
        public IList<BoostAction> Actions { get; set; }
    }
}
