var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

List<Disciplina> MinhasDisciplinas = new List<Disciplina>();


MinhasDisciplinas.Add(new Disciplina{NomeDisciplina = "DSV", CargaHoraria = 80});
MinhasDisciplinas.Add(new Disciplina{NomeDisciplina = "BD", CargaHoraria = 60});
MinhasDisciplinas.Add(new Disciplina{NomeDisciplina = "Redes", CargaHoraria = 45});
MinhasDisciplinas.Add(new Disciplina{NomeDisciplina = "ES", CargaHoraria = 120});


app.MapGet("/disciplinas", () => {
    return MinhasDisciplinas;
});

app.MapGet("/disciplinas/{id}", (int id) => {
    var disciplinas = MinhasDisciplinas.FirstOrDefault(d => d.Id == id);
    if (disciplinas is null){
        return Results.NotFound();
    }
    return Results.Ok(disciplinas);
});

app.MapPost("/disciplinas", (Disciplina novaDisciplina) => {
    MinhasDisciplinas.Add(novaDisciplina);
    return Results.Created($"/disciplinas/{novaDisciplina.Id}", novaDisciplina);
});

app.MapPut("/disciplinas/{id}", (int id, Disciplina disciplinaAtualizada) => {
    var disciplina = MinhasDisciplinas.FirstOrDefault(d => d.Id == id);
    if (disciplina is null){
        return Results.NotFound();
    }
    disciplina.NomeDisciplina = disciplinaAtualizada.NomeDisciplina;
    disciplina.CargaHoraria = disciplinaAtualizada.CargaHoraria;
    return Results.Ok(disciplina);
});

app.MapDelete("/disciplinas/{id}", (int id) => {
    var disciplina = MinhasDisciplinas.FirstOrDefault(d => d.Id == id);
    if (disciplina is null){
        return Results.NotFound();
    }
    MinhasDisciplinas.Remove(disciplina);
    return Results.Ok("Disciplina removida com sucesso!");
});

app.Run();


