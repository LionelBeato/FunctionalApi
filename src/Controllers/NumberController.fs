namespace src.Controllers

open Microsoft.AspNetCore.Mvc
open Microsoft.Extensions.Logging
open System.Collections.Generic 
open src

[<ApiController>]
[<Route("[controller]")>]
type NumberController (logger : ILogger<PlanetController>) =
    inherit ControllerBase()
    
    let mutable x = "hello!" 
    
    // get -> hello world
    [<HttpGet>]
    member _.Get() =
        "hello world"
        
    [<HttpGet>]
    [<Route("{text}")>]
    member _.ChangeX(text) =
       x <- text
       x
       
    [<HttpGet>]
    [<Route("memberx")>]
    member _.GetX() =
        x
            