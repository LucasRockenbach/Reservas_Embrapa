using System.ComponentModel.DataAnnotations;
using Aula7.Data;

namespace Aula7.Models
{
    public class Salas
    {
        [Required]
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int capacidade { get; set; }

        public Boolean disponibilidade { get; set; }
        public String descricao { get; set;}
        public String bloco { get; set;}

        public int andar { get; set;}

        public int numero { get; set;}
    }


public static class SalasEndpoints
{
	public static void MapSalasEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/Salas", async (AulaDbContext db) =>
        {
            return await db.Salas.ToListAsync();
        })
        .WithName("GetAllSalass")
        .Produces<List<Salas>>(StatusCodes.Status200OK);

        routes.MapGet("/api/Salas/{id}", async (int id, AulaDbContext db) =>
        {
            return await db.Salas.FindAsync(id)
                is Salas model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetSalasById")
        .Produces<Salas>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/Salas/{id}", async (int id, Salas salas, AulaDbContext db) =>
        {
            var foundModel = await db.Salas.FindAsync(id);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(salas);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateSalas")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Salas/", async (Salas salas, AulaDbContext db) =>
        {
            db.Salas.Add(salas);
            await db.SaveChangesAsync();
            return Results.Created($"/Salass/{salas.id}", salas);
        })
        .WithName("CreateSalas")
        .Produces<Salas>(StatusCodes.Status201Created);


        routes.MapDelete("/api/Salas/{id}", async (int id, AulaDbContext db) =>
        {
            if (await db.Salas.FindAsync(id) is Salas salas)
            {
                db.Salas.Remove(salas);
                await db.SaveChangesAsync();
                return Results.Ok(salas);
            }

            return Results.NotFound();
        })
        .WithName("DeleteSalas")
        .Produces<Salas>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}}
