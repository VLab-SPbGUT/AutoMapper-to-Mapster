using Domain.Exceptions;
using FluentValidation;
using Infrastructure;
using MapsterMapper;

namespace Application.Services
{
    public sealed class DisciplineService(UnitOfWork unitOfWork, IMapper mapper, IValidator<Discipline> validator)
    {

        private readonly IValidator<Discipline> _validator = validator;
        public async Task<StudentDiscipline> GetDisciplineById(Guid Id)
        {
            var discipline = await unitOfWork.DisciplineRepository.GetEntityByIdAsync(Id)
                ?? throw new NullEntityException("Discipline", Id);

            return mapper.Map<StudentDiscipline>(discipline);
        }

        public async Task<ICollection<StudentDiscipline>> GetAllDisciplinesAsync()
        {
            var disciplines = await unitOfWork.DisciplineRepository.GetAllEntitiesAsync();

            return mapper.Map<ICollection<StudentDiscipline>>(disciplines);
        }

        public async Task SaveDisciplineAsync(StudentDiscipline disciplineDTO)
        {
            var discipline = mapper.Map<Discipline>(disciplineDTO);

            //await _validator.ValidateAndThrowAsync(discipline);

            unitOfWork.DisciplineRepository.AddEntity(discipline);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateDisciplineAsync(Guid Id, StudentDiscipline disciplineDTO)
        {
            var discipline = await unitOfWork.DisciplineRepository.GetEntityByIdAsync(Id)
                ?? throw new NullEntityException("Discipline", Id);

            discipline.Name = disciplineDTO.Name;
            discipline.TutorFIO = disciplineDTO.TutorFiO;
            discipline.TutorId = disciplineDTO.TutorId;
            discipline.Year = disciplineDTO.Year;
            discipline.Semester = disciplineDTO.Semester;
            discipline.Student = disciplineDTO.Student ?? discipline.Student;
            discipline.IsCredited = disciplineDTO.IsCredited;
            discipline.CreditedDate = disciplineDTO.CreditedDate;
            discipline.Status = disciplineDTO.Status;

            //await _validator.ValidateAndThrowAsync(discipline);

            unitOfWork.DisciplineRepository.UpdateEntity(discipline);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task<ICollection<StudentDiscipline>> GetDisciplinesForStudentAsync(Guid StudentId)
        {
            var disciplines = await unitOfWork.DisciplineRepository.GetEntitiesByAsync(x => x.Student.Id == StudentId);

            return mapper.Map<ICollection<StudentDiscipline>>(disciplines);
        }

        public async Task DeleteDiscipline(Guid id)
        {
            var discipline = await unitOfWork.DisciplineRepository.GetEntityByIdAsync(id)
                ?? throw new NullEntityException("Discipline", id);

            unitOfWork.DisciplineRepository.DeleteEntity(discipline);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
