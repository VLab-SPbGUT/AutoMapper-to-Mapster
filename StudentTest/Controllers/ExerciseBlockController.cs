
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace StudentTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseBlockController(ExerciseBlockService service) : ControllerBase
    {

        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/ExerciseBlock/GetAll'
        /// (Юль, тебе если все надо достать, пихай в запрос вот эту ссылку ок?
        /// (Возможно 7234 надо поменять будет))
        /// </summary>
        /// <returns>Returns exery exerciseBlocks from database</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllExerciseBlocks()
        {
            return Ok(await service.GetAllExerciseBlocks());
        }

        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/ExerciseBlock/GetById/{Id}'
        /// (Юль, вот эту ссулку пихай, если тебе надо взять конкретный exerciseBlock ок?)
        /// </summary>
        /// <param name="Id">Id of exerciseBlock, that you want to take</param>
        /// <returns>Return exerciseBlock by given id</returns>
        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetExerciseBlockById(Guid Id)
        {
            StudentExerciseBlock exerciseBlock;
            try
            {
                exerciseBlock = await service.GetExerciseBlockById(Id);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(exerciseBlock);
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/ExerciseBlock/GetByLessonId/{id}'
        /// (Юль, вот эту пихай, когда тебе надо будет, чтобы чел посмотрел какие exerciseBlock есть в lesson ок?)
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetByLessonId/{Id}")]
        public async Task<IActionResult> GetExerciseBlocksByLessonId(Guid Id)
        {
            ICollection<StudentExerciseBlock> exerciseBlocks;
            exerciseBlocks = await service.GetExerciseBlockForLesson(Id);

            return Ok(exerciseBlocks);
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/ExerciseBlock/Add'
        /// Used to add new ExercisesBlock to db, must exist Lesson
        /// </summary>
        /// <param name="exerciseBlockDto"></param>
        /// <returns>If succesfull, then 200, else 500</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddExerciseBlock(StudentExerciseBlock exerciseBlockDto)
        {
            try
            {
                await service.SaveExerciseBlock(exerciseBlockDto);
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

            return Ok();
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/ExerciseBlock/Update/{Id}'
        /// Used to update exerciseBlock, that already exist
        /// </summary>
        /// <param name="exerciseBlockDto"></param>
        /// <param name="Id"></param>
        /// <returns>If succesfull, then 200, else 500</returns>
        [HttpPut("Update/{Id}")]
        public async Task<IActionResult> ChangeExerciseBlock(Guid Id, StudentExerciseBlock exerciseBlockDto)
        {
            try
            {
                await service.UpdateExerciseBlock(Id, exerciseBlockDto);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/ExerciseBlock/Delete/{Id}'
        /// Used to delete exerciseBlock, that already exist
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>If succesful, then 200, else 500</returns>
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            try
            {
                await service.DeleteExerciseBlock(Id);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok();
        }
    }
}
