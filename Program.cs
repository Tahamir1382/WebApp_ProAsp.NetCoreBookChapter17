//nptes: what is the services property?


using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using System.Text.Json;

//the WebApplication class i used for making http pipelines and managing the connection
var builder = WebApplication.CreateBuilder(args); //this method initializes a new instance of the WebApplication class; the arguments are probebly the same as the main method args; yes they are the command line arguments
builder.Services.AddDbContext<DataContext>(opts => {
    opts.UseSqlServer(builder.Configuration[      //this adds new config to the builder
        "ConnectionStrings:ProductConnection"]);
    opts.EnableSensitiveDataLogging(true); //idont fully understand this piece of code?
});

builder.Services.AddControllers(); //defines the services that are required by the mvc framework
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
var app = builder.Build(); //returns the fully configed WebApplication instance

app.MapControllers(); //defines routes that handles requests

//const string BASEURL = "api/products"; //part of the minimal api

//app.MapGet($"{BASEURL}/{{id}}", async (HttpContext context, DataContext data) => {
//    string? id = context.Request.RouteValues["id"] as string;
//    if (id != null) {
//        Product? p = data.Products.Find(long.Parse(id)); //Dbset class has a method called Find that well idiot, take a guess... yea it finds an instance with the given primary key now idont know how that is mapped to the database 
//        if (p == null)
//        {
//            context.Response.StatusCode = StatusCodes.Status404NotFound;
//        }
//        else
//        {
//            context.Response.ContentType = "application/json";
//            await context.Response.WriteAsync(JsonSerializer.Serialize<Product>(p));
//        }
//    }
//});

//app.MapGet(BASEURL, async (HttpContext context, DataContext data) => { 
//    context.Response.ContentType = "application/json";
//    await context.Response.WriteAsync(JsonSerializer.Serialize<IEnumerable<Product>>(data.Products) + "\n");
//});

//app.MapPost(BASEURL, async (HttpContext context, DataContext data) =>{
//    Product? p = await JsonSerializer.DeserializeAsync<Product>(context.Request.Body);
//    if (p != null)
//    {
//        await data.AddAsync(p);
//        await data.SaveChangesAsync();
//        context.Response.StatusCode = StatusCodes.Status200OK;
//    }
//});

//app.UseMiddleware<WebApp.TestMiddleware>(); //what is exactly middleware?

app.MapGet("/", () => "Hello World!"); //this is basically http GETl; note: uses lambda expressions to show the hello world message

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>(); //this is the database context that we know and love; what is the right side doing exactly?
SeedData.seedDatabase(context); //this static method is used to migrate all the stuff to database compeletly ; the database is empty then we add the data to it

app.Run(); //runs the app
