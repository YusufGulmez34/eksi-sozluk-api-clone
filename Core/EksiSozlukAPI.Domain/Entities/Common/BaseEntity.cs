namespace EksiSozlukAPI.Domain.Entities.Common
{
    public class BaseEntity
    {
        public DateTime CreatedDate { get; set; }   
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
