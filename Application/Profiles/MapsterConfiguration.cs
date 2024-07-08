using Mapster;
using Domain.Entities;
using Application.DTO.Tutor;

namespace Application
{
    public static class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<Discipline, StudentDiscipline>.NewConfig().TwoWays();
            TypeAdapterConfig<Exercise, StudentExercise>.NewConfig().TwoWays();
            TypeAdapterConfig<Lesson, StudentLesson>.NewConfig().TwoWays();
            TypeAdapterConfig<Student, StudentAnswer>.NewConfig().TwoWays();
            TypeAdapterConfig<Exercise, StudentExerciseBlock>.NewConfig().TwoWays();
        }
    }
}