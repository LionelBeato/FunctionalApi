namespace src.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
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
            
    let mercury = {Name = "Mercury"; Type = "Rocky"; Mass = 3.3011 * 10.00**23}
       
//    let planets = [|
//        { Name = "Mercury"; Type = "Rocky"; Mass = 3.3011 * (10.00**23) };
//        { Name = "Venus"; Type = "Rocky"; Mass = 4.867 * 10.00**24 }
//    |]
    
//        let numbers = [ 1.0; 2.0; 3.0; 4.0; 5.0 ]

    
    let mutable planets: List<Planet> =
        let pl = List<Planet>()
        pl.Add { Name = "Mercury"; Type = "Rocky"; Mass = 3.3011 * (10.00**23) }
        pl.Add { Name = "Venus"; Type = "Rocky"; Mass = 4.867 * 10.00**24 }
        pl

    
    
    
    [<HttpGet>]
    member _.GetAll() =
        ctx.planets
        
    [<HttpGet>]
    [<Route("{name}")>]
    member _.GetByName(name:string): Planet  =
//        try   
//        planets |> List.find(fun p -> p.Name = name)// TODO: error handle exception
//        with
//        | :? KeyNotFoundException -> Response {Message = "failure"}
          planets.Find( fun p -> p.Name = name)

        
                
    [<HttpGet>]
    [<Route("total")>]    
    member _.GetAllMass() =
       planets.ConvertAll(fun p -> p.Mass)
        
        
    // post
    [<HttpPost>]
    member _.Post(planet) =
         planets.Add planet
         planets
        
    // delete
        
        
        