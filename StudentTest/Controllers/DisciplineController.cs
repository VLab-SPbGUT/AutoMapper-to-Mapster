
using Microsoft.EntityFrameworkCore;
using FluentValidation;

namespace StudentTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController(DisciplineService service) : ControllerBase
    {
        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Discipline/GetAll'
        /// (Юль, тебе если все надо достать, пихай в запрос вот эту ссылку ок?
        /// (Возможно 7234 надо поменять будет))
        /// </summary>
        /// <returns>Returns every Discipline from database</returns>
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllDisciplines()
        {
            return Ok(await service.GetAllDisciplinesAsync());
        }

        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Discipline/GetById/{Id}'
        /// (Юль, вот эту ссулку пихай, если тебе надо взять конкретный discipline ок?)
        /// </summary>
        /// <param name="id">Id of Discipline, that you want to take</param>
        /// <returns>Return exerciseBlock by given id</returns>
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetDisciplineById(Guid id)
        {

            StudentDiscipline disciplineDTO;
            try
            {
                disciplineDTO = await service.GetDisciplineById(id);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            return Ok(disciplineDTO);

        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Discipline/GetByStudentId/{id}'
        /// (Юль, вот эту пихай, когда тебе надо будет, чтобы чел посмотрел какие discipline связаны с student?)
        /// ((Это явно будет позже, пока клади болт))
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet("GetByStudentId/{studentId}")]
        public async Task<IActionResult> GetDisciplinesForStudent(Guid studentId)
        {
            return Ok(await service.GetDisciplinesForStudentAsync(studentId));
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Discipline/Add'
        /// Used to add new Discipline to db
        /// </summary>
        /// <param name="disciplineDTO"></param>
        /// <returns>If succesfull, then 200, else 500</returns>
        [HttpPost("Add")]
        public async Task<IActionResult> AddDiscipline(StudentDiscipline disciplineDTO)
        {
            try
            {
                await service.SaveDisciplineAsync(disciplineDTO);
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ValidationException ex) 
            {
                return BadRequest(ex.Message);
            }
  
            return Ok("Saving successful");
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Discipline/Update/{Id}'
        /// Used to update Discipline, that already exist
        /// </summary>
        /// <param name="disciplineDTO"></param>
        /// <param name="id"></param>
        /// <returns>If succesfull, then 200, else 500</returns>
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateDiscipline(Guid id, StudentDiscipline disciplineDTO)
        {
            try
            {
                await service.UpdateDisciplineAsync(id, disciplineDTO);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(ex.InnerException.Message);
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok("Updation successful");
        }


        /// <summary>
        /// Url to endpoint 'https://localhost:7234/api/Discipline/Delete/{Id}'
        /// Used to delete discipline, that already exist
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>If succesful, then 200, else 500</returns>
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteDiscipline(Guid Id)
        {
            try
            {
                await service.DeleteDiscipline(Id);
            }
            catch (NullEntityException ex)
            {
                return NotFound(ex.Message);
            }


            return Ok("Delete successful");
        }
    }
}
