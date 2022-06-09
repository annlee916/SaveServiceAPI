using ServiceAPI;
using System.Globalization;
using System.Text;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

//For temporary testing during development
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});
// end -- For temporary testing during development

var app = builder.Build();

app.MapGet("/", () => "This provides save service to save input data into a file. The file will be saved in local folder, named GamaData.txt.");


app.MapPost("/GamaData", async (GamaModel gamadata) =>
{    
    try
    {   
        try
        {
           // validate input in specified format or criteria         
           DateTime dt = DateTime.ParseExact(gamadata.date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

            if (gamadata.text1.Length > 255 || gamadata.text2.Length > 255)
                return Results.Problem();
        }
        catch
        {
           return Results.Problem();
        }

        StringBuilder builder = new StringBuilder();
        builder.AppendLine(gamadata.id);
        builder.AppendLine(gamadata.text1);
        builder.AppendLine(gamadata.text2);
        builder.AppendLine(gamadata.date);

        await SaveService.SaveToFileAsync("GamaData.txt", builder.ToString());

        return Results.Ok();
    }
    catch {
        return Results.Problem();
    }
    
});

app.UseCors(MyAllowSpecificOrigins);
app.UseHttpsRedirection();

app.Run();
