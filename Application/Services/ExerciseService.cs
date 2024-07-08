using Infrastructure;
using Domain.Exceptions;
using FluentValidation;
using Domain.Entities;
using MapsterMapper;


namespace Application.Services
{
    public sealed class ExerciseService(UnitOfWork unitOfWork, IMapper mapper, IValidator<Exercise> validator)
    {

        private readonly IValidator<Exercise> _validator = validator;

        public async Task<StudentExercise> GetExerciseById(Guid Id)
        {
            var exercise = await unitOfWork.ExerciseRepository.GetEntityByIdAsync(Id) 
                ?? throw new NullEntityException("Exercise", Id);

            return mapper.Map<StudentExercise>(exercise);
        }

        public async Task<ICollection<StudentExercise>> GetExercisesByExerciseBlockId(Guid exerciseBlockId)
        {
            var exercises = await unitOfWork.ExerciseRepository.GetEntitiesByAsync(p=>p.ExerciseBlockId == exerciseBlockId);

            return mapper.Map<ICollection<StudentExercise>>(exercises);
        }

        public async Task<ICollection<StudentExercise>> GetAllExercises()
        {
            var exercises = await unitOfWork.ExerciseRepository.GetAllEntitiesAsync();

            return mapper.Map<ICollection<StudentExercise>>(exercises);
        }

        public async Task AddExercise(StudentExercise exerciseDto)
        {
            var exercise = mapper.Map<Exercise>(exerciseDto);

            exercise.ExerciseBlock = await unitOfWork.ExerciseBlockRepository.GetEntityByIdAsync(exercise.ExerciseBlockId) 
                ?? throw new NullEntityException("Exercise block", exercise.ExerciseBlockId);

            //await _validator.ValidateAndThrowAsync(exercise);

            unitOfWork.ExerciseRepository.AddEntity(exercise);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateExercise(Guid Id, StudentExercise exerciseDto)
        {
            var exercise = await unitOfWork.ExerciseRepository.GetEntityByIdAsync(Id) 
                ?? throw new NullEntityException("Exercise", Id);

            exercise.Name = exerciseDto.Name;
            exercise.Intensity = exerciseDto.Intensity;
            exercise.ExerciseVariant = exerciseDto.ExerciseVariant;
            exercise.IsCredited = exerciseDto.IsCredited;
            exercise.CreditedDate = exerciseDto.CreditedDate;
            exercise.Example = exerciseDto.Example;
            exercise.ExerciseNumber = exerciseDto.ExerciseNumber;
            exercise.Mark = exerciseDto.Mark;
            exercise.Status = exerciseDto.Status;
            exercise.Type = exerciseDto.Type;
            exercise.MethodicalInstructions = exerciseDto.MethodicalInstructions;
            exercise.Test = exerciseDto.Test ?? exercise.Test;
            exercise.Status = exerciseDto.Status;
            exercise.Answers = mapper.Map<List<AnswerOption>>(exerciseDto.Answers);
            
            //await _validator.ValidateAndThrowAsync(exercise);
          
            unitOfWork.ExerciseRepository.UpdateEntity(exercise);

            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteExercise(Guid Id)
        {
            var exercise = await unitOfWork.ExerciseRepository.GetEntityByIdAsync(Id) 
                ?? throw new NullEntityException("Exercise", Id);

            unitOfWork.ExerciseRepository.DeleteEntity(exercise);

            await unitOfWork.SaveChangesAsync();
        }
    }
}
