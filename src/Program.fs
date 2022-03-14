namespace src
#nowarn "20"
open System
open System.Collections.Generic
open System.IO
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.AspNetCore.HttpsPolicy
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open System.ComponentModel.DataAnnotations
open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp.Extensions
open System.Text.Json;
open System.Text.Json.Serialization;


module Program =
    let exitCode = 0

    [<EntryPoint>]
    let main args =

        let builder = WebApplication.CreateBuilder(args)
        
        builder.Services.AddControllers()
        
        builder.Services.AddDbContext<PlanetContext>(
            fun optionsBuilder ->
                printfn "in options builder lambda"
                optionsBuilder.UseInMemoryDatabase("test") |> ignore
            ) 


        let app = builder.Build()

        app.UseHttpsRedirection()
       

        app.UseAuthorization()
        app.MapControllers()

        app.Run()

        exitCode