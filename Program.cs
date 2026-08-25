var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ---------- SENİN ENDPOINT'LERİN ----------

app.MapGet("/merhaba", () =>
{
    return "Merhaba, ben Enes! Bu benim ilk API endpoint'im!";
});

app.MapGet("/merhaba/{isim}", (string isim) =>
{
    return $"Merhaba {isim}! API'ye hoş geldin!";
});

app.MapPost("/hesapla/topla", (int[] sayilar) =>
{
    var toplam = sayilar.Sum();
    return new { Sayilar = sayilar, Toplam = toplam };
});

// -------------------------------------------

app.Run();