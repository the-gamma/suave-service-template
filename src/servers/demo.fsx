#if INTERACTIVE
#I "../../packages"
#r "Newtonsoft.Json/lib/net40/Newtonsoft.Json.dll"
#r "Suave/lib/net40/Suave.dll"
#r "FSharp.Data/lib/net40/FSharp.Data.dll"
#load "../common/serializer.fs"
#else
module Services.Demo
#endif
open System
open FSharp.Data
open System.IO
open System.Collections.Generic

// ------------------------------------------------------------------------------------------------
//
// ------------------------------------------------------------------------------------------------

open TheGamma.Services
// TODO: Maybe put something useful here :-)

// ------------------------------------------------------------------------------------------------
// Server
// ------------------------------------------------------------------------------------------------

open Suave
open Suave.Filters
open Suave.Operators

let app = 
  choose [
    path "/" >=>
      Serializer.returnMembers [
        Property("hello", Nested("/elsewhere"), [])
      ]
    path "/elsewhere" >=>
      Serializer.returnMembers [
        Property("hello again", Nested("/elsewhere"), [])
      ]
  ]