namespace Model
{
    public class BoostRequest
    {
        public int RequestId { get; set; }
        public RequestState RequestState { get; set; }
        public string AdditionalInfo { get; set; }
        public BoostConfiguration BoostConfiguration { get; set; }
    }
}
