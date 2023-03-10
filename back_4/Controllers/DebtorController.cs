using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace back_4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DebtorController : ControllerBase
    {
        private readonly DataContext _context;

        public DebtorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Debtor>>> Get()
        {
         

            return Ok(await _context.Debtors.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<List<Debtor>>> Get(int id)
        {
            var DBdeb= await _context.Debtors.FindAsync(id);
            if (DBdeb == null)
                return BadRequest("Debtor not found!");

            return Ok(DBdeb);
        }


        [HttpPost]
        public async Task<ActionResult<List<Debtor>>> AddDebtor(Debtor DBdeb)
        {
            _context.Debtors.Add(DBdeb);
            await _context.SaveChangesAsync();

            return Ok(await _context.Debtors.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<Debtor>>> UpdateDebtor(Debtor request)
        {
            var DBdeb = await _context.Debtors.FindAsync(request.Id);
            if (DBdeb == null)
                return BadRequest("Debtor not found!");

            DBdeb.Name = request.Name;
            DBdeb.FirstName = request.FirstName;  
            DBdeb.Course = request.Course;    
            DBdeb.NumberOfDebt = request.NumberOfDebt;

            await _context.SaveChangesAsync();

            return Ok(await _context.Debtors.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<Debtor>>> Delete(int id)
        {
            var DBdeb = await _context.Debtors.FindAsync(id);
            if (DBdeb == null)
                return BadRequest("Debtor not found!");

            _context.Debtors.Remove(DBdeb);
            return Ok(await _context.Debtors.ToListAsync());
        }


    }
}
