
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace StudentTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController(ExerciseService service) : ControllerBase
    {

        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Exercise/GetAll'
        /// (Юль, тебе если все надо достать, пихай в запрос вот эту ссылку ок?
        /// (Возможно 7234 надо поменять будет))
        /// </summary>
        /// <returns>Returns exery exercise from database</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllExercises()
        {
            return Ok(await service.GetAllExercises());
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Exercise/GetById/{Id}'
        /// (Юль, вот эту ссулку пихай, если тебе надо взять конкретный exercise ок?)
        /// </summary>
        /// <param name="Id">Id of exercise, that you want to take</param>
        /// <returns>Return exercise by given id</returns>
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetExerciseById(Guid Id)
        {
            StudentExercise exercise;
            try
            {
                exercise = await service.GetExerciseById(Id);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(exercise);
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Exercise/GetByExerciseBlockId/{Id}'
        /// (Юль, вот эту пихай, когда тебе надо будет, чтобы чел посмотрел какие exercise есть в exerciseBlock ок?)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetByExerciseBlockId/{Id}")]
        public async Task<IActionResult> GetExerciseByExerciseBlockId(Guid Id)
        {
            ICollection<StudentExercise> exercises;
            try
            {
                exercises = await service.GetExercisesByExerciseBlockId(Id);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }

            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(exercises);
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Exercise/Add'
        /// Used to add new Exercises to db, must exist exerciseBlock
        /// </summary>
        /// <param name="exerciseDto"></param>
        /// <returns>If succesfull, then 200, else 500</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddExercise(StudentExercise exerciseDto)
        {
            try
            {
                await service.AddExercise(exerciseDto);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Add successful");
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Exercise/Update/{Id}'
        /// Used to update exercise, that already exist
        /// </summary>
        /// <param name="exerciseDTO"></param>
        /// <param name="Id"></param>
        /// <returns>If succesfull, then 200, else 500</returns>
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> UpdateExercise(StudentExercise exerciseDTO, Guid Id)
        {
            try
            {
                await service.UpdateExercise(Id, exerciseDTO);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Update succesful");
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Exercise/Delete/{Id}'
        /// Used to delete exercise, that already exist
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>If succesful, then 200, else 500</returns>
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteExercise(Guid Id)
        {
            try
            {
                await service.DeleteExercise(Id);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok("Delete successful");
        }
    }
}
