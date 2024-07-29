using JugSolverApp.Models;
using JugSolverApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace JugSolverApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JugController : ControllerBase
    {
        private readonly JugSolverService _jugSolver;

        public JugController()
        {
            _jugSolver = new JugSolverService();
        }

        [HttpPost("solve")]
        public IActionResult Solve([FromBody] JugInput input)
        {
            if (input.CapX <= 0 || input.CapY <= 0)
            {
                return BadRequest("Capacities must be positive integers greater than zero.");
            }

            if (input.DesiredAmount < 0)
            {
                return BadRequest("Desired amount must be a non-negative integer.");
            }

            if (input.DesiredAmount > input.CapX + input.CapY)
            {
                return BadRequest("Desired amount cannot be greater than the sum of the capacities.");
            }

            var result = _jugSolver.Solve(input.CapX, input.CapY, input.DesiredAmount);

            if (result.IsSolvable)
            {
                return Ok(new { Message = "Solvable", Steps = result.Steps });
            }
            else
            {
                return Ok(new { Message = "No solution possible" });
            }
        }
    }
}
