namespace SwaggerProvider

open System
open ProviderImplementation.ProvidedTypes
open Microsoft.FSharp.Core.CompilerServices

/// The Swagger Type Provider.
[<TypeProvider>]
type public SwaggerTypeProvider(cfg : TypeProviderConfig) as this =
    inherit TypeProviderForNamespaces(cfg)

    do
        this.RegisterRuntimeAssemblyLocationAsProbingFolder cfg
        
        this.AddNamespace(
            SwaggerProviderConfig.NameSpace,
            [SwaggerProviderConfig.typedSwaggerProvider this.TargetContext cfg.RuntimeAssembly])