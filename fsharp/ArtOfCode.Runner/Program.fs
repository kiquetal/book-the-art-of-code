open ArtOfCode.Domain

[<EntryPoint>]
let main argv =
    if argv.Length = 0 then
        printfn "Usage: dotnet run --project fsharp/ArtOfCode.Runner/ArtOfCode.Runner.fsproj -- [chapter]"
        printfn "Examples:"
        printfn "  dotnet run --project fsharp/ArtOfCode.Runner/ArtOfCode.Runner.fsproj -- chapter1"
        printfn "  dotnet run --project fsharp/ArtOfCode.Runner/ArtOfCode.Runner.fsproj -- 1"
        printfn "\nNo arguments provided. Running Chapter 1 by default:\n"
        Chapter1.run ()
    else
        let target = argv.[0].ToLower()
        match target with
        | "1" | "chapter1" | "chapter-1" ->
            Chapter1.run ()
        | "2" | "chapter2" | "chapter-2" ->
            printfn "============================================="
            printfn " Running Chapter 2: (Not Implemented Yet)"
            printfn "============================================="
            printfn "Chapter 2 is not yet implemented."
            printfn "To implement it:"
            printfn "1. Create 'Chapter2.fs' in ArtOfCode.Domain with its own types and a 'run ()' function."
            printfn "2. Add 'Chapter2.fs' to ArtOfCode.Domain.fsproj."
            printfn "3. Add 'Chapter2.run ()' to this dispatcher in Program.fs."
        | other ->
            printfn "Unknown chapter: '%s'" other
            printfn "Valid options: '1', 'chapter1', '2', 'chapter2'"
            
    0 // return an integer exit code
