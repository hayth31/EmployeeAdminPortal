using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EmployeeAdminPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PayrollsController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public PayrollsController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/payrolls
        [HttpGet]
        public async Task<IActionResult> GetAllPayrolls()
        {
            return Ok(await dbContext.Payrolls.ToListAsync());
        }

        // GET: api/payrolls/{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetPayroll([FromRoute] Guid id)
        {
            var payroll = await dbContext.Payrolls.FirstOrDefaultAsync(x => x.Id == id);

            if (payroll == null)
            {
                return NotFound();
            }

            return Ok(payroll);
        }

        // POST: api/payrolls
        [HttpPost]
        public async Task<IActionResult> AddPayroll([FromBody] AddPayrollDto addPayrollRequest)
        {
            var payroll = new Payroll()
            {
                Id = Guid.NewGuid(),
                Name = addPayrollRequest.Name,
                Status = addPayrollRequest.Status,
                GrossPay = addPayrollRequest.GrossPay,
                NetPay = addPayrollRequest.NetPay,
                TotalCost = addPayrollRequest.TotalCost,
                Salary = addPayrollRequest.Salary,
                Benefits = addPayrollRequest.Benefits,
                Incentives = addPayrollRequest.Incentives,
            };

            await dbContext.Payrolls.AddAsync(payroll);
            await dbContext.SaveChangesAsync();

            return Ok(payroll);
        }

        // PUT: api/payrolls/{id}
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdatePayroll([FromRoute] Guid id, [FromBody] UpdatePayrollDto updatePayrollRequest)
        {
            var payroll = await dbContext.Payrolls.FindAsync(id);

            if (payroll == null)
            {
                return NotFound();
            }

            payroll.Name = updatePayrollRequest.Name;
            payroll.GrossPay = updatePayrollRequest.GrossPay;
            payroll.NetPay = updatePayrollRequest.NetPay;
            payroll.TotalCost = updatePayrollRequest.TotalCost;
            payroll.Salary = updatePayrollRequest.Salary;
            payroll.Benefits = updatePayrollRequest.Benefits;
            payroll.Incentives = updatePayrollRequest.Incentives;

            await dbContext.SaveChangesAsync();

            return Ok(payroll);
        }

        // DELETE: api/payrolls/{id}
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeletePayroll([FromRoute] Guid id)
        {
            var payroll = await dbContext.Payrolls.FindAsync(id);

            if (payroll == null)
            {
                return NotFound();
            }

            dbContext.Payrolls.Remove(payroll);
            await dbContext.SaveChangesAsync();

            return Ok(payroll);
        }
    }
}
