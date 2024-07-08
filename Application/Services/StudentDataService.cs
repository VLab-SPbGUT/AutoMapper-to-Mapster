using Application.DTO.Tutor;
using Domain.Exceptions;
using Infrastructure;
using MapsterMapper;

namespace Application.Services
{
    public class StudentDataService(UnitOfWork unitOfWork, IMapper mapper)
    {
        public async Task<List<StudentData>> GetStudentsData(Guid disciplineId,Guid lessonId, string groupNumber)
        {
            var studentsData = new List<StudentData>();
            
            var disciplines = await unitOfWork.DisciplineRepository
                .GetEntitiesByAsync(p =>
                    p.TutorId == disciplineId &&
                    p.Student.GroupNumber == groupNumber &&
                    p.Lessons.Any(lesson => lesson.TutorId == lessonId));

            foreach (var discipline in disciplines)
            {
                var lesson = await unitOfWork.LessonRepository.GetEntityByAsync(p =>
                    p.TutorId == lessonId &&
                    p.Discipline.Student.GroupNumber == groupNumber);

                var exerciseBlocks = await unitOfWork.ExerciseBlockRepository
                    .GetEntitiesByAsync(p => p.LessonId == lesson.Id);
                
                StudentData studentData = new()
                {
                    StudentId = discipline.Student.Id,
                    WorksCount = exerciseBlocks.Count,
                    WorksDone = exerciseBlocks.Count(p=>p.IsCredited),
                    Status =  lesson.Status,
                    StudentName = discipline.Student.Name,
                    LessonId = lesson.Id
                };
                
                studentsData.Add(studentData);
            }

            return studentsData;
        }

        public async Task<LessonData> GetLessonData(Guid lessonId)
        {
            var lesson = await unitOfWork.LessonRepository.GetEntityByIdAsync(lessonId)
                         ?? throw new NullEntityException("lesson", lessonId);

            var lessonData = new LessonData
            {
                VariantNumber = lesson.Discipline.Student.Variant,
            };

            var exerciseBlocks = await unitOfWork.ExerciseBlockRepository
                .GetEntitiesByAsync(p => p.LessonId == lessonId);
            
            foreach (var exerciseBlock in exerciseBlocks)
            {

                var exercises = await unitOfWork.ExerciseRepository.GetEntitiesByAsync(
                    p => p.ExerciseBlockId == exerciseBlock.Id);
                
                var exerciseBlockData = new ExerciseBlockData
                {
                    Name = exerciseBlock.Name,
                    Type = exerciseBlock.SubType,
                    WorksDone = exercises.Count(p=>p.Status == Status.Done),
                    WorksLeft = exercises.Count(p=>p.Status != Status.Done),
                    WorksOnReview = exercises.Count(p=>p.Status == Status.SentToRevision),
                    ExerciseBlockId = exerciseBlock.Id,
                    Status = exerciseBlock.Status
                };
                
                lessonData.ExerciseBlocksData.Add(exerciseBlockData);
            }

            return lessonData;
        }
    }
}