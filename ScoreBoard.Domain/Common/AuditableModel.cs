namespace ScoreBoard.Domain.Common
{
    public class AuditableModel
    {
        public int CretedById { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}
