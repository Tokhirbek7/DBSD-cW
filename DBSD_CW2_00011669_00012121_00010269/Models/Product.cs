namespace DBSD_CW2_00011669_00012121_00010269.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public float? Price { get; set; }
        public string Characteristics { get; set; }
        public string BriefInfo { get; set; }
        public DateTime ProductionDate { get; set; }
        public bool IsCertified { get; set; }
    }
}
