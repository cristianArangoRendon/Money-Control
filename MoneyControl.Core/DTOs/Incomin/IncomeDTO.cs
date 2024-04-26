namespace MoneyControl.Core.DTOs.Incomin
{
    public class IncomeDTO
    {

        public int id { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public int idUser { get; set; }
        public int idFrequency { get; set; }
    }
}
