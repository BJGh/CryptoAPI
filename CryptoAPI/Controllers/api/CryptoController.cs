using Microsoft.AspNetCore.Mvc;
//using System.Data.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CryptoAPI.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly DataContext _context;
        public CryptoController(DataContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<List<Crypto>>> AddCrypto(Crypto crypto)
        {
            _context.cryptos.Add(crypto);
            await _context.SaveChangesAsync();

            return Ok(await _context.cryptos.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Crypto>>> GetAllCryptos()
        {
            return Ok(await _context.cryptos.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Crypto>> GetCrypto(int id)
        {
            var crypto = await _context.cryptos.FindAsync(id);
            if(crypto == null)
            {
                return BadRequest("Not exist");
            }
            return Ok(crypto);
        }
        [HttpPut]
        public async Task<ActionResult<List<Crypto>>> UpdateCrypto(Crypto request)
        {
            var crypto = await _context.cryptos.FindAsync(request.Id);
            if (crypto == null)
            {
                return NotFound("Not exist");
            }
            crypto.trTo = request.trTo;
            crypto.trFrom = request.trFrom;
            crypto.client = request.client;
            crypto.transferDate = request.transferDate;
            crypto.balance = request.balance;
            crypto.transferType = request.transferType;
            crypto.cryptoAmount = request.cryptoAmount;
            crypto.currencyType = request.currencyType;
            return Ok(await _context.cryptos.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Crypto>> DeleteCrypto(int id)
        {
            var dBcrypto = await _context.cryptos.FindAsync(id);
            if (dBcrypto == null)
            {
                return BadRequest("Not exist");
            }
            _context.cryptos.Remove(dBcrypto);
            await _context.SaveChangesAsync();
            return Ok(await _context.cryptos.ToListAsync());
        }

    }
}
