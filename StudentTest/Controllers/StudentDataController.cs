namespace StudentTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDataController(StudentDataService service) : ControllerBase
    {
        [HttpGet("{disciplineId:guid}/{lessonId:guid}/{groupNumber}")]
        public async Task<IActionResult> GetStudentData(Guid disciplineId, string groupNumber, Guid lessonId)
        {
            try
            {
                return Ok(await service.GetStudentsData(disciplineId, lessonId, groupNumber));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{lessonId:guid}")]
        public async Task<IActionResult> GetLessonData(Guid lessonId)
        {
            try
            {
                return Ok(await service.GetLessonData(lessonId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}