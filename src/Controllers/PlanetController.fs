namespace src.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.EntityFrameworkCore
open Microsoft.Extensions.Logging
open Microsoft.FSharp.Collections
open System.Collections.Generic 

open src

//type Failure = {
//    Message:string
//    }
//
//type Response 
//    | Success of Planet
//    | Err of Failure

[<ApiController>]
[<Route("[controller]")>]
type PlanetController (logger : ILogger<PlanetController>, ctx : PlanetContext) =
    inherit ControllerBase()
            
    let mutable planets: List<Planet> =
        let pl = List<Planet>()
        pl.Add { PlanetId = 1; Name = "Mercury"; Kind = "Rocky"; Mass = 3.3011 * (10.00**23) }
        pl.Add { PlanetId = 2; Name = "Venus"; Kind = "Rocky"; Mass = 4.867 * 10.00**24 }
        pl
        
    [<HttpGet>]
    member _.GetAll() =
        ctx.planets
        
    [<HttpGet>]
    [<Route("{name}")>]
    member _.GetByName(name:string): Planet  =
          planets.Find( fun p -> p.Name = name)

        
                
    [<HttpGet>]
    [<Route("total")>]    
    member _.GetAllMass() =
         ctx.Planets.ToListAsync().Result.ToArray()
         |> Array.map(fun p -> p.Mass)
           
        
    // post
    [<HttpPost>]
    member _.Post(planet) =
         ctx.planets.Add(planet) |> ignore
         ctx.SaveChanges() |> ignore
        
    // delete
        
        
        