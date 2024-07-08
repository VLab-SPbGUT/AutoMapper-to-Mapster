using Infrastructure;
using Domain.Exceptions;
using FluentValidation;
using Domain.Entities;
using Mapster;
using MapsterMapper;

namespace Application.Services
{
    public sealed class LessonService(UnitOfWork unitOfWork, IMapper mapper, IValidator<Lesson> validator)
    {

        private readonly IValidator<Lesson> _validator = validator;

        public async Task<StudentLesson> GetLessonById(Guid id)
        {
            var lesson = await unitOfWork.LessonRepository.GetEntityByIdAsync(id) 
                ?? throw new NullEntityException("Lesson", id);

            return mapper.Map<StudentLesson>(lesson);
        }

        public async Task<ICollection<StudentLesson>> GetLessonsByDisciplineId(Guid disciplineId)
        {
            var lessons = await unitOfWork.LessonRepository.GetEntitiesByAsync(p=>p.DisciplineId ==  disciplineId);

            return mapper.Map<ICollection<StudentLesson>>(lessons);
        }

        public async Task<ICollection<StudentLesson>> GetAllLessons()
        {
            var lessons = await unitOfWork.LessonRepository.GetAllEntitiesAsync();

            return mapper.Map<ICollection<StudentLesson>>(lessons);
        }

        public async Task AddLesson(StudentLesson lessonDto)
        {
            var lesson = mapper.Map<Lesson>(lessonDto);

            var discipline = await unitOfWork.DisciplineRepository.GetEntityByIdAsync(lesson.DisciplineId) 
                ?? throw new NullEntityException("Discipline", lesson.DisciplineId);

            lesson.Discipline = discipline;

            //await _validator.ValidateAndThrowAsync(lesson);

            unitOfWork.LessonRepository.AddEntity(lesson);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateLesson(Guid id, StudentLesson lessonDto)
        {
            var lesson = await unitOfWork.LessonRepository.GetEntityByIdAsync(id) 
                ?? throw new NullEntityException("Lesson", id);

            lesson.Name = lessonDto.Name;
            lesson.LessonNumber = lessonDto.LessonNumber;
            lesson.Theory = lessonDto.Theory;
            lesson.Mark = lessonDto.Mark;
            lesson.CreditedDate = lessonDto.CreditedDate;
            lesson.Intensity = lessonDto.Intensity;
            lesson.IsCredited = lessonDto.IsCredited;
            lesson.Status = lessonDto.Status;
            lesson.Type = lessonDto.Type;
            lesson.TutorId = lessonDto.TutorId;
            lesson.MarkType = lessonDto.MarkType;


           // await _validator.ValidateAndThrowAsync(lesson);

            unitOfWork.LessonRepository.UpdateEntity(lesson);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteLesson(Guid id)
        {
            var lesson = await unitOfWork.LessonRepository.GetEntityByIdAsync(id) 
                ?? throw new NullEntityException("Lesson", id);

            unitOfWork.LessonRepository.DeleteEntity(lesson);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
