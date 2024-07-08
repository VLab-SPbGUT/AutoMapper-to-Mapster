using Domain.Entities;
using Domain.Exceptions;
using FluentValidation;
using Infrastructure;
using MapsterMapper;

namespace Application.Services
{
    public sealed class ExerciseBlockService(UnitOfWork unitOfWork, IMapper mapper, IValidator<ExerciseBlock> validator)
    {

        private readonly IValidator<ExerciseBlock> _validator = validator;

        public async Task<StudentExerciseBlock> GetExerciseBlockById(Guid id)
        {
            var exerciseBlock = await unitOfWork.ExerciseBlockRepository.GetEntityByIdAsync(id)
                ?? throw new NullEntityException("Exercise block", id);

            return mapper.Map<StudentExerciseBlock>(exerciseBlock);
        }

        public async Task<ICollection<StudentExerciseBlock>> GetAllExerciseBlocks()
        {
            var exerciseBlocks = await unitOfWork.ExerciseBlockRepository.GetAllEntitiesAsync();

            return mapper.Map<ICollection<StudentExerciseBlock>>(exerciseBlocks);
        }

        public async Task<ICollection<StudentExerciseBlock>> GetExerciseBlockForLesson(Guid lessonId)
        {
            var exerciseBlocks = await unitOfWork.ExerciseBlockRepository.GetEntitiesByAsync(p => p.LessonId == lessonId);

            return mapper.Map<ICollection<StudentExerciseBlock>>(exerciseBlocks);
        }

        public async Task SaveExerciseBlock(StudentExerciseBlock exerciseBlockDto)
        {
            var exerciseBlock = mapper.Map<ExerciseBlock>(exerciseBlockDto);

            var lesson = await unitOfWork.LessonRepository.GetEntityByIdAsync(exerciseBlockDto.LessonId)
                ?? throw new NullEntityException("Lesson", exerciseBlock.LessonId);

            exerciseBlock.Lesson = lesson;

//            await _validator.ValidateAndThrowAsync(exerciseBlock);

            unitOfWork.ExerciseBlockRepository.AddEntity(exerciseBlock);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateExerciseBlock(Guid id, StudentExerciseBlock exerciseBlockDto)
        {
            var exerciseBlock = await unitOfWork.ExerciseBlockRepository.GetEntityByIdAsync(id)
                ?? throw new NullEntityException("Exercise block", id);


            exerciseBlock.Name = exerciseBlockDto.Name;
            exerciseBlock.Theory = exerciseBlockDto.Theory;
            exerciseBlock.Mark = exerciseBlockDto.Mark;
            exerciseBlock.MarkType = exerciseBlockDto.MarkType;
            exerciseBlock.Type = exerciseBlockDto.Type;
            exerciseBlock.SubType = exerciseBlockDto.SubType;
            exerciseBlock.Status = exerciseBlockDto.Status;
            exerciseBlock.CreditedDate = exerciseBlockDto.CreditedDate;
            exerciseBlock.IsCredited = exerciseBlockDto.IsCredited;
            exerciseBlock.GeneralInformation = exerciseBlockDto.GeneralInformation;


         //   await _validator.ValidateAndThrowAsync(exerciseBlock);

            unitOfWork.ExerciseBlockRepository.UpdateEntity(exerciseBlock);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteExerciseBlock(Guid id)
        {
            var exerciseBlock = await unitOfWork.ExerciseBlockRepository.GetEntityByIdAsync(id)
                ?? throw new NullEntityException("Exercise block", id);

            unitOfWork.ExerciseBlockRepository.DeleteEntity(exerciseBlock);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
