using System.Collections.Generic;

namespace Model
{
    public class BoostConfiguration
    {
        public Plataform Plataform { get; set; }
        public string UserId { get; set; }
        public int FollowsNumber { get; set; }
        public IList<BoostActionByTrack> ActionsByTrack { get; set; }
    }
}
