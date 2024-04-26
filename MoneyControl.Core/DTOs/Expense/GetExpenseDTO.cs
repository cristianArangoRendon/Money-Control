namespace MoneyControl.Core.DTOs.Expense
{
    public  class GetExpenseDTO
    {
        public int id { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public string Frequency { get; set; }
        public int idUser { get; set; }
    }
}
