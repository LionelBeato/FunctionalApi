namespace src

open System.ComponentModel.DataAnnotations
open Microsoft.EntityFrameworkCore
open EntityFrameworkCore.FSharp.Extensions

[<CLIMutable>]
type Planet =
    { Name: string
      Type: string
      Mass: float }
    
    
    member this.massCalc input exp =
        input * 10.0**exp
        
        
        
type PlanetContext(options : DbContextOptions) =
    inherit DbContext(options)
    
    [<DefaultValue>]
    val mutable planets : DbSet<Planet>
    member this.Planets with get() = this.planets and set v = this.planets <- v