module IfSharp.Kernel.Config
open System
open System.Configuration
open System.Diagnostics
open System.Collections

/// Convenience method for getting a setting with a default value
let defaultConfig (name : string, defaultValue) =
    let value = ConfigurationManager.AppSettings.[name]
    if value = null then defaultValue else value

// the configuration properties
let DefaultNuGetSource = defaultConfig("DefaultNuGetSource", "")

let NuGetSources =
    match ConfigurationManager.GetSection("NuGetSources") with
    | null -> new Specialized.NameValueCollection()
    | section -> section :?> Specialized.NameValueCollection
