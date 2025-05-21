namespace EmployeeAdminPortal.Models
{
    public class AddPayrollDto
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public decimal GrossPay { get; set; }
        public decimal NetPay { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Salary { get; set; }
        public decimal Benefits { get; set; }
        public decimal Incentives { get; set; }

    }
}
