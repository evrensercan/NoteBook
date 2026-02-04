using NoteBook.Controllers;
using NoteBook.Services;

var builder = WebApplication.CreateBuilder(args);

// --- SERVÝSLERÝN EKLENDÝÐÝ BÖLÜM (Build'den Önce Olmalý) ---

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 1. CORS ÝZNÝNÝ TANIMLIYORUZ (Burasý Build'den önce olmalý!)
builder.Services.AddCors(options =>
{
    options.AddPolicy("IzinVer",
        builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// --- ÝNÞAAT BÝTÝYOR ---
var app = builder.Build();

// --- UYGULAMA AYARLARI (Middleware) ---

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 2. CORS ÝZNÝNÝ DEVREYE ALIYORUZ
app.UseCors("IzinVer");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();