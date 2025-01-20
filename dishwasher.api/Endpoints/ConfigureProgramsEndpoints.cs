using exercise.wwwapi.ViewModels;
using dishwasher.api.Models;
using dishwasher.api.Repository;
using Microsoft.AspNetCore.Mvc;

namespace exercise.wwwapi.Endpoints
{
    public static class ConfigureProgramsEndpoints
    {
        public static string Path { get; } = "path";
        public static void ConfigureGenericModelEndpoint(this WebApplication app)
        {
            var group = app.MapGroup(Path);

            group.MapGet("/", GetPrograms);
            group.MapGet("/{id}", GetGenericModel);
            group.MapPost("/", PostGenericModel);
            group.MapPut("/{id}", PutGenericModel);
            group.MapDelete("/{id}", DeleteGenericModel);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> GetPrograms(IRepository<ProgramModel, Guid> repository)
        {
            try
            {
                return TypedResults.Ok(await repository.GetAll());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetGenericModel(IRepository<ProgramModel, Guid> repository, Guid id)
        {
            try
            {
                return TypedResults.Ok(await repository.Get(id));
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> PostGenericModel(IRepository<ProgramModel, Guid> repository, GenericModelPost entity)
        {
            try
            {
                ProgramModel genericModel = await repository.Add(new ProgramModel { Name = entity.Name });
                return TypedResults.Created($"/{Path}/{genericModel.Id}", genericModel);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> PutGenericModel(IRepository<ProgramModel, Guid> repository, Guid id, GenericModelPut entity) 
        {
            try
            {
                ProgramModel genericModel = await repository.Get(id);
                if (entity.Name != null) genericModel.Name = entity.Name;

                genericModel = await repository.Update(genericModel);
                return TypedResults.Created($"/{Path}/{genericModel.Id}", genericModel);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> DeleteGenericModel(IRepository<ProgramModel, Guid> repository, Guid id)
        {
            try
            {
                ProgramModel genericModel = await repository.Get(id);
                return TypedResults.Ok(new { Deleted = await repository.Delete(id), Name = $"{genericModel.Name}" });
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
