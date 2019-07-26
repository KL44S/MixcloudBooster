using System.Collections.Generic;

namespace Model
{
    public class BoostUser
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public IList<AuthToken> AuthTokens { get; set; }
    }
}
