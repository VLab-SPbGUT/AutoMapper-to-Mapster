
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace StudentTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController(LessonService service) : ControllerBase
    {

        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Lesson/GetAll'
        /// (Юль, тебе если все надо достать, пихай в запрос вот эту ссылку ок?
        /// (Возможно 7234 надо поменять будет))
        /// </summary>
        /// <returns>Returns exery exerciseBlocks from database</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllLessons()
        {
            return Ok(await service.GetAllLessons());
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Lesson/GetById/{Id}'
        /// (Юль, вот эту ссулку пихай, если тебе надо взять конкретный lesson ок?)
        /// </summary>
        /// <param name="id">Id of lesson, that you want to take</param>
        /// <returns>Return lesson by given id</returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetLessonById(Guid id)
        {
            StudentLesson lesson;
            try
            {
                lesson = await service.GetLessonById(id);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(lesson);
        }



        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Lesson/GetByDisciplineId/{id}'
        /// (Юль, вот эту пихай, когда тебе надо будет, чтобы чел посмотрел какие lesson есть в discipline ок?)
        /// </summary>
        /// <param name="disciplineId"></param>
        /// <returns></returns>
        [HttpGet("GetByDisciplineId/{disciplineId}")]
        public async Task<IActionResult> GetLessonForDiscipline(Guid disciplineId)
        {
            ICollection<StudentLesson> lessons;
            try
            {
                lessons = await service.GetLessonsByDisciplineId(disciplineId);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(lessons);
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Lesson/Add'
        /// Used to add new Lesson to db, must exist Discipline
        /// </summary>
        /// <param name="lessonDTO"></param>
        /// <returns>If succesfull, then 200, else 500</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddLesson(StudentLesson lessonDTO)
        {
            try
            {
                await service.AddLesson(lessonDTO);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            catch (DbUpdateException ex)
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
        /// Url to endpoint 'https://localhost:7234/api/Lesson/Update/{Id}'
        /// Used to update lesson, that already exist
        /// </summary>
        /// <param name="lessonDTO"></param>
        /// <param name="id"></param>
        /// <returns>If succesfull, then 200, else 500</returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> ChangeLesson(Guid id, StudentLesson lessonDTO)
        {
            try
            {
                await service.UpdateLesson(id, lessonDTO);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Update successful");
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Lesson/Delete/{Id}'
        /// Used to delete lesson, that already exist
        /// </summary>
        /// <param name="id"></param>
        /// <returns>If succesful, then 200, else 500</returns>
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
            try
            {
                await service.DeleteLesson(id);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }

            return Ok("Delete successful");
        }
    }
}
