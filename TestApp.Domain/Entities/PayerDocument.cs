namespace TestApp.Domain.Entities
{
    public class PayerDocument : DocumentEntity
    {
        public short RegnCode { get; set; }
        public short DistCode { get; set; }
        public int InsrNumber { get; set; }
    }
}
